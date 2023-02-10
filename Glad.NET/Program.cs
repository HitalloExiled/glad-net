namespace Glad.Net;

using Glad.Net.Spec;

internal class Program
{
    public const string GL_XML = @"https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/master/xml/gl.xml";

    static void Main()
    {
        var spec = new GLSpecification();

        var file = Path.Join(Directory.GetCurrentDirectory(), "./Resources/gl.xml");

        spec.Load(file);

        Generator.Generate(spec, new(Api.GL | Api.GLES2, Profile.Core, new() { "OVR", "KHR" }, new Version(3, 3)));

        Console.WriteLine("Done!!!");
    }
}
