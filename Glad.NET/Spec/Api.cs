namespace Glad.Net.Spec;

[Flags]
public enum Api : byte
{
    Disabled = 0x00,
    GL       = 0x01,
    GLES1    = 0x02,
    GLES2    = 0x04,
    GLSC2    = 0x08,
    GLCore   = 0x10,
    All = GL | GLES1 | GLES2 | GLSC2 | GLCore
}
