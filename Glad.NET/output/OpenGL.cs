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
    class GLExtensionAttribute : Attribute
    {
        public string Name { get; }

        public GLExtensionAttribute(string name) => Name = name;
    }


[Flags]
public enum AttribMask : uint
{
    CurrentBit = 0x00000001,
    PointBit = 0x00000002,
    LineBit = 0x00000004,
    PolygonBit = 0x00000008,
    PolygonStippleBit = 0x00000010,
    PixelModeBit = 0x00000020,
    LightingBit = 0x00000040,
    FogBit = 0x00000080,
    DepthBufferBit = 0x00000100,
    AccumBufferBit = 0x00000200,
    StencilBufferBit = 0x00000400,
    ViewportBit = 0x00000800,
    TransformBit = 0x00001000,
    EnableBit = 0x00002000,
    ColorBufferBit = 0x00004000,
    HintBit = 0x00008000,
    EvalBit = 0x00010000,
    ListBit = 0x00020000,
    TextureBit = 0x00040000,
    ScissorBit = 0x00080000,
    MultisampleBit = 0x20000000,

    [GLExtension("GL_ARB_multisample")]
    MultisampleBitARB = 0x20000000,
    AllAttribBits = 0xFFFFFFFF,
}

[Flags]
public enum ClearBufferMask : uint
{
    DepthBufferBit = 0x00000100,
    AccumBufferBit = 0x00000200,
    StencilBufferBit = 0x00000400,
    ColorBufferBit = 0x00004000,
}

[Flags]
public enum BufferStorageMask : uint
{
    DynamicStorageBit = 0x0100,
    ClientStorageBit = 0x0200,

    [GLExtension("GL_ARB_sparse_buffer")]
    SparseStorageBitARB = 0x0400,
    MapReadBit = 0x0001,
    MapWriteBit = 0x0002,
    MapPersistentBit = 0x0040,
    MapCoherentBit = 0x0080,
}

[Flags]
public enum ClientAttribMask : uint
{
    ClientPixelStoreBit = 0x00000001,
    ClientVertexArrayBit = 0x00000002,
    ClientAllAttribBits = 0xFFFFFFFF,
}

[Flags]
public enum ContextFlagMask : uint
{
    ContextFlagForwardCompatibleBit = 0x00000001,
    ContextFlagDebugBit = 0x00000002,

    [GLExtension("GL_KHR_debug")]
    ContextFlagDebugBitKhr = 0x00000002,
    ContextFlagRobustAccessBit = 0x00000004,

    [GLExtension("GL_ARB_robustness")]
    ContextFlagRobustAccessBitARB = 0x00000004,
    ContextFlagNoErrorBit = 0x00000008,

    [GLExtension("GL_KHR_no_error")]
    ContextFlagNoErrorBitKhr = 0x00000008,
}

[Flags]
public enum ContextProfileMask : uint
{
    ContextCoreProfileBit = 0x00000001,
    ContextCompatibilityProfileBit = 0x00000002,
}

[Flags]
public enum MapBufferAccessMask : uint
{
    MapReadBit = 0x0001,
    MapWriteBit = 0x0002,
    MapInvalidateRangeBit = 0x0004,
    MapInvalidateBufferBit = 0x0008,
    MapFlushExplicitBit = 0x0010,
    MapUnsynchronizedBit = 0x0020,
    MapPersistentBit = 0x0040,
    MapCoherentBit = 0x0080,
}

[Flags]
public enum MemoryBarrierMask : uint
{
    VertexAttribArrayBarrierBit = 0x00000001,
    ElementArrayBarrierBit = 0x00000002,
    UniformBarrierBit = 0x00000004,
    TextureFetchBarrierBit = 0x00000008,
    ShaderImageAccessBarrierBit = 0x00000020,
    CommandBarrierBit = 0x00000040,
    PixelBufferBarrierBit = 0x00000080,
    TextureUpdateBarrierBit = 0x00000100,
    BufferUpdateBarrierBit = 0x00000200,
    FramebufferBarrierBit = 0x00000400,
    TransformFeedbackBarrierBit = 0x00000800,
    AtomicCounterBarrierBit = 0x00001000,
    ShaderStorageBarrierBit = 0x00002000,
    ClientMappedBufferBarrierBit = 0x00004000,
    QueryBufferBarrierBit = 0x00008000,
    AllBarrierBits = 0xFFFFFFFF,
}

[Flags]
public enum SyncObjectMask : uint
{
    SyncFlushCommandsBit = 0x00000001,
}

[Flags]
public enum UseProgramStageMask : uint
{
    VertexShaderBit = 0x00000001,
    FragmentShaderBit = 0x00000002,
    GeometryShaderBit = 0x00000004,
    TessControlShaderBit = 0x00000008,
    TessEvaluationShaderBit = 0x00000010,
    ComputeShaderBit = 0x00000020,
    AllShaderBits = 0xFFFFFFFF,
}

[Flags]
public enum SubgroupSupportedFeatures : uint
{

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureBasicBitKhr = 0x00000001,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureVoteBitKhr = 0x00000002,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureArithmeticBitKhr = 0x00000004,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureBallotBitKhr = 0x00000008,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureShuffleBitKhr = 0x00000010,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureShuffleRelativeBitKhr = 0x00000020,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureClusteredBitKhr = 0x00000040,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureQuadBitKhr = 0x00000080,
}

[Flags]
public enum FragmentShaderDestMaskATI : uint
{
    None = 0,
}

[Flags]
public enum FragmentShaderDestModMaskATI : uint
{
    None = 0,
}

[Flags]
public enum TraceMaskMESA : uint
{
    TraceOperationsBitMESA = 0x0001,
    TracePrimitivesBitMESA = 0x0002,
    TraceArraysBitMESA = 0x0004,
    TraceTexturesBitMESA = 0x0008,
    TracePixelsBitMESA = 0x0010,
    TraceErrorsBitMESA = 0x0020,
    TraceAllBitsMESA = 0xFFFF,
}

public enum PathFontStyle
{
    None = 0,
}

public enum Boolean
{
    False = 0,
    True = 1,
}

public enum VertexShaderWriteMaskEXT
{
    False = 0,
    True = 1,
}

public enum ClampColorModeARB
{
    False = 0,
    True = 1,
    FixedOnly = 0x891D,

    [GLExtension("GL_ARB_color_buffer_float")]
    FixedOnlyARB = 0x891D,
}

public enum GraphicsResetStatus
{
    NoError = 0,
    GuiltyContextReset = 0x8253,
    InnocentContextReset = 0x8254,
    UnknownContextReset = 0x8255,
}

public enum ErrorCode
{
    NoError = 0,
    InvalidEnum = 0x0500,
    InvalidValue = 0x0501,
    InvalidOperation = 0x0502,
    StackOverflow = 0x0503,
    StackUnderflow = 0x0504,
    OutOfMemory = 0x0505,
    InvalidFramebufferOperation = 0x0506,

    [GLExtension("GL_ARB_imaging")]
    TableTooLarge = 0x8031,
}

public enum TextureSwizzle
{
    Zero = 0,
    One = 1,
    Red = 0x1903,
    Green = 0x1904,
    Blue = 0x1905,
    Alpha = 0x1906,
}

public enum StencilOp
{
    Zero = 0,
    Invert = 0x150A,
    Keep = 0x1E00,
    Replace = 0x1E01,
    Incr = 0x1E02,
    Decr = 0x1E03,
    IncrWrap = 0x8507,
    DecrWrap = 0x8508,
}

public enum BlendingFactor
{
    Zero = 0,
    One = 1,
    SrcColor = 0x0300,
    OneMinusSrcColor = 0x0301,
    SrcAlpha = 0x0302,
    OneMinusSrcAlpha = 0x0303,
    DstAlpha = 0x0304,
    OneMinusDstAlpha = 0x0305,
    DstColor = 0x0306,
    OneMinusDstColor = 0x0307,
    SrcAlphaSaturate = 0x0308,
    ConstantColor = 0x8001,
    OneMinusConstantColor = 0x8002,
    ConstantAlpha = 0x8003,
    OneMinusConstantAlpha = 0x8004,
    Src1Alpha = 0x8589,
    Src1Color = 0x88F9,
    OneMinusSrc1Color = 0x88FA,
    OneMinusSrc1Alpha = 0x88FB,
}

public enum FragmentShaderGenericSourceATI
{
    Zero = 0,
    One = 1,
    PrimaryColor = 0x8577,

    [GLExtension("GL_ARB_texture_env_combine")]
    PrimaryColorARB = 0x8577,
}

public enum FragmentShaderValueRepATI
{
    None = 0,
    Red = 0x1903,
    Green = 0x1904,
    Blue = 0x1905,
    Alpha = 0x1906,
}

public enum SyncBehaviorFlags
{
    None = 0,
}

public enum TextureCompareMode
{
    None = 0,
    CompareRToTexture = 0x884E,
    CompareRefToTexture = 0x884E,
}

public enum PathColorFormat
{
    None = 0,
    Alpha = 0x1906,
    Rgb = 0x1907,
    Rgba = 0x1908,
    Luminance = 0x1909,
    LuminanceAlpha = 0x190A,
    Intensity = 0x8049,
}

public enum CombinerBiasNV
{
    None = 0,
}

public enum CombinerScaleNV
{
    None = 0,
}

public enum DrawBufferMode
{
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Back = 0x0405,
    Left = 0x0406,
    Right = 0x0407,
    FrontAndBack = 0x0408,
    Aux0 = 0x0409,
    Aux1 = 0x040A,
    Aux2 = 0x040B,
    Aux3 = 0x040C,
    ColorAttachment0 = 0x8CE0,
    ColorAttachment1 = 0x8CE1,
    ColorAttachment2 = 0x8CE2,
    ColorAttachment3 = 0x8CE3,
    ColorAttachment4 = 0x8CE4,
    ColorAttachment5 = 0x8CE5,
    ColorAttachment6 = 0x8CE6,
    ColorAttachment7 = 0x8CE7,
    ColorAttachment8 = 0x8CE8,
    ColorAttachment9 = 0x8CE9,
    ColorAttachment10 = 0x8CEA,
    ColorAttachment11 = 0x8CEB,
    ColorAttachment12 = 0x8CEC,
    ColorAttachment13 = 0x8CED,
    ColorAttachment14 = 0x8CEE,
    ColorAttachment15 = 0x8CEF,
    ColorAttachment16 = 0x8CF0,
    ColorAttachment17 = 0x8CF1,
    ColorAttachment18 = 0x8CF2,
    ColorAttachment19 = 0x8CF3,
    ColorAttachment20 = 0x8CF4,
    ColorAttachment21 = 0x8CF5,
    ColorAttachment22 = 0x8CF6,
    ColorAttachment23 = 0x8CF7,
    ColorAttachment24 = 0x8CF8,
    ColorAttachment25 = 0x8CF9,
    ColorAttachment26 = 0x8CFA,
    ColorAttachment27 = 0x8CFB,
    ColorAttachment28 = 0x8CFC,
    ColorAttachment29 = 0x8CFD,
    ColorAttachment30 = 0x8CFE,
    ColorAttachment31 = 0x8CFF,
}

public enum PixelTexGenModeSGIX
{
    None = 0,
    Alpha = 0x1906,
    Rgb = 0x1907,
    Rgba = 0x1908,
    PixelTexGenQCeilingSGIX = 0x8184,
    PixelTexGenQRoundSGIX = 0x8185,
    PixelTexGenQFloorSGIX = 0x8186,
    PixelTexGenAlphaLsSGIX = 0x8189,
    PixelTexGenAlphaMsSGIX = 0x818A,
}

public enum ReadBufferMode
{
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Back = 0x0405,
    Left = 0x0406,
    Right = 0x0407,
    Aux0 = 0x0409,
    Aux1 = 0x040A,
    Aux2 = 0x040B,
    Aux3 = 0x040C,
    ColorAttachment0 = 0x8CE0,
    ColorAttachment1 = 0x8CE1,
    ColorAttachment2 = 0x8CE2,
    ColorAttachment3 = 0x8CE3,
    ColorAttachment4 = 0x8CE4,
    ColorAttachment5 = 0x8CE5,
    ColorAttachment6 = 0x8CE6,
    ColorAttachment7 = 0x8CE7,
    ColorAttachment8 = 0x8CE8,
    ColorAttachment9 = 0x8CE9,
    ColorAttachment10 = 0x8CEA,
    ColorAttachment11 = 0x8CEB,
    ColorAttachment12 = 0x8CEC,
    ColorAttachment13 = 0x8CED,
    ColorAttachment14 = 0x8CEE,
    ColorAttachment15 = 0x8CEF,
}

public enum ColorBuffer
{
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Back = 0x0405,
    Left = 0x0406,
    Right = 0x0407,
    FrontAndBack = 0x0408,
    ColorAttachment0 = 0x8CE0,
    ColorAttachment1 = 0x8CE1,
    ColorAttachment2 = 0x8CE2,
    ColorAttachment3 = 0x8CE3,
    ColorAttachment4 = 0x8CE4,
    ColorAttachment5 = 0x8CE5,
    ColorAttachment6 = 0x8CE6,
    ColorAttachment7 = 0x8CE7,
    ColorAttachment8 = 0x8CE8,
    ColorAttachment9 = 0x8CE9,
    ColorAttachment10 = 0x8CEA,
    ColorAttachment11 = 0x8CEB,
    ColorAttachment12 = 0x8CEC,
    ColorAttachment13 = 0x8CED,
    ColorAttachment14 = 0x8CEE,
    ColorAttachment15 = 0x8CEF,
    ColorAttachment16 = 0x8CF0,
    ColorAttachment17 = 0x8CF1,
    ColorAttachment18 = 0x8CF2,
    ColorAttachment19 = 0x8CF3,
    ColorAttachment20 = 0x8CF4,
    ColorAttachment21 = 0x8CF5,
    ColorAttachment22 = 0x8CF6,
    ColorAttachment23 = 0x8CF7,
    ColorAttachment24 = 0x8CF8,
    ColorAttachment25 = 0x8CF9,
    ColorAttachment26 = 0x8CFA,
    ColorAttachment27 = 0x8CFB,
    ColorAttachment28 = 0x8CFC,
    ColorAttachment29 = 0x8CFD,
    ColorAttachment30 = 0x8CFE,
    ColorAttachment31 = 0x8CFF,
}

public enum PathGenMode
{
    None = 0,
    EyeLinear = 0x2400,
    ObjectLinear = 0x2401,
    Constant = 0x8576,
}

public enum PathTransformType
{
    None = 0,
}

public enum PrimitiveType
{
    Points = 0x0000,
    Lines = 0x0001,
    LineLoop = 0x0002,
    LineStrip = 0x0003,
    Triangles = 0x0004,
    TriangleStrip = 0x0005,
    TriangleFan = 0x0006,
    Quads = 0x0007,
    QuadStrip = 0x0008,
    Polygon = 0x0009,
    LinesAdjacency = 0x000A,

    [GLExtension("GL_ARB_geometry_shader4")]
    LinesAdjacencyARB = 0x000A,
    LineStripAdjacency = 0x000B,

    [GLExtension("GL_ARB_geometry_shader4")]
    LineStripAdjacencyARB = 0x000B,
    TrianglesAdjacency = 0x000C,

    [GLExtension("GL_ARB_geometry_shader4")]
    TrianglesAdjacencyARB = 0x000C,
    TriangleStripAdjacency = 0x000D,

    [GLExtension("GL_ARB_geometry_shader4")]
    TriangleStripAdjacencyARB = 0x000D,
    Patches = 0x000E,
}

public enum GlEnum
{

    [GLExtension("GL_KHR_debug")]
    StackOverflowKhr = 0x0503,

    [GLExtension("GL_KHR_debug")]
    StackUnderflowKhr = 0x0504,
    ContextLost = 0x0507,

    [GLExtension("GL_KHR_robustness")]
    ContextLostKhr = 0x0507,
    TextureTarget = 0x1006,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview0ARB = 0x1700,
    RescaleNormal = 0x803A,
    Texture3DBindingOES = 0x806A,
    TextureDepth = 0x8071,

    [GLExtension("GL_KHR_debug")]
    VertexArrayKhr = 0x8074,

    [GLExtension("GL_ARB_multisample")]
    MultisampleARB = 0x809D,

    [GLExtension("GL_ARB_multisample")]
    SampleAlphaToCoverageARB = 0x809E,

    [GLExtension("GL_ARB_multisample")]
    SampleAlphaToOneARB = 0x809F,

    [GLExtension("GL_ARB_multisample")]
    SampleCoverageARB = 0x80A0,

    [GLExtension("GL_ARB_multisample")]
    SampleBuffersARB = 0x80A8,

    [GLExtension("GL_ARB_multisample")]
    SamplesARB = 0x80A9,

    [GLExtension("GL_ARB_multisample")]
    SampleCoverageValueARB = 0x80AA,

    [GLExtension("GL_ARB_multisample")]
    SampleCoverageInvertARB = 0x80AB,

    [GLExtension("GL_ARB_imaging")]
    ColorMatrix = 0x80B1,

    [GLExtension("GL_ARB_imaging")]
    ColorMatrixStackDepth = 0x80B2,

    [GLExtension("GL_ARB_imaging")]
    MaxColorMatrixStackDepth = 0x80B3,

    [GLExtension("GL_ARB_shadow_ambient")]
    TextureCompareFailValueARB = 0x80BF,

    [GLExtension("GL_ARB_indirect_parameters")]
    ParameterBufferARB = 0x80EE,
    ParameterBufferBinding = 0x80EF,

    [GLExtension("GL_ARB_indirect_parameters")]
    ParameterBufferBindingARB = 0x80EF,

    [GLExtension("GL_ARB_imaging")]
    ConstantBorder = 0x8151,

    [GLExtension("GL_ARB_imaging")]
    ReplicateBorder = 0x8153,
    FramebufferDefault = 0x8218,
    PrimitiveRestartForPatchesSupported = 0x8221,
    Index = 0x8222,

    [GLExtension("GL_ARB_cl_event")]
    SyncClEventARB = 0x8240,

    [GLExtension("GL_ARB_cl_event")]
    SyncClEventCompleteARB = 0x8241,

    [GLExtension("GL_ARB_debug_output")]
    DebugOutputSynchronousARB = 0x8242,

    [GLExtension("GL_KHR_debug")]
    DebugOutputSynchronousKhr = 0x8242,
    DebugNextLoggedMessageLength = 0x8243,

    [GLExtension("GL_ARB_debug_output")]
    DebugNextLoggedMessageLengthARB = 0x8243,

    [GLExtension("GL_KHR_debug")]
    DebugNextLoggedMessageLengthKhr = 0x8243,

    [GLExtension("GL_ARB_debug_output")]
    DebugCallbackFunctionARB = 0x8244,

    [GLExtension("GL_KHR_debug")]
    DebugCallbackFunctionKhr = 0x8244,

    [GLExtension("GL_ARB_debug_output")]
    DebugCallbackUserParamARB = 0x8245,

    [GLExtension("GL_KHR_debug")]
    DebugCallbackUserParamKhr = 0x8245,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceApiARB = 0x8246,

    [GLExtension("GL_KHR_debug")]
    DebugSourceApiKhr = 0x8246,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceWindowSystemARB = 0x8247,

    [GLExtension("GL_KHR_debug")]
    DebugSourceWindowSystemKhr = 0x8247,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceShaderCompilerARB = 0x8248,

    [GLExtension("GL_KHR_debug")]
    DebugSourceShaderCompilerKhr = 0x8248,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceThirdPartyARB = 0x8249,

    [GLExtension("GL_KHR_debug")]
    DebugSourceThirdPartyKhr = 0x8249,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceApplicationARB = 0x824A,

    [GLExtension("GL_KHR_debug")]
    DebugSourceApplicationKhr = 0x824A,

    [GLExtension("GL_ARB_debug_output")]
    DebugSourceOtherARB = 0x824B,

    [GLExtension("GL_KHR_debug")]
    DebugSourceOtherKhr = 0x824B,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypeErrorARB = 0x824C,

    [GLExtension("GL_KHR_debug")]
    DebugTypeErrorKhr = 0x824C,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypeDeprecatedBehaviorARB = 0x824D,

    [GLExtension("GL_KHR_debug")]
    DebugTypeDeprecatedBehaviorKhr = 0x824D,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypeUndefinedBehaviorARB = 0x824E,

    [GLExtension("GL_KHR_debug")]
    DebugTypeUndefinedBehaviorKhr = 0x824E,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypePortabilityARB = 0x824F,

    [GLExtension("GL_KHR_debug")]
    DebugTypePortabilityKhr = 0x824F,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypePerformanceARB = 0x8250,

    [GLExtension("GL_KHR_debug")]
    DebugTypePerformanceKhr = 0x8250,

    [GLExtension("GL_ARB_debug_output")]
    DebugTypeOtherARB = 0x8251,

    [GLExtension("GL_KHR_debug")]
    DebugTypeOtherKhr = 0x8251,
    LoseContextOnReset = 0x8252,

    [GLExtension("GL_ARB_robustness")]
    LoseContextOnResetARB = 0x8252,

    [GLExtension("GL_KHR_robustness")]
    LoseContextOnResetKhr = 0x8252,

    [GLExtension("GL_ARB_robustness")]
    GuiltyContextResetARB = 0x8253,

    [GLExtension("GL_KHR_robustness")]
    GuiltyContextResetKhr = 0x8253,

    [GLExtension("GL_ARB_robustness")]
    InnocentContextResetARB = 0x8254,

    [GLExtension("GL_KHR_robustness")]
    InnocentContextResetKhr = 0x8254,

    [GLExtension("GL_ARB_robustness")]
    UnknownContextResetARB = 0x8255,

    [GLExtension("GL_KHR_robustness")]
    UnknownContextResetKhr = 0x8255,
    ResetNotificationStrategy = 0x8256,

    [GLExtension("GL_ARB_robustness")]
    ResetNotificationStrategyARB = 0x8256,

    [GLExtension("GL_KHR_robustness")]
    ResetNotificationStrategyKhr = 0x8256,
    ViewportSubpixelBitsEXT = 0x825C,
    ViewportBoundsRangeEXT = 0x825D,
    ViewportIndexProvokingVertexEXT = 0x825F,
    UndefinedVertex = 0x8260,
    NoResetNotification = 0x8261,

    [GLExtension("GL_ARB_robustness")]
    NoResetNotificationARB = 0x8261,

    [GLExtension("GL_KHR_robustness")]
    NoResetNotificationKhr = 0x8261,
    MaxComputeSharedMemorySize = 0x8262,

    [GLExtension("GL_KHR_debug")]
    DebugTypeMarkerKhr = 0x8268,

    [GLExtension("GL_KHR_debug")]
    DebugTypePushGroupKhr = 0x8269,

    [GLExtension("GL_KHR_debug")]
    DebugTypePopGroupKhr = 0x826A,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityNotificationKhr = 0x826B,

    [GLExtension("GL_KHR_debug")]
    MaxDebugGroupStackDepthKhr = 0x826C,

    [GLExtension("GL_KHR_debug")]
    DebugGroupStackDepthKhr = 0x826D,
    MaxCombinedDimensions = 0x8282,
    DepthComponents = 0x8284,
    StencilComponents = 0x8285,
    ManualGenerateMipmap = 0x8294,

    [GLExtension("GL_ARB_internalformat_query2")]
    SrgbDecodeARB = 0x8299,
    FullSupport = 0x82B7,
    CaveatSupport = 0x82B8,
    ImageClass4X32 = 0x82B9,
    ImageClass2X32 = 0x82BA,
    ImageClass1X32 = 0x82BB,
    ImageClass4X16 = 0x82BC,
    ImageClass2X16 = 0x82BD,
    ImageClass1X16 = 0x82BE,
    ImageClass4X8 = 0x82BF,
    ImageClass2X8 = 0x82C0,
    ImageClass1X8 = 0x82C1,
    ImageClass111110 = 0x82C2,
    ImageClass1010102 = 0x82C3,
    ViewClass128Bits = 0x82C4,
    ViewClass96Bits = 0x82C5,
    ViewClass64Bits = 0x82C6,
    ViewClass48Bits = 0x82C7,
    ViewClass32Bits = 0x82C8,
    ViewClass24Bits = 0x82C9,
    ViewClass16Bits = 0x82CA,
    ViewClass8Bits = 0x82CB,
    ViewClassS3tcDxt1Rgb = 0x82CC,
    ViewClassS3tcDxt1Rgba = 0x82CD,
    ViewClassS3tcDxt3Rgba = 0x82CE,
    ViewClassS3tcDxt5Rgba = 0x82CF,
    ViewClassRgtc1Red = 0x82D0,
    ViewClassRgtc2Rg = 0x82D1,
    ViewClassBptcUnorm = 0x82D2,
    ViewClassBptcFloat = 0x82D3,
    TextureViewMinLevel = 0x82DB,
    TextureViewNumLevels = 0x82DC,
    TextureViewMinLayer = 0x82DD,
    TextureViewNumLayers = 0x82DE,
    TextureImmutableLevels = 0x82DF,

    [GLExtension("GL_KHR_debug")]
    BufferKhr = 0x82E0,

    [GLExtension("GL_KHR_debug")]
    ShaderKhr = 0x82E1,

    [GLExtension("GL_KHR_debug")]
    ProgramKhr = 0x82E2,

    [GLExtension("GL_KHR_debug")]
    QueryKhr = 0x82E3,

    [GLExtension("GL_KHR_debug")]
    ProgramPipelineKhr = 0x82E4,
    MaxVertexAttribStride = 0x82E5,

    [GLExtension("GL_KHR_debug")]
    SamplerKhr = 0x82E6,
    DisplayList = 0x82E7,

    [GLExtension("GL_KHR_debug")]
    MaxLabelLengthKhr = 0x82E8,
    NumShadingLanguageVersions = 0x82E9,

    [GLExtension("GL_ARB_transform_feedback_overflow_query")]
    TransformFeedbackOverflowARB = 0x82EC,
    TransformFeedbackStreamOverflow = 0x82ED,

    [GLExtension("GL_ARB_transform_feedback_overflow_query")]
    TransformFeedbackStreamOverflowARB = 0x82ED,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    VerticesSubmittedARB = 0x82EE,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    PrimitivesSubmittedARB = 0x82EF,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    VertexShaderInvocationsARB = 0x82F0,
    TessControlShaderPatches = 0x82F1,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    TessControlShaderPatchesARB = 0x82F1,
    TessEvaluationShaderInvocations = 0x82F2,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    TessEvaluationShaderInvocationsARB = 0x82F2,
    GeometryShaderPrimitivesEmitted = 0x82F3,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    GeometryShaderPrimitivesEmittedARB = 0x82F3,
    FragmentShaderInvocations = 0x82F4,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    FragmentShaderInvocationsARB = 0x82F4,
    ComputeShaderInvocations = 0x82F5,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    ComputeShaderInvocationsARB = 0x82F5,
    ClippingInputPrimitives = 0x82F6,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    ClippingInputPrimitivesARB = 0x82F6,
    ClippingOutputPrimitives = 0x82F7,

    [GLExtension("GL_ARB_pipeline_statistics_query")]
    ClippingOutputPrimitivesARB = 0x82F7,

    [GLExtension("GL_ARB_sparse_buffer")]
    SparseBufferPageSizeARB = 0x82F8,
    MaxCullDistances = 0x82F9,
    MaxCombinedClipAndCullDistances = 0x82FA,
    ContextReleaseBehavior = 0x82FB,

    [GLExtension("GL_KHR_context_flush_control")]
    ContextReleaseBehaviorKhr = 0x82FB,
    ContextReleaseBehaviorFlush = 0x82FC,

    [GLExtension("GL_KHR_context_flush_control")]
    ContextReleaseBehaviorFlushKhr = 0x82FC,
    RobustGpuTimeoutMsKhr = 0x82FD,
    DepthPassInstrumentSGIX = 0x8310,
    DepthPassInstrumentCountersSGIX = 0x8311,
    DepthPassInstrumentMaxSGIX = 0x8312,
    FragmentsInstrumentSGIX = 0x8313,
    FragmentsInstrumentCountersSGIX = 0x8314,
    FragmentsInstrumentMaxSGIX = 0x8315,
    UnpackCompressedSizeSGIX = 0x831A,
    PackMaxCompressedSizeSGIX = 0x831B,
    PackCompressedSizeSGIX = 0x831C,
    Slim8uSGIX = 0x831D,
    Slim10uSGIX = 0x831E,
    Slim12sSGIX = 0x831F,

    [GLExtension("GL_ARB_texture_mirrored_repeat")]
    MirroredRepeatARB = 0x8370,
    FogCoordinateSource = 0x8450,
    CurrentFogCoordinate = 0x8453,
    CurrentFogCoord = 0x8453,
    FogCoordinateArrayType = 0x8454,
    FogCoordArrayType = 0x8454,
    FogCoordinateArrayStride = 0x8455,
    FogCoordArrayStride = 0x8455,
    FogCoordinateArrayPointer = 0x8456,
    FogCoordArrayPointer = 0x8456,
    FogCoordinateArray = 0x8457,
    FogCoordArray = 0x8457,
    ColorSum = 0x8458,

    [GLExtension("GL_ARB_vertex_program")]
    ColorSumARB = 0x8458,
    CurrentSecondaryColor = 0x8459,
    SecondaryColorArraySize = 0x845A,
    SecondaryColorArrayType = 0x845B,
    SecondaryColorArrayStride = 0x845C,
    SecondaryColorArrayPointer = 0x845D,
    SecondaryColorArray = 0x845E,
    CurrentRasterSecondaryColor = 0x845F,

    [GLExtension("GL_ARB_multitexture")]
    Texture2ARB = 0x84C2,

    [GLExtension("GL_ARB_multitexture")]
    Texture3ARB = 0x84C3,

    [GLExtension("GL_ARB_multitexture")]
    Texture4ARB = 0x84C4,

    [GLExtension("GL_ARB_multitexture")]
    Texture5ARB = 0x84C5,

    [GLExtension("GL_ARB_multitexture")]
    Texture6ARB = 0x84C6,

    [GLExtension("GL_ARB_multitexture")]
    Texture7ARB = 0x84C7,

    [GLExtension("GL_ARB_multitexture")]
    Texture8ARB = 0x84C8,

    [GLExtension("GL_ARB_multitexture")]
    Texture9ARB = 0x84C9,

    [GLExtension("GL_ARB_multitexture")]
    Texture10ARB = 0x84CA,

    [GLExtension("GL_ARB_multitexture")]
    Texture11ARB = 0x84CB,

    [GLExtension("GL_ARB_multitexture")]
    Texture12ARB = 0x84CC,

    [GLExtension("GL_ARB_multitexture")]
    Texture13ARB = 0x84CD,

    [GLExtension("GL_ARB_multitexture")]
    Texture14ARB = 0x84CE,

    [GLExtension("GL_ARB_multitexture")]
    Texture15ARB = 0x84CF,

    [GLExtension("GL_ARB_multitexture")]
    Texture16ARB = 0x84D0,

    [GLExtension("GL_ARB_multitexture")]
    Texture17ARB = 0x84D1,

    [GLExtension("GL_ARB_multitexture")]
    Texture18ARB = 0x84D2,

    [GLExtension("GL_ARB_multitexture")]
    Texture19ARB = 0x84D3,

    [GLExtension("GL_ARB_multitexture")]
    Texture20ARB = 0x84D4,

    [GLExtension("GL_ARB_multitexture")]
    Texture21ARB = 0x84D5,

    [GLExtension("GL_ARB_multitexture")]
    Texture22ARB = 0x84D6,

    [GLExtension("GL_ARB_multitexture")]
    Texture23ARB = 0x84D7,

    [GLExtension("GL_ARB_multitexture")]
    Texture24ARB = 0x84D8,

    [GLExtension("GL_ARB_multitexture")]
    Texture25ARB = 0x84D9,

    [GLExtension("GL_ARB_multitexture")]
    Texture26ARB = 0x84DA,

    [GLExtension("GL_ARB_multitexture")]
    Texture27ARB = 0x84DB,

    [GLExtension("GL_ARB_multitexture")]
    Texture28ARB = 0x84DC,

    [GLExtension("GL_ARB_multitexture")]
    Texture29ARB = 0x84DD,

    [GLExtension("GL_ARB_multitexture")]
    Texture30ARB = 0x84DE,

    [GLExtension("GL_ARB_multitexture")]
    Texture31ARB = 0x84DF,

    [GLExtension("GL_ARB_multitexture")]
    ActiveTextureARB = 0x84E0,
    ClientActiveTexture = 0x84E1,

    [GLExtension("GL_ARB_multitexture")]
    ClientActiveTextureARB = 0x84E1,
    MaxTextureUnits = 0x84E2,

    [GLExtension("GL_ARB_multitexture")]
    MaxTextureUnitsARB = 0x84E2,
    TransposeModelviewMatrix = 0x84E3,

    [GLExtension("GL_ARB_transpose_matrix")]
    TransposeModelviewMatrixARB = 0x84E3,
    TransposeProjectionMatrix = 0x84E4,

    [GLExtension("GL_ARB_transpose_matrix")]
    TransposeProjectionMatrixARB = 0x84E4,
    TransposeTextureMatrix = 0x84E5,

    [GLExtension("GL_ARB_transpose_matrix")]
    TransposeTextureMatrixARB = 0x84E5,
    TransposeColorMatrix = 0x84E6,

    [GLExtension("GL_ARB_transpose_matrix")]
    TransposeColorMatrixARB = 0x84E6,
    Subtract = 0x84E7,

    [GLExtension("GL_ARB_texture_env_combine")]
    SubtractARB = 0x84E7,
    CompressedAlpha = 0x84E9,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedAlphaARB = 0x84E9,
    CompressedLuminance = 0x84EA,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedLuminanceARB = 0x84EA,
    CompressedLuminanceAlpha = 0x84EB,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedLuminanceAlphaARB = 0x84EB,
    CompressedIntensity = 0x84EC,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedIntensityARB = 0x84EC,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedRgbARB = 0x84ED,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedRgbaARB = 0x84EE,

    [GLExtension("GL_ARB_texture_rectangle")]
    MaxRectangleTextureSizeARB = 0x84F8,
    MaxTextureMaxAnisotropy = 0x84FF,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview1ARB = 0x850A,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArrayEnabledARB = 0x8622,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArraySizeARB = 0x8623,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArrayStrideARB = 0x8624,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArrayTypeARB = 0x8625,

    [GLExtension("GL_ARB_vertex_program")]
    CurrentVertexAttribARB = 0x8626,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramLengthARB = 0x8627,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramMatrixStackDepthARB = 0x862E,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramMatricesARB = 0x862F,

    [GLExtension("GL_ARB_fragment_program")]
    CurrentMatrixStackDepthARB = 0x8640,

    [GLExtension("GL_ARB_fragment_program")]
    CurrentMatrixARB = 0x8641,
    VertexProgramPointSize = 0x8642,

    [GLExtension("GL_ARB_vertex_program")]
    VertexProgramPointSizeARB = 0x8642,

    [GLExtension("GL_ARB_geometry_shader4")]
    ProgramPointSizeARB = 0x8642,
    VertexProgramTwoSide = 0x8643,

    [GLExtension("GL_ARB_vertex_program")]
    VertexProgramTwoSideARB = 0x8643,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramErrorPositionARB = 0x864B,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramBindingARB = 0x8677,
    TextureCompressedImageSize = 0x86A0,

    [GLExtension("GL_ARB_texture_compression")]
    TextureCompressedImageSizeARB = 0x86A0,

    [GLExtension("GL_ARB_texture_compression")]
    TextureCompressedARB = 0x86A1,

    [GLExtension("GL_ARB_texture_compression")]
    NumCompressedTextureFormatsARB = 0x86A2,

    [GLExtension("GL_ARB_texture_compression")]
    CompressedTextureFormatsARB = 0x86A3,

    [GLExtension("GL_ARB_vertex_blend")]
    MaxVertexUnitsARB = 0x86A4,

    [GLExtension("GL_ARB_vertex_blend")]
    ActiveVertexUnitsARB = 0x86A5,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightSumUnityARB = 0x86A6,

    [GLExtension("GL_ARB_vertex_blend")]
    VertexBlendARB = 0x86A7,

    [GLExtension("GL_ARB_vertex_blend")]
    CurrentWeightARB = 0x86A8,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightArrayTypeARB = 0x86A9,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightArrayStrideARB = 0x86AA,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightArraySizeARB = 0x86AB,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightArrayPointerARB = 0x86AC,

    [GLExtension("GL_ARB_vertex_blend")]
    WeightArrayARB = 0x86AD,
    Dot3Rgb = 0x86AE,

    [GLExtension("GL_ARB_texture_env_dot3")]
    Dot3RgbARB = 0x86AE,
    Dot3Rgba = 0x86AF,

    [GLExtension("GL_ARB_texture_env_dot3")]
    Dot3RgbaARB = 0x86AF,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview2ARB = 0x8722,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview3ARB = 0x8723,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview4ARB = 0x8724,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview5ARB = 0x8725,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview6ARB = 0x8726,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview7ARB = 0x8727,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview8ARB = 0x8728,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview9ARB = 0x8729,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview10ARB = 0x872A,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview11ARB = 0x872B,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview12ARB = 0x872C,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview13ARB = 0x872D,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview14ARB = 0x872E,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview15ARB = 0x872F,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview16ARB = 0x8730,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview17ARB = 0x8731,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview18ARB = 0x8732,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview19ARB = 0x8733,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview20ARB = 0x8734,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview21ARB = 0x8735,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview22ARB = 0x8736,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview23ARB = 0x8737,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview24ARB = 0x8738,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview25ARB = 0x8739,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview26ARB = 0x873A,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview27ARB = 0x873B,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview28ARB = 0x873C,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview29ARB = 0x873D,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview30ARB = 0x873E,

    [GLExtension("GL_ARB_vertex_blend")]
    Modelview31ARB = 0x873F,
    MirrorClampToEdge = 0x8743,
    UnsignedInt248MESA = 0x8751,
    UnsignedInt824RevMESA = 0x8752,
    UnsignedShort151MESA = 0x8753,
    UnsignedShort115RevMESA = 0x8754,
    TraceMaskMESA = 0x8755,
    TraceNameMESA = 0x8756,
    DebugObjectMESA = 0x8759,
    DebugPrintMESA = 0x875A,
    DebugAssertMESA = 0x875B,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramAluInstructionsARB = 0x8805,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramTexInstructionsARB = 0x8806,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramTexIndirectionsARB = 0x8807,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeAluInstructionsARB = 0x8808,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeTexInstructionsARB = 0x8809,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeTexIndirectionsARB = 0x880A,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramAluInstructionsARB = 0x880B,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramTexInstructionsARB = 0x880C,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramTexIndirectionsARB = 0x880D,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeAluInstructionsARB = 0x880E,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeTexInstructionsARB = 0x880F,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeTexIndirectionsARB = 0x8810,

    [GLExtension("GL_ARB_texture_float")]
    Alpha32fARB = 0x8816,

    [GLExtension("GL_ARB_texture_float")]
    Intensity32fARB = 0x8817,

    [GLExtension("GL_ARB_texture_float")]
    Luminance32fARB = 0x8818,

    [GLExtension("GL_ARB_texture_float")]
    LuminanceAlpha32fARB = 0x8819,

    [GLExtension("GL_ARB_texture_float")]
    Alpha16fARB = 0x881C,

    [GLExtension("GL_ARB_texture_float")]
    Intensity16fARB = 0x881D,

    [GLExtension("GL_ARB_texture_float")]
    Luminance16fARB = 0x881E,

    [GLExtension("GL_ARB_texture_float")]
    LuminanceAlpha16fARB = 0x881F,

    [GLExtension("GL_ARB_color_buffer_float")]
    RgbaFloatModeARB = 0x8820,

    [GLExtension("GL_ARB_draw_buffers")]
    MaxDrawBuffersARB = 0x8824,
    DrawBuffer0 = 0x8825,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer0ARB = 0x8825,
    DrawBuffer1 = 0x8826,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer1ARB = 0x8826,
    DrawBuffer2 = 0x8827,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer2ARB = 0x8827,
    DrawBuffer3 = 0x8828,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer3ARB = 0x8828,
    DrawBuffer4 = 0x8829,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer4ARB = 0x8829,
    DrawBuffer5 = 0x882A,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer5ARB = 0x882A,
    DrawBuffer6 = 0x882B,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer6ARB = 0x882B,
    DrawBuffer7 = 0x882C,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer7ARB = 0x882C,
    DrawBuffer8 = 0x882D,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer8ARB = 0x882D,
    DrawBuffer9 = 0x882E,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer9ARB = 0x882E,
    DrawBuffer10 = 0x882F,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer10ARB = 0x882F,
    DrawBuffer11 = 0x8830,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer11ARB = 0x8830,
    DrawBuffer12 = 0x8831,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer12ARB = 0x8831,
    DrawBuffer13 = 0x8832,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer13ARB = 0x8832,
    DrawBuffer14 = 0x8833,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer14ARB = 0x8833,
    DrawBuffer15 = 0x8834,

    [GLExtension("GL_ARB_draw_buffers")]
    DrawBuffer15ARB = 0x8834,
    CompressedLuminanceAlpha3dcATI = 0x8837,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixPaletteARB = 0x8840,

    [GLExtension("GL_ARB_matrix_palette")]
    MaxMatrixPaletteStackDepthARB = 0x8841,

    [GLExtension("GL_ARB_matrix_palette")]
    MaxPaletteMatricesARB = 0x8842,

    [GLExtension("GL_ARB_matrix_palette")]
    CurrentPaletteMatrixARB = 0x8843,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixIndexArrayARB = 0x8844,

    [GLExtension("GL_ARB_matrix_palette")]
    CurrentMatrixIndexARB = 0x8845,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixIndexArraySizeARB = 0x8846,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixIndexArrayTypeARB = 0x8847,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixIndexArrayStrideARB = 0x8848,

    [GLExtension("GL_ARB_matrix_palette")]
    MatrixIndexArrayPointerARB = 0x8849,
    TextureDepthSize = 0x884A,

    [GLExtension("GL_ARB_depth_texture")]
    TextureDepthSizeARB = 0x884A,
    DepthTextureMode = 0x884B,

    [GLExtension("GL_ARB_depth_texture")]
    DepthTextureModeARB = 0x884B,

    [GLExtension("GL_ARB_shadow")]
    TextureCompareModeARB = 0x884C,

    [GLExtension("GL_ARB_shadow")]
    TextureCompareFuncARB = 0x884D,

    [GLExtension("GL_ARB_shadow")]
    CompareRToTextureARB = 0x884E,

    [GLExtension("GL_ARB_point_sprite")]
    PointSpriteARB = 0x8861,

    [GLExtension("GL_ARB_point_sprite")]
    CoordReplaceARB = 0x8862,

    [GLExtension("GL_ARB_occlusion_query")]
    QueryCounterBitsARB = 0x8864,

    [GLExtension("GL_ARB_occlusion_query")]
    CurrentQueryARB = 0x8865,

    [GLExtension("GL_ARB_occlusion_query")]
    QueryResultARB = 0x8866,

    [GLExtension("GL_ARB_occlusion_query")]
    QueryResultAvailableARB = 0x8867,

    [GLExtension("GL_ARB_vertex_program")]
    MaxVertexAttribsARB = 0x8869,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArrayNormalizedARB = 0x886A,
    MaxTessControlInputComponents = 0x886C,
    MaxTessEvaluationInputComponents = 0x886D,
    MaxTextureCoords = 0x8871,

    [GLExtension("GL_ARB_fragment_program")]
    MaxTextureCoordsARB = 0x8871,

    [GLExtension("GL_ARB_fragment_program")]
    MaxTextureImageUnitsARB = 0x8872,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramErrorStringARB = 0x8874,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramFormatARB = 0x8876,
    GeometryShaderInvocations = 0x887F,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ArrayBufferARB = 0x8892,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ElementArrayBufferARB = 0x8893,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ArrayBufferBindingARB = 0x8894,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ElementArrayBufferBindingARB = 0x8895,
    VertexArrayBufferBinding = 0x8896,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    VertexArrayBufferBindingARB = 0x8896,
    NormalArrayBufferBinding = 0x8897,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    NormalArrayBufferBindingARB = 0x8897,
    ColorArrayBufferBinding = 0x8898,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ColorArrayBufferBindingARB = 0x8898,
    IndexArrayBufferBinding = 0x8899,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    IndexArrayBufferBindingARB = 0x8899,
    TextureCoordArrayBufferBinding = 0x889A,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    TextureCoordArrayBufferBindingARB = 0x889A,
    EdgeFlagArrayBufferBinding = 0x889B,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    EdgeFlagArrayBufferBindingARB = 0x889B,
    SecondaryColorArrayBufferBinding = 0x889C,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    SecondaryColorArrayBufferBindingARB = 0x889C,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    FogCoordinateArrayBufferBindingARB = 0x889D,
    FogCoordinateArrayBufferBinding = 0x889D,
    FogCoordArrayBufferBinding = 0x889D,
    WeightArrayBufferBinding = 0x889E,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    WeightArrayBufferBindingARB = 0x889E,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    VertexAttribArrayBufferBindingARB = 0x889F,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramInstructionsARB = 0x88A0,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramInstructionsARB = 0x88A1,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeInstructionsARB = 0x88A2,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeInstructionsARB = 0x88A3,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramTemporariesARB = 0x88A4,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramTemporariesARB = 0x88A5,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeTemporariesARB = 0x88A6,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeTemporariesARB = 0x88A7,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramParametersARB = 0x88A8,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramParametersARB = 0x88A9,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeParametersARB = 0x88AA,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeParametersARB = 0x88AB,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramAttribsARB = 0x88AC,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramAttribsARB = 0x88AD,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramNativeAttribsARB = 0x88AE,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramNativeAttribsARB = 0x88AF,

    [GLExtension("GL_ARB_vertex_program")]
    ProgramAddressRegistersARB = 0x88B0,

    [GLExtension("GL_ARB_vertex_program")]
    MaxProgramAddressRegistersARB = 0x88B1,

    [GLExtension("GL_ARB_vertex_program")]
    ProgramNativeAddressRegistersARB = 0x88B2,

    [GLExtension("GL_ARB_vertex_program")]
    MaxProgramNativeAddressRegistersARB = 0x88B3,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramLocalParametersARB = 0x88B4,

    [GLExtension("GL_ARB_fragment_program")]
    MaxProgramEnvParametersARB = 0x88B5,

    [GLExtension("GL_ARB_fragment_program")]
    ProgramUnderNativeLimitsARB = 0x88B6,

    [GLExtension("GL_ARB_fragment_program")]
    TransposeCurrentMatrixARB = 0x88B7,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ReadOnlyARB = 0x88B8,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    WriteOnlyARB = 0x88B9,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    ReadWriteARB = 0x88BA,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix0ARB = 0x88C0,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix1ARB = 0x88C1,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix2ARB = 0x88C2,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix3ARB = 0x88C3,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix4ARB = 0x88C4,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix5ARB = 0x88C5,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix6ARB = 0x88C6,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix7ARB = 0x88C7,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix8ARB = 0x88C8,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix9ARB = 0x88C9,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix10ARB = 0x88CA,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix11ARB = 0x88CB,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix12ARB = 0x88CC,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix13ARB = 0x88CD,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix14ARB = 0x88CE,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix15ARB = 0x88CF,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix16ARB = 0x88D0,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix17ARB = 0x88D1,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix18ARB = 0x88D2,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix19ARB = 0x88D3,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix20ARB = 0x88D4,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix21ARB = 0x88D5,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix22ARB = 0x88D6,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix23ARB = 0x88D7,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix24ARB = 0x88D8,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix25ARB = 0x88D9,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix26ARB = 0x88DA,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix27ARB = 0x88DB,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix28ARB = 0x88DC,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix29ARB = 0x88DD,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix30ARB = 0x88DE,

    [GLExtension("GL_ARB_fragment_program")]
    Matrix31ARB = 0x88DF,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StreamDrawARB = 0x88E0,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StreamReadARB = 0x88E1,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StreamCopyARB = 0x88E2,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StaticDrawARB = 0x88E4,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StaticReadARB = 0x88E5,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    StaticCopyARB = 0x88E6,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    DynamicDrawARB = 0x88E8,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    DynamicReadARB = 0x88E9,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    DynamicCopyARB = 0x88EA,

    [GLExtension("GL_ARB_pixel_buffer_object")]
    PixelPackBufferARB = 0x88EB,

    [GLExtension("GL_ARB_pixel_buffer_object")]
    PixelUnpackBufferARB = 0x88EC,

    [GLExtension("GL_ARB_pixel_buffer_object")]
    PixelPackBufferBindingARB = 0x88ED,

    [GLExtension("GL_ARB_pixel_buffer_object")]
    PixelUnpackBufferBindingARB = 0x88EF,
    TextureStencilSize = 0x88F1,

    [GLExtension("GL_ARB_instanced_arrays")]
    VertexAttribArrayDivisorARB = 0x88FE,

    [GLExtension("GL_ARB_occlusion_query")]
    SamplesPassedARB = 0x8914,
    ClampVertexColor = 0x891A,
    ClampFragmentColor = 0x891B,

    [GLExtension("GL_ARB_shader_objects")]
    ShaderObjectARB = 0x8B48,

    [GLExtension("GL_ARB_fragment_shader")]
    MaxFragmentUniformComponentsARB = 0x8B49,

    [GLExtension("GL_ARB_vertex_shader")]
    MaxVertexUniformComponentsARB = 0x8B4A,

    [GLExtension("GL_ARB_vertex_shader")]
    MaxVaryingFloatsARB = 0x8B4B,

    [GLExtension("GL_ARB_vertex_shader")]
    MaxVertexTextureImageUnitsARB = 0x8B4C,

    [GLExtension("GL_ARB_vertex_shader")]
    MaxCombinedTextureImageUnitsARB = 0x8B4D,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectTypeARB = 0x8B4E,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectSubtypeARB = 0x8B4F,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectDeleteStatusARB = 0x8B80,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectCompileStatusARB = 0x8B81,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectLinkStatusARB = 0x8B82,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectValidateStatusARB = 0x8B83,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectInfoLogLengthARB = 0x8B84,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectAttachedObjectsARB = 0x8B85,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectActiveUniformsARB = 0x8B86,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectActiveUniformMaxLengthARB = 0x8B87,

    [GLExtension("GL_ARB_shader_objects")]
    ObjectShaderSourceLengthARB = 0x8B88,

    [GLExtension("GL_ARB_vertex_shader")]
    ObjectActiveAttributesARB = 0x8B89,

    [GLExtension("GL_ARB_vertex_shader")]
    ObjectActiveAttributeMaxLengthARB = 0x8B8A,

    [GLExtension("GL_ARB_shading_language_100")]
    ShadingLanguageVersionARB = 0x8B8C,
    FragmentProgramPositionMESA = 0x8BB0,
    FragmentProgramCallbackMESA = 0x8BB1,
    FragmentProgramCallbackFuncMESA = 0x8BB2,
    FragmentProgramCallbackDataMESA = 0x8BB3,
    VertexProgramPositionMESA = 0x8BB4,
    VertexProgramCallbackMESA = 0x8BB5,
    VertexProgramCallbackFuncMESA = 0x8BB6,
    VertexProgramCallbackDataMESA = 0x8BB7,
    TextureRedType = 0x8C10,

    [GLExtension("GL_ARB_texture_float")]
    TextureRedTypeARB = 0x8C10,
    TextureGreenType = 0x8C11,

    [GLExtension("GL_ARB_texture_float")]
    TextureGreenTypeARB = 0x8C11,
    TextureBlueType = 0x8C12,

    [GLExtension("GL_ARB_texture_float")]
    TextureBlueTypeARB = 0x8C12,
    TextureAlphaType = 0x8C13,

    [GLExtension("GL_ARB_texture_float")]
    TextureAlphaTypeARB = 0x8C13,
    TextureLuminanceType = 0x8C14,

    [GLExtension("GL_ARB_texture_float")]
    TextureLuminanceTypeARB = 0x8C14,
    TextureIntensityType = 0x8C15,

    [GLExtension("GL_ARB_texture_float")]
    TextureIntensityTypeARB = 0x8C15,
    TextureDepthType = 0x8C16,

    [GLExtension("GL_ARB_texture_float")]
    TextureDepthTypeARB = 0x8C16,
    UnsignedNormalized = 0x8C17,

    [GLExtension("GL_ARB_texture_float")]
    UnsignedNormalizedARB = 0x8C17,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxGeometryTextureImageUnitsARB = 0x8C29,

    [GLExtension("GL_ARB_texture_buffer_object")]
    TextureBufferARB = 0x8C2A,
    TextureBufferBinding = 0x8C2A,

    [GLExtension("GL_ARB_texture_buffer_object")]
    MaxTextureBufferSizeARB = 0x8C2B,

    [GLExtension("GL_ARB_texture_buffer_object")]
    TextureBindingBufferARB = 0x8C2C,
    TextureBufferDataStoreBinding = 0x8C2D,

    [GLExtension("GL_ARB_texture_buffer_object")]
    TextureBufferDataStoreBindingARB = 0x8C2D,

    [GLExtension("GL_ARB_texture_buffer_object")]
    TextureBufferFormatARB = 0x8C2E,

    [GLExtension("GL_ARB_sample_shading")]
    SampleShadingARB = 0x8C36,
    MinSampleShadingValue = 0x8C37,

    [GLExtension("GL_ARB_sample_shading")]
    MinSampleShadingValueARB = 0x8C37,
    TextureSharedSize = 0x8C3F,
    SluminanceAlpha = 0x8C44,
    Sluminance8Alpha8 = 0x8C45,
    Sluminance = 0x8C46,
    Sluminance8 = 0x8C47,
    CompressedSluminance = 0x8C4A,
    CompressedSluminanceAlpha = 0x8C4B,
    MaxTransformFeedbackSeparateComponents = 0x8C80,
    MaxTransformFeedbackInterleavedComponents = 0x8C8A,
    MaxTransformFeedbackSeparateAttribs = 0x8C8B,
    PointSpriteCoordOrigin = 0x8CA0,
    FramebufferBinding = 0x8CA6,
    FramebufferBindingAngle = 0x8CA6,
    RenderbufferBindingAngle = 0x8CA7,
    FramebufferIncompleteDimensions = 0x8CD9,
    FramebufferIncompleteDrawBufferOES = 0x8CDB,
    FramebufferIncompleteReadBufferOES = 0x8CDC,
    MaxSamples = 0x8D57,
    AlphaInteger = 0x8D97,

    [GLExtension("GL_ARB_geometry_shader4")]
    FramebufferIncompleteLayerTargetsARB = 0x8DA8,

    [GLExtension("GL_ARB_geometry_shader4")]
    FramebufferIncompleteLayerCountARB = 0x8DA9,

    [GLExtension("GL_ARB_shading_language_include")]
    ShaderIncludeARB = 0x8DAE,

    [GLExtension("GL_ARB_geometry_shader4")]
    GeometryShaderARB = 0x8DD9,

    [GLExtension("GL_ARB_geometry_shader4")]
    GeometryVerticesOutARB = 0x8DDA,

    [GLExtension("GL_ARB_geometry_shader4")]
    GeometryInputTypeARB = 0x8DDB,

    [GLExtension("GL_ARB_geometry_shader4")]
    GeometryOutputTypeARB = 0x8DDC,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxGeometryVaryingComponentsARB = 0x8DDD,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxVertexVaryingComponentsARB = 0x8DDE,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxGeometryUniformComponentsARB = 0x8DDF,
    MaxGeometryOutputVertices = 0x8DE0,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxGeometryOutputVerticesARB = 0x8DE0,
    MaxGeometryTotalOutputComponents = 0x8DE1,

    [GLExtension("GL_ARB_geometry_shader4")]
    MaxGeometryTotalOutputComponentsARB = 0x8DE1,
    MaxSubroutines = 0x8DE7,
    MaxSubroutineUniformLocations = 0x8DE8,

    [GLExtension("GL_ARB_shading_language_include")]
    NamedStringLengthARB = 0x8DE9,

    [GLExtension("GL_ARB_shading_language_include")]
    NamedStringTypeARB = 0x8DEA,
    PolygonOffsetClamp = 0x8E1B,
    MaxCombinedTessControlUniformComponents = 0x8E1E,
    MaxCombinedTessEvaluationUniformComponents = 0x8E1F,
    TransformFeedbackBufferPaused = 0x8E23,
    TransformFeedbackBufferActive = 0x8E24,
    TransformFeedbackBinding = 0x8E25,
    QuadsFollowProvokingVertexConvention = 0x8E4C,
    SampleMaskValue = 0x8E52,
    MaxGeometryShaderInvocations = 0x8E5A,
    MinFragmentInterpolationOffset = 0x8E5B,
    MaxFragmentInterpolationOffset = 0x8E5C,
    FragmentInterpolationOffsetBits = 0x8E5D,
    MinProgramTextureGatherOffset = 0x8E5E,

    [GLExtension("GL_ARB_texture_gather")]
    MinProgramTextureGatherOffsetARB = 0x8E5E,
    MaxProgramTextureGatherOffset = 0x8E5F,

    [GLExtension("GL_ARB_texture_gather")]
    MaxProgramTextureGatherOffsetARB = 0x8E5F,
    MaxTransformFeedbackBuffers = 0x8E70,
    MaxVertexStreams = 0x8E71,
    PatchDefaultInnerLevelEXT = 0x8E73,
    PatchDefaultOuterLevelEXT = 0x8E74,
    TessControlOutputVertices = 0x8E75,
    TessGenMode = 0x8E76,
    TessGenSpacing = 0x8E77,
    TessGenVertexOrder = 0x8E78,
    TessGenPointMode = 0x8E79,
    Isolines = 0x8E7A,
    FractionalOdd = 0x8E7B,
    FractionalEven = 0x8E7C,
    MaxPatchVertices = 0x8E7D,
    MaxTessGenLevel = 0x8E7E,
    MaxTessControlUniformComponents = 0x8E7F,
    MaxTessEvaluationUniformComponents = 0x8E80,
    MaxTessControlTextureImageUnits = 0x8E81,
    MaxTessEvaluationTextureImageUnits = 0x8E82,
    MaxTessControlOutputComponents = 0x8E83,
    MaxTessPatchComponents = 0x8E84,
    MaxTessControlTotalOutputComponents = 0x8E85,
    MaxTessEvaluationOutputComponents = 0x8E86,
    CopyReadBufferBinding = 0x8F36,
    CopyWriteBufferBinding = 0x8F37,
    MaxImageUnits = 0x8F38,
    MaxCombinedImageUnitsAndFragmentOutputs = 0x8F39,
    MaxCombinedShaderOutputResources = 0x8F39,
    ImageBindingName = 0x8F3A,
    ImageBindingLevel = 0x8F3B,
    ImageBindingLayered = 0x8F3C,
    ImageBindingLayer = 0x8F3D,
    ImageBindingAccess = 0x8F3E,
    DrawIndirectBufferBinding = 0x8F43,
    VertexBindingBuffer = 0x8F4F,
    SignedNormalized = 0x8F9C,

    [GLExtension("GL_ARB_texture_gather")]
    MaxProgramTextureGatherComponentsARB = 0x8F9F,
    TextureBindingCubeMapArray = 0x900A,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    TextureBindingCubeMapArrayARB = 0x900A,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    SamplerCubeMapArrayARB = 0x900C,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    SamplerCubeMapArrayShadowARB = 0x900D,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    IntSamplerCubeMapArrayARB = 0x900E,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    UnsignedIntSamplerCubeMapArrayARB = 0x900F,
    MaxImageSamples = 0x906D,
    ImageBindingFormat = 0x906E,
    ImageFormatCompatibilityBySize = 0x90C8,
    ImageFormatCompatibilityByClass = 0x90C9,
    MaxVertexImageUniforms = 0x90CA,
    MaxTessControlImageUniforms = 0x90CB,
    MaxTessEvaluationImageUniforms = 0x90CC,
    MaxGeometryImageUniforms = 0x90CD,
    MaxFragmentImageUniforms = 0x90CE,
    MaxCombinedImageUniforms = 0x90CF,
    MaxShaderStorageBlockSize = 0x90DE,

    [GLExtension("GL_ARB_compute_variable_group_size")]
    MaxComputeFixedGroupInvocationsARB = 0x90EB,
    ContextRobustAccess = 0x90F3,

    [GLExtension("GL_KHR_robustness")]
    ContextRobustAccessKhr = 0x90F3,
    TextureSamples = 0x9106,
    TextureFixedSampleLocations = 0x9107,
    SyncFence = 0x9116,
    Unsignaled = 0x9118,
    Signaled = 0x9119,
    UnpackCompressedBlockWidth = 0x9127,
    UnpackCompressedBlockHeight = 0x9128,
    UnpackCompressedBlockDepth = 0x9129,
    UnpackCompressedBlockSize = 0x912A,
    PackCompressedBlockWidth = 0x912B,
    PackCompressedBlockHeight = 0x912C,
    PackCompressedBlockDepth = 0x912D,
    PackCompressedBlockSize = 0x912E,
    TextureImmutableFormat = 0x912F,
    MaxDebugMessageLength = 0x9143,

    [GLExtension("GL_ARB_debug_output")]
    MaxDebugMessageLengthARB = 0x9143,

    [GLExtension("GL_KHR_debug")]
    MaxDebugMessageLengthKhr = 0x9143,
    MaxDebugLoggedMessages = 0x9144,

    [GLExtension("GL_ARB_debug_output")]
    MaxDebugLoggedMessagesARB = 0x9144,

    [GLExtension("GL_KHR_debug")]
    MaxDebugLoggedMessagesKhr = 0x9144,
    DebugLoggedMessages = 0x9145,

    [GLExtension("GL_ARB_debug_output")]
    DebugLoggedMessagesARB = 0x9145,

    [GLExtension("GL_KHR_debug")]
    DebugLoggedMessagesKhr = 0x9145,

    [GLExtension("GL_ARB_debug_output")]
    DebugSeverityHighARB = 0x9146,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityHighKhr = 0x9146,

    [GLExtension("GL_ARB_debug_output")]
    DebugSeverityMediumARB = 0x9147,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityMediumKhr = 0x9147,

    [GLExtension("GL_ARB_debug_output")]
    DebugSeverityLowARB = 0x9148,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityLowKhr = 0x9148,
    QueryBufferBinding = 0x9193,

    [GLExtension("GL_ARB_sparse_texture")]
    VirtualPageSizeXARB = 0x9195,

    [GLExtension("GL_ARB_sparse_texture")]
    VirtualPageSizeYARB = 0x9196,

    [GLExtension("GL_ARB_sparse_texture")]
    VirtualPageSizeZARB = 0x9197,

    [GLExtension("GL_ARB_sparse_texture")]
    MaxSparseTextureSizeARB = 0x9198,

    [GLExtension("GL_ARB_sparse_texture")]
    MaxSparse3DTextureSizeARB = 0x9199,

    [GLExtension("GL_ARB_sparse_texture")]
    MaxSparseArrayTextureLayersARB = 0x919A,
    TextureBufferOffset = 0x919D,
    TextureBufferSize = 0x919E,

    [GLExtension("GL_ARB_sparse_texture")]
    TextureSparseARB = 0x91A6,

    [GLExtension("GL_ARB_sparse_texture")]
    VirtualPageSizeIndexARB = 0x91A7,

    [GLExtension("GL_ARB_sparse_texture")]
    NumVirtualPageSizesARB = 0x91A8,

    [GLExtension("GL_ARB_sparse_texture")]
    SparseTextureFullArrayCubeMipmapsARB = 0x91A9,

    [GLExtension("GL_ARB_sparse_texture")]
    NumSparseLevelsARB = 0x91AA,

    [GLExtension("GL_KHR_parallel_shader_compile")]
    MaxShaderCompilerThreadsKhr = 0x91B0,

    [GLExtension("GL_ARB_parallel_shader_compile")]
    MaxShaderCompilerThreadsARB = 0x91B0,

    [GLExtension("GL_KHR_parallel_shader_compile")]
    CompletionStatusKhr = 0x91B1,

    [GLExtension("GL_ARB_parallel_shader_compile")]
    CompletionStatusARB = 0x91B1,
    MaxComputeImageUniforms = 0x91BD,

    [GLExtension("GL_ARB_compute_variable_group_size")]
    MaxComputeFixedGroupSizeARB = 0x91BF,
    UnpackFlipYWebgl = 0x9240,
    UnpackPremultiplyAlphaWebgl = 0x9241,
    ContextLostWebgl = 0x9242,
    UnpackColorspaceConversionWebgl = 0x9243,
    BrowserDefaultWebgl = 0x9244,

    [GLExtension("GL_KHR_blend_equation_advanced_coherent")]
    BlendAdvancedCoherentKhr = 0x9285,
    Multiply = 0x9294,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    MultiplyKhr = 0x9294,
    Screen = 0x9295,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    ScreenKhr = 0x9295,
    Overlay = 0x9296,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    OverlayKhr = 0x9296,
    Darken = 0x9297,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    DarkenKhr = 0x9297,
    Lighten = 0x9298,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    LightenKhr = 0x9298,
    Colordodge = 0x9299,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    ColordodgeKhr = 0x9299,
    Colorburn = 0x929A,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    ColorburnKhr = 0x929A,
    Hardlight = 0x929B,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    HardlightKhr = 0x929B,
    Softlight = 0x929C,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    SoftlightKhr = 0x929C,
    Difference = 0x929E,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    DifferenceKhr = 0x929E,
    Exclusion = 0x92A0,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    ExclusionKhr = 0x92A0,
    HslHue = 0x92AD,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    HslHueKhr = 0x92AD,
    HslSaturation = 0x92AE,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    HslSaturationKhr = 0x92AE,
    HslColor = 0x92AF,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    HslColorKhr = 0x92AF,
    HslLuminosity = 0x92B0,

    [GLExtension("GL_KHR_blend_equation_advanced")]
    HslLuminosityKhr = 0x92B0,

    [GLExtension("GL_ARB_ES3_2_compatibility")]
    PrimitiveBoundingBoxARB = 0x92BE,
    PrimitiveBoundingBox = 0x92BE,
    AtomicCounterBufferStart = 0x92C2,
    AtomicCounterBufferSize = 0x92C3,
    MaxVertexAtomicCounterBuffers = 0x92CC,
    MaxTessControlAtomicCounterBuffers = 0x92CD,
    MaxTessEvaluationAtomicCounterBuffers = 0x92CE,
    MaxGeometryAtomicCounterBuffers = 0x92CF,
    MaxFragmentAtomicCounterBuffers = 0x92D0,
    MaxCombinedAtomicCounterBuffers = 0x92D1,
    MaxAtomicCounterBufferSize = 0x92D8,
    UnsignedIntAtomicCounter = 0x92DB,
    MaxAtomicCounterBufferBindings = 0x92DC,

    [GLExtension("GL_KHR_debug")]
    DebugOutputKhr = 0x92E0,

    [GLExtension("GL_ARB_sample_locations")]
    SampleLocationSubpixelBitsARB = 0x933D,

    [GLExtension("GL_ARB_sample_locations")]
    SampleLocationPixelGridWidthARB = 0x933E,

    [GLExtension("GL_ARB_sample_locations")]
    SampleLocationPixelGridHeightARB = 0x933F,

    [GLExtension("GL_ARB_sample_locations")]
    ProgrammableSampleLocationTableSizeARB = 0x9340,

    [GLExtension("GL_ARB_sample_locations")]
    FramebufferProgrammableSampleLocationsARB = 0x9342,

    [GLExtension("GL_ARB_sample_locations")]
    FramebufferSampleLocationPixelGridARB = 0x9343,

    [GLExtension("GL_ARB_compute_variable_group_size")]
    MaxComputeVariableGroupInvocationsARB = 0x9344,

    [GLExtension("GL_ARB_compute_variable_group_size")]
    MaxComputeVariableGroupSizeARB = 0x9345,
    ClipOrigin = 0x935C,
    ClipDepthMode = 0x935D,

    [GLExtension("GL_ARB_texture_filter_minmax")]
    TextureReductionModeARB = 0x9366,

    [GLExtension("GL_ARB_texture_filter_minmax")]
    WeightedAverageARB = 0x9367,

    [GLExtension("GL_ARB_ES3_2_compatibility")]
    MultisampleLineWidthRangeARB = 0x9381,
    MultisampleLineWidthRange = 0x9381,

    [GLExtension("GL_ARB_ES3_2_compatibility")]
    MultisampleLineWidthGranularityARB = 0x9382,
    MultisampleLineWidthGranularity = 0x9382,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassEacR11 = 0x9383,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassEacRg11 = 0x9384,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassEtc2Rgb = 0x9385,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassEtc2Rgba = 0x9386,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassEtc2EacRgba = 0x9387,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc4x4Rgba = 0x9388,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc5x4Rgba = 0x9389,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc5x5Rgba = 0x938A,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc6x5Rgba = 0x938B,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc6x6Rgba = 0x938C,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc8x5Rgba = 0x938D,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc8x6Rgba = 0x938E,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc8x8Rgba = 0x938F,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc10x5Rgba = 0x9390,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc10x6Rgba = 0x9391,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc10x8Rgba = 0x9392,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc10x10Rgba = 0x9393,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc12x10Rgba = 0x9394,

    [GLExtension("GL_ARB_internalformat_query2")]
    ViewClassAstc12x12Rgba = 0x9395,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSizeKhr = 0x9532,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedStagesKhr = 0x9533,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedFeaturesKhr = 0x9534,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupQuadAllStagesKhr = 0x9535,

    [GLExtension("GL_ARB_gl_spirv")]
    ShaderBinaryFormatSpirVARB = 0x9551,
    SpirVBinary = 0x9552,

    [GLExtension("GL_ARB_gl_spirv")]
    SpirVBinaryARB = 0x9552,
    SpirVExtensions = 0x9553,
    NumSpirVExtensions = 0x9554,

    [GLExtension("GL_OVR_multiview")]
    MaxViewsOvr = 0x9631,

    [GLExtension("GL_OVR_multiview")]
    FramebufferIncompleteViewTargetsOvr = 0x9633,
    GsShaderBinaryMtk = 0x9640,
    GsProgramBinaryMtk = 0x9641,
    ValidateShaderBinaryQCOM = 0x96A3,
}

public enum AccumOp
{
    Accum = 0x0100,
    Load = 0x0101,
    Return = 0x0102,
    Mult = 0x0103,
    Add = 0x0104,
}

public enum TextureEnvMode
{
    Add = 0x0104,
    Blend = 0x0BE2,
    Replace = 0x1E01,
    Modulate = 0x2100,
    Decal = 0x2101,
    Combine = 0x8570,
}

public enum LightEnvModeSGIX
{
    Add = 0x0104,
    Replace = 0x1E01,
    Modulate = 0x2100,
}

public enum StencilFunction
{
    Never = 0x0200,
    Less = 0x0201,
    Equal = 0x0202,
    Lequal = 0x0203,
    Greater = 0x0204,
    Notequal = 0x0205,
    Gequal = 0x0206,
    Always = 0x0207,
}

public enum IndexFunctionEXT
{
    Never = 0x0200,
    Less = 0x0201,
    Equal = 0x0202,
    Lequal = 0x0203,
    Greater = 0x0204,
    Notequal = 0x0205,
    Gequal = 0x0206,
    Always = 0x0207,
}

public enum AlphaFunction
{
    Never = 0x0200,
    Less = 0x0201,
    Equal = 0x0202,
    Lequal = 0x0203,
    Greater = 0x0204,
    Notequal = 0x0205,
    Gequal = 0x0206,
    Always = 0x0207,
}

public enum DepthFunction
{
    Never = 0x0200,
    Less = 0x0201,
    Equal = 0x0202,
    Lequal = 0x0203,
    Greater = 0x0204,
    Notequal = 0x0205,
    Gequal = 0x0206,
    Always = 0x0207,
}

public enum TriangleFace
{
    Front = 0x0404,
    Back = 0x0405,
    FrontAndBack = 0x0408,
}

public enum FeedbackType
{
    _2D = 0x0600,
    _3D = 0x0601,
    _3DColor = 0x0602,
    _3DColorTexture = 0x0603,
    _4dColorTexture = 0x0604,
}

public enum FeedBackToken
{
    PassThroughToken = 0x0700,
    PointToken = 0x0701,
    LineToken = 0x0702,
    PolygonToken = 0x0703,
    BitmapToken = 0x0704,
    DrawPixelToken = 0x0705,
    CopyPixelToken = 0x0706,
    LineResetToken = 0x0707,
}

public enum FogMode
{
    Exp = 0x0800,
    Exp2 = 0x0801,
    Linear = 0x2601,
}

public enum FrontFaceDirection
{
    Cw = 0x0900,
    Ccw = 0x0901,
}

public enum MapQuery
{
    Coeff = 0x0A00,
    Order = 0x0A01,
    Domain = 0x0A02,
}

public enum GetMapQuery
{
    Coeff = 0x0A00,
    Order = 0x0A01,
    Domain = 0x0A02,
}

public enum GetPName
{
    CurrentColor = 0x0B00,
    CurrentIndex = 0x0B01,
    CurrentNormal = 0x0B02,
    CurrentTextureCoords = 0x0B03,
    CurrentRasterColor = 0x0B04,
    CurrentRasterIndex = 0x0B05,
    CurrentRasterTextureCoords = 0x0B06,
    CurrentRasterPosition = 0x0B07,
    CurrentRasterPositionValid = 0x0B08,
    CurrentRasterDistance = 0x0B09,
    PointSmooth = 0x0B10,
    PointSize = 0x0B11,
    PointSizeRange = 0x0B12,
    SmoothPointSizeRange = 0x0B12,
    PointSizeGranularity = 0x0B13,
    SmoothPointSizeGranularity = 0x0B13,
    LineSmooth = 0x0B20,
    LineWidth = 0x0B21,
    LineWidthRange = 0x0B22,
    SmoothLineWidthRange = 0x0B22,
    LineWidthGranularity = 0x0B23,
    SmoothLineWidthGranularity = 0x0B23,
    LineStipple = 0x0B24,
    LineStipplePattern = 0x0B25,
    LineStippleRepeat = 0x0B26,
    ListMode = 0x0B30,
    MaxListNesting = 0x0B31,
    ListBase = 0x0B32,
    ListIndex = 0x0B33,
    PolygonMode = 0x0B40,
    PolygonSmooth = 0x0B41,
    PolygonStipple = 0x0B42,
    EdgeFlag = 0x0B43,
    CullFace = 0x0B44,
    CullFaceMode = 0x0B45,
    FrontFace = 0x0B46,
    Lighting = 0x0B50,
    LightModelLocalViewer = 0x0B51,
    LightModelTwoSide = 0x0B52,
    LightModelAmbient = 0x0B53,
    ShadeModel = 0x0B54,
    ColorMaterialFace = 0x0B55,
    ColorMaterialParameter = 0x0B56,
    ColorMaterial = 0x0B57,
    Fog = 0x0B60,
    FogIndex = 0x0B61,
    FogDensity = 0x0B62,
    FogStart = 0x0B63,
    FogEnd = 0x0B64,
    FogMode = 0x0B65,
    FogColor = 0x0B66,
    DepthRange = 0x0B70,
    DepthTest = 0x0B71,
    DepthWritemask = 0x0B72,
    DepthClearValue = 0x0B73,
    DepthFunc = 0x0B74,
    AccumClearValue = 0x0B80,
    StencilTest = 0x0B90,
    StencilClearValue = 0x0B91,
    StencilFunc = 0x0B92,
    StencilValueMask = 0x0B93,
    StencilFail = 0x0B94,
    StencilPassDepthFail = 0x0B95,
    StencilPassDepthPass = 0x0B96,
    StencilRef = 0x0B97,
    StencilWritemask = 0x0B98,
    MatrixMode = 0x0BA0,
    Normalize = 0x0BA1,
    Viewport = 0x0BA2,
    ModelviewStackDepth = 0x0BA3,
    ProjectionStackDepth = 0x0BA4,
    TextureStackDepth = 0x0BA5,
    ModelviewMatrix = 0x0BA6,
    ProjectionMatrix = 0x0BA7,
    TextureMatrix = 0x0BA8,
    AttribStackDepth = 0x0BB0,
    ClientAttribStackDepth = 0x0BB1,
    AlphaTest = 0x0BC0,
    AlphaTestFunc = 0x0BC1,
    AlphaTestRef = 0x0BC2,
    Dither = 0x0BD0,
    BlendDst = 0x0BE0,
    BlendSrc = 0x0BE1,
    Blend = 0x0BE2,
    LogicOpMode = 0x0BF0,
    IndexLogicOp = 0x0BF1,
    LogicOp = 0x0BF1,
    ColorLogicOp = 0x0BF2,
    AuxBuffers = 0x0C00,
    DrawBuffer = 0x0C01,
    ReadBuffer = 0x0C02,
    ScissorBox = 0x0C10,
    ScissorTest = 0x0C11,
    IndexClearValue = 0x0C20,
    IndexWritemask = 0x0C21,
    ColorClearValue = 0x0C22,
    ColorWritemask = 0x0C23,
    IndexMode = 0x0C30,
    RgbaMode = 0x0C31,
    Doublebuffer = 0x0C32,
    Stereo = 0x0C33,
    RenderMode = 0x0C40,
    PerspectiveCorrectionHint = 0x0C50,
    PointSmoothHint = 0x0C51,
    LineSmoothHint = 0x0C52,
    PolygonSmoothHint = 0x0C53,
    FogHint = 0x0C54,
    TextureGenS = 0x0C60,
    TextureGenT = 0x0C61,
    TextureGenR = 0x0C62,
    TextureGenQ = 0x0C63,
    PixelMapIToISize = 0x0CB0,
    PixelMapSToSSize = 0x0CB1,
    PixelMapIToRSize = 0x0CB2,
    PixelMapIToGSize = 0x0CB3,
    PixelMapIToBSize = 0x0CB4,
    PixelMapIToASize = 0x0CB5,
    PixelMapRToRSize = 0x0CB6,
    PixelMapGToGSize = 0x0CB7,
    PixelMapBToBSize = 0x0CB8,
    PixelMapAToASize = 0x0CB9,
    UnpackSwapBytes = 0x0CF0,
    UnpackLsbFirst = 0x0CF1,
    UnpackRowLength = 0x0CF2,
    UnpackSkipRows = 0x0CF3,
    UnpackSkipPixels = 0x0CF4,
    UnpackAlignment = 0x0CF5,
    PackSwapBytes = 0x0D00,
    PackLsbFirst = 0x0D01,
    PackRowLength = 0x0D02,
    PackSkipRows = 0x0D03,
    PackSkipPixels = 0x0D04,
    PackAlignment = 0x0D05,
    MapColor = 0x0D10,
    MapStencil = 0x0D11,
    IndexShift = 0x0D12,
    IndexOffset = 0x0D13,
    RedScale = 0x0D14,
    RedBias = 0x0D15,
    ZoomX = 0x0D16,
    ZoomY = 0x0D17,
    GreenScale = 0x0D18,
    GreenBias = 0x0D19,
    BlueScale = 0x0D1A,
    BlueBias = 0x0D1B,
    AlphaScale = 0x0D1C,
    AlphaBias = 0x0D1D,
    DepthScale = 0x0D1E,
    DepthBias = 0x0D1F,
    MaxEvalOrder = 0x0D30,
    MaxLights = 0x0D31,
    MaxClipPlanes = 0x0D32,
    MaxClipDistances = 0x0D32,
    MaxTextureSize = 0x0D33,
    MaxPixelMapTable = 0x0D34,
    MaxAttribStackDepth = 0x0D35,
    MaxModelviewStackDepth = 0x0D36,
    MaxNameStackDepth = 0x0D37,
    MaxProjectionStackDepth = 0x0D38,
    MaxTextureStackDepth = 0x0D39,
    MaxViewportDims = 0x0D3A,
    MaxClientAttribStackDepth = 0x0D3B,
    SubpixelBits = 0x0D50,
    IndexBits = 0x0D51,
    RedBits = 0x0D52,
    GreenBits = 0x0D53,
    BlueBits = 0x0D54,
    AlphaBits = 0x0D55,
    DepthBits = 0x0D56,
    StencilBits = 0x0D57,
    AccumRedBits = 0x0D58,
    AccumGreenBits = 0x0D59,
    AccumBlueBits = 0x0D5A,
    AccumAlphaBits = 0x0D5B,
    NameStackDepth = 0x0D70,
    AutoNormal = 0x0D80,
    Map1Color4 = 0x0D90,
    Map1Index = 0x0D91,
    Map1Normal = 0x0D92,
    Map1TextureCoord1 = 0x0D93,
    Map1TextureCoord2 = 0x0D94,
    Map1TextureCoord3 = 0x0D95,
    Map1TextureCoord4 = 0x0D96,
    Map1Vertex3 = 0x0D97,
    Map1Vertex4 = 0x0D98,
    Map2Color4 = 0x0DB0,
    Map2Index = 0x0DB1,
    Map2Normal = 0x0DB2,
    Map2TextureCoord1 = 0x0DB3,
    Map2TextureCoord2 = 0x0DB4,
    Map2TextureCoord3 = 0x0DB5,
    Map2TextureCoord4 = 0x0DB6,
    Map2Vertex3 = 0x0DB7,
    Map2Vertex4 = 0x0DB8,
    Map1GridDomain = 0x0DD0,
    Map1GridSegments = 0x0DD1,
    Map2GridDomain = 0x0DD2,
    Map2GridSegments = 0x0DD3,
    Texture1D = 0x0DE0,
    Texture2D = 0x0DE1,
    FeedbackBufferSize = 0x0DF1,
    FeedbackBufferType = 0x0DF2,
    SelectionBufferSize = 0x0DF4,
    PolygonOffsetUnits = 0x2A00,
    PolygonOffsetPoint = 0x2A01,
    PolygonOffsetLine = 0x2A02,
    ClipPlane0 = 0x3000,
    ClipPlane1 = 0x3001,
    ClipPlane2 = 0x3002,
    ClipPlane3 = 0x3003,
    ClipPlane4 = 0x3004,
    ClipPlane5 = 0x3005,
    Light0 = 0x4000,
    Light1 = 0x4001,
    Light2 = 0x4002,
    Light3 = 0x4003,
    Light4 = 0x4004,
    Light5 = 0x4005,
    Light6 = 0x4006,
    Light7 = 0x4007,
    BlendColor = 0x8005,
    BlendEquation = 0x8009,
    BlendEquationRgb = 0x8009,
    PolygonOffsetFill = 0x8037,
    PolygonOffsetFactor = 0x8038,
    TextureBinding1D = 0x8068,
    TextureBinding2D = 0x8069,
    TextureBinding3D = 0x806A,
    PackSkipImages = 0x806B,
    PackImageHeight = 0x806C,
    UnpackSkipImages = 0x806D,
    UnpackImageHeight = 0x806E,
    Max3DTextureSize = 0x8073,
    VertexArray = 0x8074,
    NormalArray = 0x8075,
    ColorArray = 0x8076,
    IndexArray = 0x8077,
    TextureCoordArray = 0x8078,
    EdgeFlagArray = 0x8079,
    VertexArraySize = 0x807A,
    VertexArrayType = 0x807B,
    VertexArrayStride = 0x807C,
    NormalArrayType = 0x807E,
    NormalArrayStride = 0x807F,
    ColorArraySize = 0x8081,
    ColorArrayType = 0x8082,
    ColorArrayStride = 0x8083,
    IndexArrayType = 0x8085,
    IndexArrayStride = 0x8086,
    TextureCoordArraySize = 0x8088,
    TextureCoordArrayType = 0x8089,
    TextureCoordArrayStride = 0x808A,
    EdgeFlagArrayStride = 0x808C,
    SampleBuffers = 0x80A8,
    Samples = 0x80A9,
    SampleCoverageValue = 0x80AA,
    SampleCoverageInvert = 0x80AB,
    BlendDstRgb = 0x80C8,
    BlendSrcRgb = 0x80C9,
    BlendDstAlpha = 0x80CA,
    BlendSrcAlpha = 0x80CB,
    MaxElementsVertices = 0x80E8,
    MaxElementsIndices = 0x80E9,
    PointSizeMin = 0x8126,

    [GLExtension("GL_ARB_point_parameters")]
    PointSizeMinARB = 0x8126,
    PointSizeMax = 0x8127,

    [GLExtension("GL_ARB_point_parameters")]
    PointSizeMaxARB = 0x8127,
    PointFadeThresholdSize = 0x8128,

    [GLExtension("GL_ARB_point_parameters")]
    PointFadeThresholdSizeARB = 0x8128,
    PointDistanceAttenuation = 0x8129,

    [GLExtension("GL_ARB_point_parameters")]
    PointDistanceAttenuationARB = 0x8129,
    LightModelColorControl = 0x81F8,
    MajorVersion = 0x821B,
    MinorVersion = 0x821C,
    NumExtensions = 0x821D,
    ContextFlags = 0x821E,
    ProgramPipelineBinding = 0x825A,
    MaxViewports = 0x825B,
    ViewportSubpixelBits = 0x825C,
    ViewportBoundsRange = 0x825D,
    LayerProvokingVertex = 0x825E,
    ViewportIndexProvokingVertex = 0x825F,
    MaxComputeUniformComponents = 0x8263,
    MaxComputeAtomicCounterBuffers = 0x8264,
    MaxComputeAtomicCounters = 0x8265,
    MaxCombinedComputeUniformComponents = 0x8266,
    MaxDebugGroupStackDepth = 0x826C,
    DebugGroupStackDepth = 0x826D,
    MaxUniformLocations = 0x826E,
    VertexBindingDivisor = 0x82D6,
    VertexBindingOffset = 0x82D7,
    VertexBindingStride = 0x82D8,
    MaxVertexAttribRelativeOffset = 0x82D9,
    MaxVertexAttribBindings = 0x82DA,
    MaxLabelLength = 0x82E8,
    AliasedPointSizeRange = 0x846D,
    AliasedLineWidthRange = 0x846E,
    ActiveTexture = 0x84E0,
    MaxRenderbufferSize = 0x84E8,
    TextureCompressionHint = 0x84EF,
    TextureBindingRectangle = 0x84F6,

    [GLExtension("GL_ARB_texture_rectangle")]
    TextureBindingRectangleARB = 0x84F6,
    MaxRectangleTextureSize = 0x84F8,
    MaxTextureLodBias = 0x84FD,
    TextureBindingCubeMap = 0x8514,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureBindingCubeMapARB = 0x8514,
    MaxCubeMapTextureSize = 0x851C,

    [GLExtension("GL_ARB_texture_cube_map")]
    MaxCubeMapTextureSizeARB = 0x851C,
    VertexArrayBinding = 0x85B5,
    ProgramPointSize = 0x8642,
    NumCompressedTextureFormats = 0x86A2,
    CompressedTextureFormats = 0x86A3,
    NumProgramBinaryFormats = 0x87FE,
    ProgramBinaryFormats = 0x87FF,
    StencilBackFunc = 0x8800,
    StencilBackFail = 0x8801,
    StencilBackPassDepthFail = 0x8802,
    StencilBackPassDepthPass = 0x8803,
    MaxDrawBuffers = 0x8824,
    BlendEquationAlpha = 0x883D,
    MaxVertexAttribs = 0x8869,
    MaxTextureImageUnits = 0x8872,
    ArrayBufferBinding = 0x8894,
    ElementArrayBufferBinding = 0x8895,
    PixelPackBufferBinding = 0x88ED,
    PixelUnpackBufferBinding = 0x88EF,
    MaxDualSourceDrawBuffers = 0x88FC,
    MaxArrayTextureLayers = 0x88FF,
    MinProgramTexelOffset = 0x8904,
    MaxProgramTexelOffset = 0x8905,
    SamplerBinding = 0x8919,
    UniformBufferBinding = 0x8A28,
    UniformBufferStart = 0x8A29,
    UniformBufferSize = 0x8A2A,
    MaxVertexUniformBlocks = 0x8A2B,
    MaxGeometryUniformBlocks = 0x8A2C,
    MaxFragmentUniformBlocks = 0x8A2D,
    MaxCombinedUniformBlocks = 0x8A2E,
    MaxUniformBufferBindings = 0x8A2F,
    MaxUniformBlockSize = 0x8A30,
    MaxCombinedVertexUniformComponents = 0x8A31,
    MaxCombinedGeometryUniformComponents = 0x8A32,
    MaxCombinedFragmentUniformComponents = 0x8A33,
    UniformBufferOffsetAlignment = 0x8A34,
    MaxFragmentUniformComponents = 0x8B49,
    MaxVertexUniformComponents = 0x8B4A,
    MaxVaryingFloats = 0x8B4B,
    MaxVaryingComponents = 0x8B4B,
    MaxVertexTextureImageUnits = 0x8B4C,
    MaxCombinedTextureImageUnits = 0x8B4D,
    FragmentShaderDerivativeHint = 0x8B8B,
    CurrentProgram = 0x8B8D,
    ImplementationColorReadType = 0x8B9A,
    ImplementationColorReadFormat = 0x8B9B,
    TextureBinding1DArray = 0x8C1C,
    TextureBinding2DArray = 0x8C1D,
    MaxGeometryTextureImageUnits = 0x8C29,
    MaxTextureBufferSize = 0x8C2B,
    TextureBindingBuffer = 0x8C2C,
    TransformFeedbackBufferStart = 0x8C84,
    TransformFeedbackBufferSize = 0x8C85,
    TransformFeedbackBufferBinding = 0x8C8F,
    StencilBackRef = 0x8CA3,
    StencilBackValueMask = 0x8CA4,
    StencilBackWritemask = 0x8CA5,
    DrawFramebufferBinding = 0x8CA6,
    RenderbufferBinding = 0x8CA7,
    ReadFramebufferBinding = 0x8CAA,
    MaxColorAttachments = 0x8CDF,
    MaxElementIndex = 0x8D6B,
    MaxGeometryUniformComponents = 0x8DDF,
    ShaderBinaryFormats = 0x8DF8,
    NumShaderBinaryFormats = 0x8DF9,
    ShaderCompiler = 0x8DFA,
    MaxVertexUniformVectors = 0x8DFB,
    MaxVaryingVectors = 0x8DFC,
    MaxFragmentUniformVectors = 0x8DFD,
    Timestamp = 0x8E28,
    ProvokingVertex = 0x8E4F,
    MaxSampleMaskWords = 0x8E59,
    MaxTessControlUniformBlocks = 0x8E89,
    MaxTessEvaluationUniformBlocks = 0x8E8A,
    PrimitiveRestartIndex = 0x8F9E,
    MinMapBufferAlignment = 0x90BC,
    ShaderStorageBufferBinding = 0x90D3,
    ShaderStorageBufferStart = 0x90D4,
    ShaderStorageBufferSize = 0x90D5,
    MaxVertexShaderStorageBlocks = 0x90D6,
    MaxGeometryShaderStorageBlocks = 0x90D7,
    MaxTessControlShaderStorageBlocks = 0x90D8,
    MaxTessEvaluationShaderStorageBlocks = 0x90D9,
    MaxFragmentShaderStorageBlocks = 0x90DA,
    MaxComputeShaderStorageBlocks = 0x90DB,
    MaxCombinedShaderStorageBlocks = 0x90DC,
    MaxShaderStorageBufferBindings = 0x90DD,
    ShaderStorageBufferOffsetAlignment = 0x90DF,
    MaxComputeWorkGroupInvocations = 0x90EB,
    DispatchIndirectBufferBinding = 0x90EF,
    TextureBinding2DMultisample = 0x9104,
    TextureBinding2DMultisampleArray = 0x9105,
    MaxColorTextureSamples = 0x910E,
    MaxDepthTextureSamples = 0x910F,
    MaxIntegerSamples = 0x9110,
    MaxServerWaitTimeout = 0x9111,
    MaxVertexOutputComponents = 0x9122,
    MaxGeometryInputComponents = 0x9123,
    MaxGeometryOutputComponents = 0x9124,
    MaxFragmentInputComponents = 0x9125,
    ContextProfileMask = 0x9126,
    TextureBufferOffsetAlignment = 0x919F,
    MaxComputeUniformBlocks = 0x91BB,
    MaxComputeTextureImageUnits = 0x91BC,
    MaxComputeWorkGroupCount = 0x91BE,
    MaxComputeWorkGroupSize = 0x91BF,
    MaxVertexAtomicCounters = 0x92D2,
    MaxTessControlAtomicCounters = 0x92D3,
    MaxTessEvaluationAtomicCounters = 0x92D4,
    MaxGeometryAtomicCounters = 0x92D5,
    MaxFragmentAtomicCounters = 0x92D6,
    MaxCombinedAtomicCounters = 0x92D7,
    MaxFramebufferWidth = 0x9315,
    MaxFramebufferHeight = 0x9316,
    MaxFramebufferLayers = 0x9317,
    MaxFramebufferSamples = 0x9318,
}

public enum VertexShaderTextureUnitParameter
{
    CurrentTextureCoords = 0x0B03,
    TextureMatrix = 0x0BA8,
}

public enum EnableCap
{
    PointSmooth = 0x0B10,
    LineSmooth = 0x0B20,
    LineStipple = 0x0B24,
    PolygonSmooth = 0x0B41,
    PolygonStipple = 0x0B42,
    CullFace = 0x0B44,
    Lighting = 0x0B50,
    ColorMaterial = 0x0B57,
    Fog = 0x0B60,
    DepthTest = 0x0B71,
    StencilTest = 0x0B90,
    Normalize = 0x0BA1,
    AlphaTest = 0x0BC0,
    Dither = 0x0BD0,
    Blend = 0x0BE2,
    IndexLogicOp = 0x0BF1,
    ColorLogicOp = 0x0BF2,
    ScissorTest = 0x0C11,
    TextureGenS = 0x0C60,
    TextureGenT = 0x0C61,
    TextureGenR = 0x0C62,
    TextureGenQ = 0x0C63,
    AutoNormal = 0x0D80,
    Map1Color4 = 0x0D90,
    Map1Index = 0x0D91,
    Map1Normal = 0x0D92,
    Map1TextureCoord1 = 0x0D93,
    Map1TextureCoord2 = 0x0D94,
    Map1TextureCoord3 = 0x0D95,
    Map1TextureCoord4 = 0x0D96,
    Map1Vertex3 = 0x0D97,
    Map1Vertex4 = 0x0D98,
    Map2Color4 = 0x0DB0,
    Map2Index = 0x0DB1,
    Map2Normal = 0x0DB2,
    Map2TextureCoord1 = 0x0DB3,
    Map2TextureCoord2 = 0x0DB4,
    Map2TextureCoord3 = 0x0DB5,
    Map2TextureCoord4 = 0x0DB6,
    Map2Vertex3 = 0x0DB7,
    Map2Vertex4 = 0x0DB8,
    Texture1D = 0x0DE0,
    Texture2D = 0x0DE1,
    PolygonOffsetPoint = 0x2A01,
    PolygonOffsetLine = 0x2A02,
    ClipPlane0 = 0x3000,
    ClipDistance0 = 0x3000,
    ClipPlane1 = 0x3001,
    ClipDistance1 = 0x3001,
    ClipPlane2 = 0x3002,
    ClipDistance2 = 0x3002,
    ClipPlane3 = 0x3003,
    ClipDistance3 = 0x3003,
    ClipPlane4 = 0x3004,
    ClipDistance4 = 0x3004,
    ClipPlane5 = 0x3005,
    ClipDistance5 = 0x3005,
    ClipDistance6 = 0x3006,
    ClipDistance7 = 0x3007,
    Light0 = 0x4000,
    Light1 = 0x4001,
    Light2 = 0x4002,
    Light3 = 0x4003,
    Light4 = 0x4004,
    Light5 = 0x4005,
    Light6 = 0x4006,
    Light7 = 0x4007,
    PolygonOffsetFill = 0x8037,
    VertexArray = 0x8074,
    NormalArray = 0x8075,
    ColorArray = 0x8076,
    IndexArray = 0x8077,
    TextureCoordArray = 0x8078,
    EdgeFlagArray = 0x8079,
    Multisample = 0x809D,
    SampleAlphaToCoverage = 0x809E,
    SampleAlphaToOne = 0x809F,
    SampleCoverage = 0x80A0,
    ColorTable = 0x80D0,
    PostConvolutionColorTable = 0x80D1,
    PostColorMatrixColorTable = 0x80D2,
    DebugOutputSynchronous = 0x8242,
    TextureRectangle = 0x84F5,

    [GLExtension("GL_ARB_texture_rectangle")]
    TextureRectangleARB = 0x84F5,
    TextureCubeMap = 0x8513,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapARB = 0x8513,
    ProgramPointSize = 0x8642,
    DepthClamp = 0x864F,
    TextureCubeMapSeamless = 0x884F,
    SampleShading = 0x8C36,
    RasterizerDiscard = 0x8C89,
    PrimitiveRestartFixedIndex = 0x8D69,
    FramebufferSrgb = 0x8DB9,
    SampleMask = 0x8E51,
    PrimitiveRestart = 0x8F9D,
    DebugOutput = 0x92E0,
}

public enum LightModelParameter
{
    LightModelLocalViewer = 0x0B51,
    LightModelTwoSide = 0x0B52,
    LightModelAmbient = 0x0B53,
    LightModelColorControl = 0x81F8,
}

public enum FogPName
{
    FogIndex = 0x0B61,
    FogDensity = 0x0B62,
    FogStart = 0x0B63,
    FogEnd = 0x0B64,
    FogMode = 0x0B65,
    FogCoordSrc = 0x8450,
}

public enum FogParameter
{
    FogIndex = 0x0B61,
    FogDensity = 0x0B62,
    FogStart = 0x0B63,
    FogEnd = 0x0B64,
    FogMode = 0x0B65,
    FogColor = 0x0B66,
}

public enum GetFramebufferParameter
{
    Doublebuffer = 0x0C32,
    Stereo = 0x0C33,
    SampleBuffers = 0x80A8,
    Samples = 0x80A9,
    ImplementationColorReadType = 0x8B9A,
    ImplementationColorReadFormat = 0x8B9B,
    FramebufferDefaultWidth = 0x9310,
    FramebufferDefaultHeight = 0x9311,
    FramebufferDefaultLayers = 0x9312,
    FramebufferDefaultSamples = 0x9313,
    FramebufferDefaultFixedSampleLocations = 0x9314,
}

public enum HintTarget
{
    PerspectiveCorrectionHint = 0x0C50,
    PointSmoothHint = 0x0C51,
    LineSmoothHint = 0x0C52,
    PolygonSmoothHint = 0x0C53,
    FogHint = 0x0C54,
    GenerateMipmapHint = 0x8192,
    ProgramBinaryRetrievableHint = 0x8257,
    LineQualityHintSGIX = 0x835B,
    TextureCompressionHint = 0x84EF,

    [GLExtension("GL_ARB_texture_compression")]
    TextureCompressionHintARB = 0x84EF,
    FragmentShaderDerivativeHint = 0x8B8B,

    [GLExtension("GL_ARB_fragment_shader")]
    FragmentShaderDerivativeHintARB = 0x8B8B,
}

public enum PixelMap
{
    PixelMapIToI = 0x0C70,
    PixelMapSToS = 0x0C71,
    PixelMapIToR = 0x0C72,
    PixelMapIToG = 0x0C73,
    PixelMapIToB = 0x0C74,
    PixelMapIToA = 0x0C75,
    PixelMapRToR = 0x0C76,
    PixelMapGToG = 0x0C77,
    PixelMapBToB = 0x0C78,
    PixelMapAToA = 0x0C79,
}

public enum PixelStoreParameter
{
    UnpackSwapBytes = 0x0CF0,
    UnpackLsbFirst = 0x0CF1,
    UnpackRowLength = 0x0CF2,
    UnpackSkipRows = 0x0CF3,
    UnpackSkipPixels = 0x0CF4,
    UnpackAlignment = 0x0CF5,
    PackSwapBytes = 0x0D00,
    PackLsbFirst = 0x0D01,
    PackRowLength = 0x0D02,
    PackSkipRows = 0x0D03,
    PackSkipPixels = 0x0D04,
    PackAlignment = 0x0D05,
    PackSkipImages = 0x806B,
    PackImageHeight = 0x806C,
    UnpackSkipImages = 0x806D,
    UnpackImageHeight = 0x806E,
}

public enum PixelTransferParameter
{
    MapColor = 0x0D10,
    MapStencil = 0x0D11,
    IndexShift = 0x0D12,
    IndexOffset = 0x0D13,
    RedScale = 0x0D14,
    RedBias = 0x0D15,
    GreenScale = 0x0D18,
    GreenBias = 0x0D19,
    BlueScale = 0x0D1A,
    BlueBias = 0x0D1B,
    AlphaScale = 0x0D1C,
    AlphaBias = 0x0D1D,
    DepthScale = 0x0D1E,
    DepthBias = 0x0D1F,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionRedScale = 0x801C,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionGreenScale = 0x801D,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionBlueScale = 0x801E,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionAlphaScale = 0x801F,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionRedBias = 0x8020,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionGreenBias = 0x8021,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionBlueBias = 0x8022,

    [GLExtension("GL_ARB_imaging")]
    PostConvolutionAlphaBias = 0x8023,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixRedScale = 0x80B4,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixGreenScale = 0x80B5,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixBlueScale = 0x80B6,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixAlphaScale = 0x80B7,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixRedBias = 0x80B8,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixGreenBias = 0x80B9,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixBlueBias = 0x80BA,

    [GLExtension("GL_ARB_imaging")]
    PostColorMatrixAlphaBias = 0x80BB,
}

public enum IndexMaterialParameterEXT
{
    IndexOffset = 0x0D13,
}

public enum TextureEnvParameter
{
    AlphaScale = 0x0D1C,
    TextureEnvMode = 0x2200,
    TextureEnvColor = 0x2201,
    TextureLodBias = 0x8501,
    Combine = 0x8570,

    [GLExtension("GL_ARB_texture_env_combine")]
    CombineARB = 0x8570,
    CombineRgb = 0x8571,

    [GLExtension("GL_ARB_texture_env_combine")]
    CombineRgbARB = 0x8571,
    CombineAlpha = 0x8572,

    [GLExtension("GL_ARB_texture_env_combine")]
    CombineAlphaARB = 0x8572,
    RgbScale = 0x8573,

    [GLExtension("GL_ARB_texture_env_combine")]
    RgbScaleARB = 0x8573,
    AddSigned = 0x8574,

    [GLExtension("GL_ARB_texture_env_combine")]
    AddSignedARB = 0x8574,
    Interpolate = 0x8575,

    [GLExtension("GL_ARB_texture_env_combine")]
    InterpolateARB = 0x8575,
    Constant = 0x8576,

    [GLExtension("GL_ARB_texture_env_combine")]
    ConstantARB = 0x8576,
    PrimaryColor = 0x8577,

    [GLExtension("GL_ARB_texture_env_combine")]
    PrimaryColorARB = 0x8577,
    Previous = 0x8578,

    [GLExtension("GL_ARB_texture_env_combine")]
    PreviousARB = 0x8578,
    Source0Rgb = 0x8580,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source0RgbARB = 0x8580,
    Src0Rgb = 0x8580,
    Source1Rgb = 0x8581,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source1RgbARB = 0x8581,
    Src1Rgb = 0x8581,
    Source2Rgb = 0x8582,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source2RgbARB = 0x8582,
    Src2Rgb = 0x8582,
    Source0Alpha = 0x8588,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source0AlphaARB = 0x8588,
    Src0Alpha = 0x8588,
    Source1Alpha = 0x8589,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source1AlphaARB = 0x8589,
    Src1Alpha = 0x8589,
    Source2Alpha = 0x858A,

    [GLExtension("GL_ARB_texture_env_combine")]
    Source2AlphaARB = 0x858A,
    Src2Alpha = 0x858A,
    Operand0Rgb = 0x8590,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand0RgbARB = 0x8590,
    Operand1Rgb = 0x8591,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand1RgbARB = 0x8591,
    Operand2Rgb = 0x8592,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand2RgbARB = 0x8592,
    Operand0Alpha = 0x8598,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand0AlphaARB = 0x8598,
    Operand1Alpha = 0x8599,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand1AlphaARB = 0x8599,
    Operand2Alpha = 0x859A,

    [GLExtension("GL_ARB_texture_env_combine")]
    Operand2AlphaARB = 0x859A,
    CoordReplace = 0x8862,
}

public enum MapTarget
{
    Map1Color4 = 0x0D90,
    Map1Index = 0x0D91,
    Map1Normal = 0x0D92,
    Map1TextureCoord1 = 0x0D93,
    Map1TextureCoord2 = 0x0D94,
    Map1TextureCoord3 = 0x0D95,
    Map1TextureCoord4 = 0x0D96,
    Map1Vertex3 = 0x0D97,
    Map1Vertex4 = 0x0D98,
    Map2Color4 = 0x0DB0,
    Map2Index = 0x0DB1,
    Map2Normal = 0x0DB2,
    Map2TextureCoord1 = 0x0DB3,
    Map2TextureCoord2 = 0x0DB4,
    Map2TextureCoord3 = 0x0DB5,
    Map2TextureCoord4 = 0x0DB6,
    Map2Vertex3 = 0x0DB7,
    Map2Vertex4 = 0x0DB8,
}

public enum CopyImageSubDataTarget
{
    Texture1D = 0x0DE0,
    Texture2D = 0x0DE1,
    Texture3D = 0x806F,
    TextureRectangle = 0x84F5,
    TextureCubeMap = 0x8513,
    Texture1DArray = 0x8C18,
    Texture2DArray = 0x8C1A,
    Renderbuffer = 0x8D41,
    TextureCubeMapArray = 0x9009,
    Texture2DMultisample = 0x9100,
    Texture2DMultisampleArray = 0x9102,
}

public enum TextureTarget
{
    Texture1D = 0x0DE0,
    Texture2D = 0x0DE1,
    ProxyTexture1D = 0x8063,
    ProxyTexture2D = 0x8064,
    Texture3D = 0x806F,
    ProxyTexture3D = 0x8070,
    TextureRectangle = 0x84F5,

    [GLExtension("GL_ARB_texture_rectangle")]
    TextureRectangleARB = 0x84F5,
    ProxyTextureRectangle = 0x84F7,

    [GLExtension("GL_ARB_texture_rectangle")]
    ProxyTextureRectangleARB = 0x84F7,
    TextureCubeMap = 0x8513,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapARB = 0x8513,
    TextureCubeMapPositiveX = 0x8515,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapPositiveXARB = 0x8515,
    TextureCubeMapNegativeX = 0x8516,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapNegativeXARB = 0x8516,
    TextureCubeMapPositiveY = 0x8517,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapPositiveYARB = 0x8517,
    TextureCubeMapNegativeY = 0x8518,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapNegativeYARB = 0x8518,
    TextureCubeMapPositiveZ = 0x8519,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapPositiveZARB = 0x8519,
    TextureCubeMapNegativeZ = 0x851A,

    [GLExtension("GL_ARB_texture_cube_map")]
    TextureCubeMapNegativeZARB = 0x851A,
    ProxyTextureCubeMap = 0x851B,

    [GLExtension("GL_ARB_texture_cube_map")]
    ProxyTextureCubeMapARB = 0x851B,
    Texture1DArray = 0x8C18,
    ProxyTexture1DArray = 0x8C19,
    Texture2DArray = 0x8C1A,
    ProxyTexture2DArray = 0x8C1B,
    TextureBuffer = 0x8C2A,
    Renderbuffer = 0x8D41,
    TextureCubeMapArray = 0x9009,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    TextureCubeMapArrayARB = 0x9009,
    ProxyTextureCubeMapArray = 0x900B,

    [GLExtension("GL_ARB_texture_cube_map_array")]
    ProxyTextureCubeMapArrayARB = 0x900B,
    Texture2DMultisample = 0x9100,
    ProxyTexture2DMultisample = 0x9101,
    Texture2DMultisampleArray = 0x9102,
    ProxyTexture2DMultisampleArray = 0x9103,
}

public enum GetPointervPName
{
    FeedbackBufferPointer = 0x0DF0,
    SelectionBufferPointer = 0x0DF3,
    VertexArrayPointer = 0x808E,
    NormalArrayPointer = 0x808F,
    ColorArrayPointer = 0x8090,
    IndexArrayPointer = 0x8091,
    TextureCoordArrayPointer = 0x8092,
    EdgeFlagArrayPointer = 0x8093,
    DebugCallbackFunction = 0x8244,
    DebugCallbackUserParam = 0x8245,
}

public enum TextureParameterName
{
    TextureWidth = 0x1000,
    TextureHeight = 0x1001,
    TextureInternalFormat = 0x1003,
    TextureComponents = 0x1003,
    TextureBorderColor = 0x1004,
    TextureBorder = 0x1005,
    TextureMagFilter = 0x2800,
    TextureMinFilter = 0x2801,
    TextureWrapS = 0x2802,
    TextureWrapT = 0x2803,
    TextureRedSize = 0x805C,
    TextureGreenSize = 0x805D,
    TextureBlueSize = 0x805E,
    TextureAlphaSize = 0x805F,
    TextureLuminanceSize = 0x8060,
    TextureIntensitySize = 0x8061,
    TexturePriority = 0x8066,
    TextureResident = 0x8067,
    TextureWrapR = 0x8072,
    TextureMinLod = 0x813A,
    TextureMaxLod = 0x813B,
    TextureBaseLevel = 0x813C,
    TextureMaxLevel = 0x813D,
    GenerateMipmap = 0x8191,
    TextureMaxAnisotropy = 0x84FE,
    TextureLodBias = 0x8501,
    TextureCompareMode = 0x884C,
    TextureCompareFunc = 0x884D,
    TextureSwizzleR = 0x8E42,
    TextureSwizzleG = 0x8E43,
    TextureSwizzleB = 0x8E44,
    TextureSwizzleA = 0x8E45,
    TextureSwizzleRgba = 0x8E46,
    DepthStencilTextureMode = 0x90EA,
}

public enum GetTextureParameter
{
    TextureWidth = 0x1000,
    TextureHeight = 0x1001,
    TextureInternalFormat = 0x1003,
    TextureComponents = 0x1003,
    TextureBorderColor = 0x1004,
    TextureBorder = 0x1005,
    TextureMagFilter = 0x2800,
    TextureMinFilter = 0x2801,
    TextureWrapS = 0x2802,
    TextureWrapT = 0x2803,
    TextureRedSize = 0x805C,
    TextureGreenSize = 0x805D,
    TextureBlueSize = 0x805E,
    TextureAlphaSize = 0x805F,
    TextureLuminanceSize = 0x8060,
    TextureIntensitySize = 0x8061,
    TexturePriority = 0x8066,
    TextureResident = 0x8067,
    NormalMap = 0x8511,

    [GLExtension("GL_ARB_texture_cube_map")]
    NormalMapARB = 0x8511,
    ReflectionMap = 0x8512,

    [GLExtension("GL_ARB_texture_cube_map")]
    ReflectionMapARB = 0x8512,
}

public enum SamplerParameterF
{
    TextureBorderColor = 0x1004,
    TextureMinLod = 0x813A,
    TextureMaxLod = 0x813B,
    TextureMaxAnisotropy = 0x84FE,
    TextureLodBias = 0x8501,
}

public enum DebugSeverity
{
    DontCare = 0x1100,
    DebugSeverityNotification = 0x826B,
    DebugSeverityHigh = 0x9146,
    DebugSeverityMedium = 0x9147,
    DebugSeverityLow = 0x9148,
}

public enum HintMode
{
    DontCare = 0x1100,
    Fastest = 0x1101,
    Nicest = 0x1102,
}

public enum DebugSource
{
    DontCare = 0x1100,
    DebugSourceApi = 0x8246,
    DebugSourceWindowSystem = 0x8247,
    DebugSourceShaderCompiler = 0x8248,
    DebugSourceThirdParty = 0x8249,
    DebugSourceApplication = 0x824A,
    DebugSourceOther = 0x824B,
}

public enum DebugType
{
    DontCare = 0x1100,
    DebugTypeError = 0x824C,
    DebugTypeDeprecatedBehavior = 0x824D,
    DebugTypeUndefinedBehavior = 0x824E,
    DebugTypePortability = 0x824F,
    DebugTypePerformance = 0x8250,
    DebugTypeOther = 0x8251,
    DebugTypeMarker = 0x8268,
    DebugTypePushGroup = 0x8269,
    DebugTypePopGroup = 0x826A,
}

public enum MaterialParameter
{
    Ambient = 0x1200,
    Diffuse = 0x1201,
    Specular = 0x1202,
    Emission = 0x1600,
    Shininess = 0x1601,
    AmbientAndDiffuse = 0x1602,
    ColorIndexes = 0x1603,
}

public enum FragmentLightParameterSGIX
{
    Ambient = 0x1200,
    Diffuse = 0x1201,
    Specular = 0x1202,
    Position = 0x1203,
    SpotDirection = 0x1204,
    SpotExponent = 0x1205,
    SpotCutoff = 0x1206,
    ConstantAttenuation = 0x1207,
    LinearAttenuation = 0x1208,
    QuadraticAttenuation = 0x1209,
}

public enum ColorMaterialParameter
{
    Ambient = 0x1200,
    Diffuse = 0x1201,
    Specular = 0x1202,
    Emission = 0x1600,
    AmbientAndDiffuse = 0x1602,
}

public enum LightParameter
{
    Position = 0x1203,
    SpotDirection = 0x1204,
    SpotExponent = 0x1205,
    SpotCutoff = 0x1206,
    ConstantAttenuation = 0x1207,
    LinearAttenuation = 0x1208,
    QuadraticAttenuation = 0x1209,
}

public enum ListMode
{
    Compile = 0x1300,
    CompileAndExecute = 0x1301,
}

public enum VertexAttribIType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
}

public enum WeightPointerTypeARB
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    Double = 0x140A,
}

public enum TangentPointerTypeEXT
{
    Byte = 0x1400,
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
    DoubleEXT = 0x140A,
}

public enum BinormalPointerTypeEXT
{
    Byte = 0x1400,
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
    DoubleEXT = 0x140A,
}

public enum ColorPointerType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum ListNameType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    _2Bytes = 0x1407,
    _3Bytes = 0x1408,
    _4Bytes = 0x1409,
}

public enum NormalPointerType
{
    Byte = 0x1400,
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
}

public enum PixelType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    HalfFloat = 0x140B,

    [GLExtension("GL_ARB_half_float_pixel")]
    HalfFloatARB = 0x140B,
    Bitmap = 0x1A00,
    UnsignedByte332 = 0x8032,
    UnsignedShort4444 = 0x8033,
    UnsignedShort5551 = 0x8034,
    UnsignedInt8888 = 0x8035,
    UnsignedInt1010102 = 0x8036,
    UnsignedByte233Rev = 0x8362,
    UnsignedByte233RevEXT = 0x8362,
    UnsignedShort565 = 0x8363,
    UnsignedShort565EXT = 0x8363,
    UnsignedShort565Rev = 0x8364,
    UnsignedShort565RevEXT = 0x8364,
    UnsignedShort4444Rev = 0x8365,
    UnsignedShort1555Rev = 0x8366,
    UnsignedInt8888Rev = 0x8367,
    UnsignedInt8888RevEXT = 0x8367,
    UnsignedInt2101010Rev = 0x8368,
    UnsignedInt248 = 0x84FA,
    UnsignedInt10f11f11fRev = 0x8C3B,
    UnsignedInt5999Rev = 0x8C3E,
    Float32UnsignedInt248Rev = 0x8DAD,
}

public enum VertexAttribType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    Double = 0x140A,
    HalfFloat = 0x140B,
    Fixed = 0x140C,
    UnsignedInt2101010Rev = 0x8368,
    UnsignedInt10f11f11fRev = 0x8C3B,
    Int2101010Rev = 0x8D9F,
}

public enum VertexAttribPointerType
{
    Byte = 0x1400,
    UnsignedByte = 0x1401,
    Short = 0x1402,
    UnsignedShort = 0x1403,
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    Double = 0x140A,
    HalfFloat = 0x140B,
    Fixed = 0x140C,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    Int64ARB = 0x140E,

    [GLExtension("GL_ARB_bindless_texture")]
    UnsignedInt64ARB = 0x140F,
    UnsignedInt2101010Rev = 0x8368,
    UnsignedInt10f11f11fRev = 0x8C3B,
    Int2101010Rev = 0x8D9F,
}

public enum ScalarType
{
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum ReplacementCodeTypeSUN
{
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum ElementPointerTypeATI
{
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum MatrixIndexPointerTypeARB
{
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum DrawElementsType
{
    UnsignedByte = 0x1401,
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
}

public enum SecondaryColorPointerTypeIBM
{
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
}

public enum IndexPointerType
{
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
}

public enum TexCoordPointerType
{
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
}

public enum VertexPointerType
{
    Short = 0x1402,
    Int = 0x1404,
    Float = 0x1406,
    Double = 0x140A,
}

public enum PixelFormat
{
    UnsignedShort = 0x1403,
    UnsignedInt = 0x1405,
    ColorIndex = 0x1900,
    StencilIndex = 0x1901,
    DepthComponent = 0x1902,
    Red = 0x1903,
    Green = 0x1904,
    Blue = 0x1905,
    Alpha = 0x1906,
    Rgb = 0x1907,
    Rgba = 0x1908,
    Luminance = 0x1909,
    LuminanceAlpha = 0x190A,
    Bgr = 0x80E0,
    Bgra = 0x80E1,
    Rg = 0x8227,
    RgInteger = 0x8228,
    DepthStencil = 0x84F9,
    RedInteger = 0x8D94,
    GreenInteger = 0x8D95,
    BlueInteger = 0x8D96,
    RgbInteger = 0x8D98,
    RgbaInteger = 0x8D99,
    BgrInteger = 0x8D9A,
    BgraInteger = 0x8D9B,
}

public enum AttributeType
{
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    Double = 0x140A,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    Int64ARB = 0x140E,

    [GLExtension("GL_ARB_bindless_texture")]
    UnsignedInt64ARB = 0x140F,
    FloatVec2 = 0x8B50,

    [GLExtension("GL_ARB_shader_objects")]
    FloatVec2ARB = 0x8B50,
    FloatVec3 = 0x8B51,

    [GLExtension("GL_ARB_shader_objects")]
    FloatVec3ARB = 0x8B51,
    FloatVec4 = 0x8B52,

    [GLExtension("GL_ARB_shader_objects")]
    FloatVec4ARB = 0x8B52,
    IntVec2 = 0x8B53,

    [GLExtension("GL_ARB_shader_objects")]
    IntVec2ARB = 0x8B53,
    IntVec3 = 0x8B54,

    [GLExtension("GL_ARB_shader_objects")]
    IntVec3ARB = 0x8B54,
    IntVec4 = 0x8B55,

    [GLExtension("GL_ARB_shader_objects")]
    IntVec4ARB = 0x8B55,
    Bool = 0x8B56,

    [GLExtension("GL_ARB_shader_objects")]
    BoolARB = 0x8B56,
    BoolVec2 = 0x8B57,

    [GLExtension("GL_ARB_shader_objects")]
    BoolVec2ARB = 0x8B57,
    BoolVec3 = 0x8B58,

    [GLExtension("GL_ARB_shader_objects")]
    BoolVec3ARB = 0x8B58,
    BoolVec4 = 0x8B59,

    [GLExtension("GL_ARB_shader_objects")]
    BoolVec4ARB = 0x8B59,
    FloatMat2 = 0x8B5A,

    [GLExtension("GL_ARB_shader_objects")]
    FloatMat2ARB = 0x8B5A,
    FloatMat3 = 0x8B5B,

    [GLExtension("GL_ARB_shader_objects")]
    FloatMat3ARB = 0x8B5B,
    FloatMat4 = 0x8B5C,

    [GLExtension("GL_ARB_shader_objects")]
    FloatMat4ARB = 0x8B5C,
    Sampler1D = 0x8B5D,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler1DARB = 0x8B5D,
    Sampler2D = 0x8B5E,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler2DARB = 0x8B5E,
    Sampler3D = 0x8B5F,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler3DARB = 0x8B5F,
    SamplerCube = 0x8B60,

    [GLExtension("GL_ARB_shader_objects")]
    SamplerCubeARB = 0x8B60,
    Sampler1DShadow = 0x8B61,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler1DShadowARB = 0x8B61,
    Sampler2DShadow = 0x8B62,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler2DShadowARB = 0x8B62,
    Sampler2DRect = 0x8B63,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler2DRectARB = 0x8B63,
    Sampler2DRectShadow = 0x8B64,

    [GLExtension("GL_ARB_shader_objects")]
    Sampler2DRectShadowARB = 0x8B64,
    FloatMat2x3 = 0x8B65,
    FloatMat2x4 = 0x8B66,
    FloatMat3x2 = 0x8B67,
    FloatMat3x4 = 0x8B68,
    FloatMat4x2 = 0x8B69,
    FloatMat4x3 = 0x8B6A,
    SamplerBuffer = 0x8DC2,
    Sampler1DArrayShadow = 0x8DC3,
    Sampler2DArrayShadow = 0x8DC4,
    SamplerCubeShadow = 0x8DC5,
    UnsignedIntVec2 = 0x8DC6,
    UnsignedIntVec3 = 0x8DC7,
    UnsignedIntVec4 = 0x8DC8,
    IntSampler1D = 0x8DC9,
    IntSampler2D = 0x8DCA,
    IntSampler3D = 0x8DCB,
    IntSamplerCube = 0x8DCC,
    IntSampler2DRect = 0x8DCD,
    IntSampler1DArray = 0x8DCE,
    IntSampler2DArray = 0x8DCF,
    IntSamplerBuffer = 0x8DD0,
    UnsignedIntSampler1D = 0x8DD1,
    UnsignedIntSampler2D = 0x8DD2,
    UnsignedIntSampler3D = 0x8DD3,
    UnsignedIntSamplerCube = 0x8DD4,
    UnsignedIntSampler2DRect = 0x8DD5,
    UnsignedIntSampler1DArray = 0x8DD6,
    UnsignedIntSampler2DArray = 0x8DD7,
    UnsignedIntSamplerBuffer = 0x8DD8,
    DoubleMat2 = 0x8F46,
    DoubleMat3 = 0x8F47,
    DoubleMat4 = 0x8F48,
    DoubleMat2x3 = 0x8F49,
    DoubleMat2x4 = 0x8F4A,
    DoubleMat3x2 = 0x8F4B,
    DoubleMat3x4 = 0x8F4C,
    DoubleMat4x2 = 0x8F4D,
    DoubleMat4x3 = 0x8F4E,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    Int64Vec2ARB = 0x8FE9,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    Int64Vec3ARB = 0x8FEA,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    Int64Vec4ARB = 0x8FEB,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    UnsignedInt64Vec2ARB = 0x8FF5,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    UnsignedInt64Vec3ARB = 0x8FF6,

    [GLExtension("GL_ARB_gpu_shader_int64")]
    UnsignedInt64Vec4ARB = 0x8FF7,
    DoubleVec2 = 0x8FFC,
    DoubleVec3 = 0x8FFD,
    DoubleVec4 = 0x8FFE,
    SamplerCubeMapArray = 0x900C,
    SamplerCubeMapArrayShadow = 0x900D,
    IntSamplerCubeMapArray = 0x900E,
    UnsignedIntSamplerCubeMapArray = 0x900F,
    Image1D = 0x904C,
    Image2D = 0x904D,
    Image3D = 0x904E,
    Image2DRect = 0x904F,
    ImageCube = 0x9050,
    ImageBuffer = 0x9051,
    Image1DArray = 0x9052,
    Image2DArray = 0x9053,
    ImageCubeMapArray = 0x9054,
    Image2DMultisample = 0x9055,
    Image2DMultisampleArray = 0x9056,
    IntImage1D = 0x9057,
    IntImage2D = 0x9058,
    IntImage3D = 0x9059,
    IntImage2DRect = 0x905A,
    IntImageCube = 0x905B,
    IntImageBuffer = 0x905C,
    IntImage1DArray = 0x905D,
    IntImage2DArray = 0x905E,
    IntImageCubeMapArray = 0x905F,
    IntImage2DMultisample = 0x9060,
    IntImage2DMultisampleArray = 0x9061,
    UnsignedIntImage1D = 0x9062,
    UnsignedIntImage2D = 0x9063,
    UnsignedIntImage3D = 0x9064,
    UnsignedIntImage2DRect = 0x9065,
    UnsignedIntImageCube = 0x9066,
    UnsignedIntImageBuffer = 0x9067,
    UnsignedIntImage1DArray = 0x9068,
    UnsignedIntImage2DArray = 0x9069,
    UnsignedIntImageCubeMapArray = 0x906A,
    UnsignedIntImage2DMultisample = 0x906B,
    UnsignedIntImage2DMultisampleArray = 0x906C,
    Sampler2DMultisample = 0x9108,
    IntSampler2DMultisample = 0x9109,
    UnsignedIntSampler2DMultisample = 0x910A,
    Sampler2DMultisampleArray = 0x910B,
    IntSampler2DMultisampleArray = 0x910C,
    UnsignedIntSampler2DMultisampleArray = 0x910D,
}

public enum UniformType
{
    Int = 0x1404,
    UnsignedInt = 0x1405,
    Float = 0x1406,
    Double = 0x140A,
    FloatVec2 = 0x8B50,
    FloatVec3 = 0x8B51,
    FloatVec4 = 0x8B52,
    IntVec2 = 0x8B53,
    IntVec3 = 0x8B54,
    IntVec4 = 0x8B55,
    Bool = 0x8B56,
    BoolVec2 = 0x8B57,
    BoolVec3 = 0x8B58,
    BoolVec4 = 0x8B59,
    FloatMat2 = 0x8B5A,
    FloatMat3 = 0x8B5B,
    FloatMat4 = 0x8B5C,
    Sampler1D = 0x8B5D,
    Sampler2D = 0x8B5E,
    Sampler3D = 0x8B5F,
    SamplerCube = 0x8B60,
    Sampler1DShadow = 0x8B61,
    Sampler2DShadow = 0x8B62,
    Sampler2DRect = 0x8B63,
    Sampler2DRectShadow = 0x8B64,
    FloatMat2x3 = 0x8B65,
    FloatMat2x4 = 0x8B66,
    FloatMat3x2 = 0x8B67,
    FloatMat3x4 = 0x8B68,
    FloatMat4x2 = 0x8B69,
    FloatMat4x3 = 0x8B6A,
    Sampler1DArray = 0x8DC0,
    Sampler2DArray = 0x8DC1,
    SamplerBuffer = 0x8DC2,
    Sampler1DArrayShadow = 0x8DC3,
    Sampler2DArrayShadow = 0x8DC4,
    SamplerCubeShadow = 0x8DC5,
    UnsignedIntVec2 = 0x8DC6,
    UnsignedIntVec3 = 0x8DC7,
    UnsignedIntVec4 = 0x8DC8,
    IntSampler1D = 0x8DC9,
    IntSampler2D = 0x8DCA,
    IntSampler3D = 0x8DCB,
    IntSamplerCube = 0x8DCC,
    IntSampler2DRect = 0x8DCD,
    IntSampler1DArray = 0x8DCE,
    IntSampler2DArray = 0x8DCF,
    IntSamplerBuffer = 0x8DD0,
    UnsignedIntSampler1D = 0x8DD1,
    UnsignedIntSampler2D = 0x8DD2,
    UnsignedIntSampler3D = 0x8DD3,
    UnsignedIntSamplerCube = 0x8DD4,
    UnsignedIntSampler2DRect = 0x8DD5,
    UnsignedIntSampler1DArray = 0x8DD6,
    UnsignedIntSampler2DArray = 0x8DD7,
    UnsignedIntSamplerBuffer = 0x8DD8,
    DoubleMat2 = 0x8F46,
    DoubleMat3 = 0x8F47,
    DoubleMat4 = 0x8F48,
    DoubleMat2x3 = 0x8F49,
    DoubleMat2x4 = 0x8F4A,
    DoubleMat3x2 = 0x8F4B,
    DoubleMat3x4 = 0x8F4C,
    DoubleMat4x2 = 0x8F4D,
    DoubleMat4x3 = 0x8F4E,
    DoubleVec2 = 0x8FFC,
    DoubleVec3 = 0x8FFD,
    DoubleVec4 = 0x8FFE,
    SamplerCubeMapArray = 0x900C,
    SamplerCubeMapArrayShadow = 0x900D,
    IntSamplerCubeMapArray = 0x900E,
    UnsignedIntSamplerCubeMapArray = 0x900F,
    Sampler2DMultisample = 0x9108,
    IntSampler2DMultisample = 0x9109,
    UnsignedIntSampler2DMultisample = 0x910A,
    Sampler2DMultisampleArray = 0x910B,
    IntSampler2DMultisampleArray = 0x910C,
    UnsignedIntSampler2DMultisampleArray = 0x910D,
}

public enum MapTypeNV
{
    Float = 0x1406,
    Double = 0x140A,
}

public enum VertexWeightPointerTypeEXT
{
    Float = 0x1406,
}

public enum FogCoordinatePointerType
{
    Float = 0x1406,
    Double = 0x140A,
}

public enum FogPointerTypeEXT
{
    Float = 0x1406,
    Double = 0x140A,
}

public enum FogPointerTypeIBM
{
    Float = 0x1406,
    Double = 0x140A,
}

public enum VertexAttribLType
{
    Double = 0x140A,
}

public enum LogicOp
{
    Clear = 0x1500,
    And = 0x1501,
    AndReverse = 0x1502,
    Copy = 0x1503,
    AndInverted = 0x1504,
    Noop = 0x1505,
    Xor = 0x1506,
    Or = 0x1507,
    Nor = 0x1508,
    Equiv = 0x1509,
    Invert = 0x150A,
    OrReverse = 0x150B,
    CopyInverted = 0x150C,
    OrInverted = 0x150D,
    Nand = 0x150E,
    Set = 0x150F,
}

public enum PathFillMode
{
    Invert = 0x150A,
}

public enum MatrixMode
{
    Modelview = 0x1700,
    Projection = 0x1701,
    Texture = 0x1702,
}

public enum ObjectIdentifier
{
    Texture = 0x1702,
    VertexArray = 0x8074,
    Buffer = 0x82E0,
    Shader = 0x82E1,
    Program = 0x82E2,
    Query = 0x82E3,
    ProgramPipeline = 0x82E4,
    Sampler = 0x82E6,
    Framebuffer = 0x8D40,
    Renderbuffer = 0x8D41,
    TransformFeedback = 0x8E22,
}

public enum Buffer
{
    Color = 0x1800,
    Depth = 0x1801,
    Stencil = 0x1802,
}

public enum PixelCopyType
{
    Color = 0x1800,
    Depth = 0x1801,
    Stencil = 0x1802,
}

public enum InvalidateFramebufferAttachment
{
    Color = 0x1800,
    Depth = 0x1801,
    Stencil = 0x1802,
    DepthStencilAttachment = 0x821A,
    ColorAttachment0 = 0x8CE0,
    ColorAttachment1 = 0x8CE1,
    ColorAttachment2 = 0x8CE2,
    ColorAttachment3 = 0x8CE3,
    ColorAttachment4 = 0x8CE4,
    ColorAttachment5 = 0x8CE5,
    ColorAttachment6 = 0x8CE6,
    ColorAttachment7 = 0x8CE7,
    ColorAttachment8 = 0x8CE8,
    ColorAttachment9 = 0x8CE9,
    ColorAttachment10 = 0x8CEA,
    ColorAttachment11 = 0x8CEB,
    ColorAttachment12 = 0x8CEC,
    ColorAttachment13 = 0x8CED,
    ColorAttachment14 = 0x8CEE,
    ColorAttachment15 = 0x8CEF,
    ColorAttachment16 = 0x8CF0,
    ColorAttachment17 = 0x8CF1,
    ColorAttachment18 = 0x8CF2,
    ColorAttachment19 = 0x8CF3,
    ColorAttachment20 = 0x8CF4,
    ColorAttachment21 = 0x8CF5,
    ColorAttachment22 = 0x8CF6,
    ColorAttachment23 = 0x8CF7,
    ColorAttachment24 = 0x8CF8,
    ColorAttachment25 = 0x8CF9,
    ColorAttachment26 = 0x8CFA,
    ColorAttachment27 = 0x8CFB,
    ColorAttachment28 = 0x8CFC,
    ColorAttachment29 = 0x8CFD,
    ColorAttachment30 = 0x8CFE,
    ColorAttachment31 = 0x8CFF,
    DepthAttachment = 0x8D00,
}

public enum InternalFormat
{
    StencilIndex = 0x1901,
    DepthComponent = 0x1902,
    Red = 0x1903,
    Rgb = 0x1907,
    Rgba = 0x1908,
    R3G3B2 = 0x2A10,
    Alpha4 = 0x803B,
    Alpha8 = 0x803C,
    Alpha12 = 0x803D,
    Alpha16 = 0x803E,
    Luminance4 = 0x803F,
    Luminance8 = 0x8040,
    Luminance12 = 0x8041,
    Luminance16 = 0x8042,
    Luminance4Alpha4 = 0x8043,
    Luminance6Alpha2 = 0x8044,
    Luminance8Alpha8 = 0x8045,
    Luminance12Alpha4 = 0x8046,
    Luminance12Alpha12 = 0x8047,
    Luminance16Alpha16 = 0x8048,
    Intensity = 0x8049,
    Intensity4 = 0x804A,
    Intensity8 = 0x804B,
    Intensity12 = 0x804C,
    Intensity16 = 0x804D,
    Rgb4 = 0x804F,
    Rgb5 = 0x8050,
    Rgb8 = 0x8051,
    Rgb10 = 0x8052,
    Rgb12 = 0x8053,
    Rgb16 = 0x8054,
    Rgba2 = 0x8055,
    Rgba4 = 0x8056,
    Rgb5A1 = 0x8057,
    Rgba8 = 0x8058,
    Rgb10A2 = 0x8059,
    Rgba12 = 0x805A,
    Rgba16 = 0x805B,
    DepthComponent16 = 0x81A5,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent16ARB = 0x81A5,
    DepthComponent24 = 0x81A6,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent24ARB = 0x81A6,
    DepthComponent32 = 0x81A7,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent32ARB = 0x81A7,
    CompressedRed = 0x8225,
    CompressedRg = 0x8226,
    Rg = 0x8227,
    R8 = 0x8229,
    R16 = 0x822A,
    Rg8 = 0x822B,
    Rg16 = 0x822C,
    R16f = 0x822D,
    R32f = 0x822E,
    Rg16f = 0x822F,
    Rg32f = 0x8230,
    R8i = 0x8231,
    R8ui = 0x8232,
    R16i = 0x8233,
    R16ui = 0x8234,
    R32i = 0x8235,
    R32ui = 0x8236,
    Rg8i = 0x8237,
    Rg8ui = 0x8238,
    Rg16i = 0x8239,
    Rg16ui = 0x823A,
    Rg32i = 0x823B,
    Rg32ui = 0x823C,
    CompressedRgb = 0x84ED,
    CompressedRgba = 0x84EE,
    DepthStencil = 0x84F9,
    DepthStencilMESA = 0x8750,
    Rgba32f = 0x8814,

    [GLExtension("GL_ARB_texture_float")]
    Rgba32fARB = 0x8814,
    Rgb32f = 0x8815,

    [GLExtension("GL_ARB_texture_float")]
    Rgb32fARB = 0x8815,
    Rgba16f = 0x881A,

    [GLExtension("GL_ARB_texture_float")]
    Rgba16fARB = 0x881A,
    Rgb16f = 0x881B,

    [GLExtension("GL_ARB_texture_float")]
    Rgb16fARB = 0x881B,
    Depth24Stencil8 = 0x88F0,
    R11fG11fB10f = 0x8C3A,
    Rgb9E5 = 0x8C3D,
    Srgb = 0x8C40,
    Srgb8 = 0x8C41,
    SrgbAlpha = 0x8C42,
    Srgb8Alpha8 = 0x8C43,
    CompressedSrgb = 0x8C48,
    CompressedSrgbAlpha = 0x8C49,
    DepthComponent32f = 0x8CAC,
    Depth32fStencil8 = 0x8CAD,
    StencilIndex1 = 0x8D46,
    StencilIndex4 = 0x8D47,
    StencilIndex8 = 0x8D48,
    StencilIndex16 = 0x8D49,
    Rgb565 = 0x8D62,
    Rgba32ui = 0x8D70,
    Rgb32ui = 0x8D71,
    Rgba16ui = 0x8D76,
    Rgb16ui = 0x8D77,
    Rgba8ui = 0x8D7C,
    Rgb8ui = 0x8D7D,
    Rgba32i = 0x8D82,
    Rgb32i = 0x8D83,
    Rgba16i = 0x8D88,
    Rgb16i = 0x8D89,
    Rgba8i = 0x8D8E,
    Rgb8i = 0x8D8F,
    CompressedRedRgtc1 = 0x8DBB,
    CompressedSignedRedRgtc1 = 0x8DBC,
    CompressedRgRgtc2 = 0x8DBD,
    CompressedSignedRgRgtc2 = 0x8DBE,
    CompressedRgbaBptcUnorm = 0x8E8C,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbaBptcUnormARB = 0x8E8C,
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedSrgbAlphaBptcUnormARB = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbBptcSignedFloatARB = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbBptcUnsignedFloatARB = 0x8E8F,
    R8Snorm = 0x8F94,
    Rg8Snorm = 0x8F95,
    Rgb8Snorm = 0x8F96,
    Rgba8Snorm = 0x8F97,
    R16Snorm = 0x8F98,
    Rg16Snorm = 0x8F99,
    Rgb16Snorm = 0x8F9A,
    Rgba16Snorm = 0x8F9B,
    Rgb10A2ui = 0x906F,
    CompressedR11Eac = 0x9270,
    CompressedR11EacOES = 0x9270,
    CompressedSignedR11Eac = 0x9271,
    CompressedSignedR11EacOES = 0x9271,
    CompressedRg11Eac = 0x9272,
    CompressedRg11EacOES = 0x9272,
    CompressedSignedRg11Eac = 0x9273,
    CompressedSignedRg11EacOES = 0x9273,
    CompressedRgb8Etc2 = 0x9274,
    CompressedRgb8Etc2OES = 0x9274,
    CompressedSrgb8Etc2 = 0x9275,
    CompressedSrgb8Etc2OES = 0x9275,
    CompressedRgb8PunchthroughAlpha1Etc2 = 0x9276,
    CompressedRgb8PunchthroughAlpha1Etc2OES = 0x9276,
    CompressedSrgb8PunchthroughAlpha1Etc2 = 0x9277,
    CompressedSrgb8PunchthroughAlpha1Etc2OES = 0x9277,
    CompressedRgba8Etc2Eac = 0x9278,
    CompressedRgba8Etc2EacOES = 0x9278,
    CompressedSrgb8Alpha8Etc2Eac = 0x9279,
    CompressedSrgb8Alpha8Etc2EacOES = 0x9279,
    CompressedRgbaAstc4x4 = 0x93B0,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc4x4Khr = 0x93B0,
    CompressedRgbaAstc5x4 = 0x93B1,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x4Khr = 0x93B1,
    CompressedRgbaAstc5x5 = 0x93B2,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x5Khr = 0x93B2,
    CompressedRgbaAstc6x5 = 0x93B3,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x5Khr = 0x93B3,
    CompressedRgbaAstc6x6 = 0x93B4,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x6Khr = 0x93B4,
    CompressedRgbaAstc8x5 = 0x93B5,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x5Khr = 0x93B5,
    CompressedRgbaAstc8x6 = 0x93B6,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x6Khr = 0x93B6,
    CompressedRgbaAstc8x8 = 0x93B7,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x8Khr = 0x93B7,
    CompressedRgbaAstc10x5 = 0x93B8,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x5Khr = 0x93B8,
    CompressedRgbaAstc10x6 = 0x93B9,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x6Khr = 0x93B9,
    CompressedRgbaAstc10x8 = 0x93BA,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x8Khr = 0x93BA,
    CompressedRgbaAstc10x10 = 0x93BB,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x10Khr = 0x93BB,
    CompressedRgbaAstc12x10 = 0x93BC,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x10Khr = 0x93BC,
    CompressedRgbaAstc12x12 = 0x93BD,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x12Khr = 0x93BD,
    CompressedSrgb8Alpha8Astc4x4 = 0x93D0,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc4x4Khr = 0x93D0,
    CompressedSrgb8Alpha8Astc5x4 = 0x93D1,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x4Khr = 0x93D1,
    CompressedSrgb8Alpha8Astc5x5 = 0x93D2,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x5Khr = 0x93D2,
    CompressedSrgb8Alpha8Astc6x5 = 0x93D3,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x5Khr = 0x93D3,
    CompressedSrgb8Alpha8Astc6x6 = 0x93D4,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x6Khr = 0x93D4,
    CompressedSrgb8Alpha8Astc8x5 = 0x93D5,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x5Khr = 0x93D5,
    CompressedSrgb8Alpha8Astc8x6 = 0x93D6,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x6Khr = 0x93D6,
    CompressedSrgb8Alpha8Astc8x8 = 0x93D7,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x8Khr = 0x93D7,
    CompressedSrgb8Alpha8Astc10x5 = 0x93D8,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x5Khr = 0x93D8,
    CompressedSrgb8Alpha8Astc10x6 = 0x93D9,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x6Khr = 0x93D9,
    CompressedSrgb8Alpha8Astc10x8 = 0x93DA,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x8Khr = 0x93DA,
    CompressedSrgb8Alpha8Astc10x10 = 0x93DB,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x10Khr = 0x93DB,
    CompressedSrgb8Alpha8Astc12x10 = 0x93DC,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x10Khr = 0x93DC,
    CompressedSrgb8Alpha8Astc12x12 = 0x93DD,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x12Khr = 0x93DD,
}

public enum DepthStencilTextureMode
{
    StencilIndex = 0x1901,
    DepthComponent = 0x1902,
}

public enum CombinerComponentUsageNV
{
    Blue = 0x1905,
    Alpha = 0x1906,
    Rgb = 0x1907,
}

public enum CombinerPortionNV
{
    Alpha = 0x1906,
    Rgb = 0x1907,
}

public enum PolygonMode
{
    Point = 0x1B00,
    Line = 0x1B01,
    Fill = 0x1B02,
}

public enum MeshMode1
{
    Point = 0x1B00,
    Line = 0x1B01,
}

public enum MeshMode2
{
    Point = 0x1B00,
    Line = 0x1B01,
    Fill = 0x1B02,
}

public enum RenderingMode
{
    Render = 0x1C00,
    Feedback = 0x1C01,
    Select = 0x1C02,
}

public enum ShadingModel
{
    Flat = 0x1D00,
    Smooth = 0x1D01,
}

public enum StringName
{
    Vendor = 0x1F00,
    Renderer = 0x1F01,
    Version = 0x1F02,
    Extensions = 0x1F03,
    ShadingLanguageVersion = 0x8B8C,
}

public enum TextureCoordName
{
    S = 0x2000,
    T = 0x2001,
    R = 0x2002,
    Q = 0x2003,
}

public enum TextureEnvTarget
{
    TextureEnv = 0x2300,
    TextureFilterControl = 0x8500,
    PointSprite = 0x8861,
}

public enum TextureGenMode
{
    EyeLinear = 0x2400,
    ObjectLinear = 0x2401,
    SphereMap = 0x2402,
}

public enum TextureGenParameter
{
    TextureGenMode = 0x2500,
    ObjectPlane = 0x2501,
    EyePlane = 0x2502,
}

public enum BlitFramebufferFilter
{
    Nearest = 0x2600,
    Linear = 0x2601,
}

public enum TextureMagFilter
{
    Nearest = 0x2600,
    Linear = 0x2601,
    PixelTexGenQCeilingSGIX = 0x8184,
    PixelTexGenQRoundSGIX = 0x8185,
    PixelTexGenQFloorSGIX = 0x8186,
}

public enum TextureMinFilter
{
    Nearest = 0x2600,
    Linear = 0x2601,
    NearestMipmapNearest = 0x2700,
    LinearMipmapNearest = 0x2701,
    NearestMipmapLinear = 0x2702,
    LinearMipmapLinear = 0x2703,
    PixelTexGenQCeilingSGIX = 0x8184,
    PixelTexGenQRoundSGIX = 0x8185,
    PixelTexGenQFloorSGIX = 0x8186,
}

public enum TextureWrapMode
{
    LinearMipmapLinear = 0x2703,
    Clamp = 0x2900,
    Repeat = 0x2901,
    ClampToBorder = 0x812D,

    [GLExtension("GL_ARB_texture_border_clamp")]
    ClampToBorderARB = 0x812D,
    ClampToEdge = 0x812F,
    MirroredRepeat = 0x8370,
}

public enum SamplerParameterI
{
    TextureMagFilter = 0x2800,
    TextureMinFilter = 0x2801,
    TextureWrapS = 0x2802,
    TextureWrapT = 0x2803,
    TextureWrapR = 0x8072,
    TextureCompareMode = 0x884C,
    TextureCompareFunc = 0x884D,
}

public enum SizedInternalFormat
{
    R3G3B2 = 0x2A10,
    Alpha4 = 0x803B,
    Alpha8 = 0x803C,
    Alpha12 = 0x803D,
    Alpha16 = 0x803E,
    Luminance4 = 0x803F,
    Luminance8 = 0x8040,
    Luminance12 = 0x8041,
    Luminance16 = 0x8042,
    Luminance4Alpha4 = 0x8043,
    Luminance6Alpha2 = 0x8044,
    Luminance8Alpha8 = 0x8045,
    Luminance12Alpha4 = 0x8046,
    Luminance12Alpha12 = 0x8047,
    Luminance16Alpha16 = 0x8048,
    Intensity4 = 0x804A,
    Intensity8 = 0x804B,
    Intensity12 = 0x804C,
    Intensity16 = 0x804D,
    Rgb4 = 0x804F,
    Rgb5 = 0x8050,
    Rgb8 = 0x8051,
    Rgb10 = 0x8052,
    Rgb12 = 0x8053,
    Rgb16 = 0x8054,
    Rgba2 = 0x8055,
    Rgba4 = 0x8056,
    Rgb5A1 = 0x8057,
    Rgba8 = 0x8058,
    Rgb10A2 = 0x8059,
    Rgba12 = 0x805A,
    Rgba16 = 0x805B,
    DepthComponent16 = 0x81A5,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent16ARB = 0x81A5,
    DepthComponent24 = 0x81A6,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent24ARB = 0x81A6,
    DepthComponent32 = 0x81A7,

    [GLExtension("GL_ARB_depth_texture")]
    DepthComponent32ARB = 0x81A7,
    R8 = 0x8229,
    R16 = 0x822A,
    Rg8 = 0x822B,
    Rg16 = 0x822C,
    R16f = 0x822D,
    R32f = 0x822E,
    Rg16f = 0x822F,
    Rg32f = 0x8230,
    R8i = 0x8231,
    R8ui = 0x8232,
    R16i = 0x8233,
    R16ui = 0x8234,
    R32i = 0x8235,
    R32ui = 0x8236,
    Rg8i = 0x8237,
    Rg8ui = 0x8238,
    Rg16i = 0x8239,
    Rg16ui = 0x823A,
    Rg32i = 0x823B,
    Rg32ui = 0x823C,
    Rgba32f = 0x8814,

    [GLExtension("GL_ARB_texture_float")]
    Rgba32fARB = 0x8814,
    Rgb32f = 0x8815,

    [GLExtension("GL_ARB_texture_float")]
    Rgb32fARB = 0x8815,
    Rgba16f = 0x881A,

    [GLExtension("GL_ARB_texture_float")]
    Rgba16fARB = 0x881A,
    Rgb16f = 0x881B,

    [GLExtension("GL_ARB_texture_float")]
    Rgb16fARB = 0x881B,
    Depth24Stencil8 = 0x88F0,
    R11fG11fB10f = 0x8C3A,
    Rgb9E5 = 0x8C3D,
    Srgb8 = 0x8C41,
    Srgb8Alpha8 = 0x8C43,
    DepthComponent32f = 0x8CAC,
    Depth32fStencil8 = 0x8CAD,
    StencilIndex1 = 0x8D46,
    StencilIndex4 = 0x8D47,
    StencilIndex8 = 0x8D48,
    StencilIndex16 = 0x8D49,
    Rgb565 = 0x8D62,
    Rgba32ui = 0x8D70,
    Rgb32ui = 0x8D71,
    Rgba16ui = 0x8D76,
    Rgb16ui = 0x8D77,
    Rgba8ui = 0x8D7C,
    Rgb8ui = 0x8D7D,
    Rgba32i = 0x8D82,
    Rgb32i = 0x8D83,
    Rgba16i = 0x8D88,
    Rgb16i = 0x8D89,
    Rgba8i = 0x8D8E,
    Rgb8i = 0x8D8F,
    CompressedRedRgtc1 = 0x8DBB,
    CompressedSignedRedRgtc1 = 0x8DBC,
    CompressedRgRgtc2 = 0x8DBD,
    CompressedSignedRgRgtc2 = 0x8DBE,
    CompressedRgbaBptcUnorm = 0x8E8C,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbaBptcUnormARB = 0x8E8C,
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedSrgbAlphaBptcUnormARB = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbBptcSignedFloatARB = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,

    [GLExtension("GL_ARB_texture_compression_bptc")]
    CompressedRgbBptcUnsignedFloatARB = 0x8E8F,
    R8Snorm = 0x8F94,
    Rg8Snorm = 0x8F95,
    Rgb8Snorm = 0x8F96,
    Rgba8Snorm = 0x8F97,
    R16Snorm = 0x8F98,
    Rg16Snorm = 0x8F99,
    Rgb16Snorm = 0x8F9A,
    Rgba16Snorm = 0x8F9B,
    Rgb10A2ui = 0x906F,
    CompressedR11Eac = 0x9270,
    CompressedR11EacOES = 0x9270,
    CompressedSignedR11Eac = 0x9271,
    CompressedSignedR11EacOES = 0x9271,
    CompressedRg11Eac = 0x9272,
    CompressedRg11EacOES = 0x9272,
    CompressedSignedRg11Eac = 0x9273,
    CompressedSignedRg11EacOES = 0x9273,
    CompressedRgb8Etc2 = 0x9274,
    CompressedRgb8Etc2OES = 0x9274,
    CompressedSrgb8Etc2 = 0x9275,
    CompressedSrgb8Etc2OES = 0x9275,
    CompressedRgb8PunchthroughAlpha1Etc2 = 0x9276,
    CompressedRgb8PunchthroughAlpha1Etc2OES = 0x9276,
    CompressedSrgb8PunchthroughAlpha1Etc2 = 0x9277,
    CompressedSrgb8PunchthroughAlpha1Etc2OES = 0x9277,
    CompressedRgba8Etc2Eac = 0x9278,
    CompressedRgba8Etc2EacOES = 0x9278,
    CompressedSrgb8Alpha8Etc2Eac = 0x9279,
    CompressedSrgb8Alpha8Etc2EacOES = 0x9279,
    CompressedRgbaAstc4x4 = 0x93B0,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc4x4Khr = 0x93B0,
    CompressedRgbaAstc5x4 = 0x93B1,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x4Khr = 0x93B1,
    CompressedRgbaAstc5x5 = 0x93B2,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x5Khr = 0x93B2,
    CompressedRgbaAstc6x5 = 0x93B3,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x5Khr = 0x93B3,
    CompressedRgbaAstc6x6 = 0x93B4,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x6Khr = 0x93B4,
    CompressedRgbaAstc8x5 = 0x93B5,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x5Khr = 0x93B5,
    CompressedRgbaAstc8x6 = 0x93B6,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x6Khr = 0x93B6,
    CompressedRgbaAstc8x8 = 0x93B7,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x8Khr = 0x93B7,
    CompressedRgbaAstc10x5 = 0x93B8,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x5Khr = 0x93B8,
    CompressedRgbaAstc10x6 = 0x93B9,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x6Khr = 0x93B9,
    CompressedRgbaAstc10x8 = 0x93BA,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x8Khr = 0x93BA,
    CompressedRgbaAstc10x10 = 0x93BB,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x10Khr = 0x93BB,
    CompressedRgbaAstc12x10 = 0x93BC,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x10Khr = 0x93BC,
    CompressedRgbaAstc12x12 = 0x93BD,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x12Khr = 0x93BD,
    CompressedSrgb8Alpha8Astc4x4 = 0x93D0,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc4x4Khr = 0x93D0,
    CompressedSrgb8Alpha8Astc5x4 = 0x93D1,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x4Khr = 0x93D1,
    CompressedSrgb8Alpha8Astc5x5 = 0x93D2,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x5Khr = 0x93D2,
    CompressedSrgb8Alpha8Astc6x5 = 0x93D3,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x5Khr = 0x93D3,
    CompressedSrgb8Alpha8Astc6x6 = 0x93D4,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x6Khr = 0x93D4,
    CompressedSrgb8Alpha8Astc8x5 = 0x93D5,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x5Khr = 0x93D5,
    CompressedSrgb8Alpha8Astc8x6 = 0x93D6,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x6Khr = 0x93D6,
    CompressedSrgb8Alpha8Astc8x8 = 0x93D7,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x8Khr = 0x93D7,
    CompressedSrgb8Alpha8Astc10x5 = 0x93D8,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x5Khr = 0x93D8,
    CompressedSrgb8Alpha8Astc10x6 = 0x93D9,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x6Khr = 0x93D9,
    CompressedSrgb8Alpha8Astc10x8 = 0x93DA,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x8Khr = 0x93DA,
    CompressedSrgb8Alpha8Astc10x10 = 0x93DB,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x10Khr = 0x93DB,
    CompressedSrgb8Alpha8Astc12x10 = 0x93DC,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x10Khr = 0x93DC,
    CompressedSrgb8Alpha8Astc12x12 = 0x93DD,

    [GLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x12Khr = 0x93DD,
}

public enum InterleavedArrayFormat
{
    V2f = 0x2A20,
    V3f = 0x2A21,
    C4ubV2f = 0x2A22,
    C4ubV3f = 0x2A23,
    C3fV3f = 0x2A24,
    N3fV3f = 0x2A25,
    C4fN3fV3f = 0x2A26,
    T2fV3f = 0x2A27,
    T4fV4f = 0x2A28,
    T2fC4ubV3f = 0x2A29,
    T2fC3fV3f = 0x2A2A,
    T2fN3fV3f = 0x2A2B,
    T2fC4fN3fV3f = 0x2A2C,
    T4fC4fN3fV4f = 0x2A2D,
}

public enum ClipPlaneName
{
    ClipPlane0 = 0x3000,
    ClipDistance0 = 0x3000,
    ClipPlane1 = 0x3001,
    ClipDistance1 = 0x3001,
    ClipPlane2 = 0x3002,
    ClipDistance2 = 0x3002,
    ClipPlane3 = 0x3003,
    ClipDistance3 = 0x3003,
    ClipPlane4 = 0x3004,
    ClipDistance4 = 0x3004,
    ClipPlane5 = 0x3005,
    ClipDistance5 = 0x3005,
    ClipDistance6 = 0x3006,
    ClipDistance7 = 0x3007,
}

public enum LightName
{
    Light0 = 0x4000,
    Light1 = 0x4001,
    Light2 = 0x4002,
    Light3 = 0x4003,
    Light4 = 0x4004,
    Light5 = 0x4005,
    Light6 = 0x4006,
    Light7 = 0x4007,
}

public enum BlendEquationModeEXT
{
    FuncAdd = 0x8006,
    Min = 0x8007,
    Max = 0x8008,
    FuncSubtract = 0x800A,
    FuncReverseSubtract = 0x800B,
}

public enum ConvolutionTarget
{
    Convolution1D = 0x8010,
    Convolution2D = 0x8011,
}

public enum ConvolutionTargetEXT
{
    Convolution1D = 0x8010,
    Convolution2D = 0x8011,
}

public enum SeparableTarget
{
    Separable2D = 0x8012,
}

public enum SeparableTargetEXT
{
    Separable2D = 0x8012,
}

public enum ConvolutionParameter
{

    [GLExtension("GL_ARB_imaging")]
    ConvolutionBorderMode = 0x8013,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionFilterScale = 0x8014,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionFilterBias = 0x8015,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionFormat = 0x8017,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionWidth = 0x8018,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionHeight = 0x8019,

    [GLExtension("GL_ARB_imaging")]
    MaxConvolutionWidth = 0x801A,

    [GLExtension("GL_ARB_imaging")]
    MaxConvolutionHeight = 0x801B,

    [GLExtension("GL_ARB_imaging")]
    ConvolutionBorderColor = 0x8154,
}

public enum ConvolutionBorderModeEXT
{

    [GLExtension("GL_ARB_imaging")]
    Reduce = 0x8016,
}

public enum HistogramTarget
{
    Histogram = 0x8024,
    ProxyHistogram = 0x8025,
}

public enum HistogramTargetEXT
{
    Histogram = 0x8024,
    ProxyHistogram = 0x8025,
}

public enum GetHistogramParameterPNameEXT
{

    [GLExtension("GL_ARB_imaging")]
    HistogramWidth = 0x8026,

    [GLExtension("GL_ARB_imaging")]
    HistogramFormat = 0x8027,

    [GLExtension("GL_ARB_imaging")]
    HistogramRedSize = 0x8028,

    [GLExtension("GL_ARB_imaging")]
    HistogramGreenSize = 0x8029,

    [GLExtension("GL_ARB_imaging")]
    HistogramBlueSize = 0x802A,

    [GLExtension("GL_ARB_imaging")]
    HistogramAlphaSize = 0x802B,

    [GLExtension("GL_ARB_imaging")]
    HistogramLuminanceSize = 0x802C,

    [GLExtension("GL_ARB_imaging")]
    HistogramSink = 0x802D,
}

public enum MinmaxTarget
{
    Minmax = 0x802E,
}

public enum MinmaxTargetEXT
{
    Minmax = 0x802E,
}

public enum GetMinmaxParameterPNameEXT
{

    [GLExtension("GL_ARB_imaging")]
    MinmaxFormat = 0x802F,

    [GLExtension("GL_ARB_imaging")]
    MinmaxSink = 0x8030,
}

public enum InternalFormatPName
{
    Samples = 0x80A9,
    GenerateMipmap = 0x8191,
    InternalformatSupported = 0x826F,
    InternalformatPreferred = 0x8270,
    InternalformatRedSize = 0x8271,
    InternalformatGreenSize = 0x8272,
    InternalformatBlueSize = 0x8273,
    InternalformatAlphaSize = 0x8274,
    InternalformatDepthSize = 0x8275,
    InternalformatStencilSize = 0x8276,
    InternalformatSharedSize = 0x8277,
    InternalformatRedType = 0x8278,
    InternalformatGreenType = 0x8279,
    InternalformatBlueType = 0x827A,
    InternalformatAlphaType = 0x827B,
    InternalformatDepthType = 0x827C,
    InternalformatStencilType = 0x827D,
    MaxWidth = 0x827E,
    MaxHeight = 0x827F,
    MaxDepth = 0x8280,
    MaxLayers = 0x8281,
    ColorComponents = 0x8283,
    ColorRenderable = 0x8286,
    DepthRenderable = 0x8287,
    StencilRenderable = 0x8288,
    FramebufferRenderable = 0x8289,
    FramebufferRenderableLayered = 0x828A,
    FramebufferBlend = 0x828B,
    ReadPixels = 0x828C,
    ReadPixelsFormat = 0x828D,
    ReadPixelsType = 0x828E,
    TextureImageFormat = 0x828F,
    TextureImageType = 0x8290,
    GetTextureImageFormat = 0x8291,
    GetTextureImageType = 0x8292,
    Mipmap = 0x8293,
    AutoGenerateMipmap = 0x8295,
    ColorEncoding = 0x8296,
    SrgbRead = 0x8297,
    SrgbWrite = 0x8298,
    Filter = 0x829A,
    VertexTexture = 0x829B,
    TessControlTexture = 0x829C,
    TessEvaluationTexture = 0x829D,
    GeometryTexture = 0x829E,
    FragmentTexture = 0x829F,
    ComputeTexture = 0x82A0,
    TextureShadow = 0x82A1,
    TextureGather = 0x82A2,
    TextureGatherShadow = 0x82A3,
    ShaderImageLoad = 0x82A4,
    ShaderImageStore = 0x82A5,
    ShaderImageAtomic = 0x82A6,
    ImageTexelSize = 0x82A7,
    ImageCompatibilityClass = 0x82A8,
    ImagePixelFormat = 0x82A9,
    ImagePixelType = 0x82AA,
    SimultaneousTextureAndDepthTest = 0x82AC,
    SimultaneousTextureAndStencilTest = 0x82AD,
    SimultaneousTextureAndDepthWrite = 0x82AE,
    SimultaneousTextureAndStencilWrite = 0x82AF,
    TextureCompressedBlockWidth = 0x82B1,
    TextureCompressedBlockHeight = 0x82B2,
    TextureCompressedBlockSize = 0x82B3,
    ClearBuffer = 0x82B4,
    TextureView = 0x82B5,
    ViewCompatibilityClass = 0x82B6,
    TextureCompressed = 0x86A1,
    ImageFormatCompatibilityType = 0x90C7,
    ClearTexture = 0x9365,
    NumSampleCounts = 0x9380,
}

public enum ColorTableTargetSGI
{
    ColorTable = 0x80D0,
    PostConvolutionColorTable = 0x80D1,
    PostColorMatrixColorTable = 0x80D2,
    ProxyColorTable = 0x80D3,
    ProxyPostConvolutionColorTable = 0x80D4,
    ProxyPostColorMatrixColorTable = 0x80D5,
}

public enum ColorTableTarget
{
    ColorTable = 0x80D0,
    PostConvolutionColorTable = 0x80D1,
    PostColorMatrixColorTable = 0x80D2,
    ProxyColorTable = 0x80D3,
    ProxyPostConvolutionColorTable = 0x80D4,
    ProxyPostColorMatrixColorTable = 0x80D5,
}

public enum ColorTableParameterPName
{

    [GLExtension("GL_ARB_imaging")]
    ColorTableScale = 0x80D6,

    [GLExtension("GL_ARB_imaging")]
    ColorTableBias = 0x80D7,

    [GLExtension("GL_ARB_imaging")]
    ColorTableFormat = 0x80D8,

    [GLExtension("GL_ARB_imaging")]
    ColorTableWidth = 0x80D9,

    [GLExtension("GL_ARB_imaging")]
    ColorTableRedSize = 0x80DA,

    [GLExtension("GL_ARB_imaging")]
    ColorTableGreenSize = 0x80DB,

    [GLExtension("GL_ARB_imaging")]
    ColorTableBlueSize = 0x80DC,

    [GLExtension("GL_ARB_imaging")]
    ColorTableAlphaSize = 0x80DD,

    [GLExtension("GL_ARB_imaging")]
    ColorTableLuminanceSize = 0x80DE,

    [GLExtension("GL_ARB_imaging")]
    ColorTableIntensitySize = 0x80DF,
}

public enum BufferTargetARB
{
    ParameterBuffer = 0x80EE,
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893,
    PixelPackBuffer = 0x88EB,
    PixelUnpackBuffer = 0x88EC,
    UniformBuffer = 0x8A11,
    TextureBuffer = 0x8C2A,
    TransformFeedbackBuffer = 0x8C8E,
    CopyReadBuffer = 0x8F36,
    CopyWriteBuffer = 0x8F37,
    DrawIndirectBuffer = 0x8F3F,
    ShaderStorageBuffer = 0x90D2,
    DispatchIndirectBuffer = 0x90EE,
    QueryBuffer = 0x9192,
    AtomicCounterBuffer = 0x92C0,
}

public enum PointParameterNameARB
{
    PointSizeMin = 0x8126,

    [GLExtension("GL_ARB_point_parameters")]
    PointSizeMinARB = 0x8126,
    PointSizeMax = 0x8127,

    [GLExtension("GL_ARB_point_parameters")]
    PointSizeMaxARB = 0x8127,
    PointFadeThresholdSize = 0x8128,

    [GLExtension("GL_ARB_point_parameters")]
    PointFadeThresholdSizeARB = 0x8128,
    PointDistanceAttenuation = 0x8129,

    [GLExtension("GL_ARB_point_parameters")]
    PointDistanceAttenuationARB = 0x8129,
}

public enum LightModelColorControl
{
    SingleColor = 0x81F9,
    SeparateSpecularColor = 0x81FA,
}

public enum ProgramTarget
{

    [GLExtension("GL_ARB_vertex_program")]
    VertexProgramARB = 0x8620,

    [GLExtension("GL_ARB_fragment_program")]
    FragmentProgramARB = 0x8804,
}

public enum FramebufferAttachmentParameterName
{
    FramebufferAttachmentColorEncoding = 0x8210,
    FramebufferAttachmentComponentType = 0x8211,
    FramebufferAttachmentRedSize = 0x8212,
    FramebufferAttachmentGreenSize = 0x8213,
    FramebufferAttachmentBlueSize = 0x8214,
    FramebufferAttachmentAlphaSize = 0x8215,
    FramebufferAttachmentDepthSize = 0x8216,
    FramebufferAttachmentStencilSize = 0x8217,
    FramebufferAttachmentObjectType = 0x8CD0,
    FramebufferAttachmentObjectName = 0x8CD1,
    FramebufferAttachmentTextureLevel = 0x8CD2,
    FramebufferAttachmentTextureCubeMapFace = 0x8CD3,
    FramebufferAttachmentTextureLayer = 0x8CD4,
    FramebufferAttachmentLayered = 0x8DA7,

    [GLExtension("GL_ARB_geometry_shader4")]
    FramebufferAttachmentLayeredARB = 0x8DA7,

    [GLExtension("GL_OVR_multiview")]
    FramebufferAttachmentTextureNumViewsOvr = 0x9630,

    [GLExtension("GL_OVR_multiview")]
    FramebufferAttachmentTextureBaseViewIndexOvr = 0x9632,
}

public enum FramebufferStatus
{
    FramebufferUndefined = 0x8219,
    FramebufferComplete = 0x8CD5,
    FramebufferIncompleteAttachment = 0x8CD6,
    FramebufferIncompleteMissingAttachment = 0x8CD7,
    FramebufferIncompleteDrawBuffer = 0x8CDB,
    FramebufferIncompleteReadBuffer = 0x8CDC,
    FramebufferUnsupported = 0x8CDD,
    FramebufferIncompleteMultisample = 0x8D56,
    FramebufferIncompleteLayerTargets = 0x8DA8,
}

public enum FramebufferAttachment
{
    DepthStencilAttachment = 0x821A,
    ColorAttachment0 = 0x8CE0,
    ColorAttachment1 = 0x8CE1,
    ColorAttachment2 = 0x8CE2,
    ColorAttachment3 = 0x8CE3,
    ColorAttachment4 = 0x8CE4,
    ColorAttachment5 = 0x8CE5,
    ColorAttachment6 = 0x8CE6,
    ColorAttachment7 = 0x8CE7,
    ColorAttachment8 = 0x8CE8,
    ColorAttachment9 = 0x8CE9,
    ColorAttachment10 = 0x8CEA,
    ColorAttachment11 = 0x8CEB,
    ColorAttachment12 = 0x8CEC,
    ColorAttachment13 = 0x8CED,
    ColorAttachment14 = 0x8CEE,
    ColorAttachment15 = 0x8CEF,
    ColorAttachment16 = 0x8CF0,
    ColorAttachment17 = 0x8CF1,
    ColorAttachment18 = 0x8CF2,
    ColorAttachment19 = 0x8CF3,
    ColorAttachment20 = 0x8CF4,
    ColorAttachment21 = 0x8CF5,
    ColorAttachment22 = 0x8CF6,
    ColorAttachment23 = 0x8CF7,
    ColorAttachment24 = 0x8CF8,
    ColorAttachment25 = 0x8CF9,
    ColorAttachment26 = 0x8CFA,
    ColorAttachment27 = 0x8CFB,
    ColorAttachment28 = 0x8CFC,
    ColorAttachment29 = 0x8CFD,
    ColorAttachment30 = 0x8CFE,
    ColorAttachment31 = 0x8CFF,
    DepthAttachment = 0x8D00,
    StencilAttachment = 0x8D20,
}

public enum BufferPNameARB
{
    BufferImmutableStorage = 0x821F,
    BufferStorageFlags = 0x8220,
    BufferSize = 0x8764,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    BufferSizeARB = 0x8764,
    BufferUsage = 0x8765,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    BufferUsageARB = 0x8765,
    BufferAccess = 0x88BB,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    BufferAccessARB = 0x88BB,
    BufferMapped = 0x88BC,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    BufferMappedARB = 0x88BC,
    BufferAccessFlags = 0x911F,
    BufferMapLength = 0x9120,
    BufferMapOffset = 0x9121,
}

public enum ProgramParameterPName
{
    ProgramBinaryRetrievableHint = 0x8257,
    ProgramSeparable = 0x8258,
}

public enum PipelineParameterName
{
    ActiveProgram = 0x8259,
    FragmentShader = 0x8B30,
    VertexShader = 0x8B31,
    InfoLogLength = 0x8B84,
    GeometryShader = 0x8DD9,
    TessEvaluationShader = 0x8E87,
    TessControlShader = 0x8E88,
}

public enum ProgramPropertyARB
{
    ComputeWorkGroupSize = 0x8267,
    ProgramBinaryLength = 0x8741,
    GeometryVerticesOut = 0x8916,
    GeometryInputType = 0x8917,
    GeometryOutputType = 0x8918,
    ActiveUniformBlockMaxNameLength = 0x8A35,
    ActiveUniformBlocks = 0x8A36,
    DeleteStatus = 0x8B80,
    LinkStatus = 0x8B82,
    ValidateStatus = 0x8B83,
    InfoLogLength = 0x8B84,
    AttachedShaders = 0x8B85,
    ActiveUniforms = 0x8B86,
    ActiveUniformMaxLength = 0x8B87,
    ActiveAttributes = 0x8B89,
    ActiveAttributeMaxLength = 0x8B8A,
    TransformFeedbackVaryingMaxLength = 0x8C76,
    TransformFeedbackBufferMode = 0x8C7F,
    TransformFeedbackVaryings = 0x8C83,
    ActiveAtomicCounterBuffers = 0x92D9,
}

public enum VertexAttribPropertyARB
{
    VertexAttribBinding = 0x82D4,
    VertexAttribRelativeOffset = 0x82D5,
    VertexAttribArrayEnabled = 0x8622,
    VertexAttribArraySize = 0x8623,
    VertexAttribArrayStride = 0x8624,
    VertexAttribArrayType = 0x8625,
    CurrentVertexAttrib = 0x8626,
    VertexAttribArrayLong = 0x874E,
    VertexAttribArrayNormalized = 0x886A,
    VertexAttribArrayBufferBinding = 0x889F,
    VertexAttribArrayInteger = 0x88FD,
    VertexAttribArrayDivisor = 0x88FE,
}

public enum VertexArrayPName
{
    VertexAttribRelativeOffset = 0x82D5,
    VertexAttribArrayEnabled = 0x8622,
    VertexAttribArraySize = 0x8623,
    VertexAttribArrayStride = 0x8624,
    VertexAttribArrayType = 0x8625,
    VertexAttribArrayLong = 0x874E,
    VertexAttribArrayNormalized = 0x886A,
    VertexAttribArrayInteger = 0x88FD,
    VertexAttribArrayDivisor = 0x88FE,
}

public enum QueryObjectParameterName
{
    QueryTarget = 0x82EA,
    QueryResult = 0x8866,
    QueryResultAvailable = 0x8867,
    QueryResultNoWait = 0x9194,
}

public enum QueryTarget
{
    TransformFeedbackOverflow = 0x82EC,
    VerticesSubmitted = 0x82EE,
    PrimitivesSubmitted = 0x82EF,
    VertexShaderInvocations = 0x82F0,
    TimeElapsed = 0x88BF,
    SamplesPassed = 0x8914,
    AnySamplesPassed = 0x8C2F,
    PrimitivesGenerated = 0x8C87,
    TransformFeedbackPrimitivesWritten = 0x8C88,
    AnySamplesPassedConservative = 0x8D6A,
}

public enum LightTextureModeEXT
{
    FragmentDepth = 0x8452,
}

public enum FogCoordSrc
{
    FogCoordinate = 0x8451,
    FogCoord = 0x8451,
    FragmentDepth = 0x8452,
}

public enum TextureUnit
{
    Texture0 = 0x84C0,
    Texture1 = 0x84C1,
    Texture2 = 0x84C2,
    Texture3 = 0x84C3,
    Texture4 = 0x84C4,
    Texture5 = 0x84C5,
    Texture6 = 0x84C6,
    Texture7 = 0x84C7,
    Texture8 = 0x84C8,
    Texture9 = 0x84C9,
    Texture10 = 0x84CA,
    Texture11 = 0x84CB,
    Texture12 = 0x84CC,
    Texture13 = 0x84CD,
    Texture14 = 0x84CE,
    Texture15 = 0x84CF,
    Texture16 = 0x84D0,
    Texture17 = 0x84D1,
    Texture18 = 0x84D2,
    Texture19 = 0x84D3,
    Texture20 = 0x84D4,
    Texture21 = 0x84D5,
    Texture22 = 0x84D6,
    Texture23 = 0x84D7,
    Texture24 = 0x84D8,
    Texture25 = 0x84D9,
    Texture26 = 0x84DA,
    Texture27 = 0x84DB,
    Texture28 = 0x84DC,
    Texture29 = 0x84DD,
    Texture30 = 0x84DE,
    Texture31 = 0x84DF,
}

public enum FragmentShaderTextureSourceATI
{
    Texture0 = 0x84C0,
    Texture1 = 0x84C1,
    Texture2 = 0x84C2,
    Texture3 = 0x84C3,
    Texture4 = 0x84C4,
    Texture5 = 0x84C5,
    Texture6 = 0x84C6,
    Texture7 = 0x84C7,
    Texture8 = 0x84C8,
    Texture9 = 0x84C9,
    Texture10 = 0x84CA,
    Texture11 = 0x84CB,
    Texture12 = 0x84CC,
    Texture13 = 0x84CD,
    Texture14 = 0x84CE,
    Texture15 = 0x84CF,
    Texture16 = 0x84D0,
    Texture17 = 0x84D1,
    Texture18 = 0x84D2,
    Texture19 = 0x84D3,
    Texture20 = 0x84D4,
    Texture21 = 0x84D5,
    Texture22 = 0x84D6,
    Texture23 = 0x84D7,
    Texture24 = 0x84D8,
    Texture25 = 0x84D9,
    Texture26 = 0x84DA,
    Texture27 = 0x84DB,
    Texture28 = 0x84DC,
    Texture29 = 0x84DD,
    Texture30 = 0x84DE,
    Texture31 = 0x84DF,
}

public enum CombinerRegisterNV
{

    [GLExtension("GL_ARB_multitexture")]
    Texture0ARB = 0x84C0,

    [GLExtension("GL_ARB_multitexture")]
    Texture1ARB = 0x84C1,
}

public enum UniformBlockPName
{
    UniformBlockReferencedByTessControlShader = 0x84F0,
    UniformBlockReferencedByTessEvaluationShader = 0x84F1,
    UniformBlockBinding = 0x8A3F,
    UniformBlockDataSize = 0x8A40,
    UniformBlockNameLength = 0x8A41,
    UniformBlockActiveUniforms = 0x8A42,
    UniformBlockActiveUniformIndices = 0x8A43,
    UniformBlockReferencedByVertexShader = 0x8A44,
    UniformBlockReferencedByGeometryShader = 0x8A45,
    UniformBlockReferencedByFragmentShader = 0x8A46,
    UniformBlockReferencedByComputeShader = 0x90EC,
}

public enum PathColor
{
    PrimaryColor = 0x8577,
}

public enum VertexAttribEnum
{
    VertexAttribArrayEnabled = 0x8622,
    VertexAttribArraySize = 0x8623,
    VertexAttribArrayStride = 0x8624,
    VertexAttribArrayType = 0x8625,
    CurrentVertexAttrib = 0x8626,
    VertexAttribArrayNormalized = 0x886A,
    VertexAttribArrayBufferBinding = 0x889F,
    VertexAttribArrayInteger = 0x88FD,
    VertexAttribArrayDivisor = 0x88FE,
}

public enum ProgramStringProperty
{

    [GLExtension("GL_ARB_fragment_program")]
    ProgramStringARB = 0x8628,
}

public enum VertexAttribPointerPropertyARB
{
    VertexAttribArrayPointer = 0x8645,

    [GLExtension("GL_ARB_vertex_program")]
    VertexAttribArrayPointerARB = 0x8645,
}

public enum QueryParameterName
{
    QueryCounterBits = 0x8864,
    CurrentQuery = 0x8865,
}

public enum ProgramFormat
{

    [GLExtension("GL_ARB_fragment_program")]
    ProgramFormatAsciiARB = 0x8875,
}

public enum CopyBufferSubDataTarget
{
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893,
    PixelPackBuffer = 0x88EB,
    PixelUnpackBuffer = 0x88EC,
    UniformBuffer = 0x8A11,
    TextureBuffer = 0x8C2A,
    TransformFeedbackBuffer = 0x8C8E,
    CopyReadBuffer = 0x8F36,
    CopyWriteBuffer = 0x8F37,
    DrawIndirectBuffer = 0x8F3F,
    ShaderStorageBuffer = 0x90D2,
    DispatchIndirectBuffer = 0x90EE,
    QueryBuffer = 0x9192,
    AtomicCounterBuffer = 0x92C0,
}

public enum BufferStorageTarget
{
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893,
    PixelPackBuffer = 0x88EB,
    PixelUnpackBuffer = 0x88EC,
    UniformBuffer = 0x8A11,
    TextureBuffer = 0x8C2A,
    TransformFeedbackBuffer = 0x8C8E,
    CopyReadBuffer = 0x8F36,
    CopyWriteBuffer = 0x8F37,
    DrawIndirectBuffer = 0x8F3F,
    ShaderStorageBuffer = 0x90D2,
    DispatchIndirectBuffer = 0x90EE,
    QueryBuffer = 0x9192,
    AtomicCounterBuffer = 0x92C0,
}

public enum BufferAccessARB
{
    ReadOnly = 0x88B8,
    WriteOnly = 0x88B9,
    ReadWrite = 0x88BA,
}

public enum BufferPointerNameARB
{
    BufferMapPointer = 0x88BD,

    [GLExtension("GL_ARB_vertex_buffer_object")]
    BufferMapPointerARB = 0x88BD,
}

public enum VertexBufferObjectUsage
{
    StreamDraw = 0x88E0,
    StreamRead = 0x88E1,
    StreamCopy = 0x88E2,
    StaticDraw = 0x88E4,
    StaticRead = 0x88E5,
    StaticCopy = 0x88E6,
    DynamicDraw = 0x88E8,
    DynamicRead = 0x88E9,
    DynamicCopy = 0x88EA,
}

public enum BufferUsageARB
{
    StreamDraw = 0x88E0,
    StreamRead = 0x88E1,
    StreamCopy = 0x88E2,
    StaticDraw = 0x88E4,
    StaticRead = 0x88E5,
    StaticCopy = 0x88E6,
    DynamicDraw = 0x88E8,
    DynamicRead = 0x88E9,
    DynamicCopy = 0x88EA,
}

public enum ClampColorTargetARB
{

    [GLExtension("GL_ARB_color_buffer_float")]
    ClampVertexColorARB = 0x891A,

    [GLExtension("GL_ARB_color_buffer_float")]
    ClampFragmentColorARB = 0x891B,
    ClampReadColor = 0x891C,

    [GLExtension("GL_ARB_color_buffer_float")]
    ClampReadColorARB = 0x891C,
}

public enum UniformPName
{
    UniformType = 0x8A37,
    UniformSize = 0x8A38,
    UniformNameLength = 0x8A39,
    UniformBlockIndex = 0x8A3A,
    UniformOffset = 0x8A3B,
    UniformArrayStride = 0x8A3C,
    UniformMatrixStride = 0x8A3D,
    UniformIsRowMajor = 0x8A3E,
    UniformAtomicCounterBufferIndex = 0x92DA,
}

public enum SubroutineParameterName
{
    UniformSize = 0x8A38,
    UniformNameLength = 0x8A39,
    NumCompatibleSubroutines = 0x8E4A,
    CompatibleSubroutines = 0x8E4B,
}

public enum ShaderType
{
    FragmentShader = 0x8B30,

    [GLExtension("GL_ARB_fragment_shader")]
    FragmentShaderARB = 0x8B30,
    VertexShader = 0x8B31,

    [GLExtension("GL_ARB_vertex_shader")]
    VertexShaderARB = 0x8B31,
    GeometryShader = 0x8DD9,
    TessEvaluationShader = 0x8E87,
    TessControlShader = 0x8E88,
    ComputeShader = 0x91B9,
}

public enum ContainerType
{

    [GLExtension("GL_ARB_shader_objects")]
    ProgramObjectARB = 0x8B40,
}

public enum ShaderParameterName
{
    ShaderType = 0x8B4F,
    DeleteStatus = 0x8B80,
    CompileStatus = 0x8B81,
    InfoLogLength = 0x8B84,
    ShaderSourceLength = 0x8B88,
}

public enum ShaderBinaryFormat
{
    ShaderBinaryFormatSpirV = 0x9551,
}

public enum TransformFeedbackPName
{
    TransformFeedbackBufferStart = 0x8C84,
    TransformFeedbackBufferSize = 0x8C85,
    TransformFeedbackBufferBinding = 0x8C8F,
    TransformFeedbackPaused = 0x8E23,
    TransformFeedbackActive = 0x8E24,
}

public enum TransformFeedbackBufferMode
{
    InterleavedAttribs = 0x8C8C,
    SeparateAttribs = 0x8C8D,
}

public enum ProgramInterface
{
    TransformFeedbackBuffer = 0x8C8E,
    Uniform = 0x92E1,
    UniformBlock = 0x92E2,
    ProgramInput = 0x92E3,
    ProgramOutput = 0x92E4,
    BufferVariable = 0x92E5,
    ShaderStorageBlock = 0x92E6,
    VertexSubroutine = 0x92E8,
    TessControlSubroutine = 0x92E9,
    TessEvaluationSubroutine = 0x92EA,
    GeometrySubroutine = 0x92EB,
    FragmentSubroutine = 0x92EC,
    ComputeSubroutine = 0x92ED,
    VertexSubroutineUniform = 0x92EE,
    TessControlSubroutineUniform = 0x92EF,
    TessEvaluationSubroutineUniform = 0x92F0,
    GeometrySubroutineUniform = 0x92F1,
    FragmentSubroutineUniform = 0x92F2,
    ComputeSubroutineUniform = 0x92F3,
    TransformFeedbackVarying = 0x92F4,
}

public enum ClipControlOrigin
{
    LowerLeft = 0x8CA1,
    UpperLeft = 0x8CA2,
}

public enum FramebufferTarget
{
    ReadFramebuffer = 0x8CA8,
    DrawFramebuffer = 0x8CA9,
    Framebuffer = 0x8D40,
}

public enum RenderbufferParameterName
{
    RenderbufferSamples = 0x8CAB,
    RenderbufferWidth = 0x8D42,
    RenderbufferHeight = 0x8D43,
    RenderbufferInternalFormat = 0x8D44,
    RenderbufferRedSize = 0x8D50,
    RenderbufferGreenSize = 0x8D51,
    RenderbufferBlueSize = 0x8D52,
    RenderbufferAlphaSize = 0x8D53,
    RenderbufferDepthSize = 0x8D54,
    RenderbufferStencilSize = 0x8D55,
}

public enum RenderbufferTarget
{
    Renderbuffer = 0x8D41,
}

public enum ProgramStagePName
{
    ActiveSubroutines = 0x8DE5,
    ActiveSubroutineUniforms = 0x8DE6,
    ActiveSubroutineUniformLocations = 0x8E47,
    ActiveSubroutineMaxLength = 0x8E48,
    ActiveSubroutineUniformMaxLength = 0x8E49,
}

public enum PrecisionType
{
    LowFloat = 0x8DF0,
    MediumFloat = 0x8DF1,
    HighFloat = 0x8DF2,
    LowInt = 0x8DF3,
    MediumInt = 0x8DF4,
    HighInt = 0x8DF5,
}

public enum ConditionalRenderMode
{
    QueryWait = 0x8E13,
    QueryNoWait = 0x8E14,
    QueryByRegionWait = 0x8E15,
    QueryByRegionNoWait = 0x8E16,
    QueryWaitInverted = 0x8E17,
    QueryNoWaitInverted = 0x8E18,
    QueryByRegionWaitInverted = 0x8E19,
    QueryByRegionNoWaitInverted = 0x8E1A,
}

public enum BindTransformFeedbackTarget
{
    TransformFeedback = 0x8E22,
}

public enum QueryCounterTarget
{
    Timestamp = 0x8E28,
}

public enum ProgramResourceProperty
{
    NumCompatibleSubroutines = 0x8E4A,
    CompatibleSubroutines = 0x8E4B,
    Uniform = 0x92E1,
    IsPerPatch = 0x92E7,
    NameLength = 0x92F9,
    Type = 0x92FA,
    ArraySize = 0x92FB,
    Offset = 0x92FC,
    BlockIndex = 0x92FD,
    ArrayStride = 0x92FE,
    MatrixStride = 0x92FF,
    IsRowMajor = 0x9300,
    AtomicCounterBufferIndex = 0x9301,
    BufferBinding = 0x9302,
    BufferDataSize = 0x9303,
    NumActiveVariables = 0x9304,
    ActiveVariables = 0x9305,
    ReferencedByVertexShader = 0x9306,
    ReferencedByTessControlShader = 0x9307,
    ReferencedByTessEvaluationShader = 0x9308,
    ReferencedByGeometryShader = 0x9309,
    ReferencedByFragmentShader = 0x930A,
    ReferencedByComputeShader = 0x930B,
    TopLevelArraySize = 0x930C,
    TopLevelArrayStride = 0x930D,
    Location = 0x930E,
    LocationIndex = 0x930F,
    LocationComponent = 0x934A,
    TransformFeedbackBufferIndex = 0x934B,
    TransformFeedbackBufferStride = 0x934C,
}

public enum VertexProvokingMode
{
    FirstVertexConvention = 0x8E4D,
    LastVertexConvention = 0x8E4E,
}

public enum GetMultisamplePNameNV
{
    SamplePosition = 0x8E50,

    [GLExtension("GL_ARB_sample_locations")]
    SampleLocationARB = 0x8E50,

    [GLExtension("GL_ARB_sample_locations")]
    ProgrammableSampleLocationARB = 0x9341,
}

public enum PatchParameterName
{
    PatchVertices = 0x8E72,
    PatchDefaultInnerLevel = 0x8E73,
    PatchDefaultOuterLevel = 0x8E74,
}

public enum AtomicCounterBufferPName
{
    AtomicCounterBufferReferencedByComputeShader = 0x90ED,
    AtomicCounterBufferBinding = 0x92C1,
    AtomicCounterBufferDataSize = 0x92C4,
    AtomicCounterBufferActiveAtomicCounters = 0x92C5,
    AtomicCounterBufferActiveAtomicCounterIndices = 0x92C6,
    AtomicCounterBufferReferencedByVertexShader = 0x92C7,
    AtomicCounterBufferReferencedByTessControlShader = 0x92C8,
    AtomicCounterBufferReferencedByTessEvaluationShader = 0x92C9,
    AtomicCounterBufferReferencedByGeometryShader = 0x92CA,
    AtomicCounterBufferReferencedByFragmentShader = 0x92CB,
}

public enum SyncParameterName
{
    ObjectType = 0x9112,
    SyncCondition = 0x9113,
    SyncStatus = 0x9114,
    SyncFlags = 0x9115,
}

public enum SyncCondition
{
    SyncGpuCommandsComplete = 0x9117,
}

public enum SyncStatus
{
    AlreadySignaled = 0x911A,
    TimeoutExpired = 0x911B,
    ConditionSatisfied = 0x911C,
    WaitFailed = 0x911D,
}

public enum ProgramInterfacePName
{
    ActiveResources = 0x92F5,
    MaxNameLength = 0x92F6,
    MaxNumActiveVariables = 0x92F7,
    MaxNumCompatibleSubroutines = 0x92F8,
}

public enum FramebufferParameterName
{
    FramebufferDefaultWidth = 0x9310,
    FramebufferDefaultHeight = 0x9311,
    FramebufferDefaultLayers = 0x9312,
    FramebufferDefaultSamples = 0x9313,
    FramebufferDefaultFixedSampleLocations = 0x9314,
}

public enum ClipControlDepth
{
    NegativeOneToOne = 0x935E,
    ZeroToOne = 0x935F,
}

public enum ShadingRateQCOM
{
    ShadingRate1x4PixelsQCOM = 0x96AA,
    ShadingRate4x1PixelsQCOM = 0x96AB,
    ShadingRate2x4PixelsQCOM = 0x96AD,
}

    public static class GL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCullFace(TriangleFace mode);
        private readonly GLCullFace glCullFace;

        public void CullFace(TriangleFace mode) =>
            this.glCullFace.Invoke(mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFrontFace(FrontFaceDirection mode);
        private readonly GLFrontFace glFrontFace;

        public void FrontFace(FrontFaceDirection mode) =>
            this.glFrontFace.Invoke(mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLHint(HintTarget target, HintMode mode);
        private readonly GLHint glHint;

        public void Hint(HintTarget target, HintMode mode) =>
            this.glHint.Invoke(target, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLineWidth(float width);
        private readonly GLLineWidth glLineWidth;

        public void LineWidth(float width) =>
            this.glLineWidth.Invoke(width);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointSize(float size);
        private readonly GLPointSize glPointSize;

        public void PointSize(float size) =>
            this.glPointSize.Invoke(size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPolygonMode(TriangleFace face, PolygonMode mode);
        private readonly GLPolygonMode glPolygonMode;

        public void PolygonMode(TriangleFace face, PolygonMode mode) =>
            this.glPolygonMode.Invoke(face, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLScissor(int x, int y, int width, int height);
        private readonly GLScissor glScissor;

        public void Scissor(int x, int y, int width, int height) =>
            this.glScissor.Invoke(x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameterf(TextureTarget target, TextureParameterName pname, float param);
        private readonly GLTexParameterf glTexParameterf;

        public void TexParameterf(TextureTarget target, TextureParameterName pname, float param) =>
            this.glTexParameterf.Invoke(target, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTexParameterfv(TextureTarget target, TextureParameterName pname, /*const*/ float* @params);
        private readonly GLTexParameterfv glTexParameterfv;

        public unsafe void TexParameterfv(TextureTarget target, TextureParameterName pname, /*const*/ float* @params) =>
            this.glTexParameterfv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameteri(TextureTarget target, TextureParameterName pname, int param);
        private readonly GLTexParameteri glTexParameteri;

        public void TexParameteri(TextureTarget target, TextureParameterName pname, int param) =>
            this.glTexParameteri.Invoke(target, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTexParameteriv(TextureTarget target, TextureParameterName pname, /*const*/ int* @params);
        private readonly GLTexParameteriv glTexParameteriv;

        public unsafe void TexParameteriv(TextureTarget target, TextureParameterName pname, /*const*/ int* @params) =>
            this.glTexParameteriv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage1D(TextureTarget target, int level, int internalformat, int width, int border, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexImage1D glTexImage1D;

        public void TexImage1D(TextureTarget target, int level, int internalformat, int width, int border, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexImage1D.Invoke(target, level, internalformat, width, border, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage2D(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexImage2D glTexImage2D;

        public void TexImage2D(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexImage2D.Invoke(target, level, internalformat, width, height, border, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawBuffer(DrawBufferMode buf);
        private readonly GLDrawBuffer glDrawBuffer;

        public void DrawBuffer(DrawBufferMode buf) =>
            this.glDrawBuffer.Invoke(buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClear(ClearBufferMask mask);
        private readonly GLClear glClear;

        public void Clear(ClearBufferMask mask) =>
            this.glClear.Invoke(mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearColor(float red, float green, float blue, float alpha);
        private readonly GLClearColor glClearColor;

        public void ClearColor(float red, float green, float blue, float alpha) =>
            this.glClearColor.Invoke(red, green, blue, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearStencil(int s);
        private readonly GLClearStencil glClearStencil;

        public void ClearStencil(int s) =>
            this.glClearStencil.Invoke(s);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearDepth(double depth);
        private readonly GLClearDepth glClearDepth;

        public void ClearDepth(double depth) =>
            this.glClearDepth.Invoke(depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilMask(uint mask);
        private readonly GLStencilMask glStencilMask;

        public void StencilMask(uint mask) =>
            this.glStencilMask.Invoke(mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLColorMask(bool red, bool green, bool blue, bool alpha);
        private readonly GLColorMask glColorMask;

        public void ColorMask(bool red, bool green, bool blue, bool alpha) =>
            this.glColorMask.Invoke(red, green, blue, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthMask(bool flag);
        private readonly GLDepthMask glDepthMask;

        public void DepthMask(bool flag) =>
            this.glDepthMask.Invoke(flag);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisable(EnableCap cap);
        private readonly GLDisable glDisable;

        public void Disable(EnableCap cap) =>
            this.glDisable.Invoke(cap);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnable(EnableCap cap);
        private readonly GLEnable glEnable;

        public void Enable(EnableCap cap) =>
            this.glEnable.Invoke(cap);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFinish();
        private readonly GLFinish glFinish;

        public void Finish() =>
            this.glFinish.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFlush();
        private readonly GLFlush glFlush;

        public void Flush() =>
            this.glFlush.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);
        private readonly GLBlendFunc glBlendFunc;

        public void BlendFunc(BlendingFactor sfactor, BlendingFactor dfactor) =>
            this.glBlendFunc.Invoke(sfactor, dfactor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLogicOp(LogicOp opcode);
        private readonly GLLogicOp glLogicOp;

        public void LogicOp(LogicOp opcode) =>
            this.glLogicOp.Invoke(opcode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilFunc(StencilFunction func, int @ref, uint mask);
        private readonly GLStencilFunc glStencilFunc;

        public void StencilFunc(StencilFunction func, int @ref, uint mask) =>
            this.glStencilFunc.Invoke(func, @ref, mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass);
        private readonly GLStencilOp glStencilOp;

        public void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass) =>
            this.glStencilOp.Invoke(fail, zfail, zpass);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthFunc(DepthFunction func);
        private readonly GLDepthFunc glDepthFunc;

        public void DepthFunc(DepthFunction func) =>
            this.glDepthFunc.Invoke(func);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPixelStoref(PixelStoreParameter pname, float param);
        private readonly GLPixelStoref glPixelStoref;

        public void PixelStoref(PixelStoreParameter pname, float param) =>
            this.glPixelStoref.Invoke(pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPixelStorei(PixelStoreParameter pname, int param);
        private readonly GLPixelStorei glPixelStorei;

        public void PixelStorei(PixelStoreParameter pname, int param) =>
            this.glPixelStorei.Invoke(pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadBuffer(ReadBufferMode src);
        private readonly GLReadBuffer glReadBuffer;

        public void ReadBuffer(ReadBufferMode src) =>
            this.glReadBuffer.Invoke(src);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, out nint pixels);
        private readonly GLReadPixels glReadPixels;

        public void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, out nint pixels) =>
            this.glReadPixels.Invoke(x, y, width, height, format, type, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetBooleanv(GetPName pname, bool* data);
        private readonly GLGetBooleanv glGetBooleanv;

        public unsafe void GetBooleanv(GetPName pname, bool* data) =>
            this.glGetBooleanv.Invoke(pname, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetDoublev(GetPName pname, double* data);
        private readonly GLGetDoublev glGetDoublev;

        public unsafe void GetDoublev(GetPName pname, double* data) =>
            this.glGetDoublev.Invoke(pname, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ErrorCode GLGetError();
        private readonly GLGetError glGetError;

        public ErrorCode GetError() =>
            this.glGetError.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetFloatv(GetPName pname, float* data);
        private readonly GLGetFloatv glGetFloatv;

        public unsafe void GetFloatv(GetPName pname, float* data) =>
            this.glGetFloatv.Invoke(pname, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetIntegerv(GetPName pname, int* data);
        private readonly GLGetIntegerv glGetIntegerv;

        public unsafe void GetIntegerv(GetPName pname, int* data) =>
            this.glGetIntegerv.Invoke(pname, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLGetString(StringName name);
        private readonly GLGetString glGetString;

        public nint GetString(StringName name) =>
            this.glGetString.Invoke(name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, out nint pixels);
        private readonly GLGetTexImage glGetTexImage;

        public void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, out nint pixels) =>
            this.glGetTexImage.Invoke(target, level, format, type, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexParameterfv(TextureTarget target, GetTextureParameter pname, float* @params);
        private readonly GLGetTexParameterfv glGetTexParameterfv;

        public unsafe void GetTexParameterfv(TextureTarget target, GetTextureParameter pname, float* @params) =>
            this.glGetTexParameterfv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexParameteriv(TextureTarget target, GetTextureParameter pname, int* @params);
        private readonly GLGetTexParameteriv glGetTexParameteriv;

        public unsafe void GetTexParameteriv(TextureTarget target, GetTextureParameter pname, int* @params) =>
            this.glGetTexParameteriv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, float* @params);
        private readonly GLGetTexLevelParameterfv glGetTexLevelParameterfv;

        public unsafe void GetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, float* @params) =>
            this.glGetTexLevelParameterfv.Invoke(target, level, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, int* @params);
        private readonly GLGetTexLevelParameteriv glGetTexLevelParameteriv;

        public unsafe void GetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, int* @params) =>
            this.glGetTexLevelParameteriv.Invoke(target, level, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsEnabled(EnableCap cap);
        private readonly GLIsEnabled glIsEnabled;

        public bool IsEnabled(EnableCap cap) =>
            this.glIsEnabled.Invoke(cap);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthRange(double n, double f);
        private readonly GLDepthRange glDepthRange;

        public void DepthRange(double n, double f) =>
            this.glDepthRange.Invoke(n, f);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLViewport(int x, int y, int width, int height);
        private readonly GLViewport glViewport;

        public void Viewport(int x, int y, int width, int height) =>
            this.glViewport.Invoke(x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReleaseShaderCompiler();
        private readonly GLReleaseShaderCompiler glReleaseShaderCompiler;

        public void ReleaseShaderCompiler() =>
            this.glReleaseShaderCompiler.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLShaderBinary(int count, /*const*/ uint* shaders, ShaderBinaryFormat binaryFormat, nint binary, int length);
        private readonly GLShaderBinary glShaderBinary;

        public unsafe void ShaderBinary(int count, /*const*/ uint* shaders, ShaderBinaryFormat binaryFormat, nint binary, int length) =>
            this.glShaderBinary.Invoke(count, shaders, binaryFormat, binary, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, int* range, int* precision);
        private readonly GLGetShaderPrecisionFormat glGetShaderPrecisionFormat;

        public unsafe void GetShaderPrecisionFormat(ShaderType shadertype, PrecisionType precisiontype, int* range, int* precision) =>
            this.glGetShaderPrecisionFormat.Invoke(shadertype, precisiontype, range, precision);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthRangef(float n, float f);
        private readonly GLDepthRangef glDepthRangef;

        public void DepthRangef(float n, float f) =>
            this.glDepthRangef.Invoke(n, f);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearDepthf(float d);
        private readonly GLClearDepthf glClearDepthf;

        public void ClearDepthf(float d) =>
            this.glClearDepthf.Invoke(d);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMemoryBarrierByRegion(MemoryBarrierMask barriers);
        private readonly GLMemoryBarrierByRegion glMemoryBarrierByRegion;

        public void MemoryBarrierByRegion(MemoryBarrierMask barriers) =>
            this.glMemoryBarrierByRegion.Invoke(barriers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPrimitiveBoundingBoxARB(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW);
        private readonly GLPrimitiveBoundingBoxARB glPrimitiveBoundingBoxARB;

        [GLExtension("GL_ARB_ES3_2_compatibility")]
        public void PrimitiveBoundingBoxARB(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW) =>
            this.glPrimitiveBoundingBoxARB.Invoke(minX, minY, minZ, minW, maxX, maxY, maxZ, maxW);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArraysInstancedBaseInstance(PrimitiveType mode, int first, int count, int instancecount, uint baseinstance);
        private readonly GLDrawArraysInstancedBaseInstance glDrawArraysInstancedBaseInstance;

        public void DrawArraysInstancedBaseInstance(PrimitiveType mode, int first, int count, int instancecount, uint baseinstance) =>
            this.glDrawArraysInstancedBaseInstance.Invoke(mode, first, count, instancecount, baseinstance);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstancedBaseInstance(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, uint baseinstance);
        private readonly GLDrawElementsInstancedBaseInstance glDrawElementsInstancedBaseInstance;

        public void DrawElementsInstancedBaseInstance(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, uint baseinstance) =>
            this.glDrawElementsInstancedBaseInstance.Invoke(mode, count, type, indices, instancecount, baseinstance);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstancedBaseVertexBaseInstance(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, int basevertex, uint baseinstance);
        private readonly GLDrawElementsInstancedBaseVertexBaseInstance glDrawElementsInstancedBaseVertexBaseInstance;

        public void DrawElementsInstancedBaseVertexBaseInstance(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, int basevertex, uint baseinstance) =>
            this.glDrawElementsInstancedBaseVertexBaseInstance.Invoke(mode, count, type, indices, instancecount, basevertex, baseinstance);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ulong GLGetTextureHandleARB(uint texture);
        private readonly GLGetTextureHandleARB glGetTextureHandleARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public ulong GetTextureHandleARB(uint texture) =>
            this.glGetTextureHandleARB.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ulong GLGetTextureSamplerHandleARB(uint texture, uint sampler);
        private readonly GLGetTextureSamplerHandleARB glGetTextureSamplerHandleARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public ulong GetTextureSamplerHandleARB(uint texture, uint sampler) =>
            this.glGetTextureSamplerHandleARB.Invoke(texture, sampler);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMakeTextureHandleResidentARB(ulong handle);
        private readonly GLMakeTextureHandleResidentARB glMakeTextureHandleResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void MakeTextureHandleResidentARB(ulong handle) =>
            this.glMakeTextureHandleResidentARB.Invoke(handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMakeTextureHandleNonResidentARB(ulong handle);
        private readonly GLMakeTextureHandleNonResidentARB glMakeTextureHandleNonResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void MakeTextureHandleNonResidentARB(ulong handle) =>
            this.glMakeTextureHandleNonResidentARB.Invoke(handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ulong GLGetImageHandleARB(uint texture, int level, bool layered, int layer, PixelFormat format);
        private readonly GLGetImageHandleARB glGetImageHandleARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public ulong GetImageHandleARB(uint texture, int level, bool layered, int layer, PixelFormat format) =>
            this.glGetImageHandleARB.Invoke(texture, level, layered, layer, format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMakeImageHandleResidentARB(ulong handle, int access);
        private readonly GLMakeImageHandleResidentARB glMakeImageHandleResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void MakeImageHandleResidentARB(ulong handle, int access) =>
            this.glMakeImageHandleResidentARB.Invoke(handle, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMakeImageHandleNonResidentARB(ulong handle);
        private readonly GLMakeImageHandleNonResidentARB glMakeImageHandleNonResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void MakeImageHandleNonResidentARB(ulong handle) =>
            this.glMakeImageHandleNonResidentARB.Invoke(handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformHandleui64ARB(int location, ulong value);
        private readonly GLUniformHandleui64ARB glUniformHandleui64ARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void UniformHandleui64ARB(int location, ulong value) =>
            this.glUniformHandleui64ARB.Invoke(location, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformHandleui64vARB(int location, int count, /*const*/ ulong* value);
        private readonly GLUniformHandleui64vARB glUniformHandleui64vARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public unsafe void UniformHandleui64vARB(int location, int count, /*const*/ ulong* value) =>
            this.glUniformHandleui64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniformHandleui64ARB(uint program, int location, ulong value);
        private readonly GLProgramUniformHandleui64ARB glProgramUniformHandleui64ARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void ProgramUniformHandleui64ARB(uint program, int location, ulong value) =>
            this.glProgramUniformHandleui64ARB.Invoke(program, location, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformHandleui64vARB(uint program, int location, int count, /*const*/ ulong* values);
        private readonly GLProgramUniformHandleui64vARB glProgramUniformHandleui64vARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public unsafe void ProgramUniformHandleui64vARB(uint program, int location, int count, /*const*/ ulong* values) =>
            this.glProgramUniformHandleui64vARB.Invoke(program, location, count, values);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsTextureHandleResidentARB(ulong handle);
        private readonly GLIsTextureHandleResidentARB glIsTextureHandleResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public bool IsTextureHandleResidentARB(ulong handle) =>
            this.glIsTextureHandleResidentARB.Invoke(handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsImageHandleResidentARB(ulong handle);
        private readonly GLIsImageHandleResidentARB glIsImageHandleResidentARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public bool IsImageHandleResidentARB(ulong handle) =>
            this.glIsImageHandleResidentARB.Invoke(handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribL1ui64ARB(uint index, ulong x);
        private readonly GLVertexAttribL1ui64ARB glVertexAttribL1ui64ARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public void VertexAttribL1ui64ARB(uint index, ulong x) =>
            this.glVertexAttribL1ui64ARB.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribL1ui64vARB(uint index, /*const*/ ulong* v);
        private readonly GLVertexAttribL1ui64vARB glVertexAttribL1ui64vARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public unsafe void VertexAttribL1ui64vARB(uint index, /*const*/ ulong* v) =>
            this.glVertexAttribL1ui64vARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribLui64vARB(uint index, VertexAttribEnum pname, ulong* @params);
        private readonly GLGetVertexAttribLui64vARB glGetVertexAttribLui64vARB;

        [GLExtension("GL_ARB_bindless_texture")]
        public unsafe void GetVertexAttribLui64vARB(uint index, VertexAttribEnum pname, ulong* @params) =>
            this.glGetVertexAttribLui64vARB.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindFragDataLocationIndexed(uint program, uint colorNumber, uint index, /*const*/ sbyte* name);
        private readonly GLBindFragDataLocationIndexed glBindFragDataLocationIndexed;

        public unsafe void BindFragDataLocationIndexed(uint program, uint colorNumber, uint index, /*const*/ sbyte* name) =>
            this.glBindFragDataLocationIndexed.Invoke(program, colorNumber, index, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetFragDataIndex(uint program, /*const*/ sbyte* name);
        private readonly GLGetFragDataIndex glGetFragDataIndex;

        public unsafe int GetFragDataIndex(uint program, /*const*/ sbyte* name) =>
            this.glGetFragDataIndex.Invoke(program, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferStorage(BufferStorageTarget target, nint size, nint data, BufferStorageMask flags);
        private readonly GLBufferStorage glBufferStorage;

        public void BufferStorage(BufferStorageTarget target, nint size, nint data, BufferStorageMask flags) =>
            this.glBufferStorage.Invoke(target, size, data, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate nint GLCreateSyncFromCLeventARB(nint context, nint @event, uint flags);
        private readonly GLCreateSyncFromCLeventARB glCreateSyncFromCLeventARB;

        [GLExtension("GL_ARB_cl_event")]
        public unsafe nint CreateSyncFromCLeventARB(nint context, nint @event, uint flags) =>
            this.glCreateSyncFromCLeventARB.Invoke(context, @event, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferData(BufferStorageTarget target, SizedInternalFormat internalformat, PixelFormat format, PixelType type, nint data);
        private readonly GLClearBufferData glClearBufferData;

        public void ClearBufferData(BufferStorageTarget target, SizedInternalFormat internalformat, PixelFormat format, PixelType type, nint data) =>
            this.glClearBufferData.Invoke(target, internalformat, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferSubData(BufferTargetARB target, SizedInternalFormat internalformat, nint offset, nint size, PixelFormat format, PixelType type, nint data);
        private readonly GLClearBufferSubData glClearBufferSubData;

        public void ClearBufferSubData(BufferTargetARB target, SizedInternalFormat internalformat, nint offset, nint size, PixelFormat format, PixelType type, nint data) =>
            this.glClearBufferSubData.Invoke(target, internalformat, offset, size, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearTexImage(uint texture, int level, PixelFormat format, PixelType type, nint data);
        private readonly GLClearTexImage glClearTexImage;

        public void ClearTexImage(uint texture, int level, PixelFormat format, PixelType type, nint data) =>
            this.glClearTexImage.Invoke(texture, level, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint data);
        private readonly GLClearTexSubImage glClearTexSubImage;

        public void ClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint data) =>
            this.glClearTexSubImage.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClipControl(ClipControlOrigin origin, ClipControlDepth depth);
        private readonly GLClipControl glClipControl;

        public void ClipControl(ClipControlOrigin origin, ClipControlDepth depth) =>
            this.glClipControl.Invoke(origin, depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClampColorARB(ClampColorTargetARB target, ClampColorModeARB clamp);
        private readonly GLClampColorARB glClampColorARB;

        [GLExtension("GL_ARB_color_buffer_float")]
        public void ClampColorARB(ClampColorTargetARB target, ClampColorModeARB clamp) =>
            this.glClampColorARB.Invoke(target, clamp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);
        private readonly GLDispatchCompute glDispatchCompute;

        public void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z) =>
            this.glDispatchCompute.Invoke(num_groups_x, num_groups_y, num_groups_z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDispatchComputeIndirect(nint indirect);
        private readonly GLDispatchComputeIndirect glDispatchComputeIndirect;

        public void DispatchComputeIndirect(nint indirect) =>
            this.glDispatchComputeIndirect.Invoke(indirect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDispatchComputeGroupSizeARB(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z);
        private readonly GLDispatchComputeGroupSizeARB glDispatchComputeGroupSizeARB;

        [GLExtension("GL_ARB_compute_variable_group_size")]
        public void DispatchComputeGroupSizeARB(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z) =>
            this.glDispatchComputeGroupSizeARB.Invoke(num_groups_x, num_groups_y, num_groups_z, group_size_x, group_size_y, group_size_z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyBufferSubData(CopyBufferSubDataTarget readTarget, CopyBufferSubDataTarget writeTarget, nint readOffset, nint writeOffset, nint size);
        private readonly GLCopyBufferSubData glCopyBufferSubData;

        public void CopyBufferSubData(CopyBufferSubDataTarget readTarget, CopyBufferSubDataTarget writeTarget, nint readOffset, nint writeOffset, nint size) =>
            this.glCopyBufferSubData.Invoke(readTarget, writeTarget, readOffset, writeOffset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyImageSubData(uint srcName, CopyImageSubDataTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, CopyImageSubDataTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth);
        private readonly GLCopyImageSubData glCopyImageSubData;

        public void CopyImageSubData(uint srcName, CopyImageSubDataTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, CopyImageSubDataTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth) =>
            this.glCopyImageSubData.Invoke(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageControlARB(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled);
        private readonly GLDebugMessageControlARB glDebugMessageControlARB;

        [GLExtension("GL_ARB_debug_output")]
        public unsafe void DebugMessageControlARB(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled) =>
            this.glDebugMessageControlARB.Invoke(source, type, severity, count, ids, enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageInsertARB(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf);
        private readonly GLDebugMessageInsertARB glDebugMessageInsertARB;

        [GLExtension("GL_ARB_debug_output")]
        public unsafe void DebugMessageInsertARB(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf) =>
            this.glDebugMessageInsertARB.Invoke(source, type, id, severity, length, buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageCallbackARB(DebugProc callback, nint userParam);
        private readonly GLDebugMessageCallbackARB glDebugMessageCallbackARB;

        [GLExtension("GL_ARB_debug_output")]
        public void DebugMessageCallbackARB(DebugProc callback, nint userParam) =>
            this.glDebugMessageCallbackARB.Invoke(callback, userParam);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetDebugMessageLogARB(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog);
        private readonly GLGetDebugMessageLogARB glGetDebugMessageLogARB;

        [GLExtension("GL_ARB_debug_output")]
        public unsafe uint GetDebugMessageLogARB(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog) =>
            this.glGetDebugMessageLogARB.Invoke(count, bufSize, sources, types, ids, severities, lengths, messageLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateTransformFeedbacks(int n, uint* ids);
        private readonly GLCreateTransformFeedbacks glCreateTransformFeedbacks;

        public unsafe void CreateTransformFeedbacks(int n, uint* ids) =>
            this.glCreateTransformFeedbacks.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTransformFeedbackBufferBase(uint xfb, uint index, uint buffer);
        private readonly GLTransformFeedbackBufferBase glTransformFeedbackBufferBase;

        public void TransformFeedbackBufferBase(uint xfb, uint index, uint buffer) =>
            this.glTransformFeedbackBufferBase.Invoke(xfb, index, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTransformFeedbackBufferRange(uint xfb, uint index, uint buffer, nint offset, nint size);
        private readonly GLTransformFeedbackBufferRange glTransformFeedbackBufferRange;

        public void TransformFeedbackBufferRange(uint xfb, uint index, uint buffer, nint offset, nint size) =>
            this.glTransformFeedbackBufferRange.Invoke(xfb, index, buffer, offset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTransformFeedbackiv(uint xfb, TransformFeedbackPName pname, int* param);
        private readonly GLGetTransformFeedbackiv glGetTransformFeedbackiv;

        public unsafe void GetTransformFeedbackiv(uint xfb, TransformFeedbackPName pname, int* param) =>
            this.glGetTransformFeedbackiv.Invoke(xfb, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTransformFeedbacki_v(uint xfb, TransformFeedbackPName pname, uint index, int* param);
        private readonly GLGetTransformFeedbacki_v glGetTransformFeedbacki_v;

        public unsafe void GetTransformFeedbacki_v(uint xfb, TransformFeedbackPName pname, uint index, int* param) =>
            this.glGetTransformFeedbacki_v.Invoke(xfb, pname, index, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTransformFeedbacki64_v(uint xfb, TransformFeedbackPName pname, uint index, long* param);
        private readonly GLGetTransformFeedbacki64_v glGetTransformFeedbacki64_v;

        public unsafe void GetTransformFeedbacki64_v(uint xfb, TransformFeedbackPName pname, uint index, long* param) =>
            this.glGetTransformFeedbacki64_v.Invoke(xfb, pname, index, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateBuffers(int n, uint* buffers);
        private readonly GLCreateBuffers glCreateBuffers;

        public unsafe void CreateBuffers(int n, uint* buffers) =>
            this.glCreateBuffers.Invoke(n, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedBufferStorage(uint buffer, nint size, nint data, BufferStorageMask flags);
        private readonly GLNamedBufferStorage glNamedBufferStorage;

        public void NamedBufferStorage(uint buffer, nint size, nint data, BufferStorageMask flags) =>
            this.glNamedBufferStorage.Invoke(buffer, size, data, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedBufferData(uint buffer, nint size, nint data, VertexBufferObjectUsage usage);
        private readonly GLNamedBufferData glNamedBufferData;

        public void NamedBufferData(uint buffer, nint size, nint data, VertexBufferObjectUsage usage) =>
            this.glNamedBufferData.Invoke(buffer, size, data, usage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedBufferSubData(uint buffer, nint offset, nint size, nint data);
        private readonly GLNamedBufferSubData glNamedBufferSubData;

        public void NamedBufferSubData(uint buffer, nint offset, nint size, nint data) =>
            this.glNamedBufferSubData.Invoke(buffer, offset, size, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyNamedBufferSubData(uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, nint size);
        private readonly GLCopyNamedBufferSubData glCopyNamedBufferSubData;

        public void CopyNamedBufferSubData(uint readBuffer, uint writeBuffer, nint readOffset, nint writeOffset, nint size) =>
            this.glCopyNamedBufferSubData.Invoke(readBuffer, writeBuffer, readOffset, writeOffset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearNamedBufferData(uint buffer, SizedInternalFormat internalformat, PixelFormat format, PixelType type, nint data);
        private readonly GLClearNamedBufferData glClearNamedBufferData;

        public void ClearNamedBufferData(uint buffer, SizedInternalFormat internalformat, PixelFormat format, PixelType type, nint data) =>
            this.glClearNamedBufferData.Invoke(buffer, internalformat, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearNamedBufferSubData(uint buffer, SizedInternalFormat internalformat, nint offset, nint size, PixelFormat format, PixelType type, nint data);
        private readonly GLClearNamedBufferSubData glClearNamedBufferSubData;

        public void ClearNamedBufferSubData(uint buffer, SizedInternalFormat internalformat, nint offset, nint size, PixelFormat format, PixelType type, nint data) =>
            this.glClearNamedBufferSubData.Invoke(buffer, internalformat, offset, size, format, type, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapNamedBuffer(uint buffer, BufferAccessARB access);
        private readonly GLMapNamedBuffer glMapNamedBuffer;

        public nint MapNamedBuffer(uint buffer, BufferAccessARB access) =>
            this.glMapNamedBuffer.Invoke(buffer, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapNamedBufferRange(uint buffer, nint offset, nint length, MapBufferAccessMask access);
        private readonly GLMapNamedBufferRange glMapNamedBufferRange;

        public nint MapNamedBufferRange(uint buffer, nint offset, nint length, MapBufferAccessMask access) =>
            this.glMapNamedBufferRange.Invoke(buffer, offset, length, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLUnmapNamedBuffer(uint buffer);
        private readonly GLUnmapNamedBuffer glUnmapNamedBuffer;

        public bool UnmapNamedBuffer(uint buffer) =>
            this.glUnmapNamedBuffer.Invoke(buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFlushMappedNamedBufferRange(uint buffer, nint offset, nint length);
        private readonly GLFlushMappedNamedBufferRange glFlushMappedNamedBufferRange;

        public void FlushMappedNamedBufferRange(uint buffer, nint offset, nint length) =>
            this.glFlushMappedNamedBufferRange.Invoke(buffer, offset, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedBufferParameteriv(uint buffer, BufferPNameARB pname, int* @params);
        private readonly GLGetNamedBufferParameteriv glGetNamedBufferParameteriv;

        public unsafe void GetNamedBufferParameteriv(uint buffer, BufferPNameARB pname, int* @params) =>
            this.glGetNamedBufferParameteriv.Invoke(buffer, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedBufferParameteri64v(uint buffer, BufferPNameARB pname, long* @params);
        private readonly GLGetNamedBufferParameteri64v glGetNamedBufferParameteri64v;

        public unsafe void GetNamedBufferParameteri64v(uint buffer, BufferPNameARB pname, long* @params) =>
            this.glGetNamedBufferParameteri64v.Invoke(buffer, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetNamedBufferPointerv(uint buffer, BufferPointerNameARB pname, out nint @params);
        private readonly GLGetNamedBufferPointerv glGetNamedBufferPointerv;

        public void GetNamedBufferPointerv(uint buffer, BufferPointerNameARB pname, out nint @params) =>
            this.glGetNamedBufferPointerv.Invoke(buffer, pname, out @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetNamedBufferSubData(uint buffer, nint offset, nint size, out nint data);
        private readonly GLGetNamedBufferSubData glGetNamedBufferSubData;

        public void GetNamedBufferSubData(uint buffer, nint offset, nint size, out nint data) =>
            this.glGetNamedBufferSubData.Invoke(buffer, offset, size, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateFramebuffers(int n, uint* framebuffers);
        private readonly GLCreateFramebuffers glCreateFramebuffers;

        public unsafe void CreateFramebuffers(int n, uint* framebuffers) =>
            this.glCreateFramebuffers.Invoke(n, framebuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferRenderbuffer(uint framebuffer, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
        private readonly GLNamedFramebufferRenderbuffer glNamedFramebufferRenderbuffer;

        public void NamedFramebufferRenderbuffer(uint framebuffer, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer) =>
            this.glNamedFramebufferRenderbuffer.Invoke(framebuffer, attachment, renderbuffertarget, renderbuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferParameteri(uint framebuffer, FramebufferParameterName pname, int param);
        private readonly GLNamedFramebufferParameteri glNamedFramebufferParameteri;

        public void NamedFramebufferParameteri(uint framebuffer, FramebufferParameterName pname, int param) =>
            this.glNamedFramebufferParameteri.Invoke(framebuffer, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferTexture(uint framebuffer, FramebufferAttachment attachment, uint texture, int level);
        private readonly GLNamedFramebufferTexture glNamedFramebufferTexture;

        public void NamedFramebufferTexture(uint framebuffer, FramebufferAttachment attachment, uint texture, int level) =>
            this.glNamedFramebufferTexture.Invoke(framebuffer, attachment, texture, level);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferTextureLayer(uint framebuffer, FramebufferAttachment attachment, uint texture, int level, int layer);
        private readonly GLNamedFramebufferTextureLayer glNamedFramebufferTextureLayer;

        public void NamedFramebufferTextureLayer(uint framebuffer, FramebufferAttachment attachment, uint texture, int level, int layer) =>
            this.glNamedFramebufferTextureLayer.Invoke(framebuffer, attachment, texture, level, layer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferDrawBuffer(uint framebuffer, ColorBuffer buf);
        private readonly GLNamedFramebufferDrawBuffer glNamedFramebufferDrawBuffer;

        public void NamedFramebufferDrawBuffer(uint framebuffer, ColorBuffer buf) =>
            this.glNamedFramebufferDrawBuffer.Invoke(framebuffer, buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLNamedFramebufferDrawBuffers(uint framebuffer, int n, /*const*/ ColorBuffer* bufs);
        private readonly GLNamedFramebufferDrawBuffers glNamedFramebufferDrawBuffers;

        public unsafe void NamedFramebufferDrawBuffers(uint framebuffer, int n, /*const*/ ColorBuffer* bufs) =>
            this.glNamedFramebufferDrawBuffers.Invoke(framebuffer, n, bufs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedFramebufferReadBuffer(uint framebuffer, ColorBuffer src);
        private readonly GLNamedFramebufferReadBuffer glNamedFramebufferReadBuffer;

        public void NamedFramebufferReadBuffer(uint framebuffer, ColorBuffer src) =>
            this.glNamedFramebufferReadBuffer.Invoke(framebuffer, src);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLInvalidateNamedFramebufferData(uint framebuffer, int numAttachments, /*const*/ FramebufferAttachment* attachments);
        private readonly GLInvalidateNamedFramebufferData glInvalidateNamedFramebufferData;

        public unsafe void InvalidateNamedFramebufferData(uint framebuffer, int numAttachments, /*const*/ FramebufferAttachment* attachments) =>
            this.glInvalidateNamedFramebufferData.Invoke(framebuffer, numAttachments, attachments);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLInvalidateNamedFramebufferSubData(uint framebuffer, int numAttachments, /*const*/ FramebufferAttachment* attachments, int x, int y, int width, int height);
        private readonly GLInvalidateNamedFramebufferSubData glInvalidateNamedFramebufferSubData;

        public unsafe void InvalidateNamedFramebufferSubData(uint framebuffer, int numAttachments, /*const*/ FramebufferAttachment* attachments, int x, int y, int width, int height) =>
            this.glInvalidateNamedFramebufferSubData.Invoke(framebuffer, numAttachments, attachments, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearNamedFramebufferiv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ int* value);
        private readonly GLClearNamedFramebufferiv glClearNamedFramebufferiv;

        public unsafe void ClearNamedFramebufferiv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ int* value) =>
            this.glClearNamedFramebufferiv.Invoke(framebuffer, buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearNamedFramebufferuiv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ uint* value);
        private readonly GLClearNamedFramebufferuiv glClearNamedFramebufferuiv;

        public unsafe void ClearNamedFramebufferuiv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ uint* value) =>
            this.glClearNamedFramebufferuiv.Invoke(framebuffer, buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearNamedFramebufferfv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ float* value);
        private readonly GLClearNamedFramebufferfv glClearNamedFramebufferfv;

        public unsafe void ClearNamedFramebufferfv(uint framebuffer, Buffer buffer, int drawbuffer, /*const*/ float* value) =>
            this.glClearNamedFramebufferfv.Invoke(framebuffer, buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearNamedFramebufferfi(uint framebuffer, Buffer buffer, int drawbuffer, float depth, int stencil);
        private readonly GLClearNamedFramebufferfi glClearNamedFramebufferfi;

        public void ClearNamedFramebufferfi(uint framebuffer, Buffer buffer, int drawbuffer, float depth, int stencil) =>
            this.glClearNamedFramebufferfi.Invoke(framebuffer, buffer, drawbuffer, depth, stencil);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlitNamedFramebuffer(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);
        private readonly GLBlitNamedFramebuffer glBlitNamedFramebuffer;

        public void BlitNamedFramebuffer(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter) =>
            this.glBlitNamedFramebuffer.Invoke(readFramebuffer, drawFramebuffer, srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FramebufferStatus GLCheckNamedFramebufferStatus(uint framebuffer, FramebufferTarget target);
        private readonly GLCheckNamedFramebufferStatus glCheckNamedFramebufferStatus;

        public FramebufferStatus CheckNamedFramebufferStatus(uint framebuffer, FramebufferTarget target) =>
            this.glCheckNamedFramebufferStatus.Invoke(framebuffer, target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedFramebufferParameteriv(uint framebuffer, GetFramebufferParameter pname, int* param);
        private readonly GLGetNamedFramebufferParameteriv glGetNamedFramebufferParameteriv;

        public unsafe void GetNamedFramebufferParameteriv(uint framebuffer, GetFramebufferParameter pname, int* param) =>
            this.glGetNamedFramebufferParameteriv.Invoke(framebuffer, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedFramebufferAttachmentParameteriv(uint framebuffer, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params);
        private readonly GLGetNamedFramebufferAttachmentParameteriv glGetNamedFramebufferAttachmentParameteriv;

        public unsafe void GetNamedFramebufferAttachmentParameteriv(uint framebuffer, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params) =>
            this.glGetNamedFramebufferAttachmentParameteriv.Invoke(framebuffer, attachment, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateRenderbuffers(int n, uint* renderbuffers);
        private readonly GLCreateRenderbuffers glCreateRenderbuffers;

        public unsafe void CreateRenderbuffers(int n, uint* renderbuffers) =>
            this.glCreateRenderbuffers.Invoke(n, renderbuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedRenderbufferStorage(uint renderbuffer, InternalFormat internalformat, int width, int height);
        private readonly GLNamedRenderbufferStorage glNamedRenderbufferStorage;

        public void NamedRenderbufferStorage(uint renderbuffer, InternalFormat internalformat, int width, int height) =>
            this.glNamedRenderbufferStorage.Invoke(renderbuffer, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedRenderbufferStorageMultisample(uint renderbuffer, int samples, InternalFormat internalformat, int width, int height);
        private readonly GLNamedRenderbufferStorageMultisample glNamedRenderbufferStorageMultisample;

        public void NamedRenderbufferStorageMultisample(uint renderbuffer, int samples, InternalFormat internalformat, int width, int height) =>
            this.glNamedRenderbufferStorageMultisample.Invoke(renderbuffer, samples, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedRenderbufferParameteriv(uint renderbuffer, RenderbufferParameterName pname, int* @params);
        private readonly GLGetNamedRenderbufferParameteriv glGetNamedRenderbufferParameteriv;

        public unsafe void GetNamedRenderbufferParameteriv(uint renderbuffer, RenderbufferParameterName pname, int* @params) =>
            this.glGetNamedRenderbufferParameteriv.Invoke(renderbuffer, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateTextures(TextureTarget target, int n, uint* textures);
        private readonly GLCreateTextures glCreateTextures;

        public unsafe void CreateTextures(TextureTarget target, int n, uint* textures) =>
            this.glCreateTextures.Invoke(target, n, textures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureBuffer(uint texture, SizedInternalFormat internalformat, uint buffer);
        private readonly GLTextureBuffer glTextureBuffer;

        public void TextureBuffer(uint texture, SizedInternalFormat internalformat, uint buffer) =>
            this.glTextureBuffer.Invoke(texture, internalformat, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureBufferRange(uint texture, SizedInternalFormat internalformat, uint buffer, nint offset, nint size);
        private readonly GLTextureBufferRange glTextureBufferRange;

        public void TextureBufferRange(uint texture, SizedInternalFormat internalformat, uint buffer, nint offset, nint size) =>
            this.glTextureBufferRange.Invoke(texture, internalformat, buffer, offset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureStorage1D(uint texture, int levels, SizedInternalFormat internalformat, int width);
        private readonly GLTextureStorage1D glTextureStorage1D;

        public void TextureStorage1D(uint texture, int levels, SizedInternalFormat internalformat, int width) =>
            this.glTextureStorage1D.Invoke(texture, levels, internalformat, width);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureStorage2D(uint texture, int levels, SizedInternalFormat internalformat, int width, int height);
        private readonly GLTextureStorage2D glTextureStorage2D;

        public void TextureStorage2D(uint texture, int levels, SizedInternalFormat internalformat, int width, int height) =>
            this.glTextureStorage2D.Invoke(texture, levels, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureStorage3D(uint texture, int levels, SizedInternalFormat internalformat, int width, int height, int depth);
        private readonly GLTextureStorage3D glTextureStorage3D;

        public void TextureStorage3D(uint texture, int levels, SizedInternalFormat internalformat, int width, int height, int depth) =>
            this.glTextureStorage3D.Invoke(texture, levels, internalformat, width, height, depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureStorage2DMultisample(uint texture, int samples, SizedInternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        private readonly GLTextureStorage2DMultisample glTextureStorage2DMultisample;

        public void TextureStorage2DMultisample(uint texture, int samples, SizedInternalFormat internalformat, int width, int height, bool fixedsamplelocations) =>
            this.glTextureStorage2DMultisample.Invoke(texture, samples, internalformat, width, height, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureStorage3DMultisample(uint texture, int samples, SizedInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        private readonly GLTextureStorage3DMultisample glTextureStorage3DMultisample;

        public void TextureStorage3DMultisample(uint texture, int samples, SizedInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations) =>
            this.glTextureStorage3DMultisample.Invoke(texture, samples, internalformat, width, height, depth, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTextureSubImage1D glTextureSubImage1D;

        public void TextureSubImage1D(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels) =>
            this.glTextureSubImage1D.Invoke(texture, level, xoffset, width, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTextureSubImage2D glTextureSubImage2D;

        public void TextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels) =>
            this.glTextureSubImage2D.Invoke(texture, level, xoffset, yoffset, width, height, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTextureSubImage3D glTextureSubImage3D;

        public void TextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels) =>
            this.glTextureSubImage3D.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTextureSubImage1D glCompressedTextureSubImage1D;

        public void CompressedTextureSubImage1D(uint texture, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTextureSubImage1D.Invoke(texture, level, xoffset, width, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTextureSubImage2D glCompressedTextureSubImage2D;

        public void CompressedTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTextureSubImage2D.Invoke(texture, level, xoffset, yoffset, width, height, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTextureSubImage3D glCompressedTextureSubImage3D;

        public void CompressedTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTextureSubImage3D.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTextureSubImage1D(uint texture, int level, int xoffset, int x, int y, int width);
        private readonly GLCopyTextureSubImage1D glCopyTextureSubImage1D;

        public void CopyTextureSubImage1D(uint texture, int level, int xoffset, int x, int y, int width) =>
            this.glCopyTextureSubImage1D.Invoke(texture, level, xoffset, x, y, width);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        private readonly GLCopyTextureSubImage2D glCopyTextureSubImage2D;

        public void CopyTextureSubImage2D(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height) =>
            this.glCopyTextureSubImage2D.Invoke(texture, level, xoffset, yoffset, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        private readonly GLCopyTextureSubImage3D glCopyTextureSubImage3D;

        public void CopyTextureSubImage3D(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height) =>
            this.glCopyTextureSubImage3D.Invoke(texture, level, xoffset, yoffset, zoffset, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureParameterf(uint texture, TextureParameterName pname, float param);
        private readonly GLTextureParameterf glTextureParameterf;

        public void TextureParameterf(uint texture, TextureParameterName pname, float param) =>
            this.glTextureParameterf.Invoke(texture, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTextureParameterfv(uint texture, TextureParameterName pname, /*const*/ float* param);
        private readonly GLTextureParameterfv glTextureParameterfv;

        public unsafe void TextureParameterfv(uint texture, TextureParameterName pname, /*const*/ float* param) =>
            this.glTextureParameterfv.Invoke(texture, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureParameteri(uint texture, TextureParameterName pname, int param);
        private readonly GLTextureParameteri glTextureParameteri;

        public void TextureParameteri(uint texture, TextureParameterName pname, int param) =>
            this.glTextureParameteri.Invoke(texture, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTextureParameterIiv(uint texture, TextureParameterName pname, /*const*/ int* @params);
        private readonly GLTextureParameterIiv glTextureParameterIiv;

        public unsafe void TextureParameterIiv(uint texture, TextureParameterName pname, /*const*/ int* @params) =>
            this.glTextureParameterIiv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTextureParameterIuiv(uint texture, TextureParameterName pname, /*const*/ uint* @params);
        private readonly GLTextureParameterIuiv glTextureParameterIuiv;

        public unsafe void TextureParameterIuiv(uint texture, TextureParameterName pname, /*const*/ uint* @params) =>
            this.glTextureParameterIuiv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTextureParameteriv(uint texture, TextureParameterName pname, /*const*/ int* param);
        private readonly GLTextureParameteriv glTextureParameteriv;

        public unsafe void TextureParameteriv(uint texture, TextureParameterName pname, /*const*/ int* param) =>
            this.glTextureParameteriv.Invoke(texture, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGenerateTextureMipmap(uint texture);
        private readonly GLGenerateTextureMipmap glGenerateTextureMipmap;

        public void GenerateTextureMipmap(uint texture) =>
            this.glGenerateTextureMipmap.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindTextureUnit(uint unit, uint texture);
        private readonly GLBindTextureUnit glBindTextureUnit;

        public void BindTextureUnit(uint unit, uint texture) =>
            this.glBindTextureUnit.Invoke(unit, texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, out nint pixels);
        private readonly GLGetTextureImage glGetTextureImage;

        public void GetTextureImage(uint texture, int level, PixelFormat format, PixelType type, int bufSize, out nint pixels) =>
            this.glGetTextureImage.Invoke(texture, level, format, type, bufSize, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetCompressedTextureImage(uint texture, int level, int bufSize, out nint pixels);
        private readonly GLGetCompressedTextureImage glGetCompressedTextureImage;

        public void GetCompressedTextureImage(uint texture, int level, int bufSize, out nint pixels) =>
            this.glGetCompressedTextureImage.Invoke(texture, level, bufSize, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureLevelParameterfv(uint texture, int level, GetTextureParameter pname, float* @params);
        private readonly GLGetTextureLevelParameterfv glGetTextureLevelParameterfv;

        public unsafe void GetTextureLevelParameterfv(uint texture, int level, GetTextureParameter pname, float* @params) =>
            this.glGetTextureLevelParameterfv.Invoke(texture, level, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureLevelParameteriv(uint texture, int level, GetTextureParameter pname, int* @params);
        private readonly GLGetTextureLevelParameteriv glGetTextureLevelParameteriv;

        public unsafe void GetTextureLevelParameteriv(uint texture, int level, GetTextureParameter pname, int* @params) =>
            this.glGetTextureLevelParameteriv.Invoke(texture, level, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureParameterfv(uint texture, GetTextureParameter pname, float* @params);
        private readonly GLGetTextureParameterfv glGetTextureParameterfv;

        public unsafe void GetTextureParameterfv(uint texture, GetTextureParameter pname, float* @params) =>
            this.glGetTextureParameterfv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureParameterIiv(uint texture, GetTextureParameter pname, int* @params);
        private readonly GLGetTextureParameterIiv glGetTextureParameterIiv;

        public unsafe void GetTextureParameterIiv(uint texture, GetTextureParameter pname, int* @params) =>
            this.glGetTextureParameterIiv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureParameterIuiv(uint texture, GetTextureParameter pname, uint* @params);
        private readonly GLGetTextureParameterIuiv glGetTextureParameterIuiv;

        public unsafe void GetTextureParameterIuiv(uint texture, GetTextureParameter pname, uint* @params) =>
            this.glGetTextureParameterIuiv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTextureParameteriv(uint texture, GetTextureParameter pname, int* @params);
        private readonly GLGetTextureParameteriv glGetTextureParameteriv;

        public unsafe void GetTextureParameteriv(uint texture, GetTextureParameter pname, int* @params) =>
            this.glGetTextureParameteriv.Invoke(texture, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateVertexArrays(int n, uint* arrays);
        private readonly GLCreateVertexArrays glCreateVertexArrays;

        public unsafe void CreateVertexArrays(int n, uint* arrays) =>
            this.glCreateVertexArrays.Invoke(n, arrays);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisableVertexArrayAttrib(uint vaobj, uint index);
        private readonly GLDisableVertexArrayAttrib glDisableVertexArrayAttrib;

        public void DisableVertexArrayAttrib(uint vaobj, uint index) =>
            this.glDisableVertexArrayAttrib.Invoke(vaobj, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnableVertexArrayAttrib(uint vaobj, uint index);
        private readonly GLEnableVertexArrayAttrib glEnableVertexArrayAttrib;

        public void EnableVertexArrayAttrib(uint vaobj, uint index) =>
            this.glEnableVertexArrayAttrib.Invoke(vaobj, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayElementBuffer(uint vaobj, uint buffer);
        private readonly GLVertexArrayElementBuffer glVertexArrayElementBuffer;

        public void VertexArrayElementBuffer(uint vaobj, uint buffer) =>
            this.glVertexArrayElementBuffer.Invoke(vaobj, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, nint offset, int stride);
        private readonly GLVertexArrayVertexBuffer glVertexArrayVertexBuffer;

        public void VertexArrayVertexBuffer(uint vaobj, uint bindingindex, uint buffer, nint offset, int stride) =>
            this.glVertexArrayVertexBuffer.Invoke(vaobj, bindingindex, buffer, offset, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexArrayVertexBuffers(uint vaobj, uint first, int count, /*const*/ uint* buffers, nint offsets, /*const*/ int* strides);
        private readonly GLVertexArrayVertexBuffers glVertexArrayVertexBuffers;

        public unsafe void VertexArrayVertexBuffers(uint vaobj, uint first, int count, /*const*/ uint* buffers, nint offsets, /*const*/ int* strides) =>
            this.glVertexArrayVertexBuffers.Invoke(vaobj, first, count, buffers, offsets, strides);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayAttribBinding(uint vaobj, uint attribindex, uint bindingindex);
        private readonly GLVertexArrayAttribBinding glVertexArrayAttribBinding;

        public void VertexArrayAttribBinding(uint vaobj, uint attribindex, uint bindingindex) =>
            this.glVertexArrayAttribBinding.Invoke(vaobj, attribindex, bindingindex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayAttribFormat(uint vaobj, uint attribindex, int size, VertexAttribType type, bool normalized, uint relativeoffset);
        private readonly GLVertexArrayAttribFormat glVertexArrayAttribFormat;

        public void VertexArrayAttribFormat(uint vaobj, uint attribindex, int size, VertexAttribType type, bool normalized, uint relativeoffset) =>
            this.glVertexArrayAttribFormat.Invoke(vaobj, attribindex, size, type, normalized, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayAttribIFormat(uint vaobj, uint attribindex, int size, VertexAttribIType type, uint relativeoffset);
        private readonly GLVertexArrayAttribIFormat glVertexArrayAttribIFormat;

        public void VertexArrayAttribIFormat(uint vaobj, uint attribindex, int size, VertexAttribIType type, uint relativeoffset) =>
            this.glVertexArrayAttribIFormat.Invoke(vaobj, attribindex, size, type, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayAttribLFormat(uint vaobj, uint attribindex, int size, VertexAttribLType type, uint relativeoffset);
        private readonly GLVertexArrayAttribLFormat glVertexArrayAttribLFormat;

        public void VertexArrayAttribLFormat(uint vaobj, uint attribindex, int size, VertexAttribLType type, uint relativeoffset) =>
            this.glVertexArrayAttribLFormat.Invoke(vaobj, attribindex, size, type, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexArrayBindingDivisor(uint vaobj, uint bindingindex, uint divisor);
        private readonly GLVertexArrayBindingDivisor glVertexArrayBindingDivisor;

        public void VertexArrayBindingDivisor(uint vaobj, uint bindingindex, uint divisor) =>
            this.glVertexArrayBindingDivisor.Invoke(vaobj, bindingindex, divisor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexArrayiv(uint vaobj, VertexArrayPName pname, int* param);
        private readonly GLGetVertexArrayiv glGetVertexArrayiv;

        public unsafe void GetVertexArrayiv(uint vaobj, VertexArrayPName pname, int* param) =>
            this.glGetVertexArrayiv.Invoke(vaobj, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexArrayIndexediv(uint vaobj, uint index, VertexArrayPName pname, int* param);
        private readonly GLGetVertexArrayIndexediv glGetVertexArrayIndexediv;

        public unsafe void GetVertexArrayIndexediv(uint vaobj, uint index, VertexArrayPName pname, int* param) =>
            this.glGetVertexArrayIndexediv.Invoke(vaobj, index, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexArrayIndexed64iv(uint vaobj, uint index, VertexArrayPName pname, long* param);
        private readonly GLGetVertexArrayIndexed64iv glGetVertexArrayIndexed64iv;

        public unsafe void GetVertexArrayIndexed64iv(uint vaobj, uint index, VertexArrayPName pname, long* param) =>
            this.glGetVertexArrayIndexed64iv.Invoke(vaobj, index, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateSamplers(int n, uint* samplers);
        private readonly GLCreateSamplers glCreateSamplers;

        public unsafe void CreateSamplers(int n, uint* samplers) =>
            this.glCreateSamplers.Invoke(n, samplers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateProgramPipelines(int n, uint* pipelines);
        private readonly GLCreateProgramPipelines glCreateProgramPipelines;

        public unsafe void CreateProgramPipelines(int n, uint* pipelines) =>
            this.glCreateProgramPipelines.Invoke(n, pipelines);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCreateQueries(QueryTarget target, int n, uint* ids);
        private readonly GLCreateQueries glCreateQueries;

        public unsafe void CreateQueries(QueryTarget target, int n, uint* ids) =>
            this.glCreateQueries.Invoke(target, n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryBufferObjecti64v(uint id, uint buffer, QueryObjectParameterName pname, nint offset);
        private readonly GLGetQueryBufferObjecti64v glGetQueryBufferObjecti64v;

        public void GetQueryBufferObjecti64v(uint id, uint buffer, QueryObjectParameterName pname, nint offset) =>
            this.glGetQueryBufferObjecti64v.Invoke(id, buffer, pname, offset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryBufferObjectiv(uint id, uint buffer, QueryObjectParameterName pname, nint offset);
        private readonly GLGetQueryBufferObjectiv glGetQueryBufferObjectiv;

        public void GetQueryBufferObjectiv(uint id, uint buffer, QueryObjectParameterName pname, nint offset) =>
            this.glGetQueryBufferObjectiv.Invoke(id, buffer, pname, offset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryBufferObjectui64v(uint id, uint buffer, QueryObjectParameterName pname, nint offset);
        private readonly GLGetQueryBufferObjectui64v glGetQueryBufferObjectui64v;

        public void GetQueryBufferObjectui64v(uint id, uint buffer, QueryObjectParameterName pname, nint offset) =>
            this.glGetQueryBufferObjectui64v.Invoke(id, buffer, pname, offset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryBufferObjectuiv(uint id, uint buffer, QueryObjectParameterName pname, nint offset);
        private readonly GLGetQueryBufferObjectuiv glGetQueryBufferObjectuiv;

        public void GetQueryBufferObjectuiv(uint id, uint buffer, QueryObjectParameterName pname, nint offset) =>
            this.glGetQueryBufferObjectuiv.Invoke(id, buffer, pname, offset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDrawBuffersARB(int n, /*const*/ DrawBufferMode* bufs);
        private readonly GLDrawBuffersARB glDrawBuffersARB;

        [GLExtension("GL_ARB_draw_buffers")]
        public unsafe void DrawBuffersARB(int n, /*const*/ DrawBufferMode* bufs) =>
            this.glDrawBuffersARB.Invoke(n, bufs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationiARB(uint buf, BlendEquationModeEXT mode);
        private readonly GLBlendEquationiARB glBlendEquationiARB;

        [GLExtension("GL_ARB_draw_buffers_blend")]
        public void BlendEquationiARB(uint buf, BlendEquationModeEXT mode) =>
            this.glBlendEquationiARB.Invoke(buf, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationSeparateiARB(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        private readonly GLBlendEquationSeparateiARB glBlendEquationSeparateiARB;

        [GLExtension("GL_ARB_draw_buffers_blend")]
        public void BlendEquationSeparateiARB(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha) =>
            this.glBlendEquationSeparateiARB.Invoke(buf, modeRGB, modeAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFunciARB(uint buf, BlendingFactor src, BlendingFactor dst);
        private readonly GLBlendFunciARB glBlendFunciARB;

        [GLExtension("GL_ARB_draw_buffers_blend")]
        public void BlendFunciARB(uint buf, BlendingFactor src, BlendingFactor dst) =>
            this.glBlendFunciARB.Invoke(buf, src, dst);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFuncSeparateiARB(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
        private readonly GLBlendFuncSeparateiARB glBlendFuncSeparateiARB;

        [GLExtension("GL_ARB_draw_buffers_blend")]
        public void BlendFuncSeparateiARB(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha) =>
            this.glBlendFuncSeparateiARB.Invoke(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint indices, int basevertex);
        private readonly GLDrawElementsBaseVertex glDrawElementsBaseVertex;

        public void DrawElementsBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint indices, int basevertex) =>
            this.glDrawElementsBaseVertex.Invoke(mode, count, type, indices, basevertex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawRangeElementsBaseVertex(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices, int basevertex);
        private readonly GLDrawRangeElementsBaseVertex glDrawRangeElementsBaseVertex;

        public void DrawRangeElementsBaseVertex(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices, int basevertex) =>
            this.glDrawRangeElementsBaseVertex.Invoke(mode, start, end, count, type, indices, basevertex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstancedBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, int basevertex);
        private readonly GLDrawElementsInstancedBaseVertex glDrawElementsInstancedBaseVertex;

        public void DrawElementsInstancedBaseVertex(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount, int basevertex) =>
            this.glDrawElementsInstancedBaseVertex.Invoke(mode, count, type, indices, instancecount, basevertex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiDrawElementsBaseVertex(PrimitiveType mode, /*const*/ int* count, DrawElementsType type, nint indices, int drawcount, /*const*/ int* basevertex);
        private readonly GLMultiDrawElementsBaseVertex glMultiDrawElementsBaseVertex;

        public unsafe void MultiDrawElementsBaseVertex(PrimitiveType mode, /*const*/ int* count, DrawElementsType type, nint indices, int drawcount, /*const*/ int* basevertex) =>
            this.glMultiDrawElementsBaseVertex.Invoke(mode, count, type, indices, drawcount, basevertex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArraysIndirect(PrimitiveType mode, nint indirect);
        private readonly GLDrawArraysIndirect glDrawArraysIndirect;

        public void DrawArraysIndirect(PrimitiveType mode, nint indirect) =>
            this.glDrawArraysIndirect.Invoke(mode, indirect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsIndirect(PrimitiveType mode, DrawElementsType type, nint indirect);
        private readonly GLDrawElementsIndirect glDrawElementsIndirect;

        public void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, nint indirect) =>
            this.glDrawElementsIndirect.Invoke(mode, type, indirect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArraysInstancedARB(PrimitiveType mode, int first, int count, int primcount);
        private readonly GLDrawArraysInstancedARB glDrawArraysInstancedARB;

        [GLExtension("GL_ARB_draw_instanced")]
        public void DrawArraysInstancedARB(PrimitiveType mode, int first, int count, int primcount) =>
            this.glDrawArraysInstancedARB.Invoke(mode, first, count, primcount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstancedARB(PrimitiveType mode, int count, DrawElementsType type, nint indices, int primcount);
        private readonly GLDrawElementsInstancedARB glDrawElementsInstancedARB;

        [GLExtension("GL_ARB_draw_instanced")]
        public void DrawElementsInstancedARB(PrimitiveType mode, int count, DrawElementsType type, nint indices, int primcount) =>
            this.glDrawElementsInstancedARB.Invoke(mode, count, type, indices, primcount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramStringARB(ProgramTarget target, ProgramFormat format, int len, nint @string);
        private readonly GLProgramStringARB glProgramStringARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void ProgramStringARB(ProgramTarget target, ProgramFormat format, int len, nint @string) =>
            this.glProgramStringARB.Invoke(target, format, len, @string);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindProgramARB(ProgramTarget target, uint program);
        private readonly GLBindProgramARB glBindProgramARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void BindProgramARB(ProgramTarget target, uint program) =>
            this.glBindProgramARB.Invoke(target, program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteProgramsARB(int n, /*const*/ uint* programs);
        private readonly GLDeleteProgramsARB glDeleteProgramsARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void DeleteProgramsARB(int n, /*const*/ uint* programs) =>
            this.glDeleteProgramsARB.Invoke(n, programs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenProgramsARB(int n, uint* programs);
        private readonly GLGenProgramsARB glGenProgramsARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GenProgramsARB(int n, uint* programs) =>
            this.glGenProgramsARB.Invoke(n, programs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramEnvParameter4dARB(ProgramTarget target, uint index, double x, double y, double z, double w);
        private readonly GLProgramEnvParameter4dARB glProgramEnvParameter4dARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void ProgramEnvParameter4dARB(ProgramTarget target, uint index, double x, double y, double z, double w) =>
            this.glProgramEnvParameter4dARB.Invoke(target, index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramEnvParameter4dvARB(ProgramTarget target, uint index, /*const*/ double* @params);
        private readonly GLProgramEnvParameter4dvARB glProgramEnvParameter4dvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void ProgramEnvParameter4dvARB(ProgramTarget target, uint index, /*const*/ double* @params) =>
            this.glProgramEnvParameter4dvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramEnvParameter4fARB(ProgramTarget target, uint index, float x, float y, float z, float w);
        private readonly GLProgramEnvParameter4fARB glProgramEnvParameter4fARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void ProgramEnvParameter4fARB(ProgramTarget target, uint index, float x, float y, float z, float w) =>
            this.glProgramEnvParameter4fARB.Invoke(target, index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramEnvParameter4fvARB(ProgramTarget target, uint index, /*const*/ float* @params);
        private readonly GLProgramEnvParameter4fvARB glProgramEnvParameter4fvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void ProgramEnvParameter4fvARB(ProgramTarget target, uint index, /*const*/ float* @params) =>
            this.glProgramEnvParameter4fvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramLocalParameter4dARB(ProgramTarget target, uint index, double x, double y, double z, double w);
        private readonly GLProgramLocalParameter4dARB glProgramLocalParameter4dARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void ProgramLocalParameter4dARB(ProgramTarget target, uint index, double x, double y, double z, double w) =>
            this.glProgramLocalParameter4dARB.Invoke(target, index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramLocalParameter4dvARB(ProgramTarget target, uint index, /*const*/ double* @params);
        private readonly GLProgramLocalParameter4dvARB glProgramLocalParameter4dvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void ProgramLocalParameter4dvARB(ProgramTarget target, uint index, /*const*/ double* @params) =>
            this.glProgramLocalParameter4dvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramLocalParameter4fARB(ProgramTarget target, uint index, float x, float y, float z, float w);
        private readonly GLProgramLocalParameter4fARB glProgramLocalParameter4fARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void ProgramLocalParameter4fARB(ProgramTarget target, uint index, float x, float y, float z, float w) =>
            this.glProgramLocalParameter4fARB.Invoke(target, index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramLocalParameter4fvARB(ProgramTarget target, uint index, /*const*/ float* @params);
        private readonly GLProgramLocalParameter4fvARB glProgramLocalParameter4fvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void ProgramLocalParameter4fvARB(ProgramTarget target, uint index, /*const*/ float* @params) =>
            this.glProgramLocalParameter4fvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramEnvParameterdvARB(ProgramTarget target, uint index, double* @params);
        private readonly GLGetProgramEnvParameterdvARB glGetProgramEnvParameterdvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GetProgramEnvParameterdvARB(ProgramTarget target, uint index, double* @params) =>
            this.glGetProgramEnvParameterdvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramEnvParameterfvARB(ProgramTarget target, uint index, float* @params);
        private readonly GLGetProgramEnvParameterfvARB glGetProgramEnvParameterfvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GetProgramEnvParameterfvARB(ProgramTarget target, uint index, float* @params) =>
            this.glGetProgramEnvParameterfvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramLocalParameterdvARB(ProgramTarget target, uint index, double* @params);
        private readonly GLGetProgramLocalParameterdvARB glGetProgramLocalParameterdvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GetProgramLocalParameterdvARB(ProgramTarget target, uint index, double* @params) =>
            this.glGetProgramLocalParameterdvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramLocalParameterfvARB(ProgramTarget target, uint index, float* @params);
        private readonly GLGetProgramLocalParameterfvARB glGetProgramLocalParameterfvARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GetProgramLocalParameterfvARB(ProgramTarget target, uint index, float* @params) =>
            this.glGetProgramLocalParameterfvARB.Invoke(target, index, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramivARB(ProgramTarget target, ProgramPropertyARB pname, int* @params);
        private readonly GLGetProgramivARB glGetProgramivARB;

        [GLExtension("GL_ARB_fragment_program")]
        public unsafe void GetProgramivARB(ProgramTarget target, ProgramPropertyARB pname, int* @params) =>
            this.glGetProgramivARB.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetProgramStringARB(ProgramTarget target, ProgramStringProperty pname, out nint @string);
        private readonly GLGetProgramStringARB glGetProgramStringARB;

        [GLExtension("GL_ARB_fragment_program")]
        public void GetProgramStringARB(ProgramTarget target, ProgramStringProperty pname, out nint @string) =>
            this.glGetProgramStringARB.Invoke(target, pname, out @string);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsProgramARB(uint program);
        private readonly GLIsProgramARB glIsProgramARB;

        [GLExtension("GL_ARB_fragment_program")]
        public bool IsProgramARB(uint program) =>
            this.glIsProgramARB.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferParameteri(FramebufferTarget target, FramebufferParameterName pname, int param);
        private readonly GLFramebufferParameteri glFramebufferParameteri;

        public void FramebufferParameteri(FramebufferTarget target, FramebufferParameterName pname, int param) =>
            this.glFramebufferParameteri.Invoke(target, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetFramebufferParameteriv(FramebufferTarget target, FramebufferAttachmentParameterName pname, int* @params);
        private readonly GLGetFramebufferParameteriv glGetFramebufferParameteriv;

        public unsafe void GetFramebufferParameteriv(FramebufferTarget target, FramebufferAttachmentParameterName pname, int* @params) =>
            this.glGetFramebufferParameteriv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsRenderbuffer(uint renderbuffer);
        private readonly GLIsRenderbuffer glIsRenderbuffer;

        public bool IsRenderbuffer(uint renderbuffer) =>
            this.glIsRenderbuffer.Invoke(renderbuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindRenderbuffer(RenderbufferTarget target, uint renderbuffer);
        private readonly GLBindRenderbuffer glBindRenderbuffer;

        public void BindRenderbuffer(RenderbufferTarget target, uint renderbuffer) =>
            this.glBindRenderbuffer.Invoke(target, renderbuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteRenderbuffers(int n, /*const*/ uint* renderbuffers);
        private readonly GLDeleteRenderbuffers glDeleteRenderbuffers;

        public unsafe void DeleteRenderbuffers(int n, /*const*/ uint* renderbuffers) =>
            this.glDeleteRenderbuffers.Invoke(n, renderbuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenRenderbuffers(int n, uint* renderbuffers);
        private readonly GLGenRenderbuffers glGenRenderbuffers;

        public unsafe void GenRenderbuffers(int n, uint* renderbuffers) =>
            this.glGenRenderbuffers.Invoke(n, renderbuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLRenderbufferStorage(RenderbufferTarget target, InternalFormat internalformat, int width, int height);
        private readonly GLRenderbufferStorage glRenderbufferStorage;

        public void RenderbufferStorage(RenderbufferTarget target, InternalFormat internalformat, int width, int height) =>
            this.glRenderbufferStorage.Invoke(target, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetRenderbufferParameteriv(RenderbufferTarget target, RenderbufferParameterName pname, int* @params);
        private readonly GLGetRenderbufferParameteriv glGetRenderbufferParameteriv;

        public unsafe void GetRenderbufferParameteriv(RenderbufferTarget target, RenderbufferParameterName pname, int* @params) =>
            this.glGetRenderbufferParameteriv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsFramebuffer(uint framebuffer);
        private readonly GLIsFramebuffer glIsFramebuffer;

        public bool IsFramebuffer(uint framebuffer) =>
            this.glIsFramebuffer.Invoke(framebuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindFramebuffer(FramebufferTarget target, uint framebuffer);
        private readonly GLBindFramebuffer glBindFramebuffer;

        public void BindFramebuffer(FramebufferTarget target, uint framebuffer) =>
            this.glBindFramebuffer.Invoke(target, framebuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteFramebuffers(int n, /*const*/ uint* framebuffers);
        private readonly GLDeleteFramebuffers glDeleteFramebuffers;

        public unsafe void DeleteFramebuffers(int n, /*const*/ uint* framebuffers) =>
            this.glDeleteFramebuffers.Invoke(n, framebuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenFramebuffers(int n, uint* framebuffers);
        private readonly GLGenFramebuffers glGenFramebuffers;

        public unsafe void GenFramebuffers(int n, uint* framebuffers) =>
            this.glGenFramebuffers.Invoke(n, framebuffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FramebufferStatus GLCheckFramebufferStatus(FramebufferTarget target);
        private readonly GLCheckFramebufferStatus glCheckFramebufferStatus;

        public FramebufferStatus CheckFramebufferStatus(FramebufferTarget target) =>
            this.glCheckFramebufferStatus.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
        private readonly GLFramebufferTexture1D glFramebufferTexture1D;

        public void FramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level) =>
            this.glFramebufferTexture1D.Invoke(target, attachment, textarget, texture, level);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
        private readonly GLFramebufferTexture2D glFramebufferTexture2D;

        public void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level) =>
            this.glFramebufferTexture2D.Invoke(target, attachment, textarget, texture, level);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level, int zoffset);
        private readonly GLFramebufferTexture3D glFramebufferTexture3D;

        public void FramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level, int zoffset) =>
            this.glFramebufferTexture3D.Invoke(target, attachment, textarget, texture, level, zoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
        private readonly GLFramebufferRenderbuffer glFramebufferRenderbuffer;

        public void FramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer) =>
            this.glFramebufferRenderbuffer.Invoke(target, attachment, renderbuffertarget, renderbuffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetFramebufferAttachmentParameteriv(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params);
        private readonly GLGetFramebufferAttachmentParameteriv glGetFramebufferAttachmentParameteriv;

        public unsafe void GetFramebufferAttachmentParameteriv(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params) =>
            this.glGetFramebufferAttachmentParameteriv.Invoke(target, attachment, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGenerateMipmap(TextureTarget target);
        private readonly GLGenerateMipmap glGenerateMipmap;

        public void GenerateMipmap(TextureTarget target) =>
            this.glGenerateMipmap.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);
        private readonly GLBlitFramebuffer glBlitFramebuffer;

        public void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter) =>
            this.glBlitFramebuffer.Invoke(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLRenderbufferStorageMultisample(RenderbufferTarget target, int samples, InternalFormat internalformat, int width, int height);
        private readonly GLRenderbufferStorageMultisample glRenderbufferStorageMultisample;

        public void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, InternalFormat internalformat, int width, int height) =>
            this.glRenderbufferStorageMultisample.Invoke(target, samples, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer);
        private readonly GLFramebufferTextureLayer glFramebufferTextureLayer;

        public void FramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer) =>
            this.glFramebufferTextureLayer.Invoke(target, attachment, texture, level, layer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramParameteriARB(uint program, ProgramParameterPName pname, int value);
        private readonly GLProgramParameteriARB glProgramParameteriARB;

        [GLExtension("GL_ARB_geometry_shader4")]
        public void ProgramParameteriARB(uint program, ProgramParameterPName pname, int value) =>
            this.glProgramParameteriARB.Invoke(program, pname, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level);
        private readonly GLFramebufferTextureARB glFramebufferTextureARB;

        [GLExtension("GL_ARB_geometry_shader4")]
        public void FramebufferTextureARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level) =>
            this.glFramebufferTextureARB.Invoke(target, attachment, texture, level);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureLayerARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer);
        private readonly GLFramebufferTextureLayerARB glFramebufferTextureLayerARB;

        [GLExtension("GL_ARB_geometry_shader4")]
        public void FramebufferTextureLayerARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer) =>
            this.glFramebufferTextureLayerARB.Invoke(target, attachment, texture, level, layer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureFaceARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, TextureTarget face);
        private readonly GLFramebufferTextureFaceARB glFramebufferTextureFaceARB;

        [GLExtension("GL_ARB_geometry_shader4")]
        public void FramebufferTextureFaceARB(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, TextureTarget face) =>
            this.glFramebufferTextureFaceARB.Invoke(target, attachment, texture, level, face);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramBinary(uint program, int bufSize, int* length, int* binaryFormat, out nint binary);
        private readonly GLGetProgramBinary glGetProgramBinary;

        public unsafe void GetProgramBinary(uint program, int bufSize, int* length, int* binaryFormat, out nint binary) =>
            this.glGetProgramBinary.Invoke(program, bufSize, length, binaryFormat, out binary);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramBinary(uint program, int binaryFormat, nint binary, int length);
        private readonly GLProgramBinary glProgramBinary;

        public void ProgramBinary(uint program, int binaryFormat, nint binary, int length) =>
            this.glProgramBinary.Invoke(program, binaryFormat, binary, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramParameteri(uint program, ProgramParameterPName pname, int value);
        private readonly GLProgramParameteri glProgramParameteri;

        public void ProgramParameteri(uint program, ProgramParameterPName pname, int value) =>
            this.glProgramParameteri.Invoke(program, pname, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, out nint pixels);
        private readonly GLGetTextureSubImage glGetTextureSubImage;

        public void GetTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, out nint pixels) =>
            this.glGetTextureSubImage.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, bufSize, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, out nint pixels);
        private readonly GLGetCompressedTextureSubImage glGetCompressedTextureSubImage;

        public void GetCompressedTextureSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, out nint pixels) =>
            this.glGetCompressedTextureSubImage.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth, bufSize, out pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLSpecializeShaderARB(uint shader, /*const*/ sbyte* pEntryPoint, uint numSpecializationConstants, /*const*/ uint* pConstantIndex, /*const*/ uint* pConstantValue);
        private readonly GLSpecializeShaderARB glSpecializeShaderARB;

        [GLExtension("GL_ARB_gl_spirv")]
        public unsafe void SpecializeShaderARB(uint shader, /*const*/ sbyte* pEntryPoint, uint numSpecializationConstants, /*const*/ uint* pConstantIndex, /*const*/ uint* pConstantValue) =>
            this.glSpecializeShaderARB.Invoke(shader, pEntryPoint, numSpecializationConstants, pConstantIndex, pConstantValue);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1d(int location, double x);
        private readonly GLUniform1d glUniform1d;

        public void Uniform1d(int location, double x) =>
            this.glUniform1d.Invoke(location, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2d(int location, double x, double y);
        private readonly GLUniform2d glUniform2d;

        public void Uniform2d(int location, double x, double y) =>
            this.glUniform2d.Invoke(location, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3d(int location, double x, double y, double z);
        private readonly GLUniform3d glUniform3d;

        public void Uniform3d(int location, double x, double y, double z) =>
            this.glUniform3d.Invoke(location, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4d(int location, double x, double y, double z, double w);
        private readonly GLUniform4d glUniform4d;

        public void Uniform4d(int location, double x, double y, double z, double w) =>
            this.glUniform4d.Invoke(location, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1dv(int location, int count, /*const*/ double* value);
        private readonly GLUniform1dv glUniform1dv;

        public unsafe void Uniform1dv(int location, int count, /*const*/ double* value) =>
            this.glUniform1dv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2dv(int location, int count, /*const*/ double* value);
        private readonly GLUniform2dv glUniform2dv;

        public unsafe void Uniform2dv(int location, int count, /*const*/ double* value) =>
            this.glUniform2dv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3dv(int location, int count, /*const*/ double* value);
        private readonly GLUniform3dv glUniform3dv;

        public unsafe void Uniform3dv(int location, int count, /*const*/ double* value) =>
            this.glUniform3dv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4dv(int location, int count, /*const*/ double* value);
        private readonly GLUniform4dv glUniform4dv;

        public unsafe void Uniform4dv(int location, int count, /*const*/ double* value) =>
            this.glUniform4dv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix2dv glUniformMatrix2dv;

        public unsafe void UniformMatrix2dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix2dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix3dv glUniformMatrix3dv;

        public unsafe void UniformMatrix3dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix3dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix4dv glUniformMatrix4dv;

        public unsafe void UniformMatrix4dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix4dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2x3dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix2x3dv glUniformMatrix2x3dv;

        public unsafe void UniformMatrix2x3dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix2x3dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2x4dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix2x4dv glUniformMatrix2x4dv;

        public unsafe void UniformMatrix2x4dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix2x4dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3x2dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix3x2dv glUniformMatrix3x2dv;

        public unsafe void UniformMatrix3x2dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix3x2dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3x4dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix3x4dv glUniformMatrix3x4dv;

        public unsafe void UniformMatrix3x4dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix3x4dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4x2dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix4x2dv glUniformMatrix4x2dv;

        public unsafe void UniformMatrix4x2dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix4x2dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4x3dv(int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLUniformMatrix4x3dv glUniformMatrix4x3dv;

        public unsafe void UniformMatrix4x3dv(int location, int count, bool transpose, /*const*/ double* value) =>
            this.glUniformMatrix4x3dv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformdv(uint program, int location, double* @params);
        private readonly GLGetUniformdv glGetUniformdv;

        public unsafe void GetUniformdv(uint program, int location, double* @params) =>
            this.glGetUniformdv.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1i64ARB(int location, long x);
        private readonly GLUniform1i64ARB glUniform1i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform1i64ARB(int location, long x) =>
            this.glUniform1i64ARB.Invoke(location, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2i64ARB(int location, long x, long y);
        private readonly GLUniform2i64ARB glUniform2i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform2i64ARB(int location, long x, long y) =>
            this.glUniform2i64ARB.Invoke(location, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3i64ARB(int location, long x, long y, long z);
        private readonly GLUniform3i64ARB glUniform3i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform3i64ARB(int location, long x, long y, long z) =>
            this.glUniform3i64ARB.Invoke(location, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4i64ARB(int location, long x, long y, long z, long w);
        private readonly GLUniform4i64ARB glUniform4i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform4i64ARB(int location, long x, long y, long z, long w) =>
            this.glUniform4i64ARB.Invoke(location, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1i64vARB(int location, int count, /*const*/ long* value);
        private readonly GLUniform1i64vARB glUniform1i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform1i64vARB(int location, int count, /*const*/ long* value) =>
            this.glUniform1i64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2i64vARB(int location, int count, /*const*/ long* value);
        private readonly GLUniform2i64vARB glUniform2i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform2i64vARB(int location, int count, /*const*/ long* value) =>
            this.glUniform2i64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3i64vARB(int location, int count, /*const*/ long* value);
        private readonly GLUniform3i64vARB glUniform3i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform3i64vARB(int location, int count, /*const*/ long* value) =>
            this.glUniform3i64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4i64vARB(int location, int count, /*const*/ long* value);
        private readonly GLUniform4i64vARB glUniform4i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform4i64vARB(int location, int count, /*const*/ long* value) =>
            this.glUniform4i64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1ui64ARB(int location, ulong x);
        private readonly GLUniform1ui64ARB glUniform1ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform1ui64ARB(int location, ulong x) =>
            this.glUniform1ui64ARB.Invoke(location, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2ui64ARB(int location, ulong x, ulong y);
        private readonly GLUniform2ui64ARB glUniform2ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform2ui64ARB(int location, ulong x, ulong y) =>
            this.glUniform2ui64ARB.Invoke(location, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3ui64ARB(int location, ulong x, ulong y, ulong z);
        private readonly GLUniform3ui64ARB glUniform3ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform3ui64ARB(int location, ulong x, ulong y, ulong z) =>
            this.glUniform3ui64ARB.Invoke(location, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4ui64ARB(int location, ulong x, ulong y, ulong z, ulong w);
        private readonly GLUniform4ui64ARB glUniform4ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void Uniform4ui64ARB(int location, ulong x, ulong y, ulong z, ulong w) =>
            this.glUniform4ui64ARB.Invoke(location, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1ui64vARB(int location, int count, /*const*/ ulong* value);
        private readonly GLUniform1ui64vARB glUniform1ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform1ui64vARB(int location, int count, /*const*/ ulong* value) =>
            this.glUniform1ui64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2ui64vARB(int location, int count, /*const*/ ulong* value);
        private readonly GLUniform2ui64vARB glUniform2ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform2ui64vARB(int location, int count, /*const*/ ulong* value) =>
            this.glUniform2ui64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3ui64vARB(int location, int count, /*const*/ ulong* value);
        private readonly GLUniform3ui64vARB glUniform3ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform3ui64vARB(int location, int count, /*const*/ ulong* value) =>
            this.glUniform3ui64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4ui64vARB(int location, int count, /*const*/ ulong* value);
        private readonly GLUniform4ui64vARB glUniform4ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void Uniform4ui64vARB(int location, int count, /*const*/ ulong* value) =>
            this.glUniform4ui64vARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformi64vARB(uint program, int location, long* @params);
        private readonly GLGetUniformi64vARB glGetUniformi64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void GetUniformi64vARB(uint program, int location, long* @params) =>
            this.glGetUniformi64vARB.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformui64vARB(uint program, int location, ulong* @params);
        private readonly GLGetUniformui64vARB glGetUniformui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void GetUniformui64vARB(uint program, int location, ulong* @params) =>
            this.glGetUniformui64vARB.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformi64vARB(uint program, int location, int bufSize, long* @params);
        private readonly GLGetnUniformi64vARB glGetnUniformi64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void GetnUniformi64vARB(uint program, int location, int bufSize, long* @params) =>
            this.glGetnUniformi64vARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformui64vARB(uint program, int location, int bufSize, ulong* @params);
        private readonly GLGetnUniformui64vARB glGetnUniformui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void GetnUniformui64vARB(uint program, int location, int bufSize, ulong* @params) =>
            this.glGetnUniformui64vARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1i64ARB(uint program, int location, long x);
        private readonly GLProgramUniform1i64ARB glProgramUniform1i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform1i64ARB(uint program, int location, long x) =>
            this.glProgramUniform1i64ARB.Invoke(program, location, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2i64ARB(uint program, int location, long x, long y);
        private readonly GLProgramUniform2i64ARB glProgramUniform2i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform2i64ARB(uint program, int location, long x, long y) =>
            this.glProgramUniform2i64ARB.Invoke(program, location, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3i64ARB(uint program, int location, long x, long y, long z);
        private readonly GLProgramUniform3i64ARB glProgramUniform3i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform3i64ARB(uint program, int location, long x, long y, long z) =>
            this.glProgramUniform3i64ARB.Invoke(program, location, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4i64ARB(uint program, int location, long x, long y, long z, long w);
        private readonly GLProgramUniform4i64ARB glProgramUniform4i64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform4i64ARB(uint program, int location, long x, long y, long z, long w) =>
            this.glProgramUniform4i64ARB.Invoke(program, location, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1i64vARB(uint program, int location, int count, /*const*/ long* value);
        private readonly GLProgramUniform1i64vARB glProgramUniform1i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform1i64vARB(uint program, int location, int count, /*const*/ long* value) =>
            this.glProgramUniform1i64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2i64vARB(uint program, int location, int count, /*const*/ long* value);
        private readonly GLProgramUniform2i64vARB glProgramUniform2i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform2i64vARB(uint program, int location, int count, /*const*/ long* value) =>
            this.glProgramUniform2i64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3i64vARB(uint program, int location, int count, /*const*/ long* value);
        private readonly GLProgramUniform3i64vARB glProgramUniform3i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform3i64vARB(uint program, int location, int count, /*const*/ long* value) =>
            this.glProgramUniform3i64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4i64vARB(uint program, int location, int count, /*const*/ long* value);
        private readonly GLProgramUniform4i64vARB glProgramUniform4i64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform4i64vARB(uint program, int location, int count, /*const*/ long* value) =>
            this.glProgramUniform4i64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1ui64ARB(uint program, int location, ulong x);
        private readonly GLProgramUniform1ui64ARB glProgramUniform1ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform1ui64ARB(uint program, int location, ulong x) =>
            this.glProgramUniform1ui64ARB.Invoke(program, location, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2ui64ARB(uint program, int location, ulong x, ulong y);
        private readonly GLProgramUniform2ui64ARB glProgramUniform2ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform2ui64ARB(uint program, int location, ulong x, ulong y) =>
            this.glProgramUniform2ui64ARB.Invoke(program, location, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3ui64ARB(uint program, int location, ulong x, ulong y, ulong z);
        private readonly GLProgramUniform3ui64ARB glProgramUniform3ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform3ui64ARB(uint program, int location, ulong x, ulong y, ulong z) =>
            this.glProgramUniform3ui64ARB.Invoke(program, location, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4ui64ARB(uint program, int location, ulong x, ulong y, ulong z, ulong w);
        private readonly GLProgramUniform4ui64ARB glProgramUniform4ui64ARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public void ProgramUniform4ui64ARB(uint program, int location, ulong x, ulong y, ulong z, ulong w) =>
            this.glProgramUniform4ui64ARB.Invoke(program, location, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1ui64vARB(uint program, int location, int count, /*const*/ ulong* value);
        private readonly GLProgramUniform1ui64vARB glProgramUniform1ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform1ui64vARB(uint program, int location, int count, /*const*/ ulong* value) =>
            this.glProgramUniform1ui64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2ui64vARB(uint program, int location, int count, /*const*/ ulong* value);
        private readonly GLProgramUniform2ui64vARB glProgramUniform2ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform2ui64vARB(uint program, int location, int count, /*const*/ ulong* value) =>
            this.glProgramUniform2ui64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3ui64vARB(uint program, int location, int count, /*const*/ ulong* value);
        private readonly GLProgramUniform3ui64vARB glProgramUniform3ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform3ui64vARB(uint program, int location, int count, /*const*/ ulong* value) =>
            this.glProgramUniform3ui64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4ui64vARB(uint program, int location, int count, /*const*/ ulong* value);
        private readonly GLProgramUniform4ui64vARB glProgramUniform4ui64vARB;

        [GLExtension("GL_ARB_gpu_shader_int64")]
        public unsafe void ProgramUniform4ui64vARB(uint program, int location, int count, /*const*/ ulong* value) =>
            this.glProgramUniform4ui64vARB.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendColor(float red, float green, float blue, float alpha);
        private readonly GLBlendColor glBlendColor;

        public void BlendColor(float red, float green, float blue, float alpha) =>
            this.glBlendColor.Invoke(red, green, blue, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquation(BlendEquationModeEXT mode);
        private readonly GLBlendEquation glBlendEquation;

        public void BlendEquation(BlendEquationModeEXT mode) =>
            this.glBlendEquation.Invoke(mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawArraysIndirectCountARB(PrimitiveType mode, nint indirect, nint drawcount, int maxdrawcount, int stride);
        private readonly GLMultiDrawArraysIndirectCountARB glMultiDrawArraysIndirectCountARB;

        [GLExtension("GL_ARB_indirect_parameters")]
        public void MultiDrawArraysIndirectCountARB(PrimitiveType mode, nint indirect, nint drawcount, int maxdrawcount, int stride) =>
            this.glMultiDrawArraysIndirectCountARB.Invoke(mode, indirect, drawcount, maxdrawcount, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawElementsIndirectCountARB(PrimitiveType mode, DrawElementsType type, nint indirect, nint drawcount, int maxdrawcount, int stride);
        private readonly GLMultiDrawElementsIndirectCountARB glMultiDrawElementsIndirectCountARB;

        [GLExtension("GL_ARB_indirect_parameters")]
        public void MultiDrawElementsIndirectCountARB(PrimitiveType mode, DrawElementsType type, nint indirect, nint drawcount, int maxdrawcount, int stride) =>
            this.glMultiDrawElementsIndirectCountARB.Invoke(mode, type, indirect, drawcount, maxdrawcount, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribDivisorARB(uint index, uint divisor);
        private readonly GLVertexAttribDivisorARB glVertexAttribDivisorARB;

        [GLExtension("GL_ARB_instanced_arrays")]
        public void VertexAttribDivisorARB(uint index, uint divisor) =>
            this.glVertexAttribDivisorARB.Invoke(index, divisor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetInternalformativ(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, int* @params);
        private readonly GLGetInternalformativ glGetInternalformativ;

        public unsafe void GetInternalformativ(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, int* @params) =>
            this.glGetInternalformativ.Invoke(target, internalformat, pname, count, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetInternalformati64v(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, long* @params);
        private readonly GLGetInternalformati64v glGetInternalformati64v;

        public unsafe void GetInternalformati64v(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int count, long* @params) =>
            this.glGetInternalformati64v.Invoke(target, internalformat, pname, count, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLInvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth);
        private readonly GLInvalidateTexSubImage glInvalidateTexSubImage;

        public void InvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth) =>
            this.glInvalidateTexSubImage.Invoke(texture, level, xoffset, yoffset, zoffset, width, height, depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLInvalidateTexImage(uint texture, int level);
        private readonly GLInvalidateTexImage glInvalidateTexImage;

        public void InvalidateTexImage(uint texture, int level) =>
            this.glInvalidateTexImage.Invoke(texture, level);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLInvalidateBufferSubData(uint buffer, nint offset, nint length);
        private readonly GLInvalidateBufferSubData glInvalidateBufferSubData;

        public void InvalidateBufferSubData(uint buffer, nint offset, nint length) =>
            this.glInvalidateBufferSubData.Invoke(buffer, offset, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLInvalidateBufferData(uint buffer);
        private readonly GLInvalidateBufferData glInvalidateBufferData;

        public void InvalidateBufferData(uint buffer) =>
            this.glInvalidateBufferData.Invoke(buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLInvalidateFramebuffer(FramebufferTarget target, int numAttachments, /*const*/ InvalidateFramebufferAttachment* attachments);
        private readonly GLInvalidateFramebuffer glInvalidateFramebuffer;

        public unsafe void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, /*const*/ InvalidateFramebufferAttachment* attachments) =>
            this.glInvalidateFramebuffer.Invoke(target, numAttachments, attachments);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLInvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, /*const*/ InvalidateFramebufferAttachment* attachments, int x, int y, int width, int height);
        private readonly GLInvalidateSubFramebuffer glInvalidateSubFramebuffer;

        public unsafe void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, /*const*/ InvalidateFramebufferAttachment* attachments, int x, int y, int width, int height) =>
            this.glInvalidateSubFramebuffer.Invoke(target, numAttachments, attachments, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapBufferRange(BufferTargetARB target, nint offset, nint length, MapBufferAccessMask access);
        private readonly GLMapBufferRange glMapBufferRange;

        public nint MapBufferRange(BufferTargetARB target, nint offset, nint length, MapBufferAccessMask access) =>
            this.glMapBufferRange.Invoke(target, offset, length, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFlushMappedBufferRange(BufferTargetARB target, nint offset, nint length);
        private readonly GLFlushMappedBufferRange glFlushMappedBufferRange;

        public void FlushMappedBufferRange(BufferTargetARB target, nint offset, nint length) =>
            this.glFlushMappedBufferRange.Invoke(target, offset, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCurrentPaletteMatrixARB(int index);
        private readonly GLCurrentPaletteMatrixARB glCurrentPaletteMatrixARB;

        [GLExtension("GL_ARB_matrix_palette")]
        public void CurrentPaletteMatrixARB(int index) =>
            this.glCurrentPaletteMatrixARB.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMatrixIndexubvARB(int size, /*const*/ byte* indices);
        private readonly GLMatrixIndexubvARB glMatrixIndexubvARB;

        [GLExtension("GL_ARB_matrix_palette")]
        public unsafe void MatrixIndexubvARB(int size, /*const*/ byte* indices) =>
            this.glMatrixIndexubvARB.Invoke(size, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMatrixIndexusvARB(int size, /*const*/ ushort* indices);
        private readonly GLMatrixIndexusvARB glMatrixIndexusvARB;

        [GLExtension("GL_ARB_matrix_palette")]
        public unsafe void MatrixIndexusvARB(int size, /*const*/ ushort* indices) =>
            this.glMatrixIndexusvARB.Invoke(size, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMatrixIndexuivARB(int size, /*const*/ uint* indices);
        private readonly GLMatrixIndexuivARB glMatrixIndexuivARB;

        [GLExtension("GL_ARB_matrix_palette")]
        public unsafe void MatrixIndexuivARB(int size, /*const*/ uint* indices) =>
            this.glMatrixIndexuivARB.Invoke(size, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMatrixIndexPointerARB(int size, MatrixIndexPointerTypeARB type, int stride, nint pointer);
        private readonly GLMatrixIndexPointerARB glMatrixIndexPointerARB;

        [GLExtension("GL_ARB_matrix_palette")]
        public void MatrixIndexPointerARB(int size, MatrixIndexPointerTypeARB type, int stride, nint pointer) =>
            this.glMatrixIndexPointerARB.Invoke(size, type, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindBuffersBase(BufferTargetARB target, uint first, int count, /*const*/ uint* buffers);
        private readonly GLBindBuffersBase glBindBuffersBase;

        public unsafe void BindBuffersBase(BufferTargetARB target, uint first, int count, /*const*/ uint* buffers) =>
            this.glBindBuffersBase.Invoke(target, first, count, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindBuffersRange(BufferTargetARB target, uint first, int count, /*const*/ uint* buffers, nint offsets, nint sizes);
        private readonly GLBindBuffersRange glBindBuffersRange;

        public unsafe void BindBuffersRange(BufferTargetARB target, uint first, int count, /*const*/ uint* buffers, nint offsets, nint sizes) =>
            this.glBindBuffersRange.Invoke(target, first, count, buffers, offsets, sizes);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindTextures(uint first, int count, /*const*/ uint* textures);
        private readonly GLBindTextures glBindTextures;

        public unsafe void BindTextures(uint first, int count, /*const*/ uint* textures) =>
            this.glBindTextures.Invoke(first, count, textures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindSamplers(uint first, int count, /*const*/ uint* samplers);
        private readonly GLBindSamplers glBindSamplers;

        public unsafe void BindSamplers(uint first, int count, /*const*/ uint* samplers) =>
            this.glBindSamplers.Invoke(first, count, samplers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindImageTextures(uint first, int count, /*const*/ uint* textures);
        private readonly GLBindImageTextures glBindImageTextures;

        public unsafe void BindImageTextures(uint first, int count, /*const*/ uint* textures) =>
            this.glBindImageTextures.Invoke(first, count, textures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindVertexBuffers(uint first, int count, /*const*/ uint* buffers, nint offsets, /*const*/ int* strides);
        private readonly GLBindVertexBuffers glBindVertexBuffers;

        public unsafe void BindVertexBuffers(uint first, int count, /*const*/ uint* buffers, nint offsets, /*const*/ int* strides) =>
            this.glBindVertexBuffers.Invoke(first, count, buffers, offsets, strides);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawArraysIndirect(PrimitiveType mode, nint indirect, int drawcount, int stride);
        private readonly GLMultiDrawArraysIndirect glMultiDrawArraysIndirect;

        public void MultiDrawArraysIndirect(PrimitiveType mode, nint indirect, int drawcount, int stride) =>
            this.glMultiDrawArraysIndirect.Invoke(mode, indirect, drawcount, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawElementsIndirect(PrimitiveType mode, DrawElementsType type, nint indirect, int drawcount, int stride);
        private readonly GLMultiDrawElementsIndirect glMultiDrawElementsIndirect;

        public void MultiDrawElementsIndirect(PrimitiveType mode, DrawElementsType type, nint indirect, int drawcount, int stride) =>
            this.glMultiDrawElementsIndirect.Invoke(mode, type, indirect, drawcount, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSampleCoverageARB(float value, bool invert);
        private readonly GLSampleCoverageARB glSampleCoverageARB;

        [GLExtension("GL_ARB_multisample")]
        public void SampleCoverageARB(float value, bool invert) =>
            this.glSampleCoverageARB.Invoke(value, invert);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLActiveTextureARB(TextureUnit texture);
        private readonly GLActiveTextureARB glActiveTextureARB;

        [GLExtension("GL_ARB_multitexture")]
        public void ActiveTextureARB(TextureUnit texture) =>
            this.glActiveTextureARB.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClientActiveTextureARB(TextureUnit texture);
        private readonly GLClientActiveTextureARB glClientActiveTextureARB;

        [GLExtension("GL_ARB_multitexture")]
        public void ClientActiveTextureARB(TextureUnit texture) =>
            this.glClientActiveTextureARB.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord1dARB(TextureUnit target, double s);
        private readonly GLMultiTexCoord1dARB glMultiTexCoord1dARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord1dARB(TextureUnit target, double s) =>
            this.glMultiTexCoord1dARB.Invoke(target, s);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord1dvARB(TextureUnit target, /*const*/ double* v);
        private readonly GLMultiTexCoord1dvARB glMultiTexCoord1dvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord1dvARB(TextureUnit target, /*const*/ double* v) =>
            this.glMultiTexCoord1dvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord1fARB(TextureUnit target, float s);
        private readonly GLMultiTexCoord1fARB glMultiTexCoord1fARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord1fARB(TextureUnit target, float s) =>
            this.glMultiTexCoord1fARB.Invoke(target, s);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord1fvARB(TextureUnit target, /*const*/ float* v);
        private readonly GLMultiTexCoord1fvARB glMultiTexCoord1fvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord1fvARB(TextureUnit target, /*const*/ float* v) =>
            this.glMultiTexCoord1fvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord1iARB(TextureUnit target, int s);
        private readonly GLMultiTexCoord1iARB glMultiTexCoord1iARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord1iARB(TextureUnit target, int s) =>
            this.glMultiTexCoord1iARB.Invoke(target, s);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord1ivARB(TextureUnit target, /*const*/ int* v);
        private readonly GLMultiTexCoord1ivARB glMultiTexCoord1ivARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord1ivARB(TextureUnit target, /*const*/ int* v) =>
            this.glMultiTexCoord1ivARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord1sARB(TextureUnit target, short s);
        private readonly GLMultiTexCoord1sARB glMultiTexCoord1sARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord1sARB(TextureUnit target, short s) =>
            this.glMultiTexCoord1sARB.Invoke(target, s);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord1svARB(TextureUnit target, /*const*/ short* v);
        private readonly GLMultiTexCoord1svARB glMultiTexCoord1svARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord1svARB(TextureUnit target, /*const*/ short* v) =>
            this.glMultiTexCoord1svARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord2dARB(TextureUnit target, double s, double t);
        private readonly GLMultiTexCoord2dARB glMultiTexCoord2dARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord2dARB(TextureUnit target, double s, double t) =>
            this.glMultiTexCoord2dARB.Invoke(target, s, t);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord2dvARB(TextureUnit target, /*const*/ double* v);
        private readonly GLMultiTexCoord2dvARB glMultiTexCoord2dvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord2dvARB(TextureUnit target, /*const*/ double* v) =>
            this.glMultiTexCoord2dvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord2fARB(TextureUnit target, float s, float t);
        private readonly GLMultiTexCoord2fARB glMultiTexCoord2fARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord2fARB(TextureUnit target, float s, float t) =>
            this.glMultiTexCoord2fARB.Invoke(target, s, t);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord2fvARB(TextureUnit target, /*const*/ float* v);
        private readonly GLMultiTexCoord2fvARB glMultiTexCoord2fvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord2fvARB(TextureUnit target, /*const*/ float* v) =>
            this.glMultiTexCoord2fvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord2iARB(TextureUnit target, int s, int t);
        private readonly GLMultiTexCoord2iARB glMultiTexCoord2iARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord2iARB(TextureUnit target, int s, int t) =>
            this.glMultiTexCoord2iARB.Invoke(target, s, t);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord2ivARB(TextureUnit target, /*const*/ int* v);
        private readonly GLMultiTexCoord2ivARB glMultiTexCoord2ivARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord2ivARB(TextureUnit target, /*const*/ int* v) =>
            this.glMultiTexCoord2ivARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord2sARB(TextureUnit target, short s, short t);
        private readonly GLMultiTexCoord2sARB glMultiTexCoord2sARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord2sARB(TextureUnit target, short s, short t) =>
            this.glMultiTexCoord2sARB.Invoke(target, s, t);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord2svARB(TextureUnit target, /*const*/ short* v);
        private readonly GLMultiTexCoord2svARB glMultiTexCoord2svARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord2svARB(TextureUnit target, /*const*/ short* v) =>
            this.glMultiTexCoord2svARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord3dARB(TextureUnit target, double s, double t, double r);
        private readonly GLMultiTexCoord3dARB glMultiTexCoord3dARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord3dARB(TextureUnit target, double s, double t, double r) =>
            this.glMultiTexCoord3dARB.Invoke(target, s, t, r);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord3dvARB(TextureUnit target, /*const*/ double* v);
        private readonly GLMultiTexCoord3dvARB glMultiTexCoord3dvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord3dvARB(TextureUnit target, /*const*/ double* v) =>
            this.glMultiTexCoord3dvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord3fARB(TextureUnit target, float s, float t, float r);
        private readonly GLMultiTexCoord3fARB glMultiTexCoord3fARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord3fARB(TextureUnit target, float s, float t, float r) =>
            this.glMultiTexCoord3fARB.Invoke(target, s, t, r);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord3fvARB(TextureUnit target, /*const*/ float* v);
        private readonly GLMultiTexCoord3fvARB glMultiTexCoord3fvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord3fvARB(TextureUnit target, /*const*/ float* v) =>
            this.glMultiTexCoord3fvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord3iARB(TextureUnit target, int s, int t, int r);
        private readonly GLMultiTexCoord3iARB glMultiTexCoord3iARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord3iARB(TextureUnit target, int s, int t, int r) =>
            this.glMultiTexCoord3iARB.Invoke(target, s, t, r);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord3ivARB(TextureUnit target, /*const*/ int* v);
        private readonly GLMultiTexCoord3ivARB glMultiTexCoord3ivARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord3ivARB(TextureUnit target, /*const*/ int* v) =>
            this.glMultiTexCoord3ivARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord3sARB(TextureUnit target, short s, short t, short r);
        private readonly GLMultiTexCoord3sARB glMultiTexCoord3sARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord3sARB(TextureUnit target, short s, short t, short r) =>
            this.glMultiTexCoord3sARB.Invoke(target, s, t, r);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord3svARB(TextureUnit target, /*const*/ short* v);
        private readonly GLMultiTexCoord3svARB glMultiTexCoord3svARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord3svARB(TextureUnit target, /*const*/ short* v) =>
            this.glMultiTexCoord3svARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord4dARB(TextureUnit target, double s, double t, double r, double q);
        private readonly GLMultiTexCoord4dARB glMultiTexCoord4dARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord4dARB(TextureUnit target, double s, double t, double r, double q) =>
            this.glMultiTexCoord4dARB.Invoke(target, s, t, r, q);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord4dvARB(TextureUnit target, /*const*/ double* v);
        private readonly GLMultiTexCoord4dvARB glMultiTexCoord4dvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord4dvARB(TextureUnit target, /*const*/ double* v) =>
            this.glMultiTexCoord4dvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord4fARB(TextureUnit target, float s, float t, float r, float q);
        private readonly GLMultiTexCoord4fARB glMultiTexCoord4fARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord4fARB(TextureUnit target, float s, float t, float r, float q) =>
            this.glMultiTexCoord4fARB.Invoke(target, s, t, r, q);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord4fvARB(TextureUnit target, /*const*/ float* v);
        private readonly GLMultiTexCoord4fvARB glMultiTexCoord4fvARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord4fvARB(TextureUnit target, /*const*/ float* v) =>
            this.glMultiTexCoord4fvARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord4iARB(TextureUnit target, int s, int t, int r, int q);
        private readonly GLMultiTexCoord4iARB glMultiTexCoord4iARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord4iARB(TextureUnit target, int s, int t, int r, int q) =>
            this.glMultiTexCoord4iARB.Invoke(target, s, t, r, q);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord4ivARB(TextureUnit target, /*const*/ int* v);
        private readonly GLMultiTexCoord4ivARB glMultiTexCoord4ivARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord4ivARB(TextureUnit target, /*const*/ int* v) =>
            this.glMultiTexCoord4ivARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiTexCoord4sARB(TextureUnit target, short s, short t, short r, short q);
        private readonly GLMultiTexCoord4sARB glMultiTexCoord4sARB;

        [GLExtension("GL_ARB_multitexture")]
        public void MultiTexCoord4sARB(TextureUnit target, short s, short t, short r, short q) =>
            this.glMultiTexCoord4sARB.Invoke(target, s, t, r, q);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiTexCoord4svARB(TextureUnit target, /*const*/ short* v);
        private readonly GLMultiTexCoord4svARB glMultiTexCoord4svARB;

        [GLExtension("GL_ARB_multitexture")]
        public unsafe void MultiTexCoord4svARB(TextureUnit target, /*const*/ short* v) =>
            this.glMultiTexCoord4svARB.Invoke(target, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenQueriesARB(int n, uint* ids);
        private readonly GLGenQueriesARB glGenQueriesARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public unsafe void GenQueriesARB(int n, uint* ids) =>
            this.glGenQueriesARB.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteQueriesARB(int n, /*const*/ uint* ids);
        private readonly GLDeleteQueriesARB glDeleteQueriesARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public unsafe void DeleteQueriesARB(int n, /*const*/ uint* ids) =>
            this.glDeleteQueriesARB.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsQueryARB(uint id);
        private readonly GLIsQueryARB glIsQueryARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public bool IsQueryARB(uint id) =>
            this.glIsQueryARB.Invoke(id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginQueryARB(QueryTarget target, uint id);
        private readonly GLBeginQueryARB glBeginQueryARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public void BeginQueryARB(QueryTarget target, uint id) =>
            this.glBeginQueryARB.Invoke(target, id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndQueryARB(QueryTarget target);
        private readonly GLEndQueryARB glEndQueryARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public void EndQueryARB(QueryTarget target) =>
            this.glEndQueryARB.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryivARB(QueryTarget target, QueryParameterName pname, int* @params);
        private readonly GLGetQueryivARB glGetQueryivARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public unsafe void GetQueryivARB(QueryTarget target, QueryParameterName pname, int* @params) =>
            this.glGetQueryivARB.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjectivARB(uint id, QueryObjectParameterName pname, int* @params);
        private readonly GLGetQueryObjectivARB glGetQueryObjectivARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public unsafe void GetQueryObjectivARB(uint id, QueryObjectParameterName pname, int* @params) =>
            this.glGetQueryObjectivARB.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjectuivARB(uint id, QueryObjectParameterName pname, uint* @params);
        private readonly GLGetQueryObjectuivARB glGetQueryObjectuivARB;

        [GLExtension("GL_ARB_occlusion_query")]
        public unsafe void GetQueryObjectuivARB(uint id, QueryObjectParameterName pname, uint* @params) =>
            this.glGetQueryObjectuivARB.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMaxShaderCompilerThreadsARB(uint count);
        private readonly GLMaxShaderCompilerThreadsARB glMaxShaderCompilerThreadsARB;

        [GLExtension("GL_ARB_parallel_shader_compile")]
        public void MaxShaderCompilerThreadsARB(uint count) =>
            this.glMaxShaderCompilerThreadsARB.Invoke(count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameterfARB(PointParameterNameARB pname, float param);
        private readonly GLPointParameterfARB glPointParameterfARB;

        [GLExtension("GL_ARB_point_parameters")]
        public void PointParameterfARB(PointParameterNameARB pname, float param) =>
            this.glPointParameterfARB.Invoke(pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPointParameterfvARB(PointParameterNameARB pname, /*const*/ float* @params);
        private readonly GLPointParameterfvARB glPointParameterfvARB;

        [GLExtension("GL_ARB_point_parameters")]
        public unsafe void PointParameterfvARB(PointParameterNameARB pname, /*const*/ float* @params) =>
            this.glPointParameterfvARB.Invoke(pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPolygonOffsetClamp(float factor, float units, float clamp);
        private readonly GLPolygonOffsetClamp glPolygonOffsetClamp;

        public void PolygonOffsetClamp(float factor, float units, float clamp) =>
            this.glPolygonOffsetClamp.Invoke(factor, units, clamp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramInterfaceiv(uint program, ProgramInterface programInterface, ProgramInterfacePName pname, int* @params);
        private readonly GLGetProgramInterfaceiv glGetProgramInterfaceiv;

        public unsafe void GetProgramInterfaceiv(uint program, ProgramInterface programInterface, ProgramInterfacePName pname, int* @params) =>
            this.glGetProgramInterfaceiv.Invoke(program, programInterface, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetProgramResourceIndex(uint program, ProgramInterface programInterface, /*const*/ sbyte* name);
        private readonly GLGetProgramResourceIndex glGetProgramResourceIndex;

        public unsafe uint GetProgramResourceIndex(uint program, ProgramInterface programInterface, /*const*/ sbyte* name) =>
            this.glGetProgramResourceIndex.Invoke(program, programInterface, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramResourceName(uint program, ProgramInterface programInterface, uint index, int bufSize, int* length, sbyte* name);
        private readonly GLGetProgramResourceName glGetProgramResourceName;

        public unsafe void GetProgramResourceName(uint program, ProgramInterface programInterface, uint index, int bufSize, int* length, sbyte* name) =>
            this.glGetProgramResourceName.Invoke(program, programInterface, index, bufSize, length, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramResourceiv(uint program, ProgramInterface programInterface, uint index, int propCount, /*const*/ ProgramResourceProperty* props, int count, int* length, int* @params);
        private readonly GLGetProgramResourceiv glGetProgramResourceiv;

        public unsafe void GetProgramResourceiv(uint program, ProgramInterface programInterface, uint index, int propCount, /*const*/ ProgramResourceProperty* props, int count, int* length, int* @params) =>
            this.glGetProgramResourceiv.Invoke(program, programInterface, index, propCount, props, count, length, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetProgramResourceLocation(uint program, ProgramInterface programInterface, /*const*/ sbyte* name);
        private readonly GLGetProgramResourceLocation glGetProgramResourceLocation;

        public unsafe int GetProgramResourceLocation(uint program, ProgramInterface programInterface, /*const*/ sbyte* name) =>
            this.glGetProgramResourceLocation.Invoke(program, programInterface, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetProgramResourceLocationIndex(uint program, ProgramInterface programInterface, /*const*/ sbyte* name);
        private readonly GLGetProgramResourceLocationIndex glGetProgramResourceLocationIndex;

        public unsafe int GetProgramResourceLocationIndex(uint program, ProgramInterface programInterface, /*const*/ sbyte* name) =>
            this.glGetProgramResourceLocationIndex.Invoke(program, programInterface, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProvokingVertex(VertexProvokingMode mode);
        private readonly GLProvokingVertex glProvokingVertex;

        public void ProvokingVertex(VertexProvokingMode mode) =>
            this.glProvokingVertex.Invoke(mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus GLGetGraphicsResetStatusARB();
        private readonly GLGetGraphicsResetStatusARB glGetGraphicsResetStatusARB;

        [GLExtension("GL_ARB_robustness")]
        public GraphicsResetStatus GetGraphicsResetStatusARB() =>
            this.glGetGraphicsResetStatusARB.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnTexImageARB(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, out nint img);
        private readonly GLGetnTexImageARB glGetnTexImageARB;

        [GLExtension("GL_ARB_robustness")]
        public void GetnTexImageARB(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, out nint img) =>
            this.glGetnTexImageARB.Invoke(target, level, format, type, bufSize, out img);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadnPixelsARB(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data);
        private readonly GLReadnPixelsARB glReadnPixelsARB;

        [GLExtension("GL_ARB_robustness")]
        public void ReadnPixelsARB(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data) =>
            this.glReadnPixelsARB.Invoke(x, y, width, height, format, type, bufSize, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnCompressedTexImageARB(TextureTarget target, int lod, int bufSize, out nint img);
        private readonly GLGetnCompressedTexImageARB glGetnCompressedTexImageARB;

        [GLExtension("GL_ARB_robustness")]
        public void GetnCompressedTexImageARB(TextureTarget target, int lod, int bufSize, out nint img) =>
            this.glGetnCompressedTexImageARB.Invoke(target, lod, bufSize, out img);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformfvARB(uint program, int location, int bufSize, float* @params);
        private readonly GLGetnUniformfvARB glGetnUniformfvARB;

        [GLExtension("GL_ARB_robustness")]
        public unsafe void GetnUniformfvARB(uint program, int location, int bufSize, float* @params) =>
            this.glGetnUniformfvARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformivARB(uint program, int location, int bufSize, int* @params);
        private readonly GLGetnUniformivARB glGetnUniformivARB;

        [GLExtension("GL_ARB_robustness")]
        public unsafe void GetnUniformivARB(uint program, int location, int bufSize, int* @params) =>
            this.glGetnUniformivARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformuivARB(uint program, int location, int bufSize, uint* @params);
        private readonly GLGetnUniformuivARB glGetnUniformuivARB;

        [GLExtension("GL_ARB_robustness")]
        public unsafe void GetnUniformuivARB(uint program, int location, int bufSize, uint* @params) =>
            this.glGetnUniformuivARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformdvARB(uint program, int location, int bufSize, double* @params);
        private readonly GLGetnUniformdvARB glGetnUniformdvARB;

        [GLExtension("GL_ARB_robustness")]
        public unsafe void GetnUniformdvARB(uint program, int location, int bufSize, double* @params) =>
            this.glGetnUniformdvARB.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLFramebufferSampleLocationsfvARB(FramebufferTarget target, uint start, int count, /*const*/ float* v);
        private readonly GLFramebufferSampleLocationsfvARB glFramebufferSampleLocationsfvARB;

        [GLExtension("GL_ARB_sample_locations")]
        public unsafe void FramebufferSampleLocationsfvARB(FramebufferTarget target, uint start, int count, /*const*/ float* v) =>
            this.glFramebufferSampleLocationsfvARB.Invoke(target, start, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLNamedFramebufferSampleLocationsfvARB(uint framebuffer, uint start, int count, /*const*/ float* v);
        private readonly GLNamedFramebufferSampleLocationsfvARB glNamedFramebufferSampleLocationsfvARB;

        [GLExtension("GL_ARB_sample_locations")]
        public unsafe void NamedFramebufferSampleLocationsfvARB(uint framebuffer, uint start, int count, /*const*/ float* v) =>
            this.glNamedFramebufferSampleLocationsfvARB.Invoke(framebuffer, start, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEvaluateDepthValuesARB();
        private readonly GLEvaluateDepthValuesARB glEvaluateDepthValuesARB;

        [GLExtension("GL_ARB_sample_locations")]
        public void EvaluateDepthValuesARB() =>
            this.glEvaluateDepthValuesARB.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMinSampleShadingARB(float value);
        private readonly GLMinSampleShadingARB glMinSampleShadingARB;

        [GLExtension("GL_ARB_sample_shading")]
        public void MinSampleShadingARB(float value) =>
            this.glMinSampleShadingARB.Invoke(value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenSamplers(int count, uint* samplers);
        private readonly GLGenSamplers glGenSamplers;

        public unsafe void GenSamplers(int count, uint* samplers) =>
            this.glGenSamplers.Invoke(count, samplers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteSamplers(int count, /*const*/ uint* samplers);
        private readonly GLDeleteSamplers glDeleteSamplers;

        public unsafe void DeleteSamplers(int count, /*const*/ uint* samplers) =>
            this.glDeleteSamplers.Invoke(count, samplers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsSampler(uint sampler);
        private readonly GLIsSampler glIsSampler;

        public bool IsSampler(uint sampler) =>
            this.glIsSampler.Invoke(sampler);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindSampler(uint unit, uint sampler);
        private readonly GLBindSampler glBindSampler;

        public void BindSampler(uint unit, uint sampler) =>
            this.glBindSampler.Invoke(unit, sampler);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSamplerParameteri(uint sampler, SamplerParameterI pname, int param);
        private readonly GLSamplerParameteri glSamplerParameteri;

        public void SamplerParameteri(uint sampler, SamplerParameterI pname, int param) =>
            this.glSamplerParameteri.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLSamplerParameteriv(uint sampler, SamplerParameterI pname, /*const*/ int* param);
        private readonly GLSamplerParameteriv glSamplerParameteriv;

        public unsafe void SamplerParameteriv(uint sampler, SamplerParameterI pname, /*const*/ int* param) =>
            this.glSamplerParameteriv.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSamplerParameterf(uint sampler, SamplerParameterF pname, float param);
        private readonly GLSamplerParameterf glSamplerParameterf;

        public void SamplerParameterf(uint sampler, SamplerParameterF pname, float param) =>
            this.glSamplerParameterf.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLSamplerParameterfv(uint sampler, SamplerParameterF pname, /*const*/ float* param);
        private readonly GLSamplerParameterfv glSamplerParameterfv;

        public unsafe void SamplerParameterfv(uint sampler, SamplerParameterF pname, /*const*/ float* param) =>
            this.glSamplerParameterfv.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLSamplerParameterIiv(uint sampler, SamplerParameterI pname, /*const*/ int* param);
        private readonly GLSamplerParameterIiv glSamplerParameterIiv;

        public unsafe void SamplerParameterIiv(uint sampler, SamplerParameterI pname, /*const*/ int* param) =>
            this.glSamplerParameterIiv.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLSamplerParameterIuiv(uint sampler, SamplerParameterI pname, /*const*/ uint* param);
        private readonly GLSamplerParameterIuiv glSamplerParameterIuiv;

        public unsafe void SamplerParameterIuiv(uint sampler, SamplerParameterI pname, /*const*/ uint* param) =>
            this.glSamplerParameterIuiv.Invoke(sampler, pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetSamplerParameteriv(uint sampler, SamplerParameterI pname, int* @params);
        private readonly GLGetSamplerParameteriv glGetSamplerParameteriv;

        public unsafe void GetSamplerParameteriv(uint sampler, SamplerParameterI pname, int* @params) =>
            this.glGetSamplerParameteriv.Invoke(sampler, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetSamplerParameterIiv(uint sampler, SamplerParameterI pname, int* @params);
        private readonly GLGetSamplerParameterIiv glGetSamplerParameterIiv;

        public unsafe void GetSamplerParameterIiv(uint sampler, SamplerParameterI pname, int* @params) =>
            this.glGetSamplerParameterIiv.Invoke(sampler, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetSamplerParameterfv(uint sampler, SamplerParameterF pname, float* @params);
        private readonly GLGetSamplerParameterfv glGetSamplerParameterfv;

        public unsafe void GetSamplerParameterfv(uint sampler, SamplerParameterF pname, float* @params) =>
            this.glGetSamplerParameterfv.Invoke(sampler, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetSamplerParameterIuiv(uint sampler, SamplerParameterI pname, uint* @params);
        private readonly GLGetSamplerParameterIuiv glGetSamplerParameterIuiv;

        public unsafe void GetSamplerParameterIuiv(uint sampler, SamplerParameterI pname, uint* @params) =>
            this.glGetSamplerParameterIuiv.Invoke(sampler, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUseProgramStages(uint pipeline, UseProgramStageMask stages, uint program);
        private readonly GLUseProgramStages glUseProgramStages;

        public void UseProgramStages(uint pipeline, UseProgramStageMask stages, uint program) =>
            this.glUseProgramStages.Invoke(pipeline, stages, program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLActiveShaderProgram(uint pipeline, uint program);
        private readonly GLActiveShaderProgram glActiveShaderProgram;

        public void ActiveShaderProgram(uint pipeline, uint program) =>
            this.glActiveShaderProgram.Invoke(pipeline, program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLCreateShaderProgramv(ShaderType type, int count, sbyte strings);
        private readonly GLCreateShaderProgramv glCreateShaderProgramv;

        public unsafe uint CreateShaderProgramv(ShaderType type, int count, sbyte strings) =>
            this.glCreateShaderProgramv.Invoke(type, count, strings);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindProgramPipeline(uint pipeline);
        private readonly GLBindProgramPipeline glBindProgramPipeline;

        public void BindProgramPipeline(uint pipeline) =>
            this.glBindProgramPipeline.Invoke(pipeline);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteProgramPipelines(int n, /*const*/ uint* pipelines);
        private readonly GLDeleteProgramPipelines glDeleteProgramPipelines;

        public unsafe void DeleteProgramPipelines(int n, /*const*/ uint* pipelines) =>
            this.glDeleteProgramPipelines.Invoke(n, pipelines);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenProgramPipelines(int n, uint* pipelines);
        private readonly GLGenProgramPipelines glGenProgramPipelines;

        public unsafe void GenProgramPipelines(int n, uint* pipelines) =>
            this.glGenProgramPipelines.Invoke(n, pipelines);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsProgramPipeline(uint pipeline);
        private readonly GLIsProgramPipeline glIsProgramPipeline;

        public bool IsProgramPipeline(uint pipeline) =>
            this.glIsProgramPipeline.Invoke(pipeline);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramPipelineiv(uint pipeline, PipelineParameterName pname, int* @params);
        private readonly GLGetProgramPipelineiv glGetProgramPipelineiv;

        public unsafe void GetProgramPipelineiv(uint pipeline, PipelineParameterName pname, int* @params) =>
            this.glGetProgramPipelineiv.Invoke(pipeline, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1i(uint program, int location, int v0);
        private readonly GLProgramUniform1i glProgramUniform1i;

        public void ProgramUniform1i(uint program, int location, int v0) =>
            this.glProgramUniform1i.Invoke(program, location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1iv(uint program, int location, int count, /*const*/ int* value);
        private readonly GLProgramUniform1iv glProgramUniform1iv;

        public unsafe void ProgramUniform1iv(uint program, int location, int count, /*const*/ int* value) =>
            this.glProgramUniform1iv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1f(uint program, int location, float v0);
        private readonly GLProgramUniform1f glProgramUniform1f;

        public void ProgramUniform1f(uint program, int location, float v0) =>
            this.glProgramUniform1f.Invoke(program, location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1fv(uint program, int location, int count, /*const*/ float* value);
        private readonly GLProgramUniform1fv glProgramUniform1fv;

        public unsafe void ProgramUniform1fv(uint program, int location, int count, /*const*/ float* value) =>
            this.glProgramUniform1fv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1d(uint program, int location, double v0);
        private readonly GLProgramUniform1d glProgramUniform1d;

        public void ProgramUniform1d(uint program, int location, double v0) =>
            this.glProgramUniform1d.Invoke(program, location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1dv(uint program, int location, int count, /*const*/ double* value);
        private readonly GLProgramUniform1dv glProgramUniform1dv;

        public unsafe void ProgramUniform1dv(uint program, int location, int count, /*const*/ double* value) =>
            this.glProgramUniform1dv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform1ui(uint program, int location, uint v0);
        private readonly GLProgramUniform1ui glProgramUniform1ui;

        public void ProgramUniform1ui(uint program, int location, uint v0) =>
            this.glProgramUniform1ui.Invoke(program, location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform1uiv(uint program, int location, int count, /*const*/ uint* value);
        private readonly GLProgramUniform1uiv glProgramUniform1uiv;

        public unsafe void ProgramUniform1uiv(uint program, int location, int count, /*const*/ uint* value) =>
            this.glProgramUniform1uiv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2i(uint program, int location, int v0, int v1);
        private readonly GLProgramUniform2i glProgramUniform2i;

        public void ProgramUniform2i(uint program, int location, int v0, int v1) =>
            this.glProgramUniform2i.Invoke(program, location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2iv(uint program, int location, int count, /*const*/ int* value);
        private readonly GLProgramUniform2iv glProgramUniform2iv;

        public unsafe void ProgramUniform2iv(uint program, int location, int count, /*const*/ int* value) =>
            this.glProgramUniform2iv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2f(uint program, int location, float v0, float v1);
        private readonly GLProgramUniform2f glProgramUniform2f;

        public void ProgramUniform2f(uint program, int location, float v0, float v1) =>
            this.glProgramUniform2f.Invoke(program, location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2fv(uint program, int location, int count, /*const*/ float* value);
        private readonly GLProgramUniform2fv glProgramUniform2fv;

        public unsafe void ProgramUniform2fv(uint program, int location, int count, /*const*/ float* value) =>
            this.glProgramUniform2fv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2d(uint program, int location, double v0, double v1);
        private readonly GLProgramUniform2d glProgramUniform2d;

        public void ProgramUniform2d(uint program, int location, double v0, double v1) =>
            this.glProgramUniform2d.Invoke(program, location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2dv(uint program, int location, int count, /*const*/ double* value);
        private readonly GLProgramUniform2dv glProgramUniform2dv;

        public unsafe void ProgramUniform2dv(uint program, int location, int count, /*const*/ double* value) =>
            this.glProgramUniform2dv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform2ui(uint program, int location, uint v0, uint v1);
        private readonly GLProgramUniform2ui glProgramUniform2ui;

        public void ProgramUniform2ui(uint program, int location, uint v0, uint v1) =>
            this.glProgramUniform2ui.Invoke(program, location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform2uiv(uint program, int location, int count, /*const*/ uint* value);
        private readonly GLProgramUniform2uiv glProgramUniform2uiv;

        public unsafe void ProgramUniform2uiv(uint program, int location, int count, /*const*/ uint* value) =>
            this.glProgramUniform2uiv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3i(uint program, int location, int v0, int v1, int v2);
        private readonly GLProgramUniform3i glProgramUniform3i;

        public void ProgramUniform3i(uint program, int location, int v0, int v1, int v2) =>
            this.glProgramUniform3i.Invoke(program, location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3iv(uint program, int location, int count, /*const*/ int* value);
        private readonly GLProgramUniform3iv glProgramUniform3iv;

        public unsafe void ProgramUniform3iv(uint program, int location, int count, /*const*/ int* value) =>
            this.glProgramUniform3iv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3f(uint program, int location, float v0, float v1, float v2);
        private readonly GLProgramUniform3f glProgramUniform3f;

        public void ProgramUniform3f(uint program, int location, float v0, float v1, float v2) =>
            this.glProgramUniform3f.Invoke(program, location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3fv(uint program, int location, int count, /*const*/ float* value);
        private readonly GLProgramUniform3fv glProgramUniform3fv;

        public unsafe void ProgramUniform3fv(uint program, int location, int count, /*const*/ float* value) =>
            this.glProgramUniform3fv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3d(uint program, int location, double v0, double v1, double v2);
        private readonly GLProgramUniform3d glProgramUniform3d;

        public void ProgramUniform3d(uint program, int location, double v0, double v1, double v2) =>
            this.glProgramUniform3d.Invoke(program, location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3dv(uint program, int location, int count, /*const*/ double* value);
        private readonly GLProgramUniform3dv glProgramUniform3dv;

        public unsafe void ProgramUniform3dv(uint program, int location, int count, /*const*/ double* value) =>
            this.glProgramUniform3dv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform3ui(uint program, int location, uint v0, uint v1, uint v2);
        private readonly GLProgramUniform3ui glProgramUniform3ui;

        public void ProgramUniform3ui(uint program, int location, uint v0, uint v1, uint v2) =>
            this.glProgramUniform3ui.Invoke(program, location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform3uiv(uint program, int location, int count, /*const*/ uint* value);
        private readonly GLProgramUniform3uiv glProgramUniform3uiv;

        public unsafe void ProgramUniform3uiv(uint program, int location, int count, /*const*/ uint* value) =>
            this.glProgramUniform3uiv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4i(uint program, int location, int v0, int v1, int v2, int v3);
        private readonly GLProgramUniform4i glProgramUniform4i;

        public void ProgramUniform4i(uint program, int location, int v0, int v1, int v2, int v3) =>
            this.glProgramUniform4i.Invoke(program, location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4iv(uint program, int location, int count, /*const*/ int* value);
        private readonly GLProgramUniform4iv glProgramUniform4iv;

        public unsafe void ProgramUniform4iv(uint program, int location, int count, /*const*/ int* value) =>
            this.glProgramUniform4iv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4f(uint program, int location, float v0, float v1, float v2, float v3);
        private readonly GLProgramUniform4f glProgramUniform4f;

        public void ProgramUniform4f(uint program, int location, float v0, float v1, float v2, float v3) =>
            this.glProgramUniform4f.Invoke(program, location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4fv(uint program, int location, int count, /*const*/ float* value);
        private readonly GLProgramUniform4fv glProgramUniform4fv;

        public unsafe void ProgramUniform4fv(uint program, int location, int count, /*const*/ float* value) =>
            this.glProgramUniform4fv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4d(uint program, int location, double v0, double v1, double v2, double v3);
        private readonly GLProgramUniform4d glProgramUniform4d;

        public void ProgramUniform4d(uint program, int location, double v0, double v1, double v2, double v3) =>
            this.glProgramUniform4d.Invoke(program, location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4dv(uint program, int location, int count, /*const*/ double* value);
        private readonly GLProgramUniform4dv glProgramUniform4dv;

        public unsafe void ProgramUniform4dv(uint program, int location, int count, /*const*/ double* value) =>
            this.glProgramUniform4dv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLProgramUniform4ui(uint program, int location, uint v0, uint v1, uint v2, uint v3);
        private readonly GLProgramUniform4ui glProgramUniform4ui;

        public void ProgramUniform4ui(uint program, int location, uint v0, uint v1, uint v2, uint v3) =>
            this.glProgramUniform4ui.Invoke(program, location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniform4uiv(uint program, int location, int count, /*const*/ uint* value);
        private readonly GLProgramUniform4uiv glProgramUniform4uiv;

        public unsafe void ProgramUniform4uiv(uint program, int location, int count, /*const*/ uint* value) =>
            this.glProgramUniform4uiv.Invoke(program, location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix2fv glProgramUniformMatrix2fv;

        public unsafe void ProgramUniformMatrix2fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix2fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix3fv glProgramUniformMatrix3fv;

        public unsafe void ProgramUniformMatrix3fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix3fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix4fv glProgramUniformMatrix4fv;

        public unsafe void ProgramUniformMatrix4fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix4fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix2dv glProgramUniformMatrix2dv;

        public unsafe void ProgramUniformMatrix2dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix2dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix3dv glProgramUniformMatrix3dv;

        public unsafe void ProgramUniformMatrix3dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix3dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix4dv glProgramUniformMatrix4dv;

        public unsafe void ProgramUniformMatrix4dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix4dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2x3fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix2x3fv glProgramUniformMatrix2x3fv;

        public unsafe void ProgramUniformMatrix2x3fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix2x3fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3x2fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix3x2fv glProgramUniformMatrix3x2fv;

        public unsafe void ProgramUniformMatrix3x2fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix3x2fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2x4fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix2x4fv glProgramUniformMatrix2x4fv;

        public unsafe void ProgramUniformMatrix2x4fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix2x4fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4x2fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix4x2fv glProgramUniformMatrix4x2fv;

        public unsafe void ProgramUniformMatrix4x2fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix4x2fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3x4fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix3x4fv glProgramUniformMatrix3x4fv;

        public unsafe void ProgramUniformMatrix3x4fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix3x4fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4x3fv(uint program, int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLProgramUniformMatrix4x3fv glProgramUniformMatrix4x3fv;

        public unsafe void ProgramUniformMatrix4x3fv(uint program, int location, int count, bool transpose, /*const*/ float* value) =>
            this.glProgramUniformMatrix4x3fv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2x3dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix2x3dv glProgramUniformMatrix2x3dv;

        public unsafe void ProgramUniformMatrix2x3dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix2x3dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3x2dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix3x2dv glProgramUniformMatrix3x2dv;

        public unsafe void ProgramUniformMatrix3x2dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix3x2dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix2x4dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix2x4dv glProgramUniformMatrix2x4dv;

        public unsafe void ProgramUniformMatrix2x4dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix2x4dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4x2dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix4x2dv glProgramUniformMatrix4x2dv;

        public unsafe void ProgramUniformMatrix4x2dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix4x2dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix3x4dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix3x4dv glProgramUniformMatrix3x4dv;

        public unsafe void ProgramUniformMatrix3x4dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix3x4dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLProgramUniformMatrix4x3dv(uint program, int location, int count, bool transpose, /*const*/ double* value);
        private readonly GLProgramUniformMatrix4x3dv glProgramUniformMatrix4x3dv;

        public unsafe void ProgramUniformMatrix4x3dv(uint program, int location, int count, bool transpose, /*const*/ double* value) =>
            this.glProgramUniformMatrix4x3dv.Invoke(program, location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLValidateProgramPipeline(uint pipeline);
        private readonly GLValidateProgramPipeline glValidateProgramPipeline;

        public void ValidateProgramPipeline(uint pipeline) =>
            this.glValidateProgramPipeline.Invoke(pipeline);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramPipelineInfoLog(uint pipeline, int bufSize, int* length, sbyte* infoLog);
        private readonly GLGetProgramPipelineInfoLog glGetProgramPipelineInfoLog;

        public unsafe void GetProgramPipelineInfoLog(uint pipeline, int bufSize, int* length, sbyte* infoLog) =>
            this.glGetProgramPipelineInfoLog.Invoke(pipeline, bufSize, length, infoLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, AtomicCounterBufferPName pname, int* @params);
        private readonly GLGetActiveAtomicCounterBufferiv glGetActiveAtomicCounterBufferiv;

        public unsafe void GetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, AtomicCounterBufferPName pname, int* @params) =>
            this.glGetActiveAtomicCounterBufferiv.Invoke(program, bufferIndex, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindImageTexture(uint unit, uint texture, int level, bool layered, int layer, BufferAccessARB access, InternalFormat format);
        private readonly GLBindImageTexture glBindImageTexture;

        public void BindImageTexture(uint unit, uint texture, int level, bool layered, int layer, BufferAccessARB access, InternalFormat format) =>
            this.glBindImageTexture.Invoke(unit, texture, level, layered, layer, access, format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMemoryBarrier(MemoryBarrierMask barriers);
        private readonly GLMemoryBarrier glMemoryBarrier;

        public void MemoryBarrier(MemoryBarrierMask barriers) =>
            this.glMemoryBarrier.Invoke(barriers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteObjectARB(ushort obj);
        private readonly GLDeleteObjectARB glDeleteObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void DeleteObjectARB(ushort obj) =>
            this.glDeleteObjectARB.Invoke(obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ushort GLGetHandleARB(ContainerType pname);
        private readonly GLGetHandleARB glGetHandleARB;

        [GLExtension("GL_ARB_shader_objects")]
        public ushort GetHandleARB(ContainerType pname) =>
            this.glGetHandleARB.Invoke(pname);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDetachObjectARB(ushort containerObj, ushort attachedObj);
        private readonly GLDetachObjectARB glDetachObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void DetachObjectARB(ushort containerObj, ushort attachedObj) =>
            this.glDetachObjectARB.Invoke(containerObj, attachedObj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ushort GLCreateShaderObjectARB(ShaderType shaderType);
        private readonly GLCreateShaderObjectARB glCreateShaderObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public ushort CreateShaderObjectARB(ShaderType shaderType) =>
            this.glCreateShaderObjectARB.Invoke(shaderType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLShaderSourceARB(ushort shaderObj, int count, /*const*/ sbyte* @string, /*const*/ int* length);
        private readonly GLShaderSourceARB glShaderSourceARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void ShaderSourceARB(ushort shaderObj, int count, /*const*/ sbyte* @string, /*const*/ int* length) =>
            this.glShaderSourceARB.Invoke(shaderObj, count, @string, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompileShaderARB(ushort shaderObj);
        private readonly GLCompileShaderARB glCompileShaderARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void CompileShaderARB(ushort shaderObj) =>
            this.glCompileShaderARB.Invoke(shaderObj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ushort GLCreateProgramObjectARB();
        private readonly GLCreateProgramObjectARB glCreateProgramObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public ushort CreateProgramObjectARB() =>
            this.glCreateProgramObjectARB.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLAttachObjectARB(ushort containerObj, ushort obj);
        private readonly GLAttachObjectARB glAttachObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void AttachObjectARB(ushort containerObj, ushort obj) =>
            this.glAttachObjectARB.Invoke(containerObj, obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLinkProgramARB(ushort programObj);
        private readonly GLLinkProgramARB glLinkProgramARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void LinkProgramARB(ushort programObj) =>
            this.glLinkProgramARB.Invoke(programObj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUseProgramObjectARB(ushort programObj);
        private readonly GLUseProgramObjectARB glUseProgramObjectARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void UseProgramObjectARB(ushort programObj) =>
            this.glUseProgramObjectARB.Invoke(programObj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLValidateProgramARB(ushort programObj);
        private readonly GLValidateProgramARB glValidateProgramARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void ValidateProgramARB(ushort programObj) =>
            this.glValidateProgramARB.Invoke(programObj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1fARB(int location, float v0);
        private readonly GLUniform1fARB glUniform1fARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform1fARB(int location, float v0) =>
            this.glUniform1fARB.Invoke(location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2fARB(int location, float v0, float v1);
        private readonly GLUniform2fARB glUniform2fARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform2fARB(int location, float v0, float v1) =>
            this.glUniform2fARB.Invoke(location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3fARB(int location, float v0, float v1, float v2);
        private readonly GLUniform3fARB glUniform3fARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform3fARB(int location, float v0, float v1, float v2) =>
            this.glUniform3fARB.Invoke(location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4fARB(int location, float v0, float v1, float v2, float v3);
        private readonly GLUniform4fARB glUniform4fARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform4fARB(int location, float v0, float v1, float v2, float v3) =>
            this.glUniform4fARB.Invoke(location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1iARB(int location, int v0);
        private readonly GLUniform1iARB glUniform1iARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform1iARB(int location, int v0) =>
            this.glUniform1iARB.Invoke(location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2iARB(int location, int v0, int v1);
        private readonly GLUniform2iARB glUniform2iARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform2iARB(int location, int v0, int v1) =>
            this.glUniform2iARB.Invoke(location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3iARB(int location, int v0, int v1, int v2);
        private readonly GLUniform3iARB glUniform3iARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform3iARB(int location, int v0, int v1, int v2) =>
            this.glUniform3iARB.Invoke(location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4iARB(int location, int v0, int v1, int v2, int v3);
        private readonly GLUniform4iARB glUniform4iARB;

        [GLExtension("GL_ARB_shader_objects")]
        public void Uniform4iARB(int location, int v0, int v1, int v2, int v3) =>
            this.glUniform4iARB.Invoke(location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1fvARB(int location, int count, /*const*/ float* value);
        private readonly GLUniform1fvARB glUniform1fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform1fvARB(int location, int count, /*const*/ float* value) =>
            this.glUniform1fvARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2fvARB(int location, int count, /*const*/ float* value);
        private readonly GLUniform2fvARB glUniform2fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform2fvARB(int location, int count, /*const*/ float* value) =>
            this.glUniform2fvARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3fvARB(int location, int count, /*const*/ float* value);
        private readonly GLUniform3fvARB glUniform3fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform3fvARB(int location, int count, /*const*/ float* value) =>
            this.glUniform3fvARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4fvARB(int location, int count, /*const*/ float* value);
        private readonly GLUniform4fvARB glUniform4fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform4fvARB(int location, int count, /*const*/ float* value) =>
            this.glUniform4fvARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1ivARB(int location, int count, /*const*/ int* value);
        private readonly GLUniform1ivARB glUniform1ivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform1ivARB(int location, int count, /*const*/ int* value) =>
            this.glUniform1ivARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2ivARB(int location, int count, /*const*/ int* value);
        private readonly GLUniform2ivARB glUniform2ivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform2ivARB(int location, int count, /*const*/ int* value) =>
            this.glUniform2ivARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3ivARB(int location, int count, /*const*/ int* value);
        private readonly GLUniform3ivARB glUniform3ivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform3ivARB(int location, int count, /*const*/ int* value) =>
            this.glUniform3ivARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4ivARB(int location, int count, /*const*/ int* value);
        private readonly GLUniform4ivARB glUniform4ivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void Uniform4ivARB(int location, int count, /*const*/ int* value) =>
            this.glUniform4ivARB.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2fvARB(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix2fvARB glUniformMatrix2fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void UniformMatrix2fvARB(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix2fvARB.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3fvARB(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix3fvARB glUniformMatrix3fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void UniformMatrix3fvARB(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix3fvARB.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4fvARB(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix4fvARB glUniformMatrix4fvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void UniformMatrix4fvARB(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix4fvARB.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectParameterfvARB(ushort obj, int pname, float* @params);
        private readonly GLGetObjectParameterfvARB glGetObjectParameterfvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetObjectParameterfvARB(ushort obj, int pname, float* @params) =>
            this.glGetObjectParameterfvARB.Invoke(obj, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectParameterivARB(ushort obj, int pname, int* @params);
        private readonly GLGetObjectParameterivARB glGetObjectParameterivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetObjectParameterivARB(ushort obj, int pname, int* @params) =>
            this.glGetObjectParameterivARB.Invoke(obj, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetInfoLogARB(ushort obj, int maxLength, int* length, sbyte* infoLog);
        private readonly GLGetInfoLogARB glGetInfoLogARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetInfoLogARB(ushort obj, int maxLength, int* length, sbyte* infoLog) =>
            this.glGetInfoLogARB.Invoke(obj, maxLength, length, infoLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetAttachedObjectsARB(ushort containerObj, int maxCount, int* count, ushort* obj);
        private readonly GLGetAttachedObjectsARB glGetAttachedObjectsARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetAttachedObjectsARB(ushort containerObj, int maxCount, int* count, ushort* obj) =>
            this.glGetAttachedObjectsARB.Invoke(containerObj, maxCount, count, obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetUniformLocationARB(ushort programObj, /*const*/ sbyte* name);
        private readonly GLGetUniformLocationARB glGetUniformLocationARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe int GetUniformLocationARB(ushort programObj, /*const*/ sbyte* name) =>
            this.glGetUniformLocationARB.Invoke(programObj, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniformARB(ushort programObj, uint index, int maxLength, int* length, int* size, UniformType* type, sbyte* name);
        private readonly GLGetActiveUniformARB glGetActiveUniformARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetActiveUniformARB(ushort programObj, uint index, int maxLength, int* length, int* size, UniformType* type, sbyte* name) =>
            this.glGetActiveUniformARB.Invoke(programObj, index, maxLength, length, size, type, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformfvARB(ushort programObj, int location, float* @params);
        private readonly GLGetUniformfvARB glGetUniformfvARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetUniformfvARB(ushort programObj, int location, float* @params) =>
            this.glGetUniformfvARB.Invoke(programObj, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformivARB(ushort programObj, int location, int* @params);
        private readonly GLGetUniformivARB glGetUniformivARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetUniformivARB(ushort programObj, int location, int* @params) =>
            this.glGetUniformivARB.Invoke(programObj, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetShaderSourceARB(ushort obj, int maxLength, int* length, sbyte* source);
        private readonly GLGetShaderSourceARB glGetShaderSourceARB;

        [GLExtension("GL_ARB_shader_objects")]
        public unsafe void GetShaderSourceARB(ushort obj, int maxLength, int* length, sbyte* source) =>
            this.glGetShaderSourceARB.Invoke(obj, maxLength, length, source);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);
        private readonly GLShaderStorageBlockBinding glShaderStorageBlockBinding;

        public void ShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding) =>
            this.glShaderStorageBlockBinding.Invoke(program, storageBlockIndex, storageBlockBinding);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetSubroutineUniformLocation(uint program, ShaderType shadertype, /*const*/ sbyte* name);
        private readonly GLGetSubroutineUniformLocation glGetSubroutineUniformLocation;

        public unsafe int GetSubroutineUniformLocation(uint program, ShaderType shadertype, /*const*/ sbyte* name) =>
            this.glGetSubroutineUniformLocation.Invoke(program, shadertype, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetSubroutineIndex(uint program, ShaderType shadertype, /*const*/ sbyte* name);
        private readonly GLGetSubroutineIndex glGetSubroutineIndex;

        public unsafe uint GetSubroutineIndex(uint program, ShaderType shadertype, /*const*/ sbyte* name) =>
            this.glGetSubroutineIndex.Invoke(program, shadertype, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveSubroutineUniformiv(uint program, ShaderType shadertype, uint index, SubroutineParameterName pname, int* values);
        private readonly GLGetActiveSubroutineUniformiv glGetActiveSubroutineUniformiv;

        public unsafe void GetActiveSubroutineUniformiv(uint program, ShaderType shadertype, uint index, SubroutineParameterName pname, int* values) =>
            this.glGetActiveSubroutineUniformiv.Invoke(program, shadertype, index, pname, values);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveSubroutineUniformName(uint program, ShaderType shadertype, uint index, int bufSize, int* length, sbyte* name);
        private readonly GLGetActiveSubroutineUniformName glGetActiveSubroutineUniformName;

        public unsafe void GetActiveSubroutineUniformName(uint program, ShaderType shadertype, uint index, int bufSize, int* length, sbyte* name) =>
            this.glGetActiveSubroutineUniformName.Invoke(program, shadertype, index, bufSize, length, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveSubroutineName(uint program, ShaderType shadertype, uint index, int bufSize, int* length, sbyte* name);
        private readonly GLGetActiveSubroutineName glGetActiveSubroutineName;

        public unsafe void GetActiveSubroutineName(uint program, ShaderType shadertype, uint index, int bufSize, int* length, sbyte* name) =>
            this.glGetActiveSubroutineName.Invoke(program, shadertype, index, bufSize, length, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformSubroutinesuiv(ShaderType shadertype, int count, /*const*/ uint* indices);
        private readonly GLUniformSubroutinesuiv glUniformSubroutinesuiv;

        public unsafe void UniformSubroutinesuiv(ShaderType shadertype, int count, /*const*/ uint* indices) =>
            this.glUniformSubroutinesuiv.Invoke(shadertype, count, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformSubroutineuiv(ShaderType shadertype, int location, uint* @params);
        private readonly GLGetUniformSubroutineuiv glGetUniformSubroutineuiv;

        public unsafe void GetUniformSubroutineuiv(ShaderType shadertype, int location, uint* @params) =>
            this.glGetUniformSubroutineuiv.Invoke(shadertype, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramStageiv(uint program, ShaderType shadertype, ProgramStagePName pname, int* values);
        private readonly GLGetProgramStageiv glGetProgramStageiv;

        public unsafe void GetProgramStageiv(uint program, ShaderType shadertype, ProgramStagePName pname, int* values) =>
            this.glGetProgramStageiv.Invoke(program, shadertype, pname, values);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLNamedStringARB(int type, int namelen, /*const*/ sbyte* name, int stringlen, /*const*/ sbyte* @string);
        private readonly GLNamedStringARB glNamedStringARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe void NamedStringARB(int type, int namelen, /*const*/ sbyte* name, int stringlen, /*const*/ sbyte* @string) =>
            this.glNamedStringARB.Invoke(type, namelen, name, stringlen, @string);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteNamedStringARB(int namelen, /*const*/ sbyte* name);
        private readonly GLDeleteNamedStringARB glDeleteNamedStringARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe void DeleteNamedStringARB(int namelen, /*const*/ sbyte* name) =>
            this.glDeleteNamedStringARB.Invoke(namelen, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLCompileShaderIncludeARB(uint shader, int count, sbyte path, /*const*/ int* length);
        private readonly GLCompileShaderIncludeARB glCompileShaderIncludeARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe void CompileShaderIncludeARB(uint shader, int count, sbyte path, /*const*/ int* length) =>
            this.glCompileShaderIncludeARB.Invoke(shader, count, path, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate bool GLIsNamedStringARB(int namelen, /*const*/ sbyte* name);
        private readonly GLIsNamedStringARB glIsNamedStringARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe bool IsNamedStringARB(int namelen, /*const*/ sbyte* name) =>
            this.glIsNamedStringARB.Invoke(namelen, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedStringARB(int namelen, /*const*/ sbyte* name, int bufSize, int* stringlen, sbyte* @string);
        private readonly GLGetNamedStringARB glGetNamedStringARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe void GetNamedStringARB(int namelen, /*const*/ sbyte* name, int bufSize, int* stringlen, sbyte* @string) =>
            this.glGetNamedStringARB.Invoke(namelen, name, bufSize, stringlen, @string);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetNamedStringivARB(int namelen, /*const*/ sbyte* name, int pname, int* @params);
        private readonly GLGetNamedStringivARB glGetNamedStringivARB;

        [GLExtension("GL_ARB_shading_language_include")]
        public unsafe void GetNamedStringivARB(int namelen, /*const*/ sbyte* name, int pname, int* @params) =>
            this.glGetNamedStringivARB.Invoke(namelen, name, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferPageCommitmentARB(int target, nint offset, nint size, bool commit);
        private readonly GLBufferPageCommitmentARB glBufferPageCommitmentARB;

        [GLExtension("GL_ARB_sparse_buffer")]
        public void BufferPageCommitmentARB(int target, nint offset, nint size, bool commit) =>
            this.glBufferPageCommitmentARB.Invoke(target, offset, size, commit);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedBufferPageCommitmentEXT(uint buffer, nint offset, nint size, bool commit);
        private readonly GLNamedBufferPageCommitmentEXT glNamedBufferPageCommitmentEXT;

        [GLExtension("GL_ARB_sparse_buffer")]
        public void NamedBufferPageCommitmentEXT(uint buffer, nint offset, nint size, bool commit) =>
            this.glNamedBufferPageCommitmentEXT.Invoke(buffer, offset, size, commit);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLNamedBufferPageCommitmentARB(uint buffer, nint offset, nint size, bool commit);
        private readonly GLNamedBufferPageCommitmentARB glNamedBufferPageCommitmentARB;

        [GLExtension("GL_ARB_sparse_buffer")]
        public void NamedBufferPageCommitmentARB(uint buffer, nint offset, nint size, bool commit) =>
            this.glNamedBufferPageCommitmentARB.Invoke(buffer, offset, size, commit);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexPageCommitmentARB(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, bool commit);
        private readonly GLTexPageCommitmentARB glTexPageCommitmentARB;

        [GLExtension("GL_ARB_sparse_texture")]
        public void TexPageCommitmentARB(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, bool commit) =>
            this.glTexPageCommitmentARB.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, commit);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLFenceSync(SyncCondition condition, SyncBehaviorFlags flags);
        private readonly GLFenceSync glFenceSync;

        public nint FenceSync(SyncCondition condition, SyncBehaviorFlags flags) =>
            this.glFenceSync.Invoke(condition, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsSync(nint sync);
        private readonly GLIsSync glIsSync;

        public bool IsSync(nint sync) =>
            this.glIsSync.Invoke(sync);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteSync(nint sync);
        private readonly GLDeleteSync glDeleteSync;

        public void DeleteSync(nint sync) =>
            this.glDeleteSync.Invoke(sync);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SyncStatus GLClientWaitSync(nint sync, SyncObjectMask flags, ulong timeout);
        private readonly GLClientWaitSync glClientWaitSync;

        public SyncStatus ClientWaitSync(nint sync, SyncObjectMask flags, ulong timeout) =>
            this.glClientWaitSync.Invoke(sync, flags, timeout);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWaitSync(nint sync, SyncBehaviorFlags flags, ulong timeout);
        private readonly GLWaitSync glWaitSync;

        public void WaitSync(nint sync, SyncBehaviorFlags flags, ulong timeout) =>
            this.glWaitSync.Invoke(sync, flags, timeout);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetInteger64v(GetPName pname, long* data);
        private readonly GLGetInteger64v glGetInteger64v;

        public unsafe void GetInteger64v(GetPName pname, long* data) =>
            this.glGetInteger64v.Invoke(pname, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetSynciv(nint sync, SyncParameterName pname, int count, int* length, int* values);
        private readonly GLGetSynciv glGetSynciv;

        public unsafe void GetSynciv(nint sync, SyncParameterName pname, int count, int* length, int* values) =>
            this.glGetSynciv.Invoke(sync, pname, count, length, values);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPatchParameteri(PatchParameterName pname, int value);
        private readonly GLPatchParameteri glPatchParameteri;

        public void PatchParameteri(PatchParameterName pname, int value) =>
            this.glPatchParameteri.Invoke(pname, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPatchParameterfv(PatchParameterName pname, /*const*/ float* values);
        private readonly GLPatchParameterfv glPatchParameterfv;

        public unsafe void PatchParameterfv(PatchParameterName pname, /*const*/ float* values) =>
            this.glPatchParameterfv.Invoke(pname, values);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureBarrier();
        private readonly GLTextureBarrier glTextureBarrier;

        public void TextureBarrier() =>
            this.glTextureBarrier.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexBufferARB(TextureTarget target, SizedInternalFormat internalformat, uint buffer);
        private readonly GLTexBufferARB glTexBufferARB;

        [GLExtension("GL_ARB_texture_buffer_object")]
        public void TexBufferARB(TextureTarget target, SizedInternalFormat internalformat, uint buffer) =>
            this.glTexBufferARB.Invoke(target, internalformat, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexBufferRange(TextureTarget target, SizedInternalFormat internalformat, uint buffer, nint offset, nint size);
        private readonly GLTexBufferRange glTexBufferRange;

        public void TexBufferRange(TextureTarget target, SizedInternalFormat internalformat, uint buffer, nint offset, nint size) =>
            this.glTexBufferRange.Invoke(target, internalformat, buffer, offset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage3DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage3DARB glCompressedTexImage3DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexImage3DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data) =>
            this.glCompressedTexImage3DARB.Invoke(target, level, internalformat, width, height, depth, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage2DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage2DARB glCompressedTexImage2DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexImage2DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data) =>
            this.glCompressedTexImage2DARB.Invoke(target, level, internalformat, width, height, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage1DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage1DARB glCompressedTexImage1DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexImage1DARB(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data) =>
            this.glCompressedTexImage1DARB.Invoke(target, level, internalformat, width, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage3DARB(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage3DARB glCompressedTexSubImage3DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexSubImage3DARB(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage3DARB.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage2DARB(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage2DARB glCompressedTexSubImage2DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexSubImage2DARB(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage2DARB.Invoke(target, level, xoffset, yoffset, width, height, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage1DARB(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage1DARB glCompressedTexSubImage1DARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void CompressedTexSubImage1DARB(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage1DARB.Invoke(target, level, xoffset, width, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetCompressedTexImageARB(TextureTarget target, int level, out nint img);
        private readonly GLGetCompressedTexImageARB glGetCompressedTexImageARB;

        [GLExtension("GL_ARB_texture_compression")]
        public void GetCompressedTexImageARB(TextureTarget target, int level, out nint img) =>
            this.glGetCompressedTexImageARB.Invoke(target, level, out img);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage2DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        private readonly GLTexImage2DMultisample glTexImage2DMultisample;

        public void TexImage2DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations) =>
            this.glTexImage2DMultisample.Invoke(target, samples, internalformat, width, height, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage3DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        private readonly GLTexImage3DMultisample glTexImage3DMultisample;

        public void TexImage3DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations) =>
            this.glTexImage3DMultisample.Invoke(target, samples, internalformat, width, height, depth, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetMultisamplefv(GetMultisamplePNameNV pname, uint index, float* val);
        private readonly GLGetMultisamplefv glGetMultisamplefv;

        public unsafe void GetMultisamplefv(GetMultisamplePNameNV pname, uint index, float* val) =>
            this.glGetMultisamplefv.Invoke(pname, index, val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSampleMaski(uint maskNumber, uint mask);
        private readonly GLSampleMaski glSampleMaski;

        public void SampleMaski(uint maskNumber, uint mask) =>
            this.glSampleMaski.Invoke(maskNumber, mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexStorage1D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width);
        private readonly GLTexStorage1D glTexStorage1D;

        public void TexStorage1D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width) =>
            this.glTexStorage1D.Invoke(target, levels, internalformat, width);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexStorage2D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height);
        private readonly GLTexStorage2D glTexStorage2D;

        public void TexStorage2D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height) =>
            this.glTexStorage2D.Invoke(target, levels, internalformat, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexStorage3D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, int depth);
        private readonly GLTexStorage3D glTexStorage3D;

        public void TexStorage3D(TextureTarget target, int levels, SizedInternalFormat internalformat, int width, int height, int depth) =>
            this.glTexStorage3D.Invoke(target, levels, internalformat, width, height, depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexStorage2DMultisample(TextureTarget target, int samples, SizedInternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        private readonly GLTexStorage2DMultisample glTexStorage2DMultisample;

        public void TexStorage2DMultisample(TextureTarget target, int samples, SizedInternalFormat internalformat, int width, int height, bool fixedsamplelocations) =>
            this.glTexStorage2DMultisample.Invoke(target, samples, internalformat, width, height, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexStorage3DMultisample(TextureTarget target, int samples, SizedInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        private readonly GLTexStorage3DMultisample glTexStorage3DMultisample;

        public void TexStorage3DMultisample(TextureTarget target, int samples, SizedInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations) =>
            this.glTexStorage3DMultisample.Invoke(target, samples, internalformat, width, height, depth, fixedsamplelocations);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTextureView(uint texture, TextureTarget target, uint origtexture, SizedInternalFormat internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);
        private readonly GLTextureView glTextureView;

        public void TextureView(uint texture, TextureTarget target, uint origtexture, SizedInternalFormat internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers) =>
            this.glTextureView.Invoke(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLQueryCounter(uint id, QueryCounterTarget target);
        private readonly GLQueryCounter glQueryCounter;

        public void QueryCounter(uint id, QueryCounterTarget target) =>
            this.glQueryCounter.Invoke(id, target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjecti64v(uint id, QueryObjectParameterName pname, long* @params);
        private readonly GLGetQueryObjecti64v glGetQueryObjecti64v;

        public unsafe void GetQueryObjecti64v(uint id, QueryObjectParameterName pname, long* @params) =>
            this.glGetQueryObjecti64v.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjectui64v(uint id, QueryObjectParameterName pname, ulong* @params);
        private readonly GLGetQueryObjectui64v glGetQueryObjectui64v;

        public unsafe void GetQueryObjectui64v(uint id, QueryObjectParameterName pname, ulong* @params) =>
            this.glGetQueryObjectui64v.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindTransformFeedback(BindTransformFeedbackTarget target, uint id);
        private readonly GLBindTransformFeedback glBindTransformFeedback;

        public void BindTransformFeedback(BindTransformFeedbackTarget target, uint id) =>
            this.glBindTransformFeedback.Invoke(target, id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteTransformFeedbacks(int n, /*const*/ uint* ids);
        private readonly GLDeleteTransformFeedbacks glDeleteTransformFeedbacks;

        public unsafe void DeleteTransformFeedbacks(int n, /*const*/ uint* ids) =>
            this.glDeleteTransformFeedbacks.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenTransformFeedbacks(int n, uint* ids);
        private readonly GLGenTransformFeedbacks glGenTransformFeedbacks;

        public unsafe void GenTransformFeedbacks(int n, uint* ids) =>
            this.glGenTransformFeedbacks.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsTransformFeedback(uint id);
        private readonly GLIsTransformFeedback glIsTransformFeedback;

        public bool IsTransformFeedback(uint id) =>
            this.glIsTransformFeedback.Invoke(id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPauseTransformFeedback();
        private readonly GLPauseTransformFeedback glPauseTransformFeedback;

        public void PauseTransformFeedback() =>
            this.glPauseTransformFeedback.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLResumeTransformFeedback();
        private readonly GLResumeTransformFeedback glResumeTransformFeedback;

        public void ResumeTransformFeedback() =>
            this.glResumeTransformFeedback.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawTransformFeedback(PrimitiveType mode, uint id);
        private readonly GLDrawTransformFeedback glDrawTransformFeedback;

        public void DrawTransformFeedback(PrimitiveType mode, uint id) =>
            this.glDrawTransformFeedback.Invoke(mode, id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawTransformFeedbackStream(PrimitiveType mode, uint id, uint stream);
        private readonly GLDrawTransformFeedbackStream glDrawTransformFeedbackStream;

        public void DrawTransformFeedbackStream(PrimitiveType mode, uint id, uint stream) =>
            this.glDrawTransformFeedbackStream.Invoke(mode, id, stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginQueryIndexed(QueryTarget target, uint index, uint id);
        private readonly GLBeginQueryIndexed glBeginQueryIndexed;

        public void BeginQueryIndexed(QueryTarget target, uint index, uint id) =>
            this.glBeginQueryIndexed.Invoke(target, index, id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndQueryIndexed(QueryTarget target, uint index);
        private readonly GLEndQueryIndexed glEndQueryIndexed;

        public void EndQueryIndexed(QueryTarget target, uint index) =>
            this.glEndQueryIndexed.Invoke(target, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryIndexediv(QueryTarget target, uint index, QueryParameterName pname, int* @params);
        private readonly GLGetQueryIndexediv glGetQueryIndexediv;

        public unsafe void GetQueryIndexediv(QueryTarget target, uint index, QueryParameterName pname, int* @params) =>
            this.glGetQueryIndexediv.Invoke(target, index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawTransformFeedbackInstanced(PrimitiveType mode, uint id, int instancecount);
        private readonly GLDrawTransformFeedbackInstanced glDrawTransformFeedbackInstanced;

        public void DrawTransformFeedbackInstanced(PrimitiveType mode, uint id, int instancecount) =>
            this.glDrawTransformFeedbackInstanced.Invoke(mode, id, instancecount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawTransformFeedbackStreamInstanced(PrimitiveType mode, uint id, uint stream, int instancecount);
        private readonly GLDrawTransformFeedbackStreamInstanced glDrawTransformFeedbackStreamInstanced;

        public void DrawTransformFeedbackStreamInstanced(PrimitiveType mode, uint id, uint stream, int instancecount) =>
            this.glDrawTransformFeedbackStreamInstanced.Invoke(mode, id, stream, instancecount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLLoadTransposeMatrixfARB(/*const*/ float* m);
        private readonly GLLoadTransposeMatrixfARB glLoadTransposeMatrixfARB;

        [GLExtension("GL_ARB_transpose_matrix")]
        public unsafe void LoadTransposeMatrixfARB(/*const*/ float* m) =>
            this.glLoadTransposeMatrixfARB.Invoke(m);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLLoadTransposeMatrixdARB(/*const*/ double* m);
        private readonly GLLoadTransposeMatrixdARB glLoadTransposeMatrixdARB;

        [GLExtension("GL_ARB_transpose_matrix")]
        public unsafe void LoadTransposeMatrixdARB(/*const*/ double* m) =>
            this.glLoadTransposeMatrixdARB.Invoke(m);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultTransposeMatrixfARB(/*const*/ float* m);
        private readonly GLMultTransposeMatrixfARB glMultTransposeMatrixfARB;

        [GLExtension("GL_ARB_transpose_matrix")]
        public unsafe void MultTransposeMatrixfARB(/*const*/ float* m) =>
            this.glMultTransposeMatrixfARB.Invoke(m);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultTransposeMatrixdARB(/*const*/ double* m);
        private readonly GLMultTransposeMatrixdARB glMultTransposeMatrixdARB;

        [GLExtension("GL_ARB_transpose_matrix")]
        public unsafe void MultTransposeMatrixdARB(/*const*/ double* m) =>
            this.glMultTransposeMatrixdARB.Invoke(m);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformIndices(uint program, int uniformCount, sbyte uniformNames, uint* uniformIndices);
        private readonly GLGetUniformIndices glGetUniformIndices;

        public unsafe void GetUniformIndices(uint program, int uniformCount, sbyte uniformNames, uint* uniformIndices) =>
            this.glGetUniformIndices.Invoke(program, uniformCount, uniformNames, uniformIndices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniformsiv(uint program, int uniformCount, /*const*/ uint* uniformIndices, UniformPName pname, int* @params);
        private readonly GLGetActiveUniformsiv glGetActiveUniformsiv;

        public unsafe void GetActiveUniformsiv(uint program, int uniformCount, /*const*/ uint* uniformIndices, UniformPName pname, int* @params) =>
            this.glGetActiveUniformsiv.Invoke(program, uniformCount, uniformIndices, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniformName(uint program, uint uniformIndex, int bufSize, int* length, sbyte* uniformName);
        private readonly GLGetActiveUniformName glGetActiveUniformName;

        public unsafe void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, int* length, sbyte* uniformName) =>
            this.glGetActiveUniformName.Invoke(program, uniformIndex, bufSize, length, uniformName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetUniformBlockIndex(uint program, /*const*/ sbyte* uniformBlockName);
        private readonly GLGetUniformBlockIndex glGetUniformBlockIndex;

        public unsafe uint GetUniformBlockIndex(uint program, /*const*/ sbyte* uniformBlockName) =>
            this.glGetUniformBlockIndex.Invoke(program, uniformBlockName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, UniformBlockPName pname, int* @params);
        private readonly GLGetActiveUniformBlockiv glGetActiveUniformBlockiv;

        public unsafe void GetActiveUniformBlockiv(uint program, uint uniformBlockIndex, UniformBlockPName pname, int* @params) =>
            this.glGetActiveUniformBlockiv.Invoke(program, uniformBlockIndex, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, int* length, sbyte* uniformBlockName);
        private readonly GLGetActiveUniformBlockName glGetActiveUniformBlockName;

        public unsafe void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, int* length, sbyte* uniformBlockName) =>
            this.glGetActiveUniformBlockName.Invoke(program, uniformBlockIndex, bufSize, length, uniformBlockName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
        private readonly GLUniformBlockBinding glUniformBlockBinding;

        public void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding) =>
            this.glUniformBlockBinding.Invoke(program, uniformBlockIndex, uniformBlockBinding);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindBufferRange(BufferTargetARB target, uint index, uint buffer, nint offset, nint size);
        private readonly GLBindBufferRange glBindBufferRange;

        public void BindBufferRange(BufferTargetARB target, uint index, uint buffer, nint offset, nint size) =>
            this.glBindBufferRange.Invoke(target, index, buffer, offset, size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindBufferBase(BufferTargetARB target, uint index, uint buffer);
        private readonly GLBindBufferBase glBindBufferBase;

        public void BindBufferBase(BufferTargetARB target, uint index, uint buffer) =>
            this.glBindBufferBase.Invoke(target, index, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetIntegeri_v(GetPName target, uint index, int* data);
        private readonly GLGetIntegeri_v glGetIntegeri_v;

        public unsafe void GetIntegeri_v(GetPName target, uint index, int* data) =>
            this.glGetIntegeri_v.Invoke(target, index, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindVertexArray(uint array);
        private readonly GLBindVertexArray glBindVertexArray;

        public void BindVertexArray(uint array) =>
            this.glBindVertexArray.Invoke(array);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteVertexArrays(int n, /*const*/ uint* arrays);
        private readonly GLDeleteVertexArrays glDeleteVertexArrays;

        public unsafe void DeleteVertexArrays(int n, /*const*/ uint* arrays) =>
            this.glDeleteVertexArrays.Invoke(n, arrays);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenVertexArrays(int n, uint* arrays);
        private readonly GLGenVertexArrays glGenVertexArrays;

        public unsafe void GenVertexArrays(int n, uint* arrays) =>
            this.glGenVertexArrays.Invoke(n, arrays);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsVertexArray(uint array);
        private readonly GLIsVertexArray glIsVertexArray;

        public bool IsVertexArray(uint array) =>
            this.glIsVertexArray.Invoke(array);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribL1d(uint index, double x);
        private readonly GLVertexAttribL1d glVertexAttribL1d;

        public void VertexAttribL1d(uint index, double x) =>
            this.glVertexAttribL1d.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribL2d(uint index, double x, double y);
        private readonly GLVertexAttribL2d glVertexAttribL2d;

        public void VertexAttribL2d(uint index, double x, double y) =>
            this.glVertexAttribL2d.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribL3d(uint index, double x, double y, double z);
        private readonly GLVertexAttribL3d glVertexAttribL3d;

        public void VertexAttribL3d(uint index, double x, double y, double z) =>
            this.glVertexAttribL3d.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribL4d(uint index, double x, double y, double z, double w);
        private readonly GLVertexAttribL4d glVertexAttribL4d;

        public void VertexAttribL4d(uint index, double x, double y, double z, double w) =>
            this.glVertexAttribL4d.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribL1dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttribL1dv glVertexAttribL1dv;

        public unsafe void VertexAttribL1dv(uint index, /*const*/ double* v) =>
            this.glVertexAttribL1dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribL2dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttribL2dv glVertexAttribL2dv;

        public unsafe void VertexAttribL2dv(uint index, /*const*/ double* v) =>
            this.glVertexAttribL2dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribL3dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttribL3dv glVertexAttribL3dv;

        public unsafe void VertexAttribL3dv(uint index, /*const*/ double* v) =>
            this.glVertexAttribL3dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribL4dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttribL4dv glVertexAttribL4dv;

        public unsafe void VertexAttribL4dv(uint index, /*const*/ double* v) =>
            this.glVertexAttribL4dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribLPointer(uint index, int size, VertexAttribLType type, int stride, nint pointer);
        private readonly GLVertexAttribLPointer glVertexAttribLPointer;

        public void VertexAttribLPointer(uint index, int size, VertexAttribLType type, int stride, nint pointer) =>
            this.glVertexAttribLPointer.Invoke(index, size, type, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribLdv(uint index, VertexAttribEnum pname, double* @params);
        private readonly GLGetVertexAttribLdv glGetVertexAttribLdv;

        public unsafe void GetVertexAttribLdv(uint index, VertexAttribEnum pname, double* @params) =>
            this.glGetVertexAttribLdv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindVertexBuffer(uint bindingindex, uint buffer, nint offset, int stride);
        private readonly GLBindVertexBuffer glBindVertexBuffer;

        public void BindVertexBuffer(uint bindingindex, uint buffer, nint offset, int stride) =>
            this.glBindVertexBuffer.Invoke(bindingindex, buffer, offset, stride);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribFormat(uint attribindex, int size, VertexAttribType type, bool normalized, uint relativeoffset);
        private readonly GLVertexAttribFormat glVertexAttribFormat;

        public void VertexAttribFormat(uint attribindex, int size, VertexAttribType type, bool normalized, uint relativeoffset) =>
            this.glVertexAttribFormat.Invoke(attribindex, size, type, normalized, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribIFormat(uint attribindex, int size, VertexAttribIType type, uint relativeoffset);
        private readonly GLVertexAttribIFormat glVertexAttribIFormat;

        public void VertexAttribIFormat(uint attribindex, int size, VertexAttribIType type, uint relativeoffset) =>
            this.glVertexAttribIFormat.Invoke(attribindex, size, type, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribLFormat(uint attribindex, int size, VertexAttribLType type, uint relativeoffset);
        private readonly GLVertexAttribLFormat glVertexAttribLFormat;

        public void VertexAttribLFormat(uint attribindex, int size, VertexAttribLType type, uint relativeoffset) =>
            this.glVertexAttribLFormat.Invoke(attribindex, size, type, relativeoffset);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribBinding(uint attribindex, uint bindingindex);
        private readonly GLVertexAttribBinding glVertexAttribBinding;

        public void VertexAttribBinding(uint attribindex, uint bindingindex) =>
            this.glVertexAttribBinding.Invoke(attribindex, bindingindex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexBindingDivisor(uint bindingindex, uint divisor);
        private readonly GLVertexBindingDivisor glVertexBindingDivisor;

        public void VertexBindingDivisor(uint bindingindex, uint divisor) =>
            this.glVertexBindingDivisor.Invoke(bindingindex, divisor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightbvARB(int size, /*const*/ sbyte* weights);
        private readonly GLWeightbvARB glWeightbvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightbvARB(int size, /*const*/ sbyte* weights) =>
            this.glWeightbvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightsvARB(int size, /*const*/ short* weights);
        private readonly GLWeightsvARB glWeightsvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightsvARB(int size, /*const*/ short* weights) =>
            this.glWeightsvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightivARB(int size, /*const*/ int* weights);
        private readonly GLWeightivARB glWeightivARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightivARB(int size, /*const*/ int* weights) =>
            this.glWeightivARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightfvARB(int size, /*const*/ float* weights);
        private readonly GLWeightfvARB glWeightfvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightfvARB(int size, /*const*/ float* weights) =>
            this.glWeightfvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightdvARB(int size, /*const*/ double* weights);
        private readonly GLWeightdvARB glWeightdvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightdvARB(int size, /*const*/ double* weights) =>
            this.glWeightdvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightubvARB(int size, /*const*/ byte* weights);
        private readonly GLWeightubvARB glWeightubvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightubvARB(int size, /*const*/ byte* weights) =>
            this.glWeightubvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightusvARB(int size, /*const*/ ushort* weights);
        private readonly GLWeightusvARB glWeightusvARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightusvARB(int size, /*const*/ ushort* weights) =>
            this.glWeightusvARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWeightuivARB(int size, /*const*/ uint* weights);
        private readonly GLWeightuivARB glWeightuivARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public unsafe void WeightuivARB(int size, /*const*/ uint* weights) =>
            this.glWeightuivARB.Invoke(size, weights);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWeightPointerARB(int size, WeightPointerTypeARB type, int stride, nint pointer);
        private readonly GLWeightPointerARB glWeightPointerARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public void WeightPointerARB(int size, WeightPointerTypeARB type, int stride, nint pointer) =>
            this.glWeightPointerARB.Invoke(size, type, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexBlendARB(int count);
        private readonly GLVertexBlendARB glVertexBlendARB;

        [GLExtension("GL_ARB_vertex_blend")]
        public void VertexBlendARB(int count) =>
            this.glVertexBlendARB.Invoke(count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindBufferARB(BufferTargetARB target, uint buffer);
        private readonly GLBindBufferARB glBindBufferARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public void BindBufferARB(BufferTargetARB target, uint buffer) =>
            this.glBindBufferARB.Invoke(target, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteBuffersARB(int n, /*const*/ uint* buffers);
        private readonly GLDeleteBuffersARB glDeleteBuffersARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public unsafe void DeleteBuffersARB(int n, /*const*/ uint* buffers) =>
            this.glDeleteBuffersARB.Invoke(n, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenBuffersARB(int n, uint* buffers);
        private readonly GLGenBuffersARB glGenBuffersARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public unsafe void GenBuffersARB(int n, uint* buffers) =>
            this.glGenBuffersARB.Invoke(n, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsBufferARB(uint buffer);
        private readonly GLIsBufferARB glIsBufferARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public bool IsBufferARB(uint buffer) =>
            this.glIsBufferARB.Invoke(buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferDataARB(BufferTargetARB target, nint size, nint data, BufferUsageARB usage);
        private readonly GLBufferDataARB glBufferDataARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public void BufferDataARB(BufferTargetARB target, nint size, nint data, BufferUsageARB usage) =>
            this.glBufferDataARB.Invoke(target, size, data, usage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferSubDataARB(BufferTargetARB target, nint offset, nint size, nint data);
        private readonly GLBufferSubDataARB glBufferSubDataARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public void BufferSubDataARB(BufferTargetARB target, nint offset, nint size, nint data) =>
            this.glBufferSubDataARB.Invoke(target, offset, size, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferSubDataARB(BufferTargetARB target, nint offset, nint size, out nint data);
        private readonly GLGetBufferSubDataARB glGetBufferSubDataARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public void GetBufferSubDataARB(BufferTargetARB target, nint offset, nint size, out nint data) =>
            this.glGetBufferSubDataARB.Invoke(target, offset, size, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapBufferARB(BufferTargetARB target, BufferAccessARB access);
        private readonly GLMapBufferARB glMapBufferARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public nint MapBufferARB(BufferTargetARB target, BufferAccessARB access) =>
            this.glMapBufferARB.Invoke(target, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLUnmapBufferARB(BufferTargetARB target);
        private readonly GLUnmapBufferARB glUnmapBufferARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public bool UnmapBufferARB(BufferTargetARB target) =>
            this.glUnmapBufferARB.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetBufferParameterivARB(BufferTargetARB target, BufferPNameARB pname, int* @params);
        private readonly GLGetBufferParameterivARB glGetBufferParameterivARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public unsafe void GetBufferParameterivARB(BufferTargetARB target, BufferPNameARB pname, int* @params) =>
            this.glGetBufferParameterivARB.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferPointervARB(BufferTargetARB target, BufferPointerNameARB pname, out nint @params);
        private readonly GLGetBufferPointervARB glGetBufferPointervARB;

        [GLExtension("GL_ARB_vertex_buffer_object")]
        public void GetBufferPointervARB(BufferTargetARB target, BufferPointerNameARB pname, out nint @params) =>
            this.glGetBufferPointervARB.Invoke(target, pname, out @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1dARB(uint index, double x);
        private readonly GLVertexAttrib1dARB glVertexAttrib1dARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib1dARB(uint index, double x) =>
            this.glVertexAttrib1dARB.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1dvARB(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib1dvARB glVertexAttrib1dvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib1dvARB(uint index, /*const*/ double* v) =>
            this.glVertexAttrib1dvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1fARB(uint index, float x);
        private readonly GLVertexAttrib1fARB glVertexAttrib1fARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib1fARB(uint index, float x) =>
            this.glVertexAttrib1fARB.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1fvARB(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib1fvARB glVertexAttrib1fvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib1fvARB(uint index, /*const*/ float* v) =>
            this.glVertexAttrib1fvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1sARB(uint index, short x);
        private readonly GLVertexAttrib1sARB glVertexAttrib1sARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib1sARB(uint index, short x) =>
            this.glVertexAttrib1sARB.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1svARB(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib1svARB glVertexAttrib1svARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib1svARB(uint index, /*const*/ short* v) =>
            this.glVertexAttrib1svARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2dARB(uint index, double x, double y);
        private readonly GLVertexAttrib2dARB glVertexAttrib2dARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib2dARB(uint index, double x, double y) =>
            this.glVertexAttrib2dARB.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2dvARB(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib2dvARB glVertexAttrib2dvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib2dvARB(uint index, /*const*/ double* v) =>
            this.glVertexAttrib2dvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2fARB(uint index, float x, float y);
        private readonly GLVertexAttrib2fARB glVertexAttrib2fARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib2fARB(uint index, float x, float y) =>
            this.glVertexAttrib2fARB.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2fvARB(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib2fvARB glVertexAttrib2fvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib2fvARB(uint index, /*const*/ float* v) =>
            this.glVertexAttrib2fvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2sARB(uint index, short x, short y);
        private readonly GLVertexAttrib2sARB glVertexAttrib2sARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib2sARB(uint index, short x, short y) =>
            this.glVertexAttrib2sARB.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2svARB(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib2svARB glVertexAttrib2svARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib2svARB(uint index, /*const*/ short* v) =>
            this.glVertexAttrib2svARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3dARB(uint index, double x, double y, double z);
        private readonly GLVertexAttrib3dARB glVertexAttrib3dARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib3dARB(uint index, double x, double y, double z) =>
            this.glVertexAttrib3dARB.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3dvARB(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib3dvARB glVertexAttrib3dvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib3dvARB(uint index, /*const*/ double* v) =>
            this.glVertexAttrib3dvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3fARB(uint index, float x, float y, float z);
        private readonly GLVertexAttrib3fARB glVertexAttrib3fARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib3fARB(uint index, float x, float y, float z) =>
            this.glVertexAttrib3fARB.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3fvARB(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib3fvARB glVertexAttrib3fvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib3fvARB(uint index, /*const*/ float* v) =>
            this.glVertexAttrib3fvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3sARB(uint index, short x, short y, short z);
        private readonly GLVertexAttrib3sARB glVertexAttrib3sARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib3sARB(uint index, short x, short y, short z) =>
            this.glVertexAttrib3sARB.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3svARB(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib3svARB glVertexAttrib3svARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib3svARB(uint index, /*const*/ short* v) =>
            this.glVertexAttrib3svARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NbvARB(uint index, /*const*/ sbyte* v);
        private readonly GLVertexAttrib4NbvARB glVertexAttrib4NbvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NbvARB(uint index, /*const*/ sbyte* v) =>
            this.glVertexAttrib4NbvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NivARB(uint index, /*const*/ int* v);
        private readonly GLVertexAttrib4NivARB glVertexAttrib4NivARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NivARB(uint index, /*const*/ int* v) =>
            this.glVertexAttrib4NivARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NsvARB(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib4NsvARB glVertexAttrib4NsvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NsvARB(uint index, /*const*/ short* v) =>
            this.glVertexAttrib4NsvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4NubARB(uint index, byte x, byte y, byte z, byte w);
        private readonly GLVertexAttrib4NubARB glVertexAttrib4NubARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib4NubARB(uint index, byte x, byte y, byte z, byte w) =>
            this.glVertexAttrib4NubARB.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NubvARB(uint index, /*const*/ byte* v);
        private readonly GLVertexAttrib4NubvARB glVertexAttrib4NubvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NubvARB(uint index, /*const*/ byte* v) =>
            this.glVertexAttrib4NubvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NuivARB(uint index, /*const*/ uint* v);
        private readonly GLVertexAttrib4NuivARB glVertexAttrib4NuivARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NuivARB(uint index, /*const*/ uint* v) =>
            this.glVertexAttrib4NuivARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4NusvARB(uint index, /*const*/ ushort* v);
        private readonly GLVertexAttrib4NusvARB glVertexAttrib4NusvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4NusvARB(uint index, /*const*/ ushort* v) =>
            this.glVertexAttrib4NusvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4bvARB(uint index, /*const*/ sbyte* v);
        private readonly GLVertexAttrib4bvARB glVertexAttrib4bvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4bvARB(uint index, /*const*/ sbyte* v) =>
            this.glVertexAttrib4bvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4dARB(uint index, double x, double y, double z, double w);
        private readonly GLVertexAttrib4dARB glVertexAttrib4dARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib4dARB(uint index, double x, double y, double z, double w) =>
            this.glVertexAttrib4dARB.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4dvARB(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib4dvARB glVertexAttrib4dvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4dvARB(uint index, /*const*/ double* v) =>
            this.glVertexAttrib4dvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4fARB(uint index, float x, float y, float z, float w);
        private readonly GLVertexAttrib4fARB glVertexAttrib4fARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib4fARB(uint index, float x, float y, float z, float w) =>
            this.glVertexAttrib4fARB.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4fvARB(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib4fvARB glVertexAttrib4fvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4fvARB(uint index, /*const*/ float* v) =>
            this.glVertexAttrib4fvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4ivARB(uint index, /*const*/ int* v);
        private readonly GLVertexAttrib4ivARB glVertexAttrib4ivARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4ivARB(uint index, /*const*/ int* v) =>
            this.glVertexAttrib4ivARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4sARB(uint index, short x, short y, short z, short w);
        private readonly GLVertexAttrib4sARB glVertexAttrib4sARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttrib4sARB(uint index, short x, short y, short z, short w) =>
            this.glVertexAttrib4sARB.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4svARB(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib4svARB glVertexAttrib4svARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4svARB(uint index, /*const*/ short* v) =>
            this.glVertexAttrib4svARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4ubvARB(uint index, /*const*/ byte* v);
        private readonly GLVertexAttrib4ubvARB glVertexAttrib4ubvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4ubvARB(uint index, /*const*/ byte* v) =>
            this.glVertexAttrib4ubvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4uivARB(uint index, /*const*/ uint* v);
        private readonly GLVertexAttrib4uivARB glVertexAttrib4uivARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4uivARB(uint index, /*const*/ uint* v) =>
            this.glVertexAttrib4uivARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4usvARB(uint index, /*const*/ ushort* v);
        private readonly GLVertexAttrib4usvARB glVertexAttrib4usvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void VertexAttrib4usvARB(uint index, /*const*/ ushort* v) =>
            this.glVertexAttrib4usvARB.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribPointerARB(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer);
        private readonly GLVertexAttribPointerARB glVertexAttribPointerARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void VertexAttribPointerARB(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer) =>
            this.glVertexAttribPointerARB.Invoke(index, size, type, normalized, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnableVertexAttribArrayARB(uint index);
        private readonly GLEnableVertexAttribArrayARB glEnableVertexAttribArrayARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void EnableVertexAttribArrayARB(uint index) =>
            this.glEnableVertexAttribArrayARB.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisableVertexAttribArrayARB(uint index);
        private readonly GLDisableVertexAttribArrayARB glDisableVertexAttribArrayARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void DisableVertexAttribArrayARB(uint index) =>
            this.glDisableVertexAttribArrayARB.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribdvARB(uint index, VertexAttribPropertyARB pname, double* @params);
        private readonly GLGetVertexAttribdvARB glGetVertexAttribdvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void GetVertexAttribdvARB(uint index, VertexAttribPropertyARB pname, double* @params) =>
            this.glGetVertexAttribdvARB.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribfvARB(uint index, VertexAttribPropertyARB pname, float* @params);
        private readonly GLGetVertexAttribfvARB glGetVertexAttribfvARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void GetVertexAttribfvARB(uint index, VertexAttribPropertyARB pname, float* @params) =>
            this.glGetVertexAttribfvARB.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribivARB(uint index, VertexAttribPropertyARB pname, int* @params);
        private readonly GLGetVertexAttribivARB glGetVertexAttribivARB;

        [GLExtension("GL_ARB_vertex_program")]
        public unsafe void GetVertexAttribivARB(uint index, VertexAttribPropertyARB pname, int* @params) =>
            this.glGetVertexAttribivARB.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribPointervARB(uint index, VertexAttribPointerPropertyARB pname, out nint pointer);
        private readonly GLGetVertexAttribPointervARB glGetVertexAttribPointervARB;

        [GLExtension("GL_ARB_vertex_program")]
        public void GetVertexAttribPointervARB(uint index, VertexAttribPointerPropertyARB pname, out nint pointer) =>
            this.glGetVertexAttribPointervARB.Invoke(index, pname, out pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindAttribLocationARB(ushort programObj, uint index, /*const*/ sbyte* name);
        private readonly GLBindAttribLocationARB glBindAttribLocationARB;

        [GLExtension("GL_ARB_vertex_shader")]
        public unsafe void BindAttribLocationARB(ushort programObj, uint index, /*const*/ sbyte* name) =>
            this.glBindAttribLocationARB.Invoke(programObj, index, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveAttribARB(ushort programObj, uint index, int maxLength, int* length, int* size, AttributeType* type, sbyte* name);
        private readonly GLGetActiveAttribARB glGetActiveAttribARB;

        [GLExtension("GL_ARB_vertex_shader")]
        public unsafe void GetActiveAttribARB(ushort programObj, uint index, int maxLength, int* length, int* size, AttributeType* type, sbyte* name) =>
            this.glGetActiveAttribARB.Invoke(programObj, index, maxLength, length, size, type, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetAttribLocationARB(ushort programObj, /*const*/ sbyte* name);
        private readonly GLGetAttribLocationARB glGetAttribLocationARB;

        [GLExtension("GL_ARB_vertex_shader")]
        public unsafe int GetAttribLocationARB(ushort programObj, /*const*/ sbyte* name) =>
            this.glGetAttribLocationARB.Invoke(programObj, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribP1ui(uint index, VertexAttribPointerType type, bool normalized, uint value);
        private readonly GLVertexAttribP1ui glVertexAttribP1ui;

        public void VertexAttribP1ui(uint index, VertexAttribPointerType type, bool normalized, uint value) =>
            this.glVertexAttribP1ui.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribP1uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value);
        private readonly GLVertexAttribP1uiv glVertexAttribP1uiv;

        public unsafe void VertexAttribP1uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value) =>
            this.glVertexAttribP1uiv.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribP2ui(uint index, VertexAttribPointerType type, bool normalized, uint value);
        private readonly GLVertexAttribP2ui glVertexAttribP2ui;

        public void VertexAttribP2ui(uint index, VertexAttribPointerType type, bool normalized, uint value) =>
            this.glVertexAttribP2ui.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribP2uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value);
        private readonly GLVertexAttribP2uiv glVertexAttribP2uiv;

        public unsafe void VertexAttribP2uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value) =>
            this.glVertexAttribP2uiv.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribP3ui(uint index, VertexAttribPointerType type, bool normalized, uint value);
        private readonly GLVertexAttribP3ui glVertexAttribP3ui;

        public void VertexAttribP3ui(uint index, VertexAttribPointerType type, bool normalized, uint value) =>
            this.glVertexAttribP3ui.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribP3uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value);
        private readonly GLVertexAttribP3uiv glVertexAttribP3uiv;

        public unsafe void VertexAttribP3uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value) =>
            this.glVertexAttribP3uiv.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribP4ui(uint index, VertexAttribPointerType type, bool normalized, uint value);
        private readonly GLVertexAttribP4ui glVertexAttribP4ui;

        public void VertexAttribP4ui(uint index, VertexAttribPointerType type, bool normalized, uint value) =>
            this.glVertexAttribP4ui.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribP4uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value);
        private readonly GLVertexAttribP4uiv glVertexAttribP4uiv;

        public unsafe void VertexAttribP4uiv(uint index, VertexAttribPointerType type, bool normalized, /*const*/ uint* value) =>
            this.glVertexAttribP4uiv.Invoke(index, type, normalized, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLViewportArrayv(uint first, int count, /*const*/ float* v);
        private readonly GLViewportArrayv glViewportArrayv;

        public unsafe void ViewportArrayv(uint first, int count, /*const*/ float* v) =>
            this.glViewportArrayv.Invoke(first, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLViewportIndexedf(uint index, float x, float y, float w, float h);
        private readonly GLViewportIndexedf glViewportIndexedf;

        public void ViewportIndexedf(uint index, float x, float y, float w, float h) =>
            this.glViewportIndexedf.Invoke(index, x, y, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLViewportIndexedfv(uint index, /*const*/ float* v);
        private readonly GLViewportIndexedfv glViewportIndexedfv;

        public unsafe void ViewportIndexedfv(uint index, /*const*/ float* v) =>
            this.glViewportIndexedfv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLScissorArrayv(uint first, int count, /*const*/ int* v);
        private readonly GLScissorArrayv glScissorArrayv;

        public unsafe void ScissorArrayv(uint first, int count, /*const*/ int* v) =>
            this.glScissorArrayv.Invoke(first, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLScissorIndexed(uint index, int left, int bottom, int width, int height);
        private readonly GLScissorIndexed glScissorIndexed;

        public void ScissorIndexed(uint index, int left, int bottom, int width, int height) =>
            this.glScissorIndexed.Invoke(index, left, bottom, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLScissorIndexedv(uint index, /*const*/ int* v);
        private readonly GLScissorIndexedv glScissorIndexedv;

        public unsafe void ScissorIndexedv(uint index, /*const*/ int* v) =>
            this.glScissorIndexedv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDepthRangeArrayv(uint first, int count, /*const*/ double* v);
        private readonly GLDepthRangeArrayv glDepthRangeArrayv;

        public unsafe void DepthRangeArrayv(uint first, int count, /*const*/ double* v) =>
            this.glDepthRangeArrayv.Invoke(first, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthRangeIndexed(uint index, double n, double f);
        private readonly GLDepthRangeIndexed glDepthRangeIndexed;

        public void DepthRangeIndexed(uint index, double n, double f) =>
            this.glDepthRangeIndexed.Invoke(index, n, f);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetFloati_v(GetPName target, uint index, float* data);
        private readonly GLGetFloati_v glGetFloati_v;

        public unsafe void GetFloati_v(GetPName target, uint index, float* data) =>
            this.glGetFloati_v.Invoke(target, index, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetDoublei_v(GetPName target, uint index, double* data);
        private readonly GLGetDoublei_v glGetDoublei_v;

        public unsafe void GetDoublei_v(GetPName target, uint index, double* data) =>
            this.glGetDoublei_v.Invoke(target, index, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDepthRangeArraydvNV(uint first, int count, /*const*/ double* v);
        private readonly GLDepthRangeArraydvNV glDepthRangeArraydvNV;

        [GLExtension("GL_ARB_viewport_array")]
        public unsafe void DepthRangeArraydvNV(uint first, int count, /*const*/ double* v) =>
            this.glDepthRangeArraydvNV.Invoke(first, count, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthRangeIndexeddNV(uint index, double n, double f);
        private readonly GLDepthRangeIndexeddNV glDepthRangeIndexeddNV;

        [GLExtension("GL_ARB_viewport_array")]
        public void DepthRangeIndexeddNV(uint index, double n, double f) =>
            this.glDepthRangeIndexeddNV.Invoke(index, n, f);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos2dARB(double x, double y);
        private readonly GLWindowPos2dARB glWindowPos2dARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos2dARB(double x, double y) =>
            this.glWindowPos2dARB.Invoke(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos2dvARB(/*const*/ double* v);
        private readonly GLWindowPos2dvARB glWindowPos2dvARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos2dvARB(/*const*/ double* v) =>
            this.glWindowPos2dvARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos2fARB(float x, float y);
        private readonly GLWindowPos2fARB glWindowPos2fARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos2fARB(float x, float y) =>
            this.glWindowPos2fARB.Invoke(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos2fvARB(/*const*/ float* v);
        private readonly GLWindowPos2fvARB glWindowPos2fvARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos2fvARB(/*const*/ float* v) =>
            this.glWindowPos2fvARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos2iARB(int x, int y);
        private readonly GLWindowPos2iARB glWindowPos2iARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos2iARB(int x, int y) =>
            this.glWindowPos2iARB.Invoke(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos2ivARB(/*const*/ int* v);
        private readonly GLWindowPos2ivARB glWindowPos2ivARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos2ivARB(/*const*/ int* v) =>
            this.glWindowPos2ivARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos2sARB(short x, short y);
        private readonly GLWindowPos2sARB glWindowPos2sARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos2sARB(short x, short y) =>
            this.glWindowPos2sARB.Invoke(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos2svARB(/*const*/ short* v);
        private readonly GLWindowPos2svARB glWindowPos2svARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos2svARB(/*const*/ short* v) =>
            this.glWindowPos2svARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos3dARB(double x, double y, double z);
        private readonly GLWindowPos3dARB glWindowPos3dARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos3dARB(double x, double y, double z) =>
            this.glWindowPos3dARB.Invoke(x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos3dvARB(/*const*/ double* v);
        private readonly GLWindowPos3dvARB glWindowPos3dvARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos3dvARB(/*const*/ double* v) =>
            this.glWindowPos3dvARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos3fARB(float x, float y, float z);
        private readonly GLWindowPos3fARB glWindowPos3fARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos3fARB(float x, float y, float z) =>
            this.glWindowPos3fARB.Invoke(x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos3fvARB(/*const*/ float* v);
        private readonly GLWindowPos3fvARB glWindowPos3fvARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos3fvARB(/*const*/ float* v) =>
            this.glWindowPos3fvARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos3iARB(int x, int y, int z);
        private readonly GLWindowPos3iARB glWindowPos3iARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos3iARB(int x, int y, int z) =>
            this.glWindowPos3iARB.Invoke(x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos3ivARB(/*const*/ int* v);
        private readonly GLWindowPos3ivARB glWindowPos3ivARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos3ivARB(/*const*/ int* v) =>
            this.glWindowPos3ivARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLWindowPos3sARB(short x, short y, short z);
        private readonly GLWindowPos3sARB glWindowPos3sARB;

        [GLExtension("GL_ARB_window_pos")]
        public void WindowPos3sARB(short x, short y, short z) =>
            this.glWindowPos3sARB.Invoke(x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLWindowPos3svARB(/*const*/ short* v);
        private readonly GLWindowPos3svARB glWindowPos3svARB;

        [GLExtension("GL_ARB_window_pos")]
        public unsafe void WindowPos3svARB(/*const*/ short* v) =>
            this.glWindowPos3svARB.Invoke(v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendBarrierKHR();
        private readonly GLBlendBarrierKHR glBlendBarrierKHR;

        [GLExtension("GL_KHR_blend_equation_advanced")]
        public void BlendBarrierKHR() =>
            this.glBlendBarrierKHR.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled);
        private readonly GLDebugMessageControl glDebugMessageControl;

        public unsafe void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled) =>
            this.glDebugMessageControl.Invoke(source, type, severity, count, ids, enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf);
        private readonly GLDebugMessageInsert glDebugMessageInsert;

        public unsafe void DebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf) =>
            this.glDebugMessageInsert.Invoke(source, type, id, severity, length, buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageCallback(DebugProc callback, nint userParam);
        private readonly GLDebugMessageCallback glDebugMessageCallback;

        public void DebugMessageCallback(DebugProc callback, nint userParam) =>
            this.glDebugMessageCallback.Invoke(callback, userParam);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetDebugMessageLog(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog);
        private readonly GLGetDebugMessageLog glGetDebugMessageLog;

        public unsafe uint GetDebugMessageLog(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog) =>
            this.glGetDebugMessageLog.Invoke(count, bufSize, sources, types, ids, severities, lengths, messageLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPushDebugGroup(DebugSource source, uint id, int length, /*const*/ sbyte* message);
        private readonly GLPushDebugGroup glPushDebugGroup;

        public unsafe void PushDebugGroup(DebugSource source, uint id, int length, /*const*/ sbyte* message) =>
            this.glPushDebugGroup.Invoke(source, id, length, message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPopDebugGroup();
        private readonly GLPopDebugGroup glPopDebugGroup;

        public void PopDebugGroup() =>
            this.glPopDebugGroup.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLObjectLabel(ObjectIdentifier identifier, uint name, int length, /*const*/ sbyte* label);
        private readonly GLObjectLabel glObjectLabel;

        public unsafe void ObjectLabel(ObjectIdentifier identifier, uint name, int length, /*const*/ sbyte* label) =>
            this.glObjectLabel.Invoke(identifier, name, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, int* length, sbyte* label);
        private readonly GLGetObjectLabel glGetObjectLabel;

        public unsafe void GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, int* length, sbyte* label) =>
            this.glGetObjectLabel.Invoke(identifier, name, bufSize, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLObjectPtrLabel(nint ptr, int length, /*const*/ sbyte* label);
        private readonly GLObjectPtrLabel glObjectPtrLabel;

        public unsafe void ObjectPtrLabel(nint ptr, int length, /*const*/ sbyte* label) =>
            this.glObjectPtrLabel.Invoke(ptr, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectPtrLabel(nint ptr, int bufSize, int* length, sbyte* label);
        private readonly GLGetObjectPtrLabel glGetObjectPtrLabel;

        public unsafe void GetObjectPtrLabel(nint ptr, int bufSize, int* length, sbyte* label) =>
            this.glGetObjectPtrLabel.Invoke(ptr, bufSize, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled);
        private readonly GLDebugMessageControlKHR glDebugMessageControlKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void DebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, /*const*/ uint* ids, bool enabled) =>
            this.glDebugMessageControlKHR.Invoke(source, type, severity, count, ids, enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDebugMessageInsertKHR(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf);
        private readonly GLDebugMessageInsertKHR glDebugMessageInsertKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void DebugMessageInsertKHR(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, /*const*/ sbyte* buf) =>
            this.glDebugMessageInsertKHR.Invoke(source, type, id, severity, length, buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageCallbackKHR(DebugProc callback, nint userParam);
        private readonly GLDebugMessageCallbackKHR glDebugMessageCallbackKHR;

        [GLExtension("GL_KHR_debug")]
        public void DebugMessageCallbackKHR(DebugProc callback, nint userParam) =>
            this.glDebugMessageCallbackKHR.Invoke(callback, userParam);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate uint GLGetDebugMessageLogKHR(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog);
        private readonly GLGetDebugMessageLogKHR glGetDebugMessageLogKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe uint GetDebugMessageLogKHR(uint count, int bufSize, DebugSource* sources, DebugType* types, uint* ids, DebugSeverity* severities, int* lengths, sbyte* messageLog) =>
            this.glGetDebugMessageLogKHR.Invoke(count, bufSize, sources, types, ids, severities, lengths, messageLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPushDebugGroupKHR(DebugSource source, uint id, int length, /*const*/ sbyte* message);
        private readonly GLPushDebugGroupKHR glPushDebugGroupKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void PushDebugGroupKHR(DebugSource source, uint id, int length, /*const*/ sbyte* message) =>
            this.glPushDebugGroupKHR.Invoke(source, id, length, message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPopDebugGroupKHR();
        private readonly GLPopDebugGroupKHR glPopDebugGroupKHR;

        [GLExtension("GL_KHR_debug")]
        public void PopDebugGroupKHR() =>
            this.glPopDebugGroupKHR.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLObjectLabelKHR(ObjectIdentifier identifier, uint name, int length, /*const*/ sbyte* label);
        private readonly GLObjectLabelKHR glObjectLabelKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void ObjectLabelKHR(ObjectIdentifier identifier, uint name, int length, /*const*/ sbyte* label) =>
            this.glObjectLabelKHR.Invoke(identifier, name, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectLabelKHR(int identifier, uint name, int bufSize, int* length, sbyte* label);
        private readonly GLGetObjectLabelKHR glGetObjectLabelKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void GetObjectLabelKHR(int identifier, uint name, int bufSize, int* length, sbyte* label) =>
            this.glGetObjectLabelKHR.Invoke(identifier, name, bufSize, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLObjectPtrLabelKHR(nint ptr, int length, /*const*/ sbyte* label);
        private readonly GLObjectPtrLabelKHR glObjectPtrLabelKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void ObjectPtrLabelKHR(nint ptr, int length, /*const*/ sbyte* label) =>
            this.glObjectPtrLabelKHR.Invoke(ptr, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetObjectPtrLabelKHR(nint ptr, int bufSize, int* length, sbyte* label);
        private readonly GLGetObjectPtrLabelKHR glGetObjectPtrLabelKHR;

        [GLExtension("GL_KHR_debug")]
        public unsafe void GetObjectPtrLabelKHR(nint ptr, int bufSize, int* length, sbyte* label) =>
            this.glGetObjectPtrLabelKHR.Invoke(ptr, bufSize, length, label);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetPointervKHR(int pname, out nint @params);
        private readonly GLGetPointervKHR glGetPointervKHR;

        [GLExtension("GL_KHR_debug")]
        public void GetPointervKHR(int pname, out nint @params) =>
            this.glGetPointervKHR.Invoke(pname, out @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus GLGetGraphicsResetStatus();
        private readonly GLGetGraphicsResetStatus glGetGraphicsResetStatus;

        public GraphicsResetStatus GetGraphicsResetStatus() =>
            this.glGetGraphicsResetStatus.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data);
        private readonly GLReadnPixels glReadnPixels;

        public void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data) =>
            this.glReadnPixels.Invoke(x, y, width, height, format, type, bufSize, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformfv(uint program, int location, int bufSize, float* @params);
        private readonly GLGetnUniformfv glGetnUniformfv;

        public unsafe void GetnUniformfv(uint program, int location, int bufSize, float* @params) =>
            this.glGetnUniformfv.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformiv(uint program, int location, int bufSize, int* @params);
        private readonly GLGetnUniformiv glGetnUniformiv;

        public unsafe void GetnUniformiv(uint program, int location, int bufSize, int* @params) =>
            this.glGetnUniformiv.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformuiv(uint program, int location, int bufSize, uint* @params);
        private readonly GLGetnUniformuiv glGetnUniformuiv;

        public unsafe void GetnUniformuiv(uint program, int location, int bufSize, uint* @params) =>
            this.glGetnUniformuiv.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus GLGetGraphicsResetStatusKHR();
        private readonly GLGetGraphicsResetStatusKHR glGetGraphicsResetStatusKHR;

        [GLExtension("GL_KHR_robustness")]
        public GraphicsResetStatus GetGraphicsResetStatusKHR() =>
            this.glGetGraphicsResetStatusKHR.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadnPixelsKHR(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data);
        private readonly GLReadnPixelsKHR glReadnPixelsKHR;

        [GLExtension("GL_KHR_robustness")]
        public void ReadnPixelsKHR(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data) =>
            this.glReadnPixelsKHR.Invoke(x, y, width, height, format, type, bufSize, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformfvKHR(uint program, int location, int bufSize, float* @params);
        private readonly GLGetnUniformfvKHR glGetnUniformfvKHR;

        [GLExtension("GL_KHR_robustness")]
        public unsafe void GetnUniformfvKHR(uint program, int location, int bufSize, float* @params) =>
            this.glGetnUniformfvKHR.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformivKHR(uint program, int location, int bufSize, int* @params);
        private readonly GLGetnUniformivKHR glGetnUniformivKHR;

        [GLExtension("GL_KHR_robustness")]
        public unsafe void GetnUniformivKHR(uint program, int location, int bufSize, int* @params) =>
            this.glGetnUniformivKHR.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetnUniformuivKHR(uint program, int location, int bufSize, uint* @params);
        private readonly GLGetnUniformuivKHR glGetnUniformuivKHR;

        [GLExtension("GL_KHR_robustness")]
        public unsafe void GetnUniformuivKHR(uint program, int location, int bufSize, uint* @params) =>
            this.glGetnUniformuivKHR.Invoke(program, location, bufSize, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMaxShaderCompilerThreadsKHR(uint count);
        private readonly GLMaxShaderCompilerThreadsKHR glMaxShaderCompilerThreadsKHR;

        [GLExtension("GL_KHR_parallel_shader_compile")]
        public void MaxShaderCompilerThreadsKHR(uint count) =>
            this.glMaxShaderCompilerThreadsKHR.Invoke(count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int baseViewIndex, int numViews);
        private readonly GLFramebufferTextureMultiviewOVR glFramebufferTextureMultiviewOVR;

        [GLExtension("GL_OVR_multiview")]
        public void FramebufferTextureMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int baseViewIndex, int numViews) =>
            this.glFramebufferTextureMultiviewOVR.Invoke(target, attachment, texture, level, baseViewIndex, numViews);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureMultisampleMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int samples, int baseViewIndex, int numViews);
        private readonly GLFramebufferTextureMultisampleMultiviewOVR glFramebufferTextureMultisampleMultiviewOVR;

        [GLExtension("GL_OVR_multiview_multisampled_render_to_texture")]
        public void FramebufferTextureMultisampleMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int samples, int baseViewIndex, int numViews) =>
            this.glFramebufferTextureMultisampleMultiviewOVR.Invoke(target, attachment, texture, level, samples, baseViewIndex, numViews);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArrays(PrimitiveType mode, int first, int count);
        private readonly GLDrawArrays glDrawArrays;

        public void DrawArrays(PrimitiveType mode, int first, int count) =>
            this.glDrawArrays.Invoke(mode, first, count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElements(PrimitiveType mode, int count, DrawElementsType type, nint indices);
        private readonly GLDrawElements glDrawElements;

        public void DrawElements(PrimitiveType mode, int count, DrawElementsType type, nint indices) =>
            this.glDrawElements.Invoke(mode, count, type, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPolygonOffset(float factor, float units);
        private readonly GLPolygonOffset glPolygonOffset;

        public void PolygonOffset(float factor, float units) =>
            this.glPolygonOffset.Invoke(factor, units);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int border);
        private readonly GLCopyTexImage1D glCopyTexImage1D;

        public void CopyTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int border) =>
            this.glCopyTexImage1D.Invoke(target, level, internalformat, x, y, width, border);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border);
        private readonly GLCopyTexImage2D glCopyTexImage2D;

        public void CopyTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border) =>
            this.glCopyTexImage2D.Invoke(target, level, internalformat, x, y, width, height, border);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage1D(TextureTarget target, int level, int xoffset, int x, int y, int width);
        private readonly GLCopyTexSubImage1D glCopyTexSubImage1D;

        public void CopyTexSubImage1D(TextureTarget target, int level, int xoffset, int x, int y, int width) =>
            this.glCopyTexSubImage1D.Invoke(target, level, xoffset, x, y, width);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        private readonly GLCopyTexSubImage2D glCopyTexSubImage2D;

        public void CopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height) =>
            this.glCopyTexSubImage2D.Invoke(target, level, xoffset, yoffset, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage1D(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexSubImage1D glTexSubImage1D;

        public void TexSubImage1D(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexSubImage1D.Invoke(target, level, xoffset, width, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexSubImage2D glTexSubImage2D;

        public void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindTexture(TextureTarget target, uint texture);
        private readonly GLBindTexture glBindTexture;

        public void BindTexture(TextureTarget target, uint texture) =>
            this.glBindTexture.Invoke(target, texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteTextures(int n, /*const*/ uint* textures);
        private readonly GLDeleteTextures glDeleteTextures;

        public unsafe void DeleteTextures(int n, /*const*/ uint* textures) =>
            this.glDeleteTextures.Invoke(n, textures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenTextures(int n, uint* textures);
        private readonly GLGenTextures glGenTextures;

        public unsafe void GenTextures(int n, uint* textures) =>
            this.glGenTextures.Invoke(n, textures);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsTexture(uint texture);
        private readonly GLIsTexture glIsTexture;

        public bool IsTexture(uint texture) =>
            this.glIsTexture.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawRangeElements(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices);
        private readonly GLDrawRangeElements glDrawRangeElements;

        public void DrawRangeElements(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices) =>
            this.glDrawRangeElements.Invoke(mode, start, end, count, type, indices);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage3D(TextureTarget target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexImage3D glTexImage3D;

        public void TexImage3D(TextureTarget target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels);
        private readonly GLTexSubImage3D glTexSubImage3D;

        public void TexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels) =>
            this.glTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        private readonly GLCopyTexSubImage3D glCopyTexSubImage3D;

        public void CopyTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height) =>
            this.glCopyTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, x, y, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLActiveTexture(TextureUnit texture);
        private readonly GLActiveTexture glActiveTexture;

        public void ActiveTexture(TextureUnit texture) =>
            this.glActiveTexture.Invoke(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSampleCoverage(float value, bool invert);
        private readonly GLSampleCoverage glSampleCoverage;

        public void SampleCoverage(float value, bool invert) =>
            this.glSampleCoverage.Invoke(value, invert);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage3D glCompressedTexImage3D;

        public void CompressedTexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data) =>
            this.glCompressedTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage2D glCompressedTexImage2D;

        public void CompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data) =>
            this.glCompressedTexImage2D.Invoke(target, level, internalformat, width, height, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data);
        private readonly GLCompressedTexImage1D glCompressedTexImage1D;

        public void CompressedTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data) =>
            this.glCompressedTexImage1D.Invoke(target, level, internalformat, width, border, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage3D glCompressedTexSubImage3D;

        public void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage2D glCompressedTexSubImage2D;

        public void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data);
        private readonly GLCompressedTexSubImage1D glCompressedTexSubImage1D;

        public void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data) =>
            this.glCompressedTexSubImage1D.Invoke(target, level, xoffset, width, format, imageSize, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetCompressedTexImage(TextureTarget target, int level, out nint img);
        private readonly GLGetCompressedTexImage glGetCompressedTexImage;

        public void GetCompressedTexImage(TextureTarget target, int level, out nint img) =>
            this.glGetCompressedTexImage.Invoke(target, level, out img);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
        private readonly GLBlendFuncSeparate glBlendFuncSeparate;

        public void BlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha) =>
            this.glBlendFuncSeparate.Invoke(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiDrawArrays(PrimitiveType mode, /*const*/ int* first, /*const*/ int* count, int drawcount);
        private readonly GLMultiDrawArrays glMultiDrawArrays;

        public unsafe void MultiDrawArrays(PrimitiveType mode, /*const*/ int* first, /*const*/ int* count, int drawcount) =>
            this.glMultiDrawArrays.Invoke(mode, first, count, drawcount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLMultiDrawElements(PrimitiveType mode, /*const*/ int* count, DrawElementsType type, nint indices, int drawcount);
        private readonly GLMultiDrawElements glMultiDrawElements;

        public unsafe void MultiDrawElements(PrimitiveType mode, /*const*/ int* count, DrawElementsType type, nint indices, int drawcount) =>
            this.glMultiDrawElements.Invoke(mode, count, type, indices, drawcount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameterf(PointParameterNameARB pname, float param);
        private readonly GLPointParameterf glPointParameterf;

        public void PointParameterf(PointParameterNameARB pname, float param) =>
            this.glPointParameterf.Invoke(pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPointParameterfv(PointParameterNameARB pname, /*const*/ float* @params);
        private readonly GLPointParameterfv glPointParameterfv;

        public unsafe void PointParameterfv(PointParameterNameARB pname, /*const*/ float* @params) =>
            this.glPointParameterfv.Invoke(pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameteri(PointParameterNameARB pname, int param);
        private readonly GLPointParameteri glPointParameteri;

        public void PointParameteri(PointParameterNameARB pname, int param) =>
            this.glPointParameteri.Invoke(pname, param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLPointParameteriv(PointParameterNameARB pname, /*const*/ int* @params);
        private readonly GLPointParameteriv glPointParameteriv;

        public unsafe void PointParameteriv(PointParameterNameARB pname, /*const*/ int* @params) =>
            this.glPointParameteriv.Invoke(pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMinSampleShading(float value);
        private readonly GLMinSampleShading glMinSampleShading;

        public void MinSampleShading(float value) =>
            this.glMinSampleShading.Invoke(value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPrimitiveBoundingBox(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW);
        private readonly GLPrimitiveBoundingBox glPrimitiveBoundingBox;

        public void PrimitiveBoundingBox(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW) =>
            this.glPrimitiveBoundingBox.Invoke(minX, minY, minZ, minW, maxX, maxY, maxZ, maxW);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFuncSeparatei(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
        private readonly GLBlendFuncSeparatei glBlendFuncSeparatei;

        public void BlendFuncSeparatei(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha) =>
            this.glBlendFuncSeparatei.Invoke(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFunci(uint buf, BlendingFactor src, BlendingFactor dst);
        private readonly GLBlendFunci glBlendFunci;

        public void BlendFunci(uint buf, BlendingFactor src, BlendingFactor dst) =>
            this.glBlendFunci.Invoke(buf, src, dst);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationSeparatei(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        private readonly GLBlendEquationSeparatei glBlendEquationSeparatei;

        public void BlendEquationSeparatei(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha) =>
            this.glBlendEquationSeparatei.Invoke(buf, modeRGB, modeAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationi(uint buf, BlendEquationModeEXT mode);
        private readonly GLBlendEquationi glBlendEquationi;

        public void BlendEquationi(uint buf, BlendEquationModeEXT mode) =>
            this.glBlendEquationi.Invoke(buf, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendBarrier();
        private readonly GLBlendBarrier glBlendBarrier;

        public void BlendBarrier() =>
            this.glBlendBarrier.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribDivisor(uint index, uint divisor);
        private readonly GLVertexAttribDivisor glVertexAttribDivisor;

        public void VertexAttribDivisor(uint index, uint divisor) =>
            this.glVertexAttribDivisor.Invoke(index, divisor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetPointerv(GetPointervPName pname, out nint @params);
        private readonly GLGetPointerv glGetPointerv;

        public void GetPointerv(GetPointervPName pname, out nint @params) =>
            this.glGetPointerv.Invoke(pname, out @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenQueries(int n, uint* ids);
        private readonly GLGenQueries glGenQueries;

        public unsafe void GenQueries(int n, uint* ids) =>
            this.glGenQueries.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteQueries(int n, /*const*/ uint* ids);
        private readonly GLDeleteQueries glDeleteQueries;

        public unsafe void DeleteQueries(int n, /*const*/ uint* ids) =>
            this.glDeleteQueries.Invoke(n, ids);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsQuery(uint id);
        private readonly GLIsQuery glIsQuery;

        public bool IsQuery(uint id) =>
            this.glIsQuery.Invoke(id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginQuery(QueryTarget target, uint id);
        private readonly GLBeginQuery glBeginQuery;

        public void BeginQuery(QueryTarget target, uint id) =>
            this.glBeginQuery.Invoke(target, id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndQuery(QueryTarget target);
        private readonly GLEndQuery glEndQuery;

        public void EndQuery(QueryTarget target) =>
            this.glEndQuery.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryiv(QueryTarget target, QueryParameterName pname, int* @params);
        private readonly GLGetQueryiv glGetQueryiv;

        public unsafe void GetQueryiv(QueryTarget target, QueryParameterName pname, int* @params) =>
            this.glGetQueryiv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjectiv(uint id, QueryObjectParameterName pname, int* @params);
        private readonly GLGetQueryObjectiv glGetQueryObjectiv;

        public unsafe void GetQueryObjectiv(uint id, QueryObjectParameterName pname, int* @params) =>
            this.glGetQueryObjectiv.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetQueryObjectuiv(uint id, QueryObjectParameterName pname, uint* @params);
        private readonly GLGetQueryObjectuiv glGetQueryObjectuiv;

        public unsafe void GetQueryObjectuiv(uint id, QueryObjectParameterName pname, uint* @params) =>
            this.glGetQueryObjectuiv.Invoke(id, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindBuffer(BufferTargetARB target, uint buffer);
        private readonly GLBindBuffer glBindBuffer;

        public void BindBuffer(BufferTargetARB target, uint buffer) =>
            this.glBindBuffer.Invoke(target, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDeleteBuffers(int n, /*const*/ uint* buffers);
        private readonly GLDeleteBuffers glDeleteBuffers;

        public unsafe void DeleteBuffers(int n, /*const*/ uint* buffers) =>
            this.glDeleteBuffers.Invoke(n, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGenBuffers(int n, uint* buffers);
        private readonly GLGenBuffers glGenBuffers;

        public unsafe void GenBuffers(int n, uint* buffers) =>
            this.glGenBuffers.Invoke(n, buffers);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsBuffer(uint buffer);
        private readonly GLIsBuffer glIsBuffer;

        public bool IsBuffer(uint buffer) =>
            this.glIsBuffer.Invoke(buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferData(BufferTargetARB target, nint size, nint data, BufferUsageARB usage);
        private readonly GLBufferData glBufferData;

        public void BufferData(BufferTargetARB target, nint size, nint data, BufferUsageARB usage) =>
            this.glBufferData.Invoke(target, size, data, usage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferSubData(BufferTargetARB target, nint offset, nint size, nint data);
        private readonly GLBufferSubData glBufferSubData;

        public void BufferSubData(BufferTargetARB target, nint offset, nint size, nint data) =>
            this.glBufferSubData.Invoke(target, offset, size, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferSubData(BufferTargetARB target, nint offset, nint size, out nint data);
        private readonly GLGetBufferSubData glGetBufferSubData;

        public void GetBufferSubData(BufferTargetARB target, nint offset, nint size, out nint data) =>
            this.glGetBufferSubData.Invoke(target, offset, size, out data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapBuffer(BufferTargetARB target, BufferAccessARB access);
        private readonly GLMapBuffer glMapBuffer;

        public nint MapBuffer(BufferTargetARB target, BufferAccessARB access) =>
            this.glMapBuffer.Invoke(target, access);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLUnmapBuffer(BufferTargetARB target);
        private readonly GLUnmapBuffer glUnmapBuffer;

        public bool UnmapBuffer(BufferTargetARB target) =>
            this.glUnmapBuffer.Invoke(target);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetBufferParameteriv(BufferTargetARB target, BufferPNameARB pname, int* @params);
        private readonly GLGetBufferParameteriv glGetBufferParameteriv;

        public unsafe void GetBufferParameteriv(BufferTargetARB target, BufferPNameARB pname, int* @params) =>
            this.glGetBufferParameteriv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferPointerv(BufferTargetARB target, BufferPointerNameARB pname, out nint @params);
        private readonly GLGetBufferPointerv glGetBufferPointerv;

        public void GetBufferPointerv(BufferTargetARB target, BufferPointerNameARB pname, out nint @params) =>
            this.glGetBufferPointerv.Invoke(target, pname, out @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationSeparate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        private readonly GLBlendEquationSeparate glBlendEquationSeparate;

        public void BlendEquationSeparate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha) =>
            this.glBlendEquationSeparate.Invoke(modeRGB, modeAlpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLDrawBuffers(int n, /*const*/ DrawBufferMode* bufs);
        private readonly GLDrawBuffers glDrawBuffers;

        public unsafe void DrawBuffers(int n, /*const*/ DrawBufferMode* bufs) =>
            this.glDrawBuffers.Invoke(n, bufs);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilOpSeparate(TriangleFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
        private readonly GLStencilOpSeparate glStencilOpSeparate;

        public void StencilOpSeparate(TriangleFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass) =>
            this.glStencilOpSeparate.Invoke(face, sfail, dpfail, dppass);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilFuncSeparate(TriangleFace face, StencilFunction func, int @ref, uint mask);
        private readonly GLStencilFuncSeparate glStencilFuncSeparate;

        public void StencilFuncSeparate(TriangleFace face, StencilFunction func, int @ref, uint mask) =>
            this.glStencilFuncSeparate.Invoke(face, func, @ref, mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilMaskSeparate(TriangleFace face, uint mask);
        private readonly GLStencilMaskSeparate glStencilMaskSeparate;

        public void StencilMaskSeparate(TriangleFace face, uint mask) =>
            this.glStencilMaskSeparate.Invoke(face, mask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLAttachShader(uint program, uint shader);
        private readonly GLAttachShader glAttachShader;

        public void AttachShader(uint program, uint shader) =>
            this.glAttachShader.Invoke(program, shader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindAttribLocation(uint program, uint index, /*const*/ sbyte* name);
        private readonly GLBindAttribLocation glBindAttribLocation;

        public unsafe void BindAttribLocation(uint program, uint index, /*const*/ sbyte* name) =>
            this.glBindAttribLocation.Invoke(program, index, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompileShader(uint shader);
        private readonly GLCompileShader glCompileShader;

        public void CompileShader(uint shader) =>
            this.glCompileShader.Invoke(shader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLCreateProgram();
        private readonly GLCreateProgram glCreateProgram;

        public uint CreateProgram() =>
            this.glCreateProgram.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLCreateShader(ShaderType type);
        private readonly GLCreateShader glCreateShader;

        public uint CreateShader(ShaderType type) =>
            this.glCreateShader.Invoke(type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteProgram(uint program);
        private readonly GLDeleteProgram glDeleteProgram;

        public void DeleteProgram(uint program) =>
            this.glDeleteProgram.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteShader(uint shader);
        private readonly GLDeleteShader glDeleteShader;

        public void DeleteShader(uint shader) =>
            this.glDeleteShader.Invoke(shader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDetachShader(uint program, uint shader);
        private readonly GLDetachShader glDetachShader;

        public void DetachShader(uint program, uint shader) =>
            this.glDetachShader.Invoke(program, shader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisableVertexAttribArray(uint index);
        private readonly GLDisableVertexAttribArray glDisableVertexAttribArray;

        public void DisableVertexAttribArray(uint index) =>
            this.glDisableVertexAttribArray.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnableVertexAttribArray(uint index);
        private readonly GLEnableVertexAttribArray glEnableVertexAttribArray;

        public void EnableVertexAttribArray(uint index) =>
            this.glEnableVertexAttribArray.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveAttrib(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, sbyte* name);
        private readonly GLGetActiveAttrib glGetActiveAttrib;

        public unsafe void GetActiveAttrib(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, sbyte* name) =>
            this.glGetActiveAttrib.Invoke(program, index, bufSize, length, size, type, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetActiveUniform(uint program, uint index, int bufSize, int* length, int* size, UniformType* type, sbyte* name);
        private readonly GLGetActiveUniform glGetActiveUniform;

        public unsafe void GetActiveUniform(uint program, uint index, int bufSize, int* length, int* size, UniformType* type, sbyte* name) =>
            this.glGetActiveUniform.Invoke(program, index, bufSize, length, size, type, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetAttachedShaders(uint program, int maxCount, int* count, uint* shaders);
        private readonly GLGetAttachedShaders glGetAttachedShaders;

        public unsafe void GetAttachedShaders(uint program, int maxCount, int* count, uint* shaders) =>
            this.glGetAttachedShaders.Invoke(program, maxCount, count, shaders);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetAttribLocation(uint program, /*const*/ sbyte* name);
        private readonly GLGetAttribLocation glGetAttribLocation;

        public unsafe int GetAttribLocation(uint program, /*const*/ sbyte* name) =>
            this.glGetAttribLocation.Invoke(program, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramiv(uint program, ProgramPropertyARB pname, int* @params);
        private readonly GLGetProgramiv glGetProgramiv;

        public unsafe void GetProgramiv(uint program, ProgramPropertyARB pname, int* @params) =>
            this.glGetProgramiv.Invoke(program, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetProgramInfoLog(uint program, int bufSize, int* length, sbyte* infoLog);
        private readonly GLGetProgramInfoLog glGetProgramInfoLog;

        public unsafe void GetProgramInfoLog(uint program, int bufSize, int* length, sbyte* infoLog) =>
            this.glGetProgramInfoLog.Invoke(program, bufSize, length, infoLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetShaderiv(uint shader, ShaderParameterName pname, int* @params);
        private readonly GLGetShaderiv glGetShaderiv;

        public unsafe void GetShaderiv(uint shader, ShaderParameterName pname, int* @params) =>
            this.glGetShaderiv.Invoke(shader, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetShaderInfoLog(uint shader, int bufSize, int* length, sbyte* infoLog);
        private readonly GLGetShaderInfoLog glGetShaderInfoLog;

        public unsafe void GetShaderInfoLog(uint shader, int bufSize, int* length, sbyte* infoLog) =>
            this.glGetShaderInfoLog.Invoke(shader, bufSize, length, infoLog);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetShaderSource(uint shader, int bufSize, int* length, sbyte* source);
        private readonly GLGetShaderSource glGetShaderSource;

        public unsafe void GetShaderSource(uint shader, int bufSize, int* length, sbyte* source) =>
            this.glGetShaderSource.Invoke(shader, bufSize, length, source);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetUniformLocation(uint program, /*const*/ sbyte* name);
        private readonly GLGetUniformLocation glGetUniformLocation;

        public unsafe int GetUniformLocation(uint program, /*const*/ sbyte* name) =>
            this.glGetUniformLocation.Invoke(program, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformfv(uint program, int location, float* @params);
        private readonly GLGetUniformfv glGetUniformfv;

        public unsafe void GetUniformfv(uint program, int location, float* @params) =>
            this.glGetUniformfv.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformiv(uint program, int location, int* @params);
        private readonly GLGetUniformiv glGetUniformiv;

        public unsafe void GetUniformiv(uint program, int location, int* @params) =>
            this.glGetUniformiv.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribdv(uint index, VertexAttribPropertyARB pname, double* @params);
        private readonly GLGetVertexAttribdv glGetVertexAttribdv;

        public unsafe void GetVertexAttribdv(uint index, VertexAttribPropertyARB pname, double* @params) =>
            this.glGetVertexAttribdv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribfv(uint index, VertexAttribPropertyARB pname, float* @params);
        private readonly GLGetVertexAttribfv glGetVertexAttribfv;

        public unsafe void GetVertexAttribfv(uint index, VertexAttribPropertyARB pname, float* @params) =>
            this.glGetVertexAttribfv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribiv(uint index, VertexAttribPropertyARB pname, int* @params);
        private readonly GLGetVertexAttribiv glGetVertexAttribiv;

        public unsafe void GetVertexAttribiv(uint index, VertexAttribPropertyARB pname, int* @params) =>
            this.glGetVertexAttribiv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribPointerv(uint index, VertexAttribPointerPropertyARB pname, out nint pointer);
        private readonly GLGetVertexAttribPointerv glGetVertexAttribPointerv;

        public void GetVertexAttribPointerv(uint index, VertexAttribPointerPropertyARB pname, out nint pointer) =>
            this.glGetVertexAttribPointerv.Invoke(index, pname, out pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsProgram(uint program);
        private readonly GLIsProgram glIsProgram;

        public bool IsProgram(uint program) =>
            this.glIsProgram.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsShader(uint shader);
        private readonly GLIsShader glIsShader;

        public bool IsShader(uint shader) =>
            this.glIsShader.Invoke(shader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLinkProgram(uint program);
        private readonly GLLinkProgram glLinkProgram;

        public void LinkProgram(uint program) =>
            this.glLinkProgram.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLShaderSource(uint shader, int count, sbyte @string, /*const*/ int* length);
        private readonly GLShaderSource glShaderSource;

        public unsafe void ShaderSource(uint shader, int count, sbyte @string, /*const*/ int* length) =>
            this.glShaderSource.Invoke(shader, count, @string, length);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUseProgram(uint program);
        private readonly GLUseProgram glUseProgram;

        public void UseProgram(uint program) =>
            this.glUseProgram.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1f(int location, float v0);
        private readonly GLUniform1f glUniform1f;

        public void Uniform1f(int location, float v0) =>
            this.glUniform1f.Invoke(location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2f(int location, float v0, float v1);
        private readonly GLUniform2f glUniform2f;

        public void Uniform2f(int location, float v0, float v1) =>
            this.glUniform2f.Invoke(location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3f(int location, float v0, float v1, float v2);
        private readonly GLUniform3f glUniform3f;

        public void Uniform3f(int location, float v0, float v1, float v2) =>
            this.glUniform3f.Invoke(location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4f(int location, float v0, float v1, float v2, float v3);
        private readonly GLUniform4f glUniform4f;

        public void Uniform4f(int location, float v0, float v1, float v2, float v3) =>
            this.glUniform4f.Invoke(location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1i(int location, int v0);
        private readonly GLUniform1i glUniform1i;

        public void Uniform1i(int location, int v0) =>
            this.glUniform1i.Invoke(location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2i(int location, int v0, int v1);
        private readonly GLUniform2i glUniform2i;

        public void Uniform2i(int location, int v0, int v1) =>
            this.glUniform2i.Invoke(location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3i(int location, int v0, int v1, int v2);
        private readonly GLUniform3i glUniform3i;

        public void Uniform3i(int location, int v0, int v1, int v2) =>
            this.glUniform3i.Invoke(location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4i(int location, int v0, int v1, int v2, int v3);
        private readonly GLUniform4i glUniform4i;

        public void Uniform4i(int location, int v0, int v1, int v2, int v3) =>
            this.glUniform4i.Invoke(location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1fv(int location, int count, /*const*/ float* value);
        private readonly GLUniform1fv glUniform1fv;

        public unsafe void Uniform1fv(int location, int count, /*const*/ float* value) =>
            this.glUniform1fv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2fv(int location, int count, /*const*/ float* value);
        private readonly GLUniform2fv glUniform2fv;

        public unsafe void Uniform2fv(int location, int count, /*const*/ float* value) =>
            this.glUniform2fv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3fv(int location, int count, /*const*/ float* value);
        private readonly GLUniform3fv glUniform3fv;

        public unsafe void Uniform3fv(int location, int count, /*const*/ float* value) =>
            this.glUniform3fv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4fv(int location, int count, /*const*/ float* value);
        private readonly GLUniform4fv glUniform4fv;

        public unsafe void Uniform4fv(int location, int count, /*const*/ float* value) =>
            this.glUniform4fv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1iv(int location, int count, /*const*/ int* value);
        private readonly GLUniform1iv glUniform1iv;

        public unsafe void Uniform1iv(int location, int count, /*const*/ int* value) =>
            this.glUniform1iv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2iv(int location, int count, /*const*/ int* value);
        private readonly GLUniform2iv glUniform2iv;

        public unsafe void Uniform2iv(int location, int count, /*const*/ int* value) =>
            this.glUniform2iv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3iv(int location, int count, /*const*/ int* value);
        private readonly GLUniform3iv glUniform3iv;

        public unsafe void Uniform3iv(int location, int count, /*const*/ int* value) =>
            this.glUniform3iv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4iv(int location, int count, /*const*/ int* value);
        private readonly GLUniform4iv glUniform4iv;

        public unsafe void Uniform4iv(int location, int count, /*const*/ int* value) =>
            this.glUniform4iv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix2fv glUniformMatrix2fv;

        public unsafe void UniformMatrix2fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix2fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix3fv glUniformMatrix3fv;

        public unsafe void UniformMatrix3fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix3fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix4fv glUniformMatrix4fv;

        public unsafe void UniformMatrix4fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix4fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLValidateProgram(uint program);
        private readonly GLValidateProgram glValidateProgram;

        public void ValidateProgram(uint program) =>
            this.glValidateProgram.Invoke(program);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1d(uint index, double x);
        private readonly GLVertexAttrib1d glVertexAttrib1d;

        public void VertexAttrib1d(uint index, double x) =>
            this.glVertexAttrib1d.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib1dv glVertexAttrib1dv;

        public unsafe void VertexAttrib1dv(uint index, /*const*/ double* v) =>
            this.glVertexAttrib1dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1f(uint index, float x);
        private readonly GLVertexAttrib1f glVertexAttrib1f;

        public void VertexAttrib1f(uint index, float x) =>
            this.glVertexAttrib1f.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1fv(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib1fv glVertexAttrib1fv;

        public unsafe void VertexAttrib1fv(uint index, /*const*/ float* v) =>
            this.glVertexAttrib1fv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1s(uint index, short x);
        private readonly GLVertexAttrib1s glVertexAttrib1s;

        public void VertexAttrib1s(uint index, short x) =>
            this.glVertexAttrib1s.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib1sv(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib1sv glVertexAttrib1sv;

        public unsafe void VertexAttrib1sv(uint index, /*const*/ short* v) =>
            this.glVertexAttrib1sv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2d(uint index, double x, double y);
        private readonly GLVertexAttrib2d glVertexAttrib2d;

        public void VertexAttrib2d(uint index, double x, double y) =>
            this.glVertexAttrib2d.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib2dv glVertexAttrib2dv;

        public unsafe void VertexAttrib2dv(uint index, /*const*/ double* v) =>
            this.glVertexAttrib2dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2f(uint index, float x, float y);
        private readonly GLVertexAttrib2f glVertexAttrib2f;

        public void VertexAttrib2f(uint index, float x, float y) =>
            this.glVertexAttrib2f.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2fv(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib2fv glVertexAttrib2fv;

        public unsafe void VertexAttrib2fv(uint index, /*const*/ float* v) =>
            this.glVertexAttrib2fv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2s(uint index, short x, short y);
        private readonly GLVertexAttrib2s glVertexAttrib2s;

        public void VertexAttrib2s(uint index, short x, short y) =>
            this.glVertexAttrib2s.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib2sv(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib2sv glVertexAttrib2sv;

        public unsafe void VertexAttrib2sv(uint index, /*const*/ short* v) =>
            this.glVertexAttrib2sv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3d(uint index, double x, double y, double z);
        private readonly GLVertexAttrib3d glVertexAttrib3d;

        public void VertexAttrib3d(uint index, double x, double y, double z) =>
            this.glVertexAttrib3d.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib3dv glVertexAttrib3dv;

        public unsafe void VertexAttrib3dv(uint index, /*const*/ double* v) =>
            this.glVertexAttrib3dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3f(uint index, float x, float y, float z);
        private readonly GLVertexAttrib3f glVertexAttrib3f;

        public void VertexAttrib3f(uint index, float x, float y, float z) =>
            this.glVertexAttrib3f.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3fv(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib3fv glVertexAttrib3fv;

        public unsafe void VertexAttrib3fv(uint index, /*const*/ float* v) =>
            this.glVertexAttrib3fv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3s(uint index, short x, short y, short z);
        private readonly GLVertexAttrib3s glVertexAttrib3s;

        public void VertexAttrib3s(uint index, short x, short y, short z) =>
            this.glVertexAttrib3s.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib3sv(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib3sv glVertexAttrib3sv;

        public unsafe void VertexAttrib3sv(uint index, /*const*/ short* v) =>
            this.glVertexAttrib3sv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Nbv(uint index, /*const*/ sbyte* v);
        private readonly GLVertexAttrib4Nbv glVertexAttrib4Nbv;

        public unsafe void VertexAttrib4Nbv(uint index, /*const*/ sbyte* v) =>
            this.glVertexAttrib4Nbv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Niv(uint index, /*const*/ int* v);
        private readonly GLVertexAttrib4Niv glVertexAttrib4Niv;

        public unsafe void VertexAttrib4Niv(uint index, /*const*/ int* v) =>
            this.glVertexAttrib4Niv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Nsv(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib4Nsv glVertexAttrib4Nsv;

        public unsafe void VertexAttrib4Nsv(uint index, /*const*/ short* v) =>
            this.glVertexAttrib4Nsv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
        private readonly GLVertexAttrib4Nub glVertexAttrib4Nub;

        public void VertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w) =>
            this.glVertexAttrib4Nub.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Nubv(uint index, /*const*/ byte* v);
        private readonly GLVertexAttrib4Nubv glVertexAttrib4Nubv;

        public unsafe void VertexAttrib4Nubv(uint index, /*const*/ byte* v) =>
            this.glVertexAttrib4Nubv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Nuiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttrib4Nuiv glVertexAttrib4Nuiv;

        public unsafe void VertexAttrib4Nuiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttrib4Nuiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4Nusv(uint index, /*const*/ ushort* v);
        private readonly GLVertexAttrib4Nusv glVertexAttrib4Nusv;

        public unsafe void VertexAttrib4Nusv(uint index, /*const*/ ushort* v) =>
            this.glVertexAttrib4Nusv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4bv(uint index, /*const*/ sbyte* v);
        private readonly GLVertexAttrib4bv glVertexAttrib4bv;

        public unsafe void VertexAttrib4bv(uint index, /*const*/ sbyte* v) =>
            this.glVertexAttrib4bv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4d(uint index, double x, double y, double z, double w);
        private readonly GLVertexAttrib4d glVertexAttrib4d;

        public void VertexAttrib4d(uint index, double x, double y, double z, double w) =>
            this.glVertexAttrib4d.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4dv(uint index, /*const*/ double* v);
        private readonly GLVertexAttrib4dv glVertexAttrib4dv;

        public unsafe void VertexAttrib4dv(uint index, /*const*/ double* v) =>
            this.glVertexAttrib4dv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4f(uint index, float x, float y, float z, float w);
        private readonly GLVertexAttrib4f glVertexAttrib4f;

        public void VertexAttrib4f(uint index, float x, float y, float z, float w) =>
            this.glVertexAttrib4f.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4fv(uint index, /*const*/ float* v);
        private readonly GLVertexAttrib4fv glVertexAttrib4fv;

        public unsafe void VertexAttrib4fv(uint index, /*const*/ float* v) =>
            this.glVertexAttrib4fv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4iv(uint index, /*const*/ int* v);
        private readonly GLVertexAttrib4iv glVertexAttrib4iv;

        public unsafe void VertexAttrib4iv(uint index, /*const*/ int* v) =>
            this.glVertexAttrib4iv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4s(uint index, short x, short y, short z, short w);
        private readonly GLVertexAttrib4s glVertexAttrib4s;

        public void VertexAttrib4s(uint index, short x, short y, short z, short w) =>
            this.glVertexAttrib4s.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4sv(uint index, /*const*/ short* v);
        private readonly GLVertexAttrib4sv glVertexAttrib4sv;

        public unsafe void VertexAttrib4sv(uint index, /*const*/ short* v) =>
            this.glVertexAttrib4sv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4ubv(uint index, /*const*/ byte* v);
        private readonly GLVertexAttrib4ubv glVertexAttrib4ubv;

        public unsafe void VertexAttrib4ubv(uint index, /*const*/ byte* v) =>
            this.glVertexAttrib4ubv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4uiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttrib4uiv glVertexAttrib4uiv;

        public unsafe void VertexAttrib4uiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttrib4uiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttrib4usv(uint index, /*const*/ ushort* v);
        private readonly GLVertexAttrib4usv glVertexAttrib4usv;

        public unsafe void VertexAttrib4usv(uint index, /*const*/ ushort* v) =>
            this.glVertexAttrib4usv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer);
        private readonly GLVertexAttribPointer glVertexAttribPointer;

        public void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer) =>
            this.glVertexAttribPointer.Invoke(index, size, type, normalized, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2x3fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix2x3fv glUniformMatrix2x3fv;

        public unsafe void UniformMatrix2x3fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix2x3fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3x2fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix3x2fv glUniformMatrix3x2fv;

        public unsafe void UniformMatrix3x2fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix3x2fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix2x4fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix2x4fv glUniformMatrix2x4fv;

        public unsafe void UniformMatrix2x4fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix2x4fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4x2fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix4x2fv glUniformMatrix4x2fv;

        public unsafe void UniformMatrix4x2fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix4x2fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix3x4fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix3x4fv glUniformMatrix3x4fv;

        public unsafe void UniformMatrix3x4fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix3x4fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniformMatrix4x3fv(int location, int count, bool transpose, /*const*/ float* value);
        private readonly GLUniformMatrix4x3fv glUniformMatrix4x3fv;

        public unsafe void UniformMatrix4x3fv(int location, int count, bool transpose, /*const*/ float* value) =>
            this.glUniformMatrix4x3fv.Invoke(location, count, transpose, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLColorMaski(uint index, bool r, bool g, bool b, bool a);
        private readonly GLColorMaski glColorMaski;

        public void ColorMaski(uint index, bool r, bool g, bool b, bool a) =>
            this.glColorMaski.Invoke(index, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetBooleani_v(BufferTargetARB target, uint index, bool* data);
        private readonly GLGetBooleani_v glGetBooleani_v;

        public unsafe void GetBooleani_v(BufferTargetARB target, uint index, bool* data) =>
            this.glGetBooleani_v.Invoke(target, index, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnablei(EnableCap target, uint index);
        private readonly GLEnablei glEnablei;

        public void Enablei(EnableCap target, uint index) =>
            this.glEnablei.Invoke(target, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisablei(EnableCap target, uint index);
        private readonly GLDisablei glDisablei;

        public void Disablei(EnableCap target, uint index) =>
            this.glDisablei.Invoke(target, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsEnabledi(EnableCap target, uint index);
        private readonly GLIsEnabledi glIsEnabledi;

        public bool IsEnabledi(EnableCap target, uint index) =>
            this.glIsEnabledi.Invoke(target, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginTransformFeedback(PrimitiveType primitiveMode);
        private readonly GLBeginTransformFeedback glBeginTransformFeedback;

        public void BeginTransformFeedback(PrimitiveType primitiveMode) =>
            this.glBeginTransformFeedback.Invoke(primitiveMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndTransformFeedback();
        private readonly GLEndTransformFeedback glEndTransformFeedback;

        public void EndTransformFeedback() =>
            this.glEndTransformFeedback.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTransformFeedbackVaryings(uint program, int count, sbyte varyings, TransformFeedbackBufferMode bufferMode);
        private readonly GLTransformFeedbackVaryings glTransformFeedbackVaryings;

        public unsafe void TransformFeedbackVaryings(uint program, int count, sbyte varyings, TransformFeedbackBufferMode bufferMode) =>
            this.glTransformFeedbackVaryings.Invoke(program, count, varyings, bufferMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTransformFeedbackVarying(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, sbyte* name);
        private readonly GLGetTransformFeedbackVarying glGetTransformFeedbackVarying;

        public unsafe void GetTransformFeedbackVarying(uint program, uint index, int bufSize, int* length, int* size, AttributeType* type, sbyte* name) =>
            this.glGetTransformFeedbackVarying.Invoke(program, index, bufSize, length, size, type, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClampColor(ClampColorTargetARB target, ClampColorModeARB clamp);
        private readonly GLClampColor glClampColor;

        public void ClampColor(ClampColorTargetARB target, ClampColorModeARB clamp) =>
            this.glClampColor.Invoke(target, clamp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginConditionalRender(uint id, ConditionalRenderMode mode);
        private readonly GLBeginConditionalRender glBeginConditionalRender;

        public void BeginConditionalRender(uint id, ConditionalRenderMode mode) =>
            this.glBeginConditionalRender.Invoke(id, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndConditionalRender();
        private readonly GLEndConditionalRender glEndConditionalRender;

        public void EndConditionalRender() =>
            this.glEndConditionalRender.Invoke();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribIPointer(uint index, int size, VertexAttribIType type, int stride, nint pointer);
        private readonly GLVertexAttribIPointer glVertexAttribIPointer;

        public void VertexAttribIPointer(uint index, int size, VertexAttribIType type, int stride, nint pointer) =>
            this.glVertexAttribIPointer.Invoke(index, size, type, stride, pointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribIiv(uint index, VertexAttribEnum pname, int* @params);
        private readonly GLGetVertexAttribIiv glGetVertexAttribIiv;

        public unsafe void GetVertexAttribIiv(uint index, VertexAttribEnum pname, int* @params) =>
            this.glGetVertexAttribIiv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetVertexAttribIuiv(uint index, VertexAttribEnum pname, uint* @params);
        private readonly GLGetVertexAttribIuiv glGetVertexAttribIuiv;

        public unsafe void GetVertexAttribIuiv(uint index, VertexAttribEnum pname, uint* @params) =>
            this.glGetVertexAttribIuiv.Invoke(index, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1i(uint index, int x);
        private readonly GLVertexAttribI1i glVertexAttribI1i;

        public void VertexAttribI1i(uint index, int x) =>
            this.glVertexAttribI1i.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2i(uint index, int x, int y);
        private readonly GLVertexAttribI2i glVertexAttribI2i;

        public void VertexAttribI2i(uint index, int x, int y) =>
            this.glVertexAttribI2i.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3i(uint index, int x, int y, int z);
        private readonly GLVertexAttribI3i glVertexAttribI3i;

        public void VertexAttribI3i(uint index, int x, int y, int z) =>
            this.glVertexAttribI3i.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4i(uint index, int x, int y, int z, int w);
        private readonly GLVertexAttribI4i glVertexAttribI4i;

        public void VertexAttribI4i(uint index, int x, int y, int z, int w) =>
            this.glVertexAttribI4i.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1ui(uint index, uint x);
        private readonly GLVertexAttribI1ui glVertexAttribI1ui;

        public void VertexAttribI1ui(uint index, uint x) =>
            this.glVertexAttribI1ui.Invoke(index, x);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2ui(uint index, uint x, uint y);
        private readonly GLVertexAttribI2ui glVertexAttribI2ui;

        public void VertexAttribI2ui(uint index, uint x, uint y) =>
            this.glVertexAttribI2ui.Invoke(index, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3ui(uint index, uint x, uint y, uint z);
        private readonly GLVertexAttribI3ui glVertexAttribI3ui;

        public void VertexAttribI3ui(uint index, uint x, uint y, uint z) =>
            this.glVertexAttribI3ui.Invoke(index, x, y, z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        private readonly GLVertexAttribI4ui glVertexAttribI4ui;

        public void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w) =>
            this.glVertexAttribI4ui.Invoke(index, x, y, z, w);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI1iv(uint index, /*const*/ int* v);
        private readonly GLVertexAttribI1iv glVertexAttribI1iv;

        public unsafe void VertexAttribI1iv(uint index, /*const*/ int* v) =>
            this.glVertexAttribI1iv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI2iv(uint index, /*const*/ int* v);
        private readonly GLVertexAttribI2iv glVertexAttribI2iv;

        public unsafe void VertexAttribI2iv(uint index, /*const*/ int* v) =>
            this.glVertexAttribI2iv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI3iv(uint index, /*const*/ int* v);
        private readonly GLVertexAttribI3iv glVertexAttribI3iv;

        public unsafe void VertexAttribI3iv(uint index, /*const*/ int* v) =>
            this.glVertexAttribI3iv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4iv(uint index, /*const*/ int* v);
        private readonly GLVertexAttribI4iv glVertexAttribI4iv;

        public unsafe void VertexAttribI4iv(uint index, /*const*/ int* v) =>
            this.glVertexAttribI4iv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI1uiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttribI1uiv glVertexAttribI1uiv;

        public unsafe void VertexAttribI1uiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttribI1uiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI2uiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttribI2uiv glVertexAttribI2uiv;

        public unsafe void VertexAttribI2uiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttribI2uiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI3uiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttribI3uiv glVertexAttribI3uiv;

        public unsafe void VertexAttribI3uiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttribI3uiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4uiv(uint index, /*const*/ uint* v);
        private readonly GLVertexAttribI4uiv glVertexAttribI4uiv;

        public unsafe void VertexAttribI4uiv(uint index, /*const*/ uint* v) =>
            this.glVertexAttribI4uiv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4bv(uint index, /*const*/ sbyte* v);
        private readonly GLVertexAttribI4bv glVertexAttribI4bv;

        public unsafe void VertexAttribI4bv(uint index, /*const*/ sbyte* v) =>
            this.glVertexAttribI4bv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4sv(uint index, /*const*/ short* v);
        private readonly GLVertexAttribI4sv glVertexAttribI4sv;

        public unsafe void VertexAttribI4sv(uint index, /*const*/ short* v) =>
            this.glVertexAttribI4sv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4ubv(uint index, /*const*/ byte* v);
        private readonly GLVertexAttribI4ubv glVertexAttribI4ubv;

        public unsafe void VertexAttribI4ubv(uint index, /*const*/ byte* v) =>
            this.glVertexAttribI4ubv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLVertexAttribI4usv(uint index, /*const*/ ushort* v);
        private readonly GLVertexAttribI4usv glVertexAttribI4usv;

        public unsafe void VertexAttribI4usv(uint index, /*const*/ ushort* v) =>
            this.glVertexAttribI4usv.Invoke(index, v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetUniformuiv(uint program, int location, uint* @params);
        private readonly GLGetUniformuiv glGetUniformuiv;

        public unsafe void GetUniformuiv(uint program, int location, uint* @params) =>
            this.glGetUniformuiv.Invoke(program, location, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLBindFragDataLocation(uint program, uint color, /*const*/ sbyte* name);
        private readonly GLBindFragDataLocation glBindFragDataLocation;

        public unsafe void BindFragDataLocation(uint program, uint color, /*const*/ sbyte* name) =>
            this.glBindFragDataLocation.Invoke(program, color, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int GLGetFragDataLocation(uint program, /*const*/ sbyte* name);
        private readonly GLGetFragDataLocation glGetFragDataLocation;

        public unsafe int GetFragDataLocation(uint program, /*const*/ sbyte* name) =>
            this.glGetFragDataLocation.Invoke(program, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1ui(int location, uint v0);
        private readonly GLUniform1ui glUniform1ui;

        public void Uniform1ui(int location, uint v0) =>
            this.glUniform1ui.Invoke(location, v0);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2ui(int location, uint v0, uint v1);
        private readonly GLUniform2ui glUniform2ui;

        public void Uniform2ui(int location, uint v0, uint v1) =>
            this.glUniform2ui.Invoke(location, v0, v1);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3ui(int location, uint v0, uint v1, uint v2);
        private readonly GLUniform3ui glUniform3ui;

        public void Uniform3ui(int location, uint v0, uint v1, uint v2) =>
            this.glUniform3ui.Invoke(location, v0, v1, v2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);
        private readonly GLUniform4ui glUniform4ui;

        public void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3) =>
            this.glUniform4ui.Invoke(location, v0, v1, v2, v3);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform1uiv(int location, int count, /*const*/ uint* value);
        private readonly GLUniform1uiv glUniform1uiv;

        public unsafe void Uniform1uiv(int location, int count, /*const*/ uint* value) =>
            this.glUniform1uiv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform2uiv(int location, int count, /*const*/ uint* value);
        private readonly GLUniform2uiv glUniform2uiv;

        public unsafe void Uniform2uiv(int location, int count, /*const*/ uint* value) =>
            this.glUniform2uiv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform3uiv(int location, int count, /*const*/ uint* value);
        private readonly GLUniform3uiv glUniform3uiv;

        public unsafe void Uniform3uiv(int location, int count, /*const*/ uint* value) =>
            this.glUniform3uiv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLUniform4uiv(int location, int count, /*const*/ uint* value);
        private readonly GLUniform4uiv glUniform4uiv;

        public unsafe void Uniform4uiv(int location, int count, /*const*/ uint* value) =>
            this.glUniform4uiv.Invoke(location, count, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTexParameterIiv(TextureTarget target, TextureParameterName pname, /*const*/ int* @params);
        private readonly GLTexParameterIiv glTexParameterIiv;

        public unsafe void TexParameterIiv(TextureTarget target, TextureParameterName pname, /*const*/ int* @params) =>
            this.glTexParameterIiv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLTexParameterIuiv(TextureTarget target, TextureParameterName pname, /*const*/ uint* @params);
        private readonly GLTexParameterIuiv glTexParameterIuiv;

        public unsafe void TexParameterIuiv(TextureTarget target, TextureParameterName pname, /*const*/ uint* @params) =>
            this.glTexParameterIuiv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexParameterIiv(TextureTarget target, GetTextureParameter pname, int* @params);
        private readonly GLGetTexParameterIiv glGetTexParameterIiv;

        public unsafe void GetTexParameterIiv(TextureTarget target, GetTextureParameter pname, int* @params) =>
            this.glGetTexParameterIiv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetTexParameterIuiv(TextureTarget target, GetTextureParameter pname, uint* @params);
        private readonly GLGetTexParameterIuiv glGetTexParameterIuiv;

        public unsafe void GetTexParameterIuiv(TextureTarget target, GetTextureParameter pname, uint* @params) =>
            this.glGetTexParameterIuiv.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearBufferiv(Buffer buffer, int drawbuffer, /*const*/ int* value);
        private readonly GLClearBufferiv glClearBufferiv;

        public unsafe void ClearBufferiv(Buffer buffer, int drawbuffer, /*const*/ int* value) =>
            this.glClearBufferiv.Invoke(buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearBufferuiv(Buffer buffer, int drawbuffer, /*const*/ uint* value);
        private readonly GLClearBufferuiv glClearBufferuiv;

        public unsafe void ClearBufferuiv(Buffer buffer, int drawbuffer, /*const*/ uint* value) =>
            this.glClearBufferuiv.Invoke(buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLClearBufferfv(Buffer buffer, int drawbuffer, /*const*/ float* value);
        private readonly GLClearBufferfv glClearBufferfv;

        public unsafe void ClearBufferfv(Buffer buffer, int drawbuffer, /*const*/ float* value) =>
            this.glClearBufferfv.Invoke(buffer, drawbuffer, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferfi(Buffer buffer, int drawbuffer, float depth, int stencil);
        private readonly GLClearBufferfi glClearBufferfi;

        public void ClearBufferfi(Buffer buffer, int drawbuffer, float depth, int stencil) =>
            this.glClearBufferfi.Invoke(buffer, drawbuffer, depth, stencil);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLGetStringi(StringName name, uint index);
        private readonly GLGetStringi glGetStringi;

        public nint GetStringi(StringName name, uint index) =>
            this.glGetStringi.Invoke(name, index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArraysInstanced(PrimitiveType mode, int first, int count, int instancecount);
        private readonly GLDrawArraysInstanced glDrawArraysInstanced;

        public void DrawArraysInstanced(PrimitiveType mode, int first, int count, int instancecount) =>
            this.glDrawArraysInstanced.Invoke(mode, first, count, instancecount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount);
        private readonly GLDrawElementsInstanced glDrawElementsInstanced;

        public void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount) =>
            this.glDrawElementsInstanced.Invoke(mode, count, type, indices, instancecount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexBuffer(TextureTarget target, SizedInternalFormat internalformat, uint buffer);
        private readonly GLTexBuffer glTexBuffer;

        public void TexBuffer(TextureTarget target, SizedInternalFormat internalformat, uint buffer) =>
            this.glTexBuffer.Invoke(target, internalformat, buffer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPrimitiveRestartIndex(uint index);
        private readonly GLPrimitiveRestartIndex glPrimitiveRestartIndex;

        public void PrimitiveRestartIndex(uint index) =>
            this.glPrimitiveRestartIndex.Invoke(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetInteger64i_v(GetPName target, uint index, long* data);
        private readonly GLGetInteger64i_v glGetInteger64i_v;

        public unsafe void GetInteger64i_v(GetPName target, uint index, long* data) =>
            this.glGetInteger64i_v.Invoke(target, index, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void GLGetBufferParameteri64v(BufferTargetARB target, BufferPNameARB pname, long* @params);
        private readonly GLGetBufferParameteri64v glGetBufferParameteri64v;

        public unsafe void GetBufferParameteri64v(BufferTargetARB target, BufferPNameARB pname, long* @params) =>
            this.glGetBufferParameteri64v.Invoke(target, pname, @params);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level);
        private readonly GLFramebufferTexture glFramebufferTexture;

        public void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level) =>
            this.glFramebufferTexture.Invoke(target, attachment, texture, level);

        public OpenGL(GetProcAddressHandler loader)
        {
            glCullFace = Marshal.GetDelegateForFunctionPointer<GLCullFace>(loader.Invoke("glCullFace"));
            glFrontFace = Marshal.GetDelegateForFunctionPointer<GLFrontFace>(loader.Invoke("glFrontFace"));
            glHint = Marshal.GetDelegateForFunctionPointer<GLHint>(loader.Invoke("glHint"));
            glLineWidth = Marshal.GetDelegateForFunctionPointer<GLLineWidth>(loader.Invoke("glLineWidth"));
            glPointSize = Marshal.GetDelegateForFunctionPointer<GLPointSize>(loader.Invoke("glPointSize"));
            glPolygonMode = Marshal.GetDelegateForFunctionPointer<GLPolygonMode>(loader.Invoke("glPolygonMode"));
            glScissor = Marshal.GetDelegateForFunctionPointer<GLScissor>(loader.Invoke("glScissor"));
            glTexParameterf = Marshal.GetDelegateForFunctionPointer<GLTexParameterf>(loader.Invoke("glTexParameterf"));
            glTexParameterfv = Marshal.GetDelegateForFunctionPointer<GLTexParameterfv>(loader.Invoke("glTexParameterfv"));
            glTexParameteri = Marshal.GetDelegateForFunctionPointer<GLTexParameteri>(loader.Invoke("glTexParameteri"));
            glTexParameteriv = Marshal.GetDelegateForFunctionPointer<GLTexParameteriv>(loader.Invoke("glTexParameteriv"));
            glTexImage1D = Marshal.GetDelegateForFunctionPointer<GLTexImage1D>(loader.Invoke("glTexImage1D"));
            glTexImage2D = Marshal.GetDelegateForFunctionPointer<GLTexImage2D>(loader.Invoke("glTexImage2D"));
            glDrawBuffer = Marshal.GetDelegateForFunctionPointer<GLDrawBuffer>(loader.Invoke("glDrawBuffer"));
            glClear = Marshal.GetDelegateForFunctionPointer<GLClear>(loader.Invoke("glClear"));
            glClearColor = Marshal.GetDelegateForFunctionPointer<GLClearColor>(loader.Invoke("glClearColor"));
            glClearStencil = Marshal.GetDelegateForFunctionPointer<GLClearStencil>(loader.Invoke("glClearStencil"));
            glClearDepth = Marshal.GetDelegateForFunctionPointer<GLClearDepth>(loader.Invoke("glClearDepth"));
            glStencilMask = Marshal.GetDelegateForFunctionPointer<GLStencilMask>(loader.Invoke("glStencilMask"));
            glColorMask = Marshal.GetDelegateForFunctionPointer<GLColorMask>(loader.Invoke("glColorMask"));
            glDepthMask = Marshal.GetDelegateForFunctionPointer<GLDepthMask>(loader.Invoke("glDepthMask"));
            glDisable = Marshal.GetDelegateForFunctionPointer<GLDisable>(loader.Invoke("glDisable"));
            glEnable = Marshal.GetDelegateForFunctionPointer<GLEnable>(loader.Invoke("glEnable"));
            glFinish = Marshal.GetDelegateForFunctionPointer<GLFinish>(loader.Invoke("glFinish"));
            glFlush = Marshal.GetDelegateForFunctionPointer<GLFlush>(loader.Invoke("glFlush"));
            glBlendFunc = Marshal.GetDelegateForFunctionPointer<GLBlendFunc>(loader.Invoke("glBlendFunc"));
            glLogicOp = Marshal.GetDelegateForFunctionPointer<GLLogicOp>(loader.Invoke("glLogicOp"));
            glStencilFunc = Marshal.GetDelegateForFunctionPointer<GLStencilFunc>(loader.Invoke("glStencilFunc"));
            glStencilOp = Marshal.GetDelegateForFunctionPointer<GLStencilOp>(loader.Invoke("glStencilOp"));
            glDepthFunc = Marshal.GetDelegateForFunctionPointer<GLDepthFunc>(loader.Invoke("glDepthFunc"));
            glPixelStoref = Marshal.GetDelegateForFunctionPointer<GLPixelStoref>(loader.Invoke("glPixelStoref"));
            glPixelStorei = Marshal.GetDelegateForFunctionPointer<GLPixelStorei>(loader.Invoke("glPixelStorei"));
            glReadBuffer = Marshal.GetDelegateForFunctionPointer<GLReadBuffer>(loader.Invoke("glReadBuffer"));
            glReadPixels = Marshal.GetDelegateForFunctionPointer<GLReadPixels>(loader.Invoke("glReadPixels"));
            glGetBooleanv = Marshal.GetDelegateForFunctionPointer<GLGetBooleanv>(loader.Invoke("glGetBooleanv"));
            glGetDoublev = Marshal.GetDelegateForFunctionPointer<GLGetDoublev>(loader.Invoke("glGetDoublev"));
            glGetError = Marshal.GetDelegateForFunctionPointer<GLGetError>(loader.Invoke("glGetError"));
            glGetFloatv = Marshal.GetDelegateForFunctionPointer<GLGetFloatv>(loader.Invoke("glGetFloatv"));
            glGetIntegerv = Marshal.GetDelegateForFunctionPointer<GLGetIntegerv>(loader.Invoke("glGetIntegerv"));
            glGetString = Marshal.GetDelegateForFunctionPointer<GLGetString>(loader.Invoke("glGetString"));
            glGetTexImage = Marshal.GetDelegateForFunctionPointer<GLGetTexImage>(loader.Invoke("glGetTexImage"));
            glGetTexParameterfv = Marshal.GetDelegateForFunctionPointer<GLGetTexParameterfv>(loader.Invoke("glGetTexParameterfv"));
            glGetTexParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetTexParameteriv>(loader.Invoke("glGetTexParameteriv"));
            glGetTexLevelParameterfv = Marshal.GetDelegateForFunctionPointer<GLGetTexLevelParameterfv>(loader.Invoke("glGetTexLevelParameterfv"));
            glGetTexLevelParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetTexLevelParameteriv>(loader.Invoke("glGetTexLevelParameteriv"));
            glIsEnabled = Marshal.GetDelegateForFunctionPointer<GLIsEnabled>(loader.Invoke("glIsEnabled"));
            glDepthRange = Marshal.GetDelegateForFunctionPointer<GLDepthRange>(loader.Invoke("glDepthRange"));
            glViewport = Marshal.GetDelegateForFunctionPointer<GLViewport>(loader.Invoke("glViewport"));
            glReleaseShaderCompiler = Marshal.GetDelegateForFunctionPointer<GLReleaseShaderCompiler>(loader.Invoke("glReleaseShaderCompiler"));
            glShaderBinary = Marshal.GetDelegateForFunctionPointer<GLShaderBinary>(loader.Invoke("glShaderBinary"));
            glGetShaderPrecisionFormat = Marshal.GetDelegateForFunctionPointer<GLGetShaderPrecisionFormat>(loader.Invoke("glGetShaderPrecisionFormat"));
            glDepthRangef = Marshal.GetDelegateForFunctionPointer<GLDepthRangef>(loader.Invoke("glDepthRangef"));
            glClearDepthf = Marshal.GetDelegateForFunctionPointer<GLClearDepthf>(loader.Invoke("glClearDepthf"));
            glMemoryBarrierByRegion = Marshal.GetDelegateForFunctionPointer<GLMemoryBarrierByRegion>(loader.Invoke("glMemoryBarrierByRegion"));
            glPrimitiveBoundingBoxARB = Marshal.GetDelegateForFunctionPointer<GLPrimitiveBoundingBoxARB>(loader.Invoke("glPrimitiveBoundingBoxARB"));
            glDrawArraysInstancedBaseInstance = Marshal.GetDelegateForFunctionPointer<GLDrawArraysInstancedBaseInstance>(loader.Invoke("glDrawArraysInstancedBaseInstance"));
            glDrawElementsInstancedBaseInstance = Marshal.GetDelegateForFunctionPointer<GLDrawElementsInstancedBaseInstance>(loader.Invoke("glDrawElementsInstancedBaseInstance"));
            glDrawElementsInstancedBaseVertexBaseInstance = Marshal.GetDelegateForFunctionPointer<GLDrawElementsInstancedBaseVertexBaseInstance>(loader.Invoke("glDrawElementsInstancedBaseVertexBaseInstance"));
            glGetTextureHandleARB = Marshal.GetDelegateForFunctionPointer<GLGetTextureHandleARB>(loader.Invoke("glGetTextureHandleARB"));
            glGetTextureSamplerHandleARB = Marshal.GetDelegateForFunctionPointer<GLGetTextureSamplerHandleARB>(loader.Invoke("glGetTextureSamplerHandleARB"));
            glMakeTextureHandleResidentARB = Marshal.GetDelegateForFunctionPointer<GLMakeTextureHandleResidentARB>(loader.Invoke("glMakeTextureHandleResidentARB"));
            glMakeTextureHandleNonResidentARB = Marshal.GetDelegateForFunctionPointer<GLMakeTextureHandleNonResidentARB>(loader.Invoke("glMakeTextureHandleNonResidentARB"));
            glGetImageHandleARB = Marshal.GetDelegateForFunctionPointer<GLGetImageHandleARB>(loader.Invoke("glGetImageHandleARB"));
            glMakeImageHandleResidentARB = Marshal.GetDelegateForFunctionPointer<GLMakeImageHandleResidentARB>(loader.Invoke("glMakeImageHandleResidentARB"));
            glMakeImageHandleNonResidentARB = Marshal.GetDelegateForFunctionPointer<GLMakeImageHandleNonResidentARB>(loader.Invoke("glMakeImageHandleNonResidentARB"));
            glUniformHandleui64ARB = Marshal.GetDelegateForFunctionPointer<GLUniformHandleui64ARB>(loader.Invoke("glUniformHandleui64ARB"));
            glUniformHandleui64vARB = Marshal.GetDelegateForFunctionPointer<GLUniformHandleui64vARB>(loader.Invoke("glUniformHandleui64vARB"));
            glProgramUniformHandleui64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniformHandleui64ARB>(loader.Invoke("glProgramUniformHandleui64ARB"));
            glProgramUniformHandleui64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniformHandleui64vARB>(loader.Invoke("glProgramUniformHandleui64vARB"));
            glIsTextureHandleResidentARB = Marshal.GetDelegateForFunctionPointer<GLIsTextureHandleResidentARB>(loader.Invoke("glIsTextureHandleResidentARB"));
            glIsImageHandleResidentARB = Marshal.GetDelegateForFunctionPointer<GLIsImageHandleResidentARB>(loader.Invoke("glIsImageHandleResidentARB"));
            glVertexAttribL1ui64ARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL1ui64ARB>(loader.Invoke("glVertexAttribL1ui64ARB"));
            glVertexAttribL1ui64vARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL1ui64vARB>(loader.Invoke("glVertexAttribL1ui64vARB"));
            glGetVertexAttribLui64vARB = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribLui64vARB>(loader.Invoke("glGetVertexAttribLui64vARB"));
            glBindFragDataLocationIndexed = Marshal.GetDelegateForFunctionPointer<GLBindFragDataLocationIndexed>(loader.Invoke("glBindFragDataLocationIndexed"));
            glGetFragDataIndex = Marshal.GetDelegateForFunctionPointer<GLGetFragDataIndex>(loader.Invoke("glGetFragDataIndex"));
            glBufferStorage = Marshal.GetDelegateForFunctionPointer<GLBufferStorage>(loader.Invoke("glBufferStorage"));
            glCreateSyncFromCLeventARB = Marshal.GetDelegateForFunctionPointer<GLCreateSyncFromCLeventARB>(loader.Invoke("glCreateSyncFromCLeventARB"));
            glClearBufferData = Marshal.GetDelegateForFunctionPointer<GLClearBufferData>(loader.Invoke("glClearBufferData"));
            glClearBufferSubData = Marshal.GetDelegateForFunctionPointer<GLClearBufferSubData>(loader.Invoke("glClearBufferSubData"));
            glClearTexImage = Marshal.GetDelegateForFunctionPointer<GLClearTexImage>(loader.Invoke("glClearTexImage"));
            glClearTexSubImage = Marshal.GetDelegateForFunctionPointer<GLClearTexSubImage>(loader.Invoke("glClearTexSubImage"));
            glClipControl = Marshal.GetDelegateForFunctionPointer<GLClipControl>(loader.Invoke("glClipControl"));
            glClampColorARB = Marshal.GetDelegateForFunctionPointer<GLClampColorARB>(loader.Invoke("glClampColorARB"));
            glDispatchCompute = Marshal.GetDelegateForFunctionPointer<GLDispatchCompute>(loader.Invoke("glDispatchCompute"));
            glDispatchComputeIndirect = Marshal.GetDelegateForFunctionPointer<GLDispatchComputeIndirect>(loader.Invoke("glDispatchComputeIndirect"));
            glDispatchComputeGroupSizeARB = Marshal.GetDelegateForFunctionPointer<GLDispatchComputeGroupSizeARB>(loader.Invoke("glDispatchComputeGroupSizeARB"));
            glCopyBufferSubData = Marshal.GetDelegateForFunctionPointer<GLCopyBufferSubData>(loader.Invoke("glCopyBufferSubData"));
            glCopyImageSubData = Marshal.GetDelegateForFunctionPointer<GLCopyImageSubData>(loader.Invoke("glCopyImageSubData"));
            glDebugMessageControlARB = Marshal.GetDelegateForFunctionPointer<GLDebugMessageControlARB>(loader.Invoke("glDebugMessageControlARB"));
            glDebugMessageInsertARB = Marshal.GetDelegateForFunctionPointer<GLDebugMessageInsertARB>(loader.Invoke("glDebugMessageInsertARB"));
            glDebugMessageCallbackARB = Marshal.GetDelegateForFunctionPointer<GLDebugMessageCallbackARB>(loader.Invoke("glDebugMessageCallbackARB"));
            glGetDebugMessageLogARB = Marshal.GetDelegateForFunctionPointer<GLGetDebugMessageLogARB>(loader.Invoke("glGetDebugMessageLogARB"));
            glCreateTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<GLCreateTransformFeedbacks>(loader.Invoke("glCreateTransformFeedbacks"));
            glTransformFeedbackBufferBase = Marshal.GetDelegateForFunctionPointer<GLTransformFeedbackBufferBase>(loader.Invoke("glTransformFeedbackBufferBase"));
            glTransformFeedbackBufferRange = Marshal.GetDelegateForFunctionPointer<GLTransformFeedbackBufferRange>(loader.Invoke("glTransformFeedbackBufferRange"));
            glGetTransformFeedbackiv = Marshal.GetDelegateForFunctionPointer<GLGetTransformFeedbackiv>(loader.Invoke("glGetTransformFeedbackiv"));
            glGetTransformFeedbacki_v = Marshal.GetDelegateForFunctionPointer<GLGetTransformFeedbacki_v>(loader.Invoke("glGetTransformFeedbacki_v"));
            glGetTransformFeedbacki64_v = Marshal.GetDelegateForFunctionPointer<GLGetTransformFeedbacki64_v>(loader.Invoke("glGetTransformFeedbacki64_v"));
            glCreateBuffers = Marshal.GetDelegateForFunctionPointer<GLCreateBuffers>(loader.Invoke("glCreateBuffers"));
            glNamedBufferStorage = Marshal.GetDelegateForFunctionPointer<GLNamedBufferStorage>(loader.Invoke("glNamedBufferStorage"));
            glNamedBufferData = Marshal.GetDelegateForFunctionPointer<GLNamedBufferData>(loader.Invoke("glNamedBufferData"));
            glNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<GLNamedBufferSubData>(loader.Invoke("glNamedBufferSubData"));
            glCopyNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<GLCopyNamedBufferSubData>(loader.Invoke("glCopyNamedBufferSubData"));
            glClearNamedBufferData = Marshal.GetDelegateForFunctionPointer<GLClearNamedBufferData>(loader.Invoke("glClearNamedBufferData"));
            glClearNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<GLClearNamedBufferSubData>(loader.Invoke("glClearNamedBufferSubData"));
            glMapNamedBuffer = Marshal.GetDelegateForFunctionPointer<GLMapNamedBuffer>(loader.Invoke("glMapNamedBuffer"));
            glMapNamedBufferRange = Marshal.GetDelegateForFunctionPointer<GLMapNamedBufferRange>(loader.Invoke("glMapNamedBufferRange"));
            glUnmapNamedBuffer = Marshal.GetDelegateForFunctionPointer<GLUnmapNamedBuffer>(loader.Invoke("glUnmapNamedBuffer"));
            glFlushMappedNamedBufferRange = Marshal.GetDelegateForFunctionPointer<GLFlushMappedNamedBufferRange>(loader.Invoke("glFlushMappedNamedBufferRange"));
            glGetNamedBufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetNamedBufferParameteriv>(loader.Invoke("glGetNamedBufferParameteriv"));
            glGetNamedBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<GLGetNamedBufferParameteri64v>(loader.Invoke("glGetNamedBufferParameteri64v"));
            glGetNamedBufferPointerv = Marshal.GetDelegateForFunctionPointer<GLGetNamedBufferPointerv>(loader.Invoke("glGetNamedBufferPointerv"));
            glGetNamedBufferSubData = Marshal.GetDelegateForFunctionPointer<GLGetNamedBufferSubData>(loader.Invoke("glGetNamedBufferSubData"));
            glCreateFramebuffers = Marshal.GetDelegateForFunctionPointer<GLCreateFramebuffers>(loader.Invoke("glCreateFramebuffers"));
            glNamedFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferRenderbuffer>(loader.Invoke("glNamedFramebufferRenderbuffer"));
            glNamedFramebufferParameteri = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferParameteri>(loader.Invoke("glNamedFramebufferParameteri"));
            glNamedFramebufferTexture = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferTexture>(loader.Invoke("glNamedFramebufferTexture"));
            glNamedFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferTextureLayer>(loader.Invoke("glNamedFramebufferTextureLayer"));
            glNamedFramebufferDrawBuffer = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferDrawBuffer>(loader.Invoke("glNamedFramebufferDrawBuffer"));
            glNamedFramebufferDrawBuffers = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferDrawBuffers>(loader.Invoke("glNamedFramebufferDrawBuffers"));
            glNamedFramebufferReadBuffer = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferReadBuffer>(loader.Invoke("glNamedFramebufferReadBuffer"));
            glInvalidateNamedFramebufferData = Marshal.GetDelegateForFunctionPointer<GLInvalidateNamedFramebufferData>(loader.Invoke("glInvalidateNamedFramebufferData"));
            glInvalidateNamedFramebufferSubData = Marshal.GetDelegateForFunctionPointer<GLInvalidateNamedFramebufferSubData>(loader.Invoke("glInvalidateNamedFramebufferSubData"));
            glClearNamedFramebufferiv = Marshal.GetDelegateForFunctionPointer<GLClearNamedFramebufferiv>(loader.Invoke("glClearNamedFramebufferiv"));
            glClearNamedFramebufferuiv = Marshal.GetDelegateForFunctionPointer<GLClearNamedFramebufferuiv>(loader.Invoke("glClearNamedFramebufferuiv"));
            glClearNamedFramebufferfv = Marshal.GetDelegateForFunctionPointer<GLClearNamedFramebufferfv>(loader.Invoke("glClearNamedFramebufferfv"));
            glClearNamedFramebufferfi = Marshal.GetDelegateForFunctionPointer<GLClearNamedFramebufferfi>(loader.Invoke("glClearNamedFramebufferfi"));
            glBlitNamedFramebuffer = Marshal.GetDelegateForFunctionPointer<GLBlitNamedFramebuffer>(loader.Invoke("glBlitNamedFramebuffer"));
            glCheckNamedFramebufferStatus = Marshal.GetDelegateForFunctionPointer<GLCheckNamedFramebufferStatus>(loader.Invoke("glCheckNamedFramebufferStatus"));
            glGetNamedFramebufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetNamedFramebufferParameteriv>(loader.Invoke("glGetNamedFramebufferParameteriv"));
            glGetNamedFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetNamedFramebufferAttachmentParameteriv>(loader.Invoke("glGetNamedFramebufferAttachmentParameteriv"));
            glCreateRenderbuffers = Marshal.GetDelegateForFunctionPointer<GLCreateRenderbuffers>(loader.Invoke("glCreateRenderbuffers"));
            glNamedRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<GLNamedRenderbufferStorage>(loader.Invoke("glNamedRenderbufferStorage"));
            glNamedRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<GLNamedRenderbufferStorageMultisample>(loader.Invoke("glNamedRenderbufferStorageMultisample"));
            glGetNamedRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetNamedRenderbufferParameteriv>(loader.Invoke("glGetNamedRenderbufferParameteriv"));
            glCreateTextures = Marshal.GetDelegateForFunctionPointer<GLCreateTextures>(loader.Invoke("glCreateTextures"));
            glTextureBuffer = Marshal.GetDelegateForFunctionPointer<GLTextureBuffer>(loader.Invoke("glTextureBuffer"));
            glTextureBufferRange = Marshal.GetDelegateForFunctionPointer<GLTextureBufferRange>(loader.Invoke("glTextureBufferRange"));
            glTextureStorage1D = Marshal.GetDelegateForFunctionPointer<GLTextureStorage1D>(loader.Invoke("glTextureStorage1D"));
            glTextureStorage2D = Marshal.GetDelegateForFunctionPointer<GLTextureStorage2D>(loader.Invoke("glTextureStorage2D"));
            glTextureStorage3D = Marshal.GetDelegateForFunctionPointer<GLTextureStorage3D>(loader.Invoke("glTextureStorage3D"));
            glTextureStorage2DMultisample = Marshal.GetDelegateForFunctionPointer<GLTextureStorage2DMultisample>(loader.Invoke("glTextureStorage2DMultisample"));
            glTextureStorage3DMultisample = Marshal.GetDelegateForFunctionPointer<GLTextureStorage3DMultisample>(loader.Invoke("glTextureStorage3DMultisample"));
            glTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<GLTextureSubImage1D>(loader.Invoke("glTextureSubImage1D"));
            glTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<GLTextureSubImage2D>(loader.Invoke("glTextureSubImage2D"));
            glTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<GLTextureSubImage3D>(loader.Invoke("glTextureSubImage3D"));
            glCompressedTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<GLCompressedTextureSubImage1D>(loader.Invoke("glCompressedTextureSubImage1D"));
            glCompressedTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<GLCompressedTextureSubImage2D>(loader.Invoke("glCompressedTextureSubImage2D"));
            glCompressedTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<GLCompressedTextureSubImage3D>(loader.Invoke("glCompressedTextureSubImage3D"));
            glCopyTextureSubImage1D = Marshal.GetDelegateForFunctionPointer<GLCopyTextureSubImage1D>(loader.Invoke("glCopyTextureSubImage1D"));
            glCopyTextureSubImage2D = Marshal.GetDelegateForFunctionPointer<GLCopyTextureSubImage2D>(loader.Invoke("glCopyTextureSubImage2D"));
            glCopyTextureSubImage3D = Marshal.GetDelegateForFunctionPointer<GLCopyTextureSubImage3D>(loader.Invoke("glCopyTextureSubImage3D"));
            glTextureParameterf = Marshal.GetDelegateForFunctionPointer<GLTextureParameterf>(loader.Invoke("glTextureParameterf"));
            glTextureParameterfv = Marshal.GetDelegateForFunctionPointer<GLTextureParameterfv>(loader.Invoke("glTextureParameterfv"));
            glTextureParameteri = Marshal.GetDelegateForFunctionPointer<GLTextureParameteri>(loader.Invoke("glTextureParameteri"));
            glTextureParameterIiv = Marshal.GetDelegateForFunctionPointer<GLTextureParameterIiv>(loader.Invoke("glTextureParameterIiv"));
            glTextureParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLTextureParameterIuiv>(loader.Invoke("glTextureParameterIuiv"));
            glTextureParameteriv = Marshal.GetDelegateForFunctionPointer<GLTextureParameteriv>(loader.Invoke("glTextureParameteriv"));
            glGenerateTextureMipmap = Marshal.GetDelegateForFunctionPointer<GLGenerateTextureMipmap>(loader.Invoke("glGenerateTextureMipmap"));
            glBindTextureUnit = Marshal.GetDelegateForFunctionPointer<GLBindTextureUnit>(loader.Invoke("glBindTextureUnit"));
            glGetTextureImage = Marshal.GetDelegateForFunctionPointer<GLGetTextureImage>(loader.Invoke("glGetTextureImage"));
            glGetCompressedTextureImage = Marshal.GetDelegateForFunctionPointer<GLGetCompressedTextureImage>(loader.Invoke("glGetCompressedTextureImage"));
            glGetTextureLevelParameterfv = Marshal.GetDelegateForFunctionPointer<GLGetTextureLevelParameterfv>(loader.Invoke("glGetTextureLevelParameterfv"));
            glGetTextureLevelParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetTextureLevelParameteriv>(loader.Invoke("glGetTextureLevelParameteriv"));
            glGetTextureParameterfv = Marshal.GetDelegateForFunctionPointer<GLGetTextureParameterfv>(loader.Invoke("glGetTextureParameterfv"));
            glGetTextureParameterIiv = Marshal.GetDelegateForFunctionPointer<GLGetTextureParameterIiv>(loader.Invoke("glGetTextureParameterIiv"));
            glGetTextureParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLGetTextureParameterIuiv>(loader.Invoke("glGetTextureParameterIuiv"));
            glGetTextureParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetTextureParameteriv>(loader.Invoke("glGetTextureParameteriv"));
            glCreateVertexArrays = Marshal.GetDelegateForFunctionPointer<GLCreateVertexArrays>(loader.Invoke("glCreateVertexArrays"));
            glDisableVertexArrayAttrib = Marshal.GetDelegateForFunctionPointer<GLDisableVertexArrayAttrib>(loader.Invoke("glDisableVertexArrayAttrib"));
            glEnableVertexArrayAttrib = Marshal.GetDelegateForFunctionPointer<GLEnableVertexArrayAttrib>(loader.Invoke("glEnableVertexArrayAttrib"));
            glVertexArrayElementBuffer = Marshal.GetDelegateForFunctionPointer<GLVertexArrayElementBuffer>(loader.Invoke("glVertexArrayElementBuffer"));
            glVertexArrayVertexBuffer = Marshal.GetDelegateForFunctionPointer<GLVertexArrayVertexBuffer>(loader.Invoke("glVertexArrayVertexBuffer"));
            glVertexArrayVertexBuffers = Marshal.GetDelegateForFunctionPointer<GLVertexArrayVertexBuffers>(loader.Invoke("glVertexArrayVertexBuffers"));
            glVertexArrayAttribBinding = Marshal.GetDelegateForFunctionPointer<GLVertexArrayAttribBinding>(loader.Invoke("glVertexArrayAttribBinding"));
            glVertexArrayAttribFormat = Marshal.GetDelegateForFunctionPointer<GLVertexArrayAttribFormat>(loader.Invoke("glVertexArrayAttribFormat"));
            glVertexArrayAttribIFormat = Marshal.GetDelegateForFunctionPointer<GLVertexArrayAttribIFormat>(loader.Invoke("glVertexArrayAttribIFormat"));
            glVertexArrayAttribLFormat = Marshal.GetDelegateForFunctionPointer<GLVertexArrayAttribLFormat>(loader.Invoke("glVertexArrayAttribLFormat"));
            glVertexArrayBindingDivisor = Marshal.GetDelegateForFunctionPointer<GLVertexArrayBindingDivisor>(loader.Invoke("glVertexArrayBindingDivisor"));
            glGetVertexArrayiv = Marshal.GetDelegateForFunctionPointer<GLGetVertexArrayiv>(loader.Invoke("glGetVertexArrayiv"));
            glGetVertexArrayIndexediv = Marshal.GetDelegateForFunctionPointer<GLGetVertexArrayIndexediv>(loader.Invoke("glGetVertexArrayIndexediv"));
            glGetVertexArrayIndexed64iv = Marshal.GetDelegateForFunctionPointer<GLGetVertexArrayIndexed64iv>(loader.Invoke("glGetVertexArrayIndexed64iv"));
            glCreateSamplers = Marshal.GetDelegateForFunctionPointer<GLCreateSamplers>(loader.Invoke("glCreateSamplers"));
            glCreateProgramPipelines = Marshal.GetDelegateForFunctionPointer<GLCreateProgramPipelines>(loader.Invoke("glCreateProgramPipelines"));
            glCreateQueries = Marshal.GetDelegateForFunctionPointer<GLCreateQueries>(loader.Invoke("glCreateQueries"));
            glGetQueryBufferObjecti64v = Marshal.GetDelegateForFunctionPointer<GLGetQueryBufferObjecti64v>(loader.Invoke("glGetQueryBufferObjecti64v"));
            glGetQueryBufferObjectiv = Marshal.GetDelegateForFunctionPointer<GLGetQueryBufferObjectiv>(loader.Invoke("glGetQueryBufferObjectiv"));
            glGetQueryBufferObjectui64v = Marshal.GetDelegateForFunctionPointer<GLGetQueryBufferObjectui64v>(loader.Invoke("glGetQueryBufferObjectui64v"));
            glGetQueryBufferObjectuiv = Marshal.GetDelegateForFunctionPointer<GLGetQueryBufferObjectuiv>(loader.Invoke("glGetQueryBufferObjectuiv"));
            glDrawBuffersARB = Marshal.GetDelegateForFunctionPointer<GLDrawBuffersARB>(loader.Invoke("glDrawBuffersARB"));
            glBlendEquationiARB = Marshal.GetDelegateForFunctionPointer<GLBlendEquationiARB>(loader.Invoke("glBlendEquationiARB"));
            glBlendEquationSeparateiARB = Marshal.GetDelegateForFunctionPointer<GLBlendEquationSeparateiARB>(loader.Invoke("glBlendEquationSeparateiARB"));
            glBlendFunciARB = Marshal.GetDelegateForFunctionPointer<GLBlendFunciARB>(loader.Invoke("glBlendFunciARB"));
            glBlendFuncSeparateiARB = Marshal.GetDelegateForFunctionPointer<GLBlendFuncSeparateiARB>(loader.Invoke("glBlendFuncSeparateiARB"));
            glDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<GLDrawElementsBaseVertex>(loader.Invoke("glDrawElementsBaseVertex"));
            glDrawRangeElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<GLDrawRangeElementsBaseVertex>(loader.Invoke("glDrawRangeElementsBaseVertex"));
            glDrawElementsInstancedBaseVertex = Marshal.GetDelegateForFunctionPointer<GLDrawElementsInstancedBaseVertex>(loader.Invoke("glDrawElementsInstancedBaseVertex"));
            glMultiDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<GLMultiDrawElementsBaseVertex>(loader.Invoke("glMultiDrawElementsBaseVertex"));
            glDrawArraysIndirect = Marshal.GetDelegateForFunctionPointer<GLDrawArraysIndirect>(loader.Invoke("glDrawArraysIndirect"));
            glDrawElementsIndirect = Marshal.GetDelegateForFunctionPointer<GLDrawElementsIndirect>(loader.Invoke("glDrawElementsIndirect"));
            glDrawArraysInstancedARB = Marshal.GetDelegateForFunctionPointer<GLDrawArraysInstancedARB>(loader.Invoke("glDrawArraysInstancedARB"));
            glDrawElementsInstancedARB = Marshal.GetDelegateForFunctionPointer<GLDrawElementsInstancedARB>(loader.Invoke("glDrawElementsInstancedARB"));
            glProgramStringARB = Marshal.GetDelegateForFunctionPointer<GLProgramStringARB>(loader.Invoke("glProgramStringARB"));
            glBindProgramARB = Marshal.GetDelegateForFunctionPointer<GLBindProgramARB>(loader.Invoke("glBindProgramARB"));
            glDeleteProgramsARB = Marshal.GetDelegateForFunctionPointer<GLDeleteProgramsARB>(loader.Invoke("glDeleteProgramsARB"));
            glGenProgramsARB = Marshal.GetDelegateForFunctionPointer<GLGenProgramsARB>(loader.Invoke("glGenProgramsARB"));
            glProgramEnvParameter4dARB = Marshal.GetDelegateForFunctionPointer<GLProgramEnvParameter4dARB>(loader.Invoke("glProgramEnvParameter4dARB"));
            glProgramEnvParameter4dvARB = Marshal.GetDelegateForFunctionPointer<GLProgramEnvParameter4dvARB>(loader.Invoke("glProgramEnvParameter4dvARB"));
            glProgramEnvParameter4fARB = Marshal.GetDelegateForFunctionPointer<GLProgramEnvParameter4fARB>(loader.Invoke("glProgramEnvParameter4fARB"));
            glProgramEnvParameter4fvARB = Marshal.GetDelegateForFunctionPointer<GLProgramEnvParameter4fvARB>(loader.Invoke("glProgramEnvParameter4fvARB"));
            glProgramLocalParameter4dARB = Marshal.GetDelegateForFunctionPointer<GLProgramLocalParameter4dARB>(loader.Invoke("glProgramLocalParameter4dARB"));
            glProgramLocalParameter4dvARB = Marshal.GetDelegateForFunctionPointer<GLProgramLocalParameter4dvARB>(loader.Invoke("glProgramLocalParameter4dvARB"));
            glProgramLocalParameter4fARB = Marshal.GetDelegateForFunctionPointer<GLProgramLocalParameter4fARB>(loader.Invoke("glProgramLocalParameter4fARB"));
            glProgramLocalParameter4fvARB = Marshal.GetDelegateForFunctionPointer<GLProgramLocalParameter4fvARB>(loader.Invoke("glProgramLocalParameter4fvARB"));
            glGetProgramEnvParameterdvARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramEnvParameterdvARB>(loader.Invoke("glGetProgramEnvParameterdvARB"));
            glGetProgramEnvParameterfvARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramEnvParameterfvARB>(loader.Invoke("glGetProgramEnvParameterfvARB"));
            glGetProgramLocalParameterdvARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramLocalParameterdvARB>(loader.Invoke("glGetProgramLocalParameterdvARB"));
            glGetProgramLocalParameterfvARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramLocalParameterfvARB>(loader.Invoke("glGetProgramLocalParameterfvARB"));
            glGetProgramivARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramivARB>(loader.Invoke("glGetProgramivARB"));
            glGetProgramStringARB = Marshal.GetDelegateForFunctionPointer<GLGetProgramStringARB>(loader.Invoke("glGetProgramStringARB"));
            glIsProgramARB = Marshal.GetDelegateForFunctionPointer<GLIsProgramARB>(loader.Invoke("glIsProgramARB"));
            glFramebufferParameteri = Marshal.GetDelegateForFunctionPointer<GLFramebufferParameteri>(loader.Invoke("glFramebufferParameteri"));
            glGetFramebufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetFramebufferParameteriv>(loader.Invoke("glGetFramebufferParameteriv"));
            glIsRenderbuffer = Marshal.GetDelegateForFunctionPointer<GLIsRenderbuffer>(loader.Invoke("glIsRenderbuffer"));
            glBindRenderbuffer = Marshal.GetDelegateForFunctionPointer<GLBindRenderbuffer>(loader.Invoke("glBindRenderbuffer"));
            glDeleteRenderbuffers = Marshal.GetDelegateForFunctionPointer<GLDeleteRenderbuffers>(loader.Invoke("glDeleteRenderbuffers"));
            glGenRenderbuffers = Marshal.GetDelegateForFunctionPointer<GLGenRenderbuffers>(loader.Invoke("glGenRenderbuffers"));
            glRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<GLRenderbufferStorage>(loader.Invoke("glRenderbufferStorage"));
            glGetRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetRenderbufferParameteriv>(loader.Invoke("glGetRenderbufferParameteriv"));
            glIsFramebuffer = Marshal.GetDelegateForFunctionPointer<GLIsFramebuffer>(loader.Invoke("glIsFramebuffer"));
            glBindFramebuffer = Marshal.GetDelegateForFunctionPointer<GLBindFramebuffer>(loader.Invoke("glBindFramebuffer"));
            glDeleteFramebuffers = Marshal.GetDelegateForFunctionPointer<GLDeleteFramebuffers>(loader.Invoke("glDeleteFramebuffers"));
            glGenFramebuffers = Marshal.GetDelegateForFunctionPointer<GLGenFramebuffers>(loader.Invoke("glGenFramebuffers"));
            glCheckFramebufferStatus = Marshal.GetDelegateForFunctionPointer<GLCheckFramebufferStatus>(loader.Invoke("glCheckFramebufferStatus"));
            glFramebufferTexture1D = Marshal.GetDelegateForFunctionPointer<GLFramebufferTexture1D>(loader.Invoke("glFramebufferTexture1D"));
            glFramebufferTexture2D = Marshal.GetDelegateForFunctionPointer<GLFramebufferTexture2D>(loader.Invoke("glFramebufferTexture2D"));
            glFramebufferTexture3D = Marshal.GetDelegateForFunctionPointer<GLFramebufferTexture3D>(loader.Invoke("glFramebufferTexture3D"));
            glFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<GLFramebufferRenderbuffer>(loader.Invoke("glFramebufferRenderbuffer"));
            glGetFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetFramebufferAttachmentParameteriv>(loader.Invoke("glGetFramebufferAttachmentParameteriv"));
            glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<GLGenerateMipmap>(loader.Invoke("glGenerateMipmap"));
            glBlitFramebuffer = Marshal.GetDelegateForFunctionPointer<GLBlitFramebuffer>(loader.Invoke("glBlitFramebuffer"));
            glRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<GLRenderbufferStorageMultisample>(loader.Invoke("glRenderbufferStorageMultisample"));
            glFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureLayer>(loader.Invoke("glFramebufferTextureLayer"));
            glProgramParameteriARB = Marshal.GetDelegateForFunctionPointer<GLProgramParameteriARB>(loader.Invoke("glProgramParameteriARB"));
            glFramebufferTextureARB = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureARB>(loader.Invoke("glFramebufferTextureARB"));
            glFramebufferTextureLayerARB = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureLayerARB>(loader.Invoke("glFramebufferTextureLayerARB"));
            glFramebufferTextureFaceARB = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureFaceARB>(loader.Invoke("glFramebufferTextureFaceARB"));
            glGetProgramBinary = Marshal.GetDelegateForFunctionPointer<GLGetProgramBinary>(loader.Invoke("glGetProgramBinary"));
            glProgramBinary = Marshal.GetDelegateForFunctionPointer<GLProgramBinary>(loader.Invoke("glProgramBinary"));
            glProgramParameteri = Marshal.GetDelegateForFunctionPointer<GLProgramParameteri>(loader.Invoke("glProgramParameteri"));
            glGetTextureSubImage = Marshal.GetDelegateForFunctionPointer<GLGetTextureSubImage>(loader.Invoke("glGetTextureSubImage"));
            glGetCompressedTextureSubImage = Marshal.GetDelegateForFunctionPointer<GLGetCompressedTextureSubImage>(loader.Invoke("glGetCompressedTextureSubImage"));
            glSpecializeShaderARB = Marshal.GetDelegateForFunctionPointer<GLSpecializeShaderARB>(loader.Invoke("glSpecializeShaderARB"));
            glUniform1d = Marshal.GetDelegateForFunctionPointer<GLUniform1d>(loader.Invoke("glUniform1d"));
            glUniform2d = Marshal.GetDelegateForFunctionPointer<GLUniform2d>(loader.Invoke("glUniform2d"));
            glUniform3d = Marshal.GetDelegateForFunctionPointer<GLUniform3d>(loader.Invoke("glUniform3d"));
            glUniform4d = Marshal.GetDelegateForFunctionPointer<GLUniform4d>(loader.Invoke("glUniform4d"));
            glUniform1dv = Marshal.GetDelegateForFunctionPointer<GLUniform1dv>(loader.Invoke("glUniform1dv"));
            glUniform2dv = Marshal.GetDelegateForFunctionPointer<GLUniform2dv>(loader.Invoke("glUniform2dv"));
            glUniform3dv = Marshal.GetDelegateForFunctionPointer<GLUniform3dv>(loader.Invoke("glUniform3dv"));
            glUniform4dv = Marshal.GetDelegateForFunctionPointer<GLUniform4dv>(loader.Invoke("glUniform4dv"));
            glUniformMatrix2dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2dv>(loader.Invoke("glUniformMatrix2dv"));
            glUniformMatrix3dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3dv>(loader.Invoke("glUniformMatrix3dv"));
            glUniformMatrix4dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4dv>(loader.Invoke("glUniformMatrix4dv"));
            glUniformMatrix2x3dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2x3dv>(loader.Invoke("glUniformMatrix2x3dv"));
            glUniformMatrix2x4dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2x4dv>(loader.Invoke("glUniformMatrix2x4dv"));
            glUniformMatrix3x2dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3x2dv>(loader.Invoke("glUniformMatrix3x2dv"));
            glUniformMatrix3x4dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3x4dv>(loader.Invoke("glUniformMatrix3x4dv"));
            glUniformMatrix4x2dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4x2dv>(loader.Invoke("glUniformMatrix4x2dv"));
            glUniformMatrix4x3dv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4x3dv>(loader.Invoke("glUniformMatrix4x3dv"));
            glGetUniformdv = Marshal.GetDelegateForFunctionPointer<GLGetUniformdv>(loader.Invoke("glGetUniformdv"));
            glUniform1i64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform1i64ARB>(loader.Invoke("glUniform1i64ARB"));
            glUniform2i64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform2i64ARB>(loader.Invoke("glUniform2i64ARB"));
            glUniform3i64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform3i64ARB>(loader.Invoke("glUniform3i64ARB"));
            glUniform4i64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform4i64ARB>(loader.Invoke("glUniform4i64ARB"));
            glUniform1i64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform1i64vARB>(loader.Invoke("glUniform1i64vARB"));
            glUniform2i64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform2i64vARB>(loader.Invoke("glUniform2i64vARB"));
            glUniform3i64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform3i64vARB>(loader.Invoke("glUniform3i64vARB"));
            glUniform4i64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform4i64vARB>(loader.Invoke("glUniform4i64vARB"));
            glUniform1ui64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform1ui64ARB>(loader.Invoke("glUniform1ui64ARB"));
            glUniform2ui64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform2ui64ARB>(loader.Invoke("glUniform2ui64ARB"));
            glUniform3ui64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform3ui64ARB>(loader.Invoke("glUniform3ui64ARB"));
            glUniform4ui64ARB = Marshal.GetDelegateForFunctionPointer<GLUniform4ui64ARB>(loader.Invoke("glUniform4ui64ARB"));
            glUniform1ui64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform1ui64vARB>(loader.Invoke("glUniform1ui64vARB"));
            glUniform2ui64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform2ui64vARB>(loader.Invoke("glUniform2ui64vARB"));
            glUniform3ui64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform3ui64vARB>(loader.Invoke("glUniform3ui64vARB"));
            glUniform4ui64vARB = Marshal.GetDelegateForFunctionPointer<GLUniform4ui64vARB>(loader.Invoke("glUniform4ui64vARB"));
            glGetUniformi64vARB = Marshal.GetDelegateForFunctionPointer<GLGetUniformi64vARB>(loader.Invoke("glGetUniformi64vARB"));
            glGetUniformui64vARB = Marshal.GetDelegateForFunctionPointer<GLGetUniformui64vARB>(loader.Invoke("glGetUniformui64vARB"));
            glGetnUniformi64vARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformi64vARB>(loader.Invoke("glGetnUniformi64vARB"));
            glGetnUniformui64vARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformui64vARB>(loader.Invoke("glGetnUniformui64vARB"));
            glProgramUniform1i64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1i64ARB>(loader.Invoke("glProgramUniform1i64ARB"));
            glProgramUniform2i64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2i64ARB>(loader.Invoke("glProgramUniform2i64ARB"));
            glProgramUniform3i64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3i64ARB>(loader.Invoke("glProgramUniform3i64ARB"));
            glProgramUniform4i64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4i64ARB>(loader.Invoke("glProgramUniform4i64ARB"));
            glProgramUniform1i64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1i64vARB>(loader.Invoke("glProgramUniform1i64vARB"));
            glProgramUniform2i64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2i64vARB>(loader.Invoke("glProgramUniform2i64vARB"));
            glProgramUniform3i64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3i64vARB>(loader.Invoke("glProgramUniform3i64vARB"));
            glProgramUniform4i64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4i64vARB>(loader.Invoke("glProgramUniform4i64vARB"));
            glProgramUniform1ui64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1ui64ARB>(loader.Invoke("glProgramUniform1ui64ARB"));
            glProgramUniform2ui64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2ui64ARB>(loader.Invoke("glProgramUniform2ui64ARB"));
            glProgramUniform3ui64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3ui64ARB>(loader.Invoke("glProgramUniform3ui64ARB"));
            glProgramUniform4ui64ARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4ui64ARB>(loader.Invoke("glProgramUniform4ui64ARB"));
            glProgramUniform1ui64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1ui64vARB>(loader.Invoke("glProgramUniform1ui64vARB"));
            glProgramUniform2ui64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2ui64vARB>(loader.Invoke("glProgramUniform2ui64vARB"));
            glProgramUniform3ui64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3ui64vARB>(loader.Invoke("glProgramUniform3ui64vARB"));
            glProgramUniform4ui64vARB = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4ui64vARB>(loader.Invoke("glProgramUniform4ui64vARB"));
            glBlendColor = Marshal.GetDelegateForFunctionPointer<GLBlendColor>(loader.Invoke("glBlendColor"));
            glBlendEquation = Marshal.GetDelegateForFunctionPointer<GLBlendEquation>(loader.Invoke("glBlendEquation"));
            glMultiDrawArraysIndirectCountARB = Marshal.GetDelegateForFunctionPointer<GLMultiDrawArraysIndirectCountARB>(loader.Invoke("glMultiDrawArraysIndirectCountARB"));
            glMultiDrawElementsIndirectCountARB = Marshal.GetDelegateForFunctionPointer<GLMultiDrawElementsIndirectCountARB>(loader.Invoke("glMultiDrawElementsIndirectCountARB"));
            glVertexAttribDivisorARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttribDivisorARB>(loader.Invoke("glVertexAttribDivisorARB"));
            glGetInternalformativ = Marshal.GetDelegateForFunctionPointer<GLGetInternalformativ>(loader.Invoke("glGetInternalformativ"));
            glGetInternalformati64v = Marshal.GetDelegateForFunctionPointer<GLGetInternalformati64v>(loader.Invoke("glGetInternalformati64v"));
            glInvalidateTexSubImage = Marshal.GetDelegateForFunctionPointer<GLInvalidateTexSubImage>(loader.Invoke("glInvalidateTexSubImage"));
            glInvalidateTexImage = Marshal.GetDelegateForFunctionPointer<GLInvalidateTexImage>(loader.Invoke("glInvalidateTexImage"));
            glInvalidateBufferSubData = Marshal.GetDelegateForFunctionPointer<GLInvalidateBufferSubData>(loader.Invoke("glInvalidateBufferSubData"));
            glInvalidateBufferData = Marshal.GetDelegateForFunctionPointer<GLInvalidateBufferData>(loader.Invoke("glInvalidateBufferData"));
            glInvalidateFramebuffer = Marshal.GetDelegateForFunctionPointer<GLInvalidateFramebuffer>(loader.Invoke("glInvalidateFramebuffer"));
            glInvalidateSubFramebuffer = Marshal.GetDelegateForFunctionPointer<GLInvalidateSubFramebuffer>(loader.Invoke("glInvalidateSubFramebuffer"));
            glMapBufferRange = Marshal.GetDelegateForFunctionPointer<GLMapBufferRange>(loader.Invoke("glMapBufferRange"));
            glFlushMappedBufferRange = Marshal.GetDelegateForFunctionPointer<GLFlushMappedBufferRange>(loader.Invoke("glFlushMappedBufferRange"));
            glCurrentPaletteMatrixARB = Marshal.GetDelegateForFunctionPointer<GLCurrentPaletteMatrixARB>(loader.Invoke("glCurrentPaletteMatrixARB"));
            glMatrixIndexubvARB = Marshal.GetDelegateForFunctionPointer<GLMatrixIndexubvARB>(loader.Invoke("glMatrixIndexubvARB"));
            glMatrixIndexusvARB = Marshal.GetDelegateForFunctionPointer<GLMatrixIndexusvARB>(loader.Invoke("glMatrixIndexusvARB"));
            glMatrixIndexuivARB = Marshal.GetDelegateForFunctionPointer<GLMatrixIndexuivARB>(loader.Invoke("glMatrixIndexuivARB"));
            glMatrixIndexPointerARB = Marshal.GetDelegateForFunctionPointer<GLMatrixIndexPointerARB>(loader.Invoke("glMatrixIndexPointerARB"));
            glBindBuffersBase = Marshal.GetDelegateForFunctionPointer<GLBindBuffersBase>(loader.Invoke("glBindBuffersBase"));
            glBindBuffersRange = Marshal.GetDelegateForFunctionPointer<GLBindBuffersRange>(loader.Invoke("glBindBuffersRange"));
            glBindTextures = Marshal.GetDelegateForFunctionPointer<GLBindTextures>(loader.Invoke("glBindTextures"));
            glBindSamplers = Marshal.GetDelegateForFunctionPointer<GLBindSamplers>(loader.Invoke("glBindSamplers"));
            glBindImageTextures = Marshal.GetDelegateForFunctionPointer<GLBindImageTextures>(loader.Invoke("glBindImageTextures"));
            glBindVertexBuffers = Marshal.GetDelegateForFunctionPointer<GLBindVertexBuffers>(loader.Invoke("glBindVertexBuffers"));
            glMultiDrawArraysIndirect = Marshal.GetDelegateForFunctionPointer<GLMultiDrawArraysIndirect>(loader.Invoke("glMultiDrawArraysIndirect"));
            glMultiDrawElementsIndirect = Marshal.GetDelegateForFunctionPointer<GLMultiDrawElementsIndirect>(loader.Invoke("glMultiDrawElementsIndirect"));
            glSampleCoverageARB = Marshal.GetDelegateForFunctionPointer<GLSampleCoverageARB>(loader.Invoke("glSampleCoverageARB"));
            glActiveTextureARB = Marshal.GetDelegateForFunctionPointer<GLActiveTextureARB>(loader.Invoke("glActiveTextureARB"));
            glClientActiveTextureARB = Marshal.GetDelegateForFunctionPointer<GLClientActiveTextureARB>(loader.Invoke("glClientActiveTextureARB"));
            glMultiTexCoord1dARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1dARB>(loader.Invoke("glMultiTexCoord1dARB"));
            glMultiTexCoord1dvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1dvARB>(loader.Invoke("glMultiTexCoord1dvARB"));
            glMultiTexCoord1fARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1fARB>(loader.Invoke("glMultiTexCoord1fARB"));
            glMultiTexCoord1fvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1fvARB>(loader.Invoke("glMultiTexCoord1fvARB"));
            glMultiTexCoord1iARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1iARB>(loader.Invoke("glMultiTexCoord1iARB"));
            glMultiTexCoord1ivARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1ivARB>(loader.Invoke("glMultiTexCoord1ivARB"));
            glMultiTexCoord1sARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1sARB>(loader.Invoke("glMultiTexCoord1sARB"));
            glMultiTexCoord1svARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord1svARB>(loader.Invoke("glMultiTexCoord1svARB"));
            glMultiTexCoord2dARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2dARB>(loader.Invoke("glMultiTexCoord2dARB"));
            glMultiTexCoord2dvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2dvARB>(loader.Invoke("glMultiTexCoord2dvARB"));
            glMultiTexCoord2fARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2fARB>(loader.Invoke("glMultiTexCoord2fARB"));
            glMultiTexCoord2fvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2fvARB>(loader.Invoke("glMultiTexCoord2fvARB"));
            glMultiTexCoord2iARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2iARB>(loader.Invoke("glMultiTexCoord2iARB"));
            glMultiTexCoord2ivARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2ivARB>(loader.Invoke("glMultiTexCoord2ivARB"));
            glMultiTexCoord2sARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2sARB>(loader.Invoke("glMultiTexCoord2sARB"));
            glMultiTexCoord2svARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord2svARB>(loader.Invoke("glMultiTexCoord2svARB"));
            glMultiTexCoord3dARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3dARB>(loader.Invoke("glMultiTexCoord3dARB"));
            glMultiTexCoord3dvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3dvARB>(loader.Invoke("glMultiTexCoord3dvARB"));
            glMultiTexCoord3fARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3fARB>(loader.Invoke("glMultiTexCoord3fARB"));
            glMultiTexCoord3fvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3fvARB>(loader.Invoke("glMultiTexCoord3fvARB"));
            glMultiTexCoord3iARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3iARB>(loader.Invoke("glMultiTexCoord3iARB"));
            glMultiTexCoord3ivARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3ivARB>(loader.Invoke("glMultiTexCoord3ivARB"));
            glMultiTexCoord3sARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3sARB>(loader.Invoke("glMultiTexCoord3sARB"));
            glMultiTexCoord3svARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord3svARB>(loader.Invoke("glMultiTexCoord3svARB"));
            glMultiTexCoord4dARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4dARB>(loader.Invoke("glMultiTexCoord4dARB"));
            glMultiTexCoord4dvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4dvARB>(loader.Invoke("glMultiTexCoord4dvARB"));
            glMultiTexCoord4fARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4fARB>(loader.Invoke("glMultiTexCoord4fARB"));
            glMultiTexCoord4fvARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4fvARB>(loader.Invoke("glMultiTexCoord4fvARB"));
            glMultiTexCoord4iARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4iARB>(loader.Invoke("glMultiTexCoord4iARB"));
            glMultiTexCoord4ivARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4ivARB>(loader.Invoke("glMultiTexCoord4ivARB"));
            glMultiTexCoord4sARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4sARB>(loader.Invoke("glMultiTexCoord4sARB"));
            glMultiTexCoord4svARB = Marshal.GetDelegateForFunctionPointer<GLMultiTexCoord4svARB>(loader.Invoke("glMultiTexCoord4svARB"));
            glGenQueriesARB = Marshal.GetDelegateForFunctionPointer<GLGenQueriesARB>(loader.Invoke("glGenQueriesARB"));
            glDeleteQueriesARB = Marshal.GetDelegateForFunctionPointer<GLDeleteQueriesARB>(loader.Invoke("glDeleteQueriesARB"));
            glIsQueryARB = Marshal.GetDelegateForFunctionPointer<GLIsQueryARB>(loader.Invoke("glIsQueryARB"));
            glBeginQueryARB = Marshal.GetDelegateForFunctionPointer<GLBeginQueryARB>(loader.Invoke("glBeginQueryARB"));
            glEndQueryARB = Marshal.GetDelegateForFunctionPointer<GLEndQueryARB>(loader.Invoke("glEndQueryARB"));
            glGetQueryivARB = Marshal.GetDelegateForFunctionPointer<GLGetQueryivARB>(loader.Invoke("glGetQueryivARB"));
            glGetQueryObjectivARB = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjectivARB>(loader.Invoke("glGetQueryObjectivARB"));
            glGetQueryObjectuivARB = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjectuivARB>(loader.Invoke("glGetQueryObjectuivARB"));
            glMaxShaderCompilerThreadsARB = Marshal.GetDelegateForFunctionPointer<GLMaxShaderCompilerThreadsARB>(loader.Invoke("glMaxShaderCompilerThreadsARB"));
            glPointParameterfARB = Marshal.GetDelegateForFunctionPointer<GLPointParameterfARB>(loader.Invoke("glPointParameterfARB"));
            glPointParameterfvARB = Marshal.GetDelegateForFunctionPointer<GLPointParameterfvARB>(loader.Invoke("glPointParameterfvARB"));
            glPolygonOffsetClamp = Marshal.GetDelegateForFunctionPointer<GLPolygonOffsetClamp>(loader.Invoke("glPolygonOffsetClamp"));
            glGetProgramInterfaceiv = Marshal.GetDelegateForFunctionPointer<GLGetProgramInterfaceiv>(loader.Invoke("glGetProgramInterfaceiv"));
            glGetProgramResourceIndex = Marshal.GetDelegateForFunctionPointer<GLGetProgramResourceIndex>(loader.Invoke("glGetProgramResourceIndex"));
            glGetProgramResourceName = Marshal.GetDelegateForFunctionPointer<GLGetProgramResourceName>(loader.Invoke("glGetProgramResourceName"));
            glGetProgramResourceiv = Marshal.GetDelegateForFunctionPointer<GLGetProgramResourceiv>(loader.Invoke("glGetProgramResourceiv"));
            glGetProgramResourceLocation = Marshal.GetDelegateForFunctionPointer<GLGetProgramResourceLocation>(loader.Invoke("glGetProgramResourceLocation"));
            glGetProgramResourceLocationIndex = Marshal.GetDelegateForFunctionPointer<GLGetProgramResourceLocationIndex>(loader.Invoke("glGetProgramResourceLocationIndex"));
            glProvokingVertex = Marshal.GetDelegateForFunctionPointer<GLProvokingVertex>(loader.Invoke("glProvokingVertex"));
            glGetGraphicsResetStatusARB = Marshal.GetDelegateForFunctionPointer<GLGetGraphicsResetStatusARB>(loader.Invoke("glGetGraphicsResetStatusARB"));
            glGetnTexImageARB = Marshal.GetDelegateForFunctionPointer<GLGetnTexImageARB>(loader.Invoke("glGetnTexImageARB"));
            glReadnPixelsARB = Marshal.GetDelegateForFunctionPointer<GLReadnPixelsARB>(loader.Invoke("glReadnPixelsARB"));
            glGetnCompressedTexImageARB = Marshal.GetDelegateForFunctionPointer<GLGetnCompressedTexImageARB>(loader.Invoke("glGetnCompressedTexImageARB"));
            glGetnUniformfvARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformfvARB>(loader.Invoke("glGetnUniformfvARB"));
            glGetnUniformivARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformivARB>(loader.Invoke("glGetnUniformivARB"));
            glGetnUniformuivARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformuivARB>(loader.Invoke("glGetnUniformuivARB"));
            glGetnUniformdvARB = Marshal.GetDelegateForFunctionPointer<GLGetnUniformdvARB>(loader.Invoke("glGetnUniformdvARB"));
            glFramebufferSampleLocationsfvARB = Marshal.GetDelegateForFunctionPointer<GLFramebufferSampleLocationsfvARB>(loader.Invoke("glFramebufferSampleLocationsfvARB"));
            glNamedFramebufferSampleLocationsfvARB = Marshal.GetDelegateForFunctionPointer<GLNamedFramebufferSampleLocationsfvARB>(loader.Invoke("glNamedFramebufferSampleLocationsfvARB"));
            glEvaluateDepthValuesARB = Marshal.GetDelegateForFunctionPointer<GLEvaluateDepthValuesARB>(loader.Invoke("glEvaluateDepthValuesARB"));
            glMinSampleShadingARB = Marshal.GetDelegateForFunctionPointer<GLMinSampleShadingARB>(loader.Invoke("glMinSampleShadingARB"));
            glGenSamplers = Marshal.GetDelegateForFunctionPointer<GLGenSamplers>(loader.Invoke("glGenSamplers"));
            glDeleteSamplers = Marshal.GetDelegateForFunctionPointer<GLDeleteSamplers>(loader.Invoke("glDeleteSamplers"));
            glIsSampler = Marshal.GetDelegateForFunctionPointer<GLIsSampler>(loader.Invoke("glIsSampler"));
            glBindSampler = Marshal.GetDelegateForFunctionPointer<GLBindSampler>(loader.Invoke("glBindSampler"));
            glSamplerParameteri = Marshal.GetDelegateForFunctionPointer<GLSamplerParameteri>(loader.Invoke("glSamplerParameteri"));
            glSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<GLSamplerParameteriv>(loader.Invoke("glSamplerParameteriv"));
            glSamplerParameterf = Marshal.GetDelegateForFunctionPointer<GLSamplerParameterf>(loader.Invoke("glSamplerParameterf"));
            glSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<GLSamplerParameterfv>(loader.Invoke("glSamplerParameterfv"));
            glSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<GLSamplerParameterIiv>(loader.Invoke("glSamplerParameterIiv"));
            glSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLSamplerParameterIuiv>(loader.Invoke("glSamplerParameterIuiv"));
            glGetSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetSamplerParameteriv>(loader.Invoke("glGetSamplerParameteriv"));
            glGetSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<GLGetSamplerParameterIiv>(loader.Invoke("glGetSamplerParameterIiv"));
            glGetSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<GLGetSamplerParameterfv>(loader.Invoke("glGetSamplerParameterfv"));
            glGetSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLGetSamplerParameterIuiv>(loader.Invoke("glGetSamplerParameterIuiv"));
            glUseProgramStages = Marshal.GetDelegateForFunctionPointer<GLUseProgramStages>(loader.Invoke("glUseProgramStages"));
            glActiveShaderProgram = Marshal.GetDelegateForFunctionPointer<GLActiveShaderProgram>(loader.Invoke("glActiveShaderProgram"));
            glCreateShaderProgramv = Marshal.GetDelegateForFunctionPointer<GLCreateShaderProgramv>(loader.Invoke("glCreateShaderProgramv"));
            glBindProgramPipeline = Marshal.GetDelegateForFunctionPointer<GLBindProgramPipeline>(loader.Invoke("glBindProgramPipeline"));
            glDeleteProgramPipelines = Marshal.GetDelegateForFunctionPointer<GLDeleteProgramPipelines>(loader.Invoke("glDeleteProgramPipelines"));
            glGenProgramPipelines = Marshal.GetDelegateForFunctionPointer<GLGenProgramPipelines>(loader.Invoke("glGenProgramPipelines"));
            glIsProgramPipeline = Marshal.GetDelegateForFunctionPointer<GLIsProgramPipeline>(loader.Invoke("glIsProgramPipeline"));
            glGetProgramPipelineiv = Marshal.GetDelegateForFunctionPointer<GLGetProgramPipelineiv>(loader.Invoke("glGetProgramPipelineiv"));
            glProgramUniform1i = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1i>(loader.Invoke("glProgramUniform1i"));
            glProgramUniform1iv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1iv>(loader.Invoke("glProgramUniform1iv"));
            glProgramUniform1f = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1f>(loader.Invoke("glProgramUniform1f"));
            glProgramUniform1fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1fv>(loader.Invoke("glProgramUniform1fv"));
            glProgramUniform1d = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1d>(loader.Invoke("glProgramUniform1d"));
            glProgramUniform1dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1dv>(loader.Invoke("glProgramUniform1dv"));
            glProgramUniform1ui = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1ui>(loader.Invoke("glProgramUniform1ui"));
            glProgramUniform1uiv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform1uiv>(loader.Invoke("glProgramUniform1uiv"));
            glProgramUniform2i = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2i>(loader.Invoke("glProgramUniform2i"));
            glProgramUniform2iv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2iv>(loader.Invoke("glProgramUniform2iv"));
            glProgramUniform2f = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2f>(loader.Invoke("glProgramUniform2f"));
            glProgramUniform2fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2fv>(loader.Invoke("glProgramUniform2fv"));
            glProgramUniform2d = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2d>(loader.Invoke("glProgramUniform2d"));
            glProgramUniform2dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2dv>(loader.Invoke("glProgramUniform2dv"));
            glProgramUniform2ui = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2ui>(loader.Invoke("glProgramUniform2ui"));
            glProgramUniform2uiv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform2uiv>(loader.Invoke("glProgramUniform2uiv"));
            glProgramUniform3i = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3i>(loader.Invoke("glProgramUniform3i"));
            glProgramUniform3iv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3iv>(loader.Invoke("glProgramUniform3iv"));
            glProgramUniform3f = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3f>(loader.Invoke("glProgramUniform3f"));
            glProgramUniform3fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3fv>(loader.Invoke("glProgramUniform3fv"));
            glProgramUniform3d = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3d>(loader.Invoke("glProgramUniform3d"));
            glProgramUniform3dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3dv>(loader.Invoke("glProgramUniform3dv"));
            glProgramUniform3ui = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3ui>(loader.Invoke("glProgramUniform3ui"));
            glProgramUniform3uiv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform3uiv>(loader.Invoke("glProgramUniform3uiv"));
            glProgramUniform4i = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4i>(loader.Invoke("glProgramUniform4i"));
            glProgramUniform4iv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4iv>(loader.Invoke("glProgramUniform4iv"));
            glProgramUniform4f = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4f>(loader.Invoke("glProgramUniform4f"));
            glProgramUniform4fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4fv>(loader.Invoke("glProgramUniform4fv"));
            glProgramUniform4d = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4d>(loader.Invoke("glProgramUniform4d"));
            glProgramUniform4dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4dv>(loader.Invoke("glProgramUniform4dv"));
            glProgramUniform4ui = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4ui>(loader.Invoke("glProgramUniform4ui"));
            glProgramUniform4uiv = Marshal.GetDelegateForFunctionPointer<GLProgramUniform4uiv>(loader.Invoke("glProgramUniform4uiv"));
            glProgramUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2fv>(loader.Invoke("glProgramUniformMatrix2fv"));
            glProgramUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3fv>(loader.Invoke("glProgramUniformMatrix3fv"));
            glProgramUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4fv>(loader.Invoke("glProgramUniformMatrix4fv"));
            glProgramUniformMatrix2dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2dv>(loader.Invoke("glProgramUniformMatrix2dv"));
            glProgramUniformMatrix3dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3dv>(loader.Invoke("glProgramUniformMatrix3dv"));
            glProgramUniformMatrix4dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4dv>(loader.Invoke("glProgramUniformMatrix4dv"));
            glProgramUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2x3fv>(loader.Invoke("glProgramUniformMatrix2x3fv"));
            glProgramUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3x2fv>(loader.Invoke("glProgramUniformMatrix3x2fv"));
            glProgramUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2x4fv>(loader.Invoke("glProgramUniformMatrix2x4fv"));
            glProgramUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4x2fv>(loader.Invoke("glProgramUniformMatrix4x2fv"));
            glProgramUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3x4fv>(loader.Invoke("glProgramUniformMatrix3x4fv"));
            glProgramUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4x3fv>(loader.Invoke("glProgramUniformMatrix4x3fv"));
            glProgramUniformMatrix2x3dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2x3dv>(loader.Invoke("glProgramUniformMatrix2x3dv"));
            glProgramUniformMatrix3x2dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3x2dv>(loader.Invoke("glProgramUniformMatrix3x2dv"));
            glProgramUniformMatrix2x4dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix2x4dv>(loader.Invoke("glProgramUniformMatrix2x4dv"));
            glProgramUniformMatrix4x2dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4x2dv>(loader.Invoke("glProgramUniformMatrix4x2dv"));
            glProgramUniformMatrix3x4dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix3x4dv>(loader.Invoke("glProgramUniformMatrix3x4dv"));
            glProgramUniformMatrix4x3dv = Marshal.GetDelegateForFunctionPointer<GLProgramUniformMatrix4x3dv>(loader.Invoke("glProgramUniformMatrix4x3dv"));
            glValidateProgramPipeline = Marshal.GetDelegateForFunctionPointer<GLValidateProgramPipeline>(loader.Invoke("glValidateProgramPipeline"));
            glGetProgramPipelineInfoLog = Marshal.GetDelegateForFunctionPointer<GLGetProgramPipelineInfoLog>(loader.Invoke("glGetProgramPipelineInfoLog"));
            glGetActiveAtomicCounterBufferiv = Marshal.GetDelegateForFunctionPointer<GLGetActiveAtomicCounterBufferiv>(loader.Invoke("glGetActiveAtomicCounterBufferiv"));
            glBindImageTexture = Marshal.GetDelegateForFunctionPointer<GLBindImageTexture>(loader.Invoke("glBindImageTexture"));
            glMemoryBarrier = Marshal.GetDelegateForFunctionPointer<GLMemoryBarrier>(loader.Invoke("glMemoryBarrier"));
            glDeleteObjectARB = Marshal.GetDelegateForFunctionPointer<GLDeleteObjectARB>(loader.Invoke("glDeleteObjectARB"));
            glGetHandleARB = Marshal.GetDelegateForFunctionPointer<GLGetHandleARB>(loader.Invoke("glGetHandleARB"));
            glDetachObjectARB = Marshal.GetDelegateForFunctionPointer<GLDetachObjectARB>(loader.Invoke("glDetachObjectARB"));
            glCreateShaderObjectARB = Marshal.GetDelegateForFunctionPointer<GLCreateShaderObjectARB>(loader.Invoke("glCreateShaderObjectARB"));
            glShaderSourceARB = Marshal.GetDelegateForFunctionPointer<GLShaderSourceARB>(loader.Invoke("glShaderSourceARB"));
            glCompileShaderARB = Marshal.GetDelegateForFunctionPointer<GLCompileShaderARB>(loader.Invoke("glCompileShaderARB"));
            glCreateProgramObjectARB = Marshal.GetDelegateForFunctionPointer<GLCreateProgramObjectARB>(loader.Invoke("glCreateProgramObjectARB"));
            glAttachObjectARB = Marshal.GetDelegateForFunctionPointer<GLAttachObjectARB>(loader.Invoke("glAttachObjectARB"));
            glLinkProgramARB = Marshal.GetDelegateForFunctionPointer<GLLinkProgramARB>(loader.Invoke("glLinkProgramARB"));
            glUseProgramObjectARB = Marshal.GetDelegateForFunctionPointer<GLUseProgramObjectARB>(loader.Invoke("glUseProgramObjectARB"));
            glValidateProgramARB = Marshal.GetDelegateForFunctionPointer<GLValidateProgramARB>(loader.Invoke("glValidateProgramARB"));
            glUniform1fARB = Marshal.GetDelegateForFunctionPointer<GLUniform1fARB>(loader.Invoke("glUniform1fARB"));
            glUniform2fARB = Marshal.GetDelegateForFunctionPointer<GLUniform2fARB>(loader.Invoke("glUniform2fARB"));
            glUniform3fARB = Marshal.GetDelegateForFunctionPointer<GLUniform3fARB>(loader.Invoke("glUniform3fARB"));
            glUniform4fARB = Marshal.GetDelegateForFunctionPointer<GLUniform4fARB>(loader.Invoke("glUniform4fARB"));
            glUniform1iARB = Marshal.GetDelegateForFunctionPointer<GLUniform1iARB>(loader.Invoke("glUniform1iARB"));
            glUniform2iARB = Marshal.GetDelegateForFunctionPointer<GLUniform2iARB>(loader.Invoke("glUniform2iARB"));
            glUniform3iARB = Marshal.GetDelegateForFunctionPointer<GLUniform3iARB>(loader.Invoke("glUniform3iARB"));
            glUniform4iARB = Marshal.GetDelegateForFunctionPointer<GLUniform4iARB>(loader.Invoke("glUniform4iARB"));
            glUniform1fvARB = Marshal.GetDelegateForFunctionPointer<GLUniform1fvARB>(loader.Invoke("glUniform1fvARB"));
            glUniform2fvARB = Marshal.GetDelegateForFunctionPointer<GLUniform2fvARB>(loader.Invoke("glUniform2fvARB"));
            glUniform3fvARB = Marshal.GetDelegateForFunctionPointer<GLUniform3fvARB>(loader.Invoke("glUniform3fvARB"));
            glUniform4fvARB = Marshal.GetDelegateForFunctionPointer<GLUniform4fvARB>(loader.Invoke("glUniform4fvARB"));
            glUniform1ivARB = Marshal.GetDelegateForFunctionPointer<GLUniform1ivARB>(loader.Invoke("glUniform1ivARB"));
            glUniform2ivARB = Marshal.GetDelegateForFunctionPointer<GLUniform2ivARB>(loader.Invoke("glUniform2ivARB"));
            glUniform3ivARB = Marshal.GetDelegateForFunctionPointer<GLUniform3ivARB>(loader.Invoke("glUniform3ivARB"));
            glUniform4ivARB = Marshal.GetDelegateForFunctionPointer<GLUniform4ivARB>(loader.Invoke("glUniform4ivARB"));
            glUniformMatrix2fvARB = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2fvARB>(loader.Invoke("glUniformMatrix2fvARB"));
            glUniformMatrix3fvARB = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3fvARB>(loader.Invoke("glUniformMatrix3fvARB"));
            glUniformMatrix4fvARB = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4fvARB>(loader.Invoke("glUniformMatrix4fvARB"));
            glGetObjectParameterfvARB = Marshal.GetDelegateForFunctionPointer<GLGetObjectParameterfvARB>(loader.Invoke("glGetObjectParameterfvARB"));
            glGetObjectParameterivARB = Marshal.GetDelegateForFunctionPointer<GLGetObjectParameterivARB>(loader.Invoke("glGetObjectParameterivARB"));
            glGetInfoLogARB = Marshal.GetDelegateForFunctionPointer<GLGetInfoLogARB>(loader.Invoke("glGetInfoLogARB"));
            glGetAttachedObjectsARB = Marshal.GetDelegateForFunctionPointer<GLGetAttachedObjectsARB>(loader.Invoke("glGetAttachedObjectsARB"));
            glGetUniformLocationARB = Marshal.GetDelegateForFunctionPointer<GLGetUniformLocationARB>(loader.Invoke("glGetUniformLocationARB"));
            glGetActiveUniformARB = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniformARB>(loader.Invoke("glGetActiveUniformARB"));
            glGetUniformfvARB = Marshal.GetDelegateForFunctionPointer<GLGetUniformfvARB>(loader.Invoke("glGetUniformfvARB"));
            glGetUniformivARB = Marshal.GetDelegateForFunctionPointer<GLGetUniformivARB>(loader.Invoke("glGetUniformivARB"));
            glGetShaderSourceARB = Marshal.GetDelegateForFunctionPointer<GLGetShaderSourceARB>(loader.Invoke("glGetShaderSourceARB"));
            glShaderStorageBlockBinding = Marshal.GetDelegateForFunctionPointer<GLShaderStorageBlockBinding>(loader.Invoke("glShaderStorageBlockBinding"));
            glGetSubroutineUniformLocation = Marshal.GetDelegateForFunctionPointer<GLGetSubroutineUniformLocation>(loader.Invoke("glGetSubroutineUniformLocation"));
            glGetSubroutineIndex = Marshal.GetDelegateForFunctionPointer<GLGetSubroutineIndex>(loader.Invoke("glGetSubroutineIndex"));
            glGetActiveSubroutineUniformiv = Marshal.GetDelegateForFunctionPointer<GLGetActiveSubroutineUniformiv>(loader.Invoke("glGetActiveSubroutineUniformiv"));
            glGetActiveSubroutineUniformName = Marshal.GetDelegateForFunctionPointer<GLGetActiveSubroutineUniformName>(loader.Invoke("glGetActiveSubroutineUniformName"));
            glGetActiveSubroutineName = Marshal.GetDelegateForFunctionPointer<GLGetActiveSubroutineName>(loader.Invoke("glGetActiveSubroutineName"));
            glUniformSubroutinesuiv = Marshal.GetDelegateForFunctionPointer<GLUniformSubroutinesuiv>(loader.Invoke("glUniformSubroutinesuiv"));
            glGetUniformSubroutineuiv = Marshal.GetDelegateForFunctionPointer<GLGetUniformSubroutineuiv>(loader.Invoke("glGetUniformSubroutineuiv"));
            glGetProgramStageiv = Marshal.GetDelegateForFunctionPointer<GLGetProgramStageiv>(loader.Invoke("glGetProgramStageiv"));
            glNamedStringARB = Marshal.GetDelegateForFunctionPointer<GLNamedStringARB>(loader.Invoke("glNamedStringARB"));
            glDeleteNamedStringARB = Marshal.GetDelegateForFunctionPointer<GLDeleteNamedStringARB>(loader.Invoke("glDeleteNamedStringARB"));
            glCompileShaderIncludeARB = Marshal.GetDelegateForFunctionPointer<GLCompileShaderIncludeARB>(loader.Invoke("glCompileShaderIncludeARB"));
            glIsNamedStringARB = Marshal.GetDelegateForFunctionPointer<GLIsNamedStringARB>(loader.Invoke("glIsNamedStringARB"));
            glGetNamedStringARB = Marshal.GetDelegateForFunctionPointer<GLGetNamedStringARB>(loader.Invoke("glGetNamedStringARB"));
            glGetNamedStringivARB = Marshal.GetDelegateForFunctionPointer<GLGetNamedStringivARB>(loader.Invoke("glGetNamedStringivARB"));
            glBufferPageCommitmentARB = Marshal.GetDelegateForFunctionPointer<GLBufferPageCommitmentARB>(loader.Invoke("glBufferPageCommitmentARB"));
            glNamedBufferPageCommitmentEXT = Marshal.GetDelegateForFunctionPointer<GLNamedBufferPageCommitmentEXT>(loader.Invoke("glNamedBufferPageCommitmentEXT"));
            glNamedBufferPageCommitmentARB = Marshal.GetDelegateForFunctionPointer<GLNamedBufferPageCommitmentARB>(loader.Invoke("glNamedBufferPageCommitmentARB"));
            glTexPageCommitmentARB = Marshal.GetDelegateForFunctionPointer<GLTexPageCommitmentARB>(loader.Invoke("glTexPageCommitmentARB"));
            glFenceSync = Marshal.GetDelegateForFunctionPointer<GLFenceSync>(loader.Invoke("glFenceSync"));
            glIsSync = Marshal.GetDelegateForFunctionPointer<GLIsSync>(loader.Invoke("glIsSync"));
            glDeleteSync = Marshal.GetDelegateForFunctionPointer<GLDeleteSync>(loader.Invoke("glDeleteSync"));
            glClientWaitSync = Marshal.GetDelegateForFunctionPointer<GLClientWaitSync>(loader.Invoke("glClientWaitSync"));
            glWaitSync = Marshal.GetDelegateForFunctionPointer<GLWaitSync>(loader.Invoke("glWaitSync"));
            glGetInteger64v = Marshal.GetDelegateForFunctionPointer<GLGetInteger64v>(loader.Invoke("glGetInteger64v"));
            glGetSynciv = Marshal.GetDelegateForFunctionPointer<GLGetSynciv>(loader.Invoke("glGetSynciv"));
            glPatchParameteri = Marshal.GetDelegateForFunctionPointer<GLPatchParameteri>(loader.Invoke("glPatchParameteri"));
            glPatchParameterfv = Marshal.GetDelegateForFunctionPointer<GLPatchParameterfv>(loader.Invoke("glPatchParameterfv"));
            glTextureBarrier = Marshal.GetDelegateForFunctionPointer<GLTextureBarrier>(loader.Invoke("glTextureBarrier"));
            glTexBufferARB = Marshal.GetDelegateForFunctionPointer<GLTexBufferARB>(loader.Invoke("glTexBufferARB"));
            glTexBufferRange = Marshal.GetDelegateForFunctionPointer<GLTexBufferRange>(loader.Invoke("glTexBufferRange"));
            glCompressedTexImage3DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage3DARB>(loader.Invoke("glCompressedTexImage3DARB"));
            glCompressedTexImage2DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage2DARB>(loader.Invoke("glCompressedTexImage2DARB"));
            glCompressedTexImage1DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage1DARB>(loader.Invoke("glCompressedTexImage1DARB"));
            glCompressedTexSubImage3DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage3DARB>(loader.Invoke("glCompressedTexSubImage3DARB"));
            glCompressedTexSubImage2DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage2DARB>(loader.Invoke("glCompressedTexSubImage2DARB"));
            glCompressedTexSubImage1DARB = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage1DARB>(loader.Invoke("glCompressedTexSubImage1DARB"));
            glGetCompressedTexImageARB = Marshal.GetDelegateForFunctionPointer<GLGetCompressedTexImageARB>(loader.Invoke("glGetCompressedTexImageARB"));
            glTexImage2DMultisample = Marshal.GetDelegateForFunctionPointer<GLTexImage2DMultisample>(loader.Invoke("glTexImage2DMultisample"));
            glTexImage3DMultisample = Marshal.GetDelegateForFunctionPointer<GLTexImage3DMultisample>(loader.Invoke("glTexImage3DMultisample"));
            glGetMultisamplefv = Marshal.GetDelegateForFunctionPointer<GLGetMultisamplefv>(loader.Invoke("glGetMultisamplefv"));
            glSampleMaski = Marshal.GetDelegateForFunctionPointer<GLSampleMaski>(loader.Invoke("glSampleMaski"));
            glTexStorage1D = Marshal.GetDelegateForFunctionPointer<GLTexStorage1D>(loader.Invoke("glTexStorage1D"));
            glTexStorage2D = Marshal.GetDelegateForFunctionPointer<GLTexStorage2D>(loader.Invoke("glTexStorage2D"));
            glTexStorage3D = Marshal.GetDelegateForFunctionPointer<GLTexStorage3D>(loader.Invoke("glTexStorage3D"));
            glTexStorage2DMultisample = Marshal.GetDelegateForFunctionPointer<GLTexStorage2DMultisample>(loader.Invoke("glTexStorage2DMultisample"));
            glTexStorage3DMultisample = Marshal.GetDelegateForFunctionPointer<GLTexStorage3DMultisample>(loader.Invoke("glTexStorage3DMultisample"));
            glTextureView = Marshal.GetDelegateForFunctionPointer<GLTextureView>(loader.Invoke("glTextureView"));
            glQueryCounter = Marshal.GetDelegateForFunctionPointer<GLQueryCounter>(loader.Invoke("glQueryCounter"));
            glGetQueryObjecti64v = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjecti64v>(loader.Invoke("glGetQueryObjecti64v"));
            glGetQueryObjectui64v = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjectui64v>(loader.Invoke("glGetQueryObjectui64v"));
            glBindTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLBindTransformFeedback>(loader.Invoke("glBindTransformFeedback"));
            glDeleteTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<GLDeleteTransformFeedbacks>(loader.Invoke("glDeleteTransformFeedbacks"));
            glGenTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<GLGenTransformFeedbacks>(loader.Invoke("glGenTransformFeedbacks"));
            glIsTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLIsTransformFeedback>(loader.Invoke("glIsTransformFeedback"));
            glPauseTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLPauseTransformFeedback>(loader.Invoke("glPauseTransformFeedback"));
            glResumeTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLResumeTransformFeedback>(loader.Invoke("glResumeTransformFeedback"));
            glDrawTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLDrawTransformFeedback>(loader.Invoke("glDrawTransformFeedback"));
            glDrawTransformFeedbackStream = Marshal.GetDelegateForFunctionPointer<GLDrawTransformFeedbackStream>(loader.Invoke("glDrawTransformFeedbackStream"));
            glBeginQueryIndexed = Marshal.GetDelegateForFunctionPointer<GLBeginQueryIndexed>(loader.Invoke("glBeginQueryIndexed"));
            glEndQueryIndexed = Marshal.GetDelegateForFunctionPointer<GLEndQueryIndexed>(loader.Invoke("glEndQueryIndexed"));
            glGetQueryIndexediv = Marshal.GetDelegateForFunctionPointer<GLGetQueryIndexediv>(loader.Invoke("glGetQueryIndexediv"));
            glDrawTransformFeedbackInstanced = Marshal.GetDelegateForFunctionPointer<GLDrawTransformFeedbackInstanced>(loader.Invoke("glDrawTransformFeedbackInstanced"));
            glDrawTransformFeedbackStreamInstanced = Marshal.GetDelegateForFunctionPointer<GLDrawTransformFeedbackStreamInstanced>(loader.Invoke("glDrawTransformFeedbackStreamInstanced"));
            glLoadTransposeMatrixfARB = Marshal.GetDelegateForFunctionPointer<GLLoadTransposeMatrixfARB>(loader.Invoke("glLoadTransposeMatrixfARB"));
            glLoadTransposeMatrixdARB = Marshal.GetDelegateForFunctionPointer<GLLoadTransposeMatrixdARB>(loader.Invoke("glLoadTransposeMatrixdARB"));
            glMultTransposeMatrixfARB = Marshal.GetDelegateForFunctionPointer<GLMultTransposeMatrixfARB>(loader.Invoke("glMultTransposeMatrixfARB"));
            glMultTransposeMatrixdARB = Marshal.GetDelegateForFunctionPointer<GLMultTransposeMatrixdARB>(loader.Invoke("glMultTransposeMatrixdARB"));
            glGetUniformIndices = Marshal.GetDelegateForFunctionPointer<GLGetUniformIndices>(loader.Invoke("glGetUniformIndices"));
            glGetActiveUniformsiv = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniformsiv>(loader.Invoke("glGetActiveUniformsiv"));
            glGetActiveUniformName = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniformName>(loader.Invoke("glGetActiveUniformName"));
            glGetUniformBlockIndex = Marshal.GetDelegateForFunctionPointer<GLGetUniformBlockIndex>(loader.Invoke("glGetUniformBlockIndex"));
            glGetActiveUniformBlockiv = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniformBlockiv>(loader.Invoke("glGetActiveUniformBlockiv"));
            glGetActiveUniformBlockName = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniformBlockName>(loader.Invoke("glGetActiveUniformBlockName"));
            glUniformBlockBinding = Marshal.GetDelegateForFunctionPointer<GLUniformBlockBinding>(loader.Invoke("glUniformBlockBinding"));
            glBindBufferRange = Marshal.GetDelegateForFunctionPointer<GLBindBufferRange>(loader.Invoke("glBindBufferRange"));
            glBindBufferBase = Marshal.GetDelegateForFunctionPointer<GLBindBufferBase>(loader.Invoke("glBindBufferBase"));
            glGetIntegeri_v = Marshal.GetDelegateForFunctionPointer<GLGetIntegeri_v>(loader.Invoke("glGetIntegeri_v"));
            glBindVertexArray = Marshal.GetDelegateForFunctionPointer<GLBindVertexArray>(loader.Invoke("glBindVertexArray"));
            glDeleteVertexArrays = Marshal.GetDelegateForFunctionPointer<GLDeleteVertexArrays>(loader.Invoke("glDeleteVertexArrays"));
            glGenVertexArrays = Marshal.GetDelegateForFunctionPointer<GLGenVertexArrays>(loader.Invoke("glGenVertexArrays"));
            glIsVertexArray = Marshal.GetDelegateForFunctionPointer<GLIsVertexArray>(loader.Invoke("glIsVertexArray"));
            glVertexAttribL1d = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL1d>(loader.Invoke("glVertexAttribL1d"));
            glVertexAttribL2d = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL2d>(loader.Invoke("glVertexAttribL2d"));
            glVertexAttribL3d = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL3d>(loader.Invoke("glVertexAttribL3d"));
            glVertexAttribL4d = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL4d>(loader.Invoke("glVertexAttribL4d"));
            glVertexAttribL1dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL1dv>(loader.Invoke("glVertexAttribL1dv"));
            glVertexAttribL2dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL2dv>(loader.Invoke("glVertexAttribL2dv"));
            glVertexAttribL3dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL3dv>(loader.Invoke("glVertexAttribL3dv"));
            glVertexAttribL4dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribL4dv>(loader.Invoke("glVertexAttribL4dv"));
            glVertexAttribLPointer = Marshal.GetDelegateForFunctionPointer<GLVertexAttribLPointer>(loader.Invoke("glVertexAttribLPointer"));
            glGetVertexAttribLdv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribLdv>(loader.Invoke("glGetVertexAttribLdv"));
            glBindVertexBuffer = Marshal.GetDelegateForFunctionPointer<GLBindVertexBuffer>(loader.Invoke("glBindVertexBuffer"));
            glVertexAttribFormat = Marshal.GetDelegateForFunctionPointer<GLVertexAttribFormat>(loader.Invoke("glVertexAttribFormat"));
            glVertexAttribIFormat = Marshal.GetDelegateForFunctionPointer<GLVertexAttribIFormat>(loader.Invoke("glVertexAttribIFormat"));
            glVertexAttribLFormat = Marshal.GetDelegateForFunctionPointer<GLVertexAttribLFormat>(loader.Invoke("glVertexAttribLFormat"));
            glVertexAttribBinding = Marshal.GetDelegateForFunctionPointer<GLVertexAttribBinding>(loader.Invoke("glVertexAttribBinding"));
            glVertexBindingDivisor = Marshal.GetDelegateForFunctionPointer<GLVertexBindingDivisor>(loader.Invoke("glVertexBindingDivisor"));
            glWeightbvARB = Marshal.GetDelegateForFunctionPointer<GLWeightbvARB>(loader.Invoke("glWeightbvARB"));
            glWeightsvARB = Marshal.GetDelegateForFunctionPointer<GLWeightsvARB>(loader.Invoke("glWeightsvARB"));
            glWeightivARB = Marshal.GetDelegateForFunctionPointer<GLWeightivARB>(loader.Invoke("glWeightivARB"));
            glWeightfvARB = Marshal.GetDelegateForFunctionPointer<GLWeightfvARB>(loader.Invoke("glWeightfvARB"));
            glWeightdvARB = Marshal.GetDelegateForFunctionPointer<GLWeightdvARB>(loader.Invoke("glWeightdvARB"));
            glWeightubvARB = Marshal.GetDelegateForFunctionPointer<GLWeightubvARB>(loader.Invoke("glWeightubvARB"));
            glWeightusvARB = Marshal.GetDelegateForFunctionPointer<GLWeightusvARB>(loader.Invoke("glWeightusvARB"));
            glWeightuivARB = Marshal.GetDelegateForFunctionPointer<GLWeightuivARB>(loader.Invoke("glWeightuivARB"));
            glWeightPointerARB = Marshal.GetDelegateForFunctionPointer<GLWeightPointerARB>(loader.Invoke("glWeightPointerARB"));
            glVertexBlendARB = Marshal.GetDelegateForFunctionPointer<GLVertexBlendARB>(loader.Invoke("glVertexBlendARB"));
            glBindBufferARB = Marshal.GetDelegateForFunctionPointer<GLBindBufferARB>(loader.Invoke("glBindBufferARB"));
            glDeleteBuffersARB = Marshal.GetDelegateForFunctionPointer<GLDeleteBuffersARB>(loader.Invoke("glDeleteBuffersARB"));
            glGenBuffersARB = Marshal.GetDelegateForFunctionPointer<GLGenBuffersARB>(loader.Invoke("glGenBuffersARB"));
            glIsBufferARB = Marshal.GetDelegateForFunctionPointer<GLIsBufferARB>(loader.Invoke("glIsBufferARB"));
            glBufferDataARB = Marshal.GetDelegateForFunctionPointer<GLBufferDataARB>(loader.Invoke("glBufferDataARB"));
            glBufferSubDataARB = Marshal.GetDelegateForFunctionPointer<GLBufferSubDataARB>(loader.Invoke("glBufferSubDataARB"));
            glGetBufferSubDataARB = Marshal.GetDelegateForFunctionPointer<GLGetBufferSubDataARB>(loader.Invoke("glGetBufferSubDataARB"));
            glMapBufferARB = Marshal.GetDelegateForFunctionPointer<GLMapBufferARB>(loader.Invoke("glMapBufferARB"));
            glUnmapBufferARB = Marshal.GetDelegateForFunctionPointer<GLUnmapBufferARB>(loader.Invoke("glUnmapBufferARB"));
            glGetBufferParameterivARB = Marshal.GetDelegateForFunctionPointer<GLGetBufferParameterivARB>(loader.Invoke("glGetBufferParameterivARB"));
            glGetBufferPointervARB = Marshal.GetDelegateForFunctionPointer<GLGetBufferPointervARB>(loader.Invoke("glGetBufferPointervARB"));
            glVertexAttrib1dARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1dARB>(loader.Invoke("glVertexAttrib1dARB"));
            glVertexAttrib1dvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1dvARB>(loader.Invoke("glVertexAttrib1dvARB"));
            glVertexAttrib1fARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1fARB>(loader.Invoke("glVertexAttrib1fARB"));
            glVertexAttrib1fvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1fvARB>(loader.Invoke("glVertexAttrib1fvARB"));
            glVertexAttrib1sARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1sARB>(loader.Invoke("glVertexAttrib1sARB"));
            glVertexAttrib1svARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1svARB>(loader.Invoke("glVertexAttrib1svARB"));
            glVertexAttrib2dARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2dARB>(loader.Invoke("glVertexAttrib2dARB"));
            glVertexAttrib2dvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2dvARB>(loader.Invoke("glVertexAttrib2dvARB"));
            glVertexAttrib2fARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2fARB>(loader.Invoke("glVertexAttrib2fARB"));
            glVertexAttrib2fvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2fvARB>(loader.Invoke("glVertexAttrib2fvARB"));
            glVertexAttrib2sARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2sARB>(loader.Invoke("glVertexAttrib2sARB"));
            glVertexAttrib2svARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2svARB>(loader.Invoke("glVertexAttrib2svARB"));
            glVertexAttrib3dARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3dARB>(loader.Invoke("glVertexAttrib3dARB"));
            glVertexAttrib3dvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3dvARB>(loader.Invoke("glVertexAttrib3dvARB"));
            glVertexAttrib3fARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3fARB>(loader.Invoke("glVertexAttrib3fARB"));
            glVertexAttrib3fvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3fvARB>(loader.Invoke("glVertexAttrib3fvARB"));
            glVertexAttrib3sARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3sARB>(loader.Invoke("glVertexAttrib3sARB"));
            glVertexAttrib3svARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3svARB>(loader.Invoke("glVertexAttrib3svARB"));
            glVertexAttrib4NbvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NbvARB>(loader.Invoke("glVertexAttrib4NbvARB"));
            glVertexAttrib4NivARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NivARB>(loader.Invoke("glVertexAttrib4NivARB"));
            glVertexAttrib4NsvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NsvARB>(loader.Invoke("glVertexAttrib4NsvARB"));
            glVertexAttrib4NubARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NubARB>(loader.Invoke("glVertexAttrib4NubARB"));
            glVertexAttrib4NubvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NubvARB>(loader.Invoke("glVertexAttrib4NubvARB"));
            glVertexAttrib4NuivARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NuivARB>(loader.Invoke("glVertexAttrib4NuivARB"));
            glVertexAttrib4NusvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4NusvARB>(loader.Invoke("glVertexAttrib4NusvARB"));
            glVertexAttrib4bvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4bvARB>(loader.Invoke("glVertexAttrib4bvARB"));
            glVertexAttrib4dARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4dARB>(loader.Invoke("glVertexAttrib4dARB"));
            glVertexAttrib4dvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4dvARB>(loader.Invoke("glVertexAttrib4dvARB"));
            glVertexAttrib4fARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4fARB>(loader.Invoke("glVertexAttrib4fARB"));
            glVertexAttrib4fvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4fvARB>(loader.Invoke("glVertexAttrib4fvARB"));
            glVertexAttrib4ivARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4ivARB>(loader.Invoke("glVertexAttrib4ivARB"));
            glVertexAttrib4sARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4sARB>(loader.Invoke("glVertexAttrib4sARB"));
            glVertexAttrib4svARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4svARB>(loader.Invoke("glVertexAttrib4svARB"));
            glVertexAttrib4ubvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4ubvARB>(loader.Invoke("glVertexAttrib4ubvARB"));
            glVertexAttrib4uivARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4uivARB>(loader.Invoke("glVertexAttrib4uivARB"));
            glVertexAttrib4usvARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4usvARB>(loader.Invoke("glVertexAttrib4usvARB"));
            glVertexAttribPointerARB = Marshal.GetDelegateForFunctionPointer<GLVertexAttribPointerARB>(loader.Invoke("glVertexAttribPointerARB"));
            glEnableVertexAttribArrayARB = Marshal.GetDelegateForFunctionPointer<GLEnableVertexAttribArrayARB>(loader.Invoke("glEnableVertexAttribArrayARB"));
            glDisableVertexAttribArrayARB = Marshal.GetDelegateForFunctionPointer<GLDisableVertexAttribArrayARB>(loader.Invoke("glDisableVertexAttribArrayARB"));
            glGetVertexAttribdvARB = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribdvARB>(loader.Invoke("glGetVertexAttribdvARB"));
            glGetVertexAttribfvARB = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribfvARB>(loader.Invoke("glGetVertexAttribfvARB"));
            glGetVertexAttribivARB = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribivARB>(loader.Invoke("glGetVertexAttribivARB"));
            glGetVertexAttribPointervARB = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribPointervARB>(loader.Invoke("glGetVertexAttribPointervARB"));
            glBindAttribLocationARB = Marshal.GetDelegateForFunctionPointer<GLBindAttribLocationARB>(loader.Invoke("glBindAttribLocationARB"));
            glGetActiveAttribARB = Marshal.GetDelegateForFunctionPointer<GLGetActiveAttribARB>(loader.Invoke("glGetActiveAttribARB"));
            glGetAttribLocationARB = Marshal.GetDelegateForFunctionPointer<GLGetAttribLocationARB>(loader.Invoke("glGetAttribLocationARB"));
            glVertexAttribP1ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP1ui>(loader.Invoke("glVertexAttribP1ui"));
            glVertexAttribP1uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP1uiv>(loader.Invoke("glVertexAttribP1uiv"));
            glVertexAttribP2ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP2ui>(loader.Invoke("glVertexAttribP2ui"));
            glVertexAttribP2uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP2uiv>(loader.Invoke("glVertexAttribP2uiv"));
            glVertexAttribP3ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP3ui>(loader.Invoke("glVertexAttribP3ui"));
            glVertexAttribP3uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP3uiv>(loader.Invoke("glVertexAttribP3uiv"));
            glVertexAttribP4ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP4ui>(loader.Invoke("glVertexAttribP4ui"));
            glVertexAttribP4uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribP4uiv>(loader.Invoke("glVertexAttribP4uiv"));
            glViewportArrayv = Marshal.GetDelegateForFunctionPointer<GLViewportArrayv>(loader.Invoke("glViewportArrayv"));
            glViewportIndexedf = Marshal.GetDelegateForFunctionPointer<GLViewportIndexedf>(loader.Invoke("glViewportIndexedf"));
            glViewportIndexedfv = Marshal.GetDelegateForFunctionPointer<GLViewportIndexedfv>(loader.Invoke("glViewportIndexedfv"));
            glScissorArrayv = Marshal.GetDelegateForFunctionPointer<GLScissorArrayv>(loader.Invoke("glScissorArrayv"));
            glScissorIndexed = Marshal.GetDelegateForFunctionPointer<GLScissorIndexed>(loader.Invoke("glScissorIndexed"));
            glScissorIndexedv = Marshal.GetDelegateForFunctionPointer<GLScissorIndexedv>(loader.Invoke("glScissorIndexedv"));
            glDepthRangeArrayv = Marshal.GetDelegateForFunctionPointer<GLDepthRangeArrayv>(loader.Invoke("glDepthRangeArrayv"));
            glDepthRangeIndexed = Marshal.GetDelegateForFunctionPointer<GLDepthRangeIndexed>(loader.Invoke("glDepthRangeIndexed"));
            glGetFloati_v = Marshal.GetDelegateForFunctionPointer<GLGetFloati_v>(loader.Invoke("glGetFloati_v"));
            glGetDoublei_v = Marshal.GetDelegateForFunctionPointer<GLGetDoublei_v>(loader.Invoke("glGetDoublei_v"));
            glDepthRangeArraydvNV = Marshal.GetDelegateForFunctionPointer<GLDepthRangeArraydvNV>(loader.Invoke("glDepthRangeArraydvNV"));
            glDepthRangeIndexeddNV = Marshal.GetDelegateForFunctionPointer<GLDepthRangeIndexeddNV>(loader.Invoke("glDepthRangeIndexeddNV"));
            glWindowPos2dARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2dARB>(loader.Invoke("glWindowPos2dARB"));
            glWindowPos2dvARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2dvARB>(loader.Invoke("glWindowPos2dvARB"));
            glWindowPos2fARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2fARB>(loader.Invoke("glWindowPos2fARB"));
            glWindowPos2fvARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2fvARB>(loader.Invoke("glWindowPos2fvARB"));
            glWindowPos2iARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2iARB>(loader.Invoke("glWindowPos2iARB"));
            glWindowPos2ivARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2ivARB>(loader.Invoke("glWindowPos2ivARB"));
            glWindowPos2sARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2sARB>(loader.Invoke("glWindowPos2sARB"));
            glWindowPos2svARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos2svARB>(loader.Invoke("glWindowPos2svARB"));
            glWindowPos3dARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3dARB>(loader.Invoke("glWindowPos3dARB"));
            glWindowPos3dvARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3dvARB>(loader.Invoke("glWindowPos3dvARB"));
            glWindowPos3fARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3fARB>(loader.Invoke("glWindowPos3fARB"));
            glWindowPos3fvARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3fvARB>(loader.Invoke("glWindowPos3fvARB"));
            glWindowPos3iARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3iARB>(loader.Invoke("glWindowPos3iARB"));
            glWindowPos3ivARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3ivARB>(loader.Invoke("glWindowPos3ivARB"));
            glWindowPos3sARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3sARB>(loader.Invoke("glWindowPos3sARB"));
            glWindowPos3svARB = Marshal.GetDelegateForFunctionPointer<GLWindowPos3svARB>(loader.Invoke("glWindowPos3svARB"));
            glBlendBarrierKHR = Marshal.GetDelegateForFunctionPointer<GLBlendBarrierKHR>(loader.Invoke("glBlendBarrierKHR"));
            glDebugMessageControl = Marshal.GetDelegateForFunctionPointer<GLDebugMessageControl>(loader.Invoke("glDebugMessageControl"));
            glDebugMessageInsert = Marshal.GetDelegateForFunctionPointer<GLDebugMessageInsert>(loader.Invoke("glDebugMessageInsert"));
            glDebugMessageCallback = Marshal.GetDelegateForFunctionPointer<GLDebugMessageCallback>(loader.Invoke("glDebugMessageCallback"));
            glGetDebugMessageLog = Marshal.GetDelegateForFunctionPointer<GLGetDebugMessageLog>(loader.Invoke("glGetDebugMessageLog"));
            glPushDebugGroup = Marshal.GetDelegateForFunctionPointer<GLPushDebugGroup>(loader.Invoke("glPushDebugGroup"));
            glPopDebugGroup = Marshal.GetDelegateForFunctionPointer<GLPopDebugGroup>(loader.Invoke("glPopDebugGroup"));
            glObjectLabel = Marshal.GetDelegateForFunctionPointer<GLObjectLabel>(loader.Invoke("glObjectLabel"));
            glGetObjectLabel = Marshal.GetDelegateForFunctionPointer<GLGetObjectLabel>(loader.Invoke("glGetObjectLabel"));
            glObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<GLObjectPtrLabel>(loader.Invoke("glObjectPtrLabel"));
            glGetObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<GLGetObjectPtrLabel>(loader.Invoke("glGetObjectPtrLabel"));
            glDebugMessageControlKHR = Marshal.GetDelegateForFunctionPointer<GLDebugMessageControlKHR>(loader.Invoke("glDebugMessageControlKHR"));
            glDebugMessageInsertKHR = Marshal.GetDelegateForFunctionPointer<GLDebugMessageInsertKHR>(loader.Invoke("glDebugMessageInsertKHR"));
            glDebugMessageCallbackKHR = Marshal.GetDelegateForFunctionPointer<GLDebugMessageCallbackKHR>(loader.Invoke("glDebugMessageCallbackKHR"));
            glGetDebugMessageLogKHR = Marshal.GetDelegateForFunctionPointer<GLGetDebugMessageLogKHR>(loader.Invoke("glGetDebugMessageLogKHR"));
            glPushDebugGroupKHR = Marshal.GetDelegateForFunctionPointer<GLPushDebugGroupKHR>(loader.Invoke("glPushDebugGroupKHR"));
            glPopDebugGroupKHR = Marshal.GetDelegateForFunctionPointer<GLPopDebugGroupKHR>(loader.Invoke("glPopDebugGroupKHR"));
            glObjectLabelKHR = Marshal.GetDelegateForFunctionPointer<GLObjectLabelKHR>(loader.Invoke("glObjectLabelKHR"));
            glGetObjectLabelKHR = Marshal.GetDelegateForFunctionPointer<GLGetObjectLabelKHR>(loader.Invoke("glGetObjectLabelKHR"));
            glObjectPtrLabelKHR = Marshal.GetDelegateForFunctionPointer<GLObjectPtrLabelKHR>(loader.Invoke("glObjectPtrLabelKHR"));
            glGetObjectPtrLabelKHR = Marshal.GetDelegateForFunctionPointer<GLGetObjectPtrLabelKHR>(loader.Invoke("glGetObjectPtrLabelKHR"));
            glGetPointervKHR = Marshal.GetDelegateForFunctionPointer<GLGetPointervKHR>(loader.Invoke("glGetPointervKHR"));
            glGetGraphicsResetStatus = Marshal.GetDelegateForFunctionPointer<GLGetGraphicsResetStatus>(loader.Invoke("glGetGraphicsResetStatus"));
            glReadnPixels = Marshal.GetDelegateForFunctionPointer<GLReadnPixels>(loader.Invoke("glReadnPixels"));
            glGetnUniformfv = Marshal.GetDelegateForFunctionPointer<GLGetnUniformfv>(loader.Invoke("glGetnUniformfv"));
            glGetnUniformiv = Marshal.GetDelegateForFunctionPointer<GLGetnUniformiv>(loader.Invoke("glGetnUniformiv"));
            glGetnUniformuiv = Marshal.GetDelegateForFunctionPointer<GLGetnUniformuiv>(loader.Invoke("glGetnUniformuiv"));
            glGetGraphicsResetStatusKHR = Marshal.GetDelegateForFunctionPointer<GLGetGraphicsResetStatusKHR>(loader.Invoke("glGetGraphicsResetStatusKHR"));
            glReadnPixelsKHR = Marshal.GetDelegateForFunctionPointer<GLReadnPixelsKHR>(loader.Invoke("glReadnPixelsKHR"));
            glGetnUniformfvKHR = Marshal.GetDelegateForFunctionPointer<GLGetnUniformfvKHR>(loader.Invoke("glGetnUniformfvKHR"));
            glGetnUniformivKHR = Marshal.GetDelegateForFunctionPointer<GLGetnUniformivKHR>(loader.Invoke("glGetnUniformivKHR"));
            glGetnUniformuivKHR = Marshal.GetDelegateForFunctionPointer<GLGetnUniformuivKHR>(loader.Invoke("glGetnUniformuivKHR"));
            glMaxShaderCompilerThreadsKHR = Marshal.GetDelegateForFunctionPointer<GLMaxShaderCompilerThreadsKHR>(loader.Invoke("glMaxShaderCompilerThreadsKHR"));
            glFramebufferTextureMultiviewOVR = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureMultiviewOVR>(loader.Invoke("glFramebufferTextureMultiviewOVR"));
            glFramebufferTextureMultisampleMultiviewOVR = Marshal.GetDelegateForFunctionPointer<GLFramebufferTextureMultisampleMultiviewOVR>(loader.Invoke("glFramebufferTextureMultisampleMultiviewOVR"));
            glDrawArrays = Marshal.GetDelegateForFunctionPointer<GLDrawArrays>(loader.Invoke("glDrawArrays"));
            glDrawElements = Marshal.GetDelegateForFunctionPointer<GLDrawElements>(loader.Invoke("glDrawElements"));
            glPolygonOffset = Marshal.GetDelegateForFunctionPointer<GLPolygonOffset>(loader.Invoke("glPolygonOffset"));
            glCopyTexImage1D = Marshal.GetDelegateForFunctionPointer<GLCopyTexImage1D>(loader.Invoke("glCopyTexImage1D"));
            glCopyTexImage2D = Marshal.GetDelegateForFunctionPointer<GLCopyTexImage2D>(loader.Invoke("glCopyTexImage2D"));
            glCopyTexSubImage1D = Marshal.GetDelegateForFunctionPointer<GLCopyTexSubImage1D>(loader.Invoke("glCopyTexSubImage1D"));
            glCopyTexSubImage2D = Marshal.GetDelegateForFunctionPointer<GLCopyTexSubImage2D>(loader.Invoke("glCopyTexSubImage2D"));
            glTexSubImage1D = Marshal.GetDelegateForFunctionPointer<GLTexSubImage1D>(loader.Invoke("glTexSubImage1D"));
            glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<GLTexSubImage2D>(loader.Invoke("glTexSubImage2D"));
            glBindTexture = Marshal.GetDelegateForFunctionPointer<GLBindTexture>(loader.Invoke("glBindTexture"));
            glDeleteTextures = Marshal.GetDelegateForFunctionPointer<GLDeleteTextures>(loader.Invoke("glDeleteTextures"));
            glGenTextures = Marshal.GetDelegateForFunctionPointer<GLGenTextures>(loader.Invoke("glGenTextures"));
            glIsTexture = Marshal.GetDelegateForFunctionPointer<GLIsTexture>(loader.Invoke("glIsTexture"));
            glDrawRangeElements = Marshal.GetDelegateForFunctionPointer<GLDrawRangeElements>(loader.Invoke("glDrawRangeElements"));
            glTexImage3D = Marshal.GetDelegateForFunctionPointer<GLTexImage3D>(loader.Invoke("glTexImage3D"));
            glTexSubImage3D = Marshal.GetDelegateForFunctionPointer<GLTexSubImage3D>(loader.Invoke("glTexSubImage3D"));
            glCopyTexSubImage3D = Marshal.GetDelegateForFunctionPointer<GLCopyTexSubImage3D>(loader.Invoke("glCopyTexSubImage3D"));
            glActiveTexture = Marshal.GetDelegateForFunctionPointer<GLActiveTexture>(loader.Invoke("glActiveTexture"));
            glSampleCoverage = Marshal.GetDelegateForFunctionPointer<GLSampleCoverage>(loader.Invoke("glSampleCoverage"));
            glCompressedTexImage3D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage3D>(loader.Invoke("glCompressedTexImage3D"));
            glCompressedTexImage2D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage2D>(loader.Invoke("glCompressedTexImage2D"));
            glCompressedTexImage1D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexImage1D>(loader.Invoke("glCompressedTexImage1D"));
            glCompressedTexSubImage3D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage3D>(loader.Invoke("glCompressedTexSubImage3D"));
            glCompressedTexSubImage2D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage2D>(loader.Invoke("glCompressedTexSubImage2D"));
            glCompressedTexSubImage1D = Marshal.GetDelegateForFunctionPointer<GLCompressedTexSubImage1D>(loader.Invoke("glCompressedTexSubImage1D"));
            glGetCompressedTexImage = Marshal.GetDelegateForFunctionPointer<GLGetCompressedTexImage>(loader.Invoke("glGetCompressedTexImage"));
            glBlendFuncSeparate = Marshal.GetDelegateForFunctionPointer<GLBlendFuncSeparate>(loader.Invoke("glBlendFuncSeparate"));
            glMultiDrawArrays = Marshal.GetDelegateForFunctionPointer<GLMultiDrawArrays>(loader.Invoke("glMultiDrawArrays"));
            glMultiDrawElements = Marshal.GetDelegateForFunctionPointer<GLMultiDrawElements>(loader.Invoke("glMultiDrawElements"));
            glPointParameterf = Marshal.GetDelegateForFunctionPointer<GLPointParameterf>(loader.Invoke("glPointParameterf"));
            glPointParameterfv = Marshal.GetDelegateForFunctionPointer<GLPointParameterfv>(loader.Invoke("glPointParameterfv"));
            glPointParameteri = Marshal.GetDelegateForFunctionPointer<GLPointParameteri>(loader.Invoke("glPointParameteri"));
            glPointParameteriv = Marshal.GetDelegateForFunctionPointer<GLPointParameteriv>(loader.Invoke("glPointParameteriv"));
            glMinSampleShading = Marshal.GetDelegateForFunctionPointer<GLMinSampleShading>(loader.Invoke("glMinSampleShading"));
            glPrimitiveBoundingBox = Marshal.GetDelegateForFunctionPointer<GLPrimitiveBoundingBox>(loader.Invoke("glPrimitiveBoundingBox"));
            glBlendFuncSeparatei = Marshal.GetDelegateForFunctionPointer<GLBlendFuncSeparatei>(loader.Invoke("glBlendFuncSeparatei"));
            glBlendFunci = Marshal.GetDelegateForFunctionPointer<GLBlendFunci>(loader.Invoke("glBlendFunci"));
            glBlendEquationSeparatei = Marshal.GetDelegateForFunctionPointer<GLBlendEquationSeparatei>(loader.Invoke("glBlendEquationSeparatei"));
            glBlendEquationi = Marshal.GetDelegateForFunctionPointer<GLBlendEquationi>(loader.Invoke("glBlendEquationi"));
            glBlendBarrier = Marshal.GetDelegateForFunctionPointer<GLBlendBarrier>(loader.Invoke("glBlendBarrier"));
            glVertexAttribDivisor = Marshal.GetDelegateForFunctionPointer<GLVertexAttribDivisor>(loader.Invoke("glVertexAttribDivisor"));
            glGetPointerv = Marshal.GetDelegateForFunctionPointer<GLGetPointerv>(loader.Invoke("glGetPointerv"));
            glGenQueries = Marshal.GetDelegateForFunctionPointer<GLGenQueries>(loader.Invoke("glGenQueries"));
            glDeleteQueries = Marshal.GetDelegateForFunctionPointer<GLDeleteQueries>(loader.Invoke("glDeleteQueries"));
            glIsQuery = Marshal.GetDelegateForFunctionPointer<GLIsQuery>(loader.Invoke("glIsQuery"));
            glBeginQuery = Marshal.GetDelegateForFunctionPointer<GLBeginQuery>(loader.Invoke("glBeginQuery"));
            glEndQuery = Marshal.GetDelegateForFunctionPointer<GLEndQuery>(loader.Invoke("glEndQuery"));
            glGetQueryiv = Marshal.GetDelegateForFunctionPointer<GLGetQueryiv>(loader.Invoke("glGetQueryiv"));
            glGetQueryObjectiv = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjectiv>(loader.Invoke("glGetQueryObjectiv"));
            glGetQueryObjectuiv = Marshal.GetDelegateForFunctionPointer<GLGetQueryObjectuiv>(loader.Invoke("glGetQueryObjectuiv"));
            glBindBuffer = Marshal.GetDelegateForFunctionPointer<GLBindBuffer>(loader.Invoke("glBindBuffer"));
            glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<GLDeleteBuffers>(loader.Invoke("glDeleteBuffers"));
            glGenBuffers = Marshal.GetDelegateForFunctionPointer<GLGenBuffers>(loader.Invoke("glGenBuffers"));
            glIsBuffer = Marshal.GetDelegateForFunctionPointer<GLIsBuffer>(loader.Invoke("glIsBuffer"));
            glBufferData = Marshal.GetDelegateForFunctionPointer<GLBufferData>(loader.Invoke("glBufferData"));
            glBufferSubData = Marshal.GetDelegateForFunctionPointer<GLBufferSubData>(loader.Invoke("glBufferSubData"));
            glGetBufferSubData = Marshal.GetDelegateForFunctionPointer<GLGetBufferSubData>(loader.Invoke("glGetBufferSubData"));
            glMapBuffer = Marshal.GetDelegateForFunctionPointer<GLMapBuffer>(loader.Invoke("glMapBuffer"));
            glUnmapBuffer = Marshal.GetDelegateForFunctionPointer<GLUnmapBuffer>(loader.Invoke("glUnmapBuffer"));
            glGetBufferParameteriv = Marshal.GetDelegateForFunctionPointer<GLGetBufferParameteriv>(loader.Invoke("glGetBufferParameteriv"));
            glGetBufferPointerv = Marshal.GetDelegateForFunctionPointer<GLGetBufferPointerv>(loader.Invoke("glGetBufferPointerv"));
            glBlendEquationSeparate = Marshal.GetDelegateForFunctionPointer<GLBlendEquationSeparate>(loader.Invoke("glBlendEquationSeparate"));
            glDrawBuffers = Marshal.GetDelegateForFunctionPointer<GLDrawBuffers>(loader.Invoke("glDrawBuffers"));
            glStencilOpSeparate = Marshal.GetDelegateForFunctionPointer<GLStencilOpSeparate>(loader.Invoke("glStencilOpSeparate"));
            glStencilFuncSeparate = Marshal.GetDelegateForFunctionPointer<GLStencilFuncSeparate>(loader.Invoke("glStencilFuncSeparate"));
            glStencilMaskSeparate = Marshal.GetDelegateForFunctionPointer<GLStencilMaskSeparate>(loader.Invoke("glStencilMaskSeparate"));
            glAttachShader = Marshal.GetDelegateForFunctionPointer<GLAttachShader>(loader.Invoke("glAttachShader"));
            glBindAttribLocation = Marshal.GetDelegateForFunctionPointer<GLBindAttribLocation>(loader.Invoke("glBindAttribLocation"));
            glCompileShader = Marshal.GetDelegateForFunctionPointer<GLCompileShader>(loader.Invoke("glCompileShader"));
            glCreateProgram = Marshal.GetDelegateForFunctionPointer<GLCreateProgram>(loader.Invoke("glCreateProgram"));
            glCreateShader = Marshal.GetDelegateForFunctionPointer<GLCreateShader>(loader.Invoke("glCreateShader"));
            glDeleteProgram = Marshal.GetDelegateForFunctionPointer<GLDeleteProgram>(loader.Invoke("glDeleteProgram"));
            glDeleteShader = Marshal.GetDelegateForFunctionPointer<GLDeleteShader>(loader.Invoke("glDeleteShader"));
            glDetachShader = Marshal.GetDelegateForFunctionPointer<GLDetachShader>(loader.Invoke("glDetachShader"));
            glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<GLDisableVertexAttribArray>(loader.Invoke("glDisableVertexAttribArray"));
            glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<GLEnableVertexAttribArray>(loader.Invoke("glEnableVertexAttribArray"));
            glGetActiveAttrib = Marshal.GetDelegateForFunctionPointer<GLGetActiveAttrib>(loader.Invoke("glGetActiveAttrib"));
            glGetActiveUniform = Marshal.GetDelegateForFunctionPointer<GLGetActiveUniform>(loader.Invoke("glGetActiveUniform"));
            glGetAttachedShaders = Marshal.GetDelegateForFunctionPointer<GLGetAttachedShaders>(loader.Invoke("glGetAttachedShaders"));
            glGetAttribLocation = Marshal.GetDelegateForFunctionPointer<GLGetAttribLocation>(loader.Invoke("glGetAttribLocation"));
            glGetProgramiv = Marshal.GetDelegateForFunctionPointer<GLGetProgramiv>(loader.Invoke("glGetProgramiv"));
            glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<GLGetProgramInfoLog>(loader.Invoke("glGetProgramInfoLog"));
            glGetShaderiv = Marshal.GetDelegateForFunctionPointer<GLGetShaderiv>(loader.Invoke("glGetShaderiv"));
            glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<GLGetShaderInfoLog>(loader.Invoke("glGetShaderInfoLog"));
            glGetShaderSource = Marshal.GetDelegateForFunctionPointer<GLGetShaderSource>(loader.Invoke("glGetShaderSource"));
            glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<GLGetUniformLocation>(loader.Invoke("glGetUniformLocation"));
            glGetUniformfv = Marshal.GetDelegateForFunctionPointer<GLGetUniformfv>(loader.Invoke("glGetUniformfv"));
            glGetUniformiv = Marshal.GetDelegateForFunctionPointer<GLGetUniformiv>(loader.Invoke("glGetUniformiv"));
            glGetVertexAttribdv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribdv>(loader.Invoke("glGetVertexAttribdv"));
            glGetVertexAttribfv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribfv>(loader.Invoke("glGetVertexAttribfv"));
            glGetVertexAttribiv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribiv>(loader.Invoke("glGetVertexAttribiv"));
            glGetVertexAttribPointerv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribPointerv>(loader.Invoke("glGetVertexAttribPointerv"));
            glIsProgram = Marshal.GetDelegateForFunctionPointer<GLIsProgram>(loader.Invoke("glIsProgram"));
            glIsShader = Marshal.GetDelegateForFunctionPointer<GLIsShader>(loader.Invoke("glIsShader"));
            glLinkProgram = Marshal.GetDelegateForFunctionPointer<GLLinkProgram>(loader.Invoke("glLinkProgram"));
            glShaderSource = Marshal.GetDelegateForFunctionPointer<GLShaderSource>(loader.Invoke("glShaderSource"));
            glUseProgram = Marshal.GetDelegateForFunctionPointer<GLUseProgram>(loader.Invoke("glUseProgram"));
            glUniform1f = Marshal.GetDelegateForFunctionPointer<GLUniform1f>(loader.Invoke("glUniform1f"));
            glUniform2f = Marshal.GetDelegateForFunctionPointer<GLUniform2f>(loader.Invoke("glUniform2f"));
            glUniform3f = Marshal.GetDelegateForFunctionPointer<GLUniform3f>(loader.Invoke("glUniform3f"));
            glUniform4f = Marshal.GetDelegateForFunctionPointer<GLUniform4f>(loader.Invoke("glUniform4f"));
            glUniform1i = Marshal.GetDelegateForFunctionPointer<GLUniform1i>(loader.Invoke("glUniform1i"));
            glUniform2i = Marshal.GetDelegateForFunctionPointer<GLUniform2i>(loader.Invoke("glUniform2i"));
            glUniform3i = Marshal.GetDelegateForFunctionPointer<GLUniform3i>(loader.Invoke("glUniform3i"));
            glUniform4i = Marshal.GetDelegateForFunctionPointer<GLUniform4i>(loader.Invoke("glUniform4i"));
            glUniform1fv = Marshal.GetDelegateForFunctionPointer<GLUniform1fv>(loader.Invoke("glUniform1fv"));
            glUniform2fv = Marshal.GetDelegateForFunctionPointer<GLUniform2fv>(loader.Invoke("glUniform2fv"));
            glUniform3fv = Marshal.GetDelegateForFunctionPointer<GLUniform3fv>(loader.Invoke("glUniform3fv"));
            glUniform4fv = Marshal.GetDelegateForFunctionPointer<GLUniform4fv>(loader.Invoke("glUniform4fv"));
            glUniform1iv = Marshal.GetDelegateForFunctionPointer<GLUniform1iv>(loader.Invoke("glUniform1iv"));
            glUniform2iv = Marshal.GetDelegateForFunctionPointer<GLUniform2iv>(loader.Invoke("glUniform2iv"));
            glUniform3iv = Marshal.GetDelegateForFunctionPointer<GLUniform3iv>(loader.Invoke("glUniform3iv"));
            glUniform4iv = Marshal.GetDelegateForFunctionPointer<GLUniform4iv>(loader.Invoke("glUniform4iv"));
            glUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2fv>(loader.Invoke("glUniformMatrix2fv"));
            glUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3fv>(loader.Invoke("glUniformMatrix3fv"));
            glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4fv>(loader.Invoke("glUniformMatrix4fv"));
            glValidateProgram = Marshal.GetDelegateForFunctionPointer<GLValidateProgram>(loader.Invoke("glValidateProgram"));
            glVertexAttrib1d = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1d>(loader.Invoke("glVertexAttrib1d"));
            glVertexAttrib1dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1dv>(loader.Invoke("glVertexAttrib1dv"));
            glVertexAttrib1f = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1f>(loader.Invoke("glVertexAttrib1f"));
            glVertexAttrib1fv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1fv>(loader.Invoke("glVertexAttrib1fv"));
            glVertexAttrib1s = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1s>(loader.Invoke("glVertexAttrib1s"));
            glVertexAttrib1sv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib1sv>(loader.Invoke("glVertexAttrib1sv"));
            glVertexAttrib2d = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2d>(loader.Invoke("glVertexAttrib2d"));
            glVertexAttrib2dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2dv>(loader.Invoke("glVertexAttrib2dv"));
            glVertexAttrib2f = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2f>(loader.Invoke("glVertexAttrib2f"));
            glVertexAttrib2fv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2fv>(loader.Invoke("glVertexAttrib2fv"));
            glVertexAttrib2s = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2s>(loader.Invoke("glVertexAttrib2s"));
            glVertexAttrib2sv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib2sv>(loader.Invoke("glVertexAttrib2sv"));
            glVertexAttrib3d = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3d>(loader.Invoke("glVertexAttrib3d"));
            glVertexAttrib3dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3dv>(loader.Invoke("glVertexAttrib3dv"));
            glVertexAttrib3f = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3f>(loader.Invoke("glVertexAttrib3f"));
            glVertexAttrib3fv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3fv>(loader.Invoke("glVertexAttrib3fv"));
            glVertexAttrib3s = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3s>(loader.Invoke("glVertexAttrib3s"));
            glVertexAttrib3sv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib3sv>(loader.Invoke("glVertexAttrib3sv"));
            glVertexAttrib4Nbv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nbv>(loader.Invoke("glVertexAttrib4Nbv"));
            glVertexAttrib4Niv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Niv>(loader.Invoke("glVertexAttrib4Niv"));
            glVertexAttrib4Nsv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nsv>(loader.Invoke("glVertexAttrib4Nsv"));
            glVertexAttrib4Nub = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nub>(loader.Invoke("glVertexAttrib4Nub"));
            glVertexAttrib4Nubv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nubv>(loader.Invoke("glVertexAttrib4Nubv"));
            glVertexAttrib4Nuiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nuiv>(loader.Invoke("glVertexAttrib4Nuiv"));
            glVertexAttrib4Nusv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4Nusv>(loader.Invoke("glVertexAttrib4Nusv"));
            glVertexAttrib4bv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4bv>(loader.Invoke("glVertexAttrib4bv"));
            glVertexAttrib4d = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4d>(loader.Invoke("glVertexAttrib4d"));
            glVertexAttrib4dv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4dv>(loader.Invoke("glVertexAttrib4dv"));
            glVertexAttrib4f = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4f>(loader.Invoke("glVertexAttrib4f"));
            glVertexAttrib4fv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4fv>(loader.Invoke("glVertexAttrib4fv"));
            glVertexAttrib4iv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4iv>(loader.Invoke("glVertexAttrib4iv"));
            glVertexAttrib4s = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4s>(loader.Invoke("glVertexAttrib4s"));
            glVertexAttrib4sv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4sv>(loader.Invoke("glVertexAttrib4sv"));
            glVertexAttrib4ubv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4ubv>(loader.Invoke("glVertexAttrib4ubv"));
            glVertexAttrib4uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4uiv>(loader.Invoke("glVertexAttrib4uiv"));
            glVertexAttrib4usv = Marshal.GetDelegateForFunctionPointer<GLVertexAttrib4usv>(loader.Invoke("glVertexAttrib4usv"));
            glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<GLVertexAttribPointer>(loader.Invoke("glVertexAttribPointer"));
            glUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2x3fv>(loader.Invoke("glUniformMatrix2x3fv"));
            glUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3x2fv>(loader.Invoke("glUniformMatrix3x2fv"));
            glUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix2x4fv>(loader.Invoke("glUniformMatrix2x4fv"));
            glUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4x2fv>(loader.Invoke("glUniformMatrix4x2fv"));
            glUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix3x4fv>(loader.Invoke("glUniformMatrix3x4fv"));
            glUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<GLUniformMatrix4x3fv>(loader.Invoke("glUniformMatrix4x3fv"));
            glColorMaski = Marshal.GetDelegateForFunctionPointer<GLColorMaski>(loader.Invoke("glColorMaski"));
            glGetBooleani_v = Marshal.GetDelegateForFunctionPointer<GLGetBooleani_v>(loader.Invoke("glGetBooleani_v"));
            glEnablei = Marshal.GetDelegateForFunctionPointer<GLEnablei>(loader.Invoke("glEnablei"));
            glDisablei = Marshal.GetDelegateForFunctionPointer<GLDisablei>(loader.Invoke("glDisablei"));
            glIsEnabledi = Marshal.GetDelegateForFunctionPointer<GLIsEnabledi>(loader.Invoke("glIsEnabledi"));
            glBeginTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLBeginTransformFeedback>(loader.Invoke("glBeginTransformFeedback"));
            glEndTransformFeedback = Marshal.GetDelegateForFunctionPointer<GLEndTransformFeedback>(loader.Invoke("glEndTransformFeedback"));
            glTransformFeedbackVaryings = Marshal.GetDelegateForFunctionPointer<GLTransformFeedbackVaryings>(loader.Invoke("glTransformFeedbackVaryings"));
            glGetTransformFeedbackVarying = Marshal.GetDelegateForFunctionPointer<GLGetTransformFeedbackVarying>(loader.Invoke("glGetTransformFeedbackVarying"));
            glClampColor = Marshal.GetDelegateForFunctionPointer<GLClampColor>(loader.Invoke("glClampColor"));
            glBeginConditionalRender = Marshal.GetDelegateForFunctionPointer<GLBeginConditionalRender>(loader.Invoke("glBeginConditionalRender"));
            glEndConditionalRender = Marshal.GetDelegateForFunctionPointer<GLEndConditionalRender>(loader.Invoke("glEndConditionalRender"));
            glVertexAttribIPointer = Marshal.GetDelegateForFunctionPointer<GLVertexAttribIPointer>(loader.Invoke("glVertexAttribIPointer"));
            glGetVertexAttribIiv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribIiv>(loader.Invoke("glGetVertexAttribIiv"));
            glGetVertexAttribIuiv = Marshal.GetDelegateForFunctionPointer<GLGetVertexAttribIuiv>(loader.Invoke("glGetVertexAttribIuiv"));
            glVertexAttribI1i = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI1i>(loader.Invoke("glVertexAttribI1i"));
            glVertexAttribI2i = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI2i>(loader.Invoke("glVertexAttribI2i"));
            glVertexAttribI3i = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI3i>(loader.Invoke("glVertexAttribI3i"));
            glVertexAttribI4i = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4i>(loader.Invoke("glVertexAttribI4i"));
            glVertexAttribI1ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI1ui>(loader.Invoke("glVertexAttribI1ui"));
            glVertexAttribI2ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI2ui>(loader.Invoke("glVertexAttribI2ui"));
            glVertexAttribI3ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI3ui>(loader.Invoke("glVertexAttribI3ui"));
            glVertexAttribI4ui = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4ui>(loader.Invoke("glVertexAttribI4ui"));
            glVertexAttribI1iv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI1iv>(loader.Invoke("glVertexAttribI1iv"));
            glVertexAttribI2iv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI2iv>(loader.Invoke("glVertexAttribI2iv"));
            glVertexAttribI3iv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI3iv>(loader.Invoke("glVertexAttribI3iv"));
            glVertexAttribI4iv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4iv>(loader.Invoke("glVertexAttribI4iv"));
            glVertexAttribI1uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI1uiv>(loader.Invoke("glVertexAttribI1uiv"));
            glVertexAttribI2uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI2uiv>(loader.Invoke("glVertexAttribI2uiv"));
            glVertexAttribI3uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI3uiv>(loader.Invoke("glVertexAttribI3uiv"));
            glVertexAttribI4uiv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4uiv>(loader.Invoke("glVertexAttribI4uiv"));
            glVertexAttribI4bv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4bv>(loader.Invoke("glVertexAttribI4bv"));
            glVertexAttribI4sv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4sv>(loader.Invoke("glVertexAttribI4sv"));
            glVertexAttribI4ubv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4ubv>(loader.Invoke("glVertexAttribI4ubv"));
            glVertexAttribI4usv = Marshal.GetDelegateForFunctionPointer<GLVertexAttribI4usv>(loader.Invoke("glVertexAttribI4usv"));
            glGetUniformuiv = Marshal.GetDelegateForFunctionPointer<GLGetUniformuiv>(loader.Invoke("glGetUniformuiv"));
            glBindFragDataLocation = Marshal.GetDelegateForFunctionPointer<GLBindFragDataLocation>(loader.Invoke("glBindFragDataLocation"));
            glGetFragDataLocation = Marshal.GetDelegateForFunctionPointer<GLGetFragDataLocation>(loader.Invoke("glGetFragDataLocation"));
            glUniform1ui = Marshal.GetDelegateForFunctionPointer<GLUniform1ui>(loader.Invoke("glUniform1ui"));
            glUniform2ui = Marshal.GetDelegateForFunctionPointer<GLUniform2ui>(loader.Invoke("glUniform2ui"));
            glUniform3ui = Marshal.GetDelegateForFunctionPointer<GLUniform3ui>(loader.Invoke("glUniform3ui"));
            glUniform4ui = Marshal.GetDelegateForFunctionPointer<GLUniform4ui>(loader.Invoke("glUniform4ui"));
            glUniform1uiv = Marshal.GetDelegateForFunctionPointer<GLUniform1uiv>(loader.Invoke("glUniform1uiv"));
            glUniform2uiv = Marshal.GetDelegateForFunctionPointer<GLUniform2uiv>(loader.Invoke("glUniform2uiv"));
            glUniform3uiv = Marshal.GetDelegateForFunctionPointer<GLUniform3uiv>(loader.Invoke("glUniform3uiv"));
            glUniform4uiv = Marshal.GetDelegateForFunctionPointer<GLUniform4uiv>(loader.Invoke("glUniform4uiv"));
            glTexParameterIiv = Marshal.GetDelegateForFunctionPointer<GLTexParameterIiv>(loader.Invoke("glTexParameterIiv"));
            glTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLTexParameterIuiv>(loader.Invoke("glTexParameterIuiv"));
            glGetTexParameterIiv = Marshal.GetDelegateForFunctionPointer<GLGetTexParameterIiv>(loader.Invoke("glGetTexParameterIiv"));
            glGetTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<GLGetTexParameterIuiv>(loader.Invoke("glGetTexParameterIuiv"));
            glClearBufferiv = Marshal.GetDelegateForFunctionPointer<GLClearBufferiv>(loader.Invoke("glClearBufferiv"));
            glClearBufferuiv = Marshal.GetDelegateForFunctionPointer<GLClearBufferuiv>(loader.Invoke("glClearBufferuiv"));
            glClearBufferfv = Marshal.GetDelegateForFunctionPointer<GLClearBufferfv>(loader.Invoke("glClearBufferfv"));
            glClearBufferfi = Marshal.GetDelegateForFunctionPointer<GLClearBufferfi>(loader.Invoke("glClearBufferfi"));
            glGetStringi = Marshal.GetDelegateForFunctionPointer<GLGetStringi>(loader.Invoke("glGetStringi"));
            glDrawArraysInstanced = Marshal.GetDelegateForFunctionPointer<GLDrawArraysInstanced>(loader.Invoke("glDrawArraysInstanced"));
            glDrawElementsInstanced = Marshal.GetDelegateForFunctionPointer<GLDrawElementsInstanced>(loader.Invoke("glDrawElementsInstanced"));
            glTexBuffer = Marshal.GetDelegateForFunctionPointer<GLTexBuffer>(loader.Invoke("glTexBuffer"));
            glPrimitiveRestartIndex = Marshal.GetDelegateForFunctionPointer<GLPrimitiveRestartIndex>(loader.Invoke("glPrimitiveRestartIndex"));
            glGetInteger64i_v = Marshal.GetDelegateForFunctionPointer<GLGetInteger64i_v>(loader.Invoke("glGetInteger64i_v"));
            glGetBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<GLGetBufferParameteri64v>(loader.Invoke("glGetBufferParameteri64v"));
            glFramebufferTexture = Marshal.GetDelegateForFunctionPointer<GLFramebufferTexture>(loader.Invoke("glFramebufferTexture"));
        }
    }
}
