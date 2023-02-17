namespace Glad.Net;

using Glad.Net.Specifications;
using Glad.Net.Specifications.Enums;

internal class Program
{
    public const string GL_XML = @"https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/master/xml/gl.xml";

    static void Main()
    {
        // GenerateOpenGL();
        GenerateVulkan();

        Console.WriteLine("Done!!!");
    }

    private static void GenerateOpenGL()
    {
        var spec = new GLSpecification();

        var file = Path.Join(Directory.GetCurrentDirectory(), "./Resources/gl.xml");

        spec.Load(file);

        var options = new Options
        {
            Api        = Api.GL | Api.GLES2,
            Profile    = Profile.Core,
            Extensions = { "OVR", "KHR" },
            Version    = new(3, 3),
        };

        Generator.Generate(spec, options);
    }

    private static void GenerateVulkan()
    {
        var spec = new VKSpecification();

        var file = Path.Join(Directory.GetCurrentDirectory(), "./Resources/vk.xml");

        spec.Load(file);

        var options = new Options
        {
            Api        = Api.Vulkan | Api.VulkanSC,
            Profile    = Profile.Core,
            Extensions = { "OVR", "KHR" },
            Version    = new(3, 3),
        };

        Generator.Generate(spec, options);
    }
}
