namespace Glad.Net;

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Text;
using Glad.Net.Spec;

public static class Generator
{
    private static readonly Dictionary<string, string> WORD_REPLACE;
    private static readonly Dictionary<string, string> TYPE_REPLACE;
    private static readonly Dictionary<string, string> NAME_REPLACE;

    static Generator()
    {
        WORD_REPLACE = new Dictionary<string, string>()
        {
            { "1d", "1D"  },
            { "2d", "2D" },
            { "2x", "TwoX" },
            { "3d", "3D" },
            { "3dfx", "3DFX" },
            { "4x", "FourX" },
            { "8x", "EightX" },
            { "amd", "AMD" },
            { "apple", "APPLE" },
            { "arb", "ARB" },
            { "ati", "ATI" },
            { "ext", "EXT" },
            { "intel", "INTEL" },
            { "mesa", "MESA" },
            { "nv", "NV" },
            { "oes", "OES" },
            { "pgi", "PGI" },
            { "qcom", "QCOM" },
            { "sgix", "SGIX" },
        };
        TYPE_REPLACE = new Dictionary<string, string>
        {
            { "struct _cl_context", "nint" },
            { "struct _cl_event", "nint" },
            { "GLbitfield", "int" },
            { "GLboolean", "bool" },
            { "GLbyte", "sbyte" },
            { "GLchar", "sbyte" },
            { "GLcharARB", "sbyte" },
            { "GLclampd", "double" },
            { "GLclampf", "float" },
            { "GLclampx", "int" },
            { "GLDEBUGPROC", "DebugProc" },
            { "GLDEBUGPROCAMD", "DebugProcAMD" },
            { "GLDEBUGPROCARB", "DebugProc" },
            { "GLDEBUGPROCKHR", "DebugProc" },
            { "GLdouble", "double" },
            { "GLeglClientBufferEXT", "nint" },
            { "GLeglImageOES", "nint" },
            { "GLfixed", "int" },
            { "GLfloat", "float" },
            { "GLhalf", "ushort" },
            { "GLhalfARB", "ushort" },
            { "GLhalfNV", "ushort" },
            { "GLhandleARB", "ushort" },
            { "GLint", "int" },
            { "GLint64", "long" },
            { "GLint64EXT", "long" },
            { "GLintptr", "nint" },
            { "GLintptrARB", "nint" },
            { "GLshort", "short" },
            { "GLsizei", "int" },
            { "GLsizeiptr", "nint" },
            { "GLsizeiptrARB", "nint" },
            { "GLsync", "nint" },
            { "GLubyte", "byte" },
            { "GLuint", "uint" },
            { "GLuint64", "ulong" },
            { "GLuint64EXT", "ulong" },
            { "GLushort", "ushort" },
            { "GLvdpauSurfaceNV", "nint" },
            { "GLvoid", "void" },
            { "GLVULKANPROCNV", "VulkanDebugProcNV" },
        };
        NAME_REPLACE = new Dictionary<string, string>
        {
            { "in", "input" },
            { "out", "output" },
            { "params", "parameters" },
            { "string", "str" },
            { "ref", "reference" }
        };
    }


    public static void Generate(Specification spec, Api api, Profile profile, Version version)
    {
        foreach (var e in spec.Enums.Values)
        {
            var vendor = e.Vendor?.ToLowerInvariant();
            if (vendor is null || WORD_REPLACE.ContainsKey(vendor))
            {
                continue;
            }

            WORD_REPLACE[vendor] = vendor.ToUpperInvariant();
        }

        var path = Path.Join(Directory.GetCurrentDirectory(), "output", "OpenGL.cs");

        using var sw = new StreamWriter(path);
        using var writer = new IndentedTextWriter(sw);

        writer.WriteLine("using System;");
        writer.WriteLine("using System.Runtime.InteropServices;");
        writer.WriteLine("using System.Security;");
        writer.WriteLine("using System.Diagnostics.CodeAnalysis;");
        writer.WriteLine();
        writer.WriteLine("namespace OpenGL");
        writer.WriteLine("{");
        writer.Indent++;
        writer.WriteLine("public delegate nint GetProcAddressHandler(string funcName);");
        writer.WriteLine("public delegate void DebugProc(int source, int type, uint id, int severity, nint length, byte[] message, nint userParam);");
        writer.WriteLine("public delegate void DebugProcAMD(uint id, int category, int severity, nint length, byte[] message, nint userParam);");
        writer.WriteLine("public delegate void VulkanDebugProcNV();");
        writer.WriteLine();
        writer.WriteLine("[AttributeUsage(AttributeTargets.All)]");
        writer.WriteLine("class GLExtensionAttribute : Attribute");
        writer.WriteLine("{");
        writer.Indent++;
        writer.WriteLine("public string Name { get; }");
        writer.WriteLine();
        writer.WriteLine("public GLExtensionAttribute(string name) => Name = name;");
        writer.Indent--;
        writer.WriteLine("}");
        writer.WriteLine();

        GenerateEnums(spec, writer);

        writer.WriteLine();

        writer.WriteLine("public static class Gl");
        writer.WriteLine("{");
        writer.Indent++;

        var imports = GenerateCommands(spec, api, profile, version, writer);

        writer.WriteLine("public static void Initialize(GetProcAddressHandler loader)");
        writer.WriteLine("{");
        writer.Indent++;
        foreach (var import in imports)
        {
            writer.WriteLine(import);
        }

        writer.Indent--;
        writer.WriteLine("}");

        writer.Indent--;
        writer.WriteLine("}");

        writer.Indent--;
        writer.WriteLine("}");
    }

    public static void GenerateEnums(Specification spec, IndentedTextWriter writer)
    {
        foreach (var enumeration in spec.Enums.Values)
        {
            if (enumeration.Group is null)
            {
                continue;
            }

            if (enumeration.Group.Contains("SpecialNumbers"))
            {
                continue;
            }

            writer.WriteLine();

            if (enumeration.Type is null)
            {
                writer.WriteLine($"public enum {enumeration.Group}");
            }
            else if (enumeration.Type.Equals("bitmask", StringComparison.Ordinal))
            {
                writer.WriteLine("[Flags]");
                writer.WriteLine($"public enum {enumeration.Group} : uint");
            }
            else
            {
                throw new InvalidOperationException("Unknown enumeration type.");
            }

            writer.WriteLine("{");
            writer.Indent++;

            var count = 0;
            foreach (var member in enumeration.Values.Select(x => x.Value))
            {
                count++;
                if (spec.TryGetExtension(member.Name, out var extension))
                {
                    writer.WriteLine();
                    writer.WriteLine($"[GLExtension(\"{extension}\")]");
                }

                var name = EnumMemberName(member.Name);
                writer.Write($"{name} = {member.Value},");
                writer.WriteLine(string.Empty);
            }

            writer.Indent--;
            writer.WriteLine("}");
        }
    }

    public static string EnumMemberName(string input)
    {
        var buffer = new StringBuilder();
        foreach (var word in input.Split('_').Select(s => s.ToLower()))
        {
            if (word == "gl")
            {
                continue;
            }

            if (WORD_REPLACE.TryGetValue(word, out var result))
            {
                buffer.Append(result);
            }
            else
            {
                buffer.Append(char.ToUpperInvariant(word[0]));
                if (word.Length > 1)
                {
                    buffer.Append(word.AsSpan(1));
                }
            }
        }
        return buffer.ToString();
    }


    public static IEnumerable<string> GenerateCommands(Specification spec, Api api, Profile profile, Version version, IndentedTextWriter writer)
    {
        var buffer = new List<string>();
        foreach (var cmd in spec.GetCommands(api, version, profile))
        {
            var import = GenerateCommand(spec, cmd!, writer);
            buffer.Add(import);
            writer.WriteLine();
        }

        return buffer;
    }

    private static string GenerateCommand(Specification spec, Command command, IndentedTextWriter writer)
    {
        var name = command.Name[2..];
        var proto = GenerateReturnType(spec, command.Proto);
        var args = command.Select(x => GenerateParameter(spec, x)).ToList();

        var argString = string.Join(", ", args);

        var delegateName = $"GL{name}";

        writer.WriteLine("[UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
        writer.WriteLine($"private delegate {proto} {delegateName}({argString});");
        writer.WriteLine($"private static {delegateName} {command.Name};");
        writer.WriteLine();

        if (spec.TryGetExtension(command.Name, out var extension))
        {
            writer.WriteLine();
            writer.WriteLine($"[GLExtension(\"{extension}\")]");
        }
        writer.WriteLine($"public static {proto} {name}({argString}) =>");
        writer.Indent++;

        writer.Write($"{command.Name}.Invoke(");

        for (var i = 0; i < args.Count; i++)
        {
            var words = args[i].Split(' ');
            if (words[0].Equals("out", StringComparison.Ordinal))
            {
                writer.Write($"out {words.Last()}");
            }
            else
            {
                writer.Write(words.Last());
            }

            if (i < args.Count - 1)
            {
                writer.Write(", ");
            }
        }
        writer.WriteLine(");");
        writer.Indent--;

        return $"{command.Name} = Marshal.GetDelegateForFunctionPointer<{delegateName}>(loader.Invoke(\"{command.Name}\"));";
    }

    public static string GenerateParameter(Specification spec, Parameter param)
    {
        var name = param.Words.Last();
        if (NAME_REPLACE.TryGetValue(name, out var value))
        {
            name = value;
        }

        if (param.Type is null)
        {
            return param.IsConstPointer ? $"nint {name}" : $"out nint {name}";
        }

        var type = param.Type;

        if (type.Equals("GLenum", StringComparison.Ordinal))
        {
            type = GetEnumName(spec, param.Group);
        }
        else if (type.Equals("GLbitfield", StringComparison.Ordinal))
        {
            type = GetBitmaskName(spec, param.Group);
        }
        else if (TYPE_REPLACE.TryGetValue(type, out var replace))
        {
            type = replace;
        }
        else
        {
            Debug.WriteLine($"Unknown GL type: {type}");
        }

        if (param.IsConstConstPointer)
        {
            Debug.WriteLine("MEH");
        }
        else if (param.IsConstPointer)
        {
            return $"{type}[] {name}";
        }
        else if (param.IsPointer)
        {
            return $"out {type} {name}";
        }

        return $"{type} {name}";
    }

    private static string GenerateReturnType(Specification spec, Prototype proto)
    {
        if (proto.IsPointer)
        {
            return "nint";
        }

        var type = proto.Words[0].Trim();
        if (type.Equals("void", StringComparison.Ordinal))
        {
            return type;
        }

        if (type.Equals("GLenum", StringComparison.Ordinal))
        {
            return GetEnumName(spec, proto.Group);
        }

        if (type.Equals("GLbitmask", StringComparison.Ordinal))
        {
            return GetBitmaskName(spec, proto.Group);
        }

        if (TYPE_REPLACE.TryGetValue(type, out var result))
        {
            return result;
        }

        Debug.WriteLine($"Unknown GL type: {type}");

        return type;
    }

    private static string GetEnumName(Specification spec, string? group)
    {
        if (group != null && spec.Enums.TryGetValue(group, out var value))
        {
            return value.Group;
        }

        return "int";
    }

    private static string GetBitmaskName(Specification spec, string? group)
    {
        if (group != null && spec.Enums.TryGetValue(group, out var value))
        {
            return value.Group;
        }

        return group ?? "uint";
    }
}

