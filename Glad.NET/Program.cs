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

        Generator.Generate(spec, Api.All, Profile.All, new Version(5, 0));

        Console.WriteLine("Done!!!");
    }
}
