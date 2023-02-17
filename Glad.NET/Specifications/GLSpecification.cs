using Glad.Net.Specifications.Enums;

namespace Glad.Net.Specifications;

public class GLSpecification : Specification
{
    public override string   ApiUrl => "https://raw.githubusercontent.com/KhronosGroup/OpenGL-Registry/master/xml/gl.xml";
    public override SpecType Type   => SpecType.OpenGL;
}
