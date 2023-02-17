using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics.CodeAnalysis;

namespace OpenGL
{
    public delegate nint GetProcAddressHandler(string funcName);
    public delegate void DebugProc(int source, int type, uint id, int severity, nint length, byte[] message, nint userParam);
    public delegate void DebugProcAMD(uint id, int category, int severity, nint length, byte[] message, nint userParam);
    public delegate void VulkanDebugProcNV();
    
    [AttributeUsage(AttributeTargets.All)]
    class VulkanExtensionAttribute : Attribute
    {
        public string Name { get; }
        
        public VulkanExtensionAttribute(string name) => Name = name;
    }
    
    
public enum GlEnum
{
    MaxPhysicalDeviceNameSize = 256,
    UuidSize = 16,
    LuidSize = 8,

    [VulkanExtension("VK_KHR_external_memory_capabilities")]
    LuidSizeKhr = ,
    MaxExtensionNameSize = 256,
    MaxDescriptionSize = 256,
    MaxMemoryTypes = 32,
    MaxMemoryHeaps = 16,
    LodClampNone = 1000.0F,
    RemainingMipLevels = (~0U),
    RemainingArrayLayers = (~0U),
    WholeSize = (~0ULL),
    AttachmentUnused = (~0U),
    True = 1,
    False = 0,
    QueueFamilyIgnored = (~0U),
    QueueFamilyExternal = (~1U),

    [VulkanExtension("VK_KHR_external_memory")]
    QueueFamilyExternalKhr = ,
    SubpassExternal = (~0U),
    MaxDeviceGroupSize = 32,

    [VulkanExtension("VK_KHR_device_group_creation")]
    MaxDeviceGroupSizeKhr = ,
    MaxDriverNameSize = 256,

    [VulkanExtension("VK_KHR_driver_properties")]
    MaxDriverNameSizeKhr = ,
    MaxDriverInfoSize = 256,

    [VulkanExtension("VK_KHR_driver_properties")]
    MaxDriverInfoSizeKhr = ,

    [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
    ShaderUnusedKhr = (~0U),

    [VulkanExtension("VK_KHR_global_priority")]
    MaxGlobalPrioritySizeKhr = 16,
    ImageLayoutUndefined = 0,
    ImageLayoutGeneral = 1,
    ImageLayoutColorAttachmentOptimal = 2,
    ImageLayoutDepthStencilAttachmentOptimal = 3,
    ImageLayoutDepthStencilReadOnlyOptimal = 4,
    ImageLayoutShaderReadOnlyOptimal = 5,
    ImageLayoutTransferSrcOptimal = 6,
    ImageLayoutTransferDstOptimal = 7,
    ImageLayoutPreinitialized = 8,
    AttachmentLoadOpLoad = 0,
    AttachmentLoadOpClear = 1,
    AttachmentLoadOpDontCare = 2,
    AttachmentStoreOpStore = 0,
    AttachmentStoreOpDontCare = 1,
    ImageType1D = 0,
    ImageType2D = 1,
    ImageType3D = 2,
    ImageTilingOptimal = 0,
    ImageTilingLinear = 1,
    ImageViewType1D = 0,
    ImageViewType2D = 1,
    ImageViewType3D = 2,
    ImageViewTypeCube = 3,
    ImageViewType1DArray = 4,
    ImageViewType2DArray = 5,
    ImageViewTypeCubeArray = 6,
    CommandBufferLevelPrimary = 0,
    CommandBufferLevelSecondary = 1,
    ComponentSwizzleIdentity = 0,
    ComponentSwizzleZero = 1,
    ComponentSwizzleOne = 2,
    ComponentSwizzleR = 3,
    ComponentSwizzleG = 4,
    ComponentSwizzleB = 5,
    ComponentSwizzleA = 6,
    DescriptorTypeSampler = 0,
    DescriptorTypeCombinedImageSampler = 1,
    DescriptorTypeSampledImage = 2,
    DescriptorTypeStorageImage = 3,
    DescriptorTypeUniformTexelBuffer = 4,
    DescriptorTypeStorageTexelBuffer = 5,
    DescriptorTypeUniformBuffer = 6,
    DescriptorTypeStorageBuffer = 7,
    DescriptorTypeUniformBufferDynamic = 8,
    DescriptorTypeStorageBufferDynamic = 9,
    DescriptorTypeInputAttachment = 10,
    QueryTypeOcclusion = 0,
    QueryTypePipelineStatistics = 1,
    QueryTypeTimestamp = 2,
    BorderColorFloatTransparentBlack = 0,
    BorderColorIntTransparentBlack = 1,
    BorderColorFloatOpaqueBlack = 2,
    BorderColorIntOpaqueBlack = 3,
    BorderColorFloatOpaqueWhite = 4,
    BorderColorIntOpaqueWhite = 5,
    PipelineBindPointGraphics = 0,
    PipelineBindPointCompute = 1,
    PipelineCacheHeaderVersionOne = 1,
    PrimitiveTopologyPointList = 0,
    PrimitiveTopologyLineList = 1,
    PrimitiveTopologyLineStrip = 2,
    PrimitiveTopologyTriangleList = 3,
    PrimitiveTopologyTriangleStrip = 4,
    PrimitiveTopologyTriangleFan = 5,
    PrimitiveTopologyLineListWithAdjacency = 6,
    PrimitiveTopologyLineStripWithAdjacency = 7,
    PrimitiveTopologyTriangleListWithAdjacency = 8,
    PrimitiveTopologyTriangleStripWithAdjacency = 9,
    PrimitiveTopologyPatchList = 10,
    SharingModeExclusive = 0,
    SharingModeConcurrent = 1,
    IndexTypeUint16 = 0,
    IndexTypeUint32 = 1,
    FilterNearest = 0,
    FilterLinear = 1,
    SamplerMipmapModeNearest = 0,
    SamplerMipmapModeLinear = 1,
    SamplerAddressModeRepeat = 0,
    SamplerAddressModeMirroredRepeat = 1,
    SamplerAddressModeClampToEdge = 2,
    SamplerAddressModeClampToBorder = 3,
    CompareOpNever = 0,
    CompareOpLess = 1,
    CompareOpEqual = 2,
    CompareOpLessOrEqual = 3,
    CompareOpGreater = 4,
    CompareOpNotEqual = 5,
    CompareOpGreaterOrEqual = 6,
    CompareOpAlways = 7,
    PolygonModeFill = 0,
    PolygonModeLine = 1,
    PolygonModePoint = 2,
    FrontFaceCounterClockwise = 0,
    FrontFaceClockwise = 1,
    BlendFactorZero = 0,
    BlendFactorOne = 1,
    BlendFactorSrcColor = 2,
    BlendFactorOneMinusSrcColor = 3,
    BlendFactorDstColor = 4,
    BlendFactorOneMinusDstColor = 5,
    BlendFactorSrcAlpha = 6,
    BlendFactorOneMinusSrcAlpha = 7,
    BlendFactorDstAlpha = 8,
    BlendFactorOneMinusDstAlpha = 9,
    BlendFactorConstantColor = 10,
    BlendFactorOneMinusConstantColor = 11,
    BlendFactorConstantAlpha = 12,
    BlendFactorOneMinusConstantAlpha = 13,
    BlendFactorSrcAlphaSaturate = 14,
    BlendFactorSrc1Color = 15,
    BlendFactorOneMinusSrc1Color = 16,
    BlendFactorSrc1Alpha = 17,
    BlendFactorOneMinusSrc1Alpha = 18,
    BlendOpAdd = 0,
    BlendOpSubtract = 1,
    BlendOpReverseSubtract = 2,
    BlendOpMin = 3,
    BlendOpMax = 4,
    StencilOpKeep = 0,
    StencilOpZero = 1,
    StencilOpReplace = 2,
    StencilOpIncrementAndClamp = 3,
    StencilOpDecrementAndClamp = 4,
    StencilOpInvert = 5,
    StencilOpIncrementAndWrap = 6,
    StencilOpDecrementAndWrap = 7,
    LogicOpClear = 0,
    LogicOpAnd = 1,
    LogicOpAndReverse = 2,
    LogicOpCopy = 3,
    LogicOpAndInverted = 4,
    LogicOpNoOp = 5,
    LogicOpXor = 6,
    LogicOpOr = 7,
    LogicOpNor = 8,
    LogicOpEquivalent = 9,
    LogicOpInvert = 10,
    LogicOpOrReverse = 11,
    LogicOpCopyInverted = 12,
    LogicOpOrInverted = 13,
    LogicOpNand = 14,
    LogicOpSet = 15,
    InternalAllocationTypeExecutable = 0,
    SystemAllocationScopeCommand = 0,
    SystemAllocationScopeObject = 1,
    SystemAllocationScopeCache = 2,
    SystemAllocationScopeDevice = 3,
    SystemAllocationScopeInstance = 4,
    PhysicalDeviceTypeOther = 0,
    PhysicalDeviceTypeIntegratedGpu = 1,
    PhysicalDeviceTypeDiscreteGpu = 2,
    PhysicalDeviceTypeVirtualGpu = 3,
    PhysicalDeviceTypeCpu = 4,
    VertexInputRateVertex = 0,
    VertexInputRateInstance = 1,
    FormatUndefined = 0,
    FormatR4g4UnormPack8 = 1,
    FormatR4g4b4a4UnormPack16 = 2,
    FormatB4g4r4a4UnormPack16 = 3,
    FormatR5g6b5UnormPack16 = 4,
    FormatB5g6r5UnormPack16 = 5,
    FormatR5g5b5a1UnormPack16 = 6,
    FormatB5g5r5a1UnormPack16 = 7,
    FormatA1r5g5b5UnormPack16 = 8,
    FormatR8Unorm = 9,
    FormatR8Snorm = 10,
    FormatR8Uscaled = 11,
    FormatR8Sscaled = 12,
    FormatR8Uint = 13,
    FormatR8Sint = 14,
    FormatR8Srgb = 15,
    FormatR8g8Unorm = 16,
    FormatR8g8Snorm = 17,
    FormatR8g8Uscaled = 18,
    FormatR8g8Sscaled = 19,
    FormatR8g8Uint = 20,
    FormatR8g8Sint = 21,
    FormatR8g8Srgb = 22,
    FormatR8g8b8Unorm = 23,
    FormatR8g8b8Snorm = 24,
    FormatR8g8b8Uscaled = 25,
    FormatR8g8b8Sscaled = 26,
    FormatR8g8b8Uint = 27,
    FormatR8g8b8Sint = 28,
    FormatR8g8b8Srgb = 29,
    FormatB8g8r8Unorm = 30,
    FormatB8g8r8Snorm = 31,
    FormatB8g8r8Uscaled = 32,
    FormatB8g8r8Sscaled = 33,
    FormatB8g8r8Uint = 34,
    FormatB8g8r8Sint = 35,
    FormatB8g8r8Srgb = 36,
    FormatR8g8b8a8Unorm = 37,
    FormatR8g8b8a8Snorm = 38,
    FormatR8g8b8a8Uscaled = 39,
    FormatR8g8b8a8Sscaled = 40,
    FormatR8g8b8a8Uint = 41,
    FormatR8g8b8a8Sint = 42,
    FormatR8g8b8a8Srgb = 43,
    FormatB8g8r8a8Unorm = 44,
    FormatB8g8r8a8Snorm = 45,
    FormatB8g8r8a8Uscaled = 46,
    FormatB8g8r8a8Sscaled = 47,
    FormatB8g8r8a8Uint = 48,
    FormatB8g8r8a8Sint = 49,
    FormatB8g8r8a8Srgb = 50,
    FormatA8b8g8r8UnormPack32 = 51,
    FormatA8b8g8r8SnormPack32 = 52,
    FormatA8b8g8r8UscaledPack32 = 53,
    FormatA8b8g8r8SscaledPack32 = 54,
    FormatA8b8g8r8UintPack32 = 55,
    FormatA8b8g8r8SintPack32 = 56,
    FormatA8b8g8r8SrgbPack32 = 57,
    FormatA2r10g10b10UnormPack32 = 58,
    FormatA2r10g10b10SnormPack32 = 59,
    FormatA2r10g10b10UscaledPack32 = 60,
    FormatA2r10g10b10SscaledPack32 = 61,
    FormatA2r10g10b10UintPack32 = 62,
    FormatA2r10g10b10SintPack32 = 63,
    FormatA2b10g10r10UnormPack32 = 64,
    FormatA2b10g10r10SnormPack32 = 65,
    FormatA2b10g10r10UscaledPack32 = 66,
    FormatA2b10g10r10SscaledPack32 = 67,
    FormatA2b10g10r10UintPack32 = 68,
    FormatA2b10g10r10SintPack32 = 69,
    FormatR16Unorm = 70,
    FormatR16Snorm = 71,
    FormatR16Uscaled = 72,
    FormatR16Sscaled = 73,
    FormatR16Uint = 74,
    FormatR16Sint = 75,
    FormatR16Sfloat = 76,
    FormatR16g16Unorm = 77,
    FormatR16g16Snorm = 78,
    FormatR16g16Uscaled = 79,
    FormatR16g16Sscaled = 80,
    FormatR16g16Uint = 81,
    FormatR16g16Sint = 82,
    FormatR16g16Sfloat = 83,
    FormatR16g16b16Unorm = 84,
    FormatR16g16b16Snorm = 85,
    FormatR16g16b16Uscaled = 86,
    FormatR16g16b16Sscaled = 87,
    FormatR16g16b16Uint = 88,
    FormatR16g16b16Sint = 89,
    FormatR16g16b16Sfloat = 90,
    FormatR16g16b16a16Unorm = 91,
    FormatR16g16b16a16Snorm = 92,
    FormatR16g16b16a16Uscaled = 93,
    FormatR16g16b16a16Sscaled = 94,
    FormatR16g16b16a16Uint = 95,
    FormatR16g16b16a16Sint = 96,
    FormatR16g16b16a16Sfloat = 97,
    FormatR32Uint = 98,
    FormatR32Sint = 99,
    FormatR32Sfloat = 100,
    FormatR32g32Uint = 101,
    FormatR32g32Sint = 102,
    FormatR32g32Sfloat = 103,
    FormatR32g32b32Uint = 104,
    FormatR32g32b32Sint = 105,
    FormatR32g32b32Sfloat = 106,
    FormatR32g32b32a32Uint = 107,
    FormatR32g32b32a32Sint = 108,
    FormatR32g32b32a32Sfloat = 109,
    FormatR64Uint = 110,
    FormatR64Sint = 111,
    FormatR64Sfloat = 112,
    FormatR64g64Uint = 113,
    FormatR64g64Sint = 114,
    FormatR64g64Sfloat = 115,
    FormatR64g64b64Uint = 116,
    FormatR64g64b64Sint = 117,
    FormatR64g64b64Sfloat = 118,
    FormatR64g64b64a64Uint = 119,
    FormatR64g64b64a64Sint = 120,
    FormatR64g64b64a64Sfloat = 121,
    FormatB10g11r11UfloatPack32 = 122,
    FormatE5b9g9r9UfloatPack32 = 123,
    FormatD16Unorm = 124,
    FormatX8D24UnormPack32 = 125,
    FormatD32Sfloat = 126,
    FormatS8Uint = 127,
    FormatD16UnormS8Uint = 128,
    FormatD24UnormS8Uint = 129,
    FormatD32SfloatS8Uint = 130,
    FormatBc1RgbUnormBlock = 131,
    FormatBc1RgbSrgbBlock = 132,
    FormatBc1RgbaUnormBlock = 133,
    FormatBc1RgbaSrgbBlock = 134,
    FormatBc2UnormBlock = 135,
    FormatBc2SrgbBlock = 136,
    FormatBc3UnormBlock = 137,
    FormatBc3SrgbBlock = 138,
    FormatBc4UnormBlock = 139,
    FormatBc4SnormBlock = 140,
    FormatBc5UnormBlock = 141,
    FormatBc5SnormBlock = 142,
    FormatBc6hUfloatBlock = 143,
    FormatBc6hSfloatBlock = 144,
    FormatBc7UnormBlock = 145,
    FormatBc7SrgbBlock = 146,
    FormatEtc2R8g8b8UnormBlock = 147,
    FormatEtc2R8g8b8SrgbBlock = 148,
    FormatEtc2R8g8b8a1UnormBlock = 149,
    FormatEtc2R8g8b8a1SrgbBlock = 150,
    FormatEtc2R8g8b8a8UnormBlock = 151,
    FormatEtc2R8g8b8a8SrgbBlock = 152,
    FormatEacR11UnormBlock = 153,
    FormatEacR11SnormBlock = 154,
    FormatEacR11g11UnormBlock = 155,
    FormatEacR11g11SnormBlock = 156,
    FormatAstc4x4UnormBlock = 157,
    FormatAstc4x4SrgbBlock = 158,
    FormatAstc5x4UnormBlock = 159,
    FormatAstc5x4SrgbBlock = 160,
    FormatAstc5x5UnormBlock = 161,
    FormatAstc5x5SrgbBlock = 162,
    FormatAstc6x5UnormBlock = 163,
    FormatAstc6x5SrgbBlock = 164,
    FormatAstc6x6UnormBlock = 165,
    FormatAstc6x6SrgbBlock = 166,
    FormatAstc8x5UnormBlock = 167,
    FormatAstc8x5SrgbBlock = 168,
    FormatAstc8x6UnormBlock = 169,
    FormatAstc8x6SrgbBlock = 170,
    FormatAstc8x8UnormBlock = 171,
    FormatAstc8x8SrgbBlock = 172,
    FormatAstc10x5UnormBlock = 173,
    FormatAstc10x5SrgbBlock = 174,
    FormatAstc10x6UnormBlock = 175,
    FormatAstc10x6SrgbBlock = 176,
    FormatAstc10x8UnormBlock = 177,
    FormatAstc10x8SrgbBlock = 178,
    FormatAstc10x10UnormBlock = 179,
    FormatAstc10x10SrgbBlock = 180,
    FormatAstc12x10UnormBlock = 181,
    FormatAstc12x10SrgbBlock = 182,
    FormatAstc12x12UnormBlock = 183,
    FormatAstc12x12SrgbBlock = 184,
    StructureTypeApplicationInfo = 0,
    StructureTypeInstanceCreateInfo = 1,
    StructureTypeDeviceQueueCreateInfo = 2,
    StructureTypeDeviceCreateInfo = 3,
    StructureTypeSubmitInfo = 4,
    StructureTypeMemoryAllocateInfo = 5,
    StructureTypeMappedMemoryRange = 6,
    StructureTypeBindSparseInfo = 7,
    StructureTypeFenceCreateInfo = 8,
    StructureTypeSemaphoreCreateInfo = 9,
    StructureTypeEventCreateInfo = 10,
    StructureTypeQueryPoolCreateInfo = 11,
    StructureTypeBufferCreateInfo = 12,
    StructureTypeBufferViewCreateInfo = 13,
    StructureTypeImageCreateInfo = 14,
    StructureTypeImageViewCreateInfo = 15,
    StructureTypeShaderModuleCreateInfo = 16,
    StructureTypePipelineCacheCreateInfo = 17,
    StructureTypePipelineShaderStageCreateInfo = 18,
    StructureTypePipelineVertexInputStateCreateInfo = 19,
    StructureTypePipelineInputAssemblyStateCreateInfo = 20,
    StructureTypePipelineTessellationStateCreateInfo = 21,
    StructureTypePipelineViewportStateCreateInfo = 22,
    StructureTypePipelineRasterizationStateCreateInfo = 23,
    StructureTypePipelineMultisampleStateCreateInfo = 24,
    StructureTypePipelineDepthStencilStateCreateInfo = 25,
    StructureTypePipelineColorBlendStateCreateInfo = 26,
    StructureTypePipelineDynamicStateCreateInfo = 27,
    StructureTypeGraphicsPipelineCreateInfo = 28,
    StructureTypeComputePipelineCreateInfo = 29,
    StructureTypePipelineLayoutCreateInfo = 30,
    StructureTypeSamplerCreateInfo = 31,
    StructureTypeDescriptorSetLayoutCreateInfo = 32,
    StructureTypeDescriptorPoolCreateInfo = 33,
    StructureTypeDescriptorSetAllocateInfo = 34,
    StructureTypeWriteDescriptorSet = 35,
    StructureTypeCopyDescriptorSet = 36,
    StructureTypeFramebufferCreateInfo = 37,
    StructureTypeRenderPassCreateInfo = 38,
    StructureTypeCommandPoolCreateInfo = 39,
    StructureTypeCommandBufferAllocateInfo = 40,
    StructureTypeCommandBufferInheritanceInfo = 41,
    StructureTypeCommandBufferBeginInfo = 42,
    StructureTypeRenderPassBeginInfo = 43,
    StructureTypeBufferMemoryBarrier = 44,
    StructureTypeImageMemoryBarrier = 45,
    StructureTypeMemoryBarrier = 46,
    StructureTypeLoaderInstanceCreateInfo = 47,
    StructureTypeLoaderDeviceCreateInfo = 48,
    SubpassContentsInline = 0,
    SubpassContentsSecondaryCommandBuffers = 1,
    Success = 0,
    NotReady = 1,
    Timeout = 2,
    EventSet = 3,
    EventReset = 4,
    Incomplete = 5,
    ErrorOutOfHostMemory = -1,
    ErrorOutOfDeviceMemory = -2,
    ErrorInitializationFailed = -3,
    ErrorDeviceLost = -4,
    ErrorMemoryMapFailed = -5,
    ErrorLayerNotPresent = -6,
    ErrorExtensionNotPresent = -7,
    ErrorFeatureNotPresent = -8,
    ErrorIncompatibleDriver = -9,
    ErrorTooManyObjects = -10,
    ErrorFormatNotSupported = -11,
    ErrorFragmentedPool = -12,
    ErrorUnknown = -13,
    DynamicStateViewport = 0,
    DynamicStateScissor = 1,
    DynamicStateLineWidth = 2,
    DynamicStateDepthBias = 3,
    DynamicStateBlendConstants = 4,
    DynamicStateDepthBounds = 5,
    DynamicStateStencilCompareMask = 6,
    DynamicStateStencilWriteMask = 7,
    DynamicStateStencilReference = 8,
    DescriptorUpdateTemplateTypeDescriptorSet = 0,
    ObjectTypeUnknown = 0,
    ObjectTypeInstance = 1,
    ObjectTypePhysicalDevice = 2,
    ObjectTypeDevice = 3,
    ObjectTypeQueue = 4,
    ObjectTypeSemaphore = 5,
    ObjectTypeCommandBuffer = 6,
    ObjectTypeFence = 7,
    ObjectTypeDeviceMemory = 8,
    ObjectTypeBuffer = 9,
    ObjectTypeImage = 10,
    ObjectTypeEvent = 11,
    ObjectTypeQueryPool = 12,
    ObjectTypeBufferView = 13,
    ObjectTypeImageView = 14,
    ObjectTypeShaderModule = 15,
    ObjectTypePipelineCache = 16,
    ObjectTypePipelineLayout = 17,
    ObjectTypeRenderPass = 18,
    ObjectTypePipeline = 19,
    ObjectTypeDescriptorSetLayout = 20,
    ObjectTypeSampler = 21,
    ObjectTypeDescriptorPool = 22,
    ObjectTypeDescriptorSet = 23,
    ObjectTypeFramebuffer = 24,
    ObjectTypeCommandPool = 25,
    RayTracingInvocationReorderModeNoneNV = 0,
    RayTracingInvocationReorderModeReorderNV = 1,
    DirectDriverLoadingModeExclusiveLunarg = 0,
    DirectDriverLoadingModeInclusiveLunarg = 1,
    QueueGraphicsBit = ,
    QueueComputeBit = ,
    QueueTransferBit = ,
    QueueSparseBindingBit = ,
    CullModeNone = 0,
    CullModeFrontBit = ,
    CullModeBackBit = ,
    CullModeFrontAndBack = 0x00000003,
    MemoryPropertyDeviceLocalBit = ,
    MemoryPropertyHostVisibleBit = ,
    MemoryPropertyHostCoherentBit = ,
    MemoryPropertyHostCachedBit = ,
    MemoryPropertyLazilyAllocatedBit = ,
    MemoryHeapDeviceLocalBit = ,
    AccessIndirectCommandReadBit = ,
    AccessIndexReadBit = ,
    AccessVertexAttributeReadBit = ,
    AccessUniformReadBit = ,
    AccessInputAttachmentReadBit = ,
    AccessShaderReadBit = ,
    AccessShaderWriteBit = ,
    AccessColorAttachmentReadBit = ,
    AccessColorAttachmentWriteBit = ,
    AccessDepthStencilAttachmentReadBit = ,
    AccessDepthStencilAttachmentWriteBit = ,
    AccessTransferReadBit = ,
    AccessTransferWriteBit = ,
    AccessHostReadBit = ,
    AccessHostWriteBit = ,
    AccessMemoryReadBit = ,
    AccessMemoryWriteBit = ,
    BufferUsageTransferSrcBit = ,
    BufferUsageTransferDstBit = ,
    BufferUsageUniformTexelBufferBit = ,
    BufferUsageStorageTexelBufferBit = ,
    BufferUsageUniformBufferBit = ,
    BufferUsageStorageBufferBit = ,
    BufferUsageIndexBufferBit = ,
    BufferUsageVertexBufferBit = ,
    BufferUsageIndirectBufferBit = ,
    BufferCreateSparseBindingBit = ,
    BufferCreateSparseResidencyBit = ,
    BufferCreateSparseAliasedBit = ,
    ShaderStageVertexBit = ,
    ShaderStageTessellationControlBit = ,
    ShaderStageTessellationEvaluationBit = ,
    ShaderStageGeometryBit = ,
    ShaderStageFragmentBit = ,
    ShaderStageComputeBit = ,
    ShaderStageAllGraphics = 0x0000001F,
    ShaderStageAll = 0x7FFFFFFF,
    ImageUsageTransferSrcBit = ,
    ImageUsageTransferDstBit = ,
    ImageUsageSampledBit = ,
    ImageUsageStorageBit = ,
    ImageUsageColorAttachmentBit = ,
    ImageUsageDepthStencilAttachmentBit = ,
    ImageUsageTransientAttachmentBit = ,
    ImageUsageInputAttachmentBit = ,
    ImageCreateSparseBindingBit = ,
    ImageCreateSparseResidencyBit = ,
    ImageCreateSparseAliasedBit = ,
    ImageCreateMutableFormatBit = ,
    ImageCreateCubeCompatibleBit = ,
    PipelineCreateDisableOptimizationBit = ,
    PipelineCreateAllowDerivativesBit = ,
    PipelineCreateDerivativeBit = ,
    ColorComponentRBit = ,
    ColorComponentGBit = ,
    ColorComponentBBit = ,
    ColorComponentABit = ,
    FenceCreateSignaledBit = ,
    FormatFeatureSampledImageBit = ,
    FormatFeatureStorageImageBit = ,
    FormatFeatureStorageImageAtomicBit = ,
    FormatFeatureUniformTexelBufferBit = ,
    FormatFeatureStorageTexelBufferBit = ,
    FormatFeatureStorageTexelBufferAtomicBit = ,
    FormatFeatureVertexBufferBit = ,
    FormatFeatureColorAttachmentBit = ,
    FormatFeatureColorAttachmentBlendBit = ,
    FormatFeatureDepthStencilAttachmentBit = ,
    FormatFeatureBlitSrcBit = ,
    FormatFeatureBlitDstBit = ,
    FormatFeatureSampledImageFilterLinearBit = ,
    QueryControlPreciseBit = ,
    QueryResult64Bit = ,
    QueryResultWaitBit = ,
    QueryResultWithAvailabilityBit = ,
    QueryResultPartialBit = ,
    CommandBufferUsageOneTimeSubmitBit = ,
    CommandBufferUsageRenderPassContinueBit = ,
    CommandBufferUsageSimultaneousUseBit = ,
    QueryPipelineStatisticInputAssemblyVerticesBit = ,
    QueryPipelineStatisticInputAssemblyPrimitivesBit = ,
    QueryPipelineStatisticVertexShaderInvocationsBit = ,
    QueryPipelineStatisticGeometryShaderInvocationsBit = ,
    QueryPipelineStatisticGeometryShaderPrimitivesBit = ,
    QueryPipelineStatisticClippingInvocationsBit = ,
    QueryPipelineStatisticClippingPrimitivesBit = ,
    QueryPipelineStatisticFragmentShaderInvocationsBit = ,
    QueryPipelineStatisticTessellationControlShaderPatchesBit = ,
    QueryPipelineStatisticTessellationEvaluationShaderInvocationsBit = ,
    QueryPipelineStatisticComputeShaderInvocationsBit = ,
    ImageAspectColorBit = ,
    ImageAspectDepthBit = ,
    ImageAspectStencilBit = ,
    ImageAspectMetadataBit = ,
    SparseImageFormatSingleMiptailBit = ,
    SparseImageFormatAlignedMipSizeBit = ,
    SparseImageFormatNonstandardBlockSizeBit = ,
    SparseMemoryBindMetadataBit = ,
    PipelineStageTopOfPipeBit = ,
    PipelineStageDrawIndirectBit = ,
    PipelineStageVertexInputBit = ,
    PipelineStageVertexShaderBit = ,
    PipelineStageTessellationControlShaderBit = ,
    PipelineStageTessellationEvaluationShaderBit = ,
    PipelineStageGeometryShaderBit = ,
    PipelineStageFragmentShaderBit = ,
    PipelineStageEarlyFragmentTestsBit = ,
    PipelineStageLateFragmentTestsBit = ,
    PipelineStageColorAttachmentOutputBit = ,
    PipelineStageComputeShaderBit = ,
    PipelineStageTransferBit = ,
    PipelineStageBottomOfPipeBit = ,
    PipelineStageHostBit = ,
    PipelineStageAllGraphicsBit = ,
    PipelineStageAllCommandsBit = ,
    CommandPoolCreateTransientBit = ,
    CommandPoolCreateResetCommandBufferBit = ,
    CommandPoolResetReleaseResourcesBit = ,
    CommandBufferResetReleaseResourcesBit = ,
    SampleCount1Bit = ,
    SampleCount2Bit = ,
    SampleCount4Bit = ,
    SampleCount8Bit = ,
    SampleCount16Bit = ,
    SampleCount32Bit = ,
    SampleCount64Bit = ,
    AttachmentDescriptionMayAliasBit = ,
    StencilFaceFrontBit = ,
    StencilFaceBackBit = ,
    StencilFaceFrontAndBack = 0x00000003,
    StencilFrontAndBack = ,
    DescriptorPoolCreateFreeDescriptorSetBit = ,
    DependencyByRegionBit = ,
    SemaphoreTypeBinary = 0,
    SemaphoreTypeTimeline = 1,
    SemaphoreWaitAnyBit = ,
    PresentModeImmediateKhr = 0,
    PresentModeMailboxKhr = 1,
    PresentModeFifoKhr = 2,
    PresentModeFifoRelaxedKhr = 3,
    ColorSpaceSrgbNonlinearKhr = 0,
    ColorspaceSrgbNonlinearKhr = ,
    DisplayPlaneAlphaOpaqueBitKhr = ,
    DisplayPlaneAlphaGlobalBitKhr = ,
    DisplayPlaneAlphaPerPixelBitKhr = ,
    DisplayPlaneAlphaPerPixelPremultipliedBitKhr = ,
    CompositeAlphaOpaqueBitKhr = ,
    CompositeAlphaPreMultipliedBitKhr = ,
    CompositeAlphaPostMultipliedBitKhr = ,
    CompositeAlphaInheritBitKhr = ,
    SurfaceTransformIdentityBitKhr = ,
    SurfaceTransformRotate90BitKhr = ,
    SurfaceTransformRotate180BitKhr = ,
    SurfaceTransformRotate270BitKhr = ,
    SurfaceTransformHorizontalMirrorBitKhr = ,
    SurfaceTransformHorizontalMirrorRotate90BitKhr = ,
    SurfaceTransformHorizontalMirrorRotate180BitKhr = ,
    SurfaceTransformHorizontalMirrorRotate270BitKhr = ,
    SurfaceTransformInheritBitKhr = ,
    SwapchainImageUsageSharedBitAndroid = ,
    TimeDomainDeviceEXT = 0,
    TimeDomainClockMonotonicEXT = 1,
    TimeDomainClockMonotonicRawEXT = 2,
    TimeDomainQueryPerformanceCounterEXT = 3,
    DebugReportInformationBitEXT = ,
    DebugReportWarningBitEXT = ,
    DebugReportPerformanceWarningBitEXT = ,
    DebugReportErrorBitEXT = ,
    DebugReportDebugBitEXT = ,
    DebugReportObjectTypeUnknownEXT = 0,
    DebugReportObjectTypeInstanceEXT = 1,
    DebugReportObjectTypePhysicalDeviceEXT = 2,
    DebugReportObjectTypeDeviceEXT = 3,
    DebugReportObjectTypeQueueEXT = 4,
    DebugReportObjectTypeSemaphoreEXT = 5,
    DebugReportObjectTypeCommandBufferEXT = 6,
    DebugReportObjectTypeFenceEXT = 7,
    DebugReportObjectTypeDeviceMemoryEXT = 8,
    DebugReportObjectTypeBufferEXT = 9,
    DebugReportObjectTypeImageEXT = 10,
    DebugReportObjectTypeEventEXT = 11,
    DebugReportObjectTypeQueryPoolEXT = 12,
    DebugReportObjectTypeBufferViewEXT = 13,
    DebugReportObjectTypeImageViewEXT = 14,
    DebugReportObjectTypeShaderModuleEXT = 15,
    DebugReportObjectTypePipelineCacheEXT = 16,
    DebugReportObjectTypePipelineLayoutEXT = 17,
    DebugReportObjectTypeRenderPassEXT = 18,
    DebugReportObjectTypePipelineEXT = 19,
    DebugReportObjectTypeDescriptorSetLayoutEXT = 20,
    DebugReportObjectTypeSamplerEXT = 21,
    DebugReportObjectTypeDescriptorPoolEXT = 22,
    DebugReportObjectTypeDescriptorSetEXT = 23,
    DebugReportObjectTypeFramebufferEXT = 24,
    DebugReportObjectTypeCommandPoolEXT = 25,
    DebugReportObjectTypeSurfaceKhrEXT = 26,
    DebugReportObjectTypeSwapchainKhrEXT = 27,
    DebugReportObjectTypeDebugReportCallbackEXTEXT = 28,
    DebugReportObjectTypeDebugReportEXT = ,
    DebugReportObjectTypeDisplayKhrEXT = 29,
    DebugReportObjectTypeDisplayModeKhrEXT = 30,
    DebugReportObjectTypeValidationCacheEXTEXT = 33,
    DebugReportObjectTypeValidationCacheEXT = ,
    DeviceMemoryReportEventTypeAllocateEXT = 0,
    DeviceMemoryReportEventTypeFreeEXT = 1,
    DeviceMemoryReportEventTypeImportEXT = 2,
    DeviceMemoryReportEventTypeUnimportEXT = 3,
    DeviceMemoryReportEventTypeAllocationFailedEXT = 4,
    RasterizationOrderStrictAMD = 0,
    RasterizationOrderRelaxedAMD = 1,
    ExternalMemoryHandleTypeOpaqueWin32BitNV = ,
    ExternalMemoryHandleTypeOpaqueWin32KmtBitNV = ,
    ExternalMemoryHandleTypeD3d11ImageBitNV = ,
    ExternalMemoryHandleTypeD3d11ImageKmtBitNV = ,
    ExternalMemoryFeatureDedicatedOnlyBitNV = ,
    ExternalMemoryFeatureExportableBitNV = ,
    ExternalMemoryFeatureImportableBitNV = ,
    ValidationCheckAllEXT = 0,
    ValidationCheckShadersEXT = 1,
    ValidationFeatureEnableGpuAssistedEXT = 0,
    ValidationFeatureEnableGpuAssistedReserveBindingSlotEXT = 1,
    ValidationFeatureEnableBestPracticesEXT = 2,
    ValidationFeatureEnableDebugPrintfEXT = 3,
    ValidationFeatureEnableSynchronizationValidationEXT = 4,
    ValidationFeatureDisableAllEXT = 0,
    ValidationFeatureDisableShadersEXT = 1,
    ValidationFeatureDisableThreadSafetyEXT = 2,
    ValidationFeatureDisableApiParametersEXT = 3,
    ValidationFeatureDisableObjectLifetimesEXT = 4,
    ValidationFeatureDisableCoreChecksEXT = 5,
    ValidationFeatureDisableUniqueHandlesEXT = 6,
    ValidationFeatureDisableShaderValidationCacheEXT = 7,
    SubgroupFeatureBasicBit = ,
    SubgroupFeatureVoteBit = ,
    SubgroupFeatureArithmeticBit = ,
    SubgroupFeatureBallotBit = ,
    SubgroupFeatureShuffleBit = ,
    SubgroupFeatureShuffleRelativeBit = ,
    SubgroupFeatureClusteredBit = ,
    SubgroupFeatureQuadBit = ,
    IndirectCommandsLayoutUsageExplicitPreprocessBitNV = ,
    IndirectCommandsLayoutUsageIndexedSequencesBitNV = ,
    IndirectCommandsLayoutUsageUnorderedSequencesBitNV = ,
    IndirectStateFlagFrontfaceBitNV = ,
    IndirectCommandsTokenTypeShaderGroupNV = 0,
    IndirectCommandsTokenTypeStateFlagsNV = 1,
    IndirectCommandsTokenTypeIndexBufferNV = 2,
    IndirectCommandsTokenTypeVertexBufferNV = 3,
    IndirectCommandsTokenTypePushConstantNV = 4,
    IndirectCommandsTokenTypeDrawIndexedNV = 5,
    IndirectCommandsTokenTypeDrawNV = 6,
    IndirectCommandsTokenTypeDrawTasksNV = 7,
    ExternalMemoryHandleTypeOpaqueFdBit = ,
    ExternalMemoryHandleTypeOpaqueWin32Bit = ,
    ExternalMemoryHandleTypeOpaqueWin32KmtBit = ,
    ExternalMemoryHandleTypeD3d11TextureBit = ,
    ExternalMemoryHandleTypeD3d11TextureKmtBit = ,
    ExternalMemoryHandleTypeD3d12HeapBit = ,
    ExternalMemoryHandleTypeD3d12ResourceBit = ,
    ExternalMemoryFeatureDedicatedOnlyBit = ,
    ExternalMemoryFeatureExportableBit = ,
    ExternalMemoryFeatureImportableBit = ,
    ExternalSemaphoreHandleTypeOpaqueFdBit = ,
    ExternalSemaphoreHandleTypeOpaqueWin32Bit = ,
    ExternalSemaphoreHandleTypeOpaqueWin32KmtBit = ,
    ExternalSemaphoreHandleTypeD3d12FenceBit = ,
    ExternalSemaphoreHandleTypeD3d11FenceBit = ,
    ExternalSemaphoreHandleTypeSyncFdBit = ,
    ExternalSemaphoreFeatureExportableBit = ,
    ExternalSemaphoreFeatureImportableBit = ,
    SemaphoreImportTemporaryBit = ,
    ExternalFenceHandleTypeOpaqueFdBit = ,
    ExternalFenceHandleTypeOpaqueWin32Bit = ,
    ExternalFenceHandleTypeOpaqueWin32KmtBit = ,
    ExternalFenceHandleTypeSyncFdBit = ,
    ExternalFenceFeatureExportableBit = ,
    ExternalFenceFeatureImportableBit = ,
    FenceImportTemporaryBit = ,
    SurfaceCounterVblankBitEXT = ,
    SurfaceCounterVblankEXT = ,
    DisplayPowerStateOffEXT = 0,
    DisplayPowerStateSuspendEXT = 1,
    DisplayPowerStateOnEXT = 2,
    DeviceEventTypeDisplayHotplugEXT = 0,
    DisplayEventTypeFirstPixelOutEXT = 0,
    PeerMemoryFeatureCopySrcBit = ,
    PeerMemoryFeatureCopyDstBit = ,
    PeerMemoryFeatureGenericSrcBit = ,
    PeerMemoryFeatureGenericDstBit = ,
    MemoryAllocateDeviceMaskBit = ,
    DeviceGroupPresentModeLocalBitKhr = ,
    DeviceGroupPresentModeRemoteBitKhr = ,
    DeviceGroupPresentModeSumBitKhr = ,
    DeviceGroupPresentModeLocalMultiDeviceBitKhr = ,
    ViewportCoordinateSwizzlePositiveXNV = 0,
    ViewportCoordinateSwizzleNegativeXNV = 1,
    ViewportCoordinateSwizzlePositiveYNV = 2,
    ViewportCoordinateSwizzleNegativeYNV = 3,
    ViewportCoordinateSwizzlePositiveZNV = 4,
    ViewportCoordinateSwizzleNegativeZNV = 5,
    ViewportCoordinateSwizzlePositiveWNV = 6,
    ViewportCoordinateSwizzleNegativeWNV = 7,
    DiscardRectangleModeInclusiveEXT = 0,
    DiscardRectangleModeExclusiveEXT = 1,
    PointClippingBehaviorAllClipPlanes = 0,
    PointClippingBehaviorUserClipPlanesOnly = 1,
    SamplerReductionModeWeightedAverage = 0,
    SamplerReductionModeMin = 1,
    SamplerReductionModeMax = 2,
    TessellationDomainOriginUpperLeft = 0,
    TessellationDomainOriginLowerLeft = 1,
    SamplerYcbcrModelConversionRgbIdentity = 0,
    SamplerYcbcrModelConversionYcbcrIdentity = 1,
    SamplerYcbcrModelConversionYcbcr709 = 2,
    SamplerYcbcrModelConversionYcbcr601 = 3,
    SamplerYcbcrModelConversionYcbcr2020 = 4,
    SamplerYcbcrRangeItuFull = 0,
    SamplerYcbcrRangeItuNarrow = 1,
    ChromaLocationCositedEven = 0,
    ChromaLocationMidpoint = 1,
    BlendOverlapUncorrelatedEXT = 0,
    BlendOverlapDisjointEXT = 1,
    BlendOverlapConjointEXT = 2,
    CoverageModulationModeNoneNV = 0,
    CoverageModulationModeRgbNV = 1,
    CoverageModulationModeAlphaNV = 2,
    CoverageModulationModeRgbaNV = 3,
    CoverageReductionModeMergeNV = 0,
    CoverageReductionModeTruncateNV = 1,
    ValidationCacheHeaderVersionOneEXT = 1,
    ShaderInfoTypeStatisticsAMD = 0,
    ShaderInfoTypeBinaryAMD = 1,
    ShaderInfoTypeDisassemblyAMD = 2,
    QueueGlobalPriorityLowKhr = 128,
    QueueGlobalPriorityMediumKhr = 256,
    QueueGlobalPriorityHighKhr = 512,
    QueueGlobalPriorityRealtimeKhr = 1024,
    QueueGlobalPriorityLowEXT = ,
    QueueGlobalPriorityMediumEXT = ,
    QueueGlobalPriorityHighEXT = ,
    QueueGlobalPriorityRealtimeEXT = ,
    DebugUtilsMessageSeverityVerboseBitEXT = ,
    DebugUtilsMessageSeverityInfoBitEXT = ,
    DebugUtilsMessageSeverityWarningBitEXT = ,
    DebugUtilsMessageSeverityErrorBitEXT = ,
    DebugUtilsMessageTypeGeneralBitEXT = ,
    DebugUtilsMessageTypeValidationBitEXT = ,
    DebugUtilsMessageTypePerformanceBitEXT = ,
    ConservativeRasterizationModeDisabledEXT = 0,
    ConservativeRasterizationModeOverestimateEXT = 1,
    ConservativeRasterizationModeUnderestimateEXT = 2,
    DescriptorBindingUpdateAfterBindBit = ,
    DescriptorBindingUpdateUnusedWhilePendingBit = ,
    DescriptorBindingPartiallyBoundBit = ,
    DescriptorBindingVariableDescriptorCountBit = ,
    VendorIdViv = 0x10001,
    VendorIdVsi = 0x10002,
    VendorIdKazan = 0x10003,
    VendorIdCodeplay = 0x10004,
    VendorIdMESA = 0x10005,
    VendorIdPocl = 0x10006,
    DriverIdAMDProprietary = 1,
    DriverIdAMDOpenSource = 2,
    DriverIdMESARadv = 3,
    DriverIdNvidiaProprietary = 4,
    DriverIdINTELProprietaryWindows = 5,
    DriverIdINTELOpenSourceMESA = 6,
    DriverIdImaginationProprietary = 7,
    DriverIdQualcommProprietary = 8,
    DriverIdArmProprietary = 9,
    DriverIdGoogleSwiftshader = 10,
    DriverIdGgpProprietary = 11,
    DriverIdBroadcomProprietary = 12,
    DriverIdMESALlvmpipe = 13,
    DriverIdMoltenvk = 14,
    DriverIdCoreaviProprietary = 15,
    DriverIdJuiceProprietary = 16,
    DriverIdVerisiliconProprietary = 17,
    DriverIdMESATurnip = 18,
    DriverIdMESAV3dv = 19,
    DriverIdMESAPanvk = 20,
    DriverIdSamsungProprietary = 21,
    DriverIdMESAVenus = 22,
    DriverIdMESADozen = 23,
    DriverIdMESANvk = 24,
    DriverIdImaginationOpenSourceMESA = 25,
    ConditionalRenderingInvertedBitEXT = ,
    ResolveModeNone = 0,
    ResolveModeSampleZeroBit = ,
    ResolveModeAverageBit = ,
    ResolveModeMinBit = ,
    ResolveModeMaxBit = ,
    ShadingRatePaletteEntryNoInvocationsNV = 0,
    ShadingRatePaletteEntry16InvocationsPerPixelNV = 1,
    ShadingRatePaletteEntry8InvocationsPerPixelNV = 2,
    ShadingRatePaletteEntry4InvocationsPerPixelNV = 3,
    ShadingRatePaletteEntry2InvocationsPerPixelNV = 4,
    ShadingRatePaletteEntry1InvocationPerPixelNV = 5,
    ShadingRatePaletteEntry1InvocationPer2x1PixelsNV = 6,
    ShadingRatePaletteEntry1InvocationPer1x2PixelsNV = 7,
    ShadingRatePaletteEntry1InvocationPer2x2PixelsNV = 8,
    ShadingRatePaletteEntry1InvocationPer4x2PixelsNV = 9,
    ShadingRatePaletteEntry1InvocationPer2x4PixelsNV = 10,
    ShadingRatePaletteEntry1InvocationPer4x4PixelsNV = 11,
    CoarseSampleOrderTypeDefaultNV = 0,
    CoarseSampleOrderTypeCustomNV = 1,
    CoarseSampleOrderTypePixelMajorNV = 2,
    CoarseSampleOrderTypeSampleMajorNV = 3,
    GeometryInstanceTriangleFacingCullDisableBitKhr = ,
    GeometryInstanceTriangleFlipFacingBitKhr = ,
    GeometryInstanceForceOpaqueBitKhr = ,
    GeometryInstanceForceNoOpaqueBitKhr = ,
    GeometryInstanceTriangleFrontCounterclockwiseBitKhr = ,
    GeometryOpaqueBitKhr = ,
    GeometryNoDuplicateAnyHitInvocationBitKhr = ,
    BuildAccelerationStructureAllowUpdateBitKhr = ,
    BuildAccelerationStructureAllowCompactionBitKhr = ,
    BuildAccelerationStructurePreferFastTraceBitKhr = ,
    BuildAccelerationStructurePreferFastBuildBitKhr = ,
    BuildAccelerationStructureLowMemoryBitKhr = ,
    AccelerationStructureCreateDeviceAddressCaptureReplayBitKhr = ,
    CopyAccelerationStructureModeCloneKhr = 0,
    CopyAccelerationStructureModeCompactKhr = 1,
    CopyAccelerationStructureModeSerializeKhr = 2,
    CopyAccelerationStructureModeDeserializeKhr = 3,
    BuildAccelerationStructureModeBuildKhr = 0,
    BuildAccelerationStructureModeUpdateKhr = 1,
    AccelerationStructureTypeTopLevelKhr = 0,
    AccelerationStructureTypeBottomLevelKhr = 1,
    AccelerationStructureTypeGenericKhr = 2,
    GeometryTypeTrianglesKhr = 0,
    GeometryTypeAabbsKhr = 1,
    GeometryTypeInstancesKhr = 2,
    AccelerationStructureMemoryRequirementsTypeObjectNV = 0,
    AccelerationStructureMemoryRequirementsTypeBuildScratchNV = 1,
    AccelerationStructureMemoryRequirementsTypeUpdateScratchNV = 2,
    AccelerationStructureBuildTypeHostKhr = 0,
    AccelerationStructureBuildTypeDeviceKhr = 1,
    AccelerationStructureBuildTypeHostOrDeviceKhr = 2,
    RayTracingShaderGroupTypeGeneralKhr = 0,
    RayTracingShaderGroupTypeTrianglesHitGroupKhr = 1,
    RayTracingShaderGroupTypeProceduralHitGroupKhr = 2,
    AccelerationStructureCompatibilityCompatibleKhr = 0,
    AccelerationStructureCompatibilityIncompatibleKhr = 1,
    ShaderGroupShaderGeneralKhr = 0,
    ShaderGroupShaderClosestHitKhr = 1,
    ShaderGroupShaderAnyHitKhr = 2,
    ShaderGroupShaderIntersectionKhr = 3,
    MemoryOverallocationBehaviorDefaultAMD = 0,
    MemoryOverallocationBehaviorAllowedAMD = 1,
    MemoryOverallocationBehaviorDisallowedAMD = 2,
    ScopeDeviceNV = 1,
    ScopeWorkgroupNV = 2,
    ScopeSubgroupNV = 3,
    ScopeQueueFamilyNV = 5,
    ComponentTypeFloat16NV = 0,
    ComponentTypeFloat32NV = 1,
    ComponentTypeFloat64NV = 2,
    ComponentTypeSint8NV = 3,
    ComponentTypeSint16NV = 4,
    ComponentTypeSint32NV = 5,
    ComponentTypeSint64NV = 6,
    ComponentTypeUint8NV = 7,
    ComponentTypeUint16NV = 8,
    ComponentTypeUint32NV = 9,
    ComponentTypeUint64NV = 10,
    DeviceDiagnosticsConfigEnableShaderDebugInfoBitNV = ,
    DeviceDiagnosticsConfigEnableResourceTrackingBitNV = ,
    DeviceDiagnosticsConfigEnableAutomaticCheckpointsBitNV = ,
    DeviceDiagnosticsConfigEnableShaderErrorReportingBitNV = ,
    PipelineCreationFeedbackValidBit = ,
    PipelineCreationFeedbackValidBitEXT = ,
    PipelineCreationFeedbackApplicationPipelineCacheHitBit = ,
    PipelineCreationFeedbackApplicationPipelineCacheHitBitEXT = ,
    PipelineCreationFeedbackBasePipelineAccelerationBit = ,
    PipelineCreationFeedbackBasePipelineAccelerationBitEXT = ,
    FullScreenExclusiveDefaultEXT = 0,
    FullScreenExclusiveAllowedEXT = 1,
    FullScreenExclusiveDisallowedEXT = 2,
    FullScreenExclusiveApplicationControlledEXT = 3,
    PerformanceCounterScopeCommandBufferKhr = 0,
    PerformanceCounterScopeRenderPassKhr = 1,
    PerformanceCounterScopeCommandKhr = 2,
    QueryScopeCommandBufferKhr = ,
    QueryScopeRenderPassKhr = ,
    QueryScopeCommandKhr = ,
    MemoryDecompressionMethodGdeflate10BitNV = ,
    PerformanceCounterUnitGenericKhr = 0,
    PerformanceCounterUnitPercentageKhr = 1,
    PerformanceCounterUnitNanosecondsKhr = 2,
    PerformanceCounterUnitBytesKhr = 3,
    PerformanceCounterUnitBytesPerSecondKhr = 4,
    PerformanceCounterUnitKelvinKhr = 5,
    PerformanceCounterUnitWattsKhr = 6,
    PerformanceCounterUnitVoltsKhr = 7,
    PerformanceCounterUnitAmpsKhr = 8,
    PerformanceCounterUnitHertzKhr = 9,
    PerformanceCounterUnitCyclesKhr = 10,
    PerformanceCounterStorageInt32Khr = 0,
    PerformanceCounterStorageInt64Khr = 1,
    PerformanceCounterStorageUint32Khr = 2,
    PerformanceCounterStorageUint64Khr = 3,
    PerformanceCounterStorageFloat32Khr = 4,
    PerformanceCounterStorageFloat64Khr = 5,
    PerformanceCounterDescriptionPerformanceImpactingBitKhr = ,
    PerformanceCounterDescriptionPerformanceImpactingKhr = ,
    PerformanceCounterDescriptionConcurrentlyImpactedBitKhr = ,
    PerformanceCounterDescriptionConcurrentlyImpactedKhr = ,
    PerformanceConfigurationTypeCommandQueueMetricsDiscoveryActivatedINTEL = 0,
    QueryPoolSamplingModeManualINTEL = 0,
    PerformanceOverrideTypeNullHardwareINTEL = 0,
    PerformanceOverrideTypeFlushGpuCachesINTEL = 1,
    PerformanceParameterTypeHwCountersSupportedINTEL = 0,
    PerformanceParameterTypeStreamMarkerValidBitsINTEL = 1,
    PerformanceValueTypeUint32INTEL = 0,
    PerformanceValueTypeUint64INTEL = 1,
    PerformanceValueTypeFloatINTEL = 2,
    PerformanceValueTypeBoolINTEL = 3,
    PerformanceValueTypeStringINTEL = 4,
    ShaderFloatControlsIndependence32BitOnly = 0,
    ShaderFloatControlsIndependenceAll = 1,
    ShaderFloatControlsIndependenceNone = 2,
    PipelineExecutableStatisticFormatBool32Khr = 0,
    PipelineExecutableStatisticFormatInt64Khr = 1,
    PipelineExecutableStatisticFormatUint64Khr = 2,
    PipelineExecutableStatisticFormatFloat64Khr = 3,
    LineRasterizationModeDefaultEXT = 0,
    LineRasterizationModeRectangularEXT = 1,
    LineRasterizationModeBresenhamEXT = 2,
    LineRasterizationModeRectangularSmoothEXT = 3,
    FaultLevelUnassigned = 0,
    FaultLevelCritical = 1,
    FaultLevelRecoverable = 2,
    FaultLevelWarning = 3,
    FaultTypeInvalid = 0,
    FaultTypeUnassigned = 1,
    FaultTypeImplementation = 2,
    FaultTypeSystem = 3,
    FaultTypePhysicalDevice = 4,
    FaultTypeCommandBufferFull = 5,
    FaultTypeInvalidApiUsage = 6,
    FaultQueryBehaviorGetAndClearAllFaults = 0,
    ToolPurposeValidationBit = ,
    ToolPurposeValidationBitEXT = ,
    ToolPurposeProfilingBit = ,
    ToolPurposeProfilingBitEXT = ,
    ToolPurposeTracingBit = ,
    ToolPurposeTracingBitEXT = ,
    ToolPurposeAdditionalFeaturesBit = ,
    ToolPurposeAdditionalFeaturesBitEXT = ,
    ToolPurposeModifyingFeaturesBit = ,
    ToolPurposeModifyingFeaturesBitEXT = ,
    PipelineMatchControlApplicationUuidExactMatch = 0,
    FragmentShadingRateCombinerOpKeepKhr = 0,
    FragmentShadingRateCombinerOpReplaceKhr = 1,
    FragmentShadingRateCombinerOpMinKhr = 2,
    FragmentShadingRateCombinerOpMaxKhr = 3,
    FragmentShadingRateCombinerOpMulKhr = 4,
    FragmentShadingRate1InvocationPerPixelNV = 0,
    FragmentShadingRate1InvocationPer1x2PixelsNV = 1,
    FragmentShadingRate1InvocationPer2x1PixelsNV = 4,
    FragmentShadingRate1InvocationPer2x2PixelsNV = 5,
    FragmentShadingRate1InvocationPer2x4PixelsNV = 6,
    FragmentShadingRate1InvocationPer4x2PixelsNV = 9,
    FragmentShadingRate1InvocationPer4x4PixelsNV = 10,
    FragmentShadingRate2InvocationsPerPixelNV = 11,
    FragmentShadingRate4InvocationsPerPixelNV = 12,
    FragmentShadingRate8InvocationsPerPixelNV = 13,
    FragmentShadingRate16InvocationsPerPixelNV = 14,
    FragmentShadingRateNoInvocationsNV = 15,
    FragmentShadingRateTypeFragmentSizeNV = 0,
    FragmentShadingRateTypeEnumsNV = 1,
    SubpassMergeStatusMergedEXT = 0,
    SubpassMergeStatusDisallowedEXT = 1,
    SubpassMergeStatusNotMergedSideEffectsEXT = 2,
    SubpassMergeStatusNotMergedSamplesMismatchEXT = 3,
    SubpassMergeStatusNotMergedViewsMismatchEXT = 4,
    SubpassMergeStatusNotMergedAliasingEXT = 5,
    SubpassMergeStatusNotMergedDependenciesEXT = 6,
    SubpassMergeStatusNotMergedIncompatibleInputAttachmentEXT = 7,
    SubpassMergeStatusNotMergedTooManyAttachmentsEXT = 8,
    SubpassMergeStatusNotMergedInsufficientStorageEXT = 9,
    SubpassMergeStatusNotMergedDepthStencilCountEXT = 10,
    SubpassMergeStatusNotMergedResolveAttachmentReuseEXT = 11,
    SubpassMergeStatusNotMergedSingleSubpassEXT = 12,
    SubpassMergeStatusNotMergedUnspecifiedEXT = 13,
    Access2None = 0,
    Access2NoneKhr = ,
    Access2IndirectCommandReadBit = ,
    Access2IndirectCommandReadBitKhr = ,
    Access2IndexReadBit = ,
    Access2IndexReadBitKhr = ,
    Access2VertexAttributeReadBit = ,
    Access2VertexAttributeReadBitKhr = ,
    Access2UniformReadBit = ,
    Access2UniformReadBitKhr = ,
    Access2InputAttachmentReadBit = ,
    Access2InputAttachmentReadBitKhr = ,
    Access2ShaderReadBit = ,
    Access2ShaderReadBitKhr = ,
    Access2ShaderWriteBit = ,
    Access2ShaderWriteBitKhr = ,
    Access2ColorAttachmentReadBit = ,
    Access2ColorAttachmentReadBitKhr = ,
    Access2ColorAttachmentWriteBit = ,
    Access2ColorAttachmentWriteBitKhr = ,
    Access2DepthStencilAttachmentReadBit = ,
    Access2DepthStencilAttachmentReadBitKhr = ,
    Access2DepthStencilAttachmentWriteBit = ,
    Access2DepthStencilAttachmentWriteBitKhr = ,
    Access2TransferReadBit = ,
    Access2TransferReadBitKhr = ,
    Access2TransferWriteBit = ,
    Access2TransferWriteBitKhr = ,
    Access2HostReadBit = ,
    Access2HostReadBitKhr = ,
    Access2HostWriteBit = ,
    Access2HostWriteBitKhr = ,
    Access2MemoryReadBit = ,
    Access2MemoryReadBitKhr = ,
    Access2MemoryWriteBit = ,
    Access2MemoryWriteBitKhr = ,
    Access2ShaderSampledReadBit = ,
    Access2ShaderSampledReadBitKhr = ,
    Access2ShaderStorageReadBit = ,
    Access2ShaderStorageReadBitKhr = ,
    Access2ShaderStorageWriteBit = ,
    Access2ShaderStorageWriteBitKhr = ,
    PipelineStage2None = 0,
    PipelineStage2NoneKhr = ,
    PipelineStage2TopOfPipeBit = ,
    PipelineStage2TopOfPipeBitKhr = ,
    PipelineStage2DrawIndirectBit = ,
    PipelineStage2DrawIndirectBitKhr = ,
    PipelineStage2VertexInputBit = ,
    PipelineStage2VertexInputBitKhr = ,
    PipelineStage2VertexShaderBit = ,
    PipelineStage2VertexShaderBitKhr = ,
    PipelineStage2TessellationControlShaderBit = ,
    PipelineStage2TessellationControlShaderBitKhr = ,
    PipelineStage2TessellationEvaluationShaderBit = ,
    PipelineStage2TessellationEvaluationShaderBitKhr = ,
    PipelineStage2GeometryShaderBit = ,
    PipelineStage2GeometryShaderBitKhr = ,
    PipelineStage2FragmentShaderBit = ,
    PipelineStage2FragmentShaderBitKhr = ,
    PipelineStage2EarlyFragmentTestsBit = ,
    PipelineStage2EarlyFragmentTestsBitKhr = ,
    PipelineStage2LateFragmentTestsBit = ,
    PipelineStage2LateFragmentTestsBitKhr = ,
    PipelineStage2ColorAttachmentOutputBit = ,
    PipelineStage2ColorAttachmentOutputBitKhr = ,
    PipelineStage2ComputeShaderBit = ,
    PipelineStage2ComputeShaderBitKhr = ,
    PipelineStage2AllTransferBit = ,
    PipelineStage2AllTransferBitKhr = ,
    PipelineStage2TransferBit = ,
    PipelineStage2TransferBitKhr = ,
    PipelineStage2BottomOfPipeBit = ,
    PipelineStage2BottomOfPipeBitKhr = ,
    PipelineStage2HostBit = ,
    PipelineStage2HostBitKhr = ,
    PipelineStage2AllGraphicsBit = ,
    PipelineStage2AllGraphicsBitKhr = ,
    PipelineStage2AllCommandsBit = ,
    PipelineStage2AllCommandsBitKhr = ,
    PipelineStage2CopyBit = ,
    PipelineStage2CopyBitKhr = ,
    PipelineStage2ResolveBit = ,
    PipelineStage2ResolveBitKhr = ,
    PipelineStage2BlitBit = ,
    PipelineStage2BlitBitKhr = ,
    PipelineStage2ClearBit = ,
    PipelineStage2ClearBitKhr = ,
    PipelineStage2IndexInputBit = ,
    PipelineStage2IndexInputBitKhr = ,
    PipelineStage2VertexAttributeInputBit = ,
    PipelineStage2VertexAttributeInputBitKhr = ,
    PipelineStage2PreRasterizationShadersBit = ,
    PipelineStage2PreRasterizationShadersBitKhr = ,
    SubmitProtectedBit = ,
    SubmitProtectedBitKhr = ,
    SciSyncClientTypeSignalerNV = 0,
    SciSyncClientTypeWaiterNV = 1,
    SciSyncClientTypeSignalerWaiterNV = 2,
    SciSyncPrimitiveTypeFenceNV = 0,
    SciSyncPrimitiveTypeSemaphoreNV = 1,
    ProvokingVertexModeFirstVertexEXT = 0,
    ProvokingVertexModeLastVertexEXT = 1,
    PipelineCacheValidationVersionSafetyCriticalOne = 1,
    AccelerationStructureMotionInstanceTypeStaticNV = 0,
    AccelerationStructureMotionInstanceTypeMatrixMotionNV = 1,
    AccelerationStructureMotionInstanceTypeSrtMotionNV = 2,
    GraphicsPipelineLibraryVertexInputInterfaceBitEXT = ,
    GraphicsPipelineLibraryPreRasterizationShadersBitEXT = ,
    GraphicsPipelineLibraryFragmentShaderBitEXT = ,
    GraphicsPipelineLibraryFragmentOutputInterfaceBitEXT = ,
    DeviceAddressBindingInternalObjectBitEXT = ,
    DeviceAddressBindingTypeBindEXT = 0,
    DeviceAddressBindingTypeUnbindEXT = 1,
    PresentScalingOneToOneBitEXT = ,
    PresentScalingAspectRatioStretchBitEXT = ,
    PresentScalingStretchBitEXT = ,
    PresentGravityMinBitEXT = ,
    PresentGravityMaxBitEXT = ,
    PresentGravityCenteredBitEXT = ,
    VideoCodecOperationNoneKhr = 0,
    VideoChromaSubsamplingInvalidKhr = 0,
    VideoChromaSubsamplingMonochromeBitKhr = ,
    VideoChromaSubsampling420BitKhr = ,
    VideoChromaSubsampling422BitKhr = ,
    VideoChromaSubsampling444BitKhr = ,
    VideoComponentBitDepthInvalidKhr = 0,
    VideoComponentBitDepth8BitKhr = ,
    VideoComponentBitDepth10BitKhr = ,
    VideoComponentBitDepth12BitKhr = ,
    VideoCapabilityProtectedContentBitKhr = ,
    VideoCapabilitySeparateReferenceImagesBitKhr = ,
    VideoSessionCreateProtectedContentBitKhr = ,
    VideoDecodeH264PictureLayoutProgressiveKhr = 0,
    VideoDecodeH264PictureLayoutInterlacedInterleavedLinesBitKhr = ,
    VideoDecodeH264PictureLayoutInterlacedSeparatePlanesBitKhr = ,
    VideoCodingControlResetBitKhr = ,
    QueryResultStatusErrorKhr = -1,
    QueryResultStatusNotReadyKhr = 0,
    QueryResultStatusCompleteKhr = 1,
    VideoDecodeUsageDefaultKhr = 0,
    VideoDecodeUsageTranscodingBitKhr = ,
    VideoDecodeUsageOfflineBitKhr = ,
    VideoDecodeUsageStreamingBitKhr = ,
    VideoDecodeCapabilityDpbAndOutputCoincideBitKhr = ,
    VideoDecodeCapabilityDpbAndOutputDistinctBitKhr = ,
    VideoEncodeUsageDefaultKhr = 0,
    VideoEncodeUsageTranscodingBitKhr = ,
    VideoEncodeUsageStreamingBitKhr = ,
    VideoEncodeUsageRecordingBitKhr = ,
    VideoEncodeUsageConferencingBitKhr = ,
    VideoEncodeContentDefaultKhr = 0,
    VideoEncodeContentCameraBitKhr = ,
    VideoEncodeContentDesktopBitKhr = ,
    VideoEncodeContentRenderedBitKhr = ,
    VideoEncodeTuningModeDefaultKhr = 0,
    VideoEncodeTuningModeHighQualityKhr = 1,
    VideoEncodeTuningModeLowLatencyKhr = 2,
    VideoEncodeTuningModeUltraLowLatencyKhr = 3,
    VideoEncodeTuningModeLosslessKhr = 4,
    VideoEncodeCapabilityPrecedingExternallyEncodedBytesBitKhr = ,
    VideoEncodeRateControlModeNoneBitKhr = 0,
    VideoEncodeRateControlModeCbrBitKhr = 1,
    VideoEncodeRateControlModeVbrBitKhr = 2,
    VideoEncodeH264CapabilityDirect8x8InferenceEnabledBitEXT = ,
    VideoEncodeH264CapabilityDirect8x8InferenceDisabledBitEXT = ,
    VideoEncodeH264CapabilitySeparateColourPlaneBitEXT = ,
    VideoEncodeH264CapabilityQpprimeYZeroTransformBypassBitEXT = ,
    VideoEncodeH264CapabilityScalingListsBitEXT = ,
    VideoEncodeH264CapabilityHrdComplianceBitEXT = ,
    VideoEncodeH264CapabilityChromaQpOffsetBitEXT = ,
    VideoEncodeH264CapabilitySecondChromaQpOffsetBitEXT = ,
    VideoEncodeH264CapabilityPicInitQpMinus26BitEXT = ,
    VideoEncodeH264CapabilityWeightedPredBitEXT = ,
    VideoEncodeH264CapabilityWeightedBipredExplicitBitEXT = ,
    VideoEncodeH264CapabilityWeightedBipredImplicitBitEXT = ,
    VideoEncodeH264CapabilityWeightedPredNoTableBitEXT = ,
    VideoEncodeH264CapabilityTransform8x8BitEXT = ,
    VideoEncodeH264CapabilityCabacBitEXT = ,
    VideoEncodeH264CapabilityCavlcBitEXT = ,
    VideoEncodeH264CapabilityDeblockingFilterDisabledBitEXT = ,
    VideoEncodeH264CapabilityDeblockingFilterEnabledBitEXT = ,
    VideoEncodeH264CapabilityDeblockingFilterPartialBitEXT = ,
    VideoEncodeH264CapabilityDisableDirectSpatialMvPredBitEXT = ,
    VideoEncodeH264CapabilityMultipleSlicePerFrameBitEXT = ,
    VideoEncodeH264CapabilitySliceMbCountBitEXT = ,
    VideoEncodeH264CapabilityRowUnalignedSliceBitEXT = ,
    VideoEncodeH264CapabilityDifferentSliceTypeBitEXT = ,
    VideoEncodeH264CapabilityBFrameInL1ListBitEXT = ,
    VideoEncodeH264InputModeFrameBitEXT = ,
    VideoEncodeH264InputModeSliceBitEXT = ,
    VideoEncodeH264InputModeNonVclBitEXT = ,
    VideoEncodeH264OutputModeFrameBitEXT = ,
    VideoEncodeH264OutputModeSliceBitEXT = ,
    VideoEncodeH264OutputModeNonVclBitEXT = ,
    VideoEncodeH264RateControlStructureUnknownEXT = 0,
    VideoEncodeH264RateControlStructureFlatEXT = 1,
    VideoEncodeH264RateControlStructureDyadicEXT = 2,
    ImageConstraintsInfoCpuReadRarelyFuchsia = ,
    ImageConstraintsInfoCpuReadOftenFuchsia = ,
    ImageConstraintsInfoCpuWriteRarelyFuchsia = ,
    ImageConstraintsInfoCpuWriteOftenFuchsia = ,
    ImageConstraintsInfoProtectedOptionalFuchsia = ,
    FormatFeature2SampledImageBit = ,
    FormatFeature2SampledImageBitKhr = ,
    FormatFeature2StorageImageBit = ,
    FormatFeature2StorageImageBitKhr = ,
    FormatFeature2StorageImageAtomicBit = ,
    FormatFeature2StorageImageAtomicBitKhr = ,
    FormatFeature2UniformTexelBufferBit = ,
    FormatFeature2UniformTexelBufferBitKhr = ,
    FormatFeature2StorageTexelBufferBit = ,
    FormatFeature2StorageTexelBufferBitKhr = ,
    FormatFeature2StorageTexelBufferAtomicBit = ,
    FormatFeature2StorageTexelBufferAtomicBitKhr = ,
    FormatFeature2VertexBufferBit = ,
    FormatFeature2VertexBufferBitKhr = ,
    FormatFeature2ColorAttachmentBit = ,
    FormatFeature2ColorAttachmentBitKhr = ,
    FormatFeature2ColorAttachmentBlendBit = ,
    FormatFeature2ColorAttachmentBlendBitKhr = ,
    FormatFeature2DepthStencilAttachmentBit = ,
    FormatFeature2DepthStencilAttachmentBitKhr = ,
    FormatFeature2BlitSrcBit = ,
    FormatFeature2BlitSrcBitKhr = ,
    FormatFeature2BlitDstBit = ,
    FormatFeature2BlitDstBitKhr = ,
    FormatFeature2SampledImageFilterLinearBit = ,
    FormatFeature2SampledImageFilterLinearBitKhr = ,
    FormatFeature2SampledImageFilterCubicBit = ,
    FormatFeature2SampledImageFilterCubicBitEXT = ,
    FormatFeature2TransferSrcBit = ,
    FormatFeature2TransferSrcBitKhr = ,
    FormatFeature2TransferDstBit = ,
    FormatFeature2TransferDstBitKhr = ,
    FormatFeature2SampledImageFilterMinmaxBit = ,
    FormatFeature2SampledImageFilterMinmaxBitKhr = ,
    FormatFeature2MidpointChromaSamplesBit = ,
    FormatFeature2MidpointChromaSamplesBitKhr = ,
    FormatFeature2SampledImageYcbcrConversionLinearFilterBit = ,
    FormatFeature2SampledImageYcbcrConversionLinearFilterBitKhr = ,
    FormatFeature2SampledImageYcbcrConversionSeparateReconstructionFilterBit = ,
    FormatFeature2SampledImageYcbcrConversionSeparateReconstructionFilterBitKhr = ,
    FormatFeature2SampledImageYcbcrConversionChromaReconstructionExplicitBit = ,
    FormatFeature2SampledImageYcbcrConversionChromaReconstructionExplicitBitKhr = ,
    FormatFeature2SampledImageYcbcrConversionChromaReconstructionExplicitForceableBit = ,
    FormatFeature2SampledImageYcbcrConversionChromaReconstructionExplicitForceableBitKhr = ,
    FormatFeature2DisjointBit = ,
    FormatFeature2DisjointBitKhr = ,
    FormatFeature2CositedChromaSamplesBit = ,
    FormatFeature2CositedChromaSamplesBitKhr = ,
    FormatFeature2StorageReadWithoutFormatBit = ,
    FormatFeature2StorageReadWithoutFormatBitKhr = ,
    FormatFeature2StorageWriteWithoutFormatBit = ,
    FormatFeature2StorageWriteWithoutFormatBitKhr = ,
    FormatFeature2SampledImageDepthComparisonBit = ,
    FormatFeature2SampledImageDepthComparisonBitKhr = ,
    RenderingContentsSecondaryCommandBuffersBit = ,
    RenderingContentsSecondaryCommandBuffersBitKhr = ,
    RenderingSuspendingBit = ,
    RenderingSuspendingBitKhr = ,
    RenderingResumingBit = ,
    RenderingResumingBitKhr = ,
    VideoEncodeH265CapabilitySeparateColourPlaneBitEXT = ,
    VideoEncodeH265CapabilityScalingListsBitEXT = ,
    VideoEncodeH265CapabilitySampleAdaptiveOffsetEnabledBitEXT = ,
    VideoEncodeH265CapabilityPcmEnableBitEXT = ,
    VideoEncodeH265CapabilitySpsTemporalMvpEnabledBitEXT = ,
    VideoEncodeH265CapabilityHrdComplianceBitEXT = ,
    VideoEncodeH265CapabilityInitQpMinus26BitEXT = ,
    VideoEncodeH265CapabilityLog2ParallelMergeLevelMinus2BitEXT = ,
    VideoEncodeH265CapabilitySignDataHidingEnabledBitEXT = ,
    VideoEncodeH265CapabilityTransformSkipEnabledBitEXT = ,
    VideoEncodeH265CapabilityTransformSkipDisabledBitEXT = ,
    VideoEncodeH265CapabilityPpsSliceChromaQpOffsetsPresentBitEXT = ,
    VideoEncodeH265CapabilityWeightedPredBitEXT = ,
    VideoEncodeH265CapabilityWeightedBipredBitEXT = ,
    VideoEncodeH265CapabilityWeightedPredNoTableBitEXT = ,
    VideoEncodeH265CapabilityTransquantBypassEnabledBitEXT = ,
    VideoEncodeH265CapabilityEntropyCodingSyncEnabledBitEXT = ,
    VideoEncodeH265CapabilityDeblockingFilterOverrideEnabledBitEXT = ,
    VideoEncodeH265CapabilityMultipleTilePerFrameBitEXT = ,
    VideoEncodeH265CapabilityMultipleSlicePerTileBitEXT = ,
    VideoEncodeH265CapabilityMultipleTilePerSliceBitEXT = ,
    VideoEncodeH265CapabilitySliceSegmentCtbCountBitEXT = ,
    VideoEncodeH265CapabilityRowUnalignedSliceSegmentBitEXT = ,
    VideoEncodeH265CapabilityDependentSliceSegmentBitEXT = ,
    VideoEncodeH265CapabilityDifferentSliceTypeBitEXT = ,
    VideoEncodeH265CapabilityBFrameInL1ListBitEXT = ,
    VideoEncodeH265InputModeFrameBitEXT = ,
    VideoEncodeH265InputModeSliceSegmentBitEXT = ,
    VideoEncodeH265InputModeNonVclBitEXT = ,
    VideoEncodeH265OutputModeFrameBitEXT = ,
    VideoEncodeH265OutputModeSliceSegmentBitEXT = ,
    VideoEncodeH265OutputModeNonVclBitEXT = ,
    VideoEncodeH265RateControlStructureUnknownEXT = 0,
    VideoEncodeH265RateControlStructureFlatEXT = 1,
    VideoEncodeH265RateControlStructureDyadicEXT = 2,
    VideoEncodeH265CtbSize16BitEXT = ,
    VideoEncodeH265CtbSize32BitEXT = ,
    VideoEncodeH265CtbSize64BitEXT = ,
    VideoEncodeH265TransformBlockSize4BitEXT = ,
    VideoEncodeH265TransformBlockSize8BitEXT = ,
    VideoEncodeH265TransformBlockSize16BitEXT = ,
    VideoEncodeH265TransformBlockSize32BitEXT = ,
    ExportMetalObjectTypeMetalDeviceBitEXT = ,
    ExportMetalObjectTypeMetalCommandQueueBitEXT = ,
    ExportMetalObjectTypeMetalBufferBitEXT = ,
    ExportMetalObjectTypeMetalTextureBitEXT = ,
    ExportMetalObjectTypeMetalIosurfaceBitEXT = ,
    ExportMetalObjectTypeMetalSharedEventBitEXT = ,
    ImageCompressionDefaultEXT = 0,
    ImageCompressionFixedRateDefaultEXT = ,
    ImageCompressionFixedRateExplicitEXT = ,
    ImageCompressionDisabledEXT = ,
    ImageCompressionFixedRateNoneEXT = 0,
    ImageCompressionFixedRate1bpcBitEXT = ,
    ImageCompressionFixedRate2bpcBitEXT = ,
    ImageCompressionFixedRate3bpcBitEXT = ,
    ImageCompressionFixedRate4bpcBitEXT = ,
    ImageCompressionFixedRate5bpcBitEXT = ,
    ImageCompressionFixedRate6bpcBitEXT = ,
    ImageCompressionFixedRate7bpcBitEXT = ,
    ImageCompressionFixedRate8bpcBitEXT = ,
    ImageCompressionFixedRate9bpcBitEXT = ,
    ImageCompressionFixedRate10bpcBitEXT = ,
    ImageCompressionFixedRate11bpcBitEXT = ,
    ImageCompressionFixedRate12bpcBitEXT = ,
    ImageCompressionFixedRate13bpcBitEXT = ,
    ImageCompressionFixedRate14bpcBitEXT = ,
    ImageCompressionFixedRate15bpcBitEXT = ,
    ImageCompressionFixedRate16bpcBitEXT = ,
    ImageCompressionFixedRate17bpcBitEXT = ,
    ImageCompressionFixedRate18bpcBitEXT = ,
    ImageCompressionFixedRate19bpcBitEXT = ,
    ImageCompressionFixedRate20bpcBitEXT = ,
    ImageCompressionFixedRate21bpcBitEXT = ,
    ImageCompressionFixedRate22bpcBitEXT = ,
    ImageCompressionFixedRate23bpcBitEXT = ,
    ImageCompressionFixedRate24bpcBitEXT = ,
    PipelineRobustnessBufferBehaviorDeviceDefaultEXT = 0,
    PipelineRobustnessBufferBehaviorDisabledEXT = 1,
    PipelineRobustnessBufferBehaviorRobustBufferAccessEXT = 2,
    PipelineRobustnessBufferBehaviorRobustBufferAccess2EXT = 3,
    PipelineRobustnessImageBehaviorDeviceDefaultEXT = 0,
    PipelineRobustnessImageBehaviorDisabledEXT = 1,
    PipelineRobustnessImageBehaviorRobustImageAccessEXT = 2,
    PipelineRobustnessImageBehaviorRobustImageAccess2EXT = 3,
    OpticalFlowGridSizeUnknownNV = 0,
    OpticalFlowGridSize1x1BitNV = ,
    OpticalFlowGridSize2x2BitNV = ,
    OpticalFlowGridSize4x4BitNV = ,
    OpticalFlowGridSize8x8BitNV = ,
    OpticalFlowUsageUnknownNV = 0,
    OpticalFlowUsageInputBitNV = ,
    OpticalFlowUsageOutputBitNV = ,
    OpticalFlowUsageHintBitNV = ,
    OpticalFlowUsageCostBitNV = ,
    OpticalFlowUsageGlobalFlowBitNV = ,
    OpticalFlowPerformanceLevelUnknownNV = 0,
    OpticalFlowPerformanceLevelSlowNV = 1,
    OpticalFlowPerformanceLevelMediumNV = 2,
    OpticalFlowPerformanceLevelFastNV = 3,
    OpticalFlowSessionBindingPointUnknownNV = 0,
    OpticalFlowSessionBindingPointInputNV = 1,
    OpticalFlowSessionBindingPointReferenceNV = 2,
    OpticalFlowSessionBindingPointHintNV = 3,
    OpticalFlowSessionBindingPointFlowVectorNV = 4,
    OpticalFlowSessionBindingPointBackwardFlowVectorNV = 5,
    OpticalFlowSessionBindingPointCostNV = 6,
    OpticalFlowSessionBindingPointBackwardCostNV = 7,
    OpticalFlowSessionBindingPointGlobalFlowNV = 8,
    OpticalFlowSessionCreateEnableHintBitNV = ,
    OpticalFlowSessionCreateEnableCostBitNV = ,
    OpticalFlowSessionCreateEnableGlobalFlowBitNV = ,
    OpticalFlowSessionCreateAllowRegionsBitNV = ,
    OpticalFlowSessionCreateBothDirectionsBitNV = ,
    OpticalFlowExecuteDisableTemporalHintsBitNV = ,
    MicromapTypeOpacityMicromapEXT = 0,
    BuildMicromapPreferFastTraceBitEXT = ,
    BuildMicromapPreferFastBuildBitEXT = ,
    BuildMicromapAllowCompactionBitEXT = ,
    MicromapCreateDeviceAddressCaptureReplayBitEXT = ,
    CopyMicromapModeCloneEXT = 0,
    CopyMicromapModeSerializeEXT = 1,
    CopyMicromapModeDeserializeEXT = 2,
    CopyMicromapModeCompactEXT = 3,
    BuildMicromapModeBuildEXT = 0,
    OpacityMicromapFormat2StateEXT = 1,
    OpacityMicromapFormat4StateEXT = 2,
    OpacityMicromapSpecialIndexFullyTransparentEXT = -1,
    OpacityMicromapSpecialIndexFullyOpaqueEXT = -2,
    OpacityMicromapSpecialIndexFullyUnknownTransparentEXT = -3,
    OpacityMicromapSpecialIndexFullyUnknownOpaqueEXT = -4,
    DeviceFaultAddressTypeNoneEXT = 0,
    DeviceFaultAddressTypeReadInvalidEXT = 1,
    DeviceFaultAddressTypeWriteInvalidEXT = 2,
    DeviceFaultAddressTypeExecuteInvalidEXT = 3,
    DeviceFaultAddressTypeInstructionPointerUnknownEXT = 4,
    DeviceFaultAddressTypeInstructionPointerInvalidEXT = 5,
    DeviceFaultAddressTypeInstructionPointerFaultEXT = 6,
    DeviceFaultVendorBinaryHeaderVersionOneEXT = 1,
}
    
    public class Vulkan
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateInstance(/*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pInstance* pInstance);
        private readonly VulkanCreateInstance vkCreateInstance;
        
        public unsafe VkResult CreateInstance(/*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pInstance* pInstance) =>
            this.vkCreateInstance.Invoke(pCreateInfo, pAllocator, pInstance);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyInstance(instance instance, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyInstance vkDestroyInstance;
        
        public unsafe void DestroyInstance(instance instance, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyInstance.Invoke(instance, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumeratePhysicalDevices(instance instance, pPhysicalDeviceCount* pPhysicalDeviceCount, pPhysicalDevices* pPhysicalDevices);
        private readonly VulkanEnumeratePhysicalDevices vkEnumeratePhysicalDevices;
        
        public unsafe VkResult EnumeratePhysicalDevices(instance instance, pPhysicalDeviceCount* pPhysicalDeviceCount, pPhysicalDevices* pPhysicalDevices) =>
            this.vkEnumeratePhysicalDevices.Invoke(instance, pPhysicalDeviceCount, pPhysicalDevices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceFeatures(physicalDevice physicalDevice, pFeatures* pFeatures);
        private readonly VulkanGetPhysicalDeviceFeatures vkGetPhysicalDeviceFeatures;
        
        public unsafe void GetPhysicalDeviceFeatures(physicalDevice physicalDevice, pFeatures* pFeatures) =>
            this.vkGetPhysicalDeviceFeatures.Invoke(physicalDevice, pFeatures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceFormatProperties(physicalDevice physicalDevice, format format, pFormatProperties* pFormatProperties);
        private readonly VulkanGetPhysicalDeviceFormatProperties vkGetPhysicalDeviceFormatProperties;
        
        public unsafe void GetPhysicalDeviceFormatProperties(physicalDevice physicalDevice, format format, pFormatProperties* pFormatProperties) =>
            this.vkGetPhysicalDeviceFormatProperties.Invoke(physicalDevice, format, pFormatProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceImageFormatProperties(physicalDevice physicalDevice, format format, type type, tiling tiling, usage usage, flags flags, pImageFormatProperties* pImageFormatProperties);
        private readonly VulkanGetPhysicalDeviceImageFormatProperties vkGetPhysicalDeviceImageFormatProperties;
        
        public unsafe VkResult GetPhysicalDeviceImageFormatProperties(physicalDevice physicalDevice, format format, type type, tiling tiling, usage usage, flags flags, pImageFormatProperties* pImageFormatProperties) =>
            this.vkGetPhysicalDeviceImageFormatProperties.Invoke(physicalDevice, format, type, tiling, usage, flags, pImageFormatProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceProperties(physicalDevice physicalDevice, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceProperties vkGetPhysicalDeviceProperties;
        
        public unsafe void GetPhysicalDeviceProperties(physicalDevice physicalDevice, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceProperties.Invoke(physicalDevice, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceQueueFamilyProperties(physicalDevice physicalDevice, pQueueFamilyPropertyCount* pQueueFamilyPropertyCount, pQueueFamilyProperties* pQueueFamilyProperties);
        private readonly VulkanGetPhysicalDeviceQueueFamilyProperties vkGetPhysicalDeviceQueueFamilyProperties;
        
        public unsafe void GetPhysicalDeviceQueueFamilyProperties(physicalDevice physicalDevice, pQueueFamilyPropertyCount* pQueueFamilyPropertyCount, pQueueFamilyProperties* pQueueFamilyProperties) =>
            this.vkGetPhysicalDeviceQueueFamilyProperties.Invoke(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceMemoryProperties(physicalDevice physicalDevice, pMemoryProperties* pMemoryProperties);
        private readonly VulkanGetPhysicalDeviceMemoryProperties vkGetPhysicalDeviceMemoryProperties;
        
        public unsafe void GetPhysicalDeviceMemoryProperties(physicalDevice physicalDevice, pMemoryProperties* pMemoryProperties) =>
            this.vkGetPhysicalDeviceMemoryProperties.Invoke(physicalDevice, pMemoryProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate PFN_vkVoidFunction VulkanGetInstanceProcAddr(instance instance, /*const*/ pName* pName);
        private readonly VulkanGetInstanceProcAddr vkGetInstanceProcAddr;
        
        public unsafe PFN_vkVoidFunction GetInstanceProcAddr(instance instance, /*const*/ pName* pName) =>
            this.vkGetInstanceProcAddr.Invoke(instance, pName);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate PFN_vkVoidFunction VulkanGetDeviceProcAddr(device device, /*const*/ pName* pName);
        private readonly VulkanGetDeviceProcAddr vkGetDeviceProcAddr;
        
        public unsafe PFN_vkVoidFunction GetDeviceProcAddr(device device, /*const*/ pName* pName) =>
            this.vkGetDeviceProcAddr.Invoke(device, pName);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDevice(physicalDevice physicalDevice, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDevice* pDevice);
        private readonly VulkanCreateDevice vkCreateDevice;
        
        public unsafe VkResult CreateDevice(physicalDevice physicalDevice, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDevice* pDevice) =>
            this.vkCreateDevice.Invoke(physicalDevice, pCreateInfo, pAllocator, pDevice);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDevice(physicalDevice physicalDevice, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDevice* pDevice);
        private readonly VulkanCreateDevice vkCreateDevice;
        
        public unsafe VkResult CreateDevice(physicalDevice physicalDevice, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDevice* pDevice) =>
            this.vkCreateDevice.Invoke(physicalDevice, pCreateInfo, pAllocator, pDevice);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyDevice(device device, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyDevice vkDestroyDevice;
        
        public unsafe void DestroyDevice(device device, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyDevice.Invoke(device, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateInstanceExtensionProperties(/*const*/ pLayerName* pLayerName, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanEnumerateInstanceExtensionProperties vkEnumerateInstanceExtensionProperties;
        
        public unsafe VkResult EnumerateInstanceExtensionProperties(/*const*/ pLayerName* pLayerName, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkEnumerateInstanceExtensionProperties.Invoke(pLayerName, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateDeviceExtensionProperties(physicalDevice physicalDevice, /*const*/ pLayerName* pLayerName, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanEnumerateDeviceExtensionProperties vkEnumerateDeviceExtensionProperties;
        
        public unsafe VkResult EnumerateDeviceExtensionProperties(physicalDevice physicalDevice, /*const*/ pLayerName* pLayerName, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkEnumerateDeviceExtensionProperties.Invoke(physicalDevice, pLayerName, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateInstanceLayerProperties(pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanEnumerateInstanceLayerProperties vkEnumerateInstanceLayerProperties;
        
        public unsafe VkResult EnumerateInstanceLayerProperties(pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkEnumerateInstanceLayerProperties.Invoke(pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateDeviceLayerProperties(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanEnumerateDeviceLayerProperties vkEnumerateDeviceLayerProperties;
        
        public unsafe VkResult EnumerateDeviceLayerProperties(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkEnumerateDeviceLayerProperties.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateDeviceLayerProperties(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanEnumerateDeviceLayerProperties vkEnumerateDeviceLayerProperties;
        
        public unsafe VkResult EnumerateDeviceLayerProperties(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkEnumerateDeviceLayerProperties.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceQueue(device device, queueFamilyIndex queueFamilyIndex, queueIndex queueIndex, pQueue* pQueue);
        private readonly VulkanGetDeviceQueue vkGetDeviceQueue;
        
        public unsafe void GetDeviceQueue(device device, queueFamilyIndex queueFamilyIndex, queueIndex queueIndex, pQueue* pQueue) =>
            this.vkGetDeviceQueue.Invoke(device, queueFamilyIndex, queueIndex, pQueue);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanQueueSubmit(queue queue, submitCount submitCount, /*const*/ pSubmits* pSubmits, fence fence);
        private readonly VulkanQueueSubmit vkQueueSubmit;
        
        public unsafe VkResult QueueSubmit(queue queue, submitCount submitCount, /*const*/ pSubmits* pSubmits, fence fence) =>
            this.vkQueueSubmit.Invoke(queue, submitCount, pSubmits, fence);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanQueueWaitIdle(queue queue);
        private readonly VulkanQueueWaitIdle vkQueueWaitIdle;
        
        public VkResult QueueWaitIdle(queue queue) =>
            this.vkQueueWaitIdle.Invoke(queue);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanDeviceWaitIdle(device device);
        private readonly VulkanDeviceWaitIdle vkDeviceWaitIdle;
        
        public VkResult DeviceWaitIdle(device device) =>
            this.vkDeviceWaitIdle.Invoke(device);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAllocateMemory(device device, /*const*/ pAllocateInfo* pAllocateInfo, /*const*/ pAllocator* pAllocator, pMemory* pMemory);
        private readonly VulkanAllocateMemory vkAllocateMemory;
        
        public unsafe VkResult AllocateMemory(device device, /*const*/ pAllocateInfo* pAllocateInfo, /*const*/ pAllocator* pAllocator, pMemory* pMemory) =>
            this.vkAllocateMemory.Invoke(device, pAllocateInfo, pAllocator, pMemory);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanMapMemory(device device, memory memory, offset offset, size size, flags flags, ppData* ppData);
        private readonly VulkanMapMemory vkMapMemory;
        
        public unsafe VkResult MapMemory(device device, memory memory, offset offset, size size, flags flags, ppData* ppData) =>
            this.vkMapMemory.Invoke(device, memory, offset, size, flags, ppData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanUnmapMemory(device device, memory memory);
        private readonly VulkanUnmapMemory vkUnmapMemory;
        
        public void UnmapMemory(device device, memory memory) =>
            this.vkUnmapMemory.Invoke(device, memory);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanFlushMappedMemoryRanges(device device, memoryRangeCount memoryRangeCount, /*const*/ pMemoryRanges* pMemoryRanges);
        private readonly VulkanFlushMappedMemoryRanges vkFlushMappedMemoryRanges;
        
        public unsafe VkResult FlushMappedMemoryRanges(device device, memoryRangeCount memoryRangeCount, /*const*/ pMemoryRanges* pMemoryRanges) =>
            this.vkFlushMappedMemoryRanges.Invoke(device, memoryRangeCount, pMemoryRanges);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanInvalidateMappedMemoryRanges(device device, memoryRangeCount memoryRangeCount, /*const*/ pMemoryRanges* pMemoryRanges);
        private readonly VulkanInvalidateMappedMemoryRanges vkInvalidateMappedMemoryRanges;
        
        public unsafe VkResult InvalidateMappedMemoryRanges(device device, memoryRangeCount memoryRangeCount, /*const*/ pMemoryRanges* pMemoryRanges) =>
            this.vkInvalidateMappedMemoryRanges.Invoke(device, memoryRangeCount, pMemoryRanges);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceMemoryCommitment(device device, memory memory, pCommittedMemoryInBytes* pCommittedMemoryInBytes);
        private readonly VulkanGetDeviceMemoryCommitment vkGetDeviceMemoryCommitment;
        
        public unsafe void GetDeviceMemoryCommitment(device device, memory memory, pCommittedMemoryInBytes* pCommittedMemoryInBytes) =>
            this.vkGetDeviceMemoryCommitment.Invoke(device, memory, pCommittedMemoryInBytes);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanBindBufferMemory(device device, buffer buffer, memory memory, memoryOffset memoryOffset);
        private readonly VulkanBindBufferMemory vkBindBufferMemory;
        
        public VkResult BindBufferMemory(device device, buffer buffer, memory memory, memoryOffset memoryOffset) =>
            this.vkBindBufferMemory.Invoke(device, buffer, memory, memoryOffset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanBindImageMemory(device device, image image, memory memory, memoryOffset memoryOffset);
        private readonly VulkanBindImageMemory vkBindImageMemory;
        
        public VkResult BindImageMemory(device device, image image, memory memory, memoryOffset memoryOffset) =>
            this.vkBindImageMemory.Invoke(device, image, memory, memoryOffset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetBufferMemoryRequirements(device device, buffer buffer, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetBufferMemoryRequirements vkGetBufferMemoryRequirements;
        
        public unsafe void GetBufferMemoryRequirements(device device, buffer buffer, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetBufferMemoryRequirements.Invoke(device, buffer, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetImageMemoryRequirements(device device, image image, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetImageMemoryRequirements vkGetImageMemoryRequirements;
        
        public unsafe void GetImageMemoryRequirements(device device, image image, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetImageMemoryRequirements.Invoke(device, image, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroySwapchainKHR(device device, swapchain swapchain, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroySwapchainKHR vkDestroySwapchainKHR;
        
        public unsafe void DestroySwapchainKHR(device device, swapchain swapchain, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroySwapchainKHR.Invoke(device, swapchain, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateFence(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pFence* pFence);
        private readonly VulkanCreateFence vkCreateFence;
        
        public unsafe VkResult CreateFence(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pFence* pFence) =>
            this.vkCreateFence.Invoke(device, pCreateInfo, pAllocator, pFence);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyFence(device device, fence fence, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyFence vkDestroyFence;
        
        public unsafe void DestroyFence(device device, fence fence, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyFence.Invoke(device, fence, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanResetFences(device device, fenceCount fenceCount, /*const*/ pFences* pFences);
        private readonly VulkanResetFences vkResetFences;
        
        public unsafe VkResult ResetFences(device device, fenceCount fenceCount, /*const*/ pFences* pFences) =>
            this.vkResetFences.Invoke(device, fenceCount, pFences);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanGetFenceStatus(device device, fence fence);
        private readonly VulkanGetFenceStatus vkGetFenceStatus;
        
        public VkResult GetFenceStatus(device device, fence fence) =>
            this.vkGetFenceStatus.Invoke(device, fence);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanWaitForFences(device device, fenceCount fenceCount, /*const*/ pFences* pFences, waitAll waitAll, timeout timeout);
        private readonly VulkanWaitForFences vkWaitForFences;
        
        public unsafe VkResult WaitForFences(device device, fenceCount fenceCount, /*const*/ pFences* pFences, waitAll waitAll, timeout timeout) =>
            this.vkWaitForFences.Invoke(device, fenceCount, pFences, waitAll, timeout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateSemaphore(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSemaphore* pSemaphore);
        private readonly VulkanCreateSemaphore vkCreateSemaphore;
        
        public unsafe VkResult CreateSemaphore(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSemaphore* pSemaphore) =>
            this.vkCreateSemaphore.Invoke(device, pCreateInfo, pAllocator, pSemaphore);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroySemaphore(device device, semaphore semaphore, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroySemaphore vkDestroySemaphore;
        
        public unsafe void DestroySemaphore(device device, semaphore semaphore, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroySemaphore.Invoke(device, semaphore, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateEvent(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pEvent* pEvent);
        private readonly VulkanCreateEvent vkCreateEvent;
        
        public unsafe VkResult CreateEvent(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pEvent* pEvent) =>
            this.vkCreateEvent.Invoke(device, pCreateInfo, pAllocator, pEvent);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyEvent(device device, event @event, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyEvent vkDestroyEvent;
        
        public unsafe void DestroyEvent(device device, event @event, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyEvent.Invoke(device, @event, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanGetEventStatus(device device, event @event);
        private readonly VulkanGetEventStatus vkGetEventStatus;
        
        public VkResult GetEventStatus(device device, event @event) =>
            this.vkGetEventStatus.Invoke(device, @event);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanSetEvent(device device, event @event);
        private readonly VulkanSetEvent vkSetEvent;
        
        public VkResult SetEvent(device device, event @event) =>
            this.vkSetEvent.Invoke(device, @event);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanResetEvent(device device, event @event);
        private readonly VulkanResetEvent vkResetEvent;
        
        public VkResult ResetEvent(device device, event @event) =>
            this.vkResetEvent.Invoke(device, @event);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateQueryPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pQueryPool* pQueryPool);
        private readonly VulkanCreateQueryPool vkCreateQueryPool;
        
        public unsafe VkResult CreateQueryPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pQueryPool* pQueryPool) =>
            this.vkCreateQueryPool.Invoke(device, pCreateInfo, pAllocator, pQueryPool);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetQueryPoolResults(device device, queryPool queryPool, firstQuery firstQuery, queryCount queryCount, dataSize dataSize, pData* pData, stride stride, flags flags);
        private readonly VulkanGetQueryPoolResults vkGetQueryPoolResults;
        
        public unsafe VkResult GetQueryPoolResults(device device, queryPool queryPool, firstQuery firstQuery, queryCount queryCount, dataSize dataSize, pData* pData, stride stride, flags flags) =>
            this.vkGetQueryPoolResults.Invoke(device, queryPool, firstQuery, queryCount, dataSize, pData, stride, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateBuffer(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pBuffer* pBuffer);
        private readonly VulkanCreateBuffer vkCreateBuffer;
        
        public unsafe VkResult CreateBuffer(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pBuffer* pBuffer) =>
            this.vkCreateBuffer.Invoke(device, pCreateInfo, pAllocator, pBuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyBuffer(device device, buffer buffer, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyBuffer vkDestroyBuffer;
        
        public unsafe void DestroyBuffer(device device, buffer buffer, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyBuffer.Invoke(device, buffer, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateBufferView(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pView* pView);
        private readonly VulkanCreateBufferView vkCreateBufferView;
        
        public unsafe VkResult CreateBufferView(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pView* pView) =>
            this.vkCreateBufferView.Invoke(device, pCreateInfo, pAllocator, pView);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyBufferView(device device, bufferView bufferView, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyBufferView vkDestroyBufferView;
        
        public unsafe void DestroyBufferView(device device, bufferView bufferView, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyBufferView.Invoke(device, bufferView, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateImage(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pImage* pImage);
        private readonly VulkanCreateImage vkCreateImage;
        
        public unsafe VkResult CreateImage(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pImage* pImage) =>
            this.vkCreateImage.Invoke(device, pCreateInfo, pAllocator, pImage);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyImage(device device, image image, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyImage vkDestroyImage;
        
        public unsafe void DestroyImage(device device, image image, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyImage.Invoke(device, image, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetImageSubresourceLayout(device device, image image, /*const*/ pSubresource* pSubresource, pLayout* pLayout);
        private readonly VulkanGetImageSubresourceLayout vkGetImageSubresourceLayout;
        
        public unsafe void GetImageSubresourceLayout(device device, image image, /*const*/ pSubresource* pSubresource, pLayout* pLayout) =>
            this.vkGetImageSubresourceLayout.Invoke(device, image, pSubresource, pLayout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateImageView(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pView* pView);
        private readonly VulkanCreateImageView vkCreateImageView;
        
        public unsafe VkResult CreateImageView(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pView* pView) =>
            this.vkCreateImageView.Invoke(device, pCreateInfo, pAllocator, pView);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyImageView(device device, imageView imageView, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyImageView vkDestroyImageView;
        
        public unsafe void DestroyImageView(device device, imageView imageView, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyImageView.Invoke(device, imageView, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreatePipelineCache(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineCache* pPipelineCache);
        private readonly VulkanCreatePipelineCache vkCreatePipelineCache;
        
        public unsafe VkResult CreatePipelineCache(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineCache* pPipelineCache) =>
            this.vkCreatePipelineCache.Invoke(device, pCreateInfo, pAllocator, pPipelineCache);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreatePipelineCache(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineCache* pPipelineCache);
        private readonly VulkanCreatePipelineCache vkCreatePipelineCache;
        
        public unsafe VkResult CreatePipelineCache(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineCache* pPipelineCache) =>
            this.vkCreatePipelineCache.Invoke(device, pCreateInfo, pAllocator, pPipelineCache);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyPipelineCache(device device, pipelineCache pipelineCache, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyPipelineCache vkDestroyPipelineCache;
        
        public unsafe void DestroyPipelineCache(device device, pipelineCache pipelineCache, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyPipelineCache.Invoke(device, pipelineCache, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateGraphicsPipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateGraphicsPipelines vkCreateGraphicsPipelines;
        
        public unsafe VkResult CreateGraphicsPipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateGraphicsPipelines.Invoke(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateGraphicsPipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateGraphicsPipelines vkCreateGraphicsPipelines;
        
        public unsafe VkResult CreateGraphicsPipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateGraphicsPipelines.Invoke(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateComputePipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateComputePipelines vkCreateComputePipelines;
        
        public unsafe VkResult CreateComputePipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateComputePipelines.Invoke(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateComputePipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateComputePipelines vkCreateComputePipelines;
        
        public unsafe VkResult CreateComputePipelines(device device, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateComputePipelines.Invoke(device, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyPipeline(device device, pipeline pipeline, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyPipeline vkDestroyPipeline;
        
        public unsafe void DestroyPipeline(device device, pipeline pipeline, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyPipeline.Invoke(device, pipeline, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreatePipelineLayout(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineLayout* pPipelineLayout);
        private readonly VulkanCreatePipelineLayout vkCreatePipelineLayout;
        
        public unsafe VkResult CreatePipelineLayout(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPipelineLayout* pPipelineLayout) =>
            this.vkCreatePipelineLayout.Invoke(device, pCreateInfo, pAllocator, pPipelineLayout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyPipelineLayout(device device, pipelineLayout pipelineLayout, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyPipelineLayout vkDestroyPipelineLayout;
        
        public unsafe void DestroyPipelineLayout(device device, pipelineLayout pipelineLayout, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyPipelineLayout.Invoke(device, pipelineLayout, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateSampler(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSampler* pSampler);
        private readonly VulkanCreateSampler vkCreateSampler;
        
        public unsafe VkResult CreateSampler(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSampler* pSampler) =>
            this.vkCreateSampler.Invoke(device, pCreateInfo, pAllocator, pSampler);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroySampler(device device, sampler sampler, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroySampler vkDestroySampler;
        
        public unsafe void DestroySampler(device device, sampler sampler, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroySampler.Invoke(device, sampler, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDescriptorSetLayout(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSetLayout* pSetLayout);
        private readonly VulkanCreateDescriptorSetLayout vkCreateDescriptorSetLayout;
        
        public unsafe VkResult CreateDescriptorSetLayout(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSetLayout* pSetLayout) =>
            this.vkCreateDescriptorSetLayout.Invoke(device, pCreateInfo, pAllocator, pSetLayout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyDescriptorSetLayout(device device, descriptorSetLayout descriptorSetLayout, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyDescriptorSetLayout vkDestroyDescriptorSetLayout;
        
        public unsafe void DestroyDescriptorSetLayout(device device, descriptorSetLayout descriptorSetLayout, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyDescriptorSetLayout.Invoke(device, descriptorSetLayout, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDescriptorPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDescriptorPool* pDescriptorPool);
        private readonly VulkanCreateDescriptorPool vkCreateDescriptorPool;
        
        public unsafe VkResult CreateDescriptorPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pDescriptorPool* pDescriptorPool) =>
            this.vkCreateDescriptorPool.Invoke(device, pCreateInfo, pAllocator, pDescriptorPool);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanResetDescriptorPool(device device, descriptorPool descriptorPool, flags flags);
        private readonly VulkanResetDescriptorPool vkResetDescriptorPool;
        
        public VkResult ResetDescriptorPool(device device, descriptorPool descriptorPool, flags flags) =>
            this.vkResetDescriptorPool.Invoke(device, descriptorPool, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAllocateDescriptorSets(device device, /*const*/ pAllocateInfo* pAllocateInfo, pDescriptorSets* pDescriptorSets);
        private readonly VulkanAllocateDescriptorSets vkAllocateDescriptorSets;
        
        public unsafe VkResult AllocateDescriptorSets(device device, /*const*/ pAllocateInfo* pAllocateInfo, pDescriptorSets* pDescriptorSets) =>
            this.vkAllocateDescriptorSets.Invoke(device, pAllocateInfo, pDescriptorSets);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanFreeDescriptorSets(device device, descriptorPool descriptorPool, descriptorSetCount descriptorSetCount, /*const*/ pDescriptorSets* pDescriptorSets);
        private readonly VulkanFreeDescriptorSets vkFreeDescriptorSets;
        
        public unsafe VkResult FreeDescriptorSets(device device, descriptorPool descriptorPool, descriptorSetCount descriptorSetCount, /*const*/ pDescriptorSets* pDescriptorSets) =>
            this.vkFreeDescriptorSets.Invoke(device, descriptorPool, descriptorSetCount, pDescriptorSets);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanUpdateDescriptorSets(device device, descriptorWriteCount descriptorWriteCount, /*const*/ pDescriptorWrites* pDescriptorWrites, descriptorCopyCount descriptorCopyCount, /*const*/ pDescriptorCopies* pDescriptorCopies);
        private readonly VulkanUpdateDescriptorSets vkUpdateDescriptorSets;
        
        public unsafe void UpdateDescriptorSets(device device, descriptorWriteCount descriptorWriteCount, /*const*/ pDescriptorWrites* pDescriptorWrites, descriptorCopyCount descriptorCopyCount, /*const*/ pDescriptorCopies* pDescriptorCopies) =>
            this.vkUpdateDescriptorSets.Invoke(device, descriptorWriteCount, pDescriptorWrites, descriptorCopyCount, pDescriptorCopies);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateFramebuffer(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pFramebuffer* pFramebuffer);
        private readonly VulkanCreateFramebuffer vkCreateFramebuffer;
        
        public unsafe VkResult CreateFramebuffer(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pFramebuffer* pFramebuffer) =>
            this.vkCreateFramebuffer.Invoke(device, pCreateInfo, pAllocator, pFramebuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyFramebuffer(device device, framebuffer framebuffer, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyFramebuffer vkDestroyFramebuffer;
        
        public unsafe void DestroyFramebuffer(device device, framebuffer framebuffer, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyFramebuffer.Invoke(device, framebuffer, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateRenderPass(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pRenderPass* pRenderPass);
        private readonly VulkanCreateRenderPass vkCreateRenderPass;
        
        public unsafe VkResult CreateRenderPass(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pRenderPass* pRenderPass) =>
            this.vkCreateRenderPass.Invoke(device, pCreateInfo, pAllocator, pRenderPass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyRenderPass(device device, renderPass renderPass, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyRenderPass vkDestroyRenderPass;
        
        public unsafe void DestroyRenderPass(device device, renderPass renderPass, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyRenderPass.Invoke(device, renderPass, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetRenderAreaGranularity(device device, renderPass renderPass, pGranularity* pGranularity);
        private readonly VulkanGetRenderAreaGranularity vkGetRenderAreaGranularity;
        
        public unsafe void GetRenderAreaGranularity(device device, renderPass renderPass, pGranularity* pGranularity) =>
            this.vkGetRenderAreaGranularity.Invoke(device, renderPass, pGranularity);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateCommandPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pCommandPool* pCommandPool);
        private readonly VulkanCreateCommandPool vkCreateCommandPool;
        
        public unsafe VkResult CreateCommandPool(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pCommandPool* pCommandPool) =>
            this.vkCreateCommandPool.Invoke(device, pCreateInfo, pAllocator, pCommandPool);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanResetCommandPool(device device, commandPool commandPool, flags flags);
        private readonly VulkanResetCommandPool vkResetCommandPool;
        
        public VkResult ResetCommandPool(device device, commandPool commandPool, flags flags) =>
            this.vkResetCommandPool.Invoke(device, commandPool, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAllocateCommandBuffers(device device, /*const*/ pAllocateInfo* pAllocateInfo, pCommandBuffers* pCommandBuffers);
        private readonly VulkanAllocateCommandBuffers vkAllocateCommandBuffers;
        
        public unsafe VkResult AllocateCommandBuffers(device device, /*const*/ pAllocateInfo* pAllocateInfo, pCommandBuffers* pCommandBuffers) =>
            this.vkAllocateCommandBuffers.Invoke(device, pAllocateInfo, pCommandBuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanFreeCommandBuffers(device device, commandPool commandPool, commandBufferCount commandBufferCount, /*const*/ pCommandBuffers* pCommandBuffers);
        private readonly VulkanFreeCommandBuffers vkFreeCommandBuffers;
        
        public unsafe void FreeCommandBuffers(device device, commandPool commandPool, commandBufferCount commandBufferCount, /*const*/ pCommandBuffers* pCommandBuffers) =>
            this.vkFreeCommandBuffers.Invoke(device, commandPool, commandBufferCount, pCommandBuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanBeginCommandBuffer(commandBuffer commandBuffer, /*const*/ pBeginInfo* pBeginInfo);
        private readonly VulkanBeginCommandBuffer vkBeginCommandBuffer;
        
        public unsafe VkResult BeginCommandBuffer(commandBuffer commandBuffer, /*const*/ pBeginInfo* pBeginInfo) =>
            this.vkBeginCommandBuffer.Invoke(commandBuffer, pBeginInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanEndCommandBuffer(commandBuffer commandBuffer);
        private readonly VulkanEndCommandBuffer vkEndCommandBuffer;
        
        public VkResult EndCommandBuffer(commandBuffer commandBuffer) =>
            this.vkEndCommandBuffer.Invoke(commandBuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanResetCommandBuffer(commandBuffer commandBuffer, flags flags);
        private readonly VulkanResetCommandBuffer vkResetCommandBuffer;
        
        public VkResult ResetCommandBuffer(commandBuffer commandBuffer, flags flags) =>
            this.vkResetCommandBuffer.Invoke(commandBuffer, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdBindPipeline(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, pipeline pipeline);
        private readonly VulkanCmdBindPipeline vkCmdBindPipeline;
        
        public void CmdBindPipeline(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, pipeline pipeline) =>
            this.vkCmdBindPipeline.Invoke(commandBuffer, pipelineBindPoint, pipeline);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetViewport(commandBuffer commandBuffer, firstViewport firstViewport, viewportCount viewportCount, /*const*/ pViewports* pViewports);
        private readonly VulkanCmdSetViewport vkCmdSetViewport;
        
        public unsafe void CmdSetViewport(commandBuffer commandBuffer, firstViewport firstViewport, viewportCount viewportCount, /*const*/ pViewports* pViewports) =>
            this.vkCmdSetViewport.Invoke(commandBuffer, firstViewport, viewportCount, pViewports);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetScissor(commandBuffer commandBuffer, firstScissor firstScissor, scissorCount scissorCount, /*const*/ pScissors* pScissors);
        private readonly VulkanCmdSetScissor vkCmdSetScissor;
        
        public unsafe void CmdSetScissor(commandBuffer commandBuffer, firstScissor firstScissor, scissorCount scissorCount, /*const*/ pScissors* pScissors) =>
            this.vkCmdSetScissor.Invoke(commandBuffer, firstScissor, scissorCount, pScissors);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetLineWidth(commandBuffer commandBuffer, lineWidth lineWidth);
        private readonly VulkanCmdSetLineWidth vkCmdSetLineWidth;
        
        public void CmdSetLineWidth(commandBuffer commandBuffer, lineWidth lineWidth) =>
            this.vkCmdSetLineWidth.Invoke(commandBuffer, lineWidth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthBias(commandBuffer commandBuffer, depthBiasConstantFactor depthBiasConstantFactor, depthBiasClamp depthBiasClamp, depthBiasSlopeFactor depthBiasSlopeFactor);
        private readonly VulkanCmdSetDepthBias vkCmdSetDepthBias;
        
        public void CmdSetDepthBias(commandBuffer commandBuffer, depthBiasConstantFactor depthBiasConstantFactor, depthBiasClamp depthBiasClamp, depthBiasSlopeFactor depthBiasSlopeFactor) =>
            this.vkCmdSetDepthBias.Invoke(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetBlendConstants(commandBuffer commandBuffer, /*const*/ blendConstants* [4]);
        private readonly VulkanCmdSetBlendConstants vkCmdSetBlendConstants;
        
        public void CmdSetBlendConstants(commandBuffer commandBuffer, /*const*/ blendConstants* [4]) =>
            this.vkCmdSetBlendConstants.Invoke(commandBuffer, [4]);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthBounds(commandBuffer commandBuffer, minDepthBounds minDepthBounds, maxDepthBounds maxDepthBounds);
        private readonly VulkanCmdSetDepthBounds vkCmdSetDepthBounds;
        
        public void CmdSetDepthBounds(commandBuffer commandBuffer, minDepthBounds minDepthBounds, maxDepthBounds maxDepthBounds) =>
            this.vkCmdSetDepthBounds.Invoke(commandBuffer, minDepthBounds, maxDepthBounds);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetStencilCompareMask(commandBuffer commandBuffer, faceMask faceMask, compareMask compareMask);
        private readonly VulkanCmdSetStencilCompareMask vkCmdSetStencilCompareMask;
        
        public void CmdSetStencilCompareMask(commandBuffer commandBuffer, faceMask faceMask, compareMask compareMask) =>
            this.vkCmdSetStencilCompareMask.Invoke(commandBuffer, faceMask, compareMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetStencilWriteMask(commandBuffer commandBuffer, faceMask faceMask, writeMask writeMask);
        private readonly VulkanCmdSetStencilWriteMask vkCmdSetStencilWriteMask;
        
        public void CmdSetStencilWriteMask(commandBuffer commandBuffer, faceMask faceMask, writeMask writeMask) =>
            this.vkCmdSetStencilWriteMask.Invoke(commandBuffer, faceMask, writeMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetStencilReference(commandBuffer commandBuffer, faceMask faceMask, reference reference);
        private readonly VulkanCmdSetStencilReference vkCmdSetStencilReference;
        
        public void CmdSetStencilReference(commandBuffer commandBuffer, faceMask faceMask, reference reference) =>
            this.vkCmdSetStencilReference.Invoke(commandBuffer, faceMask, reference);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBindDescriptorSets(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, layout layout, firstSet firstSet, descriptorSetCount descriptorSetCount, /*const*/ pDescriptorSets* pDescriptorSets, dynamicOffsetCount dynamicOffsetCount, /*const*/ pDynamicOffsets* pDynamicOffsets);
        private readonly VulkanCmdBindDescriptorSets vkCmdBindDescriptorSets;
        
        public unsafe void CmdBindDescriptorSets(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, layout layout, firstSet firstSet, descriptorSetCount descriptorSetCount, /*const*/ pDescriptorSets* pDescriptorSets, dynamicOffsetCount dynamicOffsetCount, /*const*/ pDynamicOffsets* pDynamicOffsets) =>
            this.vkCmdBindDescriptorSets.Invoke(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, pDescriptorSets, dynamicOffsetCount, pDynamicOffsets);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdBindIndexBuffer(commandBuffer commandBuffer, buffer buffer, offset offset, indexType indexType);
        private readonly VulkanCmdBindIndexBuffer vkCmdBindIndexBuffer;
        
        public void CmdBindIndexBuffer(commandBuffer commandBuffer, buffer buffer, offset offset, indexType indexType) =>
            this.vkCmdBindIndexBuffer.Invoke(commandBuffer, buffer, offset, indexType);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBindVertexBuffers(commandBuffer commandBuffer, firstBinding firstBinding, bindingCount bindingCount, /*const*/ pBuffers* pBuffers, /*const*/ pOffsets* pOffsets);
        private readonly VulkanCmdBindVertexBuffers vkCmdBindVertexBuffers;
        
        public unsafe void CmdBindVertexBuffers(commandBuffer commandBuffer, firstBinding firstBinding, bindingCount bindingCount, /*const*/ pBuffers* pBuffers, /*const*/ pOffsets* pOffsets) =>
            this.vkCmdBindVertexBuffers.Invoke(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDraw(commandBuffer commandBuffer, vertexCount vertexCount, instanceCount instanceCount, firstVertex firstVertex, firstInstance firstInstance);
        private readonly VulkanCmdDraw vkCmdDraw;
        
        public void CmdDraw(commandBuffer commandBuffer, vertexCount vertexCount, instanceCount instanceCount, firstVertex firstVertex, firstInstance firstInstance) =>
            this.vkCmdDraw.Invoke(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDrawIndexed(commandBuffer commandBuffer, indexCount indexCount, instanceCount instanceCount, firstIndex firstIndex, vertexOffset vertexOffset, firstInstance firstInstance);
        private readonly VulkanCmdDrawIndexed vkCmdDrawIndexed;
        
        public void CmdDrawIndexed(commandBuffer commandBuffer, indexCount indexCount, instanceCount instanceCount, firstIndex firstIndex, vertexOffset vertexOffset, firstInstance firstInstance) =>
            this.vkCmdDrawIndexed.Invoke(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDrawIndirect(commandBuffer commandBuffer, buffer buffer, offset offset, drawCount drawCount, stride stride);
        private readonly VulkanCmdDrawIndirect vkCmdDrawIndirect;
        
        public void CmdDrawIndirect(commandBuffer commandBuffer, buffer buffer, offset offset, drawCount drawCount, stride stride) =>
            this.vkCmdDrawIndirect.Invoke(commandBuffer, buffer, offset, drawCount, stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDrawIndexedIndirect(commandBuffer commandBuffer, buffer buffer, offset offset, drawCount drawCount, stride stride);
        private readonly VulkanCmdDrawIndexedIndirect vkCmdDrawIndexedIndirect;
        
        public void CmdDrawIndexedIndirect(commandBuffer commandBuffer, buffer buffer, offset offset, drawCount drawCount, stride stride) =>
            this.vkCmdDrawIndexedIndirect.Invoke(commandBuffer, buffer, offset, drawCount, stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDispatch(commandBuffer commandBuffer, groupCountX groupCountX, groupCountY groupCountY, groupCountZ groupCountZ);
        private readonly VulkanCmdDispatch vkCmdDispatch;
        
        public void CmdDispatch(commandBuffer commandBuffer, groupCountX groupCountX, groupCountY groupCountY, groupCountZ groupCountZ) =>
            this.vkCmdDispatch.Invoke(commandBuffer, groupCountX, groupCountY, groupCountZ);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDispatchIndirect(commandBuffer commandBuffer, buffer buffer, offset offset);
        private readonly VulkanCmdDispatchIndirect vkCmdDispatchIndirect;
        
        public void CmdDispatchIndirect(commandBuffer commandBuffer, buffer buffer, offset offset) =>
            this.vkCmdDispatchIndirect.Invoke(commandBuffer, buffer, offset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyBuffer(commandBuffer commandBuffer, srcBuffer srcBuffer, dstBuffer dstBuffer, regionCount regionCount, /*const*/ pRegions* pRegions);
        private readonly VulkanCmdCopyBuffer vkCmdCopyBuffer;
        
        public unsafe void CmdCopyBuffer(commandBuffer commandBuffer, srcBuffer srcBuffer, dstBuffer dstBuffer, regionCount regionCount, /*const*/ pRegions* pRegions) =>
            this.vkCmdCopyBuffer.Invoke(commandBuffer, srcBuffer, dstBuffer, regionCount, pRegions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions);
        private readonly VulkanCmdCopyImage vkCmdCopyImage;
        
        public unsafe void CmdCopyImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions) =>
            this.vkCmdCopyImage.Invoke(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBlitImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions, filter filter);
        private readonly VulkanCmdBlitImage vkCmdBlitImage;
        
        public unsafe void CmdBlitImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions, filter filter) =>
            this.vkCmdBlitImage.Invoke(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions, filter);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyBufferToImage(commandBuffer commandBuffer, srcBuffer srcBuffer, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions);
        private readonly VulkanCmdCopyBufferToImage vkCmdCopyBufferToImage;
        
        public unsafe void CmdCopyBufferToImage(commandBuffer commandBuffer, srcBuffer srcBuffer, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions) =>
            this.vkCmdCopyBufferToImage.Invoke(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, pRegions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyImageToBuffer(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstBuffer dstBuffer, regionCount regionCount, /*const*/ pRegions* pRegions);
        private readonly VulkanCmdCopyImageToBuffer vkCmdCopyImageToBuffer;
        
        public unsafe void CmdCopyImageToBuffer(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstBuffer dstBuffer, regionCount regionCount, /*const*/ pRegions* pRegions) =>
            this.vkCmdCopyImageToBuffer.Invoke(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, pRegions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdUpdateBuffer(commandBuffer commandBuffer, dstBuffer dstBuffer, dstOffset dstOffset, dataSize dataSize, /*const*/ pData* pData);
        private readonly VulkanCmdUpdateBuffer vkCmdUpdateBuffer;
        
        public unsafe void CmdUpdateBuffer(commandBuffer commandBuffer, dstBuffer dstBuffer, dstOffset dstOffset, dataSize dataSize, /*const*/ pData* pData) =>
            this.vkCmdUpdateBuffer.Invoke(commandBuffer, dstBuffer, dstOffset, dataSize, pData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdFillBuffer(commandBuffer commandBuffer, dstBuffer dstBuffer, dstOffset dstOffset, size size, data data);
        private readonly VulkanCmdFillBuffer vkCmdFillBuffer;
        
        public void CmdFillBuffer(commandBuffer commandBuffer, dstBuffer dstBuffer, dstOffset dstOffset, size size, data data) =>
            this.vkCmdFillBuffer.Invoke(commandBuffer, dstBuffer, dstOffset, size, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdClearColorImage(commandBuffer commandBuffer, image image, imageLayout imageLayout, /*const*/ pColor* pColor, rangeCount rangeCount, /*const*/ pRanges* pRanges);
        private readonly VulkanCmdClearColorImage vkCmdClearColorImage;
        
        public unsafe void CmdClearColorImage(commandBuffer commandBuffer, image image, imageLayout imageLayout, /*const*/ pColor* pColor, rangeCount rangeCount, /*const*/ pRanges* pRanges) =>
            this.vkCmdClearColorImage.Invoke(commandBuffer, image, imageLayout, pColor, rangeCount, pRanges);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdClearDepthStencilImage(commandBuffer commandBuffer, image image, imageLayout imageLayout, /*const*/ pDepthStencil* pDepthStencil, rangeCount rangeCount, /*const*/ pRanges* pRanges);
        private readonly VulkanCmdClearDepthStencilImage vkCmdClearDepthStencilImage;
        
        public unsafe void CmdClearDepthStencilImage(commandBuffer commandBuffer, image image, imageLayout imageLayout, /*const*/ pDepthStencil* pDepthStencil, rangeCount rangeCount, /*const*/ pRanges* pRanges) =>
            this.vkCmdClearDepthStencilImage.Invoke(commandBuffer, image, imageLayout, pDepthStencil, rangeCount, pRanges);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdClearAttachments(commandBuffer commandBuffer, attachmentCount attachmentCount, /*const*/ pAttachments* pAttachments, rectCount rectCount, /*const*/ pRects* pRects);
        private readonly VulkanCmdClearAttachments vkCmdClearAttachments;
        
        public unsafe void CmdClearAttachments(commandBuffer commandBuffer, attachmentCount attachmentCount, /*const*/ pAttachments* pAttachments, rectCount rectCount, /*const*/ pRects* pRects) =>
            this.vkCmdClearAttachments.Invoke(commandBuffer, attachmentCount, pAttachments, rectCount, pRects);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdResolveImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions);
        private readonly VulkanCmdResolveImage vkCmdResolveImage;
        
        public unsafe void CmdResolveImage(commandBuffer commandBuffer, srcImage srcImage, srcImageLayout srcImageLayout, dstImage dstImage, dstImageLayout dstImageLayout, regionCount regionCount, /*const*/ pRegions* pRegions) =>
            this.vkCmdResolveImage.Invoke(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, pRegions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetEvent(commandBuffer commandBuffer, event @event, stageMask stageMask);
        private readonly VulkanCmdSetEvent vkCmdSetEvent;
        
        public void CmdSetEvent(commandBuffer commandBuffer, event @event, stageMask stageMask) =>
            this.vkCmdSetEvent.Invoke(commandBuffer, @event, stageMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdResetEvent(commandBuffer commandBuffer, event @event, stageMask stageMask);
        private readonly VulkanCmdResetEvent vkCmdResetEvent;
        
        public void CmdResetEvent(commandBuffer commandBuffer, event @event, stageMask stageMask) =>
            this.vkCmdResetEvent.Invoke(commandBuffer, @event, stageMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdWaitEvents(commandBuffer commandBuffer, eventCount eventCount, /*const*/ pEvents* pEvents, srcStageMask srcStageMask, dstStageMask dstStageMask, memoryBarrierCount memoryBarrierCount, /*const*/ pMemoryBarriers* pMemoryBarriers, bufferMemoryBarrierCount bufferMemoryBarrierCount, /*const*/ pBufferMemoryBarriers* pBufferMemoryBarriers, imageMemoryBarrierCount imageMemoryBarrierCount, /*const*/ pImageMemoryBarriers* pImageMemoryBarriers);
        private readonly VulkanCmdWaitEvents vkCmdWaitEvents;
        
        public unsafe void CmdWaitEvents(commandBuffer commandBuffer, eventCount eventCount, /*const*/ pEvents* pEvents, srcStageMask srcStageMask, dstStageMask dstStageMask, memoryBarrierCount memoryBarrierCount, /*const*/ pMemoryBarriers* pMemoryBarriers, bufferMemoryBarrierCount bufferMemoryBarrierCount, /*const*/ pBufferMemoryBarriers* pBufferMemoryBarriers, imageMemoryBarrierCount imageMemoryBarrierCount, /*const*/ pImageMemoryBarriers* pImageMemoryBarriers) =>
            this.vkCmdWaitEvents.Invoke(commandBuffer, eventCount, pEvents, srcStageMask, dstStageMask, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdPipelineBarrier(commandBuffer commandBuffer, srcStageMask srcStageMask, dstStageMask dstStageMask, dependencyFlags dependencyFlags, memoryBarrierCount memoryBarrierCount, /*const*/ pMemoryBarriers* pMemoryBarriers, bufferMemoryBarrierCount bufferMemoryBarrierCount, /*const*/ pBufferMemoryBarriers* pBufferMemoryBarriers, imageMemoryBarrierCount imageMemoryBarrierCount, /*const*/ pImageMemoryBarriers* pImageMemoryBarriers);
        private readonly VulkanCmdPipelineBarrier vkCmdPipelineBarrier;
        
        public unsafe void CmdPipelineBarrier(commandBuffer commandBuffer, srcStageMask srcStageMask, dstStageMask dstStageMask, dependencyFlags dependencyFlags, memoryBarrierCount memoryBarrierCount, /*const*/ pMemoryBarriers* pMemoryBarriers, bufferMemoryBarrierCount bufferMemoryBarrierCount, /*const*/ pBufferMemoryBarriers* pBufferMemoryBarriers, imageMemoryBarrierCount imageMemoryBarrierCount, /*const*/ pImageMemoryBarriers* pImageMemoryBarriers) =>
            this.vkCmdPipelineBarrier.Invoke(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, pMemoryBarriers, bufferMemoryBarrierCount, pBufferMemoryBarriers, imageMemoryBarrierCount, pImageMemoryBarriers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdBeginQuery(commandBuffer commandBuffer, queryPool queryPool, query query, flags flags);
        private readonly VulkanCmdBeginQuery vkCmdBeginQuery;
        
        public void CmdBeginQuery(commandBuffer commandBuffer, queryPool queryPool, query query, flags flags) =>
            this.vkCmdBeginQuery.Invoke(commandBuffer, queryPool, query, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdEndQuery(commandBuffer commandBuffer, queryPool queryPool, query query);
        private readonly VulkanCmdEndQuery vkCmdEndQuery;
        
        public void CmdEndQuery(commandBuffer commandBuffer, queryPool queryPool, query query) =>
            this.vkCmdEndQuery.Invoke(commandBuffer, queryPool, query);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdResetQueryPool(commandBuffer commandBuffer, queryPool queryPool, firstQuery firstQuery, queryCount queryCount);
        private readonly VulkanCmdResetQueryPool vkCmdResetQueryPool;
        
        public void CmdResetQueryPool(commandBuffer commandBuffer, queryPool queryPool, firstQuery firstQuery, queryCount queryCount) =>
            this.vkCmdResetQueryPool.Invoke(commandBuffer, queryPool, firstQuery, queryCount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdWriteTimestamp(commandBuffer commandBuffer, pipelineStage pipelineStage, queryPool queryPool, query query);
        private readonly VulkanCmdWriteTimestamp vkCmdWriteTimestamp;
        
        public void CmdWriteTimestamp(commandBuffer commandBuffer, pipelineStage pipelineStage, queryPool queryPool, query query) =>
            this.vkCmdWriteTimestamp.Invoke(commandBuffer, pipelineStage, queryPool, query);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdCopyQueryPoolResults(commandBuffer commandBuffer, queryPool queryPool, firstQuery firstQuery, queryCount queryCount, dstBuffer dstBuffer, dstOffset dstOffset, stride stride, flags flags);
        private readonly VulkanCmdCopyQueryPoolResults vkCmdCopyQueryPoolResults;
        
        public void CmdCopyQueryPoolResults(commandBuffer commandBuffer, queryPool queryPool, firstQuery firstQuery, queryCount queryCount, dstBuffer dstBuffer, dstOffset dstOffset, stride stride, flags flags) =>
            this.vkCmdCopyQueryPoolResults.Invoke(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdPushConstants(commandBuffer commandBuffer, layout layout, stageFlags stageFlags, offset offset, size size, /*const*/ pValues* pValues);
        private readonly VulkanCmdPushConstants vkCmdPushConstants;
        
        public unsafe void CmdPushConstants(commandBuffer commandBuffer, layout layout, stageFlags stageFlags, offset offset, size size, /*const*/ pValues* pValues) =>
            this.vkCmdPushConstants.Invoke(commandBuffer, layout, stageFlags, offset, size, pValues);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBeginRenderPass(commandBuffer commandBuffer, /*const*/ pRenderPassBegin* pRenderPassBegin, contents contents);
        private readonly VulkanCmdBeginRenderPass vkCmdBeginRenderPass;
        
        public unsafe void CmdBeginRenderPass(commandBuffer commandBuffer, /*const*/ pRenderPassBegin* pRenderPassBegin, contents contents) =>
            this.vkCmdBeginRenderPass.Invoke(commandBuffer, pRenderPassBegin, contents);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdNextSubpass(commandBuffer commandBuffer, contents contents);
        private readonly VulkanCmdNextSubpass vkCmdNextSubpass;
        
        public void CmdNextSubpass(commandBuffer commandBuffer, contents contents) =>
            this.vkCmdNextSubpass.Invoke(commandBuffer, contents);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdEndRenderPass(commandBuffer commandBuffer);
        private readonly VulkanCmdEndRenderPass vkCmdEndRenderPass;
        
        public void CmdEndRenderPass(commandBuffer commandBuffer) =>
            this.vkCmdEndRenderPass.Invoke(commandBuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdExecuteCommands(commandBuffer commandBuffer, commandBufferCount commandBufferCount, /*const*/ pCommandBuffers* pCommandBuffers);
        private readonly VulkanCmdExecuteCommands vkCmdExecuteCommands;
        
        public unsafe void CmdExecuteCommands(commandBuffer commandBuffer, commandBufferCount commandBufferCount, /*const*/ pCommandBuffers* pCommandBuffers) =>
            this.vkCmdExecuteCommands.Invoke(commandBuffer, commandBufferCount, pCommandBuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroySurfaceKHR(instance instance, surface surface, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroySurfaceKHR vkDestroySurfaceKHR;
        
        [VulkanExtension("VK_KHR_surface")]
        public unsafe void DestroySurfaceKHR(instance instance, surface surface, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroySurfaceKHR.Invoke(instance, surface, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfaceSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, surface surface, pSupported* pSupported);
        private readonly VulkanGetPhysicalDeviceSurfaceSupportKHR vkGetPhysicalDeviceSurfaceSupportKHR;
        
        [VulkanExtension("VK_KHR_surface")]
        public unsafe VkResult GetPhysicalDeviceSurfaceSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, surface surface, pSupported* pSupported) =>
            this.vkGetPhysicalDeviceSurfaceSupportKHR.Invoke(physicalDevice, queueFamilyIndex, surface, pSupported);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice physicalDevice, surface surface, pSurfaceCapabilities* pSurfaceCapabilities);
        private readonly VulkanGetPhysicalDeviceSurfaceCapabilitiesKHR vkGetPhysicalDeviceSurfaceCapabilitiesKHR;
        
        [VulkanExtension("VK_KHR_surface")]
        public unsafe VkResult GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice physicalDevice, surface surface, pSurfaceCapabilities* pSurfaceCapabilities) =>
            this.vkGetPhysicalDeviceSurfaceCapabilitiesKHR.Invoke(physicalDevice, surface, pSurfaceCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice physicalDevice, surface surface, pSurfaceFormatCount* pSurfaceFormatCount, pSurfaceFormats* pSurfaceFormats);
        private readonly VulkanGetPhysicalDeviceSurfaceFormatsKHR vkGetPhysicalDeviceSurfaceFormatsKHR;
        
        [VulkanExtension("VK_KHR_surface")]
        public unsafe VkResult GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice physicalDevice, surface surface, pSurfaceFormatCount* pSurfaceFormatCount, pSurfaceFormats* pSurfaceFormats) =>
            this.vkGetPhysicalDeviceSurfaceFormatsKHR.Invoke(physicalDevice, surface, pSurfaceFormatCount, pSurfaceFormats);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice physicalDevice, surface surface, pPresentModeCount* pPresentModeCount, pPresentModes* pPresentModes);
        private readonly VulkanGetPhysicalDeviceSurfacePresentModesKHR vkGetPhysicalDeviceSurfacePresentModesKHR;
        
        [VulkanExtension("VK_KHR_surface")]
        public unsafe VkResult GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice physicalDevice, surface surface, pPresentModeCount* pPresentModeCount, pPresentModes* pPresentModes) =>
            this.vkGetPhysicalDeviceSurfacePresentModesKHR.Invoke(physicalDevice, surface, pPresentModeCount, pPresentModes);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateSwapchainKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSwapchain* pSwapchain);
        private readonly VulkanCreateSwapchainKHR vkCreateSwapchainKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult CreateSwapchainKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSwapchain* pSwapchain) =>
            this.vkCreateSwapchainKHR.Invoke(device, pCreateInfo, pCreateInfo, pAllocator, pSwapchain);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetSwapchainImagesKHR(device device, swapchain swapchain, pSwapchainImageCount* pSwapchainImageCount, pSwapchainImages* pSwapchainImages);
        private readonly VulkanGetSwapchainImagesKHR vkGetSwapchainImagesKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult GetSwapchainImagesKHR(device device, swapchain swapchain, pSwapchainImageCount* pSwapchainImageCount, pSwapchainImages* pSwapchainImages) =>
            this.vkGetSwapchainImagesKHR.Invoke(device, swapchain, pSwapchainImageCount, pSwapchainImages);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAcquireNextImageKHR(device device, swapchain swapchain, timeout timeout, semaphore semaphore, fence fence, pImageIndex* pImageIndex);
        private readonly VulkanAcquireNextImageKHR vkAcquireNextImageKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult AcquireNextImageKHR(device device, swapchain swapchain, timeout timeout, semaphore semaphore, fence fence, pImageIndex* pImageIndex) =>
            this.vkAcquireNextImageKHR.Invoke(device, swapchain, timeout, semaphore, fence, pImageIndex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanQueuePresentKHR(queue queue, /*const*/ pPresentInfo* pPresentInfo);
        private readonly VulkanQueuePresentKHR vkQueuePresentKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult QueuePresentKHR(queue queue, /*const*/ pPresentInfo* pPresentInfo) =>
            this.vkQueuePresentKHR.Invoke(queue, pPresentInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDeviceGroupPresentCapabilitiesKHR(device device, pDeviceGroupPresentCapabilities* pDeviceGroupPresentCapabilities);
        private readonly VulkanGetDeviceGroupPresentCapabilitiesKHR vkGetDeviceGroupPresentCapabilitiesKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult GetDeviceGroupPresentCapabilitiesKHR(device device, pDeviceGroupPresentCapabilities* pDeviceGroupPresentCapabilities) =>
            this.vkGetDeviceGroupPresentCapabilitiesKHR.Invoke(device, pDeviceGroupPresentCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDeviceGroupSurfacePresentModesKHR(device device, surface surface, pModes* pModes);
        private readonly VulkanGetDeviceGroupSurfacePresentModesKHR vkGetDeviceGroupSurfacePresentModesKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult GetDeviceGroupSurfacePresentModesKHR(device device, surface surface, pModes* pModes) =>
            this.vkGetDeviceGroupSurfacePresentModesKHR.Invoke(device, surface, pModes);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDevicePresentRectanglesKHR(physicalDevice physicalDevice, surface surface, pRectCount* pRectCount, pRects* pRects);
        private readonly VulkanGetPhysicalDevicePresentRectanglesKHR vkGetPhysicalDevicePresentRectanglesKHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult GetPhysicalDevicePresentRectanglesKHR(physicalDevice physicalDevice, surface surface, pRectCount* pRectCount, pRects* pRects) =>
            this.vkGetPhysicalDevicePresentRectanglesKHR.Invoke(physicalDevice, surface, pRectCount, pRects);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAcquireNextImage2KHR(device device, /*const*/ pAcquireInfo* pAcquireInfo, pImageIndex* pImageIndex);
        private readonly VulkanAcquireNextImage2KHR vkAcquireNextImage2KHR;
        
        [VulkanExtension("VK_KHR_swapchain")]
        public unsafe VkResult AcquireNextImage2KHR(device device, /*const*/ pAcquireInfo* pAcquireInfo, pImageIndex* pImageIndex) =>
            this.vkAcquireNextImage2KHR.Invoke(device, pAcquireInfo, pImageIndex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceDisplayPropertiesKHR vkGetPhysicalDeviceDisplayPropertiesKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceDisplayPropertiesKHR.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceDisplayPlanePropertiesKHR vkGetPhysicalDeviceDisplayPlanePropertiesKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceDisplayPlanePropertiesKHR.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDisplayPlaneSupportedDisplaysKHR(physicalDevice physicalDevice, planeIndex planeIndex, pDisplayCount* pDisplayCount, pDisplays* pDisplays);
        private readonly VulkanGetDisplayPlaneSupportedDisplaysKHR vkGetDisplayPlaneSupportedDisplaysKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult GetDisplayPlaneSupportedDisplaysKHR(physicalDevice physicalDevice, planeIndex planeIndex, pDisplayCount* pDisplayCount, pDisplays* pDisplays) =>
            this.vkGetDisplayPlaneSupportedDisplaysKHR.Invoke(physicalDevice, planeIndex, pDisplayCount, pDisplays);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDisplayModePropertiesKHR(physicalDevice physicalDevice, display display, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetDisplayModePropertiesKHR vkGetDisplayModePropertiesKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult GetDisplayModePropertiesKHR(physicalDevice physicalDevice, display display, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetDisplayModePropertiesKHR.Invoke(physicalDevice, display, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDisplayModeKHR(physicalDevice physicalDevice, display display, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pMode* pMode);
        private readonly VulkanCreateDisplayModeKHR vkCreateDisplayModeKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult CreateDisplayModeKHR(physicalDevice physicalDevice, display display, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pMode* pMode) =>
            this.vkCreateDisplayModeKHR.Invoke(physicalDevice, display, pCreateInfo, pAllocator, pMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDisplayPlaneCapabilitiesKHR(physicalDevice physicalDevice, mode mode, planeIndex planeIndex, pCapabilities* pCapabilities);
        private readonly VulkanGetDisplayPlaneCapabilitiesKHR vkGetDisplayPlaneCapabilitiesKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult GetDisplayPlaneCapabilitiesKHR(physicalDevice physicalDevice, mode mode, planeIndex planeIndex, pCapabilities* pCapabilities) =>
            this.vkGetDisplayPlaneCapabilitiesKHR.Invoke(physicalDevice, mode, planeIndex, pCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDisplayPlaneSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateDisplayPlaneSurfaceKHR vkCreateDisplayPlaneSurfaceKHR;
        
        [VulkanExtension("VK_KHR_display")]
        public unsafe VkResult CreateDisplayPlaneSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateDisplayPlaneSurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateSharedSwapchainsKHR(device device, swapchainCount swapchainCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pSwapchains* pSwapchains);
        private readonly VulkanCreateSharedSwapchainsKHR vkCreateSharedSwapchainsKHR;
        
        [VulkanExtension("VK_KHR_display_swapchain")]
        public unsafe VkResult CreateSharedSwapchainsKHR(device device, swapchainCount swapchainCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pSwapchains* pSwapchains) =>
            this.vkCreateSharedSwapchainsKHR.Invoke(device, swapchainCount, pCreateInfos, pCreateInfos, pAllocator, pSwapchains);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateXlibSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateXlibSurfaceKHR vkCreateXlibSurfaceKHR;
        
        [VulkanExtension("VK_KHR_xlib_surface")]
        public unsafe VkResult CreateXlibSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateXlibSurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkBool32 VulkanGetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, dpy* dpy, visualID visualID);
        private readonly VulkanGetPhysicalDeviceXlibPresentationSupportKHR vkGetPhysicalDeviceXlibPresentationSupportKHR;
        
        [VulkanExtension("VK_KHR_xlib_surface")]
        public unsafe VkBool32 GetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, dpy* dpy, visualID visualID) =>
            this.vkGetPhysicalDeviceXlibPresentationSupportKHR.Invoke(physicalDevice, queueFamilyIndex, dpy, visualID);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateXcbSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateXcbSurfaceKHR vkCreateXcbSurfaceKHR;
        
        [VulkanExtension("VK_KHR_xcb_surface")]
        public unsafe VkResult CreateXcbSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateXcbSurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkBool32 VulkanGetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, connection* connection, visual_id visual_id);
        private readonly VulkanGetPhysicalDeviceXcbPresentationSupportKHR vkGetPhysicalDeviceXcbPresentationSupportKHR;
        
        [VulkanExtension("VK_KHR_xcb_surface")]
        public unsafe VkBool32 GetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, connection* connection, visual_id visual_id) =>
            this.vkGetPhysicalDeviceXcbPresentationSupportKHR.Invoke(physicalDevice, queueFamilyIndex, connection, visual_id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateWaylandSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateWaylandSurfaceKHR vkCreateWaylandSurfaceKHR;
        
        [VulkanExtension("VK_KHR_wayland_surface")]
        public unsafe VkResult CreateWaylandSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateWaylandSurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkBool32 VulkanGetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, display* display);
        private readonly VulkanGetPhysicalDeviceWaylandPresentationSupportKHR vkGetPhysicalDeviceWaylandPresentationSupportKHR;
        
        [VulkanExtension("VK_KHR_wayland_surface")]
        public unsafe VkBool32 GetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, display* display) =>
            this.vkGetPhysicalDeviceWaylandPresentationSupportKHR.Invoke(physicalDevice, queueFamilyIndex, display);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateAndroidSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateAndroidSurfaceKHR vkCreateAndroidSurfaceKHR;
        
        [VulkanExtension("VK_KHR_android_surface")]
        public unsafe VkResult CreateAndroidSurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateAndroidSurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateWin32SurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface);
        private readonly VulkanCreateWin32SurfaceKHR vkCreateWin32SurfaceKHR;
        
        [VulkanExtension("VK_KHR_win32_surface")]
        public unsafe VkResult CreateWin32SurfaceKHR(instance instance, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pSurface* pSurface) =>
            this.vkCreateWin32SurfaceKHR.Invoke(instance, pCreateInfo, pAllocator, pSurface);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkBool32 VulkanGetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex);
        private readonly VulkanGetPhysicalDeviceWin32PresentationSupportKHR vkGetPhysicalDeviceWin32PresentationSupportKHR;
        
        [VulkanExtension("VK_KHR_win32_surface")]
        public VkBool32 GetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex) =>
            this.vkGetPhysicalDeviceWin32PresentationSupportKHR.Invoke(physicalDevice, queueFamilyIndex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceVideoCapabilitiesKHR(physicalDevice physicalDevice, /*const*/ pVideoProfile* pVideoProfile, pCapabilities* pCapabilities);
        private readonly VulkanGetPhysicalDeviceVideoCapabilitiesKHR vkGetPhysicalDeviceVideoCapabilitiesKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult GetPhysicalDeviceVideoCapabilitiesKHR(physicalDevice physicalDevice, /*const*/ pVideoProfile* pVideoProfile, pCapabilities* pCapabilities) =>
            this.vkGetPhysicalDeviceVideoCapabilitiesKHR.Invoke(physicalDevice, pVideoProfile, pCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceVideoFormatPropertiesKHR(physicalDevice physicalDevice, /*const*/ pVideoFormatInfo* pVideoFormatInfo, pVideoFormatPropertyCount* pVideoFormatPropertyCount, pVideoFormatProperties* pVideoFormatProperties);
        private readonly VulkanGetPhysicalDeviceVideoFormatPropertiesKHR vkGetPhysicalDeviceVideoFormatPropertiesKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult GetPhysicalDeviceVideoFormatPropertiesKHR(physicalDevice physicalDevice, /*const*/ pVideoFormatInfo* pVideoFormatInfo, pVideoFormatPropertyCount* pVideoFormatPropertyCount, pVideoFormatProperties* pVideoFormatProperties) =>
            this.vkGetPhysicalDeviceVideoFormatPropertiesKHR.Invoke(physicalDevice, pVideoFormatInfo, pVideoFormatPropertyCount, pVideoFormatProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateVideoSessionKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pVideoSession* pVideoSession);
        private readonly VulkanCreateVideoSessionKHR vkCreateVideoSessionKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult CreateVideoSessionKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pVideoSession* pVideoSession) =>
            this.vkCreateVideoSessionKHR.Invoke(device, pCreateInfo, pAllocator, pVideoSession);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyVideoSessionKHR(device device, videoSession videoSession, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyVideoSessionKHR vkDestroyVideoSessionKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe void DestroyVideoSessionKHR(device device, videoSession videoSession, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyVideoSessionKHR.Invoke(device, videoSession, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetVideoSessionMemoryRequirementsKHR(device device, videoSession videoSession, pMemoryRequirementsCount* pMemoryRequirementsCount, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetVideoSessionMemoryRequirementsKHR vkGetVideoSessionMemoryRequirementsKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult GetVideoSessionMemoryRequirementsKHR(device device, videoSession videoSession, pMemoryRequirementsCount* pMemoryRequirementsCount, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetVideoSessionMemoryRequirementsKHR.Invoke(device, videoSession, pMemoryRequirementsCount, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanBindVideoSessionMemoryKHR(device device, videoSession videoSession, bindSessionMemoryInfoCount bindSessionMemoryInfoCount, /*const*/ pBindSessionMemoryInfos* pBindSessionMemoryInfos);
        private readonly VulkanBindVideoSessionMemoryKHR vkBindVideoSessionMemoryKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult BindVideoSessionMemoryKHR(device device, videoSession videoSession, bindSessionMemoryInfoCount bindSessionMemoryInfoCount, /*const*/ pBindSessionMemoryInfos* pBindSessionMemoryInfos) =>
            this.vkBindVideoSessionMemoryKHR.Invoke(device, videoSession, bindSessionMemoryInfoCount, pBindSessionMemoryInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateVideoSessionParametersKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pVideoSessionParameters* pVideoSessionParameters);
        private readonly VulkanCreateVideoSessionParametersKHR vkCreateVideoSessionParametersKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult CreateVideoSessionParametersKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pVideoSessionParameters* pVideoSessionParameters) =>
            this.vkCreateVideoSessionParametersKHR.Invoke(device, pCreateInfo, pAllocator, pVideoSessionParameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanUpdateVideoSessionParametersKHR(device device, videoSessionParameters videoSessionParameters, /*const*/ pUpdateInfo* pUpdateInfo);
        private readonly VulkanUpdateVideoSessionParametersKHR vkUpdateVideoSessionParametersKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe VkResult UpdateVideoSessionParametersKHR(device device, videoSessionParameters videoSessionParameters, /*const*/ pUpdateInfo* pUpdateInfo) =>
            this.vkUpdateVideoSessionParametersKHR.Invoke(device, videoSessionParameters, pUpdateInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyVideoSessionParametersKHR(device device, videoSessionParameters videoSessionParameters, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyVideoSessionParametersKHR vkDestroyVideoSessionParametersKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe void DestroyVideoSessionParametersKHR(device device, videoSessionParameters videoSessionParameters, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyVideoSessionParametersKHR.Invoke(device, videoSessionParameters, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBeginVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pBeginInfo* pBeginInfo);
        private readonly VulkanCmdBeginVideoCodingKHR vkCmdBeginVideoCodingKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe void CmdBeginVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pBeginInfo* pBeginInfo) =>
            this.vkCmdBeginVideoCodingKHR.Invoke(commandBuffer, pBeginInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdEndVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pEndCodingInfo* pEndCodingInfo);
        private readonly VulkanCmdEndVideoCodingKHR vkCmdEndVideoCodingKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe void CmdEndVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pEndCodingInfo* pEndCodingInfo) =>
            this.vkCmdEndVideoCodingKHR.Invoke(commandBuffer, pEndCodingInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdControlVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pCodingControlInfo* pCodingControlInfo);
        private readonly VulkanCmdControlVideoCodingKHR vkCmdControlVideoCodingKHR;
        
        [VulkanExtension("VK_KHR_video_queue")]
        public unsafe void CmdControlVideoCodingKHR(commandBuffer commandBuffer, /*const*/ pCodingControlInfo* pCodingControlInfo) =>
            this.vkCmdControlVideoCodingKHR.Invoke(commandBuffer, pCodingControlInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdDecodeVideoKHR(commandBuffer commandBuffer, /*const*/ pDecodeInfo* pDecodeInfo);
        private readonly VulkanCmdDecodeVideoKHR vkCmdDecodeVideoKHR;
        
        [VulkanExtension("VK_KHR_video_decode_queue")]
        public unsafe void CmdDecodeVideoKHR(commandBuffer commandBuffer, /*const*/ pDecodeInfo* pDecodeInfo) =>
            this.vkCmdDecodeVideoKHR.Invoke(commandBuffer, pDecodeInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetMemoryWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle);
        private readonly VulkanGetMemoryWin32HandleKHR vkGetMemoryWin32HandleKHR;
        
        [VulkanExtension("VK_KHR_external_memory_win32")]
        public unsafe VkResult GetMemoryWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle) =>
            this.vkGetMemoryWin32HandleKHR.Invoke(device, pGetWin32HandleInfo, pHandle);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetMemoryWin32HandlePropertiesKHR(device device, handleType handleType, handle handle, pMemoryWin32HandleProperties* pMemoryWin32HandleProperties);
        private readonly VulkanGetMemoryWin32HandlePropertiesKHR vkGetMemoryWin32HandlePropertiesKHR;
        
        [VulkanExtension("VK_KHR_external_memory_win32")]
        public unsafe VkResult GetMemoryWin32HandlePropertiesKHR(device device, handleType handleType, handle handle, pMemoryWin32HandleProperties* pMemoryWin32HandleProperties) =>
            this.vkGetMemoryWin32HandlePropertiesKHR.Invoke(device, handleType, handle, pMemoryWin32HandleProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetMemoryFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd);
        private readonly VulkanGetMemoryFdKHR vkGetMemoryFdKHR;
        
        [VulkanExtension("VK_KHR_external_memory_fd")]
        public unsafe VkResult GetMemoryFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd) =>
            this.vkGetMemoryFdKHR.Invoke(device, pGetFdInfo, pFd);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetMemoryFdPropertiesKHR(device device, handleType handleType, fd fd, pMemoryFdProperties* pMemoryFdProperties);
        private readonly VulkanGetMemoryFdPropertiesKHR vkGetMemoryFdPropertiesKHR;
        
        [VulkanExtension("VK_KHR_external_memory_fd")]
        public unsafe VkResult GetMemoryFdPropertiesKHR(device device, handleType handleType, fd fd, pMemoryFdProperties* pMemoryFdProperties) =>
            this.vkGetMemoryFdPropertiesKHR.Invoke(device, handleType, fd, pMemoryFdProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanImportSemaphoreWin32HandleKHR(device device, /*const*/ pImportSemaphoreWin32HandleInfo* pImportSemaphoreWin32HandleInfo);
        private readonly VulkanImportSemaphoreWin32HandleKHR vkImportSemaphoreWin32HandleKHR;
        
        [VulkanExtension("VK_KHR_external_semaphore_win32")]
        public unsafe VkResult ImportSemaphoreWin32HandleKHR(device device, /*const*/ pImportSemaphoreWin32HandleInfo* pImportSemaphoreWin32HandleInfo) =>
            this.vkImportSemaphoreWin32HandleKHR.Invoke(device, pImportSemaphoreWin32HandleInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetSemaphoreWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle);
        private readonly VulkanGetSemaphoreWin32HandleKHR vkGetSemaphoreWin32HandleKHR;
        
        [VulkanExtension("VK_KHR_external_semaphore_win32")]
        public unsafe VkResult GetSemaphoreWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle) =>
            this.vkGetSemaphoreWin32HandleKHR.Invoke(device, pGetWin32HandleInfo, pHandle);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanImportSemaphoreFdKHR(device device, /*const*/ pImportSemaphoreFdInfo* pImportSemaphoreFdInfo);
        private readonly VulkanImportSemaphoreFdKHR vkImportSemaphoreFdKHR;
        
        [VulkanExtension("VK_KHR_external_semaphore_fd")]
        public unsafe VkResult ImportSemaphoreFdKHR(device device, /*const*/ pImportSemaphoreFdInfo* pImportSemaphoreFdInfo) =>
            this.vkImportSemaphoreFdKHR.Invoke(device, pImportSemaphoreFdInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetSemaphoreFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd);
        private readonly VulkanGetSemaphoreFdKHR vkGetSemaphoreFdKHR;
        
        [VulkanExtension("VK_KHR_external_semaphore_fd")]
        public unsafe VkResult GetSemaphoreFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd) =>
            this.vkGetSemaphoreFdKHR.Invoke(device, pGetFdInfo, pFd);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdPushDescriptorSetKHR(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, layout layout, set set, descriptorWriteCount descriptorWriteCount, /*const*/ pDescriptorWrites* pDescriptorWrites);
        private readonly VulkanCmdPushDescriptorSetKHR vkCmdPushDescriptorSetKHR;
        
        [VulkanExtension("VK_KHR_push_descriptor")]
        public unsafe void CmdPushDescriptorSetKHR(commandBuffer commandBuffer, pipelineBindPoint pipelineBindPoint, layout layout, set set, descriptorWriteCount descriptorWriteCount, /*const*/ pDescriptorWrites* pDescriptorWrites) =>
            this.vkCmdPushDescriptorSetKHR.Invoke(commandBuffer, pipelineBindPoint, layout, set, descriptorWriteCount, pDescriptorWrites);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdPushDescriptorSetWithTemplateKHR(commandBuffer commandBuffer, descriptorUpdateTemplate descriptorUpdateTemplate, layout layout, set set, /*const*/ pData* pData);
        private readonly VulkanCmdPushDescriptorSetWithTemplateKHR vkCmdPushDescriptorSetWithTemplateKHR;
        
        [VulkanExtension("VK_KHR_push_descriptor")]
        public unsafe void CmdPushDescriptorSetWithTemplateKHR(commandBuffer commandBuffer, descriptorUpdateTemplate descriptorUpdateTemplate, layout layout, set set, /*const*/ pData* pData) =>
            this.vkCmdPushDescriptorSetWithTemplateKHR.Invoke(commandBuffer, descriptorUpdateTemplate, layout, set, pData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanGetSwapchainStatusKHR(device device, swapchain swapchain);
        private readonly VulkanGetSwapchainStatusKHR vkGetSwapchainStatusKHR;
        
        [VulkanExtension("VK_KHR_shared_presentable_image")]
        public VkResult GetSwapchainStatusKHR(device device, swapchain swapchain) =>
            this.vkGetSwapchainStatusKHR.Invoke(device, swapchain);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanImportFenceWin32HandleKHR(device device, /*const*/ pImportFenceWin32HandleInfo* pImportFenceWin32HandleInfo);
        private readonly VulkanImportFenceWin32HandleKHR vkImportFenceWin32HandleKHR;
        
        [VulkanExtension("VK_KHR_external_fence_win32")]
        public unsafe VkResult ImportFenceWin32HandleKHR(device device, /*const*/ pImportFenceWin32HandleInfo* pImportFenceWin32HandleInfo) =>
            this.vkImportFenceWin32HandleKHR.Invoke(device, pImportFenceWin32HandleInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetFenceWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle);
        private readonly VulkanGetFenceWin32HandleKHR vkGetFenceWin32HandleKHR;
        
        [VulkanExtension("VK_KHR_external_fence_win32")]
        public unsafe VkResult GetFenceWin32HandleKHR(device device, /*const*/ pGetWin32HandleInfo* pGetWin32HandleInfo, pHandle* pHandle) =>
            this.vkGetFenceWin32HandleKHR.Invoke(device, pGetWin32HandleInfo, pHandle);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanImportFenceFdKHR(device device, /*const*/ pImportFenceFdInfo* pImportFenceFdInfo);
        private readonly VulkanImportFenceFdKHR vkImportFenceFdKHR;
        
        [VulkanExtension("VK_KHR_external_fence_fd")]
        public unsafe VkResult ImportFenceFdKHR(device device, /*const*/ pImportFenceFdInfo* pImportFenceFdInfo) =>
            this.vkImportFenceFdKHR.Invoke(device, pImportFenceFdInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetFenceFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd);
        private readonly VulkanGetFenceFdKHR vkGetFenceFdKHR;
        
        [VulkanExtension("VK_KHR_external_fence_fd")]
        public unsafe VkResult GetFenceFdKHR(device device, /*const*/ pGetFdInfo* pGetFdInfo, pFd* pFd) =>
            this.vkGetFenceFdKHR.Invoke(device, pGetFdInfo, pFd);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, pCounterCount* pCounterCount, pCounters* pCounters, pCounterDescriptions* pCounterDescriptions);
        private readonly VulkanEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR;
        
        [VulkanExtension("VK_KHR_performance_query")]
        public unsafe VkResult EnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR(physicalDevice physicalDevice, queueFamilyIndex queueFamilyIndex, pCounterCount* pCounterCount, pCounters* pCounters, pCounterDescriptions* pCounterDescriptions) =>
            this.vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR.Invoke(physicalDevice, queueFamilyIndex, pCounterCount, pCounters, pCounterDescriptions);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR(physicalDevice physicalDevice, /*const*/ pPerformanceQueryCreateInfo* pPerformanceQueryCreateInfo, pNumPasses* pNumPasses);
        private readonly VulkanGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR;
        
        [VulkanExtension("VK_KHR_performance_query")]
        public unsafe void GetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR(physicalDevice physicalDevice, /*const*/ pPerformanceQueryCreateInfo* pPerformanceQueryCreateInfo, pNumPasses* pNumPasses) =>
            this.vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR.Invoke(physicalDevice, pPerformanceQueryCreateInfo, pNumPasses);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanAcquireProfilingLockKHR(device device, /*const*/ pInfo* pInfo);
        private readonly VulkanAcquireProfilingLockKHR vkAcquireProfilingLockKHR;
        
        [VulkanExtension("VK_KHR_performance_query")]
        public unsafe VkResult AcquireProfilingLockKHR(device device, /*const*/ pInfo* pInfo) =>
            this.vkAcquireProfilingLockKHR.Invoke(device, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanReleaseProfilingLockKHR(device device);
        private readonly VulkanReleaseProfilingLockKHR vkReleaseProfilingLockKHR;
        
        [VulkanExtension("VK_KHR_performance_query")]
        public void ReleaseProfilingLockKHR(device device) =>
            this.vkReleaseProfilingLockKHR.Invoke(device);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfaceCapabilities2KHR(physicalDevice physicalDevice, /*const*/ pSurfaceInfo* pSurfaceInfo, pSurfaceCapabilities* pSurfaceCapabilities);
        private readonly VulkanGetPhysicalDeviceSurfaceCapabilities2KHR vkGetPhysicalDeviceSurfaceCapabilities2KHR;
        
        [VulkanExtension("VK_KHR_get_surface_capabilities2")]
        public unsafe VkResult GetPhysicalDeviceSurfaceCapabilities2KHR(physicalDevice physicalDevice, /*const*/ pSurfaceInfo* pSurfaceInfo, pSurfaceCapabilities* pSurfaceCapabilities) =>
            this.vkGetPhysicalDeviceSurfaceCapabilities2KHR.Invoke(physicalDevice, pSurfaceInfo, pSurfaceCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceSurfaceFormats2KHR(physicalDevice physicalDevice, /*const*/ pSurfaceInfo* pSurfaceInfo, pSurfaceFormatCount* pSurfaceFormatCount, pSurfaceFormats* pSurfaceFormats);
        private readonly VulkanGetPhysicalDeviceSurfaceFormats2KHR vkGetPhysicalDeviceSurfaceFormats2KHR;
        
        [VulkanExtension("VK_KHR_get_surface_capabilities2")]
        public unsafe VkResult GetPhysicalDeviceSurfaceFormats2KHR(physicalDevice physicalDevice, /*const*/ pSurfaceInfo* pSurfaceInfo, pSurfaceFormatCount* pSurfaceFormatCount, pSurfaceFormats* pSurfaceFormats) =>
            this.vkGetPhysicalDeviceSurfaceFormats2KHR.Invoke(physicalDevice, pSurfaceInfo, pSurfaceFormatCount, pSurfaceFormats);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceDisplayProperties2KHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceDisplayProperties2KHR vkGetPhysicalDeviceDisplayProperties2KHR;
        
        [VulkanExtension("VK_KHR_get_display_properties2")]
        public unsafe VkResult GetPhysicalDeviceDisplayProperties2KHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceDisplayProperties2KHR.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceDisplayPlaneProperties2KHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceDisplayPlaneProperties2KHR vkGetPhysicalDeviceDisplayPlaneProperties2KHR;
        
        [VulkanExtension("VK_KHR_get_display_properties2")]
        public unsafe VkResult GetPhysicalDeviceDisplayPlaneProperties2KHR(physicalDevice physicalDevice, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceDisplayPlaneProperties2KHR.Invoke(physicalDevice, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDisplayModeProperties2KHR(physicalDevice physicalDevice, display display, pPropertyCount* pPropertyCount, pProperties* pProperties);
        private readonly VulkanGetDisplayModeProperties2KHR vkGetDisplayModeProperties2KHR;
        
        [VulkanExtension("VK_KHR_get_display_properties2")]
        public unsafe VkResult GetDisplayModeProperties2KHR(physicalDevice physicalDevice, display display, pPropertyCount* pPropertyCount, pProperties* pProperties) =>
            this.vkGetDisplayModeProperties2KHR.Invoke(physicalDevice, display, pPropertyCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetDisplayPlaneCapabilities2KHR(physicalDevice physicalDevice, /*const*/ pDisplayPlaneInfo* pDisplayPlaneInfo, pCapabilities* pCapabilities);
        private readonly VulkanGetDisplayPlaneCapabilities2KHR vkGetDisplayPlaneCapabilities2KHR;
        
        [VulkanExtension("VK_KHR_get_display_properties2")]
        public unsafe VkResult GetDisplayPlaneCapabilities2KHR(physicalDevice physicalDevice, /*const*/ pDisplayPlaneInfo* pDisplayPlaneInfo, pCapabilities* pCapabilities) =>
            this.vkGetDisplayPlaneCapabilities2KHR.Invoke(physicalDevice, pDisplayPlaneInfo, pCapabilities);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateAccelerationStructureKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pAccelerationStructure* pAccelerationStructure);
        private readonly VulkanCreateAccelerationStructureKHR vkCreateAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult CreateAccelerationStructureKHR(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pAccelerationStructure* pAccelerationStructure) =>
            this.vkCreateAccelerationStructureKHR.Invoke(device, pCreateInfo, pAllocator, pAccelerationStructure);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyAccelerationStructureKHR(device device, accelerationStructure accelerationStructure, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyAccelerationStructureKHR vkDestroyAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void DestroyAccelerationStructureKHR(device device, accelerationStructure accelerationStructure, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyAccelerationStructureKHR.Invoke(device, accelerationStructure, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBuildAccelerationStructuresKHR(commandBuffer commandBuffer, infoCount infoCount, /*const*/ pInfos* pInfos, ppBuildRangeInfos ppBuildRangeInfos);
        private readonly VulkanCmdBuildAccelerationStructuresKHR vkCmdBuildAccelerationStructuresKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdBuildAccelerationStructuresKHR(commandBuffer commandBuffer, infoCount infoCount, /*const*/ pInfos* pInfos, ppBuildRangeInfos ppBuildRangeInfos) =>
            this.vkCmdBuildAccelerationStructuresKHR.Invoke(commandBuffer, infoCount, pInfos, ppBuildRangeInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBuildAccelerationStructuresIndirectKHR(commandBuffer commandBuffer, infoCount infoCount, /*const*/ pInfos* pInfos, /*const*/ pIndirectDeviceAddresses* pIndirectDeviceAddresses, /*const*/ pIndirectStrides* pIndirectStrides, ppMaxPrimitiveCounts ppMaxPrimitiveCounts);
        private readonly VulkanCmdBuildAccelerationStructuresIndirectKHR vkCmdBuildAccelerationStructuresIndirectKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdBuildAccelerationStructuresIndirectKHR(commandBuffer commandBuffer, infoCount infoCount, /*const*/ pInfos* pInfos, /*const*/ pIndirectDeviceAddresses* pIndirectDeviceAddresses, /*const*/ pIndirectStrides* pIndirectStrides, ppMaxPrimitiveCounts ppMaxPrimitiveCounts) =>
            this.vkCmdBuildAccelerationStructuresIndirectKHR.Invoke(commandBuffer, infoCount, pInfos, pIndirectDeviceAddresses, pIndirectStrides, ppMaxPrimitiveCounts);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanBuildAccelerationStructuresKHR(device device, deferredOperation deferredOperation, infoCount infoCount, /*const*/ pInfos* pInfos, ppBuildRangeInfos ppBuildRangeInfos);
        private readonly VulkanBuildAccelerationStructuresKHR vkBuildAccelerationStructuresKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult BuildAccelerationStructuresKHR(device device, deferredOperation deferredOperation, infoCount infoCount, /*const*/ pInfos* pInfos, ppBuildRangeInfos ppBuildRangeInfos) =>
            this.vkBuildAccelerationStructuresKHR.Invoke(device, deferredOperation, infoCount, pInfos, ppBuildRangeInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCopyAccelerationStructureKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo);
        private readonly VulkanCopyAccelerationStructureKHR vkCopyAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult CopyAccelerationStructureKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo) =>
            this.vkCopyAccelerationStructureKHR.Invoke(device, deferredOperation, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCopyAccelerationStructureToMemoryKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo);
        private readonly VulkanCopyAccelerationStructureToMemoryKHR vkCopyAccelerationStructureToMemoryKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult CopyAccelerationStructureToMemoryKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo) =>
            this.vkCopyAccelerationStructureToMemoryKHR.Invoke(device, deferredOperation, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCopyMemoryToAccelerationStructureKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo);
        private readonly VulkanCopyMemoryToAccelerationStructureKHR vkCopyMemoryToAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult CopyMemoryToAccelerationStructureKHR(device device, deferredOperation deferredOperation, /*const*/ pInfo* pInfo) =>
            this.vkCopyMemoryToAccelerationStructureKHR.Invoke(device, deferredOperation, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanWriteAccelerationStructuresPropertiesKHR(device device, accelerationStructureCount accelerationStructureCount, /*const*/ pAccelerationStructures* pAccelerationStructures, queryType queryType, dataSize dataSize, pData* pData, stride stride);
        private readonly VulkanWriteAccelerationStructuresPropertiesKHR vkWriteAccelerationStructuresPropertiesKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkResult WriteAccelerationStructuresPropertiesKHR(device device, accelerationStructureCount accelerationStructureCount, /*const*/ pAccelerationStructures* pAccelerationStructures, queryType queryType, dataSize dataSize, pData* pData, stride stride) =>
            this.vkWriteAccelerationStructuresPropertiesKHR.Invoke(device, accelerationStructureCount, pAccelerationStructures, queryType, dataSize, pData, stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyAccelerationStructureKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo);
        private readonly VulkanCmdCopyAccelerationStructureKHR vkCmdCopyAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdCopyAccelerationStructureKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo) =>
            this.vkCmdCopyAccelerationStructureKHR.Invoke(commandBuffer, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyAccelerationStructureToMemoryKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo);
        private readonly VulkanCmdCopyAccelerationStructureToMemoryKHR vkCmdCopyAccelerationStructureToMemoryKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdCopyAccelerationStructureToMemoryKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo) =>
            this.vkCmdCopyAccelerationStructureToMemoryKHR.Invoke(commandBuffer, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyMemoryToAccelerationStructureKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo);
        private readonly VulkanCmdCopyMemoryToAccelerationStructureKHR vkCmdCopyMemoryToAccelerationStructureKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdCopyMemoryToAccelerationStructureKHR(commandBuffer commandBuffer, /*const*/ pInfo* pInfo) =>
            this.vkCmdCopyMemoryToAccelerationStructureKHR.Invoke(commandBuffer, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkDeviceAddress VulkanGetAccelerationStructureDeviceAddressKHR(device device, /*const*/ pInfo* pInfo);
        private readonly VulkanGetAccelerationStructureDeviceAddressKHR vkGetAccelerationStructureDeviceAddressKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe VkDeviceAddress GetAccelerationStructureDeviceAddressKHR(device device, /*const*/ pInfo* pInfo) =>
            this.vkGetAccelerationStructureDeviceAddressKHR.Invoke(device, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdWriteAccelerationStructuresPropertiesKHR(commandBuffer commandBuffer, accelerationStructureCount accelerationStructureCount, /*const*/ pAccelerationStructures* pAccelerationStructures, queryType queryType, queryPool queryPool, firstQuery firstQuery);
        private readonly VulkanCmdWriteAccelerationStructuresPropertiesKHR vkCmdWriteAccelerationStructuresPropertiesKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void CmdWriteAccelerationStructuresPropertiesKHR(commandBuffer commandBuffer, accelerationStructureCount accelerationStructureCount, /*const*/ pAccelerationStructures* pAccelerationStructures, queryType queryType, queryPool queryPool, firstQuery firstQuery) =>
            this.vkCmdWriteAccelerationStructuresPropertiesKHR.Invoke(commandBuffer, accelerationStructureCount, pAccelerationStructures, queryType, queryPool, firstQuery);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceAccelerationStructureCompatibilityKHR(device device, /*const*/ pVersionInfo* pVersionInfo, pCompatibility* pCompatibility);
        private readonly VulkanGetDeviceAccelerationStructureCompatibilityKHR vkGetDeviceAccelerationStructureCompatibilityKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void GetDeviceAccelerationStructureCompatibilityKHR(device device, /*const*/ pVersionInfo* pVersionInfo, pCompatibility* pCompatibility) =>
            this.vkGetDeviceAccelerationStructureCompatibilityKHR.Invoke(device, pVersionInfo, pCompatibility);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetAccelerationStructureBuildSizesKHR(device device, buildType buildType, /*const*/ pBuildInfo* pBuildInfo, /*const*/ pMaxPrimitiveCounts* pMaxPrimitiveCounts, pSizeInfo* pSizeInfo);
        private readonly VulkanGetAccelerationStructureBuildSizesKHR vkGetAccelerationStructureBuildSizesKHR;
        
        [VulkanExtension("VK_KHR_acceleration_structure")]
        public unsafe void GetAccelerationStructureBuildSizesKHR(device device, buildType buildType, /*const*/ pBuildInfo* pBuildInfo, /*const*/ pMaxPrimitiveCounts* pMaxPrimitiveCounts, pSizeInfo* pSizeInfo) =>
            this.vkGetAccelerationStructureBuildSizesKHR.Invoke(device, buildType, pBuildInfo, pMaxPrimitiveCounts, pSizeInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdTraceRaysKHR(commandBuffer commandBuffer, /*const*/ pRaygenShaderBindingTable* pRaygenShaderBindingTable, /*const*/ pMissShaderBindingTable* pMissShaderBindingTable, /*const*/ pHitShaderBindingTable* pHitShaderBindingTable, /*const*/ pCallableShaderBindingTable* pCallableShaderBindingTable, width width, height height, depth depth);
        private readonly VulkanCmdTraceRaysKHR vkCmdTraceRaysKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe void CmdTraceRaysKHR(commandBuffer commandBuffer, /*const*/ pRaygenShaderBindingTable* pRaygenShaderBindingTable, /*const*/ pMissShaderBindingTable* pMissShaderBindingTable, /*const*/ pHitShaderBindingTable* pHitShaderBindingTable, /*const*/ pCallableShaderBindingTable* pCallableShaderBindingTable, width width, height height, depth depth) =>
            this.vkCmdTraceRaysKHR.Invoke(commandBuffer, pRaygenShaderBindingTable, pMissShaderBindingTable, pHitShaderBindingTable, pCallableShaderBindingTable, width, height, depth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateRayTracingPipelinesKHR(device device, deferredOperation deferredOperation, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateRayTracingPipelinesKHR vkCreateRayTracingPipelinesKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe VkResult CreateRayTracingPipelinesKHR(device device, deferredOperation deferredOperation, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateRayTracingPipelinesKHR.Invoke(device, deferredOperation, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateRayTracingPipelinesKHR(device device, deferredOperation deferredOperation, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines);
        private readonly VulkanCreateRayTracingPipelinesKHR vkCreateRayTracingPipelinesKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe VkResult CreateRayTracingPipelinesKHR(device device, deferredOperation deferredOperation, pipelineCache pipelineCache, createInfoCount createInfoCount, /*const*/ pCreateInfos* pCreateInfos, /*const*/ pAllocator* pAllocator, pPipelines* pPipelines) =>
            this.vkCreateRayTracingPipelinesKHR.Invoke(device, deferredOperation, pipelineCache, createInfoCount, pCreateInfos, pAllocator, pPipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetRayTracingShaderGroupHandlesKHR(device device, pipeline pipeline, firstGroup firstGroup, groupCount groupCount, dataSize dataSize, pData* pData);
        private readonly VulkanGetRayTracingShaderGroupHandlesKHR vkGetRayTracingShaderGroupHandlesKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe VkResult GetRayTracingShaderGroupHandlesKHR(device device, pipeline pipeline, firstGroup firstGroup, groupCount groupCount, dataSize dataSize, pData* pData) =>
            this.vkGetRayTracingShaderGroupHandlesKHR.Invoke(device, pipeline, firstGroup, groupCount, dataSize, pData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetRayTracingCaptureReplayShaderGroupHandlesKHR(device device, pipeline pipeline, firstGroup firstGroup, groupCount groupCount, dataSize dataSize, pData* pData);
        private readonly VulkanGetRayTracingCaptureReplayShaderGroupHandlesKHR vkGetRayTracingCaptureReplayShaderGroupHandlesKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe VkResult GetRayTracingCaptureReplayShaderGroupHandlesKHR(device device, pipeline pipeline, firstGroup firstGroup, groupCount groupCount, dataSize dataSize, pData* pData) =>
            this.vkGetRayTracingCaptureReplayShaderGroupHandlesKHR.Invoke(device, pipeline, firstGroup, groupCount, dataSize, pData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdTraceRaysIndirectKHR(commandBuffer commandBuffer, /*const*/ pRaygenShaderBindingTable* pRaygenShaderBindingTable, /*const*/ pMissShaderBindingTable* pMissShaderBindingTable, /*const*/ pHitShaderBindingTable* pHitShaderBindingTable, /*const*/ pCallableShaderBindingTable* pCallableShaderBindingTable, indirectDeviceAddress indirectDeviceAddress);
        private readonly VulkanCmdTraceRaysIndirectKHR vkCmdTraceRaysIndirectKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public unsafe void CmdTraceRaysIndirectKHR(commandBuffer commandBuffer, /*const*/ pRaygenShaderBindingTable* pRaygenShaderBindingTable, /*const*/ pMissShaderBindingTable* pMissShaderBindingTable, /*const*/ pHitShaderBindingTable* pHitShaderBindingTable, /*const*/ pCallableShaderBindingTable* pCallableShaderBindingTable, indirectDeviceAddress indirectDeviceAddress) =>
            this.vkCmdTraceRaysIndirectKHR.Invoke(commandBuffer, pRaygenShaderBindingTable, pMissShaderBindingTable, pHitShaderBindingTable, pCallableShaderBindingTable, indirectDeviceAddress);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkDeviceSize VulkanGetRayTracingShaderGroupStackSizeKHR(device device, pipeline pipeline, group group, groupShader groupShader);
        private readonly VulkanGetRayTracingShaderGroupStackSizeKHR vkGetRayTracingShaderGroupStackSizeKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public VkDeviceSize GetRayTracingShaderGroupStackSizeKHR(device device, pipeline pipeline, group group, groupShader groupShader) =>
            this.vkGetRayTracingShaderGroupStackSizeKHR.Invoke(device, pipeline, group, groupShader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetRayTracingPipelineStackSizeKHR(commandBuffer commandBuffer, pipelineStackSize pipelineStackSize);
        private readonly VulkanCmdSetRayTracingPipelineStackSizeKHR vkCmdSetRayTracingPipelineStackSizeKHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_pipeline")]
        public void CmdSetRayTracingPipelineStackSizeKHR(commandBuffer commandBuffer, pipelineStackSize pipelineStackSize) =>
            this.vkCmdSetRayTracingPipelineStackSizeKHR.Invoke(commandBuffer, pipelineStackSize);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceFragmentShadingRatesKHR(physicalDevice physicalDevice, pFragmentShadingRateCount* pFragmentShadingRateCount, pFragmentShadingRates* pFragmentShadingRates);
        private readonly VulkanGetPhysicalDeviceFragmentShadingRatesKHR vkGetPhysicalDeviceFragmentShadingRatesKHR;
        
        [VulkanExtension("VK_KHR_fragment_shading_rate")]
        public unsafe VkResult GetPhysicalDeviceFragmentShadingRatesKHR(physicalDevice physicalDevice, pFragmentShadingRateCount* pFragmentShadingRateCount, pFragmentShadingRates* pFragmentShadingRates) =>
            this.vkGetPhysicalDeviceFragmentShadingRatesKHR.Invoke(physicalDevice, pFragmentShadingRateCount, pFragmentShadingRates);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetFragmentShadingRateKHR(commandBuffer commandBuffer, /*const*/ pFragmentSize* pFragmentSize, /*const*/ combinerOps* [2]);
        private readonly VulkanCmdSetFragmentShadingRateKHR vkCmdSetFragmentShadingRateKHR;
        
        [VulkanExtension("VK_KHR_fragment_shading_rate")]
        public unsafe void CmdSetFragmentShadingRateKHR(commandBuffer commandBuffer, /*const*/ pFragmentSize* pFragmentSize, /*const*/ combinerOps* [2]) =>
            this.vkCmdSetFragmentShadingRateKHR.Invoke(commandBuffer, pFragmentSize, [2]);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanWaitForPresentKHR(device device, swapchain swapchain, presentId presentId, timeout timeout);
        private readonly VulkanWaitForPresentKHR vkWaitForPresentKHR;
        
        [VulkanExtension("VK_KHR_present_wait")]
        public VkResult WaitForPresentKHR(device device, swapchain swapchain, presentId presentId, timeout timeout) =>
            this.vkWaitForPresentKHR.Invoke(device, swapchain, presentId, timeout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateDeferredOperationKHR(device device, /*const*/ pAllocator* pAllocator, pDeferredOperation* pDeferredOperation);
        private readonly VulkanCreateDeferredOperationKHR vkCreateDeferredOperationKHR;
        
        [VulkanExtension("VK_KHR_deferred_host_operations")]
        public unsafe VkResult CreateDeferredOperationKHR(device device, /*const*/ pAllocator* pAllocator, pDeferredOperation* pDeferredOperation) =>
            this.vkCreateDeferredOperationKHR.Invoke(device, pAllocator, pDeferredOperation);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyDeferredOperationKHR(device device, operation operation, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyDeferredOperationKHR vkDestroyDeferredOperationKHR;
        
        [VulkanExtension("VK_KHR_deferred_host_operations")]
        public unsafe void DestroyDeferredOperationKHR(device device, operation operation, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyDeferredOperationKHR.Invoke(device, operation, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint32_t VulkanGetDeferredOperationMaxConcurrencyKHR(device device, operation operation);
        private readonly VulkanGetDeferredOperationMaxConcurrencyKHR vkGetDeferredOperationMaxConcurrencyKHR;
        
        [VulkanExtension("VK_KHR_deferred_host_operations")]
        public uint32_t GetDeferredOperationMaxConcurrencyKHR(device device, operation operation) =>
            this.vkGetDeferredOperationMaxConcurrencyKHR.Invoke(device, operation);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanGetDeferredOperationResultKHR(device device, operation operation);
        private readonly VulkanGetDeferredOperationResultKHR vkGetDeferredOperationResultKHR;
        
        [VulkanExtension("VK_KHR_deferred_host_operations")]
        public VkResult GetDeferredOperationResultKHR(device device, operation operation) =>
            this.vkGetDeferredOperationResultKHR.Invoke(device, operation);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanDeferredOperationJoinKHR(device device, operation operation);
        private readonly VulkanDeferredOperationJoinKHR vkDeferredOperationJoinKHR;
        
        [VulkanExtension("VK_KHR_deferred_host_operations")]
        public VkResult DeferredOperationJoinKHR(device device, operation operation) =>
            this.vkDeferredOperationJoinKHR.Invoke(device, operation);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPipelineExecutablePropertiesKHR(device device, /*const*/ pPipelineInfo* pPipelineInfo, pExecutableCount* pExecutableCount, pProperties* pProperties);
        private readonly VulkanGetPipelineExecutablePropertiesKHR vkGetPipelineExecutablePropertiesKHR;
        
        [VulkanExtension("VK_KHR_pipeline_executable_properties")]
        public unsafe VkResult GetPipelineExecutablePropertiesKHR(device device, /*const*/ pPipelineInfo* pPipelineInfo, pExecutableCount* pExecutableCount, pProperties* pProperties) =>
            this.vkGetPipelineExecutablePropertiesKHR.Invoke(device, pPipelineInfo, pExecutableCount, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPipelineExecutableStatisticsKHR(device device, /*const*/ pExecutableInfo* pExecutableInfo, pStatisticCount* pStatisticCount, pStatistics* pStatistics);
        private readonly VulkanGetPipelineExecutableStatisticsKHR vkGetPipelineExecutableStatisticsKHR;
        
        [VulkanExtension("VK_KHR_pipeline_executable_properties")]
        public unsafe VkResult GetPipelineExecutableStatisticsKHR(device device, /*const*/ pExecutableInfo* pExecutableInfo, pStatisticCount* pStatisticCount, pStatistics* pStatistics) =>
            this.vkGetPipelineExecutableStatisticsKHR.Invoke(device, pExecutableInfo, pStatisticCount, pStatistics);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPipelineExecutableInternalRepresentationsKHR(device device, /*const*/ pExecutableInfo* pExecutableInfo, pInternalRepresentationCount* pInternalRepresentationCount, pInternalRepresentations* pInternalRepresentations);
        private readonly VulkanGetPipelineExecutableInternalRepresentationsKHR vkGetPipelineExecutableInternalRepresentationsKHR;
        
        [VulkanExtension("VK_KHR_pipeline_executable_properties")]
        public unsafe VkResult GetPipelineExecutableInternalRepresentationsKHR(device device, /*const*/ pExecutableInfo* pExecutableInfo, pInternalRepresentationCount* pInternalRepresentationCount, pInternalRepresentations* pInternalRepresentations) =>
            this.vkGetPipelineExecutableInternalRepresentationsKHR.Invoke(device, pExecutableInfo, pInternalRepresentationCount, pInternalRepresentations);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdEncodeVideoKHR(commandBuffer commandBuffer, /*const*/ pEncodeInfo* pEncodeInfo);
        private readonly VulkanCmdEncodeVideoKHR vkCmdEncodeVideoKHR;
        
        [VulkanExtension("VK_KHR_video_encode_queue")]
        public unsafe void CmdEncodeVideoKHR(commandBuffer commandBuffer, /*const*/ pEncodeInfo* pEncodeInfo) =>
            this.vkCmdEncodeVideoKHR.Invoke(commandBuffer, pEncodeInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdRefreshObjectsKHR(commandBuffer commandBuffer, /*const*/ pRefreshObjects* pRefreshObjects);
        private readonly VulkanCmdRefreshObjectsKHR vkCmdRefreshObjectsKHR;
        
        [VulkanExtension("VK_KHR_object_refresh")]
        public unsafe void CmdRefreshObjectsKHR(commandBuffer commandBuffer, /*const*/ pRefreshObjects* pRefreshObjects) =>
            this.vkCmdRefreshObjectsKHR.Invoke(commandBuffer, pRefreshObjects);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceRefreshableObjectTypesKHR(physicalDevice physicalDevice, pRefreshableObjectTypeCount* pRefreshableObjectTypeCount, pRefreshableObjectTypes* pRefreshableObjectTypes);
        private readonly VulkanGetPhysicalDeviceRefreshableObjectTypesKHR vkGetPhysicalDeviceRefreshableObjectTypesKHR;
        
        [VulkanExtension("VK_KHR_object_refresh")]
        public unsafe VkResult GetPhysicalDeviceRefreshableObjectTypesKHR(physicalDevice physicalDevice, pRefreshableObjectTypeCount* pRefreshableObjectTypeCount, pRefreshableObjectTypes* pRefreshableObjectTypes) =>
            this.vkGetPhysicalDeviceRefreshableObjectTypesKHR.Invoke(physicalDevice, pRefreshableObjectTypeCount, pRefreshableObjectTypes);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdWriteBufferMarker2AMD(commandBuffer commandBuffer, stage stage, dstBuffer dstBuffer, dstOffset dstOffset, marker marker);
        private readonly VulkanCmdWriteBufferMarker2AMD vkCmdWriteBufferMarker2AMD;
        
        [VulkanExtension("VK_KHR_synchronization2")]
        public void CmdWriteBufferMarker2AMD(commandBuffer commandBuffer, stage stage, dstBuffer dstBuffer, dstOffset dstOffset, marker marker) =>
            this.vkCmdWriteBufferMarker2AMD.Invoke(commandBuffer, stage, dstBuffer, dstOffset, marker);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetQueueCheckpointData2NV(queue queue, pCheckpointDataCount* pCheckpointDataCount, pCheckpointData* pCheckpointData);
        private readonly VulkanGetQueueCheckpointData2NV vkGetQueueCheckpointData2NV;
        
        [VulkanExtension("VK_KHR_synchronization2")]
        public unsafe void GetQueueCheckpointData2NV(queue queue, pCheckpointDataCount* pCheckpointDataCount, pCheckpointData* pCheckpointData) =>
            this.vkGetQueueCheckpointData2NV.Invoke(queue, pCheckpointDataCount, pCheckpointData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdTraceRaysIndirect2KHR(commandBuffer commandBuffer, indirectDeviceAddress indirectDeviceAddress);
        private readonly VulkanCmdTraceRaysIndirect2KHR vkCmdTraceRaysIndirect2KHR;
        
        [VulkanExtension("VK_KHR_ray_tracing_maintenance1")]
        public void CmdTraceRaysIndirect2KHR(commandBuffer commandBuffer, indirectDeviceAddress indirectDeviceAddress) =>
            this.vkCmdTraceRaysIndirect2KHR.Invoke(commandBuffer, indirectDeviceAddress);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumerateInstanceVersion(pApiVersion* pApiVersion);
        private readonly VulkanEnumerateInstanceVersion vkEnumerateInstanceVersion;
        
        public unsafe VkResult EnumerateInstanceVersion(pApiVersion* pApiVersion) =>
            this.vkEnumerateInstanceVersion.Invoke(pApiVersion);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanBindBufferMemory2(device device, bindInfoCount bindInfoCount, /*const*/ pBindInfos* pBindInfos);
        private readonly VulkanBindBufferMemory2 vkBindBufferMemory2;
        
        public unsafe VkResult BindBufferMemory2(device device, bindInfoCount bindInfoCount, /*const*/ pBindInfos* pBindInfos) =>
            this.vkBindBufferMemory2.Invoke(device, bindInfoCount, pBindInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanBindImageMemory2(device device, bindInfoCount bindInfoCount, /*const*/ pBindInfos* pBindInfos);
        private readonly VulkanBindImageMemory2 vkBindImageMemory2;
        
        public unsafe VkResult BindImageMemory2(device device, bindInfoCount bindInfoCount, /*const*/ pBindInfos* pBindInfos) =>
            this.vkBindImageMemory2.Invoke(device, bindInfoCount, pBindInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceGroupPeerMemoryFeatures(device device, heapIndex heapIndex, localDeviceIndex localDeviceIndex, remoteDeviceIndex remoteDeviceIndex, pPeerMemoryFeatures* pPeerMemoryFeatures);
        private readonly VulkanGetDeviceGroupPeerMemoryFeatures vkGetDeviceGroupPeerMemoryFeatures;
        
        public unsafe void GetDeviceGroupPeerMemoryFeatures(device device, heapIndex heapIndex, localDeviceIndex localDeviceIndex, remoteDeviceIndex remoteDeviceIndex, pPeerMemoryFeatures* pPeerMemoryFeatures) =>
            this.vkGetDeviceGroupPeerMemoryFeatures.Invoke(device, heapIndex, localDeviceIndex, remoteDeviceIndex, pPeerMemoryFeatures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDeviceMask(commandBuffer commandBuffer, deviceMask deviceMask);
        private readonly VulkanCmdSetDeviceMask vkCmdSetDeviceMask;
        
        public void CmdSetDeviceMask(commandBuffer commandBuffer, deviceMask deviceMask) =>
            this.vkCmdSetDeviceMask.Invoke(commandBuffer, deviceMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDispatchBase(commandBuffer commandBuffer, baseGroupX baseGroupX, baseGroupY baseGroupY, baseGroupZ baseGroupZ, groupCountX groupCountX, groupCountY groupCountY, groupCountZ groupCountZ);
        private readonly VulkanCmdDispatchBase vkCmdDispatchBase;
        
        public void CmdDispatchBase(commandBuffer commandBuffer, baseGroupX baseGroupX, baseGroupY baseGroupY, baseGroupZ baseGroupZ, groupCountX groupCountX, groupCountY groupCountY, groupCountZ groupCountZ) =>
            this.vkCmdDispatchBase.Invoke(commandBuffer, baseGroupX, baseGroupY, baseGroupZ, groupCountX, groupCountY, groupCountZ);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanEnumeratePhysicalDeviceGroups(instance instance, pPhysicalDeviceGroupCount* pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);
        private readonly VulkanEnumeratePhysicalDeviceGroups vkEnumeratePhysicalDeviceGroups;
        
        public unsafe VkResult EnumeratePhysicalDeviceGroups(instance instance, pPhysicalDeviceGroupCount* pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties) =>
            this.vkEnumeratePhysicalDeviceGroups.Invoke(instance, pPhysicalDeviceGroupCount, pPhysicalDeviceGroupProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetImageMemoryRequirements2(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetImageMemoryRequirements2 vkGetImageMemoryRequirements2;
        
        public unsafe void GetImageMemoryRequirements2(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetImageMemoryRequirements2.Invoke(device, pInfo, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetBufferMemoryRequirements2(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetBufferMemoryRequirements2 vkGetBufferMemoryRequirements2;
        
        public unsafe void GetBufferMemoryRequirements2(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetBufferMemoryRequirements2.Invoke(device, pInfo, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceFeatures2(physicalDevice physicalDevice, pFeatures* pFeatures);
        private readonly VulkanGetPhysicalDeviceFeatures2 vkGetPhysicalDeviceFeatures2;
        
        public unsafe void GetPhysicalDeviceFeatures2(physicalDevice physicalDevice, pFeatures* pFeatures) =>
            this.vkGetPhysicalDeviceFeatures2.Invoke(physicalDevice, pFeatures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceProperties2(physicalDevice physicalDevice, pProperties* pProperties);
        private readonly VulkanGetPhysicalDeviceProperties2 vkGetPhysicalDeviceProperties2;
        
        public unsafe void GetPhysicalDeviceProperties2(physicalDevice physicalDevice, pProperties* pProperties) =>
            this.vkGetPhysicalDeviceProperties2.Invoke(physicalDevice, pProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceFormatProperties2(physicalDevice physicalDevice, format format, pFormatProperties* pFormatProperties);
        private readonly VulkanGetPhysicalDeviceFormatProperties2 vkGetPhysicalDeviceFormatProperties2;
        
        public unsafe void GetPhysicalDeviceFormatProperties2(physicalDevice physicalDevice, format format, pFormatProperties* pFormatProperties) =>
            this.vkGetPhysicalDeviceFormatProperties2.Invoke(physicalDevice, format, pFormatProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceImageFormatProperties2(physicalDevice physicalDevice, /*const*/ pImageFormatInfo* pImageFormatInfo, pImageFormatProperties* pImageFormatProperties);
        private readonly VulkanGetPhysicalDeviceImageFormatProperties2 vkGetPhysicalDeviceImageFormatProperties2;
        
        public unsafe VkResult GetPhysicalDeviceImageFormatProperties2(physicalDevice physicalDevice, /*const*/ pImageFormatInfo* pImageFormatInfo, pImageFormatProperties* pImageFormatProperties) =>
            this.vkGetPhysicalDeviceImageFormatProperties2.Invoke(physicalDevice, pImageFormatInfo, pImageFormatProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceQueueFamilyProperties2(physicalDevice physicalDevice, pQueueFamilyPropertyCount* pQueueFamilyPropertyCount, pQueueFamilyProperties* pQueueFamilyProperties);
        private readonly VulkanGetPhysicalDeviceQueueFamilyProperties2 vkGetPhysicalDeviceQueueFamilyProperties2;
        
        public unsafe void GetPhysicalDeviceQueueFamilyProperties2(physicalDevice physicalDevice, pQueueFamilyPropertyCount* pQueueFamilyPropertyCount, pQueueFamilyProperties* pQueueFamilyProperties) =>
            this.vkGetPhysicalDeviceQueueFamilyProperties2.Invoke(physicalDevice, pQueueFamilyPropertyCount, pQueueFamilyProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceMemoryProperties2(physicalDevice physicalDevice, pMemoryProperties* pMemoryProperties);
        private readonly VulkanGetPhysicalDeviceMemoryProperties2 vkGetPhysicalDeviceMemoryProperties2;
        
        public unsafe void GetPhysicalDeviceMemoryProperties2(physicalDevice physicalDevice, pMemoryProperties* pMemoryProperties) =>
            this.vkGetPhysicalDeviceMemoryProperties2.Invoke(physicalDevice, pMemoryProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceQueue2(device device, /*const*/ pQueueInfo* pQueueInfo, pQueue* pQueue);
        private readonly VulkanGetDeviceQueue2 vkGetDeviceQueue2;
        
        public unsafe void GetDeviceQueue2(device device, /*const*/ pQueueInfo* pQueueInfo, pQueue* pQueue) =>
            this.vkGetDeviceQueue2.Invoke(device, pQueueInfo, pQueue);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateSamplerYcbcrConversion(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pYcbcrConversion* pYcbcrConversion);
        private readonly VulkanCreateSamplerYcbcrConversion vkCreateSamplerYcbcrConversion;
        
        public unsafe VkResult CreateSamplerYcbcrConversion(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pYcbcrConversion* pYcbcrConversion) =>
            this.vkCreateSamplerYcbcrConversion.Invoke(device, pCreateInfo, pAllocator, pYcbcrConversion);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroySamplerYcbcrConversion(device device, ycbcrConversion ycbcrConversion, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroySamplerYcbcrConversion vkDestroySamplerYcbcrConversion;
        
        public unsafe void DestroySamplerYcbcrConversion(device device, ycbcrConversion ycbcrConversion, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroySamplerYcbcrConversion.Invoke(device, ycbcrConversion, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceExternalBufferProperties(physicalDevice physicalDevice, /*const*/ pExternalBufferInfo* pExternalBufferInfo, pExternalBufferProperties* pExternalBufferProperties);
        private readonly VulkanGetPhysicalDeviceExternalBufferProperties vkGetPhysicalDeviceExternalBufferProperties;
        
        public unsafe void GetPhysicalDeviceExternalBufferProperties(physicalDevice physicalDevice, /*const*/ pExternalBufferInfo* pExternalBufferInfo, pExternalBufferProperties* pExternalBufferProperties) =>
            this.vkGetPhysicalDeviceExternalBufferProperties.Invoke(physicalDevice, pExternalBufferInfo, pExternalBufferProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceExternalFenceProperties(physicalDevice physicalDevice, /*const*/ pExternalFenceInfo* pExternalFenceInfo, pExternalFenceProperties* pExternalFenceProperties);
        private readonly VulkanGetPhysicalDeviceExternalFenceProperties vkGetPhysicalDeviceExternalFenceProperties;
        
        public unsafe void GetPhysicalDeviceExternalFenceProperties(physicalDevice physicalDevice, /*const*/ pExternalFenceInfo* pExternalFenceInfo, pExternalFenceProperties* pExternalFenceProperties) =>
            this.vkGetPhysicalDeviceExternalFenceProperties.Invoke(physicalDevice, pExternalFenceInfo, pExternalFenceProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPhysicalDeviceExternalSemaphoreProperties(physicalDevice physicalDevice, /*const*/ pExternalSemaphoreInfo* pExternalSemaphoreInfo, pExternalSemaphoreProperties* pExternalSemaphoreProperties);
        private readonly VulkanGetPhysicalDeviceExternalSemaphoreProperties vkGetPhysicalDeviceExternalSemaphoreProperties;
        
        public unsafe void GetPhysicalDeviceExternalSemaphoreProperties(physicalDevice physicalDevice, /*const*/ pExternalSemaphoreInfo* pExternalSemaphoreInfo, pExternalSemaphoreProperties* pExternalSemaphoreProperties) =>
            this.vkGetPhysicalDeviceExternalSemaphoreProperties.Invoke(physicalDevice, pExternalSemaphoreInfo, pExternalSemaphoreProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDescriptorSetLayoutSupport(device device, /*const*/ pCreateInfo* pCreateInfo, pSupport* pSupport);
        private readonly VulkanGetDescriptorSetLayoutSupport vkGetDescriptorSetLayoutSupport;
        
        public unsafe void GetDescriptorSetLayoutSupport(device device, /*const*/ pCreateInfo* pCreateInfo, pSupport* pSupport) =>
            this.vkGetDescriptorSetLayoutSupport.Invoke(device, pCreateInfo, pSupport);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDrawIndirectCount(commandBuffer commandBuffer, buffer buffer, offset offset, countBuffer countBuffer, countBufferOffset countBufferOffset, maxDrawCount maxDrawCount, stride stride);
        private readonly VulkanCmdDrawIndirectCount vkCmdDrawIndirectCount;
        
        public void CmdDrawIndirectCount(commandBuffer commandBuffer, buffer buffer, offset offset, countBuffer countBuffer, countBufferOffset countBufferOffset, maxDrawCount maxDrawCount, stride stride) =>
            this.vkCmdDrawIndirectCount.Invoke(commandBuffer, buffer, offset, countBuffer, countBufferOffset, maxDrawCount, stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdDrawIndexedIndirectCount(commandBuffer commandBuffer, buffer buffer, offset offset, countBuffer countBuffer, countBufferOffset countBufferOffset, maxDrawCount maxDrawCount, stride stride);
        private readonly VulkanCmdDrawIndexedIndirectCount vkCmdDrawIndexedIndirectCount;
        
        public void CmdDrawIndexedIndirectCount(commandBuffer commandBuffer, buffer buffer, offset offset, countBuffer countBuffer, countBufferOffset countBufferOffset, maxDrawCount maxDrawCount, stride stride) =>
            this.vkCmdDrawIndexedIndirectCount.Invoke(commandBuffer, buffer, offset, countBuffer, countBufferOffset, maxDrawCount, stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreateRenderPass2(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pRenderPass* pRenderPass);
        private readonly VulkanCreateRenderPass2 vkCreateRenderPass2;
        
        public unsafe VkResult CreateRenderPass2(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pRenderPass* pRenderPass) =>
            this.vkCreateRenderPass2.Invoke(device, pCreateInfo, pAllocator, pRenderPass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBeginRenderPass2(commandBuffer commandBuffer, /*const*/ pRenderPassBegin* pRenderPassBegin, /*const*/ pSubpassBeginInfo* pSubpassBeginInfo);
        private readonly VulkanCmdBeginRenderPass2 vkCmdBeginRenderPass2;
        
        public unsafe void CmdBeginRenderPass2(commandBuffer commandBuffer, /*const*/ pRenderPassBegin* pRenderPassBegin, /*const*/ pSubpassBeginInfo* pSubpassBeginInfo) =>
            this.vkCmdBeginRenderPass2.Invoke(commandBuffer, pRenderPassBegin, pSubpassBeginInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdNextSubpass2(commandBuffer commandBuffer, /*const*/ pSubpassBeginInfo* pSubpassBeginInfo, /*const*/ pSubpassEndInfo* pSubpassEndInfo);
        private readonly VulkanCmdNextSubpass2 vkCmdNextSubpass2;
        
        public unsafe void CmdNextSubpass2(commandBuffer commandBuffer, /*const*/ pSubpassBeginInfo* pSubpassBeginInfo, /*const*/ pSubpassEndInfo* pSubpassEndInfo) =>
            this.vkCmdNextSubpass2.Invoke(commandBuffer, pSubpassBeginInfo, pSubpassEndInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdEndRenderPass2(commandBuffer commandBuffer, /*const*/ pSubpassEndInfo* pSubpassEndInfo);
        private readonly VulkanCmdEndRenderPass2 vkCmdEndRenderPass2;
        
        public unsafe void CmdEndRenderPass2(commandBuffer commandBuffer, /*const*/ pSubpassEndInfo* pSubpassEndInfo) =>
            this.vkCmdEndRenderPass2.Invoke(commandBuffer, pSubpassEndInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanResetQueryPool(device device, queryPool queryPool, firstQuery firstQuery, queryCount queryCount);
        private readonly VulkanResetQueryPool vkResetQueryPool;
        
        public void ResetQueryPool(device device, queryPool queryPool, firstQuery firstQuery, queryCount queryCount) =>
            this.vkResetQueryPool.Invoke(device, queryPool, firstQuery, queryCount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetSemaphoreCounterValue(device device, semaphore semaphore, pValue* pValue);
        private readonly VulkanGetSemaphoreCounterValue vkGetSemaphoreCounterValue;
        
        public unsafe VkResult GetSemaphoreCounterValue(device device, semaphore semaphore, pValue* pValue) =>
            this.vkGetSemaphoreCounterValue.Invoke(device, semaphore, pValue);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanWaitSemaphores(device device, /*const*/ pWaitInfo* pWaitInfo, timeout timeout);
        private readonly VulkanWaitSemaphores vkWaitSemaphores;
        
        public unsafe VkResult WaitSemaphores(device device, /*const*/ pWaitInfo* pWaitInfo, timeout timeout) =>
            this.vkWaitSemaphores.Invoke(device, pWaitInfo, timeout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanSignalSemaphore(device device, /*const*/ pSignalInfo* pSignalInfo);
        private readonly VulkanSignalSemaphore vkSignalSemaphore;
        
        public unsafe VkResult SignalSemaphore(device device, /*const*/ pSignalInfo* pSignalInfo) =>
            this.vkSignalSemaphore.Invoke(device, pSignalInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkDeviceAddress VulkanGetBufferDeviceAddress(device device, /*const*/ pInfo* pInfo);
        private readonly VulkanGetBufferDeviceAddress vkGetBufferDeviceAddress;
        
        public unsafe VkDeviceAddress GetBufferDeviceAddress(device device, /*const*/ pInfo* pInfo) =>
            this.vkGetBufferDeviceAddress.Invoke(device, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint64_t VulkanGetBufferOpaqueCaptureAddress(device device, /*const*/ pInfo* pInfo);
        private readonly VulkanGetBufferOpaqueCaptureAddress vkGetBufferOpaqueCaptureAddress;
        
        public unsafe uint64_t GetBufferOpaqueCaptureAddress(device device, /*const*/ pInfo* pInfo) =>
            this.vkGetBufferOpaqueCaptureAddress.Invoke(device, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint64_t VulkanGetDeviceMemoryOpaqueCaptureAddress(device device, /*const*/ pInfo* pInfo);
        private readonly VulkanGetDeviceMemoryOpaqueCaptureAddress vkGetDeviceMemoryOpaqueCaptureAddress;
        
        public unsafe uint64_t GetDeviceMemoryOpaqueCaptureAddress(device device, /*const*/ pInfo* pInfo) =>
            this.vkGetDeviceMemoryOpaqueCaptureAddress.Invoke(device, pInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetPhysicalDeviceToolProperties(physicalDevice physicalDevice, pToolCount* pToolCount, pToolProperties* pToolProperties);
        private readonly VulkanGetPhysicalDeviceToolProperties vkGetPhysicalDeviceToolProperties;
        
        public unsafe VkResult GetPhysicalDeviceToolProperties(physicalDevice physicalDevice, pToolCount* pToolCount, pToolProperties* pToolProperties) =>
            this.vkGetPhysicalDeviceToolProperties.Invoke(physicalDevice, pToolCount, pToolProperties);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanCreatePrivateDataSlot(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPrivateDataSlot* pPrivateDataSlot);
        private readonly VulkanCreatePrivateDataSlot vkCreatePrivateDataSlot;
        
        public unsafe VkResult CreatePrivateDataSlot(device device, /*const*/ pCreateInfo* pCreateInfo, /*const*/ pAllocator* pAllocator, pPrivateDataSlot* pPrivateDataSlot) =>
            this.vkCreatePrivateDataSlot.Invoke(device, pCreateInfo, pAllocator, pPrivateDataSlot);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanDestroyPrivateDataSlot(device device, privateDataSlot privateDataSlot, /*const*/ pAllocator* pAllocator);
        private readonly VulkanDestroyPrivateDataSlot vkDestroyPrivateDataSlot;
        
        public unsafe void DestroyPrivateDataSlot(device device, privateDataSlot privateDataSlot, /*const*/ pAllocator* pAllocator) =>
            this.vkDestroyPrivateDataSlot.Invoke(device, privateDataSlot, pAllocator);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate VkResult VulkanSetPrivateData(device device, objectType objectType, objectHandle objectHandle, privateDataSlot privateDataSlot, data data);
        private readonly VulkanSetPrivateData vkSetPrivateData;
        
        public VkResult SetPrivateData(device device, objectType objectType, objectHandle objectHandle, privateDataSlot privateDataSlot, data data) =>
            this.vkSetPrivateData.Invoke(device, objectType, objectHandle, privateDataSlot, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetPrivateData(device device, objectType objectType, objectHandle objectHandle, privateDataSlot privateDataSlot, pData* pData);
        private readonly VulkanGetPrivateData vkGetPrivateData;
        
        public unsafe void GetPrivateData(device device, objectType objectType, objectHandle objectHandle, privateDataSlot privateDataSlot, pData* pData) =>
            this.vkGetPrivateData.Invoke(device, objectType, objectHandle, privateDataSlot, pData);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetEvent2(commandBuffer commandBuffer, event @event, /*const*/ pDependencyInfo* pDependencyInfo);
        private readonly VulkanCmdSetEvent2 vkCmdSetEvent2;
        
        public unsafe void CmdSetEvent2(commandBuffer commandBuffer, event @event, /*const*/ pDependencyInfo* pDependencyInfo) =>
            this.vkCmdSetEvent2.Invoke(commandBuffer, @event, pDependencyInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdResetEvent2(commandBuffer commandBuffer, event @event, stageMask stageMask);
        private readonly VulkanCmdResetEvent2 vkCmdResetEvent2;
        
        public void CmdResetEvent2(commandBuffer commandBuffer, event @event, stageMask stageMask) =>
            this.vkCmdResetEvent2.Invoke(commandBuffer, @event, stageMask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdWaitEvents2(commandBuffer commandBuffer, eventCount eventCount, /*const*/ pEvents* pEvents, /*const*/ pDependencyInfos* pDependencyInfos);
        private readonly VulkanCmdWaitEvents2 vkCmdWaitEvents2;
        
        public unsafe void CmdWaitEvents2(commandBuffer commandBuffer, eventCount eventCount, /*const*/ pEvents* pEvents, /*const*/ pDependencyInfos* pDependencyInfos) =>
            this.vkCmdWaitEvents2.Invoke(commandBuffer, eventCount, pEvents, pDependencyInfos);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdPipelineBarrier2(commandBuffer commandBuffer, /*const*/ pDependencyInfo* pDependencyInfo);
        private readonly VulkanCmdPipelineBarrier2 vkCmdPipelineBarrier2;
        
        public unsafe void CmdPipelineBarrier2(commandBuffer commandBuffer, /*const*/ pDependencyInfo* pDependencyInfo) =>
            this.vkCmdPipelineBarrier2.Invoke(commandBuffer, pDependencyInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdWriteTimestamp2(commandBuffer commandBuffer, stage stage, queryPool queryPool, query query);
        private readonly VulkanCmdWriteTimestamp2 vkCmdWriteTimestamp2;
        
        public void CmdWriteTimestamp2(commandBuffer commandBuffer, stage stage, queryPool queryPool, query query) =>
            this.vkCmdWriteTimestamp2.Invoke(commandBuffer, stage, queryPool, query);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanQueueSubmit2(queue queue, submitCount submitCount, /*const*/ pSubmits* pSubmits, fence fence);
        private readonly VulkanQueueSubmit2 vkQueueSubmit2;
        
        public unsafe VkResult QueueSubmit2(queue queue, submitCount submitCount, /*const*/ pSubmits* pSubmits, fence fence) =>
            this.vkQueueSubmit2.Invoke(queue, submitCount, pSubmits, fence);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyBuffer2(commandBuffer commandBuffer, /*const*/ pCopyBufferInfo* pCopyBufferInfo);
        private readonly VulkanCmdCopyBuffer2 vkCmdCopyBuffer2;
        
        public unsafe void CmdCopyBuffer2(commandBuffer commandBuffer, /*const*/ pCopyBufferInfo* pCopyBufferInfo) =>
            this.vkCmdCopyBuffer2.Invoke(commandBuffer, pCopyBufferInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyImage2(commandBuffer commandBuffer, /*const*/ pCopyImageInfo* pCopyImageInfo);
        private readonly VulkanCmdCopyImage2 vkCmdCopyImage2;
        
        public unsafe void CmdCopyImage2(commandBuffer commandBuffer, /*const*/ pCopyImageInfo* pCopyImageInfo) =>
            this.vkCmdCopyImage2.Invoke(commandBuffer, pCopyImageInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyBufferToImage2(commandBuffer commandBuffer, /*const*/ pCopyBufferToImageInfo* pCopyBufferToImageInfo);
        private readonly VulkanCmdCopyBufferToImage2 vkCmdCopyBufferToImage2;
        
        public unsafe void CmdCopyBufferToImage2(commandBuffer commandBuffer, /*const*/ pCopyBufferToImageInfo* pCopyBufferToImageInfo) =>
            this.vkCmdCopyBufferToImage2.Invoke(commandBuffer, pCopyBufferToImageInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdCopyImageToBuffer2(commandBuffer commandBuffer, /*const*/ pCopyImageToBufferInfo* pCopyImageToBufferInfo);
        private readonly VulkanCmdCopyImageToBuffer2 vkCmdCopyImageToBuffer2;
        
        public unsafe void CmdCopyImageToBuffer2(commandBuffer commandBuffer, /*const*/ pCopyImageToBufferInfo* pCopyImageToBufferInfo) =>
            this.vkCmdCopyImageToBuffer2.Invoke(commandBuffer, pCopyImageToBufferInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBlitImage2(commandBuffer commandBuffer, /*const*/ pBlitImageInfo* pBlitImageInfo);
        private readonly VulkanCmdBlitImage2 vkCmdBlitImage2;
        
        public unsafe void CmdBlitImage2(commandBuffer commandBuffer, /*const*/ pBlitImageInfo* pBlitImageInfo) =>
            this.vkCmdBlitImage2.Invoke(commandBuffer, pBlitImageInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdResolveImage2(commandBuffer commandBuffer, /*const*/ pResolveImageInfo* pResolveImageInfo);
        private readonly VulkanCmdResolveImage2 vkCmdResolveImage2;
        
        public unsafe void CmdResolveImage2(commandBuffer commandBuffer, /*const*/ pResolveImageInfo* pResolveImageInfo) =>
            this.vkCmdResolveImage2.Invoke(commandBuffer, pResolveImageInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBeginRendering(commandBuffer commandBuffer, /*const*/ pRenderingInfo* pRenderingInfo);
        private readonly VulkanCmdBeginRendering vkCmdBeginRendering;
        
        public unsafe void CmdBeginRendering(commandBuffer commandBuffer, /*const*/ pRenderingInfo* pRenderingInfo) =>
            this.vkCmdBeginRendering.Invoke(commandBuffer, pRenderingInfo);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdEndRendering(commandBuffer commandBuffer);
        private readonly VulkanCmdEndRendering vkCmdEndRendering;
        
        public void CmdEndRendering(commandBuffer commandBuffer) =>
            this.vkCmdEndRendering.Invoke(commandBuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetCullMode(commandBuffer commandBuffer, cullMode cullMode);
        private readonly VulkanCmdSetCullMode vkCmdSetCullMode;
        
        public void CmdSetCullMode(commandBuffer commandBuffer, cullMode cullMode) =>
            this.vkCmdSetCullMode.Invoke(commandBuffer, cullMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetFrontFace(commandBuffer commandBuffer, frontFace frontFace);
        private readonly VulkanCmdSetFrontFace vkCmdSetFrontFace;
        
        public void CmdSetFrontFace(commandBuffer commandBuffer, frontFace frontFace) =>
            this.vkCmdSetFrontFace.Invoke(commandBuffer, frontFace);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetPrimitiveTopology(commandBuffer commandBuffer, primitiveTopology primitiveTopology);
        private readonly VulkanCmdSetPrimitiveTopology vkCmdSetPrimitiveTopology;
        
        public void CmdSetPrimitiveTopology(commandBuffer commandBuffer, primitiveTopology primitiveTopology) =>
            this.vkCmdSetPrimitiveTopology.Invoke(commandBuffer, primitiveTopology);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetViewportWithCount(commandBuffer commandBuffer, viewportCount viewportCount, /*const*/ pViewports* pViewports);
        private readonly VulkanCmdSetViewportWithCount vkCmdSetViewportWithCount;
        
        public unsafe void CmdSetViewportWithCount(commandBuffer commandBuffer, viewportCount viewportCount, /*const*/ pViewports* pViewports) =>
            this.vkCmdSetViewportWithCount.Invoke(commandBuffer, viewportCount, pViewports);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdSetScissorWithCount(commandBuffer commandBuffer, scissorCount scissorCount, /*const*/ pScissors* pScissors);
        private readonly VulkanCmdSetScissorWithCount vkCmdSetScissorWithCount;
        
        public unsafe void CmdSetScissorWithCount(commandBuffer commandBuffer, scissorCount scissorCount, /*const*/ pScissors* pScissors) =>
            this.vkCmdSetScissorWithCount.Invoke(commandBuffer, scissorCount, pScissors);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanCmdBindVertexBuffers2(commandBuffer commandBuffer, firstBinding firstBinding, bindingCount bindingCount, /*const*/ pBuffers* pBuffers, /*const*/ pOffsets* pOffsets, /*const*/ pSizes* pSizes, /*const*/ pStrides* pStrides);
        private readonly VulkanCmdBindVertexBuffers2 vkCmdBindVertexBuffers2;
        
        public unsafe void CmdBindVertexBuffers2(commandBuffer commandBuffer, firstBinding firstBinding, bindingCount bindingCount, /*const*/ pBuffers* pBuffers, /*const*/ pOffsets* pOffsets, /*const*/ pSizes* pSizes, /*const*/ pStrides* pStrides) =>
            this.vkCmdBindVertexBuffers2.Invoke(commandBuffer, firstBinding, bindingCount, pBuffers, pOffsets, pSizes, pStrides);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthTestEnable(commandBuffer commandBuffer, depthTestEnable depthTestEnable);
        private readonly VulkanCmdSetDepthTestEnable vkCmdSetDepthTestEnable;
        
        public void CmdSetDepthTestEnable(commandBuffer commandBuffer, depthTestEnable depthTestEnable) =>
            this.vkCmdSetDepthTestEnable.Invoke(commandBuffer, depthTestEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthWriteEnable(commandBuffer commandBuffer, depthWriteEnable depthWriteEnable);
        private readonly VulkanCmdSetDepthWriteEnable vkCmdSetDepthWriteEnable;
        
        public void CmdSetDepthWriteEnable(commandBuffer commandBuffer, depthWriteEnable depthWriteEnable) =>
            this.vkCmdSetDepthWriteEnable.Invoke(commandBuffer, depthWriteEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthCompareOp(commandBuffer commandBuffer, depthCompareOp depthCompareOp);
        private readonly VulkanCmdSetDepthCompareOp vkCmdSetDepthCompareOp;
        
        public void CmdSetDepthCompareOp(commandBuffer commandBuffer, depthCompareOp depthCompareOp) =>
            this.vkCmdSetDepthCompareOp.Invoke(commandBuffer, depthCompareOp);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthBoundsTestEnable(commandBuffer commandBuffer, depthBoundsTestEnable depthBoundsTestEnable);
        private readonly VulkanCmdSetDepthBoundsTestEnable vkCmdSetDepthBoundsTestEnable;
        
        public void CmdSetDepthBoundsTestEnable(commandBuffer commandBuffer, depthBoundsTestEnable depthBoundsTestEnable) =>
            this.vkCmdSetDepthBoundsTestEnable.Invoke(commandBuffer, depthBoundsTestEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetStencilTestEnable(commandBuffer commandBuffer, stencilTestEnable stencilTestEnable);
        private readonly VulkanCmdSetStencilTestEnable vkCmdSetStencilTestEnable;
        
        public void CmdSetStencilTestEnable(commandBuffer commandBuffer, stencilTestEnable stencilTestEnable) =>
            this.vkCmdSetStencilTestEnable.Invoke(commandBuffer, stencilTestEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetStencilOp(commandBuffer commandBuffer, faceMask faceMask, failOp failOp, passOp passOp, depthFailOp depthFailOp, compareOp compareOp);
        private readonly VulkanCmdSetStencilOp vkCmdSetStencilOp;
        
        public void CmdSetStencilOp(commandBuffer commandBuffer, faceMask faceMask, failOp failOp, passOp passOp, depthFailOp depthFailOp, compareOp compareOp) =>
            this.vkCmdSetStencilOp.Invoke(commandBuffer, faceMask, failOp, passOp, depthFailOp, compareOp);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetRasterizerDiscardEnable(commandBuffer commandBuffer, rasterizerDiscardEnable rasterizerDiscardEnable);
        private readonly VulkanCmdSetRasterizerDiscardEnable vkCmdSetRasterizerDiscardEnable;
        
        public void CmdSetRasterizerDiscardEnable(commandBuffer commandBuffer, rasterizerDiscardEnable rasterizerDiscardEnable) =>
            this.vkCmdSetRasterizerDiscardEnable.Invoke(commandBuffer, rasterizerDiscardEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetDepthBiasEnable(commandBuffer commandBuffer, depthBiasEnable depthBiasEnable);
        private readonly VulkanCmdSetDepthBiasEnable vkCmdSetDepthBiasEnable;
        
        public void CmdSetDepthBiasEnable(commandBuffer commandBuffer, depthBiasEnable depthBiasEnable) =>
            this.vkCmdSetDepthBiasEnable.Invoke(commandBuffer, depthBiasEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VulkanCmdSetPrimitiveRestartEnable(commandBuffer commandBuffer, primitiveRestartEnable primitiveRestartEnable);
        private readonly VulkanCmdSetPrimitiveRestartEnable vkCmdSetPrimitiveRestartEnable;
        
        public void CmdSetPrimitiveRestartEnable(commandBuffer commandBuffer, primitiveRestartEnable primitiveRestartEnable) =>
            this.vkCmdSetPrimitiveRestartEnable.Invoke(commandBuffer, primitiveRestartEnable);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceBufferMemoryRequirements(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetDeviceBufferMemoryRequirements vkGetDeviceBufferMemoryRequirements;
        
        public unsafe void GetDeviceBufferMemoryRequirements(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetDeviceBufferMemoryRequirements.Invoke(device, pInfo, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceImageMemoryRequirements(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements);
        private readonly VulkanGetDeviceImageMemoryRequirements vkGetDeviceImageMemoryRequirements;
        
        public unsafe void GetDeviceImageMemoryRequirements(device device, /*const*/ pInfo* pInfo, pMemoryRequirements* pMemoryRequirements) =>
            this.vkGetDeviceImageMemoryRequirements.Invoke(device, pInfo, pMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetDeviceImageSparseMemoryRequirements(device device, /*const*/ pInfo* pInfo, pSparseMemoryRequirementCount* pSparseMemoryRequirementCount, pSparseMemoryRequirements* pSparseMemoryRequirements);
        private readonly VulkanGetDeviceImageSparseMemoryRequirements vkGetDeviceImageSparseMemoryRequirements;
        
        public unsafe void GetDeviceImageSparseMemoryRequirements(device device, /*const*/ pInfo* pInfo, pSparseMemoryRequirementCount* pSparseMemoryRequirementCount, pSparseMemoryRequirements* pSparseMemoryRequirements) =>
            this.vkGetDeviceImageSparseMemoryRequirements.Invoke(device, pInfo, pSparseMemoryRequirementCount, pSparseMemoryRequirements);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void VulkanGetCommandPoolMemoryConsumption(device device, commandPool commandPool, commandBuffer commandBuffer, pConsumption* pConsumption);
        private readonly VulkanGetCommandPoolMemoryConsumption vkGetCommandPoolMemoryConsumption;
        
        public unsafe void GetCommandPoolMemoryConsumption(device device, commandPool commandPool, commandBuffer commandBuffer, pConsumption* pConsumption) =>
            this.vkGetCommandPoolMemoryConsumption.Invoke(device, commandPool, commandBuffer, pConsumption);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate VkResult VulkanGetFaultData(device device, faultQueryBehavior faultQueryBehavior, pUnrecordedFaults* pUnrecordedFaults, pFaultCount* pFaultCount, pFaults* pFaults);
        private readonly VulkanGetFaultData vkGetFaultData;
        
        public unsafe VkResult GetFaultData(device device, faultQueryBehavior faultQueryBehavior, pUnrecordedFaults* pUnrecordedFaults, pFaultCount* pFaultCount, pFaults* pFaults) =>
            this.vkGetFaultData.Invoke(device, faultQueryBehavior, pUnrecordedFaults, pFaultCount, pFaults);
        
        public Vulkan(GetProcAddressHandler loader)
        {
            vkCreateInstance = Marshal.GetDelegateForFunctionPointer<VulkanCreateInstance>(loader.Invoke("vkCreateInstance"));
            vkDestroyInstance = Marshal.GetDelegateForFunctionPointer<VulkanDestroyInstance>(loader.Invoke("vkDestroyInstance"));
            vkEnumeratePhysicalDevices = Marshal.GetDelegateForFunctionPointer<VulkanEnumeratePhysicalDevices>(loader.Invoke("vkEnumeratePhysicalDevices"));
            vkGetPhysicalDeviceFeatures = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceFeatures>(loader.Invoke("vkGetPhysicalDeviceFeatures"));
            vkGetPhysicalDeviceFormatProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceFormatProperties>(loader.Invoke("vkGetPhysicalDeviceFormatProperties"));
            vkGetPhysicalDeviceImageFormatProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceImageFormatProperties>(loader.Invoke("vkGetPhysicalDeviceImageFormatProperties"));
            vkGetPhysicalDeviceProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceProperties>(loader.Invoke("vkGetPhysicalDeviceProperties"));
            vkGetPhysicalDeviceQueueFamilyProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceQueueFamilyProperties>(loader.Invoke("vkGetPhysicalDeviceQueueFamilyProperties"));
            vkGetPhysicalDeviceMemoryProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceMemoryProperties>(loader.Invoke("vkGetPhysicalDeviceMemoryProperties"));
            vkGetInstanceProcAddr = Marshal.GetDelegateForFunctionPointer<VulkanGetInstanceProcAddr>(loader.Invoke("vkGetInstanceProcAddr"));
            vkGetDeviceProcAddr = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceProcAddr>(loader.Invoke("vkGetDeviceProcAddr"));
            vkCreateDevice = Marshal.GetDelegateForFunctionPointer<VulkanCreateDevice>(loader.Invoke("vkCreateDevice"));
            vkCreateDevice = Marshal.GetDelegateForFunctionPointer<VulkanCreateDevice>(loader.Invoke("vkCreateDevice"));
            vkDestroyDevice = Marshal.GetDelegateForFunctionPointer<VulkanDestroyDevice>(loader.Invoke("vkDestroyDevice"));
            vkEnumerateInstanceExtensionProperties = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateInstanceExtensionProperties>(loader.Invoke("vkEnumerateInstanceExtensionProperties"));
            vkEnumerateDeviceExtensionProperties = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateDeviceExtensionProperties>(loader.Invoke("vkEnumerateDeviceExtensionProperties"));
            vkEnumerateInstanceLayerProperties = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateInstanceLayerProperties>(loader.Invoke("vkEnumerateInstanceLayerProperties"));
            vkEnumerateDeviceLayerProperties = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateDeviceLayerProperties>(loader.Invoke("vkEnumerateDeviceLayerProperties"));
            vkEnumerateDeviceLayerProperties = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateDeviceLayerProperties>(loader.Invoke("vkEnumerateDeviceLayerProperties"));
            vkGetDeviceQueue = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceQueue>(loader.Invoke("vkGetDeviceQueue"));
            vkQueueSubmit = Marshal.GetDelegateForFunctionPointer<VulkanQueueSubmit>(loader.Invoke("vkQueueSubmit"));
            vkQueueWaitIdle = Marshal.GetDelegateForFunctionPointer<VulkanQueueWaitIdle>(loader.Invoke("vkQueueWaitIdle"));
            vkDeviceWaitIdle = Marshal.GetDelegateForFunctionPointer<VulkanDeviceWaitIdle>(loader.Invoke("vkDeviceWaitIdle"));
            vkAllocateMemory = Marshal.GetDelegateForFunctionPointer<VulkanAllocateMemory>(loader.Invoke("vkAllocateMemory"));
            vkMapMemory = Marshal.GetDelegateForFunctionPointer<VulkanMapMemory>(loader.Invoke("vkMapMemory"));
            vkUnmapMemory = Marshal.GetDelegateForFunctionPointer<VulkanUnmapMemory>(loader.Invoke("vkUnmapMemory"));
            vkFlushMappedMemoryRanges = Marshal.GetDelegateForFunctionPointer<VulkanFlushMappedMemoryRanges>(loader.Invoke("vkFlushMappedMemoryRanges"));
            vkInvalidateMappedMemoryRanges = Marshal.GetDelegateForFunctionPointer<VulkanInvalidateMappedMemoryRanges>(loader.Invoke("vkInvalidateMappedMemoryRanges"));
            vkGetDeviceMemoryCommitment = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceMemoryCommitment>(loader.Invoke("vkGetDeviceMemoryCommitment"));
            vkBindBufferMemory = Marshal.GetDelegateForFunctionPointer<VulkanBindBufferMemory>(loader.Invoke("vkBindBufferMemory"));
            vkBindImageMemory = Marshal.GetDelegateForFunctionPointer<VulkanBindImageMemory>(loader.Invoke("vkBindImageMemory"));
            vkGetBufferMemoryRequirements = Marshal.GetDelegateForFunctionPointer<VulkanGetBufferMemoryRequirements>(loader.Invoke("vkGetBufferMemoryRequirements"));
            vkGetImageMemoryRequirements = Marshal.GetDelegateForFunctionPointer<VulkanGetImageMemoryRequirements>(loader.Invoke("vkGetImageMemoryRequirements"));
            vkDestroySwapchainKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroySwapchainKHR>(loader.Invoke("vkDestroySwapchainKHR"));
            vkCreateFence = Marshal.GetDelegateForFunctionPointer<VulkanCreateFence>(loader.Invoke("vkCreateFence"));
            vkDestroyFence = Marshal.GetDelegateForFunctionPointer<VulkanDestroyFence>(loader.Invoke("vkDestroyFence"));
            vkResetFences = Marshal.GetDelegateForFunctionPointer<VulkanResetFences>(loader.Invoke("vkResetFences"));
            vkGetFenceStatus = Marshal.GetDelegateForFunctionPointer<VulkanGetFenceStatus>(loader.Invoke("vkGetFenceStatus"));
            vkWaitForFences = Marshal.GetDelegateForFunctionPointer<VulkanWaitForFences>(loader.Invoke("vkWaitForFences"));
            vkCreateSemaphore = Marshal.GetDelegateForFunctionPointer<VulkanCreateSemaphore>(loader.Invoke("vkCreateSemaphore"));
            vkDestroySemaphore = Marshal.GetDelegateForFunctionPointer<VulkanDestroySemaphore>(loader.Invoke("vkDestroySemaphore"));
            vkCreateEvent = Marshal.GetDelegateForFunctionPointer<VulkanCreateEvent>(loader.Invoke("vkCreateEvent"));
            vkDestroyEvent = Marshal.GetDelegateForFunctionPointer<VulkanDestroyEvent>(loader.Invoke("vkDestroyEvent"));
            vkGetEventStatus = Marshal.GetDelegateForFunctionPointer<VulkanGetEventStatus>(loader.Invoke("vkGetEventStatus"));
            vkSetEvent = Marshal.GetDelegateForFunctionPointer<VulkanSetEvent>(loader.Invoke("vkSetEvent"));
            vkResetEvent = Marshal.GetDelegateForFunctionPointer<VulkanResetEvent>(loader.Invoke("vkResetEvent"));
            vkCreateQueryPool = Marshal.GetDelegateForFunctionPointer<VulkanCreateQueryPool>(loader.Invoke("vkCreateQueryPool"));
            vkGetQueryPoolResults = Marshal.GetDelegateForFunctionPointer<VulkanGetQueryPoolResults>(loader.Invoke("vkGetQueryPoolResults"));
            vkCreateBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCreateBuffer>(loader.Invoke("vkCreateBuffer"));
            vkDestroyBuffer = Marshal.GetDelegateForFunctionPointer<VulkanDestroyBuffer>(loader.Invoke("vkDestroyBuffer"));
            vkCreateBufferView = Marshal.GetDelegateForFunctionPointer<VulkanCreateBufferView>(loader.Invoke("vkCreateBufferView"));
            vkDestroyBufferView = Marshal.GetDelegateForFunctionPointer<VulkanDestroyBufferView>(loader.Invoke("vkDestroyBufferView"));
            vkCreateImage = Marshal.GetDelegateForFunctionPointer<VulkanCreateImage>(loader.Invoke("vkCreateImage"));
            vkDestroyImage = Marshal.GetDelegateForFunctionPointer<VulkanDestroyImage>(loader.Invoke("vkDestroyImage"));
            vkGetImageSubresourceLayout = Marshal.GetDelegateForFunctionPointer<VulkanGetImageSubresourceLayout>(loader.Invoke("vkGetImageSubresourceLayout"));
            vkCreateImageView = Marshal.GetDelegateForFunctionPointer<VulkanCreateImageView>(loader.Invoke("vkCreateImageView"));
            vkDestroyImageView = Marshal.GetDelegateForFunctionPointer<VulkanDestroyImageView>(loader.Invoke("vkDestroyImageView"));
            vkCreatePipelineCache = Marshal.GetDelegateForFunctionPointer<VulkanCreatePipelineCache>(loader.Invoke("vkCreatePipelineCache"));
            vkCreatePipelineCache = Marshal.GetDelegateForFunctionPointer<VulkanCreatePipelineCache>(loader.Invoke("vkCreatePipelineCache"));
            vkDestroyPipelineCache = Marshal.GetDelegateForFunctionPointer<VulkanDestroyPipelineCache>(loader.Invoke("vkDestroyPipelineCache"));
            vkCreateGraphicsPipelines = Marshal.GetDelegateForFunctionPointer<VulkanCreateGraphicsPipelines>(loader.Invoke("vkCreateGraphicsPipelines"));
            vkCreateGraphicsPipelines = Marshal.GetDelegateForFunctionPointer<VulkanCreateGraphicsPipelines>(loader.Invoke("vkCreateGraphicsPipelines"));
            vkCreateComputePipelines = Marshal.GetDelegateForFunctionPointer<VulkanCreateComputePipelines>(loader.Invoke("vkCreateComputePipelines"));
            vkCreateComputePipelines = Marshal.GetDelegateForFunctionPointer<VulkanCreateComputePipelines>(loader.Invoke("vkCreateComputePipelines"));
            vkDestroyPipeline = Marshal.GetDelegateForFunctionPointer<VulkanDestroyPipeline>(loader.Invoke("vkDestroyPipeline"));
            vkCreatePipelineLayout = Marshal.GetDelegateForFunctionPointer<VulkanCreatePipelineLayout>(loader.Invoke("vkCreatePipelineLayout"));
            vkDestroyPipelineLayout = Marshal.GetDelegateForFunctionPointer<VulkanDestroyPipelineLayout>(loader.Invoke("vkDestroyPipelineLayout"));
            vkCreateSampler = Marshal.GetDelegateForFunctionPointer<VulkanCreateSampler>(loader.Invoke("vkCreateSampler"));
            vkDestroySampler = Marshal.GetDelegateForFunctionPointer<VulkanDestroySampler>(loader.Invoke("vkDestroySampler"));
            vkCreateDescriptorSetLayout = Marshal.GetDelegateForFunctionPointer<VulkanCreateDescriptorSetLayout>(loader.Invoke("vkCreateDescriptorSetLayout"));
            vkDestroyDescriptorSetLayout = Marshal.GetDelegateForFunctionPointer<VulkanDestroyDescriptorSetLayout>(loader.Invoke("vkDestroyDescriptorSetLayout"));
            vkCreateDescriptorPool = Marshal.GetDelegateForFunctionPointer<VulkanCreateDescriptorPool>(loader.Invoke("vkCreateDescriptorPool"));
            vkResetDescriptorPool = Marshal.GetDelegateForFunctionPointer<VulkanResetDescriptorPool>(loader.Invoke("vkResetDescriptorPool"));
            vkAllocateDescriptorSets = Marshal.GetDelegateForFunctionPointer<VulkanAllocateDescriptorSets>(loader.Invoke("vkAllocateDescriptorSets"));
            vkFreeDescriptorSets = Marshal.GetDelegateForFunctionPointer<VulkanFreeDescriptorSets>(loader.Invoke("vkFreeDescriptorSets"));
            vkUpdateDescriptorSets = Marshal.GetDelegateForFunctionPointer<VulkanUpdateDescriptorSets>(loader.Invoke("vkUpdateDescriptorSets"));
            vkCreateFramebuffer = Marshal.GetDelegateForFunctionPointer<VulkanCreateFramebuffer>(loader.Invoke("vkCreateFramebuffer"));
            vkDestroyFramebuffer = Marshal.GetDelegateForFunctionPointer<VulkanDestroyFramebuffer>(loader.Invoke("vkDestroyFramebuffer"));
            vkCreateRenderPass = Marshal.GetDelegateForFunctionPointer<VulkanCreateRenderPass>(loader.Invoke("vkCreateRenderPass"));
            vkDestroyRenderPass = Marshal.GetDelegateForFunctionPointer<VulkanDestroyRenderPass>(loader.Invoke("vkDestroyRenderPass"));
            vkGetRenderAreaGranularity = Marshal.GetDelegateForFunctionPointer<VulkanGetRenderAreaGranularity>(loader.Invoke("vkGetRenderAreaGranularity"));
            vkCreateCommandPool = Marshal.GetDelegateForFunctionPointer<VulkanCreateCommandPool>(loader.Invoke("vkCreateCommandPool"));
            vkResetCommandPool = Marshal.GetDelegateForFunctionPointer<VulkanResetCommandPool>(loader.Invoke("vkResetCommandPool"));
            vkAllocateCommandBuffers = Marshal.GetDelegateForFunctionPointer<VulkanAllocateCommandBuffers>(loader.Invoke("vkAllocateCommandBuffers"));
            vkFreeCommandBuffers = Marshal.GetDelegateForFunctionPointer<VulkanFreeCommandBuffers>(loader.Invoke("vkFreeCommandBuffers"));
            vkBeginCommandBuffer = Marshal.GetDelegateForFunctionPointer<VulkanBeginCommandBuffer>(loader.Invoke("vkBeginCommandBuffer"));
            vkEndCommandBuffer = Marshal.GetDelegateForFunctionPointer<VulkanEndCommandBuffer>(loader.Invoke("vkEndCommandBuffer"));
            vkResetCommandBuffer = Marshal.GetDelegateForFunctionPointer<VulkanResetCommandBuffer>(loader.Invoke("vkResetCommandBuffer"));
            vkCmdBindPipeline = Marshal.GetDelegateForFunctionPointer<VulkanCmdBindPipeline>(loader.Invoke("vkCmdBindPipeline"));
            vkCmdSetViewport = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetViewport>(loader.Invoke("vkCmdSetViewport"));
            vkCmdSetScissor = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetScissor>(loader.Invoke("vkCmdSetScissor"));
            vkCmdSetLineWidth = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetLineWidth>(loader.Invoke("vkCmdSetLineWidth"));
            vkCmdSetDepthBias = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthBias>(loader.Invoke("vkCmdSetDepthBias"));
            vkCmdSetBlendConstants = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetBlendConstants>(loader.Invoke("vkCmdSetBlendConstants"));
            vkCmdSetDepthBounds = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthBounds>(loader.Invoke("vkCmdSetDepthBounds"));
            vkCmdSetStencilCompareMask = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetStencilCompareMask>(loader.Invoke("vkCmdSetStencilCompareMask"));
            vkCmdSetStencilWriteMask = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetStencilWriteMask>(loader.Invoke("vkCmdSetStencilWriteMask"));
            vkCmdSetStencilReference = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetStencilReference>(loader.Invoke("vkCmdSetStencilReference"));
            vkCmdBindDescriptorSets = Marshal.GetDelegateForFunctionPointer<VulkanCmdBindDescriptorSets>(loader.Invoke("vkCmdBindDescriptorSets"));
            vkCmdBindIndexBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCmdBindIndexBuffer>(loader.Invoke("vkCmdBindIndexBuffer"));
            vkCmdBindVertexBuffers = Marshal.GetDelegateForFunctionPointer<VulkanCmdBindVertexBuffers>(loader.Invoke("vkCmdBindVertexBuffers"));
            vkCmdDraw = Marshal.GetDelegateForFunctionPointer<VulkanCmdDraw>(loader.Invoke("vkCmdDraw"));
            vkCmdDrawIndexed = Marshal.GetDelegateForFunctionPointer<VulkanCmdDrawIndexed>(loader.Invoke("vkCmdDrawIndexed"));
            vkCmdDrawIndirect = Marshal.GetDelegateForFunctionPointer<VulkanCmdDrawIndirect>(loader.Invoke("vkCmdDrawIndirect"));
            vkCmdDrawIndexedIndirect = Marshal.GetDelegateForFunctionPointer<VulkanCmdDrawIndexedIndirect>(loader.Invoke("vkCmdDrawIndexedIndirect"));
            vkCmdDispatch = Marshal.GetDelegateForFunctionPointer<VulkanCmdDispatch>(loader.Invoke("vkCmdDispatch"));
            vkCmdDispatchIndirect = Marshal.GetDelegateForFunctionPointer<VulkanCmdDispatchIndirect>(loader.Invoke("vkCmdDispatchIndirect"));
            vkCmdCopyBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyBuffer>(loader.Invoke("vkCmdCopyBuffer"));
            vkCmdCopyImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyImage>(loader.Invoke("vkCmdCopyImage"));
            vkCmdBlitImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdBlitImage>(loader.Invoke("vkCmdBlitImage"));
            vkCmdCopyBufferToImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyBufferToImage>(loader.Invoke("vkCmdCopyBufferToImage"));
            vkCmdCopyImageToBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyImageToBuffer>(loader.Invoke("vkCmdCopyImageToBuffer"));
            vkCmdUpdateBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCmdUpdateBuffer>(loader.Invoke("vkCmdUpdateBuffer"));
            vkCmdFillBuffer = Marshal.GetDelegateForFunctionPointer<VulkanCmdFillBuffer>(loader.Invoke("vkCmdFillBuffer"));
            vkCmdClearColorImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdClearColorImage>(loader.Invoke("vkCmdClearColorImage"));
            vkCmdClearDepthStencilImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdClearDepthStencilImage>(loader.Invoke("vkCmdClearDepthStencilImage"));
            vkCmdClearAttachments = Marshal.GetDelegateForFunctionPointer<VulkanCmdClearAttachments>(loader.Invoke("vkCmdClearAttachments"));
            vkCmdResolveImage = Marshal.GetDelegateForFunctionPointer<VulkanCmdResolveImage>(loader.Invoke("vkCmdResolveImage"));
            vkCmdSetEvent = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetEvent>(loader.Invoke("vkCmdSetEvent"));
            vkCmdResetEvent = Marshal.GetDelegateForFunctionPointer<VulkanCmdResetEvent>(loader.Invoke("vkCmdResetEvent"));
            vkCmdWaitEvents = Marshal.GetDelegateForFunctionPointer<VulkanCmdWaitEvents>(loader.Invoke("vkCmdWaitEvents"));
            vkCmdPipelineBarrier = Marshal.GetDelegateForFunctionPointer<VulkanCmdPipelineBarrier>(loader.Invoke("vkCmdPipelineBarrier"));
            vkCmdBeginQuery = Marshal.GetDelegateForFunctionPointer<VulkanCmdBeginQuery>(loader.Invoke("vkCmdBeginQuery"));
            vkCmdEndQuery = Marshal.GetDelegateForFunctionPointer<VulkanCmdEndQuery>(loader.Invoke("vkCmdEndQuery"));
            vkCmdResetQueryPool = Marshal.GetDelegateForFunctionPointer<VulkanCmdResetQueryPool>(loader.Invoke("vkCmdResetQueryPool"));
            vkCmdWriteTimestamp = Marshal.GetDelegateForFunctionPointer<VulkanCmdWriteTimestamp>(loader.Invoke("vkCmdWriteTimestamp"));
            vkCmdCopyQueryPoolResults = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyQueryPoolResults>(loader.Invoke("vkCmdCopyQueryPoolResults"));
            vkCmdPushConstants = Marshal.GetDelegateForFunctionPointer<VulkanCmdPushConstants>(loader.Invoke("vkCmdPushConstants"));
            vkCmdBeginRenderPass = Marshal.GetDelegateForFunctionPointer<VulkanCmdBeginRenderPass>(loader.Invoke("vkCmdBeginRenderPass"));
            vkCmdNextSubpass = Marshal.GetDelegateForFunctionPointer<VulkanCmdNextSubpass>(loader.Invoke("vkCmdNextSubpass"));
            vkCmdEndRenderPass = Marshal.GetDelegateForFunctionPointer<VulkanCmdEndRenderPass>(loader.Invoke("vkCmdEndRenderPass"));
            vkCmdExecuteCommands = Marshal.GetDelegateForFunctionPointer<VulkanCmdExecuteCommands>(loader.Invoke("vkCmdExecuteCommands"));
            vkDestroySurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroySurfaceKHR>(loader.Invoke("vkDestroySurfaceKHR"));
            vkGetPhysicalDeviceSurfaceSupportKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfaceSupportKHR>(loader.Invoke("vkGetPhysicalDeviceSurfaceSupportKHR"));
            vkGetPhysicalDeviceSurfaceCapabilitiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfaceCapabilitiesKHR>(loader.Invoke("vkGetPhysicalDeviceSurfaceCapabilitiesKHR"));
            vkGetPhysicalDeviceSurfaceFormatsKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfaceFormatsKHR>(loader.Invoke("vkGetPhysicalDeviceSurfaceFormatsKHR"));
            vkGetPhysicalDeviceSurfacePresentModesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfacePresentModesKHR>(loader.Invoke("vkGetPhysicalDeviceSurfacePresentModesKHR"));
            vkCreateSwapchainKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateSwapchainKHR>(loader.Invoke("vkCreateSwapchainKHR"));
            vkGetSwapchainImagesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetSwapchainImagesKHR>(loader.Invoke("vkGetSwapchainImagesKHR"));
            vkAcquireNextImageKHR = Marshal.GetDelegateForFunctionPointer<VulkanAcquireNextImageKHR>(loader.Invoke("vkAcquireNextImageKHR"));
            vkQueuePresentKHR = Marshal.GetDelegateForFunctionPointer<VulkanQueuePresentKHR>(loader.Invoke("vkQueuePresentKHR"));
            vkGetDeviceGroupPresentCapabilitiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceGroupPresentCapabilitiesKHR>(loader.Invoke("vkGetDeviceGroupPresentCapabilitiesKHR"));
            vkGetDeviceGroupSurfacePresentModesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceGroupSurfacePresentModesKHR>(loader.Invoke("vkGetDeviceGroupSurfacePresentModesKHR"));
            vkGetPhysicalDevicePresentRectanglesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDevicePresentRectanglesKHR>(loader.Invoke("vkGetPhysicalDevicePresentRectanglesKHR"));
            vkAcquireNextImage2KHR = Marshal.GetDelegateForFunctionPointer<VulkanAcquireNextImage2KHR>(loader.Invoke("vkAcquireNextImage2KHR"));
            vkGetPhysicalDeviceDisplayPropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceDisplayPropertiesKHR>(loader.Invoke("vkGetPhysicalDeviceDisplayPropertiesKHR"));
            vkGetPhysicalDeviceDisplayPlanePropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceDisplayPlanePropertiesKHR>(loader.Invoke("vkGetPhysicalDeviceDisplayPlanePropertiesKHR"));
            vkGetDisplayPlaneSupportedDisplaysKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDisplayPlaneSupportedDisplaysKHR>(loader.Invoke("vkGetDisplayPlaneSupportedDisplaysKHR"));
            vkGetDisplayModePropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDisplayModePropertiesKHR>(loader.Invoke("vkGetDisplayModePropertiesKHR"));
            vkCreateDisplayModeKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateDisplayModeKHR>(loader.Invoke("vkCreateDisplayModeKHR"));
            vkGetDisplayPlaneCapabilitiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDisplayPlaneCapabilitiesKHR>(loader.Invoke("vkGetDisplayPlaneCapabilitiesKHR"));
            vkCreateDisplayPlaneSurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateDisplayPlaneSurfaceKHR>(loader.Invoke("vkCreateDisplayPlaneSurfaceKHR"));
            vkCreateSharedSwapchainsKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateSharedSwapchainsKHR>(loader.Invoke("vkCreateSharedSwapchainsKHR"));
            vkCreateXlibSurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateXlibSurfaceKHR>(loader.Invoke("vkCreateXlibSurfaceKHR"));
            vkGetPhysicalDeviceXlibPresentationSupportKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceXlibPresentationSupportKHR>(loader.Invoke("vkGetPhysicalDeviceXlibPresentationSupportKHR"));
            vkCreateXcbSurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateXcbSurfaceKHR>(loader.Invoke("vkCreateXcbSurfaceKHR"));
            vkGetPhysicalDeviceXcbPresentationSupportKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceXcbPresentationSupportKHR>(loader.Invoke("vkGetPhysicalDeviceXcbPresentationSupportKHR"));
            vkCreateWaylandSurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateWaylandSurfaceKHR>(loader.Invoke("vkCreateWaylandSurfaceKHR"));
            vkGetPhysicalDeviceWaylandPresentationSupportKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceWaylandPresentationSupportKHR>(loader.Invoke("vkGetPhysicalDeviceWaylandPresentationSupportKHR"));
            vkCreateAndroidSurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateAndroidSurfaceKHR>(loader.Invoke("vkCreateAndroidSurfaceKHR"));
            vkCreateWin32SurfaceKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateWin32SurfaceKHR>(loader.Invoke("vkCreateWin32SurfaceKHR"));
            vkGetPhysicalDeviceWin32PresentationSupportKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceWin32PresentationSupportKHR>(loader.Invoke("vkGetPhysicalDeviceWin32PresentationSupportKHR"));
            vkGetPhysicalDeviceVideoCapabilitiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceVideoCapabilitiesKHR>(loader.Invoke("vkGetPhysicalDeviceVideoCapabilitiesKHR"));
            vkGetPhysicalDeviceVideoFormatPropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceVideoFormatPropertiesKHR>(loader.Invoke("vkGetPhysicalDeviceVideoFormatPropertiesKHR"));
            vkCreateVideoSessionKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateVideoSessionKHR>(loader.Invoke("vkCreateVideoSessionKHR"));
            vkDestroyVideoSessionKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroyVideoSessionKHR>(loader.Invoke("vkDestroyVideoSessionKHR"));
            vkGetVideoSessionMemoryRequirementsKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetVideoSessionMemoryRequirementsKHR>(loader.Invoke("vkGetVideoSessionMemoryRequirementsKHR"));
            vkBindVideoSessionMemoryKHR = Marshal.GetDelegateForFunctionPointer<VulkanBindVideoSessionMemoryKHR>(loader.Invoke("vkBindVideoSessionMemoryKHR"));
            vkCreateVideoSessionParametersKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateVideoSessionParametersKHR>(loader.Invoke("vkCreateVideoSessionParametersKHR"));
            vkUpdateVideoSessionParametersKHR = Marshal.GetDelegateForFunctionPointer<VulkanUpdateVideoSessionParametersKHR>(loader.Invoke("vkUpdateVideoSessionParametersKHR"));
            vkDestroyVideoSessionParametersKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroyVideoSessionParametersKHR>(loader.Invoke("vkDestroyVideoSessionParametersKHR"));
            vkCmdBeginVideoCodingKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdBeginVideoCodingKHR>(loader.Invoke("vkCmdBeginVideoCodingKHR"));
            vkCmdEndVideoCodingKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdEndVideoCodingKHR>(loader.Invoke("vkCmdEndVideoCodingKHR"));
            vkCmdControlVideoCodingKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdControlVideoCodingKHR>(loader.Invoke("vkCmdControlVideoCodingKHR"));
            vkCmdDecodeVideoKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdDecodeVideoKHR>(loader.Invoke("vkCmdDecodeVideoKHR"));
            vkGetMemoryWin32HandleKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetMemoryWin32HandleKHR>(loader.Invoke("vkGetMemoryWin32HandleKHR"));
            vkGetMemoryWin32HandlePropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetMemoryWin32HandlePropertiesKHR>(loader.Invoke("vkGetMemoryWin32HandlePropertiesKHR"));
            vkGetMemoryFdKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetMemoryFdKHR>(loader.Invoke("vkGetMemoryFdKHR"));
            vkGetMemoryFdPropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetMemoryFdPropertiesKHR>(loader.Invoke("vkGetMemoryFdPropertiesKHR"));
            vkImportSemaphoreWin32HandleKHR = Marshal.GetDelegateForFunctionPointer<VulkanImportSemaphoreWin32HandleKHR>(loader.Invoke("vkImportSemaphoreWin32HandleKHR"));
            vkGetSemaphoreWin32HandleKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetSemaphoreWin32HandleKHR>(loader.Invoke("vkGetSemaphoreWin32HandleKHR"));
            vkImportSemaphoreFdKHR = Marshal.GetDelegateForFunctionPointer<VulkanImportSemaphoreFdKHR>(loader.Invoke("vkImportSemaphoreFdKHR"));
            vkGetSemaphoreFdKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetSemaphoreFdKHR>(loader.Invoke("vkGetSemaphoreFdKHR"));
            vkCmdPushDescriptorSetKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdPushDescriptorSetKHR>(loader.Invoke("vkCmdPushDescriptorSetKHR"));
            vkCmdPushDescriptorSetWithTemplateKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdPushDescriptorSetWithTemplateKHR>(loader.Invoke("vkCmdPushDescriptorSetWithTemplateKHR"));
            vkGetSwapchainStatusKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetSwapchainStatusKHR>(loader.Invoke("vkGetSwapchainStatusKHR"));
            vkImportFenceWin32HandleKHR = Marshal.GetDelegateForFunctionPointer<VulkanImportFenceWin32HandleKHR>(loader.Invoke("vkImportFenceWin32HandleKHR"));
            vkGetFenceWin32HandleKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetFenceWin32HandleKHR>(loader.Invoke("vkGetFenceWin32HandleKHR"));
            vkImportFenceFdKHR = Marshal.GetDelegateForFunctionPointer<VulkanImportFenceFdKHR>(loader.Invoke("vkImportFenceFdKHR"));
            vkGetFenceFdKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetFenceFdKHR>(loader.Invoke("vkGetFenceFdKHR"));
            vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR = Marshal.GetDelegateForFunctionPointer<VulkanEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR>(loader.Invoke("vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR"));
            vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR>(loader.Invoke("vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR"));
            vkAcquireProfilingLockKHR = Marshal.GetDelegateForFunctionPointer<VulkanAcquireProfilingLockKHR>(loader.Invoke("vkAcquireProfilingLockKHR"));
            vkReleaseProfilingLockKHR = Marshal.GetDelegateForFunctionPointer<VulkanReleaseProfilingLockKHR>(loader.Invoke("vkReleaseProfilingLockKHR"));
            vkGetPhysicalDeviceSurfaceCapabilities2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfaceCapabilities2KHR>(loader.Invoke("vkGetPhysicalDeviceSurfaceCapabilities2KHR"));
            vkGetPhysicalDeviceSurfaceFormats2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceSurfaceFormats2KHR>(loader.Invoke("vkGetPhysicalDeviceSurfaceFormats2KHR"));
            vkGetPhysicalDeviceDisplayProperties2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceDisplayProperties2KHR>(loader.Invoke("vkGetPhysicalDeviceDisplayProperties2KHR"));
            vkGetPhysicalDeviceDisplayPlaneProperties2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceDisplayPlaneProperties2KHR>(loader.Invoke("vkGetPhysicalDeviceDisplayPlaneProperties2KHR"));
            vkGetDisplayModeProperties2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDisplayModeProperties2KHR>(loader.Invoke("vkGetDisplayModeProperties2KHR"));
            vkGetDisplayPlaneCapabilities2KHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDisplayPlaneCapabilities2KHR>(loader.Invoke("vkGetDisplayPlaneCapabilities2KHR"));
            vkCreateAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateAccelerationStructureKHR>(loader.Invoke("vkCreateAccelerationStructureKHR"));
            vkDestroyAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroyAccelerationStructureKHR>(loader.Invoke("vkDestroyAccelerationStructureKHR"));
            vkCmdBuildAccelerationStructuresKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdBuildAccelerationStructuresKHR>(loader.Invoke("vkCmdBuildAccelerationStructuresKHR"));
            vkCmdBuildAccelerationStructuresIndirectKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdBuildAccelerationStructuresIndirectKHR>(loader.Invoke("vkCmdBuildAccelerationStructuresIndirectKHR"));
            vkBuildAccelerationStructuresKHR = Marshal.GetDelegateForFunctionPointer<VulkanBuildAccelerationStructuresKHR>(loader.Invoke("vkBuildAccelerationStructuresKHR"));
            vkCopyAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanCopyAccelerationStructureKHR>(loader.Invoke("vkCopyAccelerationStructureKHR"));
            vkCopyAccelerationStructureToMemoryKHR = Marshal.GetDelegateForFunctionPointer<VulkanCopyAccelerationStructureToMemoryKHR>(loader.Invoke("vkCopyAccelerationStructureToMemoryKHR"));
            vkCopyMemoryToAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanCopyMemoryToAccelerationStructureKHR>(loader.Invoke("vkCopyMemoryToAccelerationStructureKHR"));
            vkWriteAccelerationStructuresPropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanWriteAccelerationStructuresPropertiesKHR>(loader.Invoke("vkWriteAccelerationStructuresPropertiesKHR"));
            vkCmdCopyAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyAccelerationStructureKHR>(loader.Invoke("vkCmdCopyAccelerationStructureKHR"));
            vkCmdCopyAccelerationStructureToMemoryKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyAccelerationStructureToMemoryKHR>(loader.Invoke("vkCmdCopyAccelerationStructureToMemoryKHR"));
            vkCmdCopyMemoryToAccelerationStructureKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyMemoryToAccelerationStructureKHR>(loader.Invoke("vkCmdCopyMemoryToAccelerationStructureKHR"));
            vkGetAccelerationStructureDeviceAddressKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetAccelerationStructureDeviceAddressKHR>(loader.Invoke("vkGetAccelerationStructureDeviceAddressKHR"));
            vkCmdWriteAccelerationStructuresPropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdWriteAccelerationStructuresPropertiesKHR>(loader.Invoke("vkCmdWriteAccelerationStructuresPropertiesKHR"));
            vkGetDeviceAccelerationStructureCompatibilityKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceAccelerationStructureCompatibilityKHR>(loader.Invoke("vkGetDeviceAccelerationStructureCompatibilityKHR"));
            vkGetAccelerationStructureBuildSizesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetAccelerationStructureBuildSizesKHR>(loader.Invoke("vkGetAccelerationStructureBuildSizesKHR"));
            vkCmdTraceRaysKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdTraceRaysKHR>(loader.Invoke("vkCmdTraceRaysKHR"));
            vkCreateRayTracingPipelinesKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateRayTracingPipelinesKHR>(loader.Invoke("vkCreateRayTracingPipelinesKHR"));
            vkCreateRayTracingPipelinesKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateRayTracingPipelinesKHR>(loader.Invoke("vkCreateRayTracingPipelinesKHR"));
            vkGetRayTracingShaderGroupHandlesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetRayTracingShaderGroupHandlesKHR>(loader.Invoke("vkGetRayTracingShaderGroupHandlesKHR"));
            vkGetRayTracingCaptureReplayShaderGroupHandlesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetRayTracingCaptureReplayShaderGroupHandlesKHR>(loader.Invoke("vkGetRayTracingCaptureReplayShaderGroupHandlesKHR"));
            vkCmdTraceRaysIndirectKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdTraceRaysIndirectKHR>(loader.Invoke("vkCmdTraceRaysIndirectKHR"));
            vkGetRayTracingShaderGroupStackSizeKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetRayTracingShaderGroupStackSizeKHR>(loader.Invoke("vkGetRayTracingShaderGroupStackSizeKHR"));
            vkCmdSetRayTracingPipelineStackSizeKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetRayTracingPipelineStackSizeKHR>(loader.Invoke("vkCmdSetRayTracingPipelineStackSizeKHR"));
            vkGetPhysicalDeviceFragmentShadingRatesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceFragmentShadingRatesKHR>(loader.Invoke("vkGetPhysicalDeviceFragmentShadingRatesKHR"));
            vkCmdSetFragmentShadingRateKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetFragmentShadingRateKHR>(loader.Invoke("vkCmdSetFragmentShadingRateKHR"));
            vkWaitForPresentKHR = Marshal.GetDelegateForFunctionPointer<VulkanWaitForPresentKHR>(loader.Invoke("vkWaitForPresentKHR"));
            vkCreateDeferredOperationKHR = Marshal.GetDelegateForFunctionPointer<VulkanCreateDeferredOperationKHR>(loader.Invoke("vkCreateDeferredOperationKHR"));
            vkDestroyDeferredOperationKHR = Marshal.GetDelegateForFunctionPointer<VulkanDestroyDeferredOperationKHR>(loader.Invoke("vkDestroyDeferredOperationKHR"));
            vkGetDeferredOperationMaxConcurrencyKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDeferredOperationMaxConcurrencyKHR>(loader.Invoke("vkGetDeferredOperationMaxConcurrencyKHR"));
            vkGetDeferredOperationResultKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetDeferredOperationResultKHR>(loader.Invoke("vkGetDeferredOperationResultKHR"));
            vkDeferredOperationJoinKHR = Marshal.GetDelegateForFunctionPointer<VulkanDeferredOperationJoinKHR>(loader.Invoke("vkDeferredOperationJoinKHR"));
            vkGetPipelineExecutablePropertiesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPipelineExecutablePropertiesKHR>(loader.Invoke("vkGetPipelineExecutablePropertiesKHR"));
            vkGetPipelineExecutableStatisticsKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPipelineExecutableStatisticsKHR>(loader.Invoke("vkGetPipelineExecutableStatisticsKHR"));
            vkGetPipelineExecutableInternalRepresentationsKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPipelineExecutableInternalRepresentationsKHR>(loader.Invoke("vkGetPipelineExecutableInternalRepresentationsKHR"));
            vkCmdEncodeVideoKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdEncodeVideoKHR>(loader.Invoke("vkCmdEncodeVideoKHR"));
            vkCmdRefreshObjectsKHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdRefreshObjectsKHR>(loader.Invoke("vkCmdRefreshObjectsKHR"));
            vkGetPhysicalDeviceRefreshableObjectTypesKHR = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceRefreshableObjectTypesKHR>(loader.Invoke("vkGetPhysicalDeviceRefreshableObjectTypesKHR"));
            vkCmdWriteBufferMarker2AMD = Marshal.GetDelegateForFunctionPointer<VulkanCmdWriteBufferMarker2AMD>(loader.Invoke("vkCmdWriteBufferMarker2AMD"));
            vkGetQueueCheckpointData2NV = Marshal.GetDelegateForFunctionPointer<VulkanGetQueueCheckpointData2NV>(loader.Invoke("vkGetQueueCheckpointData2NV"));
            vkCmdTraceRaysIndirect2KHR = Marshal.GetDelegateForFunctionPointer<VulkanCmdTraceRaysIndirect2KHR>(loader.Invoke("vkCmdTraceRaysIndirect2KHR"));
            vkEnumerateInstanceVersion = Marshal.GetDelegateForFunctionPointer<VulkanEnumerateInstanceVersion>(loader.Invoke("vkEnumerateInstanceVersion"));
            vkBindBufferMemory2 = Marshal.GetDelegateForFunctionPointer<VulkanBindBufferMemory2>(loader.Invoke("vkBindBufferMemory2"));
            vkBindImageMemory2 = Marshal.GetDelegateForFunctionPointer<VulkanBindImageMemory2>(loader.Invoke("vkBindImageMemory2"));
            vkGetDeviceGroupPeerMemoryFeatures = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceGroupPeerMemoryFeatures>(loader.Invoke("vkGetDeviceGroupPeerMemoryFeatures"));
            vkCmdSetDeviceMask = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDeviceMask>(loader.Invoke("vkCmdSetDeviceMask"));
            vkCmdDispatchBase = Marshal.GetDelegateForFunctionPointer<VulkanCmdDispatchBase>(loader.Invoke("vkCmdDispatchBase"));
            vkEnumeratePhysicalDeviceGroups = Marshal.GetDelegateForFunctionPointer<VulkanEnumeratePhysicalDeviceGroups>(loader.Invoke("vkEnumeratePhysicalDeviceGroups"));
            vkGetImageMemoryRequirements2 = Marshal.GetDelegateForFunctionPointer<VulkanGetImageMemoryRequirements2>(loader.Invoke("vkGetImageMemoryRequirements2"));
            vkGetBufferMemoryRequirements2 = Marshal.GetDelegateForFunctionPointer<VulkanGetBufferMemoryRequirements2>(loader.Invoke("vkGetBufferMemoryRequirements2"));
            vkGetPhysicalDeviceFeatures2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceFeatures2>(loader.Invoke("vkGetPhysicalDeviceFeatures2"));
            vkGetPhysicalDeviceProperties2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceProperties2>(loader.Invoke("vkGetPhysicalDeviceProperties2"));
            vkGetPhysicalDeviceFormatProperties2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceFormatProperties2>(loader.Invoke("vkGetPhysicalDeviceFormatProperties2"));
            vkGetPhysicalDeviceImageFormatProperties2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceImageFormatProperties2>(loader.Invoke("vkGetPhysicalDeviceImageFormatProperties2"));
            vkGetPhysicalDeviceQueueFamilyProperties2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceQueueFamilyProperties2>(loader.Invoke("vkGetPhysicalDeviceQueueFamilyProperties2"));
            vkGetPhysicalDeviceMemoryProperties2 = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceMemoryProperties2>(loader.Invoke("vkGetPhysicalDeviceMemoryProperties2"));
            vkGetDeviceQueue2 = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceQueue2>(loader.Invoke("vkGetDeviceQueue2"));
            vkCreateSamplerYcbcrConversion = Marshal.GetDelegateForFunctionPointer<VulkanCreateSamplerYcbcrConversion>(loader.Invoke("vkCreateSamplerYcbcrConversion"));
            vkDestroySamplerYcbcrConversion = Marshal.GetDelegateForFunctionPointer<VulkanDestroySamplerYcbcrConversion>(loader.Invoke("vkDestroySamplerYcbcrConversion"));
            vkGetPhysicalDeviceExternalBufferProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceExternalBufferProperties>(loader.Invoke("vkGetPhysicalDeviceExternalBufferProperties"));
            vkGetPhysicalDeviceExternalFenceProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceExternalFenceProperties>(loader.Invoke("vkGetPhysicalDeviceExternalFenceProperties"));
            vkGetPhysicalDeviceExternalSemaphoreProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceExternalSemaphoreProperties>(loader.Invoke("vkGetPhysicalDeviceExternalSemaphoreProperties"));
            vkGetDescriptorSetLayoutSupport = Marshal.GetDelegateForFunctionPointer<VulkanGetDescriptorSetLayoutSupport>(loader.Invoke("vkGetDescriptorSetLayoutSupport"));
            vkCmdDrawIndirectCount = Marshal.GetDelegateForFunctionPointer<VulkanCmdDrawIndirectCount>(loader.Invoke("vkCmdDrawIndirectCount"));
            vkCmdDrawIndexedIndirectCount = Marshal.GetDelegateForFunctionPointer<VulkanCmdDrawIndexedIndirectCount>(loader.Invoke("vkCmdDrawIndexedIndirectCount"));
            vkCreateRenderPass2 = Marshal.GetDelegateForFunctionPointer<VulkanCreateRenderPass2>(loader.Invoke("vkCreateRenderPass2"));
            vkCmdBeginRenderPass2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdBeginRenderPass2>(loader.Invoke("vkCmdBeginRenderPass2"));
            vkCmdNextSubpass2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdNextSubpass2>(loader.Invoke("vkCmdNextSubpass2"));
            vkCmdEndRenderPass2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdEndRenderPass2>(loader.Invoke("vkCmdEndRenderPass2"));
            vkResetQueryPool = Marshal.GetDelegateForFunctionPointer<VulkanResetQueryPool>(loader.Invoke("vkResetQueryPool"));
            vkGetSemaphoreCounterValue = Marshal.GetDelegateForFunctionPointer<VulkanGetSemaphoreCounterValue>(loader.Invoke("vkGetSemaphoreCounterValue"));
            vkWaitSemaphores = Marshal.GetDelegateForFunctionPointer<VulkanWaitSemaphores>(loader.Invoke("vkWaitSemaphores"));
            vkSignalSemaphore = Marshal.GetDelegateForFunctionPointer<VulkanSignalSemaphore>(loader.Invoke("vkSignalSemaphore"));
            vkGetBufferDeviceAddress = Marshal.GetDelegateForFunctionPointer<VulkanGetBufferDeviceAddress>(loader.Invoke("vkGetBufferDeviceAddress"));
            vkGetBufferOpaqueCaptureAddress = Marshal.GetDelegateForFunctionPointer<VulkanGetBufferOpaqueCaptureAddress>(loader.Invoke("vkGetBufferOpaqueCaptureAddress"));
            vkGetDeviceMemoryOpaqueCaptureAddress = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceMemoryOpaqueCaptureAddress>(loader.Invoke("vkGetDeviceMemoryOpaqueCaptureAddress"));
            vkGetPhysicalDeviceToolProperties = Marshal.GetDelegateForFunctionPointer<VulkanGetPhysicalDeviceToolProperties>(loader.Invoke("vkGetPhysicalDeviceToolProperties"));
            vkCreatePrivateDataSlot = Marshal.GetDelegateForFunctionPointer<VulkanCreatePrivateDataSlot>(loader.Invoke("vkCreatePrivateDataSlot"));
            vkDestroyPrivateDataSlot = Marshal.GetDelegateForFunctionPointer<VulkanDestroyPrivateDataSlot>(loader.Invoke("vkDestroyPrivateDataSlot"));
            vkSetPrivateData = Marshal.GetDelegateForFunctionPointer<VulkanSetPrivateData>(loader.Invoke("vkSetPrivateData"));
            vkGetPrivateData = Marshal.GetDelegateForFunctionPointer<VulkanGetPrivateData>(loader.Invoke("vkGetPrivateData"));
            vkCmdSetEvent2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetEvent2>(loader.Invoke("vkCmdSetEvent2"));
            vkCmdResetEvent2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdResetEvent2>(loader.Invoke("vkCmdResetEvent2"));
            vkCmdWaitEvents2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdWaitEvents2>(loader.Invoke("vkCmdWaitEvents2"));
            vkCmdPipelineBarrier2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdPipelineBarrier2>(loader.Invoke("vkCmdPipelineBarrier2"));
            vkCmdWriteTimestamp2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdWriteTimestamp2>(loader.Invoke("vkCmdWriteTimestamp2"));
            vkQueueSubmit2 = Marshal.GetDelegateForFunctionPointer<VulkanQueueSubmit2>(loader.Invoke("vkQueueSubmit2"));
            vkCmdCopyBuffer2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyBuffer2>(loader.Invoke("vkCmdCopyBuffer2"));
            vkCmdCopyImage2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyImage2>(loader.Invoke("vkCmdCopyImage2"));
            vkCmdCopyBufferToImage2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyBufferToImage2>(loader.Invoke("vkCmdCopyBufferToImage2"));
            vkCmdCopyImageToBuffer2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdCopyImageToBuffer2>(loader.Invoke("vkCmdCopyImageToBuffer2"));
            vkCmdBlitImage2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdBlitImage2>(loader.Invoke("vkCmdBlitImage2"));
            vkCmdResolveImage2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdResolveImage2>(loader.Invoke("vkCmdResolveImage2"));
            vkCmdBeginRendering = Marshal.GetDelegateForFunctionPointer<VulkanCmdBeginRendering>(loader.Invoke("vkCmdBeginRendering"));
            vkCmdEndRendering = Marshal.GetDelegateForFunctionPointer<VulkanCmdEndRendering>(loader.Invoke("vkCmdEndRendering"));
            vkCmdSetCullMode = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetCullMode>(loader.Invoke("vkCmdSetCullMode"));
            vkCmdSetFrontFace = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetFrontFace>(loader.Invoke("vkCmdSetFrontFace"));
            vkCmdSetPrimitiveTopology = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetPrimitiveTopology>(loader.Invoke("vkCmdSetPrimitiveTopology"));
            vkCmdSetViewportWithCount = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetViewportWithCount>(loader.Invoke("vkCmdSetViewportWithCount"));
            vkCmdSetScissorWithCount = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetScissorWithCount>(loader.Invoke("vkCmdSetScissorWithCount"));
            vkCmdBindVertexBuffers2 = Marshal.GetDelegateForFunctionPointer<VulkanCmdBindVertexBuffers2>(loader.Invoke("vkCmdBindVertexBuffers2"));
            vkCmdSetDepthTestEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthTestEnable>(loader.Invoke("vkCmdSetDepthTestEnable"));
            vkCmdSetDepthWriteEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthWriteEnable>(loader.Invoke("vkCmdSetDepthWriteEnable"));
            vkCmdSetDepthCompareOp = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthCompareOp>(loader.Invoke("vkCmdSetDepthCompareOp"));
            vkCmdSetDepthBoundsTestEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthBoundsTestEnable>(loader.Invoke("vkCmdSetDepthBoundsTestEnable"));
            vkCmdSetStencilTestEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetStencilTestEnable>(loader.Invoke("vkCmdSetStencilTestEnable"));
            vkCmdSetStencilOp = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetStencilOp>(loader.Invoke("vkCmdSetStencilOp"));
            vkCmdSetRasterizerDiscardEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetRasterizerDiscardEnable>(loader.Invoke("vkCmdSetRasterizerDiscardEnable"));
            vkCmdSetDepthBiasEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetDepthBiasEnable>(loader.Invoke("vkCmdSetDepthBiasEnable"));
            vkCmdSetPrimitiveRestartEnable = Marshal.GetDelegateForFunctionPointer<VulkanCmdSetPrimitiveRestartEnable>(loader.Invoke("vkCmdSetPrimitiveRestartEnable"));
            vkGetDeviceBufferMemoryRequirements = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceBufferMemoryRequirements>(loader.Invoke("vkGetDeviceBufferMemoryRequirements"));
            vkGetDeviceImageMemoryRequirements = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceImageMemoryRequirements>(loader.Invoke("vkGetDeviceImageMemoryRequirements"));
            vkGetDeviceImageSparseMemoryRequirements = Marshal.GetDelegateForFunctionPointer<VulkanGetDeviceImageSparseMemoryRequirements>(loader.Invoke("vkGetDeviceImageSparseMemoryRequirements"));
            vkGetCommandPoolMemoryConsumption = Marshal.GetDelegateForFunctionPointer<VulkanGetCommandPoolMemoryConsumption>(loader.Invoke("vkGetCommandPoolMemoryConsumption"));
            vkGetFaultData = Marshal.GetDelegateForFunctionPointer<VulkanGetFaultData>(loader.Invoke("vkGetFaultData"));
        }
    }
}
