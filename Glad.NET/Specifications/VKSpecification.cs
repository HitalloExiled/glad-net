using Glad.Net.Specifications.Enums;

namespace Glad.Net.Specifications;

public class VKSpecification : Specification
{
    public override string   ApiUrl => "https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/main/xml/vk.xml";
    public override SpecType Type   => SpecType.VK;
}
