using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsDemo
{
    public class Simulador
    {
        public event Action<long> MemoriaModificada;

        public long PC { get; private set; }
        public int Tempo { get; private set; }
        public bool Terminou { get; private set; }
        public string InstrucaoAtual { get; private set; }
        public int LinhaAtual { get; private set; }
        public long FreqCpu { get; private set; } = 1_000_000;

        private readonly List<string> linhasAssembly;
        private readonly int[] registradores = new int[32];
        private readonly Dictionary<long, int> memoria = new Dictionary<long, int>();
        private readonly Dictionary<string, long> labels = new Dictionary<string, long>();

        private int clkI = 1, clkJ = 1, clkR = 1;
        private int ciclosRestantes = 0;

        private readonly Dictionary<string, int> opcodes = new Dictionary<string, int>
        {
            { "add", 0 }, { "sub", 0 }, { "and", 0 }, { "or", 0 }, { "nor", 0 },
            { "slt", 0 }, { "sltu", 0 }, { "sll", 0 }, { "srl", 0 }, { "jr", 0 },
            { "addi", 8 }, { "slti", 10 }, { "sltiu", 11 }, { "andi", 12 }, { "ori", 13 },
            { "lw", 35 }, { "sw", 43 }, { "lh", 33 }, { "sh", 41 }, { "lb", 32 }, { "sb", 40 },
            { "beq", 4 }, { "bne", 5 }, { "j", 2 }, { "jal", 3 },{ "li", 13 }
        };

        private readonly Dictionary<string, int> functs = new Dictionary<string, int>
        {
            { "add", 32 }, { "sub", 34 }, { "and", 36 }, { "or", 37 }, { "nor", 39 },
            { "slt", 42 }, { "sltu", 43 }, { "sll", 0 }, { "srl", 2 }, { "jr", 8 }
        };


        public Simulador(string[] linhas)
        {
            linhasAssembly = new List<string>(linhas);
            Terminou = false;
            InstrucaoAtual = "nop";
            PreProcessar();
            ProcessarConfiguracoes();
            InicializarRegistradores();
            PC = labels.TryGetValue("main", out long mainAddr) ? mainAddr : 0x00400000;
            LinhaAtual = EncontrarLinhaDoPC(PC);
        }

        private string LimparLinha(string linha) => linha.Split('#')[0].Trim();

        private void InicializarRegistradores()
        {
            Array.Clear(registradores, 0, registradores.Length);
            registradores[29] = 0x7FFFEFFC; // $sp
            registradores[28] = 0x10008000; // $gp
            registradores[0] = 0;
        }

        private void PreProcessar()
        {
            long dataAddr = 0x10010000;
            long textAddr = 0x00400000;
            bool inDataSegment = false;
            for (int i = 0; i < linhasAssembly.Count; i++)
            {
                string linhaLimpa = LimparLinha(linhasAssembly[i]);
                if (string.IsNullOrEmpty(linhaLimpa)) continue;
                if (linhaLimpa == ".data") { inDataSegment = true; continue; }
                if (linhaLimpa == ".text") { inDataSegment = false; continue; }
                var matchLabel = Regex.Match(linhaLimpa, @"^(\w+):");
                if (matchLabel.Success)
                {
                    labels[matchLabel.Groups[1].Value] = inDataSegment ? dataAddr : textAddr;
                }
                string instrucao = linhaLimpa.Contains(':') ? linhaLimpa.Split(new[] { ':' }, 2)[1].Trim() : linhaLimpa;
                if (inDataSegment)
                {
                    if (instrucao.StartsWith(".word"))
                    {
                        var values = Regex.Match(instrucao, @"\.word\s+(.+)").Groups[1].Value.Split(',');
                        dataAddr += values.Length * 4;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(instrucao) && !instrucao.StartsWith("Config_CPU")) textAddr += 4;
                }
            }
            inDataSegment = false;
            dataAddr = 0x10010000;
            foreach (var linhaOriginal in linhasAssembly)
            {
                string linhaLimpa = LimparLinha(linhaOriginal);
                if (string.IsNullOrEmpty(linhaLimpa)) continue;
                if (linhaLimpa == ".data") { inDataSegment = true; continue; }
                if (linhaLimpa == ".text") { inDataSegment = false; continue; }
                if (!inDataSegment) continue;

                string instrucao = linhaLimpa.Contains(':') ? linhaLimpa.Split(new[] { ':' }, 2)[1].Trim() : linhaLimpa;
                var matchWord = Regex.Match(instrucao, @"\.word\s+(.+)");
                if (matchWord.Success)
                {
                    var values = matchWord.Groups[1].Value.Split(',').Select(s => int.Parse(s.Trim()));
                    foreach (var val in values)
                    {
                        if (labels.ContainsValue(dataAddr))
                        {
                            memoria[dataAddr] = val;
                        }
                        dataAddr += 4;
                    }
                }
            }
        }

        private void ProcessarConfiguracoes()
        {
            bool configLineFound = false;
            foreach (string linhaOriginal in linhasAssembly)
            {
                string linhaLimpa = LimparLinha(linhaOriginal);
                if (linhaLimpa.Contains("Config_CPU"))
                {
                    configLineFound = true;
                    var match = Regex.Match(linhaLimpa, @"\[\s*(\d+)\s*(GHZ|MHZ|HZ)\s*,\s*I=(\d+)\s*,\s*J=(\d+)\s*,\s*R=(\d+)\s*\]", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        long val = long.Parse(match.Groups[1].Value);
                        string unit = match.Groups[2].Value.ToUpper();
                        if (unit == "GHZ") FreqCpu = val * 1_000_000_000;
                        else if (unit == "MHZ") FreqCpu = val * 1_000_000;
                        else FreqCpu = val;
                        clkI = int.Parse(match.Groups[3].Value);
                        clkJ = int.Parse(match.Groups[4].Value);
                        clkR = int.Parse(match.Groups[5].Value);
                        return;
                    }
                }
            }
            if (configLineFound)
            {
                MessageBox.Show(
                    "A linha 'Config_CPU' foi encontrada, mas seu formato é inválido.\n" +
                    "Usando configurações padrão (1MHz, CPI=1).\n\n" +
                    "Formato esperado: [ FREQUENCIA, I=1, J=1, R=1 ]",
                    "Aviso de Configuração",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        public bool ProximoClock()
        {
            if (Terminou) return false;

            if (ciclosRestantes > 1)
            {
                ciclosRestantes--;
                Tempo++;
                return true;
            }

            LinhaAtual = EncontrarLinhaDoPC(PC);
            if (LinhaAtual == -1)
            {
                Terminou = true;
                InstrucaoAtual = "Execution finished.";
                return false;
            }

            Tempo++;

            string linhaExec = LimparLinha(linhasAssembly[LinhaAtual]);
            if (linhaExec.Contains(':')) linhaExec = linhaExec.Split(new[] { ':' }, 2)[1].Trim();

            if (string.IsNullOrEmpty(linhaExec))
            {
                InstrucaoAtual = "nop (empty line)";
                PC += 4;
                return ProximoClock();
            }

            InstrucaoAtual = linhaExec;
            var partes = ParseInstrucao(linhaExec);
            string instrucao = partes[0].ToLower();

            PC = ExecutarInstrucao(instrucao, partes);

            if (new[] { "add", "sub", "and", "or", "nor", "sll", "srl", "slt", "sltu", "jr" }.Contains(instrucao)) ciclosRestantes = clkR;
            else if (new[] { "addi", "lw", "sw", "lh", "sh", "lb", "sb", "andi", "ori", "beq", "bne", "la", "li" }.Contains(instrucao)) ciclosRestantes = clkI;
            else if (new[] { "j", "jal" }.Contains(instrucao)) ciclosRestantes = clkJ;
            else ciclosRestantes = 1;

            registradores[0] = 0;
            return true;
        }

        private long ExecutarInstrucao(string inst, string[] partes)
        {
            try
            {
                switch (inst)
                {
                    case "add":
                    case "sub":
                    case "and":
                    case "or":
                    case "nor":
                    case "slt":
                    case "sltu":
                        int rd = ParseRegistrador(partes[1]), rs = ParseRegistrador(partes[2]), rt = ParseRegistrador(partes[3]);
                        if (rd != 0)
                        {
                            int v_rs = registradores[rs], v_rt = registradores[rt];
                            if (inst == "add") registradores[rd] = v_rs + v_rt;
                            else if (inst == "sub") registradores[rd] = v_rs - v_rt;
                            else if (inst == "and") registradores[rd] = v_rs & v_rt;
                            else if (inst == "or") registradores[rd] = v_rs | v_rt;
                            else if (inst == "nor") registradores[rd] = ~(v_rs | v_rt);
                            else if (inst == "slt") registradores[rd] = (v_rs < v_rt) ? 1 : 0;
                            else if (inst == "sltu") registradores[rd] = ((uint)v_rs < (uint)v_rt) ? 1 : 0;
                        }
                        return PC + 4;
                    case "sll":
                    case "srl":
                        rd = ParseRegistrador(partes[1]); rt = ParseRegistrador(partes[2]); int shamt = int.Parse(partes[3]);
                        if (rd != 0)
                        {
                            if (inst == "sll") registradores[rd] = registradores[rt] << shamt;
                            else registradores[rd] = (int)((uint)registradores[rt] >> shamt);
                        }
                        return PC + 4;
                    case "addi":
                    case "slti":
                    case "sltiu":
                    case "andi":
                    case "ori":
                        rt = ParseRegistrador(partes[1]); rs = ParseRegistrador(partes[2]); int imm = ParseImmediate(partes[3]);
                        if (rt != 0)
                        {
                            if (inst == "addi") registradores[rt] = registradores[rs] + imm;
                            else if (inst == "andi") registradores[rt] = registradores[rs] & imm;
                            else if (inst == "ori") registradores[rt] = registradores[rs] | imm;
                            else if (inst == "slti") registradores[rt] = (registradores[rs] < imm) ? 1 : 0;
                            else if (inst == "sltiu") registradores[rt] = ((uint)registradores[rs] < (uint)imm) ? 1 : 0;
                        }
                        return PC + 4;
                    case "li":
                        rt = ParseRegistrador(partes[1]);
                        imm = ParseImmediate(partes[2]);
                        if (rt != 0) registradores[rt] = imm;
                        return PC + 4;
                    case "la":
                        rt = ParseRegistrador(partes[1]);
                        if (labels.TryGetValue(partes[2], out long labelAddr))
                        {
                            if (rt != 0) registradores[rt] = (int)labelAddr;
                        }
                        else throw new KeyNotFoundException($"Label '{partes[2]}' não encontrado.");
                        return PC + 4;
                    case "lw":
                    case "sw":
                    case "lb":
                    case "sb":
                    case "lh":
                    case "sh":
                        string operand = partes[2];
                        if (operand.Contains("(") && operand.Contains(")"))
                        {
                            ProcessarMemoria(inst, ParseRegistrador(partes[1]), operand);
                        }
                        else
                        {
                            int reg = ParseRegistrador(partes[1]);
                            if (labels.TryGetValue(operand, out long addr))
                            {
                                if (inst == "lw")
                                {
                                    if (memoria.TryGetValue(addr, out int value)) registradores[reg] = value;
                                    else registradores[reg] = 0;
                                }
                                else if (inst == "sw")
                                {
                                    memoria[addr] = registradores[reg];
                                    MemoriaModificada?.Invoke(addr);
                                }
                            }
                            else throw new KeyNotFoundException($"Label '{operand}' não encontrado para instrução {inst}.");
                        }
                        return PC + 4;
                    case "beq":
                    case "bne":
                        rs = ParseRegistrador(partes[1]); rt = ParseRegistrador(partes[2]); string label = partes[3];
                        if (!labels.TryGetValue(label, out long targetAddr))
                        {
                            int offset = ParseImmediate(label);
                            targetAddr = PC + 4 + (offset << 2);
                        }
                        bool branch = (inst == "beq" && registradores[rs] == registradores[rt]) || (inst == "bne" && registradores[rs] != registradores[rt]);
                        return branch ? targetAddr : PC + 4;
                    case "j": return ParseImmediate(partes[1]);
                    case "jal":
                        registradores[31] = (int)(PC + 4);
                        return ParseImmediate(partes[1]);
                    case "jr": return (long)(uint)registradores[ParseRegistrador(partes[1])];
                    case "nop": return PC + 4;
                    default: throw new ArgumentException($"Instrução '{inst}' não reconhecida.");
                }
            }
            catch (Exception ex) { throw new Exception($"Erro na instrução '{string.Join(" ", partes)}': {ex.Message}", ex); }
        }

        private void ProcessarMemoria(string inst, int rtReg, string memStr)
        {
            var match = Regex.Match(memStr, @"(-?[\w\.]+)?\((\$\w+\d*)\)");
            if (!match.Success) throw new ArgumentException("Formato de memória inválido.");
            int offset = match.Groups[1].Value != "" ? ParseImmediate(match.Groups[1].Value) : 0;
            int baseReg = ParseRegistrador(match.Groups[2].Value);
            long addr = registradores[baseReg] + offset;
            long alignedAddr = addr & 0xFFFFFFFC;
            if (!memoria.ContainsKey(alignedAddr)) memoria[alignedAddr] = 0;
            int word = memoria[alignedAddr];

            if ((inst == "lh" || inst == "sh") && addr % 2 != 0) throw new Exception($"Erro de alinhamento em {inst}.");

            switch (inst)
            {
                case "lw": registradores[rtReg] = word; break;
                case "sw": memoria[alignedAddr] = registradores[rtReg]; MemoriaModificada?.Invoke(alignedAddr); break;
                case "lh": registradores[rtReg] = (short)((word >> ((1 - (int)(addr % 4) / 2) * 16)) & 0xFFFF); break;
                case "sh":
                    int shift_sh = (1 - (int)(addr % 4) / 2) * 16;
                    memoria[alignedAddr] = (word & ~(0xFFFF << shift_sh)) | ((registradores[rtReg] & 0xFFFF) << shift_sh);
                    MemoriaModificada?.Invoke(alignedAddr);
                    break;
                case "lb": registradores[rtReg] = (sbyte)((word >> ((3 - (int)(addr % 4)) * 8)) & 0xFF); break;
                case "sb":
                    int shift_sb = (3 - (int)(addr % 4)) * 8;
                    memoria[alignedAddr] = (word & ~(0xFF << shift_sb)) | ((registradores[rtReg] & 0xFF) << shift_sb);
                    MemoriaModificada?.Invoke(alignedAddr);
                    break;
            }
        }

        private int EncontrarLinhaDoPC(long pcValue)
        {
            long textAddr = 0x00400000;
            bool inTextSegment = true;
            for (int i = 0; i < linhasAssembly.Count; i++)
            {
                string linha = LimparLinha(linhasAssembly[i]);
                if (string.IsNullOrEmpty(linha)) continue;
                if (linha == ".data") { inTextSegment = false; continue; }
                if (linha == ".text") { inTextSegment = true; continue; }
                if (!inTextSegment) continue;
                string instrucaoPotencial = linha.Contains(':') ? linha.Split(new[] { ':' }, 2)[1].Trim() : linha;
                if (!string.IsNullOrEmpty(instrucaoPotencial) && !instrucaoPotencial.StartsWith("Config_CPU"))
                {
                    if (textAddr == pcValue) return i;
                    textAddr += 4;
                }
            }
            return -1;
        }

        private string[] ParseInstrucao(string linha) => linha.Replace(",", " ").Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        private int ParseRegistrador(string regStr)
        {
            regStr = regStr.ToLower().Trim();
            var regMap = new Dictionary<string, int> {
                {"$zero", 0}, {"$at", 1}, {"$v0", 2}, {"$v1", 3}, {"$a0", 4}, {"$a1", 5}, {"$a2", 6}, {"$a3", 7},
                {"$t0", 8}, {"$t1", 9}, {"$t2", 10}, {"$t3", 11}, {"$t4", 12}, {"$t5", 13}, {"$t6", 14}, {"$t7", 15},
                {"$s0", 16}, {"$s1", 17}, {"$s2", 18}, {"$s3", 19}, {"$s4", 20}, {"$s5", 21}, {"$s6", 22}, {"$s7", 23},
                {"$t8", 24}, {"$t9", 25}, {"$k0", 26}, {"$k1", 27}, {"$gp", 28}, {"$sp", 29}, {"$fp", 30}, {"$ra", 31}
            };
            if (regMap.ContainsKey(regStr)) return regMap[regStr];
            if (regStr.StartsWith("$") && int.TryParse(regStr.Substring(1), out int num)) return num;
            throw new ArgumentException($"Registrador inválido: '{regStr}'");
        }
        private int ParseImmediate(string valStr)
        {
            valStr = valStr.Trim();
            if (labels.TryGetValue(valStr, out long addr)) return (int)addr;
            if (valStr.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) return int.Parse(valStr.Substring(2), NumberStyles.HexNumber);
            return int.Parse(valStr);
        }
        public int[] GetRegistradores() => (int[])registradores.Clone();
        public Dictionary<long, int> GetMemoria() => new Dictionary<long, int>(memoria);
        public string GerarCodigoMaquina()
        {
            if (string.IsNullOrEmpty(InstrucaoAtual) || InstrucaoAtual.StartsWith("Exec") || InstrucaoAtual.StartsWith("nop"))
            {
                return "N/A";
            }

            try
            {
                var partes = ParseInstrucao(InstrucaoAtual);
                string inst = partes[0].ToLower();
                uint codigoMaquina = 0;

                if (!opcodes.ContainsKey(inst))
                {
                    return "Instrução desconhecida";
                }

                int opcode = opcodes[inst];
                codigoMaquina |= (uint)opcode << 26;

                // Tipo R (opcode 0)
                if (opcode == 0)
                {
                    int funct = functs[inst];
                    if (inst == "jr")
                    {
                        int rs = ParseRegistrador(partes[1]);
                        codigoMaquina |= (uint)rs << 21;
                    }
                    else if (inst == "sll" || inst == "srl") // formato: sll $d, $t, shamt
                    {
                        int rd = ParseRegistrador(partes[1]);
                        int rt = ParseRegistrador(partes[2]);
                        int shamt = ParseImmediate(partes[3]);
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)rd << 11;
                        codigoMaquina |= (uint)shamt << 6;
                    }
                    else // formato: add $d, $s, $t
                    {
                        int rd = ParseRegistrador(partes[1]);
                        int rs = ParseRegistrador(partes[2]);
                        int rt = ParseRegistrador(partes[3]);
                        codigoMaquina |= (uint)rs << 21;
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)rd << 11;
                    }
                    codigoMaquina |= (uint)funct;
                }
                // Tipo J
                else if (inst == "j" || inst == "jal")
                {
                    long targetAddr = ParseImmediate(partes[1]);
                    uint pseudoAddress = (uint)(targetAddr & 0x0FFFFFFF) >> 2;
                    codigoMaquina |= pseudoAddress;
                }
                // Tipo I
                else
                {
                    if (inst == "li")
                    {
                        int rt = ParseRegistrador(partes[1]);
                        int imm = ParseImmediate(partes[2]);
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)(imm & 0xFFFF);
                    }
                    else if (inst == "beq" || inst == "bne")
                    {
                        int rs = ParseRegistrador(partes[1]);
                        int rt = ParseRegistrador(partes[2]);
                        long targetAddr = labels[partes[3]];
                        int offset = (int)((targetAddr - (PC + 4)) / 4);
                        codigoMaquina |= (uint)rs << 21;
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)(offset & 0xFFFF);
                    }
                    else if (inst == "lw" || inst == "sw" || inst == "lb" || inst == "sb" || inst == "lh" || inst == "sh") // formato: lw $t, offset($s)
                    {
                        int rt = ParseRegistrador(partes[1]);
                        var match = Regex.Match(partes[2], @"(-?[\w\.]+)?\((\$\w+\d*)\)");
                        int offset = match.Groups[1].Value != "" ? ParseImmediate(match.Groups[1].Value) : 0;
                        int rs = ParseRegistrador(match.Groups[2].Value);

                        codigoMaquina |= (uint)rs << 21;
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)(offset & 0xFFFF);
                    }
                    else
                    {
                        int rt = ParseRegistrador(partes[1]);
                        int rs = ParseRegistrador(partes[2]);
                        int imm = ParseImmediate(partes[3]);
                        codigoMaquina |= (uint)rs << 21;
                        codigoMaquina |= (uint)rt << 16;
                        codigoMaquina |= (uint)(imm & 0xFFFF);
                    }
                }

                return $"0x{codigoMaquina:X8}";
            }
            catch (Exception)
            {
                return "Erro na conversão";
            }
        }
    }
}