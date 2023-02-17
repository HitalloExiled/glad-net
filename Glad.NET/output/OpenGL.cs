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
    class OpenGLExtensionAttribute : Attribute
    {
        public string Name { get; }
        
        public OpenGLExtensionAttribute(string name) => Name = name;
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

    [OpenGLExtension("GL_KHR_debug")]
    ContextFlagDebugBitKhr = 0x00000002,
    ContextFlagRobustAccessBit = 0x00000004,
    ContextFlagNoErrorBit = 0x00000008,

    [OpenGLExtension("GL_KHR_no_error")]
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

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureBasicBitKhr = 0x00000001,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureVoteBitKhr = 0x00000002,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureArithmeticBitKhr = 0x00000004,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureBallotBitKhr = 0x00000008,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureShuffleBitKhr = 0x00000010,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureShuffleRelativeBitKhr = 0x00000020,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupFeatureClusteredBitKhr = 0x00000040,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
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
    LineStripAdjacency = 0x000B,
    TrianglesAdjacency = 0x000C,
    TriangleStripAdjacency = 0x000D,
    Patches = 0x000E,
}
    
public enum GlEnum
{

    [OpenGLExtension("GL_KHR_debug")]
    StackOverflowKhr = 0x0503,

    [OpenGLExtension("GL_KHR_debug")]
    StackUnderflowKhr = 0x0504,
    ContextLost = 0x0507,

    [OpenGLExtension("GL_KHR_robustness")]
    ContextLostKhr = 0x0507,
    TextureTarget = 0x1006,
    RescaleNormal = 0x803A,
    Texture3DBindingOES = 0x806A,
    TextureDepth = 0x8071,

    [OpenGLExtension("GL_KHR_debug")]
    VertexArrayKhr = 0x8074,
    ParameterBufferBinding = 0x80EF,
    FramebufferDefault = 0x8218,
    PrimitiveRestartForPatchesSupported = 0x8221,
    Index = 0x8222,

    [OpenGLExtension("GL_KHR_debug")]
    DebugOutputSynchronousKhr = 0x8242,
    DebugNextLoggedMessageLength = 0x8243,

    [OpenGLExtension("GL_KHR_debug")]
    DebugNextLoggedMessageLengthKhr = 0x8243,

    [OpenGLExtension("GL_KHR_debug")]
    DebugCallbackFunctionKhr = 0x8244,

    [OpenGLExtension("GL_KHR_debug")]
    DebugCallbackUserParamKhr = 0x8245,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceApiKhr = 0x8246,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceWindowSystemKhr = 0x8247,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceShaderCompilerKhr = 0x8248,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceThirdPartyKhr = 0x8249,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceApplicationKhr = 0x824A,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSourceOtherKhr = 0x824B,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypeErrorKhr = 0x824C,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypeDeprecatedBehaviorKhr = 0x824D,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypeUndefinedBehaviorKhr = 0x824E,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypePortabilityKhr = 0x824F,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypePerformanceKhr = 0x8250,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypeOtherKhr = 0x8251,
    LoseContextOnReset = 0x8252,

    [OpenGLExtension("GL_KHR_robustness")]
    LoseContextOnResetKhr = 0x8252,

    [OpenGLExtension("GL_KHR_robustness")]
    GuiltyContextResetKhr = 0x8253,

    [OpenGLExtension("GL_KHR_robustness")]
    InnocentContextResetKhr = 0x8254,

    [OpenGLExtension("GL_KHR_robustness")]
    UnknownContextResetKhr = 0x8255,
    ResetNotificationStrategy = 0x8256,

    [OpenGLExtension("GL_KHR_robustness")]
    ResetNotificationStrategyKhr = 0x8256,
    ViewportSubpixelBitsEXT = 0x825C,
    ViewportBoundsRangeEXT = 0x825D,
    ViewportIndexProvokingVertexEXT = 0x825F,
    UndefinedVertex = 0x8260,
    NoResetNotification = 0x8261,

    [OpenGLExtension("GL_KHR_robustness")]
    NoResetNotificationKhr = 0x8261,
    MaxComputeSharedMemorySize = 0x8262,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypeMarkerKhr = 0x8268,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypePushGroupKhr = 0x8269,

    [OpenGLExtension("GL_KHR_debug")]
    DebugTypePopGroupKhr = 0x826A,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSeverityNotificationKhr = 0x826B,

    [OpenGLExtension("GL_KHR_debug")]
    MaxDebugGroupStackDepthKhr = 0x826C,

    [OpenGLExtension("GL_KHR_debug")]
    DebugGroupStackDepthKhr = 0x826D,
    MaxCombinedDimensions = 0x8282,
    DepthComponents = 0x8284,
    StencilComponents = 0x8285,
    ManualGenerateMipmap = 0x8294,
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

    [OpenGLExtension("GL_KHR_debug")]
    BufferKhr = 0x82E0,

    [OpenGLExtension("GL_KHR_debug")]
    ShaderKhr = 0x82E1,

    [OpenGLExtension("GL_KHR_debug")]
    ProgramKhr = 0x82E2,

    [OpenGLExtension("GL_KHR_debug")]
    QueryKhr = 0x82E3,

    [OpenGLExtension("GL_KHR_debug")]
    ProgramPipelineKhr = 0x82E4,
    MaxVertexAttribStride = 0x82E5,

    [OpenGLExtension("GL_KHR_debug")]
    SamplerKhr = 0x82E6,
    DisplayList = 0x82E7,

    [OpenGLExtension("GL_KHR_debug")]
    MaxLabelLengthKhr = 0x82E8,
    NumShadingLanguageVersions = 0x82E9,
    TransformFeedbackStreamOverflow = 0x82ED,
    TessControlShaderPatches = 0x82F1,
    TessEvaluationShaderInvocations = 0x82F2,
    GeometryShaderPrimitivesEmitted = 0x82F3,
    FragmentShaderInvocations = 0x82F4,
    ComputeShaderInvocations = 0x82F5,
    ClippingInputPrimitives = 0x82F6,
    ClippingOutputPrimitives = 0x82F7,
    MaxCullDistances = 0x82F9,
    MaxCombinedClipAndCullDistances = 0x82FA,
    ContextReleaseBehavior = 0x82FB,

    [OpenGLExtension("GL_KHR_context_flush_control")]
    ContextReleaseBehaviorKhr = 0x82FB,
    ContextReleaseBehaviorFlush = 0x82FC,

    [OpenGLExtension("GL_KHR_context_flush_control")]
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
    CurrentSecondaryColor = 0x8459,
    SecondaryColorArraySize = 0x845A,
    SecondaryColorArrayType = 0x845B,
    SecondaryColorArrayStride = 0x845C,
    SecondaryColorArrayPointer = 0x845D,
    SecondaryColorArray = 0x845E,
    CurrentRasterSecondaryColor = 0x845F,
    ClientActiveTexture = 0x84E1,
    MaxTextureUnits = 0x84E2,
    TransposeModelviewMatrix = 0x84E3,
    TransposeProjectionMatrix = 0x84E4,
    TransposeTextureMatrix = 0x84E5,
    TransposeColorMatrix = 0x84E6,
    Subtract = 0x84E7,
    CompressedAlpha = 0x84E9,
    CompressedLuminance = 0x84EA,
    CompressedLuminanceAlpha = 0x84EB,
    CompressedIntensity = 0x84EC,
    MaxTextureMaxAnisotropy = 0x84FF,
    VertexProgramPointSize = 0x8642,
    VertexProgramTwoSide = 0x8643,
    TextureCompressedImageSize = 0x86A0,
    Dot3Rgb = 0x86AE,
    Dot3Rgba = 0x86AF,
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
    DrawBuffer0 = 0x8825,
    DrawBuffer1 = 0x8826,
    DrawBuffer2 = 0x8827,
    DrawBuffer3 = 0x8828,
    DrawBuffer4 = 0x8829,
    DrawBuffer5 = 0x882A,
    DrawBuffer6 = 0x882B,
    DrawBuffer7 = 0x882C,
    DrawBuffer8 = 0x882D,
    DrawBuffer9 = 0x882E,
    DrawBuffer10 = 0x882F,
    DrawBuffer11 = 0x8830,
    DrawBuffer12 = 0x8831,
    DrawBuffer13 = 0x8832,
    DrawBuffer14 = 0x8833,
    DrawBuffer15 = 0x8834,
    CompressedLuminanceAlpha3dcATI = 0x8837,
    TextureDepthSize = 0x884A,
    DepthTextureMode = 0x884B,
    MaxTessControlInputComponents = 0x886C,
    MaxTessEvaluationInputComponents = 0x886D,
    MaxTextureCoords = 0x8871,
    GeometryShaderInvocations = 0x887F,
    VertexArrayBufferBinding = 0x8896,
    NormalArrayBufferBinding = 0x8897,
    ColorArrayBufferBinding = 0x8898,
    IndexArrayBufferBinding = 0x8899,
    TextureCoordArrayBufferBinding = 0x889A,
    EdgeFlagArrayBufferBinding = 0x889B,
    SecondaryColorArrayBufferBinding = 0x889C,
    FogCoordinateArrayBufferBinding = 0x889D,
    FogCoordArrayBufferBinding = 0x889D,
    WeightArrayBufferBinding = 0x889E,
    TextureStencilSize = 0x88F1,
    ClampVertexColor = 0x891A,
    ClampFragmentColor = 0x891B,
    FragmentProgramPositionMESA = 0x8BB0,
    FragmentProgramCallbackMESA = 0x8BB1,
    FragmentProgramCallbackFuncMESA = 0x8BB2,
    FragmentProgramCallbackDataMESA = 0x8BB3,
    VertexProgramPositionMESA = 0x8BB4,
    VertexProgramCallbackMESA = 0x8BB5,
    VertexProgramCallbackFuncMESA = 0x8BB6,
    VertexProgramCallbackDataMESA = 0x8BB7,
    TextureRedType = 0x8C10,
    TextureGreenType = 0x8C11,
    TextureBlueType = 0x8C12,
    TextureAlphaType = 0x8C13,
    TextureLuminanceType = 0x8C14,
    TextureIntensityType = 0x8C15,
    TextureDepthType = 0x8C16,
    UnsignedNormalized = 0x8C17,
    TextureBufferBinding = 0x8C2A,
    TextureBufferDataStoreBinding = 0x8C2D,
    MinSampleShadingValue = 0x8C37,
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
    MaxGeometryOutputVertices = 0x8DE0,
    MaxGeometryTotalOutputComponents = 0x8DE1,
    MaxSubroutines = 0x8DE7,
    MaxSubroutineUniformLocations = 0x8DE8,
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
    MaxProgramTextureGatherOffset = 0x8E5F,
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
    TextureBindingCubeMapArray = 0x900A,
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
    ContextRobustAccess = 0x90F3,

    [OpenGLExtension("GL_KHR_robustness")]
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

    [OpenGLExtension("GL_KHR_debug")]
    MaxDebugMessageLengthKhr = 0x9143,
    MaxDebugLoggedMessages = 0x9144,

    [OpenGLExtension("GL_KHR_debug")]
    MaxDebugLoggedMessagesKhr = 0x9144,
    DebugLoggedMessages = 0x9145,

    [OpenGLExtension("GL_KHR_debug")]
    DebugLoggedMessagesKhr = 0x9145,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSeverityHighKhr = 0x9146,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSeverityMediumKhr = 0x9147,

    [OpenGLExtension("GL_KHR_debug")]
    DebugSeverityLowKhr = 0x9148,
    QueryBufferBinding = 0x9193,
    TextureBufferOffset = 0x919D,
    TextureBufferSize = 0x919E,

    [OpenGLExtension("GL_KHR_parallel_shader_compile")]
    MaxShaderCompilerThreadsKhr = 0x91B0,

    [OpenGLExtension("GL_KHR_parallel_shader_compile")]
    CompletionStatusKhr = 0x91B1,
    MaxComputeImageUniforms = 0x91BD,
    UnpackFlipYWebgl = 0x9240,
    UnpackPremultiplyAlphaWebgl = 0x9241,
    ContextLostWebgl = 0x9242,
    UnpackColorspaceConversionWebgl = 0x9243,
    BrowserDefaultWebgl = 0x9244,

    [OpenGLExtension("GL_KHR_blend_equation_advanced_coherent")]
    BlendAdvancedCoherentKhr = 0x9285,
    Multiply = 0x9294,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    MultiplyKhr = 0x9294,
    Screen = 0x9295,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    ScreenKhr = 0x9295,
    Overlay = 0x9296,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    OverlayKhr = 0x9296,
    Darken = 0x9297,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    DarkenKhr = 0x9297,
    Lighten = 0x9298,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    LightenKhr = 0x9298,
    Colordodge = 0x9299,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    ColordodgeKhr = 0x9299,
    Colorburn = 0x929A,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    ColorburnKhr = 0x929A,
    Hardlight = 0x929B,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    HardlightKhr = 0x929B,
    Softlight = 0x929C,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    SoftlightKhr = 0x929C,
    Difference = 0x929E,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    DifferenceKhr = 0x929E,
    Exclusion = 0x92A0,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    ExclusionKhr = 0x92A0,
    HslHue = 0x92AD,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    HslHueKhr = 0x92AD,
    HslSaturation = 0x92AE,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    HslSaturationKhr = 0x92AE,
    HslColor = 0x92AF,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    HslColorKhr = 0x92AF,
    HslLuminosity = 0x92B0,

    [OpenGLExtension("GL_KHR_blend_equation_advanced")]
    HslLuminosityKhr = 0x92B0,
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

    [OpenGLExtension("GL_KHR_debug")]
    DebugOutputKhr = 0x92E0,
    ClipOrigin = 0x935C,
    ClipDepthMode = 0x935D,
    MultisampleLineWidthRange = 0x9381,
    MultisampleLineWidthGranularity = 0x9382,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupSizeKhr = 0x9532,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedStagesKhr = 0x9533,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedFeaturesKhr = 0x9534,

    [OpenGLExtension("GL_KHR_shader_subgroup")]
    SubgroupQuadAllStagesKhr = 0x9535,
    SpirVBinary = 0x9552,
    SpirVExtensions = 0x9553,
    NumSpirVExtensions = 0x9554,

    [OpenGLExtension("GL_OVR_multiview")]
    MaxViewsOvr = 0x9631,

    [OpenGLExtension("GL_OVR_multiview")]
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
    PointSizeMax = 0x8127,
    PointFadeThresholdSize = 0x8128,
    PointDistanceAttenuation = 0x8129,
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
    MaxRectangleTextureSize = 0x84F8,
    MaxTextureLodBias = 0x84FD,
    TextureBindingCubeMap = 0x8514,
    MaxCubeMapTextureSize = 0x851C,
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
    TextureCubeMap = 0x8513,
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
    FragmentShaderDerivativeHint = 0x8B8B,
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
    CombineRgb = 0x8571,
    CombineAlpha = 0x8572,
    RgbScale = 0x8573,
    AddSigned = 0x8574,
    Interpolate = 0x8575,
    Constant = 0x8576,
    PrimaryColor = 0x8577,
    Previous = 0x8578,
    Source0Rgb = 0x8580,
    Src0Rgb = 0x8580,
    Source1Rgb = 0x8581,
    Src1Rgb = 0x8581,
    Source2Rgb = 0x8582,
    Src2Rgb = 0x8582,
    Source0Alpha = 0x8588,
    Src0Alpha = 0x8588,
    Source1Alpha = 0x8589,
    Src1Alpha = 0x8589,
    Source2Alpha = 0x858A,
    Src2Alpha = 0x858A,
    Operand0Rgb = 0x8590,
    Operand1Rgb = 0x8591,
    Operand2Rgb = 0x8592,
    Operand0Alpha = 0x8598,
    Operand1Alpha = 0x8599,
    Operand2Alpha = 0x859A,
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
    ProxyTextureRectangle = 0x84F7,
    TextureCubeMap = 0x8513,
    TextureCubeMapPositiveX = 0x8515,
    TextureCubeMapNegativeX = 0x8516,
    TextureCubeMapPositiveY = 0x8517,
    TextureCubeMapNegativeY = 0x8518,
    TextureCubeMapPositiveZ = 0x8519,
    TextureCubeMapNegativeZ = 0x851A,
    ProxyTextureCubeMap = 0x851B,
    Texture1DArray = 0x8C18,
    ProxyTexture1DArray = 0x8C19,
    Texture2DArray = 0x8C1A,
    ProxyTexture2DArray = 0x8C1B,
    TextureBuffer = 0x8C2A,
    Renderbuffer = 0x8D41,
    TextureCubeMapArray = 0x9009,
    ProxyTextureCubeMapArray = 0x900B,
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
    ReflectionMap = 0x8512,
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
    DepthComponent24 = 0x81A6,
    DepthComponent32 = 0x81A7,
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
    Rgb32f = 0x8815,
    Rgba16f = 0x881A,
    Rgb16f = 0x881B,
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
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,
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

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc4x4Khr = 0x93B0,
    CompressedRgbaAstc5x4 = 0x93B1,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x4Khr = 0x93B1,
    CompressedRgbaAstc5x5 = 0x93B2,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x5Khr = 0x93B2,
    CompressedRgbaAstc6x5 = 0x93B3,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x5Khr = 0x93B3,
    CompressedRgbaAstc6x6 = 0x93B4,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x6Khr = 0x93B4,
    CompressedRgbaAstc8x5 = 0x93B5,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x5Khr = 0x93B5,
    CompressedRgbaAstc8x6 = 0x93B6,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x6Khr = 0x93B6,
    CompressedRgbaAstc8x8 = 0x93B7,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x8Khr = 0x93B7,
    CompressedRgbaAstc10x5 = 0x93B8,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x5Khr = 0x93B8,
    CompressedRgbaAstc10x6 = 0x93B9,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x6Khr = 0x93B9,
    CompressedRgbaAstc10x8 = 0x93BA,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x8Khr = 0x93BA,
    CompressedRgbaAstc10x10 = 0x93BB,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x10Khr = 0x93BB,
    CompressedRgbaAstc12x10 = 0x93BC,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x10Khr = 0x93BC,
    CompressedRgbaAstc12x12 = 0x93BD,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x12Khr = 0x93BD,
    CompressedSrgb8Alpha8Astc4x4 = 0x93D0,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc4x4Khr = 0x93D0,
    CompressedSrgb8Alpha8Astc5x4 = 0x93D1,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x4Khr = 0x93D1,
    CompressedSrgb8Alpha8Astc5x5 = 0x93D2,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x5Khr = 0x93D2,
    CompressedSrgb8Alpha8Astc6x5 = 0x93D3,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x5Khr = 0x93D3,
    CompressedSrgb8Alpha8Astc6x6 = 0x93D4,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x6Khr = 0x93D4,
    CompressedSrgb8Alpha8Astc8x5 = 0x93D5,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x5Khr = 0x93D5,
    CompressedSrgb8Alpha8Astc8x6 = 0x93D6,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x6Khr = 0x93D6,
    CompressedSrgb8Alpha8Astc8x8 = 0x93D7,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x8Khr = 0x93D7,
    CompressedSrgb8Alpha8Astc10x5 = 0x93D8,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x5Khr = 0x93D8,
    CompressedSrgb8Alpha8Astc10x6 = 0x93D9,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x6Khr = 0x93D9,
    CompressedSrgb8Alpha8Astc10x8 = 0x93DA,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x8Khr = 0x93DA,
    CompressedSrgb8Alpha8Astc10x10 = 0x93DB,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x10Khr = 0x93DB,
    CompressedSrgb8Alpha8Astc12x10 = 0x93DC,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x10Khr = 0x93DC,
    CompressedSrgb8Alpha8Astc12x12 = 0x93DD,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
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
    DepthComponent24 = 0x81A6,
    DepthComponent32 = 0x81A7,
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
    Rgb32f = 0x8815,
    Rgba16f = 0x881A,
    Rgb16f = 0x881B,
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
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,
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

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc4x4Khr = 0x93B0,
    CompressedRgbaAstc5x4 = 0x93B1,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x4Khr = 0x93B1,
    CompressedRgbaAstc5x5 = 0x93B2,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc5x5Khr = 0x93B2,
    CompressedRgbaAstc6x5 = 0x93B3,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x5Khr = 0x93B3,
    CompressedRgbaAstc6x6 = 0x93B4,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc6x6Khr = 0x93B4,
    CompressedRgbaAstc8x5 = 0x93B5,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x5Khr = 0x93B5,
    CompressedRgbaAstc8x6 = 0x93B6,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x6Khr = 0x93B6,
    CompressedRgbaAstc8x8 = 0x93B7,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc8x8Khr = 0x93B7,
    CompressedRgbaAstc10x5 = 0x93B8,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x5Khr = 0x93B8,
    CompressedRgbaAstc10x6 = 0x93B9,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x6Khr = 0x93B9,
    CompressedRgbaAstc10x8 = 0x93BA,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x8Khr = 0x93BA,
    CompressedRgbaAstc10x10 = 0x93BB,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc10x10Khr = 0x93BB,
    CompressedRgbaAstc12x10 = 0x93BC,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x10Khr = 0x93BC,
    CompressedRgbaAstc12x12 = 0x93BD,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedRgbaAstc12x12Khr = 0x93BD,
    CompressedSrgb8Alpha8Astc4x4 = 0x93D0,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc4x4Khr = 0x93D0,
    CompressedSrgb8Alpha8Astc5x4 = 0x93D1,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x4Khr = 0x93D1,
    CompressedSrgb8Alpha8Astc5x5 = 0x93D2,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc5x5Khr = 0x93D2,
    CompressedSrgb8Alpha8Astc6x5 = 0x93D3,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x5Khr = 0x93D3,
    CompressedSrgb8Alpha8Astc6x6 = 0x93D4,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc6x6Khr = 0x93D4,
    CompressedSrgb8Alpha8Astc8x5 = 0x93D5,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x5Khr = 0x93D5,
    CompressedSrgb8Alpha8Astc8x6 = 0x93D6,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x6Khr = 0x93D6,
    CompressedSrgb8Alpha8Astc8x8 = 0x93D7,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc8x8Khr = 0x93D7,
    CompressedSrgb8Alpha8Astc10x5 = 0x93D8,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x5Khr = 0x93D8,
    CompressedSrgb8Alpha8Astc10x6 = 0x93D9,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x6Khr = 0x93D9,
    CompressedSrgb8Alpha8Astc10x8 = 0x93DA,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x8Khr = 0x93DA,
    CompressedSrgb8Alpha8Astc10x10 = 0x93DB,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc10x10Khr = 0x93DB,
    CompressedSrgb8Alpha8Astc12x10 = 0x93DC,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
    CompressedSrgb8Alpha8Astc12x10Khr = 0x93DC,
    CompressedSrgb8Alpha8Astc12x12 = 0x93DD,

    [OpenGLExtension("GL_KHR_texture_compression_astc_hdr")]
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
    
public enum MinmaxTarget
{
    Minmax = 0x802E,
}
    
public enum MinmaxTargetEXT
{
    Minmax = 0x802E,
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
    PointSizeMax = 0x8127,
    PointFadeThresholdSize = 0x8128,
    PointDistanceAttenuation = 0x8129,
}
    
public enum LightModelColorControl
{
    SingleColor = 0x81F9,
    SeparateSpecularColor = 0x81FA,
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

    [OpenGLExtension("GL_OVR_multiview")]
    FramebufferAttachmentTextureNumViewsOvr = 0x9630,

    [OpenGLExtension("GL_OVR_multiview")]
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
    BufferUsage = 0x8765,
    BufferAccess = 0x88BB,
    BufferMapped = 0x88BC,
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
    
public enum VertexAttribPointerPropertyARB
{
    VertexAttribArrayPointer = 0x8645,
}
    
public enum QueryParameterName
{
    QueryCounterBits = 0x8864,
    CurrentQuery = 0x8865,
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
    ClampReadColor = 0x891C,
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
    VertexShader = 0x8B31,
    GeometryShader = 0x8DD9,
    TessEvaluationShader = 0x8E87,
    TessControlShader = 0x8E88,
    ComputeShader = 0x91B9,
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
    
    public class OpenGL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCullFace(out nint mode);
        private readonly OpenGLCullFace glCullFace;
        
        public void CullFace(out nint mode) =>
            this.glCullFace.Invoke(out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFrontFace(out nint mode);
        private readonly OpenGLFrontFace glFrontFace;
        
        public void FrontFace(out nint mode) =>
            this.glFrontFace.Invoke(out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLHint(out nint target, out nint mode);
        private readonly OpenGLHint glHint;
        
        public void Hint(out nint target, out nint mode) =>
            this.glHint.Invoke(out target, out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLLineWidth(out nint width);
        private readonly OpenGLLineWidth glLineWidth;
        
        public void LineWidth(out nint width) =>
            this.glLineWidth.Invoke(out width);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPointSize(out nint size);
        private readonly OpenGLPointSize glPointSize;
        
        public void PointSize(out nint size) =>
            this.glPointSize.Invoke(out size);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPolygonMode(out nint face, out nint mode);
        private readonly OpenGLPolygonMode glPolygonMode;
        
        public void PolygonMode(out nint face, out nint mode) =>
            this.glPolygonMode.Invoke(out face, out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLScissor(out nint x, out nint y, out nint width, out nint height);
        private readonly OpenGLScissor glScissor;
        
        public void Scissor(out nint x, out nint y, out nint width, out nint height) =>
            this.glScissor.Invoke(out x, out y, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameterf(out nint target, out nint pname, out nint param);
        private readonly OpenGLTexParameterf glTexParameterf;
        
        public void TexParameterf(out nint target, out nint pname, out nint param) =>
            this.glTexParameterf.Invoke(out target, out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameterfv(out nint target, out nint pname, nint @params);
        private readonly OpenGLTexParameterfv glTexParameterfv;
        
        public void TexParameterfv(out nint target, out nint pname, nint @params) =>
            this.glTexParameterfv.Invoke(out target, out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameteri(out nint target, out nint pname, out nint param);
        private readonly OpenGLTexParameteri glTexParameteri;
        
        public void TexParameteri(out nint target, out nint pname, out nint param) =>
            this.glTexParameteri.Invoke(out target, out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameteriv(out nint target, out nint pname, nint @params);
        private readonly OpenGLTexParameteriv glTexParameteriv;
        
        public void TexParameteriv(out nint target, out nint pname, nint @params) =>
            this.glTexParameteriv.Invoke(out target, out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexImage1D(out nint target, out nint level, out nint internalformat, out nint width, out nint border, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexImage1D glTexImage1D;
        
        public void TexImage1D(out nint target, out nint level, out nint internalformat, out nint width, out nint border, out nint format, out nint type, nint pixels) =>
            this.glTexImage1D.Invoke(out target, out level, out internalformat, out width, out border, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexImage2D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint border, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexImage2D glTexImage2D;
        
        public void TexImage2D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint border, out nint format, out nint type, nint pixels) =>
            this.glTexImage2D.Invoke(out target, out level, out internalformat, out width, out height, out border, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawBuffer(out nint buf);
        private readonly OpenGLDrawBuffer glDrawBuffer;
        
        public void DrawBuffer(out nint buf) =>
            this.glDrawBuffer.Invoke(out buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClear(out nint mask);
        private readonly OpenGLClear glClear;
        
        public void Clear(out nint mask) =>
            this.glClear.Invoke(out mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearColor(out nint red, out nint green, out nint blue, out nint alpha);
        private readonly OpenGLClearColor glClearColor;
        
        public void ClearColor(out nint red, out nint green, out nint blue, out nint alpha) =>
            this.glClearColor.Invoke(out red, out green, out blue, out alpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearStencil(out nint s);
        private readonly OpenGLClearStencil glClearStencil;
        
        public void ClearStencil(out nint s) =>
            this.glClearStencil.Invoke(out s);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearDepth(out nint depth);
        private readonly OpenGLClearDepth glClearDepth;
        
        public void ClearDepth(out nint depth) =>
            this.glClearDepth.Invoke(out depth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilMask(out nint mask);
        private readonly OpenGLStencilMask glStencilMask;
        
        public void StencilMask(out nint mask) =>
            this.glStencilMask.Invoke(out mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLColorMask(out nint red, out nint green, out nint blue, out nint alpha);
        private readonly OpenGLColorMask glColorMask;
        
        public void ColorMask(out nint red, out nint green, out nint blue, out nint alpha) =>
            this.glColorMask.Invoke(out red, out green, out blue, out alpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDepthMask(out nint flag);
        private readonly OpenGLDepthMask glDepthMask;
        
        public void DepthMask(out nint flag) =>
            this.glDepthMask.Invoke(out flag);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDisable(out nint cap);
        private readonly OpenGLDisable glDisable;
        
        public void Disable(out nint cap) =>
            this.glDisable.Invoke(out cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEnable(out nint cap);
        private readonly OpenGLEnable glEnable;
        
        public void Enable(out nint cap) =>
            this.glEnable.Invoke(out cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFinish();
        private readonly OpenGLFinish glFinish;
        
        public void Finish() =>
            this.glFinish.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFlush();
        private readonly OpenGLFlush glFlush;
        
        public void Flush() =>
            this.glFlush.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendFunc(out nint sfactor, out nint dfactor);
        private readonly OpenGLBlendFunc glBlendFunc;
        
        public void BlendFunc(out nint sfactor, out nint dfactor) =>
            this.glBlendFunc.Invoke(out sfactor, out dfactor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLLogicOp(out nint opcode);
        private readonly OpenGLLogicOp glLogicOp;
        
        public void LogicOp(out nint opcode) =>
            this.glLogicOp.Invoke(out opcode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilFunc(out nint func, out nint @ref, out nint mask);
        private readonly OpenGLStencilFunc glStencilFunc;
        
        public void StencilFunc(out nint func, out nint @ref, out nint mask) =>
            this.glStencilFunc.Invoke(out func, out @ref, out mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilOp(out nint fail, out nint zfail, out nint zpass);
        private readonly OpenGLStencilOp glStencilOp;
        
        public void StencilOp(out nint fail, out nint zfail, out nint zpass) =>
            this.glStencilOp.Invoke(out fail, out zfail, out zpass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDepthFunc(out nint func);
        private readonly OpenGLDepthFunc glDepthFunc;
        
        public void DepthFunc(out nint func) =>
            this.glDepthFunc.Invoke(out func);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPixelStoref(out nint pname, out nint param);
        private readonly OpenGLPixelStoref glPixelStoref;
        
        public void PixelStoref(out nint pname, out nint param) =>
            this.glPixelStoref.Invoke(out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPixelStorei(out nint pname, out nint param);
        private readonly OpenGLPixelStorei glPixelStorei;
        
        public void PixelStorei(out nint pname, out nint param) =>
            this.glPixelStorei.Invoke(out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLReadBuffer(out nint src);
        private readonly OpenGLReadBuffer glReadBuffer;
        
        public void ReadBuffer(out nint src) =>
            this.glReadBuffer.Invoke(out src);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLReadPixels(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint pixels);
        private readonly OpenGLReadPixels glReadPixels;
        
        public void ReadPixels(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint pixels) =>
            this.glReadPixels.Invoke(out x, out y, out width, out height, out format, out type, out pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBooleanv(out nint pname, out nint data);
        private readonly OpenGLGetBooleanv glGetBooleanv;
        
        public void GetBooleanv(out nint pname, out nint data) =>
            this.glGetBooleanv.Invoke(out pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetDoublev(out nint pname, out nint data);
        private readonly OpenGLGetDoublev glGetDoublev;
        
        public void GetDoublev(out nint pname, out nint data) =>
            this.glGetDoublev.Invoke(out pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ErrorCode OpenGLGetError();
        private readonly OpenGLGetError glGetError;
        
        public ErrorCode GetError() =>
            this.glGetError.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetFloatv(out nint pname, out nint data);
        private readonly OpenGLGetFloatv glGetFloatv;
        
        public void GetFloatv(out nint pname, out nint data) =>
            this.glGetFloatv.Invoke(out pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetIntegerv(out nint pname, out nint data);
        private readonly OpenGLGetIntegerv glGetIntegerv;
        
        public void GetIntegerv(out nint pname, out nint data) =>
            this.glGetIntegerv.Invoke(out pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint OpenGLGetString(out nint name);
        private readonly OpenGLGetString glGetString;
        
        public nint GetString(out nint name) =>
            this.glGetString.Invoke(out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexImage(out nint target, out nint level, out nint format, out nint type, out nint pixels);
        private readonly OpenGLGetTexImage glGetTexImage;
        
        public void GetTexImage(out nint target, out nint level, out nint format, out nint type, out nint pixels) =>
            this.glGetTexImage.Invoke(out target, out level, out format, out type, out pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexParameterfv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetTexParameterfv glGetTexParameterfv;
        
        public void GetTexParameterfv(out nint target, out nint pname, out nint @params) =>
            this.glGetTexParameterfv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexParameteriv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetTexParameteriv glGetTexParameteriv;
        
        public void GetTexParameteriv(out nint target, out nint pname, out nint @params) =>
            this.glGetTexParameteriv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexLevelParameterfv(out nint target, out nint level, out nint pname, out nint @params);
        private readonly OpenGLGetTexLevelParameterfv glGetTexLevelParameterfv;
        
        public void GetTexLevelParameterfv(out nint target, out nint level, out nint pname, out nint @params) =>
            this.glGetTexLevelParameterfv.Invoke(out target, out level, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexLevelParameteriv(out nint target, out nint level, out nint pname, out nint @params);
        private readonly OpenGLGetTexLevelParameteriv glGetTexLevelParameteriv;
        
        public void GetTexLevelParameteriv(out nint target, out nint level, out nint pname, out nint @params) =>
            this.glGetTexLevelParameteriv.Invoke(out target, out level, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsEnabled(out nint cap);
        private readonly OpenGLIsEnabled glIsEnabled;
        
        public bool IsEnabled(out nint cap) =>
            this.glIsEnabled.Invoke(out cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDepthRange(out nint n, out nint f);
        private readonly OpenGLDepthRange glDepthRange;
        
        public void DepthRange(out nint n, out nint f) =>
            this.glDepthRange.Invoke(out n, out f);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLViewport(out nint x, out nint y, out nint width, out nint height);
        private readonly OpenGLViewport glViewport;
        
        public void Viewport(out nint x, out nint y, out nint width, out nint height) =>
            this.glViewport.Invoke(out x, out y, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexStorage3DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint depth, out nint fixedsamplelocations);
        private readonly OpenGLTexStorage3DMultisample glTexStorage3DMultisample;
        
        public void TexStorage3DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint depth, out nint fixedsamplelocations) =>
            this.glTexStorage3DMultisample.Invoke(out target, out samples, out internalformat, out width, out height, out depth, out fixedsamplelocations);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexBufferRange(out nint target, out nint internalformat, out nint buffer, out nint offset, out nint size);
        private readonly OpenGLTexBufferRange glTexBufferRange;
        
        public void TexBufferRange(out nint target, out nint internalformat, out nint buffer, out nint offset, out nint size) =>
            this.glTexBufferRange.Invoke(out target, out internalformat, out buffer, out offset, out size);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPatchParameteri(out nint pname, out nint value);
        private readonly OpenGLPatchParameteri glPatchParameteri;
        
        public void PatchParameteri(out nint pname, out nint value) =>
            this.glPatchParameteri.Invoke(out pname, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMinSampleShading(out nint value);
        private readonly OpenGLMinSampleShading glMinSampleShading;
        
        public void MinSampleShading(out nint value) =>
            this.glMinSampleShading.Invoke(out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPrimitiveBoundingBox(out nint minX, out nint minY, out nint minZ, out nint minW, out nint maxX, out nint maxY, out nint maxZ, out nint maxW);
        private readonly OpenGLPrimitiveBoundingBox glPrimitiveBoundingBox;
        
        public void PrimitiveBoundingBox(out nint minX, out nint minY, out nint minZ, out nint minW, out nint maxX, out nint maxY, out nint maxZ, out nint maxW) =>
            this.glPrimitiveBoundingBox.Invoke(out minX, out minY, out minZ, out minW, out maxX, out maxY, out maxZ, out maxW);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendFuncSeparatei(out nint buf, out nint srcRGB, out nint dstRGB, out nint srcAlpha, out nint dstAlpha);
        private readonly OpenGLBlendFuncSeparatei glBlendFuncSeparatei;
        
        public void BlendFuncSeparatei(out nint buf, out nint srcRGB, out nint dstRGB, out nint srcAlpha, out nint dstAlpha) =>
            this.glBlendFuncSeparatei.Invoke(out buf, out srcRGB, out dstRGB, out srcAlpha, out dstAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendFunci(out nint buf, out nint src, out nint dst);
        private readonly OpenGLBlendFunci glBlendFunci;
        
        public void BlendFunci(out nint buf, out nint src, out nint dst) =>
            this.glBlendFunci.Invoke(out buf, out src, out dst);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendEquationSeparatei(out nint buf, out nint modeRGB, out nint modeAlpha);
        private readonly OpenGLBlendEquationSeparatei glBlendEquationSeparatei;
        
        public void BlendEquationSeparatei(out nint buf, out nint modeRGB, out nint modeAlpha) =>
            this.glBlendEquationSeparatei.Invoke(out buf, out modeRGB, out modeAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendEquationi(out nint buf, out nint mode);
        private readonly OpenGLBlendEquationi glBlendEquationi;
        
        public void BlendEquationi(out nint buf, out nint mode) =>
            this.glBlendEquationi.Invoke(out buf, out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyImageSubData(out nint srcName, out nint srcTarget, out nint srcLevel, out nint srcX, out nint srcY, out nint srcZ, out nint dstName, out nint dstTarget, out nint dstLevel, out nint dstX, out nint dstY, out nint dstZ, out nint srcWidth, out nint srcHeight, out nint srcDepth);
        private readonly OpenGLCopyImageSubData glCopyImageSubData;
        
        public void CopyImageSubData(out nint srcName, out nint srcTarget, out nint srcLevel, out nint srcX, out nint srcY, out nint srcZ, out nint dstName, out nint dstTarget, out nint dstLevel, out nint dstX, out nint dstY, out nint dstZ, out nint srcWidth, out nint srcHeight, out nint srcDepth) =>
            this.glCopyImageSubData.Invoke(out srcName, out srcTarget, out srcLevel, out srcX, out srcY, out srcZ, out dstName, out dstTarget, out dstLevel, out dstX, out dstY, out dstZ, out srcWidth, out srcHeight, out srcDepth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendBarrier();
        private readonly OpenGLBlendBarrier glBlendBarrier;
        
        public void BlendBarrier() =>
            this.glBlendBarrier.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexBindingDivisor(out nint bindingindex, out nint divisor);
        private readonly OpenGLVertexBindingDivisor glVertexBindingDivisor;
        
        public void VertexBindingDivisor(out nint bindingindex, out nint divisor) =>
            this.glVertexBindingDivisor.Invoke(out bindingindex, out divisor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribBinding(out nint attribindex, out nint bindingindex);
        private readonly OpenGLVertexAttribBinding glVertexAttribBinding;
        
        public void VertexAttribBinding(out nint attribindex, out nint bindingindex) =>
            this.glVertexAttribBinding.Invoke(out attribindex, out bindingindex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribIFormat(out nint attribindex, out nint size, out nint type, out nint relativeoffset);
        private readonly OpenGLVertexAttribIFormat glVertexAttribIFormat;
        
        public void VertexAttribIFormat(out nint attribindex, out nint size, out nint type, out nint relativeoffset) =>
            this.glVertexAttribIFormat.Invoke(out attribindex, out size, out type, out relativeoffset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribFormat(out nint attribindex, out nint size, out nint type, out nint normalized, out nint relativeoffset);
        private readonly OpenGLVertexAttribFormat glVertexAttribFormat;
        
        public void VertexAttribFormat(out nint attribindex, out nint size, out nint type, out nint normalized, out nint relativeoffset) =>
            this.glVertexAttribFormat.Invoke(out attribindex, out size, out type, out normalized, out relativeoffset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindVertexBuffer(out nint bindingindex, out nint buffer, out nint offset, out nint stride);
        private readonly OpenGLBindVertexBuffer glBindVertexBuffer;
        
        public void BindVertexBuffer(out nint bindingindex, out nint buffer, out nint offset, out nint stride) =>
            this.glBindVertexBuffer.Invoke(out bindingindex, out buffer, out offset, out stride);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexStorage2DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint fixedsamplelocations);
        private readonly OpenGLTexStorage2DMultisample glTexStorage2DMultisample;
        
        public void TexStorage2DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint fixedsamplelocations) =>
            this.glTexStorage2DMultisample.Invoke(out target, out samples, out internalformat, out width, out height, out fixedsamplelocations);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMemoryBarrierByRegion(out nint barriers);
        private readonly OpenGLMemoryBarrierByRegion glMemoryBarrierByRegion;
        
        public void MemoryBarrierByRegion(out nint barriers) =>
            this.glMemoryBarrierByRegion.Invoke(out barriers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMemoryBarrier(out nint barriers);
        private readonly OpenGLMemoryBarrier glMemoryBarrier;
        
        public void MemoryBarrier(out nint barriers) =>
            this.glMemoryBarrier.Invoke(out barriers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindImageTexture(out nint unit, out nint texture, out nint level, out nint layered, out nint layer, out nint access, out nint format);
        private readonly OpenGLBindImageTexture glBindImageTexture;
        
        public void BindImageTexture(out nint unit, out nint texture, out nint level, out nint layered, out nint layer, out nint access, out nint format) =>
            this.glBindImageTexture.Invoke(out unit, out texture, out level, out layered, out layer, out access, out format);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramPipelineInfoLog(out nint pipeline, out nint bufSize, out nint length, out nint infoLog);
        private readonly OpenGLGetProgramPipelineInfoLog glGetProgramPipelineInfoLog;
        
        public void GetProgramPipelineInfoLog(out nint pipeline, out nint bufSize, out nint length, out nint infoLog) =>
            this.glGetProgramPipelineInfoLog.Invoke(out pipeline, out bufSize, out length, out infoLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLValidateProgramPipeline(out nint pipeline);
        private readonly OpenGLValidateProgramPipeline glValidateProgramPipeline;
        
        public void ValidateProgramPipeline(out nint pipeline) =>
            this.glValidateProgramPipeline.Invoke(out pipeline);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix4x3fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix4x3fv glProgramUniformMatrix4x3fv;
        
        public void ProgramUniformMatrix4x3fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix4x3fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix3x4fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix3x4fv glProgramUniformMatrix3x4fv;
        
        public void ProgramUniformMatrix3x4fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix3x4fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix4x2fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix4x2fv glProgramUniformMatrix4x2fv;
        
        public void ProgramUniformMatrix4x2fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix4x2fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix2x4fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix2x4fv glProgramUniformMatrix2x4fv;
        
        public void ProgramUniformMatrix2x4fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix2x4fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix3x2fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix3x2fv glProgramUniformMatrix3x2fv;
        
        public void ProgramUniformMatrix3x2fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix3x2fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix2x3fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix2x3fv glProgramUniformMatrix2x3fv;
        
        public void ProgramUniformMatrix2x3fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix2x3fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix4fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix4fv glProgramUniformMatrix4fv;
        
        public void ProgramUniformMatrix4fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix4fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix3fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix3fv glProgramUniformMatrix3fv;
        
        public void ProgramUniformMatrix3fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix3fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendBarrierKHR();
        private readonly OpenGLBlendBarrierKHR glBlendBarrierKHR;
        
        [OpenGLExtension("GL_KHR_blend_equation_advanced")]
        public void BlendBarrierKHR() =>
            this.glBlendBarrierKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageControl(out nint source, out nint type, out nint severity, out nint count, nint ids, out nint enabled);
        private readonly OpenGLDebugMessageControl glDebugMessageControl;
        
        public void DebugMessageControl(out nint source, out nint type, out nint severity, out nint count, nint ids, out nint enabled) =>
            this.glDebugMessageControl.Invoke(out source, out type, out severity, out count, ids, out enabled);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageInsert(out nint source, out nint type, out nint id, out nint severity, out nint length, nint buf);
        private readonly OpenGLDebugMessageInsert glDebugMessageInsert;
        
        public void DebugMessageInsert(out nint source, out nint type, out nint id, out nint severity, out nint length, nint buf) =>
            this.glDebugMessageInsert.Invoke(out source, out type, out id, out severity, out length, buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageCallback(out nint callback, nint userParam);
        private readonly OpenGLDebugMessageCallback glDebugMessageCallback;
        
        public void DebugMessageCallback(out nint callback, nint userParam) =>
            this.glDebugMessageCallback.Invoke(out callback, userParam);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLGetDebugMessageLog(out nint count, out nint bufSize, out nint sources, out nint types, out nint ids, out nint severities, out nint lengths, out nint messageLog);
        private readonly OpenGLGetDebugMessageLog glGetDebugMessageLog;
        
        public uint GetDebugMessageLog(out nint count, out nint bufSize, out nint sources, out nint types, out nint ids, out nint severities, out nint lengths, out nint messageLog) =>
            this.glGetDebugMessageLog.Invoke(out count, out bufSize, out sources, out types, out ids, out severities, out lengths, out messageLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPushDebugGroup(out nint source, out nint id, out nint length, nint message);
        private readonly OpenGLPushDebugGroup glPushDebugGroup;
        
        public void PushDebugGroup(out nint source, out nint id, out nint length, nint message) =>
            this.glPushDebugGroup.Invoke(out source, out id, out length, message);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPopDebugGroup();
        private readonly OpenGLPopDebugGroup glPopDebugGroup;
        
        public void PopDebugGroup() =>
            this.glPopDebugGroup.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLObjectLabel(out nint identifier, out nint name, out nint length, nint label);
        private readonly OpenGLObjectLabel glObjectLabel;
        
        public void ObjectLabel(out nint identifier, out nint name, out nint length, nint label) =>
            this.glObjectLabel.Invoke(out identifier, out name, out length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetObjectLabel(out nint identifier, out nint name, out nint bufSize, out nint length, out nint label);
        private readonly OpenGLGetObjectLabel glGetObjectLabel;
        
        public void GetObjectLabel(out nint identifier, out nint name, out nint bufSize, out nint length, out nint label) =>
            this.glGetObjectLabel.Invoke(out identifier, out name, out bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLObjectPtrLabel(nint ptr, out nint length, nint label);
        private readonly OpenGLObjectPtrLabel glObjectPtrLabel;
        
        public void ObjectPtrLabel(nint ptr, out nint length, nint label) =>
            this.glObjectPtrLabel.Invoke(ptr, out length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetObjectPtrLabel(nint ptr, out nint bufSize, out nint length, out nint label);
        private readonly OpenGLGetObjectPtrLabel glGetObjectPtrLabel;
        
        public void GetObjectPtrLabel(nint ptr, out nint bufSize, out nint length, out nint label) =>
            this.glGetObjectPtrLabel.Invoke(ptr, out bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3uiv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform3uiv glProgramUniform3uiv;
        
        public void ProgramUniform3uiv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform3uiv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageControlKHR(out nint source, out nint type, out nint severity, out nint count, nint ids, out nint enabled);
        private readonly OpenGLDebugMessageControlKHR glDebugMessageControlKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void DebugMessageControlKHR(out nint source, out nint type, out nint severity, out nint count, nint ids, out nint enabled) =>
            this.glDebugMessageControlKHR.Invoke(out source, out type, out severity, out count, ids, out enabled);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageInsertKHR(out nint source, out nint type, out nint id, out nint severity, out nint length, nint buf);
        private readonly OpenGLDebugMessageInsertKHR glDebugMessageInsertKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void DebugMessageInsertKHR(out nint source, out nint type, out nint id, out nint severity, out nint length, nint buf) =>
            this.glDebugMessageInsertKHR.Invoke(out source, out type, out id, out severity, out length, buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDebugMessageCallbackKHR(out nint callback, nint userParam);
        private readonly OpenGLDebugMessageCallbackKHR glDebugMessageCallbackKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void DebugMessageCallbackKHR(out nint callback, nint userParam) =>
            this.glDebugMessageCallbackKHR.Invoke(out callback, userParam);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLGetDebugMessageLogKHR(out nint count, out nint bufSize, out nint sources, out nint types, out nint ids, out nint severities, out nint lengths, out nint messageLog);
        private readonly OpenGLGetDebugMessageLogKHR glGetDebugMessageLogKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public uint GetDebugMessageLogKHR(out nint count, out nint bufSize, out nint sources, out nint types, out nint ids, out nint severities, out nint lengths, out nint messageLog) =>
            this.glGetDebugMessageLogKHR.Invoke(out count, out bufSize, out sources, out types, out ids, out severities, out lengths, out messageLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPushDebugGroupKHR(out nint source, out nint id, out nint length, nint message);
        private readonly OpenGLPushDebugGroupKHR glPushDebugGroupKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void PushDebugGroupKHR(out nint source, out nint id, out nint length, nint message) =>
            this.glPushDebugGroupKHR.Invoke(out source, out id, out length, message);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPopDebugGroupKHR();
        private readonly OpenGLPopDebugGroupKHR glPopDebugGroupKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void PopDebugGroupKHR() =>
            this.glPopDebugGroupKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLObjectLabelKHR(out nint identifier, out nint name, out nint length, nint label);
        private readonly OpenGLObjectLabelKHR glObjectLabelKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void ObjectLabelKHR(out nint identifier, out nint name, out nint length, nint label) =>
            this.glObjectLabelKHR.Invoke(out identifier, out name, out length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetObjectLabelKHR(out nint identifier, out nint name, out nint bufSize, out nint length, out nint label);
        private readonly OpenGLGetObjectLabelKHR glGetObjectLabelKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void GetObjectLabelKHR(out nint identifier, out nint name, out nint bufSize, out nint length, out nint label) =>
            this.glGetObjectLabelKHR.Invoke(out identifier, out name, out bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLObjectPtrLabelKHR(nint ptr, out nint length, nint label);
        private readonly OpenGLObjectPtrLabelKHR glObjectPtrLabelKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void ObjectPtrLabelKHR(nint ptr, out nint length, nint label) =>
            this.glObjectPtrLabelKHR.Invoke(ptr, out length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetObjectPtrLabelKHR(nint ptr, out nint bufSize, out nint length, out nint label);
        private readonly OpenGLGetObjectPtrLabelKHR glGetObjectPtrLabelKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void GetObjectPtrLabelKHR(nint ptr, out nint bufSize, out nint length, out nint label) =>
            this.glGetObjectPtrLabelKHR.Invoke(ptr, out bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetPointervKHR(out nint pname, out nint @params);
        private readonly OpenGLGetPointervKHR glGetPointervKHR;
        
        [OpenGLExtension("GL_KHR_debug")]
        public void GetPointervKHR(out nint pname, out nint @params) =>
            this.glGetPointervKHR.Invoke(out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus OpenGLGetGraphicsResetStatus();
        private readonly OpenGLGetGraphicsResetStatus glGetGraphicsResetStatus;
        
        public GraphicsResetStatus GetGraphicsResetStatus() =>
            this.glGetGraphicsResetStatus.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLReadnPixels(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint bufSize, out nint data);
        private readonly OpenGLReadnPixels glReadnPixels;
        
        public void ReadnPixels(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint bufSize, out nint data) =>
            this.glReadnPixels.Invoke(out x, out y, out width, out height, out format, out type, out bufSize, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformfv(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformfv glGetnUniformfv;
        
        public void GetnUniformfv(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformfv.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformiv(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformiv glGetnUniformiv;
        
        public void GetnUniformiv(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformiv.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformuiv(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformuiv glGetnUniformuiv;
        
        public void GetnUniformuiv(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformuiv.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus OpenGLGetGraphicsResetStatusKHR();
        private readonly OpenGLGetGraphicsResetStatusKHR glGetGraphicsResetStatusKHR;
        
        [OpenGLExtension("GL_KHR_robustness")]
        public GraphicsResetStatus GetGraphicsResetStatusKHR() =>
            this.glGetGraphicsResetStatusKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLReadnPixelsKHR(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint bufSize, out nint data);
        private readonly OpenGLReadnPixelsKHR glReadnPixelsKHR;
        
        [OpenGLExtension("GL_KHR_robustness")]
        public void ReadnPixelsKHR(out nint x, out nint y, out nint width, out nint height, out nint format, out nint type, out nint bufSize, out nint data) =>
            this.glReadnPixelsKHR.Invoke(out x, out y, out width, out height, out format, out type, out bufSize, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformfvKHR(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformfvKHR glGetnUniformfvKHR;
        
        [OpenGLExtension("GL_KHR_robustness")]
        public void GetnUniformfvKHR(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformfvKHR.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformivKHR(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformivKHR glGetnUniformivKHR;
        
        [OpenGLExtension("GL_KHR_robustness")]
        public void GetnUniformivKHR(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformivKHR.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetnUniformuivKHR(out nint program, out nint location, out nint bufSize, out nint @params);
        private readonly OpenGLGetnUniformuivKHR glGetnUniformuivKHR;
        
        [OpenGLExtension("GL_KHR_robustness")]
        public void GetnUniformuivKHR(out nint program, out nint location, out nint bufSize, out nint @params) =>
            this.glGetnUniformuivKHR.Invoke(out program, out location, out bufSize, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMaxShaderCompilerThreadsKHR(out nint count);
        private readonly OpenGLMaxShaderCompilerThreadsKHR glMaxShaderCompilerThreadsKHR;
        
        [OpenGLExtension("GL_KHR_parallel_shader_compile")]
        public void MaxShaderCompilerThreadsKHR(out nint count) =>
            this.glMaxShaderCompilerThreadsKHR.Invoke(out count);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTextureMultiviewOVR(out nint target, out nint attachment, out nint texture, out nint level, out nint baseViewIndex, out nint numViews);
        private readonly OpenGLFramebufferTextureMultiviewOVR glFramebufferTextureMultiviewOVR;
        
        [OpenGLExtension("GL_OVR_multiview")]
        public void FramebufferTextureMultiviewOVR(out nint target, out nint attachment, out nint texture, out nint level, out nint baseViewIndex, out nint numViews) =>
            this.glFramebufferTextureMultiviewOVR.Invoke(out target, out attachment, out texture, out level, out baseViewIndex, out numViews);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTextureMultisampleMultiviewOVR(out nint target, out nint attachment, out nint texture, out nint level, out nint samples, out nint baseViewIndex, out nint numViews);
        private readonly OpenGLFramebufferTextureMultisampleMultiviewOVR glFramebufferTextureMultisampleMultiviewOVR;
        
        [OpenGLExtension("GL_OVR_multiview_multisampled_render_to_texture")]
        public void FramebufferTextureMultisampleMultiviewOVR(out nint target, out nint attachment, out nint texture, out nint level, out nint samples, out nint baseViewIndex, out nint numViews) =>
            this.glFramebufferTextureMultisampleMultiviewOVR.Invoke(out target, out attachment, out texture, out level, out samples, out baseViewIndex, out numViews);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawArrays(out nint mode, out nint first, out nint count);
        private readonly OpenGLDrawArrays glDrawArrays;
        
        public void DrawArrays(out nint mode, out nint first, out nint count) =>
            this.glDrawArrays.Invoke(out mode, out first, out count);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawElements(out nint mode, out nint count, out nint type, nint indices);
        private readonly OpenGLDrawElements glDrawElements;
        
        public void DrawElements(out nint mode, out nint count, out nint type, nint indices) =>
            this.glDrawElements.Invoke(out mode, out count, out type, indices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPolygonOffset(out nint factor, out nint units);
        private readonly OpenGLPolygonOffset glPolygonOffset;
        
        public void PolygonOffset(out nint factor, out nint units) =>
            this.glPolygonOffset.Invoke(out factor, out units);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyTexImage1D(out nint target, out nint level, out nint internalformat, out nint x, out nint y, out nint width, out nint border);
        private readonly OpenGLCopyTexImage1D glCopyTexImage1D;
        
        public void CopyTexImage1D(out nint target, out nint level, out nint internalformat, out nint x, out nint y, out nint width, out nint border) =>
            this.glCopyTexImage1D.Invoke(out target, out level, out internalformat, out x, out y, out width, out border);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyTexImage2D(out nint target, out nint level, out nint internalformat, out nint x, out nint y, out nint width, out nint height, out nint border);
        private readonly OpenGLCopyTexImage2D glCopyTexImage2D;
        
        public void CopyTexImage2D(out nint target, out nint level, out nint internalformat, out nint x, out nint y, out nint width, out nint height, out nint border) =>
            this.glCopyTexImage2D.Invoke(out target, out level, out internalformat, out x, out y, out width, out height, out border);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyTexSubImage1D(out nint target, out nint level, out nint xoffset, out nint x, out nint y, out nint width);
        private readonly OpenGLCopyTexSubImage1D glCopyTexSubImage1D;
        
        public void CopyTexSubImage1D(out nint target, out nint level, out nint xoffset, out nint x, out nint y, out nint width) =>
            this.glCopyTexSubImage1D.Invoke(out target, out level, out xoffset, out x, out y, out width);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyTexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint x, out nint y, out nint width, out nint height);
        private readonly OpenGLCopyTexSubImage2D glCopyTexSubImage2D;
        
        public void CopyTexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint x, out nint y, out nint width, out nint height) =>
            this.glCopyTexSubImage2D.Invoke(out target, out level, out xoffset, out yoffset, out x, out y, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexSubImage1D(out nint target, out nint level, out nint xoffset, out nint width, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexSubImage1D glTexSubImage1D;
        
        public void TexSubImage1D(out nint target, out nint level, out nint xoffset, out nint width, out nint format, out nint type, nint pixels) =>
            this.glTexSubImage1D.Invoke(out target, out level, out xoffset, out width, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint width, out nint height, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexSubImage2D glTexSubImage2D;
        
        public void TexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint width, out nint height, out nint format, out nint type, nint pixels) =>
            this.glTexSubImage2D.Invoke(out target, out level, out xoffset, out yoffset, out width, out height, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindTexture(out nint target, out nint texture);
        private readonly OpenGLBindTexture glBindTexture;
        
        public void BindTexture(out nint target, out nint texture) =>
            this.glBindTexture.Invoke(out target, out texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteTextures(out nint n, nint textures);
        private readonly OpenGLDeleteTextures glDeleteTextures;
        
        public void DeleteTextures(out nint n, nint textures) =>
            this.glDeleteTextures.Invoke(out n, textures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenTextures(out nint n, out nint textures);
        private readonly OpenGLGenTextures glGenTextures;
        
        public void GenTextures(out nint n, out nint textures) =>
            this.glGenTextures.Invoke(out n, out textures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsTexture(out nint texture);
        private readonly OpenGLIsTexture glIsTexture;
        
        public bool IsTexture(out nint texture) =>
            this.glIsTexture.Invoke(out texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniformMatrix2fv(out nint program, out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLProgramUniformMatrix2fv glProgramUniformMatrix2fv;
        
        public void ProgramUniformMatrix2fv(out nint program, out nint location, out nint count, out nint transpose, nint value) =>
            this.glProgramUniformMatrix2fv.Invoke(out program, out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4fv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform4fv glProgramUniform4fv;
        
        public void ProgramUniform4fv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform4fv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3fv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform3fv glProgramUniform3fv;
        
        public void ProgramUniform3fv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform3fv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2fv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform2fv glProgramUniform2fv;
        
        public void ProgramUniform2fv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform2fv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1fv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform1fv glProgramUniform1fv;
        
        public void ProgramUniform1fv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform1fv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4uiv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform4uiv glProgramUniform4uiv;
        
        public void ProgramUniform4uiv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform4uiv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2uiv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform2uiv glProgramUniform2uiv;
        
        public void ProgramUniform2uiv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform2uiv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1uiv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform1uiv glProgramUniform1uiv;
        
        public void ProgramUniform1uiv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform1uiv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4iv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform4iv glProgramUniform4iv;
        
        public void ProgramUniform4iv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform4iv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3iv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform3iv glProgramUniform3iv;
        
        public void ProgramUniform3iv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform3iv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2iv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform2iv glProgramUniform2iv;
        
        public void ProgramUniform2iv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform2iv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1iv(out nint program, out nint location, out nint count, nint value);
        private readonly OpenGLProgramUniform1iv glProgramUniform1iv;
        
        public void ProgramUniform1iv(out nint program, out nint location, out nint count, nint value) =>
            this.glProgramUniform1iv.Invoke(out program, out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4f(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLProgramUniform4f glProgramUniform4f;
        
        public void ProgramUniform4f(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glProgramUniform4f.Invoke(out program, out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3f(out nint program, out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLProgramUniform3f glProgramUniform3f;
        
        public void ProgramUniform3f(out nint program, out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glProgramUniform3f.Invoke(out program, out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2f(out nint program, out nint location, out nint v0, out nint v1);
        private readonly OpenGLProgramUniform2f glProgramUniform2f;
        
        public void ProgramUniform2f(out nint program, out nint location, out nint v0, out nint v1) =>
            this.glProgramUniform2f.Invoke(out program, out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1f(out nint program, out nint location, out nint v0);
        private readonly OpenGLProgramUniform1f glProgramUniform1f;
        
        public void ProgramUniform1f(out nint program, out nint location, out nint v0) =>
            this.glProgramUniform1f.Invoke(out program, out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawRangeElements(out nint mode, out nint start, out nint end, out nint count, out nint type, nint indices);
        private readonly OpenGLDrawRangeElements glDrawRangeElements;
        
        public void DrawRangeElements(out nint mode, out nint start, out nint end, out nint count, out nint type, nint indices) =>
            this.glDrawRangeElements.Invoke(out mode, out start, out end, out count, out type, indices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexImage3D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint depth, out nint border, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexImage3D glTexImage3D;
        
        public void TexImage3D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint depth, out nint border, out nint format, out nint type, nint pixels) =>
            this.glTexImage3D.Invoke(out target, out level, out internalformat, out width, out height, out depth, out border, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint width, out nint height, out nint depth, out nint format, out nint type, nint pixels);
        private readonly OpenGLTexSubImage3D glTexSubImage3D;
        
        public void TexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint width, out nint height, out nint depth, out nint format, out nint type, nint pixels) =>
            this.glTexSubImage3D.Invoke(out target, out level, out xoffset, out yoffset, out zoffset, out width, out height, out depth, out format, out type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyTexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint x, out nint y, out nint width, out nint height);
        private readonly OpenGLCopyTexSubImage3D glCopyTexSubImage3D;
        
        public void CopyTexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint x, out nint y, out nint width, out nint height) =>
            this.glCopyTexSubImage3D.Invoke(out target, out level, out xoffset, out yoffset, out zoffset, out x, out y, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLActiveTexture(out nint texture);
        private readonly OpenGLActiveTexture glActiveTexture;
        
        public void ActiveTexture(out nint texture) =>
            this.glActiveTexture.Invoke(out texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSampleCoverage(out nint value, out nint invert);
        private readonly OpenGLSampleCoverage glSampleCoverage;
        
        public void SampleCoverage(out nint value, out nint invert) =>
            this.glSampleCoverage.Invoke(out value, out invert);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexImage3D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint depth, out nint border, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexImage3D glCompressedTexImage3D;
        
        public void CompressedTexImage3D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint depth, out nint border, out nint imageSize, nint data) =>
            this.glCompressedTexImage3D.Invoke(out target, out level, out internalformat, out width, out height, out depth, out border, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexImage2D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint border, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexImage2D glCompressedTexImage2D;
        
        public void CompressedTexImage2D(out nint target, out nint level, out nint internalformat, out nint width, out nint height, out nint border, out nint imageSize, nint data) =>
            this.glCompressedTexImage2D.Invoke(out target, out level, out internalformat, out width, out height, out border, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexImage1D(out nint target, out nint level, out nint internalformat, out nint width, out nint border, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexImage1D glCompressedTexImage1D;
        
        public void CompressedTexImage1D(out nint target, out nint level, out nint internalformat, out nint width, out nint border, out nint imageSize, nint data) =>
            this.glCompressedTexImage1D.Invoke(out target, out level, out internalformat, out width, out border, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint width, out nint height, out nint depth, out nint format, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexSubImage3D glCompressedTexSubImage3D;
        
        public void CompressedTexSubImage3D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint zoffset, out nint width, out nint height, out nint depth, out nint format, out nint imageSize, nint data) =>
            this.glCompressedTexSubImage3D.Invoke(out target, out level, out xoffset, out yoffset, out zoffset, out width, out height, out depth, out format, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint width, out nint height, out nint format, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexSubImage2D glCompressedTexSubImage2D;
        
        public void CompressedTexSubImage2D(out nint target, out nint level, out nint xoffset, out nint yoffset, out nint width, out nint height, out nint format, out nint imageSize, nint data) =>
            this.glCompressedTexSubImage2D.Invoke(out target, out level, out xoffset, out yoffset, out width, out height, out format, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompressedTexSubImage1D(out nint target, out nint level, out nint xoffset, out nint width, out nint format, out nint imageSize, nint data);
        private readonly OpenGLCompressedTexSubImage1D glCompressedTexSubImage1D;
        
        public void CompressedTexSubImage1D(out nint target, out nint level, out nint xoffset, out nint width, out nint format, out nint imageSize, nint data) =>
            this.glCompressedTexSubImage1D.Invoke(out target, out level, out xoffset, out width, out format, out imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetCompressedTexImage(out nint target, out nint level, out nint img);
        private readonly OpenGLGetCompressedTexImage glGetCompressedTexImage;
        
        public void GetCompressedTexImage(out nint target, out nint level, out nint img) =>
            this.glGetCompressedTexImage.Invoke(out target, out level, out img);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4ui(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLProgramUniform4ui glProgramUniform4ui;
        
        public void ProgramUniform4ui(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glProgramUniform4ui.Invoke(out program, out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3ui(out nint program, out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLProgramUniform3ui glProgramUniform3ui;
        
        public void ProgramUniform3ui(out nint program, out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glProgramUniform3ui.Invoke(out program, out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2ui(out nint program, out nint location, out nint v0, out nint v1);
        private readonly OpenGLProgramUniform2ui glProgramUniform2ui;
        
        public void ProgramUniform2ui(out nint program, out nint location, out nint v0, out nint v1) =>
            this.glProgramUniform2ui.Invoke(out program, out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1ui(out nint program, out nint location, out nint v0);
        private readonly OpenGLProgramUniform1ui glProgramUniform1ui;
        
        public void ProgramUniform1ui(out nint program, out nint location, out nint v0) =>
            this.glProgramUniform1ui.Invoke(out program, out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform4i(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLProgramUniform4i glProgramUniform4i;
        
        public void ProgramUniform4i(out nint program, out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glProgramUniform4i.Invoke(out program, out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform3i(out nint program, out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLProgramUniform3i glProgramUniform3i;
        
        public void ProgramUniform3i(out nint program, out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glProgramUniform3i.Invoke(out program, out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform2i(out nint program, out nint location, out nint v0, out nint v1);
        private readonly OpenGLProgramUniform2i glProgramUniform2i;
        
        public void ProgramUniform2i(out nint program, out nint location, out nint v0, out nint v1) =>
            this.glProgramUniform2i.Invoke(out program, out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramUniform1i(out nint program, out nint location, out nint v0);
        private readonly OpenGLProgramUniform1i glProgramUniform1i;
        
        public void ProgramUniform1i(out nint program, out nint location, out nint v0) =>
            this.glProgramUniform1i.Invoke(out program, out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramPipelineiv(out nint pipeline, out nint pname, out nint @params);
        private readonly OpenGLGetProgramPipelineiv glGetProgramPipelineiv;
        
        public void GetProgramPipelineiv(out nint pipeline, out nint pname, out nint @params) =>
            this.glGetProgramPipelineiv.Invoke(out pipeline, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsProgramPipeline(out nint pipeline);
        private readonly OpenGLIsProgramPipeline glIsProgramPipeline;
        
        public bool IsProgramPipeline(out nint pipeline) =>
            this.glIsProgramPipeline.Invoke(out pipeline);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenProgramPipelines(out nint n, out nint pipelines);
        private readonly OpenGLGenProgramPipelines glGenProgramPipelines;
        
        public void GenProgramPipelines(out nint n, out nint pipelines) =>
            this.glGenProgramPipelines.Invoke(out n, out pipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteProgramPipelines(out nint n, nint pipelines);
        private readonly OpenGLDeleteProgramPipelines glDeleteProgramPipelines;
        
        public void DeleteProgramPipelines(out nint n, nint pipelines) =>
            this.glDeleteProgramPipelines.Invoke(out n, pipelines);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindProgramPipeline(out nint pipeline);
        private readonly OpenGLBindProgramPipeline glBindProgramPipeline;
        
        public void BindProgramPipeline(out nint pipeline) =>
            this.glBindProgramPipeline.Invoke(out pipeline);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLCreateShaderProgramv(out nint type, out nint count, nint strings);
        private readonly OpenGLCreateShaderProgramv glCreateShaderProgramv;
        
        public uint CreateShaderProgramv(out nint type, out nint count, nint strings) =>
            this.glCreateShaderProgramv.Invoke(out type, out count, strings);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLActiveShaderProgram(out nint pipeline, out nint program);
        private readonly OpenGLActiveShaderProgram glActiveShaderProgram;
        
        public void ActiveShaderProgram(out nint pipeline, out nint program) =>
            this.glActiveShaderProgram.Invoke(out pipeline, out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUseProgramStages(out nint pipeline, out nint stages, out nint program);
        private readonly OpenGLUseProgramStages glUseProgramStages;
        
        public void UseProgramStages(out nint pipeline, out nint stages, out nint program) =>
            this.glUseProgramStages.Invoke(out pipeline, out stages, out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int OpenGLGetProgramResourceLocation(out nint program, out nint programInterface, nint name);
        private readonly OpenGLGetProgramResourceLocation glGetProgramResourceLocation;
        
        public int GetProgramResourceLocation(out nint program, out nint programInterface, nint name) =>
            this.glGetProgramResourceLocation.Invoke(out program, out programInterface, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramResourceiv(out nint program, out nint programInterface, out nint index, out nint propCount, nint props, out nint count, out nint length, out nint @params);
        private readonly OpenGLGetProgramResourceiv glGetProgramResourceiv;
        
        public void GetProgramResourceiv(out nint program, out nint programInterface, out nint index, out nint propCount, nint props, out nint count, out nint length, out nint @params) =>
            this.glGetProgramResourceiv.Invoke(out program, out programInterface, out index, out propCount, props, out count, out length, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramResourceName(out nint program, out nint programInterface, out nint index, out nint bufSize, out nint length, out nint name);
        private readonly OpenGLGetProgramResourceName glGetProgramResourceName;
        
        public void GetProgramResourceName(out nint program, out nint programInterface, out nint index, out nint bufSize, out nint length, out nint name) =>
            this.glGetProgramResourceName.Invoke(out program, out programInterface, out index, out bufSize, out length, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLGetProgramResourceIndex(out nint program, out nint programInterface, nint name);
        private readonly OpenGLGetProgramResourceIndex glGetProgramResourceIndex;
        
        public uint GetProgramResourceIndex(out nint program, out nint programInterface, nint name) =>
            this.glGetProgramResourceIndex.Invoke(out program, out programInterface, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramInterfaceiv(out nint program, out nint programInterface, out nint pname, out nint @params);
        private readonly OpenGLGetProgramInterfaceiv glGetProgramInterfaceiv;
        
        public void GetProgramInterfaceiv(out nint program, out nint programInterface, out nint pname, out nint @params) =>
            this.glGetProgramInterfaceiv.Invoke(out program, out programInterface, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetFramebufferParameteriv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetFramebufferParameteriv glGetFramebufferParameteriv;
        
        public void GetFramebufferParameteriv(out nint target, out nint pname, out nint @params) =>
            this.glGetFramebufferParameteriv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferParameteri(out nint target, out nint pname, out nint param);
        private readonly OpenGLFramebufferParameteri glFramebufferParameteri;
        
        public void FramebufferParameteri(out nint target, out nint pname, out nint param) =>
            this.glFramebufferParameteri.Invoke(out target, out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawElementsIndirect(out nint mode, out nint type, nint indirect);
        private readonly OpenGLDrawElementsIndirect glDrawElementsIndirect;
        
        public void DrawElementsIndirect(out nint mode, out nint type, nint indirect) =>
            this.glDrawElementsIndirect.Invoke(out mode, out type, indirect);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawArraysIndirect(out nint mode, nint indirect);
        private readonly OpenGLDrawArraysIndirect glDrawArraysIndirect;
        
        public void DrawArraysIndirect(out nint mode, nint indirect) =>
            this.glDrawArraysIndirect.Invoke(out mode, indirect);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDispatchComputeIndirect(out nint indirect);
        private readonly OpenGLDispatchComputeIndirect glDispatchComputeIndirect;
        
        public void DispatchComputeIndirect(out nint indirect) =>
            this.glDispatchComputeIndirect.Invoke(out indirect);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDispatchCompute(out nint num_groups_x, out nint num_groups_y, out nint num_groups_z);
        private readonly OpenGLDispatchCompute glDispatchCompute;
        
        public void DispatchCompute(out nint num_groups_x, out nint num_groups_y, out nint num_groups_z) =>
            this.glDispatchCompute.Invoke(out num_groups_x, out num_groups_y, out num_groups_z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetInternalformativ(out nint target, out nint internalformat, out nint pname, out nint count, out nint @params);
        private readonly OpenGLGetInternalformativ glGetInternalformativ;
        
        public void GetInternalformativ(out nint target, out nint internalformat, out nint pname, out nint count, out nint @params) =>
            this.glGetInternalformativ.Invoke(out target, out internalformat, out pname, out count, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexStorage3D(out nint target, out nint levels, out nint internalformat, out nint width, out nint height, out nint depth);
        private readonly OpenGLTexStorage3D glTexStorage3D;
        
        public void TexStorage3D(out nint target, out nint levels, out nint internalformat, out nint width, out nint height, out nint depth) =>
            this.glTexStorage3D.Invoke(out target, out levels, out internalformat, out width, out height, out depth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexStorage2D(out nint target, out nint levels, out nint internalformat, out nint width, out nint height);
        private readonly OpenGLTexStorage2D glTexStorage2D;
        
        public void TexStorage2D(out nint target, out nint levels, out nint internalformat, out nint width, out nint height) =>
            this.glTexStorage2D.Invoke(out target, out levels, out internalformat, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLInvalidateSubFramebuffer(out nint target, out nint numAttachments, nint attachments, out nint x, out nint y, out nint width, out nint height);
        private readonly OpenGLInvalidateSubFramebuffer glInvalidateSubFramebuffer;
        
        public void InvalidateSubFramebuffer(out nint target, out nint numAttachments, nint attachments, out nint x, out nint y, out nint width, out nint height) =>
            this.glInvalidateSubFramebuffer.Invoke(out target, out numAttachments, attachments, out x, out y, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLInvalidateFramebuffer(out nint target, out nint numAttachments, nint attachments);
        private readonly OpenGLInvalidateFramebuffer glInvalidateFramebuffer;
        
        public void InvalidateFramebuffer(out nint target, out nint numAttachments, nint attachments) =>
            this.glInvalidateFramebuffer.Invoke(out target, out numAttachments, attachments);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramParameteri(out nint program, out nint pname, out nint value);
        private readonly OpenGLProgramParameteri glProgramParameteri;
        
        public void ProgramParameteri(out nint program, out nint pname, out nint value) =>
            this.glProgramParameteri.Invoke(out program, out pname, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProgramBinary(out nint program, out nint binaryFormat, nint binary, out nint length);
        private readonly OpenGLProgramBinary glProgramBinary;
        
        public void ProgramBinary(out nint program, out nint binaryFormat, nint binary, out nint length) =>
            this.glProgramBinary.Invoke(out program, out binaryFormat, binary, out length);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramBinary(out nint program, out nint bufSize, out nint length, out nint binaryFormat, out nint binary);
        private readonly OpenGLGetProgramBinary glGetProgramBinary;
        
        public void GetProgramBinary(out nint program, out nint bufSize, out nint length, out nint binaryFormat, out nint binary) =>
            this.glGetProgramBinary.Invoke(out program, out bufSize, out length, out binaryFormat, out binary);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLResumeTransformFeedback();
        private readonly OpenGLResumeTransformFeedback glResumeTransformFeedback;
        
        public void ResumeTransformFeedback() =>
            this.glResumeTransformFeedback.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPauseTransformFeedback();
        private readonly OpenGLPauseTransformFeedback glPauseTransformFeedback;
        
        public void PauseTransformFeedback() =>
            this.glPauseTransformFeedback.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendFuncSeparate(out nint sfactorRGB, out nint dfactorRGB, out nint sfactorAlpha, out nint dfactorAlpha);
        private readonly OpenGLBlendFuncSeparate glBlendFuncSeparate;
        
        public void BlendFuncSeparate(out nint sfactorRGB, out nint dfactorRGB, out nint sfactorAlpha, out nint dfactorAlpha) =>
            this.glBlendFuncSeparate.Invoke(out sfactorRGB, out dfactorRGB, out sfactorAlpha, out dfactorAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMultiDrawArrays(out nint mode, nint first, nint count, out nint drawcount);
        private readonly OpenGLMultiDrawArrays glMultiDrawArrays;
        
        public void MultiDrawArrays(out nint mode, nint first, nint count, out nint drawcount) =>
            this.glMultiDrawArrays.Invoke(out mode, first, count, out drawcount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMultiDrawElements(out nint mode, nint count, out nint type, nint indices, out nint drawcount);
        private readonly OpenGLMultiDrawElements glMultiDrawElements;
        
        public void MultiDrawElements(out nint mode, nint count, out nint type, nint indices, out nint drawcount) =>
            this.glMultiDrawElements.Invoke(out mode, count, out type, indices, out drawcount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPointParameterf(out nint pname, out nint param);
        private readonly OpenGLPointParameterf glPointParameterf;
        
        public void PointParameterf(out nint pname, out nint param) =>
            this.glPointParameterf.Invoke(out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPointParameterfv(out nint pname, nint @params);
        private readonly OpenGLPointParameterfv glPointParameterfv;
        
        public void PointParameterfv(out nint pname, nint @params) =>
            this.glPointParameterfv.Invoke(out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPointParameteri(out nint pname, out nint param);
        private readonly OpenGLPointParameteri glPointParameteri;
        
        public void PointParameteri(out nint pname, out nint param) =>
            this.glPointParameteri.Invoke(out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPointParameteriv(out nint pname, nint @params);
        private readonly OpenGLPointParameteriv glPointParameteriv;
        
        public void PointParameteriv(out nint pname, nint @params) =>
            this.glPointParameteriv.Invoke(out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsTransformFeedback(out nint id);
        private readonly OpenGLIsTransformFeedback glIsTransformFeedback;
        
        public bool IsTransformFeedback(out nint id) =>
            this.glIsTransformFeedback.Invoke(out id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenTransformFeedbacks(out nint n, out nint ids);
        private readonly OpenGLGenTransformFeedbacks glGenTransformFeedbacks;
        
        public void GenTransformFeedbacks(out nint n, out nint ids) =>
            this.glGenTransformFeedbacks.Invoke(out n, out ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteTransformFeedbacks(out nint n, nint ids);
        private readonly OpenGLDeleteTransformFeedbacks glDeleteTransformFeedbacks;
        
        public void DeleteTransformFeedbacks(out nint n, nint ids) =>
            this.glDeleteTransformFeedbacks.Invoke(out n, ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindTransformFeedback(out nint target, out nint id);
        private readonly OpenGLBindTransformFeedback glBindTransformFeedback;
        
        public void BindTransformFeedback(out nint target, out nint id) =>
            this.glBindTransformFeedback.Invoke(out target, out id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLShaderBinary(out nint count, nint shaders, out nint binaryFormat, nint binary, out nint length);
        private readonly OpenGLShaderBinary glShaderBinary;
        
        public void ShaderBinary(out nint count, nint shaders, out nint binaryFormat, nint binary, out nint length) =>
            this.glShaderBinary.Invoke(out count, shaders, out binaryFormat, binary, out length);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLReleaseShaderCompiler();
        private readonly OpenGLReleaseShaderCompiler glReleaseShaderCompiler;
        
        public void ReleaseShaderCompiler() =>
            this.glReleaseShaderCompiler.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetShaderPrecisionFormat(out nint shadertype, out nint precisiontype, out nint range, out nint precision);
        private readonly OpenGLGetShaderPrecisionFormat glGetShaderPrecisionFormat;
        
        public void GetShaderPrecisionFormat(out nint shadertype, out nint precisiontype, out nint range, out nint precision) =>
            this.glGetShaderPrecisionFormat.Invoke(out shadertype, out precisiontype, out range, out precision);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDepthRangef(out nint n, out nint f);
        private readonly OpenGLDepthRangef glDepthRangef;
        
        public void DepthRangef(out nint n, out nint f) =>
            this.glDepthRangef.Invoke(out n, out f);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearDepthf(out nint d);
        private readonly OpenGLClearDepthf glClearDepthf;
        
        public void ClearDepthf(out nint d) =>
            this.glClearDepthf.Invoke(out d);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP4uiv(out nint index, out nint type, out nint normalized, nint value);
        private readonly OpenGLVertexAttribP4uiv glVertexAttribP4uiv;
        
        public void VertexAttribP4uiv(out nint index, out nint type, out nint normalized, nint value) =>
            this.glVertexAttribP4uiv.Invoke(out index, out type, out normalized, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP4ui(out nint index, out nint type, out nint normalized, out nint value);
        private readonly OpenGLVertexAttribP4ui glVertexAttribP4ui;
        
        public void VertexAttribP4ui(out nint index, out nint type, out nint normalized, out nint value) =>
            this.glVertexAttribP4ui.Invoke(out index, out type, out normalized, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP3uiv(out nint index, out nint type, out nint normalized, nint value);
        private readonly OpenGLVertexAttribP3uiv glVertexAttribP3uiv;
        
        public void VertexAttribP3uiv(out nint index, out nint type, out nint normalized, nint value) =>
            this.glVertexAttribP3uiv.Invoke(out index, out type, out normalized, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP3ui(out nint index, out nint type, out nint normalized, out nint value);
        private readonly OpenGLVertexAttribP3ui glVertexAttribP3ui;
        
        public void VertexAttribP3ui(out nint index, out nint type, out nint normalized, out nint value) =>
            this.glVertexAttribP3ui.Invoke(out index, out type, out normalized, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP2uiv(out nint index, out nint type, out nint normalized, nint value);
        private readonly OpenGLVertexAttribP2uiv glVertexAttribP2uiv;
        
        public void VertexAttribP2uiv(out nint index, out nint type, out nint normalized, nint value) =>
            this.glVertexAttribP2uiv.Invoke(out index, out type, out normalized, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP2ui(out nint index, out nint type, out nint normalized, out nint value);
        private readonly OpenGLVertexAttribP2ui glVertexAttribP2ui;
        
        public void VertexAttribP2ui(out nint index, out nint type, out nint normalized, out nint value) =>
            this.glVertexAttribP2ui.Invoke(out index, out type, out normalized, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP1uiv(out nint index, out nint type, out nint normalized, nint value);
        private readonly OpenGLVertexAttribP1uiv glVertexAttribP1uiv;
        
        public void VertexAttribP1uiv(out nint index, out nint type, out nint normalized, nint value) =>
            this.glVertexAttribP1uiv.Invoke(out index, out type, out normalized, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribP1ui(out nint index, out nint type, out nint normalized, out nint value);
        private readonly OpenGLVertexAttribP1ui glVertexAttribP1ui;
        
        public void VertexAttribP1ui(out nint index, out nint type, out nint normalized, out nint value) =>
            this.glVertexAttribP1ui.Invoke(out index, out type, out normalized, out value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribDivisor(out nint index, out nint divisor);
        private readonly OpenGLVertexAttribDivisor glVertexAttribDivisor;
        
        public void VertexAttribDivisor(out nint index, out nint divisor) =>
            this.glVertexAttribDivisor.Invoke(out index, out divisor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetQueryObjectui64v(out nint id, out nint pname, out nint @params);
        private readonly OpenGLGetQueryObjectui64v glGetQueryObjectui64v;
        
        public void GetQueryObjectui64v(out nint id, out nint pname, out nint @params) =>
            this.glGetQueryObjectui64v.Invoke(out id, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetQueryObjecti64v(out nint id, out nint pname, out nint @params);
        private readonly OpenGLGetQueryObjecti64v glGetQueryObjecti64v;
        
        public void GetQueryObjecti64v(out nint id, out nint pname, out nint @params) =>
            this.glGetQueryObjecti64v.Invoke(out id, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLQueryCounter(out nint id, out nint target);
        private readonly OpenGLQueryCounter glQueryCounter;
        
        public void QueryCounter(out nint id, out nint target) =>
            this.glQueryCounter.Invoke(out id, out target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetSamplerParameterIuiv(out nint sampler, out nint pname, out nint @params);
        private readonly OpenGLGetSamplerParameterIuiv glGetSamplerParameterIuiv;
        
        public void GetSamplerParameterIuiv(out nint sampler, out nint pname, out nint @params) =>
            this.glGetSamplerParameterIuiv.Invoke(out sampler, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetSamplerParameterfv(out nint sampler, out nint pname, out nint @params);
        private readonly OpenGLGetSamplerParameterfv glGetSamplerParameterfv;
        
        public void GetSamplerParameterfv(out nint sampler, out nint pname, out nint @params) =>
            this.glGetSamplerParameterfv.Invoke(out sampler, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetSamplerParameterIiv(out nint sampler, out nint pname, out nint @params);
        private readonly OpenGLGetSamplerParameterIiv glGetSamplerParameterIiv;
        
        public void GetSamplerParameterIiv(out nint sampler, out nint pname, out nint @params) =>
            this.glGetSamplerParameterIiv.Invoke(out sampler, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetSamplerParameteriv(out nint sampler, out nint pname, out nint @params);
        private readonly OpenGLGetSamplerParameteriv glGetSamplerParameteriv;
        
        public void GetSamplerParameteriv(out nint sampler, out nint pname, out nint @params) =>
            this.glGetSamplerParameteriv.Invoke(out sampler, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameterIuiv(out nint sampler, out nint pname, nint param);
        private readonly OpenGLSamplerParameterIuiv glSamplerParameterIuiv;
        
        public void SamplerParameterIuiv(out nint sampler, out nint pname, nint param) =>
            this.glSamplerParameterIuiv.Invoke(out sampler, out pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameterIiv(out nint sampler, out nint pname, nint param);
        private readonly OpenGLSamplerParameterIiv glSamplerParameterIiv;
        
        public void SamplerParameterIiv(out nint sampler, out nint pname, nint param) =>
            this.glSamplerParameterIiv.Invoke(out sampler, out pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameterfv(out nint sampler, out nint pname, nint param);
        private readonly OpenGLSamplerParameterfv glSamplerParameterfv;
        
        public void SamplerParameterfv(out nint sampler, out nint pname, nint param) =>
            this.glSamplerParameterfv.Invoke(out sampler, out pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameterf(out nint sampler, out nint pname, out nint param);
        private readonly OpenGLSamplerParameterf glSamplerParameterf;
        
        public void SamplerParameterf(out nint sampler, out nint pname, out nint param) =>
            this.glSamplerParameterf.Invoke(out sampler, out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameteriv(out nint sampler, out nint pname, nint param);
        private readonly OpenGLSamplerParameteriv glSamplerParameteriv;
        
        public void SamplerParameteriv(out nint sampler, out nint pname, nint param) =>
            this.glSamplerParameteriv.Invoke(out sampler, out pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSamplerParameteri(out nint sampler, out nint pname, out nint param);
        private readonly OpenGLSamplerParameteri glSamplerParameteri;
        
        public void SamplerParameteri(out nint sampler, out nint pname, out nint param) =>
            this.glSamplerParameteri.Invoke(out sampler, out pname, out param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindSampler(out nint unit, out nint sampler);
        private readonly OpenGLBindSampler glBindSampler;
        
        public void BindSampler(out nint unit, out nint sampler) =>
            this.glBindSampler.Invoke(out unit, out sampler);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsSampler(out nint sampler);
        private readonly OpenGLIsSampler glIsSampler;
        
        public bool IsSampler(out nint sampler) =>
            this.glIsSampler.Invoke(out sampler);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteSamplers(out nint count, nint samplers);
        private readonly OpenGLDeleteSamplers glDeleteSamplers;
        
        public void DeleteSamplers(out nint count, nint samplers) =>
            this.glDeleteSamplers.Invoke(out count, samplers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenSamplers(out nint count, out nint samplers);
        private readonly OpenGLGenSamplers glGenSamplers;
        
        public void GenSamplers(out nint count, out nint samplers) =>
            this.glGenSamplers.Invoke(out count, out samplers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int OpenGLGetFragDataIndex(out nint program, nint name);
        private readonly OpenGLGetFragDataIndex glGetFragDataIndex;
        
        public int GetFragDataIndex(out nint program, nint name) =>
            this.glGetFragDataIndex.Invoke(out program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindFragDataLocationIndexed(out nint program, out nint colorNumber, out nint index, nint name);
        private readonly OpenGLBindFragDataLocationIndexed glBindFragDataLocationIndexed;
        
        public void BindFragDataLocationIndexed(out nint program, out nint colorNumber, out nint index, nint name) =>
            this.glBindFragDataLocationIndexed.Invoke(out program, out colorNumber, out index, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetPointerv(out nint pname, out nint @params);
        private readonly OpenGLGetPointerv glGetPointerv;
        
        public void GetPointerv(out nint pname, out nint @params) =>
            this.glGetPointerv.Invoke(out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendColor(out nint red, out nint green, out nint blue, out nint alpha);
        private readonly OpenGLBlendColor glBlendColor;
        
        public void BlendColor(out nint red, out nint green, out nint blue, out nint alpha) =>
            this.glBlendColor.Invoke(out red, out green, out blue, out alpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendEquation(out nint mode);
        private readonly OpenGLBlendEquation glBlendEquation;
        
        public void BlendEquation(out nint mode) =>
            this.glBlendEquation.Invoke(out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenQueries(out nint n, out nint ids);
        private readonly OpenGLGenQueries glGenQueries;
        
        public void GenQueries(out nint n, out nint ids) =>
            this.glGenQueries.Invoke(out n, out ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteQueries(out nint n, nint ids);
        private readonly OpenGLDeleteQueries glDeleteQueries;
        
        public void DeleteQueries(out nint n, nint ids) =>
            this.glDeleteQueries.Invoke(out n, ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsQuery(out nint id);
        private readonly OpenGLIsQuery glIsQuery;
        
        public bool IsQuery(out nint id) =>
            this.glIsQuery.Invoke(out id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBeginQuery(out nint target, out nint id);
        private readonly OpenGLBeginQuery glBeginQuery;
        
        public void BeginQuery(out nint target, out nint id) =>
            this.glBeginQuery.Invoke(out target, out id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEndQuery(out nint target);
        private readonly OpenGLEndQuery glEndQuery;
        
        public void EndQuery(out nint target) =>
            this.glEndQuery.Invoke(out target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetQueryiv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetQueryiv glGetQueryiv;
        
        public void GetQueryiv(out nint target, out nint pname, out nint @params) =>
            this.glGetQueryiv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetQueryObjectiv(out nint id, out nint pname, out nint @params);
        private readonly OpenGLGetQueryObjectiv glGetQueryObjectiv;
        
        public void GetQueryObjectiv(out nint id, out nint pname, out nint @params) =>
            this.glGetQueryObjectiv.Invoke(out id, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetQueryObjectuiv(out nint id, out nint pname, out nint @params);
        private readonly OpenGLGetQueryObjectuiv glGetQueryObjectuiv;
        
        public void GetQueryObjectuiv(out nint id, out nint pname, out nint @params) =>
            this.glGetQueryObjectuiv.Invoke(out id, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindBuffer(out nint target, out nint buffer);
        private readonly OpenGLBindBuffer glBindBuffer;
        
        public void BindBuffer(out nint target, out nint buffer) =>
            this.glBindBuffer.Invoke(out target, out buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteBuffers(out nint n, nint buffers);
        private readonly OpenGLDeleteBuffers glDeleteBuffers;
        
        public void DeleteBuffers(out nint n, nint buffers) =>
            this.glDeleteBuffers.Invoke(out n, buffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenBuffers(out nint n, out nint buffers);
        private readonly OpenGLGenBuffers glGenBuffers;
        
        public void GenBuffers(out nint n, out nint buffers) =>
            this.glGenBuffers.Invoke(out n, out buffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsBuffer(out nint buffer);
        private readonly OpenGLIsBuffer glIsBuffer;
        
        public bool IsBuffer(out nint buffer) =>
            this.glIsBuffer.Invoke(out buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBufferData(out nint target, out nint size, nint data, out nint usage);
        private readonly OpenGLBufferData glBufferData;
        
        public void BufferData(out nint target, out nint size, nint data, out nint usage) =>
            this.glBufferData.Invoke(out target, out size, data, out usage);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBufferSubData(out nint target, out nint offset, out nint size, nint data);
        private readonly OpenGLBufferSubData glBufferSubData;
        
        public void BufferSubData(out nint target, out nint offset, out nint size, nint data) =>
            this.glBufferSubData.Invoke(out target, out offset, out size, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBufferSubData(out nint target, out nint offset, out nint size, out nint data);
        private readonly OpenGLGetBufferSubData glGetBufferSubData;
        
        public void GetBufferSubData(out nint target, out nint offset, out nint size, out nint data) =>
            this.glGetBufferSubData.Invoke(out target, out offset, out size, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint OpenGLMapBuffer(out nint target, out nint access);
        private readonly OpenGLMapBuffer glMapBuffer;
        
        public nint MapBuffer(out nint target, out nint access) =>
            this.glMapBuffer.Invoke(out target, out access);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLUnmapBuffer(out nint target);
        private readonly OpenGLUnmapBuffer glUnmapBuffer;
        
        public bool UnmapBuffer(out nint target) =>
            this.glUnmapBuffer.Invoke(out target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBufferParameteriv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetBufferParameteriv glGetBufferParameteriv;
        
        public void GetBufferParameteriv(out nint target, out nint pname, out nint @params) =>
            this.glGetBufferParameteriv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBufferPointerv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetBufferPointerv glGetBufferPointerv;
        
        public void GetBufferPointerv(out nint target, out nint pname, out nint @params) =>
            this.glGetBufferPointerv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlendEquationSeparate(out nint modeRGB, out nint modeAlpha);
        private readonly OpenGLBlendEquationSeparate glBlendEquationSeparate;
        
        public void BlendEquationSeparate(out nint modeRGB, out nint modeAlpha) =>
            this.glBlendEquationSeparate.Invoke(out modeRGB, out modeAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawBuffers(out nint n, nint bufs);
        private readonly OpenGLDrawBuffers glDrawBuffers;
        
        public void DrawBuffers(out nint n, nint bufs) =>
            this.glDrawBuffers.Invoke(out n, bufs);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilOpSeparate(out nint face, out nint sfail, out nint dpfail, out nint dppass);
        private readonly OpenGLStencilOpSeparate glStencilOpSeparate;
        
        public void StencilOpSeparate(out nint face, out nint sfail, out nint dpfail, out nint dppass) =>
            this.glStencilOpSeparate.Invoke(out face, out sfail, out dpfail, out dppass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilFuncSeparate(out nint face, out nint func, out nint @ref, out nint mask);
        private readonly OpenGLStencilFuncSeparate glStencilFuncSeparate;
        
        public void StencilFuncSeparate(out nint face, out nint func, out nint @ref, out nint mask) =>
            this.glStencilFuncSeparate.Invoke(out face, out func, out @ref, out mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLStencilMaskSeparate(out nint face, out nint mask);
        private readonly OpenGLStencilMaskSeparate glStencilMaskSeparate;
        
        public void StencilMaskSeparate(out nint face, out nint mask) =>
            this.glStencilMaskSeparate.Invoke(out face, out mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLAttachShader(out nint program, out nint shader);
        private readonly OpenGLAttachShader glAttachShader;
        
        public void AttachShader(out nint program, out nint shader) =>
            this.glAttachShader.Invoke(out program, out shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindAttribLocation(out nint program, out nint index, nint name);
        private readonly OpenGLBindAttribLocation glBindAttribLocation;
        
        public void BindAttribLocation(out nint program, out nint index, nint name) =>
            this.glBindAttribLocation.Invoke(out program, out index, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCompileShader(out nint shader);
        private readonly OpenGLCompileShader glCompileShader;
        
        public void CompileShader(out nint shader) =>
            this.glCompileShader.Invoke(out shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLCreateProgram();
        private readonly OpenGLCreateProgram glCreateProgram;
        
        public uint CreateProgram() =>
            this.glCreateProgram.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLCreateShader(out nint type);
        private readonly OpenGLCreateShader glCreateShader;
        
        public uint CreateShader(out nint type) =>
            this.glCreateShader.Invoke(out type);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteProgram(out nint program);
        private readonly OpenGLDeleteProgram glDeleteProgram;
        
        public void DeleteProgram(out nint program) =>
            this.glDeleteProgram.Invoke(out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteShader(out nint shader);
        private readonly OpenGLDeleteShader glDeleteShader;
        
        public void DeleteShader(out nint shader) =>
            this.glDeleteShader.Invoke(out shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDetachShader(out nint program, out nint shader);
        private readonly OpenGLDetachShader glDetachShader;
        
        public void DetachShader(out nint program, out nint shader) =>
            this.glDetachShader.Invoke(out program, out shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDisableVertexAttribArray(out nint index);
        private readonly OpenGLDisableVertexAttribArray glDisableVertexAttribArray;
        
        public void DisableVertexAttribArray(out nint index) =>
            this.glDisableVertexAttribArray.Invoke(out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEnableVertexAttribArray(out nint index);
        private readonly OpenGLEnableVertexAttribArray glEnableVertexAttribArray;
        
        public void EnableVertexAttribArray(out nint index) =>
            this.glEnableVertexAttribArray.Invoke(out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveAttrib(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name);
        private readonly OpenGLGetActiveAttrib glGetActiveAttrib;
        
        public void GetActiveAttrib(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name) =>
            this.glGetActiveAttrib.Invoke(out program, out index, out bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveUniform(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name);
        private readonly OpenGLGetActiveUniform glGetActiveUniform;
        
        public void GetActiveUniform(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name) =>
            this.glGetActiveUniform.Invoke(out program, out index, out bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetAttachedShaders(out nint program, out nint maxCount, out nint count, out nint shaders);
        private readonly OpenGLGetAttachedShaders glGetAttachedShaders;
        
        public void GetAttachedShaders(out nint program, out nint maxCount, out nint count, out nint shaders) =>
            this.glGetAttachedShaders.Invoke(out program, out maxCount, out count, out shaders);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int OpenGLGetAttribLocation(out nint program, nint name);
        private readonly OpenGLGetAttribLocation glGetAttribLocation;
        
        public int GetAttribLocation(out nint program, nint name) =>
            this.glGetAttribLocation.Invoke(out program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramiv(out nint program, out nint pname, out nint @params);
        private readonly OpenGLGetProgramiv glGetProgramiv;
        
        public void GetProgramiv(out nint program, out nint pname, out nint @params) =>
            this.glGetProgramiv.Invoke(out program, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetProgramInfoLog(out nint program, out nint bufSize, out nint length, out nint infoLog);
        private readonly OpenGLGetProgramInfoLog glGetProgramInfoLog;
        
        public void GetProgramInfoLog(out nint program, out nint bufSize, out nint length, out nint infoLog) =>
            this.glGetProgramInfoLog.Invoke(out program, out bufSize, out length, out infoLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetShaderiv(out nint shader, out nint pname, out nint @params);
        private readonly OpenGLGetShaderiv glGetShaderiv;
        
        public void GetShaderiv(out nint shader, out nint pname, out nint @params) =>
            this.glGetShaderiv.Invoke(out shader, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetShaderInfoLog(out nint shader, out nint bufSize, out nint length, out nint infoLog);
        private readonly OpenGLGetShaderInfoLog glGetShaderInfoLog;
        
        public void GetShaderInfoLog(out nint shader, out nint bufSize, out nint length, out nint infoLog) =>
            this.glGetShaderInfoLog.Invoke(out shader, out bufSize, out length, out infoLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetShaderSource(out nint shader, out nint bufSize, out nint length, out nint source);
        private readonly OpenGLGetShaderSource glGetShaderSource;
        
        public void GetShaderSource(out nint shader, out nint bufSize, out nint length, out nint source) =>
            this.glGetShaderSource.Invoke(out shader, out bufSize, out length, out source);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int OpenGLGetUniformLocation(out nint program, nint name);
        private readonly OpenGLGetUniformLocation glGetUniformLocation;
        
        public int GetUniformLocation(out nint program, nint name) =>
            this.glGetUniformLocation.Invoke(out program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetUniformfv(out nint program, out nint location, out nint @params);
        private readonly OpenGLGetUniformfv glGetUniformfv;
        
        public void GetUniformfv(out nint program, out nint location, out nint @params) =>
            this.glGetUniformfv.Invoke(out program, out location, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetUniformiv(out nint program, out nint location, out nint @params);
        private readonly OpenGLGetUniformiv glGetUniformiv;
        
        public void GetUniformiv(out nint program, out nint location, out nint @params) =>
            this.glGetUniformiv.Invoke(out program, out location, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribdv(out nint index, out nint pname, out nint @params);
        private readonly OpenGLGetVertexAttribdv glGetVertexAttribdv;
        
        public void GetVertexAttribdv(out nint index, out nint pname, out nint @params) =>
            this.glGetVertexAttribdv.Invoke(out index, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribfv(out nint index, out nint pname, out nint @params);
        private readonly OpenGLGetVertexAttribfv glGetVertexAttribfv;
        
        public void GetVertexAttribfv(out nint index, out nint pname, out nint @params) =>
            this.glGetVertexAttribfv.Invoke(out index, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribiv(out nint index, out nint pname, out nint @params);
        private readonly OpenGLGetVertexAttribiv glGetVertexAttribiv;
        
        public void GetVertexAttribiv(out nint index, out nint pname, out nint @params) =>
            this.glGetVertexAttribiv.Invoke(out index, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribPointerv(out nint index, out nint pname, out nint pointer);
        private readonly OpenGLGetVertexAttribPointerv glGetVertexAttribPointerv;
        
        public void GetVertexAttribPointerv(out nint index, out nint pname, out nint pointer) =>
            this.glGetVertexAttribPointerv.Invoke(out index, out pname, out pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsProgram(out nint program);
        private readonly OpenGLIsProgram glIsProgram;
        
        public bool IsProgram(out nint program) =>
            this.glIsProgram.Invoke(out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsShader(out nint shader);
        private readonly OpenGLIsShader glIsShader;
        
        public bool IsShader(out nint shader) =>
            this.glIsShader.Invoke(out shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLLinkProgram(out nint program);
        private readonly OpenGLLinkProgram glLinkProgram;
        
        public void LinkProgram(out nint program) =>
            this.glLinkProgram.Invoke(out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLShaderSource(out nint shader, out nint count, nint @string, nint length);
        private readonly OpenGLShaderSource glShaderSource;
        
        public void ShaderSource(out nint shader, out nint count, nint @string, nint length) =>
            this.glShaderSource.Invoke(out shader, out count, @string, length);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUseProgram(out nint program);
        private readonly OpenGLUseProgram glUseProgram;
        
        public void UseProgram(out nint program) =>
            this.glUseProgram.Invoke(out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1f(out nint location, out nint v0);
        private readonly OpenGLUniform1f glUniform1f;
        
        public void Uniform1f(out nint location, out nint v0) =>
            this.glUniform1f.Invoke(out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2f(out nint location, out nint v0, out nint v1);
        private readonly OpenGLUniform2f glUniform2f;
        
        public void Uniform2f(out nint location, out nint v0, out nint v1) =>
            this.glUniform2f.Invoke(out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3f(out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLUniform3f glUniform3f;
        
        public void Uniform3f(out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glUniform3f.Invoke(out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4f(out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLUniform4f glUniform4f;
        
        public void Uniform4f(out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glUniform4f.Invoke(out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1i(out nint location, out nint v0);
        private readonly OpenGLUniform1i glUniform1i;
        
        public void Uniform1i(out nint location, out nint v0) =>
            this.glUniform1i.Invoke(out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2i(out nint location, out nint v0, out nint v1);
        private readonly OpenGLUniform2i glUniform2i;
        
        public void Uniform2i(out nint location, out nint v0, out nint v1) =>
            this.glUniform2i.Invoke(out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3i(out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLUniform3i glUniform3i;
        
        public void Uniform3i(out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glUniform3i.Invoke(out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4i(out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLUniform4i glUniform4i;
        
        public void Uniform4i(out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glUniform4i.Invoke(out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1fv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform1fv glUniform1fv;
        
        public void Uniform1fv(out nint location, out nint count, nint value) =>
            this.glUniform1fv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2fv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform2fv glUniform2fv;
        
        public void Uniform2fv(out nint location, out nint count, nint value) =>
            this.glUniform2fv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3fv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform3fv glUniform3fv;
        
        public void Uniform3fv(out nint location, out nint count, nint value) =>
            this.glUniform3fv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4fv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform4fv glUniform4fv;
        
        public void Uniform4fv(out nint location, out nint count, nint value) =>
            this.glUniform4fv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1iv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform1iv glUniform1iv;
        
        public void Uniform1iv(out nint location, out nint count, nint value) =>
            this.glUniform1iv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2iv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform2iv glUniform2iv;
        
        public void Uniform2iv(out nint location, out nint count, nint value) =>
            this.glUniform2iv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3iv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform3iv glUniform3iv;
        
        public void Uniform3iv(out nint location, out nint count, nint value) =>
            this.glUniform3iv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4iv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform4iv glUniform4iv;
        
        public void Uniform4iv(out nint location, out nint count, nint value) =>
            this.glUniform4iv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix2fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix2fv glUniformMatrix2fv;
        
        public void UniformMatrix2fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix2fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix3fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix3fv glUniformMatrix3fv;
        
        public void UniformMatrix3fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix3fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix4fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix4fv glUniformMatrix4fv;
        
        public void UniformMatrix4fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix4fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLValidateProgram(out nint program);
        private readonly OpenGLValidateProgram glValidateProgram;
        
        public void ValidateProgram(out nint program) =>
            this.glValidateProgram.Invoke(out program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1d(out nint index, out nint x);
        private readonly OpenGLVertexAttrib1d glVertexAttrib1d;
        
        public void VertexAttrib1d(out nint index, out nint x) =>
            this.glVertexAttrib1d.Invoke(out index, out x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1dv(out nint index, nint v);
        private readonly OpenGLVertexAttrib1dv glVertexAttrib1dv;
        
        public void VertexAttrib1dv(out nint index, nint v) =>
            this.glVertexAttrib1dv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1f(out nint index, out nint x);
        private readonly OpenGLVertexAttrib1f glVertexAttrib1f;
        
        public void VertexAttrib1f(out nint index, out nint x) =>
            this.glVertexAttrib1f.Invoke(out index, out x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1fv(out nint index, nint v);
        private readonly OpenGLVertexAttrib1fv glVertexAttrib1fv;
        
        public void VertexAttrib1fv(out nint index, nint v) =>
            this.glVertexAttrib1fv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1s(out nint index, out nint x);
        private readonly OpenGLVertexAttrib1s glVertexAttrib1s;
        
        public void VertexAttrib1s(out nint index, out nint x) =>
            this.glVertexAttrib1s.Invoke(out index, out x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib1sv(out nint index, nint v);
        private readonly OpenGLVertexAttrib1sv glVertexAttrib1sv;
        
        public void VertexAttrib1sv(out nint index, nint v) =>
            this.glVertexAttrib1sv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2d(out nint index, out nint x, out nint y);
        private readonly OpenGLVertexAttrib2d glVertexAttrib2d;
        
        public void VertexAttrib2d(out nint index, out nint x, out nint y) =>
            this.glVertexAttrib2d.Invoke(out index, out x, out y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2dv(out nint index, nint v);
        private readonly OpenGLVertexAttrib2dv glVertexAttrib2dv;
        
        public void VertexAttrib2dv(out nint index, nint v) =>
            this.glVertexAttrib2dv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2f(out nint index, out nint x, out nint y);
        private readonly OpenGLVertexAttrib2f glVertexAttrib2f;
        
        public void VertexAttrib2f(out nint index, out nint x, out nint y) =>
            this.glVertexAttrib2f.Invoke(out index, out x, out y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2fv(out nint index, nint v);
        private readonly OpenGLVertexAttrib2fv glVertexAttrib2fv;
        
        public void VertexAttrib2fv(out nint index, nint v) =>
            this.glVertexAttrib2fv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2s(out nint index, out nint x, out nint y);
        private readonly OpenGLVertexAttrib2s glVertexAttrib2s;
        
        public void VertexAttrib2s(out nint index, out nint x, out nint y) =>
            this.glVertexAttrib2s.Invoke(out index, out x, out y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib2sv(out nint index, nint v);
        private readonly OpenGLVertexAttrib2sv glVertexAttrib2sv;
        
        public void VertexAttrib2sv(out nint index, nint v) =>
            this.glVertexAttrib2sv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3d(out nint index, out nint x, out nint y, out nint z);
        private readonly OpenGLVertexAttrib3d glVertexAttrib3d;
        
        public void VertexAttrib3d(out nint index, out nint x, out nint y, out nint z) =>
            this.glVertexAttrib3d.Invoke(out index, out x, out y, out z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3dv(out nint index, nint v);
        private readonly OpenGLVertexAttrib3dv glVertexAttrib3dv;
        
        public void VertexAttrib3dv(out nint index, nint v) =>
            this.glVertexAttrib3dv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3f(out nint index, out nint x, out nint y, out nint z);
        private readonly OpenGLVertexAttrib3f glVertexAttrib3f;
        
        public void VertexAttrib3f(out nint index, out nint x, out nint y, out nint z) =>
            this.glVertexAttrib3f.Invoke(out index, out x, out y, out z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3fv(out nint index, nint v);
        private readonly OpenGLVertexAttrib3fv glVertexAttrib3fv;
        
        public void VertexAttrib3fv(out nint index, nint v) =>
            this.glVertexAttrib3fv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3s(out nint index, out nint x, out nint y, out nint z);
        private readonly OpenGLVertexAttrib3s glVertexAttrib3s;
        
        public void VertexAttrib3s(out nint index, out nint x, out nint y, out nint z) =>
            this.glVertexAttrib3s.Invoke(out index, out x, out y, out z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib3sv(out nint index, nint v);
        private readonly OpenGLVertexAttrib3sv glVertexAttrib3sv;
        
        public void VertexAttrib3sv(out nint index, nint v) =>
            this.glVertexAttrib3sv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nbv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Nbv glVertexAttrib4Nbv;
        
        public void VertexAttrib4Nbv(out nint index, nint v) =>
            this.glVertexAttrib4Nbv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Niv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Niv glVertexAttrib4Niv;
        
        public void VertexAttrib4Niv(out nint index, nint v) =>
            this.glVertexAttrib4Niv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nsv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Nsv glVertexAttrib4Nsv;
        
        public void VertexAttrib4Nsv(out nint index, nint v) =>
            this.glVertexAttrib4Nsv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nub(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttrib4Nub glVertexAttrib4Nub;
        
        public void VertexAttrib4Nub(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttrib4Nub.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nubv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Nubv glVertexAttrib4Nubv;
        
        public void VertexAttrib4Nubv(out nint index, nint v) =>
            this.glVertexAttrib4Nubv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nuiv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Nuiv glVertexAttrib4Nuiv;
        
        public void VertexAttrib4Nuiv(out nint index, nint v) =>
            this.glVertexAttrib4Nuiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4Nusv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4Nusv glVertexAttrib4Nusv;
        
        public void VertexAttrib4Nusv(out nint index, nint v) =>
            this.glVertexAttrib4Nusv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4bv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4bv glVertexAttrib4bv;
        
        public void VertexAttrib4bv(out nint index, nint v) =>
            this.glVertexAttrib4bv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4d(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttrib4d glVertexAttrib4d;
        
        public void VertexAttrib4d(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttrib4d.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4dv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4dv glVertexAttrib4dv;
        
        public void VertexAttrib4dv(out nint index, nint v) =>
            this.glVertexAttrib4dv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4f(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttrib4f glVertexAttrib4f;
        
        public void VertexAttrib4f(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttrib4f.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4fv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4fv glVertexAttrib4fv;
        
        public void VertexAttrib4fv(out nint index, nint v) =>
            this.glVertexAttrib4fv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4iv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4iv glVertexAttrib4iv;
        
        public void VertexAttrib4iv(out nint index, nint v) =>
            this.glVertexAttrib4iv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4s(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttrib4s glVertexAttrib4s;
        
        public void VertexAttrib4s(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttrib4s.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4sv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4sv glVertexAttrib4sv;
        
        public void VertexAttrib4sv(out nint index, nint v) =>
            this.glVertexAttrib4sv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4ubv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4ubv glVertexAttrib4ubv;
        
        public void VertexAttrib4ubv(out nint index, nint v) =>
            this.glVertexAttrib4ubv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4uiv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4uiv glVertexAttrib4uiv;
        
        public void VertexAttrib4uiv(out nint index, nint v) =>
            this.glVertexAttrib4uiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttrib4usv(out nint index, nint v);
        private readonly OpenGLVertexAttrib4usv glVertexAttrib4usv;
        
        public void VertexAttrib4usv(out nint index, nint v) =>
            this.glVertexAttrib4usv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribPointer(out nint index, out nint size, out nint type, out nint normalized, out nint stride, nint pointer);
        private readonly OpenGLVertexAttribPointer glVertexAttribPointer;
        
        public void VertexAttribPointer(out nint index, out nint size, out nint type, out nint normalized, out nint stride, nint pointer) =>
            this.glVertexAttribPointer.Invoke(out index, out size, out type, out normalized, out stride, pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix2x3fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix2x3fv glUniformMatrix2x3fv;
        
        public void UniformMatrix2x3fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix2x3fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix3x2fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix3x2fv glUniformMatrix3x2fv;
        
        public void UniformMatrix3x2fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix3x2fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix2x4fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix2x4fv glUniformMatrix2x4fv;
        
        public void UniformMatrix2x4fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix2x4fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix4x2fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix4x2fv glUniformMatrix4x2fv;
        
        public void UniformMatrix4x2fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix4x2fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix3x4fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix3x4fv glUniformMatrix3x4fv;
        
        public void UniformMatrix3x4fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix3x4fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformMatrix4x3fv(out nint location, out nint count, out nint transpose, nint value);
        private readonly OpenGLUniformMatrix4x3fv glUniformMatrix4x3fv;
        
        public void UniformMatrix4x3fv(out nint location, out nint count, out nint transpose, nint value) =>
            this.glUniformMatrix4x3fv.Invoke(out location, out count, out transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLColorMaski(out nint index, out nint r, out nint g, out nint b, out nint a);
        private readonly OpenGLColorMaski glColorMaski;
        
        public void ColorMaski(out nint index, out nint r, out nint g, out nint b, out nint a) =>
            this.glColorMaski.Invoke(out index, out r, out g, out b, out a);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBooleani_v(out nint target, out nint index, out nint data);
        private readonly OpenGLGetBooleani_v glGetBooleani_v;
        
        public void GetBooleani_v(out nint target, out nint index, out nint data) =>
            this.glGetBooleani_v.Invoke(out target, out index, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetIntegeri_v(out nint target, out nint index, out nint data);
        private readonly OpenGLGetIntegeri_v glGetIntegeri_v;
        
        public void GetIntegeri_v(out nint target, out nint index, out nint data) =>
            this.glGetIntegeri_v.Invoke(out target, out index, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEnablei(out nint target, out nint index);
        private readonly OpenGLEnablei glEnablei;
        
        public void Enablei(out nint target, out nint index) =>
            this.glEnablei.Invoke(out target, out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDisablei(out nint target, out nint index);
        private readonly OpenGLDisablei glDisablei;
        
        public void Disablei(out nint target, out nint index) =>
            this.glDisablei.Invoke(out target, out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsEnabledi(out nint target, out nint index);
        private readonly OpenGLIsEnabledi glIsEnabledi;
        
        public bool IsEnabledi(out nint target, out nint index) =>
            this.glIsEnabledi.Invoke(out target, out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBeginTransformFeedback(out nint primitiveMode);
        private readonly OpenGLBeginTransformFeedback glBeginTransformFeedback;
        
        public void BeginTransformFeedback(out nint primitiveMode) =>
            this.glBeginTransformFeedback.Invoke(out primitiveMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEndTransformFeedback();
        private readonly OpenGLEndTransformFeedback glEndTransformFeedback;
        
        public void EndTransformFeedback() =>
            this.glEndTransformFeedback.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindBufferRange(out nint target, out nint index, out nint buffer, out nint offset, out nint size);
        private readonly OpenGLBindBufferRange glBindBufferRange;
        
        public void BindBufferRange(out nint target, out nint index, out nint buffer, out nint offset, out nint size) =>
            this.glBindBufferRange.Invoke(out target, out index, out buffer, out offset, out size);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindBufferBase(out nint target, out nint index, out nint buffer);
        private readonly OpenGLBindBufferBase glBindBufferBase;
        
        public void BindBufferBase(out nint target, out nint index, out nint buffer) =>
            this.glBindBufferBase.Invoke(out target, out index, out buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTransformFeedbackVaryings(out nint program, out nint count, nint varyings, out nint bufferMode);
        private readonly OpenGLTransformFeedbackVaryings glTransformFeedbackVaryings;
        
        public void TransformFeedbackVaryings(out nint program, out nint count, nint varyings, out nint bufferMode) =>
            this.glTransformFeedbackVaryings.Invoke(out program, out count, varyings, out bufferMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTransformFeedbackVarying(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name);
        private readonly OpenGLGetTransformFeedbackVarying glGetTransformFeedbackVarying;
        
        public void GetTransformFeedbackVarying(out nint program, out nint index, out nint bufSize, out nint length, out nint size, out nint type, out nint name) =>
            this.glGetTransformFeedbackVarying.Invoke(out program, out index, out bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClampColor(out nint target, out nint clamp);
        private readonly OpenGLClampColor glClampColor;
        
        public void ClampColor(out nint target, out nint clamp) =>
            this.glClampColor.Invoke(out target, out clamp);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBeginConditionalRender(out nint id, out nint mode);
        private readonly OpenGLBeginConditionalRender glBeginConditionalRender;
        
        public void BeginConditionalRender(out nint id, out nint mode) =>
            this.glBeginConditionalRender.Invoke(out id, out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLEndConditionalRender();
        private readonly OpenGLEndConditionalRender glEndConditionalRender;
        
        public void EndConditionalRender() =>
            this.glEndConditionalRender.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribIPointer(out nint index, out nint size, out nint type, out nint stride, nint pointer);
        private readonly OpenGLVertexAttribIPointer glVertexAttribIPointer;
        
        public void VertexAttribIPointer(out nint index, out nint size, out nint type, out nint stride, nint pointer) =>
            this.glVertexAttribIPointer.Invoke(out index, out size, out type, out stride, pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribIiv(out nint index, out nint pname, out nint @params);
        private readonly OpenGLGetVertexAttribIiv glGetVertexAttribIiv;
        
        public void GetVertexAttribIiv(out nint index, out nint pname, out nint @params) =>
            this.glGetVertexAttribIiv.Invoke(out index, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetVertexAttribIuiv(out nint index, out nint pname, out nint @params);
        private readonly OpenGLGetVertexAttribIuiv glGetVertexAttribIuiv;
        
        public void GetVertexAttribIuiv(out nint index, out nint pname, out nint @params) =>
            this.glGetVertexAttribIuiv.Invoke(out index, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI1i(out nint index, out nint x);
        private readonly OpenGLVertexAttribI1i glVertexAttribI1i;
        
        public void VertexAttribI1i(out nint index, out nint x) =>
            this.glVertexAttribI1i.Invoke(out index, out x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI2i(out nint index, out nint x, out nint y);
        private readonly OpenGLVertexAttribI2i glVertexAttribI2i;
        
        public void VertexAttribI2i(out nint index, out nint x, out nint y) =>
            this.glVertexAttribI2i.Invoke(out index, out x, out y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI3i(out nint index, out nint x, out nint y, out nint z);
        private readonly OpenGLVertexAttribI3i glVertexAttribI3i;
        
        public void VertexAttribI3i(out nint index, out nint x, out nint y, out nint z) =>
            this.glVertexAttribI3i.Invoke(out index, out x, out y, out z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4i(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttribI4i glVertexAttribI4i;
        
        public void VertexAttribI4i(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttribI4i.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI1ui(out nint index, out nint x);
        private readonly OpenGLVertexAttribI1ui glVertexAttribI1ui;
        
        public void VertexAttribI1ui(out nint index, out nint x) =>
            this.glVertexAttribI1ui.Invoke(out index, out x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI2ui(out nint index, out nint x, out nint y);
        private readonly OpenGLVertexAttribI2ui glVertexAttribI2ui;
        
        public void VertexAttribI2ui(out nint index, out nint x, out nint y) =>
            this.glVertexAttribI2ui.Invoke(out index, out x, out y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI3ui(out nint index, out nint x, out nint y, out nint z);
        private readonly OpenGLVertexAttribI3ui glVertexAttribI3ui;
        
        public void VertexAttribI3ui(out nint index, out nint x, out nint y, out nint z) =>
            this.glVertexAttribI3ui.Invoke(out index, out x, out y, out z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4ui(out nint index, out nint x, out nint y, out nint z, out nint w);
        private readonly OpenGLVertexAttribI4ui glVertexAttribI4ui;
        
        public void VertexAttribI4ui(out nint index, out nint x, out nint y, out nint z, out nint w) =>
            this.glVertexAttribI4ui.Invoke(out index, out x, out y, out z, out w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI1iv(out nint index, nint v);
        private readonly OpenGLVertexAttribI1iv glVertexAttribI1iv;
        
        public void VertexAttribI1iv(out nint index, nint v) =>
            this.glVertexAttribI1iv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI2iv(out nint index, nint v);
        private readonly OpenGLVertexAttribI2iv glVertexAttribI2iv;
        
        public void VertexAttribI2iv(out nint index, nint v) =>
            this.glVertexAttribI2iv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI3iv(out nint index, nint v);
        private readonly OpenGLVertexAttribI3iv glVertexAttribI3iv;
        
        public void VertexAttribI3iv(out nint index, nint v) =>
            this.glVertexAttribI3iv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4iv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4iv glVertexAttribI4iv;
        
        public void VertexAttribI4iv(out nint index, nint v) =>
            this.glVertexAttribI4iv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI1uiv(out nint index, nint v);
        private readonly OpenGLVertexAttribI1uiv glVertexAttribI1uiv;
        
        public void VertexAttribI1uiv(out nint index, nint v) =>
            this.glVertexAttribI1uiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI2uiv(out nint index, nint v);
        private readonly OpenGLVertexAttribI2uiv glVertexAttribI2uiv;
        
        public void VertexAttribI2uiv(out nint index, nint v) =>
            this.glVertexAttribI2uiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI3uiv(out nint index, nint v);
        private readonly OpenGLVertexAttribI3uiv glVertexAttribI3uiv;
        
        public void VertexAttribI3uiv(out nint index, nint v) =>
            this.glVertexAttribI3uiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4uiv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4uiv glVertexAttribI4uiv;
        
        public void VertexAttribI4uiv(out nint index, nint v) =>
            this.glVertexAttribI4uiv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4bv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4bv glVertexAttribI4bv;
        
        public void VertexAttribI4bv(out nint index, nint v) =>
            this.glVertexAttribI4bv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4sv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4sv glVertexAttribI4sv;
        
        public void VertexAttribI4sv(out nint index, nint v) =>
            this.glVertexAttribI4sv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4ubv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4ubv glVertexAttribI4ubv;
        
        public void VertexAttribI4ubv(out nint index, nint v) =>
            this.glVertexAttribI4ubv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLVertexAttribI4usv(out nint index, nint v);
        private readonly OpenGLVertexAttribI4usv glVertexAttribI4usv;
        
        public void VertexAttribI4usv(out nint index, nint v) =>
            this.glVertexAttribI4usv.Invoke(out index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetUniformuiv(out nint program, out nint location, out nint @params);
        private readonly OpenGLGetUniformuiv glGetUniformuiv;
        
        public void GetUniformuiv(out nint program, out nint location, out nint @params) =>
            this.glGetUniformuiv.Invoke(out program, out location, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindFragDataLocation(out nint program, out nint color, nint name);
        private readonly OpenGLBindFragDataLocation glBindFragDataLocation;
        
        public void BindFragDataLocation(out nint program, out nint color, nint name) =>
            this.glBindFragDataLocation.Invoke(out program, out color, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int OpenGLGetFragDataLocation(out nint program, nint name);
        private readonly OpenGLGetFragDataLocation glGetFragDataLocation;
        
        public int GetFragDataLocation(out nint program, nint name) =>
            this.glGetFragDataLocation.Invoke(out program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1ui(out nint location, out nint v0);
        private readonly OpenGLUniform1ui glUniform1ui;
        
        public void Uniform1ui(out nint location, out nint v0) =>
            this.glUniform1ui.Invoke(out location, out v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2ui(out nint location, out nint v0, out nint v1);
        private readonly OpenGLUniform2ui glUniform2ui;
        
        public void Uniform2ui(out nint location, out nint v0, out nint v1) =>
            this.glUniform2ui.Invoke(out location, out v0, out v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3ui(out nint location, out nint v0, out nint v1, out nint v2);
        private readonly OpenGLUniform3ui glUniform3ui;
        
        public void Uniform3ui(out nint location, out nint v0, out nint v1, out nint v2) =>
            this.glUniform3ui.Invoke(out location, out v0, out v1, out v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4ui(out nint location, out nint v0, out nint v1, out nint v2, out nint v3);
        private readonly OpenGLUniform4ui glUniform4ui;
        
        public void Uniform4ui(out nint location, out nint v0, out nint v1, out nint v2, out nint v3) =>
            this.glUniform4ui.Invoke(out location, out v0, out v1, out v2, out v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform1uiv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform1uiv glUniform1uiv;
        
        public void Uniform1uiv(out nint location, out nint count, nint value) =>
            this.glUniform1uiv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform2uiv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform2uiv glUniform2uiv;
        
        public void Uniform2uiv(out nint location, out nint count, nint value) =>
            this.glUniform2uiv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform3uiv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform3uiv glUniform3uiv;
        
        public void Uniform3uiv(out nint location, out nint count, nint value) =>
            this.glUniform3uiv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniform4uiv(out nint location, out nint count, nint value);
        private readonly OpenGLUniform4uiv glUniform4uiv;
        
        public void Uniform4uiv(out nint location, out nint count, nint value) =>
            this.glUniform4uiv.Invoke(out location, out count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameterIiv(out nint target, out nint pname, nint @params);
        private readonly OpenGLTexParameterIiv glTexParameterIiv;
        
        public void TexParameterIiv(out nint target, out nint pname, nint @params) =>
            this.glTexParameterIiv.Invoke(out target, out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexParameterIuiv(out nint target, out nint pname, nint @params);
        private readonly OpenGLTexParameterIuiv glTexParameterIuiv;
        
        public void TexParameterIuiv(out nint target, out nint pname, nint @params) =>
            this.glTexParameterIuiv.Invoke(out target, out pname, @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexParameterIiv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetTexParameterIiv glGetTexParameterIiv;
        
        public void GetTexParameterIiv(out nint target, out nint pname, out nint @params) =>
            this.glGetTexParameterIiv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetTexParameterIuiv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetTexParameterIuiv glGetTexParameterIuiv;
        
        public void GetTexParameterIuiv(out nint target, out nint pname, out nint @params) =>
            this.glGetTexParameterIuiv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearBufferiv(out nint buffer, out nint drawbuffer, nint value);
        private readonly OpenGLClearBufferiv glClearBufferiv;
        
        public void ClearBufferiv(out nint buffer, out nint drawbuffer, nint value) =>
            this.glClearBufferiv.Invoke(out buffer, out drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearBufferuiv(out nint buffer, out nint drawbuffer, nint value);
        private readonly OpenGLClearBufferuiv glClearBufferuiv;
        
        public void ClearBufferuiv(out nint buffer, out nint drawbuffer, nint value) =>
            this.glClearBufferuiv.Invoke(out buffer, out drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearBufferfv(out nint buffer, out nint drawbuffer, nint value);
        private readonly OpenGLClearBufferfv glClearBufferfv;
        
        public void ClearBufferfv(out nint buffer, out nint drawbuffer, nint value) =>
            this.glClearBufferfv.Invoke(out buffer, out drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLClearBufferfi(out nint buffer, out nint drawbuffer, out nint depth, out nint stencil);
        private readonly OpenGLClearBufferfi glClearBufferfi;
        
        public void ClearBufferfi(out nint buffer, out nint drawbuffer, out nint depth, out nint stencil) =>
            this.glClearBufferfi.Invoke(out buffer, out drawbuffer, out depth, out stencil);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint OpenGLGetStringi(out nint name, out nint index);
        private readonly OpenGLGetStringi glGetStringi;
        
        public nint GetStringi(out nint name, out nint index) =>
            this.glGetStringi.Invoke(out name, out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsRenderbuffer(out nint renderbuffer);
        private readonly OpenGLIsRenderbuffer glIsRenderbuffer;
        
        public bool IsRenderbuffer(out nint renderbuffer) =>
            this.glIsRenderbuffer.Invoke(out renderbuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindRenderbuffer(out nint target, out nint renderbuffer);
        private readonly OpenGLBindRenderbuffer glBindRenderbuffer;
        
        public void BindRenderbuffer(out nint target, out nint renderbuffer) =>
            this.glBindRenderbuffer.Invoke(out target, out renderbuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteRenderbuffers(out nint n, nint renderbuffers);
        private readonly OpenGLDeleteRenderbuffers glDeleteRenderbuffers;
        
        public void DeleteRenderbuffers(out nint n, nint renderbuffers) =>
            this.glDeleteRenderbuffers.Invoke(out n, renderbuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenRenderbuffers(out nint n, out nint renderbuffers);
        private readonly OpenGLGenRenderbuffers glGenRenderbuffers;
        
        public void GenRenderbuffers(out nint n, out nint renderbuffers) =>
            this.glGenRenderbuffers.Invoke(out n, out renderbuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLRenderbufferStorage(out nint target, out nint internalformat, out nint width, out nint height);
        private readonly OpenGLRenderbufferStorage glRenderbufferStorage;
        
        public void RenderbufferStorage(out nint target, out nint internalformat, out nint width, out nint height) =>
            this.glRenderbufferStorage.Invoke(out target, out internalformat, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetRenderbufferParameteriv(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetRenderbufferParameteriv glGetRenderbufferParameteriv;
        
        public void GetRenderbufferParameteriv(out nint target, out nint pname, out nint @params) =>
            this.glGetRenderbufferParameteriv.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsFramebuffer(out nint framebuffer);
        private readonly OpenGLIsFramebuffer glIsFramebuffer;
        
        public bool IsFramebuffer(out nint framebuffer) =>
            this.glIsFramebuffer.Invoke(out framebuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindFramebuffer(out nint target, out nint framebuffer);
        private readonly OpenGLBindFramebuffer glBindFramebuffer;
        
        public void BindFramebuffer(out nint target, out nint framebuffer) =>
            this.glBindFramebuffer.Invoke(out target, out framebuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteFramebuffers(out nint n, nint framebuffers);
        private readonly OpenGLDeleteFramebuffers glDeleteFramebuffers;
        
        public void DeleteFramebuffers(out nint n, nint framebuffers) =>
            this.glDeleteFramebuffers.Invoke(out n, framebuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenFramebuffers(out nint n, out nint framebuffers);
        private readonly OpenGLGenFramebuffers glGenFramebuffers;
        
        public void GenFramebuffers(out nint n, out nint framebuffers) =>
            this.glGenFramebuffers.Invoke(out n, out framebuffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FramebufferStatus OpenGLCheckFramebufferStatus(out nint target);
        private readonly OpenGLCheckFramebufferStatus glCheckFramebufferStatus;
        
        public FramebufferStatus CheckFramebufferStatus(out nint target) =>
            this.glCheckFramebufferStatus.Invoke(out target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTexture1D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level);
        private readonly OpenGLFramebufferTexture1D glFramebufferTexture1D;
        
        public void FramebufferTexture1D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level) =>
            this.glFramebufferTexture1D.Invoke(out target, out attachment, out textarget, out texture, out level);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTexture2D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level);
        private readonly OpenGLFramebufferTexture2D glFramebufferTexture2D;
        
        public void FramebufferTexture2D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level) =>
            this.glFramebufferTexture2D.Invoke(out target, out attachment, out textarget, out texture, out level);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTexture3D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level, out nint zoffset);
        private readonly OpenGLFramebufferTexture3D glFramebufferTexture3D;
        
        public void FramebufferTexture3D(out nint target, out nint attachment, out nint textarget, out nint texture, out nint level, out nint zoffset) =>
            this.glFramebufferTexture3D.Invoke(out target, out attachment, out textarget, out texture, out level, out zoffset);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferRenderbuffer(out nint target, out nint attachment, out nint renderbuffertarget, out nint renderbuffer);
        private readonly OpenGLFramebufferRenderbuffer glFramebufferRenderbuffer;
        
        public void FramebufferRenderbuffer(out nint target, out nint attachment, out nint renderbuffertarget, out nint renderbuffer) =>
            this.glFramebufferRenderbuffer.Invoke(out target, out attachment, out renderbuffertarget, out renderbuffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetFramebufferAttachmentParameteriv(out nint target, out nint attachment, out nint pname, out nint @params);
        private readonly OpenGLGetFramebufferAttachmentParameteriv glGetFramebufferAttachmentParameteriv;
        
        public void GetFramebufferAttachmentParameteriv(out nint target, out nint attachment, out nint pname, out nint @params) =>
            this.glGetFramebufferAttachmentParameteriv.Invoke(out target, out attachment, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenerateMipmap(out nint target);
        private readonly OpenGLGenerateMipmap glGenerateMipmap;
        
        public void GenerateMipmap(out nint target) =>
            this.glGenerateMipmap.Invoke(out target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBlitFramebuffer(out nint srcX0, out nint srcY0, out nint srcX1, out nint srcY1, out nint dstX0, out nint dstY0, out nint dstX1, out nint dstY1, out nint mask, out nint filter);
        private readonly OpenGLBlitFramebuffer glBlitFramebuffer;
        
        public void BlitFramebuffer(out nint srcX0, out nint srcY0, out nint srcX1, out nint srcY1, out nint dstX0, out nint dstY0, out nint dstX1, out nint dstY1, out nint mask, out nint filter) =>
            this.glBlitFramebuffer.Invoke(out srcX0, out srcY0, out srcX1, out srcY1, out dstX0, out dstY0, out dstX1, out dstY1, out mask, out filter);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLRenderbufferStorageMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height);
        private readonly OpenGLRenderbufferStorageMultisample glRenderbufferStorageMultisample;
        
        public void RenderbufferStorageMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height) =>
            this.glRenderbufferStorageMultisample.Invoke(out target, out samples, out internalformat, out width, out height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTextureLayer(out nint target, out nint attachment, out nint texture, out nint level, out nint layer);
        private readonly OpenGLFramebufferTextureLayer glFramebufferTextureLayer;
        
        public void FramebufferTextureLayer(out nint target, out nint attachment, out nint texture, out nint level, out nint layer) =>
            this.glFramebufferTextureLayer.Invoke(out target, out attachment, out texture, out level, out layer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint OpenGLMapBufferRange(out nint target, out nint offset, out nint length, out nint access);
        private readonly OpenGLMapBufferRange glMapBufferRange;
        
        public nint MapBufferRange(out nint target, out nint offset, out nint length, out nint access) =>
            this.glMapBufferRange.Invoke(out target, out offset, out length, out access);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFlushMappedBufferRange(out nint target, out nint offset, out nint length);
        private readonly OpenGLFlushMappedBufferRange glFlushMappedBufferRange;
        
        public void FlushMappedBufferRange(out nint target, out nint offset, out nint length) =>
            this.glFlushMappedBufferRange.Invoke(out target, out offset, out length);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLBindVertexArray(out nint array);
        private readonly OpenGLBindVertexArray glBindVertexArray;
        
        public void BindVertexArray(out nint array) =>
            this.glBindVertexArray.Invoke(out array);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteVertexArrays(out nint n, nint arrays);
        private readonly OpenGLDeleteVertexArrays glDeleteVertexArrays;
        
        public void DeleteVertexArrays(out nint n, nint arrays) =>
            this.glDeleteVertexArrays.Invoke(out n, arrays);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGenVertexArrays(out nint n, out nint arrays);
        private readonly OpenGLGenVertexArrays glGenVertexArrays;
        
        public void GenVertexArrays(out nint n, out nint arrays) =>
            this.glGenVertexArrays.Invoke(out n, out arrays);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsVertexArray(out nint array);
        private readonly OpenGLIsVertexArray glIsVertexArray;
        
        public bool IsVertexArray(out nint array) =>
            this.glIsVertexArray.Invoke(out array);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawArraysInstanced(out nint mode, out nint first, out nint count, out nint instancecount);
        private readonly OpenGLDrawArraysInstanced glDrawArraysInstanced;
        
        public void DrawArraysInstanced(out nint mode, out nint first, out nint count, out nint instancecount) =>
            this.glDrawArraysInstanced.Invoke(out mode, out first, out count, out instancecount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawElementsInstanced(out nint mode, out nint count, out nint type, nint indices, out nint instancecount);
        private readonly OpenGLDrawElementsInstanced glDrawElementsInstanced;
        
        public void DrawElementsInstanced(out nint mode, out nint count, out nint type, nint indices, out nint instancecount) =>
            this.glDrawElementsInstanced.Invoke(out mode, out count, out type, indices, out instancecount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexBuffer(out nint target, out nint internalformat, out nint buffer);
        private readonly OpenGLTexBuffer glTexBuffer;
        
        public void TexBuffer(out nint target, out nint internalformat, out nint buffer) =>
            this.glTexBuffer.Invoke(out target, out internalformat, out buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLPrimitiveRestartIndex(out nint index);
        private readonly OpenGLPrimitiveRestartIndex glPrimitiveRestartIndex;
        
        public void PrimitiveRestartIndex(out nint index) =>
            this.glPrimitiveRestartIndex.Invoke(out index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLCopyBufferSubData(out nint readTarget, out nint writeTarget, out nint readOffset, out nint writeOffset, out nint size);
        private readonly OpenGLCopyBufferSubData glCopyBufferSubData;
        
        public void CopyBufferSubData(out nint readTarget, out nint writeTarget, out nint readOffset, out nint writeOffset, out nint size) =>
            this.glCopyBufferSubData.Invoke(out readTarget, out writeTarget, out readOffset, out writeOffset, out size);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetUniformIndices(out nint program, out nint uniformCount, nint uniformNames, out nint uniformIndices);
        private readonly OpenGLGetUniformIndices glGetUniformIndices;
        
        public void GetUniformIndices(out nint program, out nint uniformCount, nint uniformNames, out nint uniformIndices) =>
            this.glGetUniformIndices.Invoke(out program, out uniformCount, uniformNames, out uniformIndices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveUniformsiv(out nint program, out nint uniformCount, nint uniformIndices, out nint pname, out nint @params);
        private readonly OpenGLGetActiveUniformsiv glGetActiveUniformsiv;
        
        public void GetActiveUniformsiv(out nint program, out nint uniformCount, nint uniformIndices, out nint pname, out nint @params) =>
            this.glGetActiveUniformsiv.Invoke(out program, out uniformCount, uniformIndices, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveUniformName(out nint program, out nint uniformIndex, out nint bufSize, out nint length, out nint uniformName);
        private readonly OpenGLGetActiveUniformName glGetActiveUniformName;
        
        public void GetActiveUniformName(out nint program, out nint uniformIndex, out nint bufSize, out nint length, out nint uniformName) =>
            this.glGetActiveUniformName.Invoke(out program, out uniformIndex, out bufSize, out length, out uniformName);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint OpenGLGetUniformBlockIndex(out nint program, nint uniformBlockName);
        private readonly OpenGLGetUniformBlockIndex glGetUniformBlockIndex;
        
        public uint GetUniformBlockIndex(out nint program, nint uniformBlockName) =>
            this.glGetUniformBlockIndex.Invoke(out program, uniformBlockName);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveUniformBlockiv(out nint program, out nint uniformBlockIndex, out nint pname, out nint @params);
        private readonly OpenGLGetActiveUniformBlockiv glGetActiveUniformBlockiv;
        
        public void GetActiveUniformBlockiv(out nint program, out nint uniformBlockIndex, out nint pname, out nint @params) =>
            this.glGetActiveUniformBlockiv.Invoke(out program, out uniformBlockIndex, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetActiveUniformBlockName(out nint program, out nint uniformBlockIndex, out nint bufSize, out nint length, out nint uniformBlockName);
        private readonly OpenGLGetActiveUniformBlockName glGetActiveUniformBlockName;
        
        public void GetActiveUniformBlockName(out nint program, out nint uniformBlockIndex, out nint bufSize, out nint length, out nint uniformBlockName) =>
            this.glGetActiveUniformBlockName.Invoke(out program, out uniformBlockIndex, out bufSize, out length, out uniformBlockName);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLUniformBlockBinding(out nint program, out nint uniformBlockIndex, out nint uniformBlockBinding);
        private readonly OpenGLUniformBlockBinding glUniformBlockBinding;
        
        public void UniformBlockBinding(out nint program, out nint uniformBlockIndex, out nint uniformBlockBinding) =>
            this.glUniformBlockBinding.Invoke(out program, out uniformBlockIndex, out uniformBlockBinding);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawElementsBaseVertex(out nint mode, out nint count, out nint type, nint indices, out nint basevertex);
        private readonly OpenGLDrawElementsBaseVertex glDrawElementsBaseVertex;
        
        public void DrawElementsBaseVertex(out nint mode, out nint count, out nint type, nint indices, out nint basevertex) =>
            this.glDrawElementsBaseVertex.Invoke(out mode, out count, out type, indices, out basevertex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawRangeElementsBaseVertex(out nint mode, out nint start, out nint end, out nint count, out nint type, nint indices, out nint basevertex);
        private readonly OpenGLDrawRangeElementsBaseVertex glDrawRangeElementsBaseVertex;
        
        public void DrawRangeElementsBaseVertex(out nint mode, out nint start, out nint end, out nint count, out nint type, nint indices, out nint basevertex) =>
            this.glDrawRangeElementsBaseVertex.Invoke(out mode, out start, out end, out count, out type, indices, out basevertex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDrawElementsInstancedBaseVertex(out nint mode, out nint count, out nint type, nint indices, out nint instancecount, out nint basevertex);
        private readonly OpenGLDrawElementsInstancedBaseVertex glDrawElementsInstancedBaseVertex;
        
        public void DrawElementsInstancedBaseVertex(out nint mode, out nint count, out nint type, nint indices, out nint instancecount, out nint basevertex) =>
            this.glDrawElementsInstancedBaseVertex.Invoke(out mode, out count, out type, indices, out instancecount, out basevertex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLMultiDrawElementsBaseVertex(out nint mode, nint count, out nint type, nint indices, out nint drawcount, nint basevertex);
        private readonly OpenGLMultiDrawElementsBaseVertex glMultiDrawElementsBaseVertex;
        
        public void MultiDrawElementsBaseVertex(out nint mode, nint count, out nint type, nint indices, out nint drawcount, nint basevertex) =>
            this.glMultiDrawElementsBaseVertex.Invoke(out mode, count, out type, indices, out drawcount, basevertex);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLProvokingVertex(out nint mode);
        private readonly OpenGLProvokingVertex glProvokingVertex;
        
        public void ProvokingVertex(out nint mode) =>
            this.glProvokingVertex.Invoke(out mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint OpenGLFenceSync(out nint condition, out nint flags);
        private readonly OpenGLFenceSync glFenceSync;
        
        public nint FenceSync(out nint condition, out nint flags) =>
            this.glFenceSync.Invoke(out condition, out flags);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool OpenGLIsSync(out nint sync);
        private readonly OpenGLIsSync glIsSync;
        
        public bool IsSync(out nint sync) =>
            this.glIsSync.Invoke(out sync);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLDeleteSync(out nint sync);
        private readonly OpenGLDeleteSync glDeleteSync;
        
        public void DeleteSync(out nint sync) =>
            this.glDeleteSync.Invoke(out sync);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SyncStatus OpenGLClientWaitSync(out nint sync, out nint flags, out nint timeout);
        private readonly OpenGLClientWaitSync glClientWaitSync;
        
        public SyncStatus ClientWaitSync(out nint sync, out nint flags, out nint timeout) =>
            this.glClientWaitSync.Invoke(out sync, out flags, out timeout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLWaitSync(out nint sync, out nint flags, out nint timeout);
        private readonly OpenGLWaitSync glWaitSync;
        
        public void WaitSync(out nint sync, out nint flags, out nint timeout) =>
            this.glWaitSync.Invoke(out sync, out flags, out timeout);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetInteger64v(out nint pname, out nint data);
        private readonly OpenGLGetInteger64v glGetInteger64v;
        
        public void GetInteger64v(out nint pname, out nint data) =>
            this.glGetInteger64v.Invoke(out pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetSynciv(out nint sync, out nint pname, out nint count, out nint length, out nint values);
        private readonly OpenGLGetSynciv glGetSynciv;
        
        public void GetSynciv(out nint sync, out nint pname, out nint count, out nint length, out nint values) =>
            this.glGetSynciv.Invoke(out sync, out pname, out count, out length, out values);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetInteger64i_v(out nint target, out nint index, out nint data);
        private readonly OpenGLGetInteger64i_v glGetInteger64i_v;
        
        public void GetInteger64i_v(out nint target, out nint index, out nint data) =>
            this.glGetInteger64i_v.Invoke(out target, out index, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetBufferParameteri64v(out nint target, out nint pname, out nint @params);
        private readonly OpenGLGetBufferParameteri64v glGetBufferParameteri64v;
        
        public void GetBufferParameteri64v(out nint target, out nint pname, out nint @params) =>
            this.glGetBufferParameteri64v.Invoke(out target, out pname, out @params);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLFramebufferTexture(out nint target, out nint attachment, out nint texture, out nint level);
        private readonly OpenGLFramebufferTexture glFramebufferTexture;
        
        public void FramebufferTexture(out nint target, out nint attachment, out nint texture, out nint level) =>
            this.glFramebufferTexture.Invoke(out target, out attachment, out texture, out level);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexImage2DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint fixedsamplelocations);
        private readonly OpenGLTexImage2DMultisample glTexImage2DMultisample;
        
        public void TexImage2DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint fixedsamplelocations) =>
            this.glTexImage2DMultisample.Invoke(out target, out samples, out internalformat, out width, out height, out fixedsamplelocations);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLTexImage3DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint depth, out nint fixedsamplelocations);
        private readonly OpenGLTexImage3DMultisample glTexImage3DMultisample;
        
        public void TexImage3DMultisample(out nint target, out nint samples, out nint internalformat, out nint width, out nint height, out nint depth, out nint fixedsamplelocations) =>
            this.glTexImage3DMultisample.Invoke(out target, out samples, out internalformat, out width, out height, out depth, out fixedsamplelocations);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLGetMultisamplefv(out nint pname, out nint index, out nint val);
        private readonly OpenGLGetMultisamplefv glGetMultisamplefv;
        
        public void GetMultisamplefv(out nint pname, out nint index, out nint val) =>
            this.glGetMultisamplefv.Invoke(out pname, out index, out val);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void OpenGLSampleMaski(out nint maskNumber, out nint mask);
        private readonly OpenGLSampleMaski glSampleMaski;
        
        public void SampleMaski(out nint maskNumber, out nint mask) =>
            this.glSampleMaski.Invoke(out maskNumber, out mask);
        
        public OpenGL(GetProcAddressHandler loader)
        {
            glCullFace = Marshal.GetDelegateForFunctionPointer<OpenGLCullFace>(loader.Invoke("glCullFace"));
            glFrontFace = Marshal.GetDelegateForFunctionPointer<OpenGLFrontFace>(loader.Invoke("glFrontFace"));
            glHint = Marshal.GetDelegateForFunctionPointer<OpenGLHint>(loader.Invoke("glHint"));
            glLineWidth = Marshal.GetDelegateForFunctionPointer<OpenGLLineWidth>(loader.Invoke("glLineWidth"));
            glPointSize = Marshal.GetDelegateForFunctionPointer<OpenGLPointSize>(loader.Invoke("glPointSize"));
            glPolygonMode = Marshal.GetDelegateForFunctionPointer<OpenGLPolygonMode>(loader.Invoke("glPolygonMode"));
            glScissor = Marshal.GetDelegateForFunctionPointer<OpenGLScissor>(loader.Invoke("glScissor"));
            glTexParameterf = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameterf>(loader.Invoke("glTexParameterf"));
            glTexParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameterfv>(loader.Invoke("glTexParameterfv"));
            glTexParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameteri>(loader.Invoke("glTexParameteri"));
            glTexParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameteriv>(loader.Invoke("glTexParameteriv"));
            glTexImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLTexImage1D>(loader.Invoke("glTexImage1D"));
            glTexImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLTexImage2D>(loader.Invoke("glTexImage2D"));
            glDrawBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLDrawBuffer>(loader.Invoke("glDrawBuffer"));
            glClear = Marshal.GetDelegateForFunctionPointer<OpenGLClear>(loader.Invoke("glClear"));
            glClearColor = Marshal.GetDelegateForFunctionPointer<OpenGLClearColor>(loader.Invoke("glClearColor"));
            glClearStencil = Marshal.GetDelegateForFunctionPointer<OpenGLClearStencil>(loader.Invoke("glClearStencil"));
            glClearDepth = Marshal.GetDelegateForFunctionPointer<OpenGLClearDepth>(loader.Invoke("glClearDepth"));
            glStencilMask = Marshal.GetDelegateForFunctionPointer<OpenGLStencilMask>(loader.Invoke("glStencilMask"));
            glColorMask = Marshal.GetDelegateForFunctionPointer<OpenGLColorMask>(loader.Invoke("glColorMask"));
            glDepthMask = Marshal.GetDelegateForFunctionPointer<OpenGLDepthMask>(loader.Invoke("glDepthMask"));
            glDisable = Marshal.GetDelegateForFunctionPointer<OpenGLDisable>(loader.Invoke("glDisable"));
            glEnable = Marshal.GetDelegateForFunctionPointer<OpenGLEnable>(loader.Invoke("glEnable"));
            glFinish = Marshal.GetDelegateForFunctionPointer<OpenGLFinish>(loader.Invoke("glFinish"));
            glFlush = Marshal.GetDelegateForFunctionPointer<OpenGLFlush>(loader.Invoke("glFlush"));
            glBlendFunc = Marshal.GetDelegateForFunctionPointer<OpenGLBlendFunc>(loader.Invoke("glBlendFunc"));
            glLogicOp = Marshal.GetDelegateForFunctionPointer<OpenGLLogicOp>(loader.Invoke("glLogicOp"));
            glStencilFunc = Marshal.GetDelegateForFunctionPointer<OpenGLStencilFunc>(loader.Invoke("glStencilFunc"));
            glStencilOp = Marshal.GetDelegateForFunctionPointer<OpenGLStencilOp>(loader.Invoke("glStencilOp"));
            glDepthFunc = Marshal.GetDelegateForFunctionPointer<OpenGLDepthFunc>(loader.Invoke("glDepthFunc"));
            glPixelStoref = Marshal.GetDelegateForFunctionPointer<OpenGLPixelStoref>(loader.Invoke("glPixelStoref"));
            glPixelStorei = Marshal.GetDelegateForFunctionPointer<OpenGLPixelStorei>(loader.Invoke("glPixelStorei"));
            glReadBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLReadBuffer>(loader.Invoke("glReadBuffer"));
            glReadPixels = Marshal.GetDelegateForFunctionPointer<OpenGLReadPixels>(loader.Invoke("glReadPixels"));
            glGetBooleanv = Marshal.GetDelegateForFunctionPointer<OpenGLGetBooleanv>(loader.Invoke("glGetBooleanv"));
            glGetDoublev = Marshal.GetDelegateForFunctionPointer<OpenGLGetDoublev>(loader.Invoke("glGetDoublev"));
            glGetError = Marshal.GetDelegateForFunctionPointer<OpenGLGetError>(loader.Invoke("glGetError"));
            glGetFloatv = Marshal.GetDelegateForFunctionPointer<OpenGLGetFloatv>(loader.Invoke("glGetFloatv"));
            glGetIntegerv = Marshal.GetDelegateForFunctionPointer<OpenGLGetIntegerv>(loader.Invoke("glGetIntegerv"));
            glGetString = Marshal.GetDelegateForFunctionPointer<OpenGLGetString>(loader.Invoke("glGetString"));
            glGetTexImage = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexImage>(loader.Invoke("glGetTexImage"));
            glGetTexParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexParameterfv>(loader.Invoke("glGetTexParameterfv"));
            glGetTexParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexParameteriv>(loader.Invoke("glGetTexParameteriv"));
            glGetTexLevelParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexLevelParameterfv>(loader.Invoke("glGetTexLevelParameterfv"));
            glGetTexLevelParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexLevelParameteriv>(loader.Invoke("glGetTexLevelParameteriv"));
            glIsEnabled = Marshal.GetDelegateForFunctionPointer<OpenGLIsEnabled>(loader.Invoke("glIsEnabled"));
            glDepthRange = Marshal.GetDelegateForFunctionPointer<OpenGLDepthRange>(loader.Invoke("glDepthRange"));
            glViewport = Marshal.GetDelegateForFunctionPointer<OpenGLViewport>(loader.Invoke("glViewport"));
            glTexStorage3DMultisample = Marshal.GetDelegateForFunctionPointer<OpenGLTexStorage3DMultisample>(loader.Invoke("glTexStorage3DMultisample"));
            glTexBufferRange = Marshal.GetDelegateForFunctionPointer<OpenGLTexBufferRange>(loader.Invoke("glTexBufferRange"));
            glPatchParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLPatchParameteri>(loader.Invoke("glPatchParameteri"));
            glMinSampleShading = Marshal.GetDelegateForFunctionPointer<OpenGLMinSampleShading>(loader.Invoke("glMinSampleShading"));
            glPrimitiveBoundingBox = Marshal.GetDelegateForFunctionPointer<OpenGLPrimitiveBoundingBox>(loader.Invoke("glPrimitiveBoundingBox"));
            glBlendFuncSeparatei = Marshal.GetDelegateForFunctionPointer<OpenGLBlendFuncSeparatei>(loader.Invoke("glBlendFuncSeparatei"));
            glBlendFunci = Marshal.GetDelegateForFunctionPointer<OpenGLBlendFunci>(loader.Invoke("glBlendFunci"));
            glBlendEquationSeparatei = Marshal.GetDelegateForFunctionPointer<OpenGLBlendEquationSeparatei>(loader.Invoke("glBlendEquationSeparatei"));
            glBlendEquationi = Marshal.GetDelegateForFunctionPointer<OpenGLBlendEquationi>(loader.Invoke("glBlendEquationi"));
            glCopyImageSubData = Marshal.GetDelegateForFunctionPointer<OpenGLCopyImageSubData>(loader.Invoke("glCopyImageSubData"));
            glBlendBarrier = Marshal.GetDelegateForFunctionPointer<OpenGLBlendBarrier>(loader.Invoke("glBlendBarrier"));
            glVertexBindingDivisor = Marshal.GetDelegateForFunctionPointer<OpenGLVertexBindingDivisor>(loader.Invoke("glVertexBindingDivisor"));
            glVertexAttribBinding = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribBinding>(loader.Invoke("glVertexAttribBinding"));
            glVertexAttribIFormat = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribIFormat>(loader.Invoke("glVertexAttribIFormat"));
            glVertexAttribFormat = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribFormat>(loader.Invoke("glVertexAttribFormat"));
            glBindVertexBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLBindVertexBuffer>(loader.Invoke("glBindVertexBuffer"));
            glTexStorage2DMultisample = Marshal.GetDelegateForFunctionPointer<OpenGLTexStorage2DMultisample>(loader.Invoke("glTexStorage2DMultisample"));
            glMemoryBarrierByRegion = Marshal.GetDelegateForFunctionPointer<OpenGLMemoryBarrierByRegion>(loader.Invoke("glMemoryBarrierByRegion"));
            glMemoryBarrier = Marshal.GetDelegateForFunctionPointer<OpenGLMemoryBarrier>(loader.Invoke("glMemoryBarrier"));
            glBindImageTexture = Marshal.GetDelegateForFunctionPointer<OpenGLBindImageTexture>(loader.Invoke("glBindImageTexture"));
            glGetProgramPipelineInfoLog = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramPipelineInfoLog>(loader.Invoke("glGetProgramPipelineInfoLog"));
            glValidateProgramPipeline = Marshal.GetDelegateForFunctionPointer<OpenGLValidateProgramPipeline>(loader.Invoke("glValidateProgramPipeline"));
            glProgramUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix4x3fv>(loader.Invoke("glProgramUniformMatrix4x3fv"));
            glProgramUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix3x4fv>(loader.Invoke("glProgramUniformMatrix3x4fv"));
            glProgramUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix4x2fv>(loader.Invoke("glProgramUniformMatrix4x2fv"));
            glProgramUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix2x4fv>(loader.Invoke("glProgramUniformMatrix2x4fv"));
            glProgramUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix3x2fv>(loader.Invoke("glProgramUniformMatrix3x2fv"));
            glProgramUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix2x3fv>(loader.Invoke("glProgramUniformMatrix2x3fv"));
            glProgramUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix4fv>(loader.Invoke("glProgramUniformMatrix4fv"));
            glProgramUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix3fv>(loader.Invoke("glProgramUniformMatrix3fv"));
            glBlendBarrierKHR = Marshal.GetDelegateForFunctionPointer<OpenGLBlendBarrierKHR>(loader.Invoke("glBlendBarrierKHR"));
            glDebugMessageControl = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageControl>(loader.Invoke("glDebugMessageControl"));
            glDebugMessageInsert = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageInsert>(loader.Invoke("glDebugMessageInsert"));
            glDebugMessageCallback = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageCallback>(loader.Invoke("glDebugMessageCallback"));
            glGetDebugMessageLog = Marshal.GetDelegateForFunctionPointer<OpenGLGetDebugMessageLog>(loader.Invoke("glGetDebugMessageLog"));
            glPushDebugGroup = Marshal.GetDelegateForFunctionPointer<OpenGLPushDebugGroup>(loader.Invoke("glPushDebugGroup"));
            glPopDebugGroup = Marshal.GetDelegateForFunctionPointer<OpenGLPopDebugGroup>(loader.Invoke("glPopDebugGroup"));
            glObjectLabel = Marshal.GetDelegateForFunctionPointer<OpenGLObjectLabel>(loader.Invoke("glObjectLabel"));
            glGetObjectLabel = Marshal.GetDelegateForFunctionPointer<OpenGLGetObjectLabel>(loader.Invoke("glGetObjectLabel"));
            glObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<OpenGLObjectPtrLabel>(loader.Invoke("glObjectPtrLabel"));
            glGetObjectPtrLabel = Marshal.GetDelegateForFunctionPointer<OpenGLGetObjectPtrLabel>(loader.Invoke("glGetObjectPtrLabel"));
            glProgramUniform3uiv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3uiv>(loader.Invoke("glProgramUniform3uiv"));
            glDebugMessageControlKHR = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageControlKHR>(loader.Invoke("glDebugMessageControlKHR"));
            glDebugMessageInsertKHR = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageInsertKHR>(loader.Invoke("glDebugMessageInsertKHR"));
            glDebugMessageCallbackKHR = Marshal.GetDelegateForFunctionPointer<OpenGLDebugMessageCallbackKHR>(loader.Invoke("glDebugMessageCallbackKHR"));
            glGetDebugMessageLogKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetDebugMessageLogKHR>(loader.Invoke("glGetDebugMessageLogKHR"));
            glPushDebugGroupKHR = Marshal.GetDelegateForFunctionPointer<OpenGLPushDebugGroupKHR>(loader.Invoke("glPushDebugGroupKHR"));
            glPopDebugGroupKHR = Marshal.GetDelegateForFunctionPointer<OpenGLPopDebugGroupKHR>(loader.Invoke("glPopDebugGroupKHR"));
            glObjectLabelKHR = Marshal.GetDelegateForFunctionPointer<OpenGLObjectLabelKHR>(loader.Invoke("glObjectLabelKHR"));
            glGetObjectLabelKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetObjectLabelKHR>(loader.Invoke("glGetObjectLabelKHR"));
            glObjectPtrLabelKHR = Marshal.GetDelegateForFunctionPointer<OpenGLObjectPtrLabelKHR>(loader.Invoke("glObjectPtrLabelKHR"));
            glGetObjectPtrLabelKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetObjectPtrLabelKHR>(loader.Invoke("glGetObjectPtrLabelKHR"));
            glGetPointervKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetPointervKHR>(loader.Invoke("glGetPointervKHR"));
            glGetGraphicsResetStatus = Marshal.GetDelegateForFunctionPointer<OpenGLGetGraphicsResetStatus>(loader.Invoke("glGetGraphicsResetStatus"));
            glReadnPixels = Marshal.GetDelegateForFunctionPointer<OpenGLReadnPixels>(loader.Invoke("glReadnPixels"));
            glGetnUniformfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformfv>(loader.Invoke("glGetnUniformfv"));
            glGetnUniformiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformiv>(loader.Invoke("glGetnUniformiv"));
            glGetnUniformuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformuiv>(loader.Invoke("glGetnUniformuiv"));
            glGetGraphicsResetStatusKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetGraphicsResetStatusKHR>(loader.Invoke("glGetGraphicsResetStatusKHR"));
            glReadnPixelsKHR = Marshal.GetDelegateForFunctionPointer<OpenGLReadnPixelsKHR>(loader.Invoke("glReadnPixelsKHR"));
            glGetnUniformfvKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformfvKHR>(loader.Invoke("glGetnUniformfvKHR"));
            glGetnUniformivKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformivKHR>(loader.Invoke("glGetnUniformivKHR"));
            glGetnUniformuivKHR = Marshal.GetDelegateForFunctionPointer<OpenGLGetnUniformuivKHR>(loader.Invoke("glGetnUniformuivKHR"));
            glMaxShaderCompilerThreadsKHR = Marshal.GetDelegateForFunctionPointer<OpenGLMaxShaderCompilerThreadsKHR>(loader.Invoke("glMaxShaderCompilerThreadsKHR"));
            glFramebufferTextureMultiviewOVR = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTextureMultiviewOVR>(loader.Invoke("glFramebufferTextureMultiviewOVR"));
            glFramebufferTextureMultisampleMultiviewOVR = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTextureMultisampleMultiviewOVR>(loader.Invoke("glFramebufferTextureMultisampleMultiviewOVR"));
            glDrawArrays = Marshal.GetDelegateForFunctionPointer<OpenGLDrawArrays>(loader.Invoke("glDrawArrays"));
            glDrawElements = Marshal.GetDelegateForFunctionPointer<OpenGLDrawElements>(loader.Invoke("glDrawElements"));
            glPolygonOffset = Marshal.GetDelegateForFunctionPointer<OpenGLPolygonOffset>(loader.Invoke("glPolygonOffset"));
            glCopyTexImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLCopyTexImage1D>(loader.Invoke("glCopyTexImage1D"));
            glCopyTexImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLCopyTexImage2D>(loader.Invoke("glCopyTexImage2D"));
            glCopyTexSubImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLCopyTexSubImage1D>(loader.Invoke("glCopyTexSubImage1D"));
            glCopyTexSubImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLCopyTexSubImage2D>(loader.Invoke("glCopyTexSubImage2D"));
            glTexSubImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLTexSubImage1D>(loader.Invoke("glTexSubImage1D"));
            glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLTexSubImage2D>(loader.Invoke("glTexSubImage2D"));
            glBindTexture = Marshal.GetDelegateForFunctionPointer<OpenGLBindTexture>(loader.Invoke("glBindTexture"));
            glDeleteTextures = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteTextures>(loader.Invoke("glDeleteTextures"));
            glGenTextures = Marshal.GetDelegateForFunctionPointer<OpenGLGenTextures>(loader.Invoke("glGenTextures"));
            glIsTexture = Marshal.GetDelegateForFunctionPointer<OpenGLIsTexture>(loader.Invoke("glIsTexture"));
            glProgramUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniformMatrix2fv>(loader.Invoke("glProgramUniformMatrix2fv"));
            glProgramUniform4fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4fv>(loader.Invoke("glProgramUniform4fv"));
            glProgramUniform3fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3fv>(loader.Invoke("glProgramUniform3fv"));
            glProgramUniform2fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2fv>(loader.Invoke("glProgramUniform2fv"));
            glProgramUniform1fv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1fv>(loader.Invoke("glProgramUniform1fv"));
            glProgramUniform4uiv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4uiv>(loader.Invoke("glProgramUniform4uiv"));
            glProgramUniform2uiv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2uiv>(loader.Invoke("glProgramUniform2uiv"));
            glProgramUniform1uiv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1uiv>(loader.Invoke("glProgramUniform1uiv"));
            glProgramUniform4iv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4iv>(loader.Invoke("glProgramUniform4iv"));
            glProgramUniform3iv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3iv>(loader.Invoke("glProgramUniform3iv"));
            glProgramUniform2iv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2iv>(loader.Invoke("glProgramUniform2iv"));
            glProgramUniform1iv = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1iv>(loader.Invoke("glProgramUniform1iv"));
            glProgramUniform4f = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4f>(loader.Invoke("glProgramUniform4f"));
            glProgramUniform3f = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3f>(loader.Invoke("glProgramUniform3f"));
            glProgramUniform2f = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2f>(loader.Invoke("glProgramUniform2f"));
            glProgramUniform1f = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1f>(loader.Invoke("glProgramUniform1f"));
            glDrawRangeElements = Marshal.GetDelegateForFunctionPointer<OpenGLDrawRangeElements>(loader.Invoke("glDrawRangeElements"));
            glTexImage3D = Marshal.GetDelegateForFunctionPointer<OpenGLTexImage3D>(loader.Invoke("glTexImage3D"));
            glTexSubImage3D = Marshal.GetDelegateForFunctionPointer<OpenGLTexSubImage3D>(loader.Invoke("glTexSubImage3D"));
            glCopyTexSubImage3D = Marshal.GetDelegateForFunctionPointer<OpenGLCopyTexSubImage3D>(loader.Invoke("glCopyTexSubImage3D"));
            glActiveTexture = Marshal.GetDelegateForFunctionPointer<OpenGLActiveTexture>(loader.Invoke("glActiveTexture"));
            glSampleCoverage = Marshal.GetDelegateForFunctionPointer<OpenGLSampleCoverage>(loader.Invoke("glSampleCoverage"));
            glCompressedTexImage3D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexImage3D>(loader.Invoke("glCompressedTexImage3D"));
            glCompressedTexImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexImage2D>(loader.Invoke("glCompressedTexImage2D"));
            glCompressedTexImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexImage1D>(loader.Invoke("glCompressedTexImage1D"));
            glCompressedTexSubImage3D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexSubImage3D>(loader.Invoke("glCompressedTexSubImage3D"));
            glCompressedTexSubImage2D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexSubImage2D>(loader.Invoke("glCompressedTexSubImage2D"));
            glCompressedTexSubImage1D = Marshal.GetDelegateForFunctionPointer<OpenGLCompressedTexSubImage1D>(loader.Invoke("glCompressedTexSubImage1D"));
            glGetCompressedTexImage = Marshal.GetDelegateForFunctionPointer<OpenGLGetCompressedTexImage>(loader.Invoke("glGetCompressedTexImage"));
            glProgramUniform4ui = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4ui>(loader.Invoke("glProgramUniform4ui"));
            glProgramUniform3ui = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3ui>(loader.Invoke("glProgramUniform3ui"));
            glProgramUniform2ui = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2ui>(loader.Invoke("glProgramUniform2ui"));
            glProgramUniform1ui = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1ui>(loader.Invoke("glProgramUniform1ui"));
            glProgramUniform4i = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform4i>(loader.Invoke("glProgramUniform4i"));
            glProgramUniform3i = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform3i>(loader.Invoke("glProgramUniform3i"));
            glProgramUniform2i = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform2i>(loader.Invoke("glProgramUniform2i"));
            glProgramUniform1i = Marshal.GetDelegateForFunctionPointer<OpenGLProgramUniform1i>(loader.Invoke("glProgramUniform1i"));
            glGetProgramPipelineiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramPipelineiv>(loader.Invoke("glGetProgramPipelineiv"));
            glIsProgramPipeline = Marshal.GetDelegateForFunctionPointer<OpenGLIsProgramPipeline>(loader.Invoke("glIsProgramPipeline"));
            glGenProgramPipelines = Marshal.GetDelegateForFunctionPointer<OpenGLGenProgramPipelines>(loader.Invoke("glGenProgramPipelines"));
            glDeleteProgramPipelines = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteProgramPipelines>(loader.Invoke("glDeleteProgramPipelines"));
            glBindProgramPipeline = Marshal.GetDelegateForFunctionPointer<OpenGLBindProgramPipeline>(loader.Invoke("glBindProgramPipeline"));
            glCreateShaderProgramv = Marshal.GetDelegateForFunctionPointer<OpenGLCreateShaderProgramv>(loader.Invoke("glCreateShaderProgramv"));
            glActiveShaderProgram = Marshal.GetDelegateForFunctionPointer<OpenGLActiveShaderProgram>(loader.Invoke("glActiveShaderProgram"));
            glUseProgramStages = Marshal.GetDelegateForFunctionPointer<OpenGLUseProgramStages>(loader.Invoke("glUseProgramStages"));
            glGetProgramResourceLocation = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramResourceLocation>(loader.Invoke("glGetProgramResourceLocation"));
            glGetProgramResourceiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramResourceiv>(loader.Invoke("glGetProgramResourceiv"));
            glGetProgramResourceName = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramResourceName>(loader.Invoke("glGetProgramResourceName"));
            glGetProgramResourceIndex = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramResourceIndex>(loader.Invoke("glGetProgramResourceIndex"));
            glGetProgramInterfaceiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramInterfaceiv>(loader.Invoke("glGetProgramInterfaceiv"));
            glGetFramebufferParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetFramebufferParameteriv>(loader.Invoke("glGetFramebufferParameteriv"));
            glFramebufferParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferParameteri>(loader.Invoke("glFramebufferParameteri"));
            glDrawElementsIndirect = Marshal.GetDelegateForFunctionPointer<OpenGLDrawElementsIndirect>(loader.Invoke("glDrawElementsIndirect"));
            glDrawArraysIndirect = Marshal.GetDelegateForFunctionPointer<OpenGLDrawArraysIndirect>(loader.Invoke("glDrawArraysIndirect"));
            glDispatchComputeIndirect = Marshal.GetDelegateForFunctionPointer<OpenGLDispatchComputeIndirect>(loader.Invoke("glDispatchComputeIndirect"));
            glDispatchCompute = Marshal.GetDelegateForFunctionPointer<OpenGLDispatchCompute>(loader.Invoke("glDispatchCompute"));
            glGetInternalformativ = Marshal.GetDelegateForFunctionPointer<OpenGLGetInternalformativ>(loader.Invoke("glGetInternalformativ"));
            glTexStorage3D = Marshal.GetDelegateForFunctionPointer<OpenGLTexStorage3D>(loader.Invoke("glTexStorage3D"));
            glTexStorage2D = Marshal.GetDelegateForFunctionPointer<OpenGLTexStorage2D>(loader.Invoke("glTexStorage2D"));
            glInvalidateSubFramebuffer = Marshal.GetDelegateForFunctionPointer<OpenGLInvalidateSubFramebuffer>(loader.Invoke("glInvalidateSubFramebuffer"));
            glInvalidateFramebuffer = Marshal.GetDelegateForFunctionPointer<OpenGLInvalidateFramebuffer>(loader.Invoke("glInvalidateFramebuffer"));
            glProgramParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLProgramParameteri>(loader.Invoke("glProgramParameteri"));
            glProgramBinary = Marshal.GetDelegateForFunctionPointer<OpenGLProgramBinary>(loader.Invoke("glProgramBinary"));
            glGetProgramBinary = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramBinary>(loader.Invoke("glGetProgramBinary"));
            glResumeTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLResumeTransformFeedback>(loader.Invoke("glResumeTransformFeedback"));
            glPauseTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLPauseTransformFeedback>(loader.Invoke("glPauseTransformFeedback"));
            glBlendFuncSeparate = Marshal.GetDelegateForFunctionPointer<OpenGLBlendFuncSeparate>(loader.Invoke("glBlendFuncSeparate"));
            glMultiDrawArrays = Marshal.GetDelegateForFunctionPointer<OpenGLMultiDrawArrays>(loader.Invoke("glMultiDrawArrays"));
            glMultiDrawElements = Marshal.GetDelegateForFunctionPointer<OpenGLMultiDrawElements>(loader.Invoke("glMultiDrawElements"));
            glPointParameterf = Marshal.GetDelegateForFunctionPointer<OpenGLPointParameterf>(loader.Invoke("glPointParameterf"));
            glPointParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLPointParameterfv>(loader.Invoke("glPointParameterfv"));
            glPointParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLPointParameteri>(loader.Invoke("glPointParameteri"));
            glPointParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLPointParameteriv>(loader.Invoke("glPointParameteriv"));
            glIsTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLIsTransformFeedback>(loader.Invoke("glIsTransformFeedback"));
            glGenTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<OpenGLGenTransformFeedbacks>(loader.Invoke("glGenTransformFeedbacks"));
            glDeleteTransformFeedbacks = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteTransformFeedbacks>(loader.Invoke("glDeleteTransformFeedbacks"));
            glBindTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLBindTransformFeedback>(loader.Invoke("glBindTransformFeedback"));
            glShaderBinary = Marshal.GetDelegateForFunctionPointer<OpenGLShaderBinary>(loader.Invoke("glShaderBinary"));
            glReleaseShaderCompiler = Marshal.GetDelegateForFunctionPointer<OpenGLReleaseShaderCompiler>(loader.Invoke("glReleaseShaderCompiler"));
            glGetShaderPrecisionFormat = Marshal.GetDelegateForFunctionPointer<OpenGLGetShaderPrecisionFormat>(loader.Invoke("glGetShaderPrecisionFormat"));
            glDepthRangef = Marshal.GetDelegateForFunctionPointer<OpenGLDepthRangef>(loader.Invoke("glDepthRangef"));
            glClearDepthf = Marshal.GetDelegateForFunctionPointer<OpenGLClearDepthf>(loader.Invoke("glClearDepthf"));
            glVertexAttribP4uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP4uiv>(loader.Invoke("glVertexAttribP4uiv"));
            glVertexAttribP4ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP4ui>(loader.Invoke("glVertexAttribP4ui"));
            glVertexAttribP3uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP3uiv>(loader.Invoke("glVertexAttribP3uiv"));
            glVertexAttribP3ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP3ui>(loader.Invoke("glVertexAttribP3ui"));
            glVertexAttribP2uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP2uiv>(loader.Invoke("glVertexAttribP2uiv"));
            glVertexAttribP2ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP2ui>(loader.Invoke("glVertexAttribP2ui"));
            glVertexAttribP1uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP1uiv>(loader.Invoke("glVertexAttribP1uiv"));
            glVertexAttribP1ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribP1ui>(loader.Invoke("glVertexAttribP1ui"));
            glVertexAttribDivisor = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribDivisor>(loader.Invoke("glVertexAttribDivisor"));
            glGetQueryObjectui64v = Marshal.GetDelegateForFunctionPointer<OpenGLGetQueryObjectui64v>(loader.Invoke("glGetQueryObjectui64v"));
            glGetQueryObjecti64v = Marshal.GetDelegateForFunctionPointer<OpenGLGetQueryObjecti64v>(loader.Invoke("glGetQueryObjecti64v"));
            glQueryCounter = Marshal.GetDelegateForFunctionPointer<OpenGLQueryCounter>(loader.Invoke("glQueryCounter"));
            glGetSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetSamplerParameterIuiv>(loader.Invoke("glGetSamplerParameterIuiv"));
            glGetSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetSamplerParameterfv>(loader.Invoke("glGetSamplerParameterfv"));
            glGetSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetSamplerParameterIiv>(loader.Invoke("glGetSamplerParameterIiv"));
            glGetSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetSamplerParameteriv>(loader.Invoke("glGetSamplerParameteriv"));
            glSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameterIuiv>(loader.Invoke("glSamplerParameterIuiv"));
            glSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameterIiv>(loader.Invoke("glSamplerParameterIiv"));
            glSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameterfv>(loader.Invoke("glSamplerParameterfv"));
            glSamplerParameterf = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameterf>(loader.Invoke("glSamplerParameterf"));
            glSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameteriv>(loader.Invoke("glSamplerParameteriv"));
            glSamplerParameteri = Marshal.GetDelegateForFunctionPointer<OpenGLSamplerParameteri>(loader.Invoke("glSamplerParameteri"));
            glBindSampler = Marshal.GetDelegateForFunctionPointer<OpenGLBindSampler>(loader.Invoke("glBindSampler"));
            glIsSampler = Marshal.GetDelegateForFunctionPointer<OpenGLIsSampler>(loader.Invoke("glIsSampler"));
            glDeleteSamplers = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteSamplers>(loader.Invoke("glDeleteSamplers"));
            glGenSamplers = Marshal.GetDelegateForFunctionPointer<OpenGLGenSamplers>(loader.Invoke("glGenSamplers"));
            glGetFragDataIndex = Marshal.GetDelegateForFunctionPointer<OpenGLGetFragDataIndex>(loader.Invoke("glGetFragDataIndex"));
            glBindFragDataLocationIndexed = Marshal.GetDelegateForFunctionPointer<OpenGLBindFragDataLocationIndexed>(loader.Invoke("glBindFragDataLocationIndexed"));
            glGetPointerv = Marshal.GetDelegateForFunctionPointer<OpenGLGetPointerv>(loader.Invoke("glGetPointerv"));
            glBlendColor = Marshal.GetDelegateForFunctionPointer<OpenGLBlendColor>(loader.Invoke("glBlendColor"));
            glBlendEquation = Marshal.GetDelegateForFunctionPointer<OpenGLBlendEquation>(loader.Invoke("glBlendEquation"));
            glGenQueries = Marshal.GetDelegateForFunctionPointer<OpenGLGenQueries>(loader.Invoke("glGenQueries"));
            glDeleteQueries = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteQueries>(loader.Invoke("glDeleteQueries"));
            glIsQuery = Marshal.GetDelegateForFunctionPointer<OpenGLIsQuery>(loader.Invoke("glIsQuery"));
            glBeginQuery = Marshal.GetDelegateForFunctionPointer<OpenGLBeginQuery>(loader.Invoke("glBeginQuery"));
            glEndQuery = Marshal.GetDelegateForFunctionPointer<OpenGLEndQuery>(loader.Invoke("glEndQuery"));
            glGetQueryiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetQueryiv>(loader.Invoke("glGetQueryiv"));
            glGetQueryObjectiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetQueryObjectiv>(loader.Invoke("glGetQueryObjectiv"));
            glGetQueryObjectuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetQueryObjectuiv>(loader.Invoke("glGetQueryObjectuiv"));
            glBindBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLBindBuffer>(loader.Invoke("glBindBuffer"));
            glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteBuffers>(loader.Invoke("glDeleteBuffers"));
            glGenBuffers = Marshal.GetDelegateForFunctionPointer<OpenGLGenBuffers>(loader.Invoke("glGenBuffers"));
            glIsBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLIsBuffer>(loader.Invoke("glIsBuffer"));
            glBufferData = Marshal.GetDelegateForFunctionPointer<OpenGLBufferData>(loader.Invoke("glBufferData"));
            glBufferSubData = Marshal.GetDelegateForFunctionPointer<OpenGLBufferSubData>(loader.Invoke("glBufferSubData"));
            glGetBufferSubData = Marshal.GetDelegateForFunctionPointer<OpenGLGetBufferSubData>(loader.Invoke("glGetBufferSubData"));
            glMapBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLMapBuffer>(loader.Invoke("glMapBuffer"));
            glUnmapBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLUnmapBuffer>(loader.Invoke("glUnmapBuffer"));
            glGetBufferParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetBufferParameteriv>(loader.Invoke("glGetBufferParameteriv"));
            glGetBufferPointerv = Marshal.GetDelegateForFunctionPointer<OpenGLGetBufferPointerv>(loader.Invoke("glGetBufferPointerv"));
            glBlendEquationSeparate = Marshal.GetDelegateForFunctionPointer<OpenGLBlendEquationSeparate>(loader.Invoke("glBlendEquationSeparate"));
            glDrawBuffers = Marshal.GetDelegateForFunctionPointer<OpenGLDrawBuffers>(loader.Invoke("glDrawBuffers"));
            glStencilOpSeparate = Marshal.GetDelegateForFunctionPointer<OpenGLStencilOpSeparate>(loader.Invoke("glStencilOpSeparate"));
            glStencilFuncSeparate = Marshal.GetDelegateForFunctionPointer<OpenGLStencilFuncSeparate>(loader.Invoke("glStencilFuncSeparate"));
            glStencilMaskSeparate = Marshal.GetDelegateForFunctionPointer<OpenGLStencilMaskSeparate>(loader.Invoke("glStencilMaskSeparate"));
            glAttachShader = Marshal.GetDelegateForFunctionPointer<OpenGLAttachShader>(loader.Invoke("glAttachShader"));
            glBindAttribLocation = Marshal.GetDelegateForFunctionPointer<OpenGLBindAttribLocation>(loader.Invoke("glBindAttribLocation"));
            glCompileShader = Marshal.GetDelegateForFunctionPointer<OpenGLCompileShader>(loader.Invoke("glCompileShader"));
            glCreateProgram = Marshal.GetDelegateForFunctionPointer<OpenGLCreateProgram>(loader.Invoke("glCreateProgram"));
            glCreateShader = Marshal.GetDelegateForFunctionPointer<OpenGLCreateShader>(loader.Invoke("glCreateShader"));
            glDeleteProgram = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteProgram>(loader.Invoke("glDeleteProgram"));
            glDeleteShader = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteShader>(loader.Invoke("glDeleteShader"));
            glDetachShader = Marshal.GetDelegateForFunctionPointer<OpenGLDetachShader>(loader.Invoke("glDetachShader"));
            glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<OpenGLDisableVertexAttribArray>(loader.Invoke("glDisableVertexAttribArray"));
            glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<OpenGLEnableVertexAttribArray>(loader.Invoke("glEnableVertexAttribArray"));
            glGetActiveAttrib = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveAttrib>(loader.Invoke("glGetActiveAttrib"));
            glGetActiveUniform = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveUniform>(loader.Invoke("glGetActiveUniform"));
            glGetAttachedShaders = Marshal.GetDelegateForFunctionPointer<OpenGLGetAttachedShaders>(loader.Invoke("glGetAttachedShaders"));
            glGetAttribLocation = Marshal.GetDelegateForFunctionPointer<OpenGLGetAttribLocation>(loader.Invoke("glGetAttribLocation"));
            glGetProgramiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramiv>(loader.Invoke("glGetProgramiv"));
            glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<OpenGLGetProgramInfoLog>(loader.Invoke("glGetProgramInfoLog"));
            glGetShaderiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetShaderiv>(loader.Invoke("glGetShaderiv"));
            glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<OpenGLGetShaderInfoLog>(loader.Invoke("glGetShaderInfoLog"));
            glGetShaderSource = Marshal.GetDelegateForFunctionPointer<OpenGLGetShaderSource>(loader.Invoke("glGetShaderSource"));
            glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformLocation>(loader.Invoke("glGetUniformLocation"));
            glGetUniformfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformfv>(loader.Invoke("glGetUniformfv"));
            glGetUniformiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformiv>(loader.Invoke("glGetUniformiv"));
            glGetVertexAttribdv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribdv>(loader.Invoke("glGetVertexAttribdv"));
            glGetVertexAttribfv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribfv>(loader.Invoke("glGetVertexAttribfv"));
            glGetVertexAttribiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribiv>(loader.Invoke("glGetVertexAttribiv"));
            glGetVertexAttribPointerv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribPointerv>(loader.Invoke("glGetVertexAttribPointerv"));
            glIsProgram = Marshal.GetDelegateForFunctionPointer<OpenGLIsProgram>(loader.Invoke("glIsProgram"));
            glIsShader = Marshal.GetDelegateForFunctionPointer<OpenGLIsShader>(loader.Invoke("glIsShader"));
            glLinkProgram = Marshal.GetDelegateForFunctionPointer<OpenGLLinkProgram>(loader.Invoke("glLinkProgram"));
            glShaderSource = Marshal.GetDelegateForFunctionPointer<OpenGLShaderSource>(loader.Invoke("glShaderSource"));
            glUseProgram = Marshal.GetDelegateForFunctionPointer<OpenGLUseProgram>(loader.Invoke("glUseProgram"));
            glUniform1f = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1f>(loader.Invoke("glUniform1f"));
            glUniform2f = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2f>(loader.Invoke("glUniform2f"));
            glUniform3f = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3f>(loader.Invoke("glUniform3f"));
            glUniform4f = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4f>(loader.Invoke("glUniform4f"));
            glUniform1i = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1i>(loader.Invoke("glUniform1i"));
            glUniform2i = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2i>(loader.Invoke("glUniform2i"));
            glUniform3i = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3i>(loader.Invoke("glUniform3i"));
            glUniform4i = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4i>(loader.Invoke("glUniform4i"));
            glUniform1fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1fv>(loader.Invoke("glUniform1fv"));
            glUniform2fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2fv>(loader.Invoke("glUniform2fv"));
            glUniform3fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3fv>(loader.Invoke("glUniform3fv"));
            glUniform4fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4fv>(loader.Invoke("glUniform4fv"));
            glUniform1iv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1iv>(loader.Invoke("glUniform1iv"));
            glUniform2iv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2iv>(loader.Invoke("glUniform2iv"));
            glUniform3iv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3iv>(loader.Invoke("glUniform3iv"));
            glUniform4iv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4iv>(loader.Invoke("glUniform4iv"));
            glUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix2fv>(loader.Invoke("glUniformMatrix2fv"));
            glUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix3fv>(loader.Invoke("glUniformMatrix3fv"));
            glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix4fv>(loader.Invoke("glUniformMatrix4fv"));
            glValidateProgram = Marshal.GetDelegateForFunctionPointer<OpenGLValidateProgram>(loader.Invoke("glValidateProgram"));
            glVertexAttrib1d = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1d>(loader.Invoke("glVertexAttrib1d"));
            glVertexAttrib1dv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1dv>(loader.Invoke("glVertexAttrib1dv"));
            glVertexAttrib1f = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1f>(loader.Invoke("glVertexAttrib1f"));
            glVertexAttrib1fv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1fv>(loader.Invoke("glVertexAttrib1fv"));
            glVertexAttrib1s = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1s>(loader.Invoke("glVertexAttrib1s"));
            glVertexAttrib1sv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib1sv>(loader.Invoke("glVertexAttrib1sv"));
            glVertexAttrib2d = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2d>(loader.Invoke("glVertexAttrib2d"));
            glVertexAttrib2dv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2dv>(loader.Invoke("glVertexAttrib2dv"));
            glVertexAttrib2f = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2f>(loader.Invoke("glVertexAttrib2f"));
            glVertexAttrib2fv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2fv>(loader.Invoke("glVertexAttrib2fv"));
            glVertexAttrib2s = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2s>(loader.Invoke("glVertexAttrib2s"));
            glVertexAttrib2sv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib2sv>(loader.Invoke("glVertexAttrib2sv"));
            glVertexAttrib3d = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3d>(loader.Invoke("glVertexAttrib3d"));
            glVertexAttrib3dv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3dv>(loader.Invoke("glVertexAttrib3dv"));
            glVertexAttrib3f = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3f>(loader.Invoke("glVertexAttrib3f"));
            glVertexAttrib3fv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3fv>(loader.Invoke("glVertexAttrib3fv"));
            glVertexAttrib3s = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3s>(loader.Invoke("glVertexAttrib3s"));
            glVertexAttrib3sv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib3sv>(loader.Invoke("glVertexAttrib3sv"));
            glVertexAttrib4Nbv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nbv>(loader.Invoke("glVertexAttrib4Nbv"));
            glVertexAttrib4Niv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Niv>(loader.Invoke("glVertexAttrib4Niv"));
            glVertexAttrib4Nsv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nsv>(loader.Invoke("glVertexAttrib4Nsv"));
            glVertexAttrib4Nub = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nub>(loader.Invoke("glVertexAttrib4Nub"));
            glVertexAttrib4Nubv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nubv>(loader.Invoke("glVertexAttrib4Nubv"));
            glVertexAttrib4Nuiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nuiv>(loader.Invoke("glVertexAttrib4Nuiv"));
            glVertexAttrib4Nusv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4Nusv>(loader.Invoke("glVertexAttrib4Nusv"));
            glVertexAttrib4bv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4bv>(loader.Invoke("glVertexAttrib4bv"));
            glVertexAttrib4d = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4d>(loader.Invoke("glVertexAttrib4d"));
            glVertexAttrib4dv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4dv>(loader.Invoke("glVertexAttrib4dv"));
            glVertexAttrib4f = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4f>(loader.Invoke("glVertexAttrib4f"));
            glVertexAttrib4fv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4fv>(loader.Invoke("glVertexAttrib4fv"));
            glVertexAttrib4iv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4iv>(loader.Invoke("glVertexAttrib4iv"));
            glVertexAttrib4s = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4s>(loader.Invoke("glVertexAttrib4s"));
            glVertexAttrib4sv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4sv>(loader.Invoke("glVertexAttrib4sv"));
            glVertexAttrib4ubv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4ubv>(loader.Invoke("glVertexAttrib4ubv"));
            glVertexAttrib4uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4uiv>(loader.Invoke("glVertexAttrib4uiv"));
            glVertexAttrib4usv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttrib4usv>(loader.Invoke("glVertexAttrib4usv"));
            glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribPointer>(loader.Invoke("glVertexAttribPointer"));
            glUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix2x3fv>(loader.Invoke("glUniformMatrix2x3fv"));
            glUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix3x2fv>(loader.Invoke("glUniformMatrix3x2fv"));
            glUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix2x4fv>(loader.Invoke("glUniformMatrix2x4fv"));
            glUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix4x2fv>(loader.Invoke("glUniformMatrix4x2fv"));
            glUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix3x4fv>(loader.Invoke("glUniformMatrix3x4fv"));
            glUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<OpenGLUniformMatrix4x3fv>(loader.Invoke("glUniformMatrix4x3fv"));
            glColorMaski = Marshal.GetDelegateForFunctionPointer<OpenGLColorMaski>(loader.Invoke("glColorMaski"));
            glGetBooleani_v = Marshal.GetDelegateForFunctionPointer<OpenGLGetBooleani_v>(loader.Invoke("glGetBooleani_v"));
            glGetIntegeri_v = Marshal.GetDelegateForFunctionPointer<OpenGLGetIntegeri_v>(loader.Invoke("glGetIntegeri_v"));
            glEnablei = Marshal.GetDelegateForFunctionPointer<OpenGLEnablei>(loader.Invoke("glEnablei"));
            glDisablei = Marshal.GetDelegateForFunctionPointer<OpenGLDisablei>(loader.Invoke("glDisablei"));
            glIsEnabledi = Marshal.GetDelegateForFunctionPointer<OpenGLIsEnabledi>(loader.Invoke("glIsEnabledi"));
            glBeginTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLBeginTransformFeedback>(loader.Invoke("glBeginTransformFeedback"));
            glEndTransformFeedback = Marshal.GetDelegateForFunctionPointer<OpenGLEndTransformFeedback>(loader.Invoke("glEndTransformFeedback"));
            glBindBufferRange = Marshal.GetDelegateForFunctionPointer<OpenGLBindBufferRange>(loader.Invoke("glBindBufferRange"));
            glBindBufferBase = Marshal.GetDelegateForFunctionPointer<OpenGLBindBufferBase>(loader.Invoke("glBindBufferBase"));
            glTransformFeedbackVaryings = Marshal.GetDelegateForFunctionPointer<OpenGLTransformFeedbackVaryings>(loader.Invoke("glTransformFeedbackVaryings"));
            glGetTransformFeedbackVarying = Marshal.GetDelegateForFunctionPointer<OpenGLGetTransformFeedbackVarying>(loader.Invoke("glGetTransformFeedbackVarying"));
            glClampColor = Marshal.GetDelegateForFunctionPointer<OpenGLClampColor>(loader.Invoke("glClampColor"));
            glBeginConditionalRender = Marshal.GetDelegateForFunctionPointer<OpenGLBeginConditionalRender>(loader.Invoke("glBeginConditionalRender"));
            glEndConditionalRender = Marshal.GetDelegateForFunctionPointer<OpenGLEndConditionalRender>(loader.Invoke("glEndConditionalRender"));
            glVertexAttribIPointer = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribIPointer>(loader.Invoke("glVertexAttribIPointer"));
            glGetVertexAttribIiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribIiv>(loader.Invoke("glGetVertexAttribIiv"));
            glGetVertexAttribIuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetVertexAttribIuiv>(loader.Invoke("glGetVertexAttribIuiv"));
            glVertexAttribI1i = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI1i>(loader.Invoke("glVertexAttribI1i"));
            glVertexAttribI2i = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI2i>(loader.Invoke("glVertexAttribI2i"));
            glVertexAttribI3i = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI3i>(loader.Invoke("glVertexAttribI3i"));
            glVertexAttribI4i = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4i>(loader.Invoke("glVertexAttribI4i"));
            glVertexAttribI1ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI1ui>(loader.Invoke("glVertexAttribI1ui"));
            glVertexAttribI2ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI2ui>(loader.Invoke("glVertexAttribI2ui"));
            glVertexAttribI3ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI3ui>(loader.Invoke("glVertexAttribI3ui"));
            glVertexAttribI4ui = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4ui>(loader.Invoke("glVertexAttribI4ui"));
            glVertexAttribI1iv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI1iv>(loader.Invoke("glVertexAttribI1iv"));
            glVertexAttribI2iv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI2iv>(loader.Invoke("glVertexAttribI2iv"));
            glVertexAttribI3iv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI3iv>(loader.Invoke("glVertexAttribI3iv"));
            glVertexAttribI4iv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4iv>(loader.Invoke("glVertexAttribI4iv"));
            glVertexAttribI1uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI1uiv>(loader.Invoke("glVertexAttribI1uiv"));
            glVertexAttribI2uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI2uiv>(loader.Invoke("glVertexAttribI2uiv"));
            glVertexAttribI3uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI3uiv>(loader.Invoke("glVertexAttribI3uiv"));
            glVertexAttribI4uiv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4uiv>(loader.Invoke("glVertexAttribI4uiv"));
            glVertexAttribI4bv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4bv>(loader.Invoke("glVertexAttribI4bv"));
            glVertexAttribI4sv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4sv>(loader.Invoke("glVertexAttribI4sv"));
            glVertexAttribI4ubv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4ubv>(loader.Invoke("glVertexAttribI4ubv"));
            glVertexAttribI4usv = Marshal.GetDelegateForFunctionPointer<OpenGLVertexAttribI4usv>(loader.Invoke("glVertexAttribI4usv"));
            glGetUniformuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformuiv>(loader.Invoke("glGetUniformuiv"));
            glBindFragDataLocation = Marshal.GetDelegateForFunctionPointer<OpenGLBindFragDataLocation>(loader.Invoke("glBindFragDataLocation"));
            glGetFragDataLocation = Marshal.GetDelegateForFunctionPointer<OpenGLGetFragDataLocation>(loader.Invoke("glGetFragDataLocation"));
            glUniform1ui = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1ui>(loader.Invoke("glUniform1ui"));
            glUniform2ui = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2ui>(loader.Invoke("glUniform2ui"));
            glUniform3ui = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3ui>(loader.Invoke("glUniform3ui"));
            glUniform4ui = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4ui>(loader.Invoke("glUniform4ui"));
            glUniform1uiv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform1uiv>(loader.Invoke("glUniform1uiv"));
            glUniform2uiv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform2uiv>(loader.Invoke("glUniform2uiv"));
            glUniform3uiv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform3uiv>(loader.Invoke("glUniform3uiv"));
            glUniform4uiv = Marshal.GetDelegateForFunctionPointer<OpenGLUniform4uiv>(loader.Invoke("glUniform4uiv"));
            glTexParameterIiv = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameterIiv>(loader.Invoke("glTexParameterIiv"));
            glTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<OpenGLTexParameterIuiv>(loader.Invoke("glTexParameterIuiv"));
            glGetTexParameterIiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexParameterIiv>(loader.Invoke("glGetTexParameterIiv"));
            glGetTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetTexParameterIuiv>(loader.Invoke("glGetTexParameterIuiv"));
            glClearBufferiv = Marshal.GetDelegateForFunctionPointer<OpenGLClearBufferiv>(loader.Invoke("glClearBufferiv"));
            glClearBufferuiv = Marshal.GetDelegateForFunctionPointer<OpenGLClearBufferuiv>(loader.Invoke("glClearBufferuiv"));
            glClearBufferfv = Marshal.GetDelegateForFunctionPointer<OpenGLClearBufferfv>(loader.Invoke("glClearBufferfv"));
            glClearBufferfi = Marshal.GetDelegateForFunctionPointer<OpenGLClearBufferfi>(loader.Invoke("glClearBufferfi"));
            glGetStringi = Marshal.GetDelegateForFunctionPointer<OpenGLGetStringi>(loader.Invoke("glGetStringi"));
            glIsRenderbuffer = Marshal.GetDelegateForFunctionPointer<OpenGLIsRenderbuffer>(loader.Invoke("glIsRenderbuffer"));
            glBindRenderbuffer = Marshal.GetDelegateForFunctionPointer<OpenGLBindRenderbuffer>(loader.Invoke("glBindRenderbuffer"));
            glDeleteRenderbuffers = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteRenderbuffers>(loader.Invoke("glDeleteRenderbuffers"));
            glGenRenderbuffers = Marshal.GetDelegateForFunctionPointer<OpenGLGenRenderbuffers>(loader.Invoke("glGenRenderbuffers"));
            glRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<OpenGLRenderbufferStorage>(loader.Invoke("glRenderbufferStorage"));
            glGetRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetRenderbufferParameteriv>(loader.Invoke("glGetRenderbufferParameteriv"));
            glIsFramebuffer = Marshal.GetDelegateForFunctionPointer<OpenGLIsFramebuffer>(loader.Invoke("glIsFramebuffer"));
            glBindFramebuffer = Marshal.GetDelegateForFunctionPointer<OpenGLBindFramebuffer>(loader.Invoke("glBindFramebuffer"));
            glDeleteFramebuffers = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteFramebuffers>(loader.Invoke("glDeleteFramebuffers"));
            glGenFramebuffers = Marshal.GetDelegateForFunctionPointer<OpenGLGenFramebuffers>(loader.Invoke("glGenFramebuffers"));
            glCheckFramebufferStatus = Marshal.GetDelegateForFunctionPointer<OpenGLCheckFramebufferStatus>(loader.Invoke("glCheckFramebufferStatus"));
            glFramebufferTexture1D = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTexture1D>(loader.Invoke("glFramebufferTexture1D"));
            glFramebufferTexture2D = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTexture2D>(loader.Invoke("glFramebufferTexture2D"));
            glFramebufferTexture3D = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTexture3D>(loader.Invoke("glFramebufferTexture3D"));
            glFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferRenderbuffer>(loader.Invoke("glFramebufferRenderbuffer"));
            glGetFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<OpenGLGetFramebufferAttachmentParameteriv>(loader.Invoke("glGetFramebufferAttachmentParameteriv"));
            glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<OpenGLGenerateMipmap>(loader.Invoke("glGenerateMipmap"));
            glBlitFramebuffer = Marshal.GetDelegateForFunctionPointer<OpenGLBlitFramebuffer>(loader.Invoke("glBlitFramebuffer"));
            glRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<OpenGLRenderbufferStorageMultisample>(loader.Invoke("glRenderbufferStorageMultisample"));
            glFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTextureLayer>(loader.Invoke("glFramebufferTextureLayer"));
            glMapBufferRange = Marshal.GetDelegateForFunctionPointer<OpenGLMapBufferRange>(loader.Invoke("glMapBufferRange"));
            glFlushMappedBufferRange = Marshal.GetDelegateForFunctionPointer<OpenGLFlushMappedBufferRange>(loader.Invoke("glFlushMappedBufferRange"));
            glBindVertexArray = Marshal.GetDelegateForFunctionPointer<OpenGLBindVertexArray>(loader.Invoke("glBindVertexArray"));
            glDeleteVertexArrays = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteVertexArrays>(loader.Invoke("glDeleteVertexArrays"));
            glGenVertexArrays = Marshal.GetDelegateForFunctionPointer<OpenGLGenVertexArrays>(loader.Invoke("glGenVertexArrays"));
            glIsVertexArray = Marshal.GetDelegateForFunctionPointer<OpenGLIsVertexArray>(loader.Invoke("glIsVertexArray"));
            glDrawArraysInstanced = Marshal.GetDelegateForFunctionPointer<OpenGLDrawArraysInstanced>(loader.Invoke("glDrawArraysInstanced"));
            glDrawElementsInstanced = Marshal.GetDelegateForFunctionPointer<OpenGLDrawElementsInstanced>(loader.Invoke("glDrawElementsInstanced"));
            glTexBuffer = Marshal.GetDelegateForFunctionPointer<OpenGLTexBuffer>(loader.Invoke("glTexBuffer"));
            glPrimitiveRestartIndex = Marshal.GetDelegateForFunctionPointer<OpenGLPrimitiveRestartIndex>(loader.Invoke("glPrimitiveRestartIndex"));
            glCopyBufferSubData = Marshal.GetDelegateForFunctionPointer<OpenGLCopyBufferSubData>(loader.Invoke("glCopyBufferSubData"));
            glGetUniformIndices = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformIndices>(loader.Invoke("glGetUniformIndices"));
            glGetActiveUniformsiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveUniformsiv>(loader.Invoke("glGetActiveUniformsiv"));
            glGetActiveUniformName = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveUniformName>(loader.Invoke("glGetActiveUniformName"));
            glGetUniformBlockIndex = Marshal.GetDelegateForFunctionPointer<OpenGLGetUniformBlockIndex>(loader.Invoke("glGetUniformBlockIndex"));
            glGetActiveUniformBlockiv = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveUniformBlockiv>(loader.Invoke("glGetActiveUniformBlockiv"));
            glGetActiveUniformBlockName = Marshal.GetDelegateForFunctionPointer<OpenGLGetActiveUniformBlockName>(loader.Invoke("glGetActiveUniformBlockName"));
            glUniformBlockBinding = Marshal.GetDelegateForFunctionPointer<OpenGLUniformBlockBinding>(loader.Invoke("glUniformBlockBinding"));
            glDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<OpenGLDrawElementsBaseVertex>(loader.Invoke("glDrawElementsBaseVertex"));
            glDrawRangeElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<OpenGLDrawRangeElementsBaseVertex>(loader.Invoke("glDrawRangeElementsBaseVertex"));
            glDrawElementsInstancedBaseVertex = Marshal.GetDelegateForFunctionPointer<OpenGLDrawElementsInstancedBaseVertex>(loader.Invoke("glDrawElementsInstancedBaseVertex"));
            glMultiDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<OpenGLMultiDrawElementsBaseVertex>(loader.Invoke("glMultiDrawElementsBaseVertex"));
            glProvokingVertex = Marshal.GetDelegateForFunctionPointer<OpenGLProvokingVertex>(loader.Invoke("glProvokingVertex"));
            glFenceSync = Marshal.GetDelegateForFunctionPointer<OpenGLFenceSync>(loader.Invoke("glFenceSync"));
            glIsSync = Marshal.GetDelegateForFunctionPointer<OpenGLIsSync>(loader.Invoke("glIsSync"));
            glDeleteSync = Marshal.GetDelegateForFunctionPointer<OpenGLDeleteSync>(loader.Invoke("glDeleteSync"));
            glClientWaitSync = Marshal.GetDelegateForFunctionPointer<OpenGLClientWaitSync>(loader.Invoke("glClientWaitSync"));
            glWaitSync = Marshal.GetDelegateForFunctionPointer<OpenGLWaitSync>(loader.Invoke("glWaitSync"));
            glGetInteger64v = Marshal.GetDelegateForFunctionPointer<OpenGLGetInteger64v>(loader.Invoke("glGetInteger64v"));
            glGetSynciv = Marshal.GetDelegateForFunctionPointer<OpenGLGetSynciv>(loader.Invoke("glGetSynciv"));
            glGetInteger64i_v = Marshal.GetDelegateForFunctionPointer<OpenGLGetInteger64i_v>(loader.Invoke("glGetInteger64i_v"));
            glGetBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<OpenGLGetBufferParameteri64v>(loader.Invoke("glGetBufferParameteri64v"));
            glFramebufferTexture = Marshal.GetDelegateForFunctionPointer<OpenGLFramebufferTexture>(loader.Invoke("glFramebufferTexture"));
            glTexImage2DMultisample = Marshal.GetDelegateForFunctionPointer<OpenGLTexImage2DMultisample>(loader.Invoke("glTexImage2DMultisample"));
            glTexImage3DMultisample = Marshal.GetDelegateForFunctionPointer<OpenGLTexImage3DMultisample>(loader.Invoke("glTexImage3DMultisample"));
            glGetMultisamplefv = Marshal.GetDelegateForFunctionPointer<OpenGLGetMultisamplefv>(loader.Invoke("glGetMultisamplefv"));
            glSampleMaski = Marshal.GetDelegateForFunctionPointer<OpenGLSampleMaski>(loader.Invoke("glSampleMaski"));
        }
    }
}
