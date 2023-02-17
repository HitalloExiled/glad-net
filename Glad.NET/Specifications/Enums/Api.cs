namespace Glad.Net.Specifications.Enums;

[Flags]
public enum Api : byte
{
    Disabled = 0,
    GL       = 1 << 1,
    GLES1    = 1 << 2,
    GLES2    = 1 << 3,
    GLSC2    = 1 << 4,
    GLCore   = 1 << 5,
    Vulkan   = 1 << 6,
    VulkanSC = 1 << 7,
    All      = GL | GLES1 | GLES2 | GLSC2 | GLCore | Vulkan | VulkanSC
}
