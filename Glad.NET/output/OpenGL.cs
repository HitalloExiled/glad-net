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

    [GLExtension("GL_KHR_debug")]
    ContextFlagDebugBit = 0x00000002,

    [GLExtension("GL_KHR_debug")]
    ContextFlagDebugBitKhr = 0x00000002,
    ContextFlagRobustAccessBit = 0x00000004,
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

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
[Flags]
public enum FragmentShaderDestModMaskATI : uint
{

    [GLExtension("GL_KHR_context_flush_control")]
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

    [GLExtension("GL_KHR_context_flush_control")]
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

    [GLExtension("GL_KHR_robustness")]
    GuiltyContextReset = 0x8253,

    [GLExtension("GL_KHR_robustness")]
    InnocentContextReset = 0x8254,

    [GLExtension("GL_KHR_robustness")]
    UnknownContextReset = 0x8255,
}
    
public enum ErrorCode
{
    InvalidEnum = 0x0500,
    InvalidValue = 0x0501,
    InvalidOperation = 0x0502,

    [GLExtension("GL_KHR_debug")]
    StackOverflow = 0x0503,

    [GLExtension("GL_KHR_debug")]
    StackUnderflow = 0x0504,
    OutOfMemory = 0x0505,
}
    
public enum StencilOp
{
    Keep = 0x1E00,
    Replace = 0x1E01,
    Incr = 0x1E02,
    Decr = 0x1E03,
    IncrWrap = 0x8507,
    DecrWrap = 0x8508,
}
    
public enum FragmentShaderValueRepATI
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
public enum SyncBehaviorFlags
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
public enum TextureCompareMode
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    CompareRToTexture = 0x884E,
    CompareRefToTexture = 0x884E,
}
    
public enum PathColorFormat
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    Rgb = 0x1907,
    Rgba = 0x1908,
    Luminance = 0x1909,
    LuminanceAlpha = 0x190A,
    Intensity = 0x8049,
}
    
public enum CombinerBiasNV
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
public enum CombinerScaleNV
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
public enum DrawBufferMode
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Left = 0x0406,
    Right = 0x0407,
    FrontAndBack = 0x0408,
    Aux0 = 0x0409,
    Aux1 = 0x040A,
    Aux2 = 0x040B,
    Aux3 = 0x040C,
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

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
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

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Left = 0x0406,
    Right = 0x0407,
    Aux0 = 0x0409,
    Aux1 = 0x040A,
    Aux2 = 0x040B,
    Aux3 = 0x040C,
}
    
public enum ColorBuffer
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    FrontLeft = 0x0400,
    FrontRight = 0x0401,
    BackLeft = 0x0402,
    BackRight = 0x0403,
    Front = 0x0404,
    Left = 0x0406,
    Right = 0x0407,
    FrontAndBack = 0x0408,
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

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
    EyeLinear = 0x2400,
    ObjectLinear = 0x2401,
    Constant = 0x8576,
}
    
public enum PathTransformType
{

    [GLExtension("GL_KHR_context_flush_control")]
    None = 0,
}
    
public enum PrimitiveType
{
    Points = 0x0000,
    Lines = 0x0001,
    LineLoop = 0x0002,
    LineStrip = 0x0003,
    TriangleStrip = 0x0005,
    TriangleFan = 0x0006,
    QuadStrip = 0x0008,
    Polygon = 0x0009,
    LinesAdjacency = 0x000A,
    LineStripAdjacency = 0x000B,
    TrianglesAdjacency = 0x000C,
    TriangleStripAdjacency = 0x000D,
}
    
public enum GlEnum
{

    [GLExtension("GL_KHR_debug")]
    StackOverflowKhr = 0x0503,

    [GLExtension("GL_KHR_debug")]
    StackUnderflowKhr = 0x0504,

    [GLExtension("GL_KHR_robustness")]
    ContextLost = 0x0507,

    [GLExtension("GL_KHR_robustness")]
    ContextLostKhr = 0x0507,
    RescaleNormal = 0x803A,
    Texture3DBindingOES = 0x806A,
    TextureDepth = 0x8071,

    [GLExtension("GL_KHR_debug")]
    VertexArrayKhr = 0x8074,
    ParameterBufferBinding = 0x80EF,

    [GLExtension("GL_KHR_debug")]
    DebugOutputSynchronousKhr = 0x8242,

    [GLExtension("GL_KHR_debug")]
    DebugNextLoggedMessageLength = 0x8243,

    [GLExtension("GL_KHR_debug")]
    DebugNextLoggedMessageLengthKhr = 0x8243,

    [GLExtension("GL_KHR_debug")]
    DebugCallbackFunctionKhr = 0x8244,

    [GLExtension("GL_KHR_debug")]
    DebugCallbackUserParamKhr = 0x8245,

    [GLExtension("GL_KHR_debug")]
    DebugSourceApiKhr = 0x8246,

    [GLExtension("GL_KHR_debug")]
    DebugSourceWindowSystemKhr = 0x8247,

    [GLExtension("GL_KHR_debug")]
    DebugSourceShaderCompilerKhr = 0x8248,

    [GLExtension("GL_KHR_debug")]
    DebugSourceThirdPartyKhr = 0x8249,

    [GLExtension("GL_KHR_debug")]
    DebugSourceApplicationKhr = 0x824A,

    [GLExtension("GL_KHR_debug")]
    DebugSourceOtherKhr = 0x824B,

    [GLExtension("GL_KHR_debug")]
    DebugTypeErrorKhr = 0x824C,

    [GLExtension("GL_KHR_debug")]
    DebugTypeDeprecatedBehaviorKhr = 0x824D,

    [GLExtension("GL_KHR_debug")]
    DebugTypeUndefinedBehaviorKhr = 0x824E,

    [GLExtension("GL_KHR_debug")]
    DebugTypePortabilityKhr = 0x824F,

    [GLExtension("GL_KHR_debug")]
    DebugTypePerformanceKhr = 0x8250,

    [GLExtension("GL_KHR_debug")]
    DebugTypeOtherKhr = 0x8251,

    [GLExtension("GL_KHR_robustness")]
    LoseContextOnReset = 0x8252,

    [GLExtension("GL_KHR_robustness")]
    LoseContextOnResetKhr = 0x8252,

    [GLExtension("GL_KHR_robustness")]
    GuiltyContextResetKhr = 0x8253,

    [GLExtension("GL_KHR_robustness")]
    InnocentContextResetKhr = 0x8254,

    [GLExtension("GL_KHR_robustness")]
    UnknownContextResetKhr = 0x8255,

    [GLExtension("GL_KHR_robustness")]
    ResetNotificationStrategy = 0x8256,

    [GLExtension("GL_KHR_robustness")]
    ResetNotificationStrategyKhr = 0x8256,
    ViewportSubpixelBitsEXT = 0x825C,
    ViewportBoundsRangeEXT = 0x825D,
    ViewportIndexProvokingVertexEXT = 0x825F,

    [GLExtension("GL_KHR_robustness")]
    NoResetNotification = 0x8261,

    [GLExtension("GL_KHR_robustness")]
    NoResetNotificationKhr = 0x8261,

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

    [GLExtension("GL_KHR_debug")]
    DisplayList = 0x82E7,

    [GLExtension("GL_KHR_debug")]
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

    [GLExtension("GL_KHR_context_flush_control")]
    ContextReleaseBehavior = 0x82FB,

    [GLExtension("GL_KHR_context_flush_control")]
    ContextReleaseBehaviorKhr = 0x82FB,

    [GLExtension("GL_KHR_context_flush_control")]
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
    VertexProgramPointSize = 0x8642,
    VertexProgramTwoSide = 0x8643,
    TextureCompressedImageSize = 0x86A0,
    Dot3Rgb = 0x86AE,
    Dot3Rgba = 0x86AF,
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
    MaxTextureCoords = 0x8871,
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
    FramebufferBindingAngle = 0x8CA6,
    RenderbufferBindingAngle = 0x8CA7,
    FramebufferIncompleteDimensions = 0x8CD9,
    FramebufferIncompleteDrawBufferOES = 0x8CDB,
    FramebufferIncompleteReadBufferOES = 0x8CDC,
    AlphaInteger = 0x8D97,
    MaxGeometryOutputVertices = 0x8DE0,
    MaxGeometryTotalOutputComponents = 0x8DE1,
    MinProgramTextureGatherOffset = 0x8E5E,
    MaxProgramTextureGatherOffset = 0x8E5F,
    PatchDefaultInnerLevelEXT = 0x8E73,
    PatchDefaultOuterLevelEXT = 0x8E74,
    CopyReadBufferBinding = 0x8F36,
    CopyWriteBufferBinding = 0x8F37,
    VertexBindingBuffer = 0x8F4F,

    [GLExtension("GL_KHR_robustness")]
    ContextRobustAccess = 0x90F3,

    [GLExtension("GL_KHR_robustness")]
    ContextRobustAccessKhr = 0x90F3,

    [GLExtension("GL_KHR_debug")]
    MaxDebugMessageLength = 0x9143,

    [GLExtension("GL_KHR_debug")]
    MaxDebugMessageLengthKhr = 0x9143,

    [GLExtension("GL_KHR_debug")]
    MaxDebugLoggedMessages = 0x9144,

    [GLExtension("GL_KHR_debug")]
    MaxDebugLoggedMessagesKhr = 0x9144,

    [GLExtension("GL_KHR_debug")]
    DebugLoggedMessages = 0x9145,

    [GLExtension("GL_KHR_debug")]
    DebugLoggedMessagesKhr = 0x9145,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityHighKhr = 0x9146,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityMediumKhr = 0x9147,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityLowKhr = 0x9148,

    [GLExtension("GL_KHR_parallel_shader_compile")]
    MaxShaderCompilerThreadsKhr = 0x91B0,

    [GLExtension("GL_KHR_parallel_shader_compile")]
    CompletionStatusKhr = 0x91B1,
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
    PrimitiveBoundingBox = 0x92BE,

    [GLExtension("GL_KHR_debug")]
    DebugOutputKhr = 0x92E0,
    MultisampleLineWidthRange = 0x9381,
    MultisampleLineWidthGranularity = 0x9382,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSizeKhr = 0x9532,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedStagesKhr = 0x9533,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupSupportedFeaturesKhr = 0x9534,

    [GLExtension("GL_KHR_shader_subgroup")]
    SubgroupQuadAllStagesKhr = 0x9535,
    SpirVBinary = 0x9552,

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
    Lequal = 0x0203,
    Greater = 0x0204,
    Notequal = 0x0205,
    Gequal = 0x0206,
    Always = 0x0207,
}
    
public enum TriangleFace
{
    Front = 0x0404,
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
    FogIndex = 0x0B61,
    FogDensity = 0x0B62,
    FogStart = 0x0B63,
    FogEnd = 0x0B64,
    FogMode = 0x0B65,
    FogColor = 0x0B66,
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
    LogicOpMode = 0x0BF0,
    IndexLogicOp = 0x0BF1,
    LogicOp = 0x0BF1,
    ColorLogicOp = 0x0BF2,
    AuxBuffers = 0x0C00,
    DrawBuffer = 0x0C01,
    ReadBuffer = 0x0C02,
    IndexClearValue = 0x0C20,
    IndexWritemask = 0x0C21,
    ColorClearValue = 0x0C22,
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
    PolygonOffsetFill = 0x8037,
    PolygonOffsetFactor = 0x8038,
    PackSkipImages = 0x806B,
    PackImageHeight = 0x806C,
    UnpackSkipImages = 0x806D,
    UnpackImageHeight = 0x806E,
    Max3DTextureSize = 0x8073,

    [GLExtension("GL_KHR_debug")]
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
    SampleCoverageValue = 0x80AA,
    SampleCoverageInvert = 0x80AB,
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

    [GLExtension("GL_KHR_debug")]
    MaxDebugGroupStackDepth = 0x826C,

    [GLExtension("GL_KHR_debug")]
    DebugGroupStackDepth = 0x826D,

    [GLExtension("GL_KHR_debug")]
    MaxLabelLength = 0x82E8,
    AliasedPointSizeRange = 0x846D,
    AliasedLineWidthRange = 0x846E,
    ActiveTexture = 0x84E0,
    TextureCompressionHint = 0x84EF,
    MaxRectangleTextureSize = 0x84F8,
    MaxTextureLodBias = 0x84FD,
    MaxCubeMapTextureSize = 0x851C,
    ProgramPointSize = 0x8642,
    NumCompressedTextureFormats = 0x86A2,
    CompressedTextureFormats = 0x86A3,
    StencilBackFunc = 0x8800,
    StencilBackFail = 0x8801,
    StencilBackPassDepthFail = 0x8802,
    StencilBackPassDepthPass = 0x8803,
    MaxDrawBuffers = 0x8824,
    MaxVertexAttribs = 0x8869,
    MaxTextureImageUnits = 0x8872,
    ArrayBufferBinding = 0x8894,
    ElementArrayBufferBinding = 0x8895,
    PixelPackBufferBinding = 0x88ED,
    PixelUnpackBufferBinding = 0x88EF,
    MaxArrayTextureLayers = 0x88FF,
    MinProgramTexelOffset = 0x8904,
    MaxProgramTexelOffset = 0x8905,
    MaxFragmentUniformComponents = 0x8B49,
    MaxVertexUniformComponents = 0x8B4A,
    MaxVaryingFloats = 0x8B4B,
    MaxVertexTextureImageUnits = 0x8B4C,
    MaxCombinedTextureImageUnits = 0x8B4D,
    FragmentShaderDerivativeHint = 0x8B8B,
    CurrentProgram = 0x8B8D,
    MaxGeometryTextureImageUnits = 0x8C29,
    MaxTextureBufferSize = 0x8C2B,
    TransformFeedbackBufferStart = 0x8C84,
    TransformFeedbackBufferSize = 0x8C85,
    TransformFeedbackBufferBinding = 0x8C8F,
    StencilBackRef = 0x8CA3,
    StencilBackValueMask = 0x8CA4,
    StencilBackWritemask = 0x8CA5,
    MaxGeometryUniformComponents = 0x8DDF,
    PrimitiveRestartIndex = 0x8F9E,
    MaxVertexOutputComponents = 0x9122,
    MaxGeometryInputComponents = 0x9123,
    MaxGeometryOutputComponents = 0x9124,
    MaxFragmentInputComponents = 0x9125,
    ContextProfileMask = 0x9126,
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
    DepthTest = 0x0B71,
    StencilTest = 0x0B90,
    Normalize = 0x0BA1,
    AlphaTest = 0x0BC0,
    Dither = 0x0BD0,
    IndexLogicOp = 0x0BF1,
    ColorLogicOp = 0x0BF2,
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

    [GLExtension("GL_KHR_debug")]
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

    [GLExtension("GL_KHR_debug")]
    DebugOutputSynchronous = 0x8242,
    ProgramPointSize = 0x8642,
    SampleShading = 0x8C36,
    RasterizerDiscard = 0x8C89,
    PrimitiveRestart = 0x8F9D,

    [GLExtension("GL_KHR_debug")]
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
}
    
public enum HintTarget
{
    PerspectiveCorrectionHint = 0x0C50,
    PointSmoothHint = 0x0C51,
    LineSmoothHint = 0x0C52,
    PolygonSmoothHint = 0x0C53,
    FogHint = 0x0C54,
    GenerateMipmapHint = 0x8192,
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
    
public enum TextureTarget
{
    ProxyTexture1D = 0x8063,
    ProxyTexture2D = 0x8064,
    ProxyTexture3D = 0x8070,
    ProxyTextureRectangle = 0x84F7,
    TextureCubeMapPositiveX = 0x8515,
    TextureCubeMapNegativeX = 0x8516,
    TextureCubeMapPositiveY = 0x8517,
    TextureCubeMapNegativeY = 0x8518,
    TextureCubeMapPositiveZ = 0x8519,
    TextureCubeMapNegativeZ = 0x851A,
    ProxyTextureCubeMap = 0x851B,
    ProxyTexture1DArray = 0x8C19,
    ProxyTexture2DArray = 0x8C1B,
    ProxyTextureCubeMapArray = 0x900B,
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

    [GLExtension("GL_KHR_debug")]
    DebugCallbackFunction = 0x8244,

    [GLExtension("GL_KHR_debug")]
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
    TextureLodBias = 0x8501,
    TextureCompareMode = 0x884C,
    TextureCompareFunc = 0x884D,
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
    TextureLodBias = 0x8501,
}
    
public enum DebugSeverity
{
    DontCare = 0x1100,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityNotification = 0x826B,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityHigh = 0x9146,

    [GLExtension("GL_KHR_debug")]
    DebugSeverityMedium = 0x9147,

    [GLExtension("GL_KHR_debug")]
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

    [GLExtension("GL_KHR_debug")]
    DebugSourceApi = 0x8246,

    [GLExtension("GL_KHR_debug")]
    DebugSourceWindowSystem = 0x8247,

    [GLExtension("GL_KHR_debug")]
    DebugSourceShaderCompiler = 0x8248,

    [GLExtension("GL_KHR_debug")]
    DebugSourceThirdParty = 0x8249,

    [GLExtension("GL_KHR_debug")]
    DebugSourceApplication = 0x824A,

    [GLExtension("GL_KHR_debug")]
    DebugSourceOther = 0x824B,
}
    
public enum DebugType
{
    DontCare = 0x1100,

    [GLExtension("GL_KHR_debug")]
    DebugTypeError = 0x824C,

    [GLExtension("GL_KHR_debug")]
    DebugTypeDeprecatedBehavior = 0x824D,

    [GLExtension("GL_KHR_debug")]
    DebugTypeUndefinedBehavior = 0x824E,

    [GLExtension("GL_KHR_debug")]
    DebugTypePortability = 0x824F,

    [GLExtension("GL_KHR_debug")]
    DebugTypePerformance = 0x8250,

    [GLExtension("GL_KHR_debug")]
    DebugTypeOther = 0x8251,

    [GLExtension("GL_KHR_debug")]
    DebugTypeMarker = 0x8268,

    [GLExtension("GL_KHR_debug")]
    DebugTypePushGroup = 0x8269,

    [GLExtension("GL_KHR_debug")]
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
    UnsignedByte = 0x1401,
    Int = 0x1404,
}
    
public enum WeightPointerTypeARB
{
    UnsignedByte = 0x1401,
    Int = 0x1404,
}
    
public enum TangentPointerTypeEXT
{
    Int = 0x1404,
    DoubleEXT = 0x140A,
}
    
public enum BinormalPointerTypeEXT
{
    Int = 0x1404,
    DoubleEXT = 0x140A,
}
    
public enum ColorPointerType
{
    UnsignedByte = 0x1401,
}
    
public enum ListNameType
{
    UnsignedByte = 0x1401,
    Int = 0x1404,
    _2Bytes = 0x1407,
    _3Bytes = 0x1408,
    _4Bytes = 0x1409,
}
    
public enum NormalPointerType
{
    Int = 0x1404,
}
    
public enum PixelType
{
    UnsignedByte = 0x1401,
    Int = 0x1404,
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
    UnsignedInt5999Rev = 0x8C3E,
}
    
public enum VertexAttribType
{
    UnsignedByte = 0x1401,
    Int = 0x1404,
}
    
public enum VertexAttribPointerType
{
    UnsignedByte = 0x1401,
    Int = 0x1404,
}
    
public enum ScalarType
{
    UnsignedByte = 0x1401,
}
    
public enum ReplacementCodeTypeSUN
{
    UnsignedByte = 0x1401,
}
    
public enum ElementPointerTypeATI
{
    UnsignedByte = 0x1401,
}
    
public enum MatrixIndexPointerTypeARB
{
    UnsignedByte = 0x1401,
}
    
public enum DrawElementsType
{
    UnsignedByte = 0x1401,
}
    
public enum SecondaryColorPointerTypeIBM
{
    Int = 0x1404,
}
    
public enum IndexPointerType
{
    Int = 0x1404,
}
    
public enum TexCoordPointerType
{
    Int = 0x1404,
}
    
public enum VertexPointerType
{
    Int = 0x1404,
}
    
public enum PixelFormat
{
    ColorIndex = 0x1900,
    Rgb = 0x1907,
    Rgba = 0x1908,
    Luminance = 0x1909,
    LuminanceAlpha = 0x190A,
    Bgr = 0x80E0,
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
    SamplerCubeMapArray = 0x900C,
    SamplerCubeMapArrayShadow = 0x900D,
    IntSamplerCubeMapArray = 0x900E,
    UnsignedIntSamplerCubeMapArray = 0x900F,
}
    
public enum UniformType
{
    Int = 0x1404,
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
    SamplerCubeMapArray = 0x900C,
    SamplerCubeMapArrayShadow = 0x900D,
    IntSamplerCubeMapArray = 0x900E,
    UnsignedIntSamplerCubeMapArray = 0x900F,
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
    OrReverse = 0x150B,
    CopyInverted = 0x150C,
    OrInverted = 0x150D,
    Nand = 0x150E,
    Set = 0x150F,
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

    [GLExtension("GL_KHR_debug")]
    VertexArray = 0x8074,

    [GLExtension("GL_KHR_debug")]
    Buffer = 0x82E0,

    [GLExtension("GL_KHR_debug")]
    Shader = 0x82E1,

    [GLExtension("GL_KHR_debug")]
    Program = 0x82E2,

    [GLExtension("GL_KHR_debug")]
    Query = 0x82E3,

    [GLExtension("GL_KHR_debug")]
    ProgramPipeline = 0x82E4,
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
    
public enum InternalFormat
{
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
    DepthComponent24 = 0x81A6,
    DepthComponent32 = 0x81A7,
    CompressedRed = 0x8225,
    CompressedRg = 0x8226,
    CompressedRgb = 0x84ED,
    CompressedRgba = 0x84EE,
    DepthStencilMESA = 0x8750,
    Rgba32f = 0x8814,
    Rgba16f = 0x881A,
    Rgb16f = 0x881B,
    R11fG11fB10f = 0x8C3A,
    Rgb9E5 = 0x8C3D,
    Srgb = 0x8C40,
    Srgb8 = 0x8C41,
    SrgbAlpha = 0x8C42,
    Srgb8Alpha8 = 0x8C43,
    CompressedSrgb = 0x8C48,
    CompressedSrgbAlpha = 0x8C49,
    Rgba32ui = 0x8D70,
    Rgba16ui = 0x8D76,
    Rgb16ui = 0x8D77,
    Rgb8ui = 0x8D7D,
    Rgba32i = 0x8D82,
    Rgba16i = 0x8D88,
    Rgb16i = 0x8D89,
    Rgba8i = 0x8D8E,
    Rgb8i = 0x8D8F,
    CompressedRgbaBptcUnorm = 0x8E8C,
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,
    CompressedR11EacOES = 0x9270,
    CompressedSignedR11EacOES = 0x9271,
    CompressedRg11EacOES = 0x9272,
    CompressedSignedRg11EacOES = 0x9273,
    CompressedRgb8Etc2OES = 0x9274,
    CompressedSrgb8Etc2OES = 0x9275,
    CompressedRgb8PunchthroughAlpha1Etc2OES = 0x9276,
    CompressedSrgb8PunchthroughAlpha1Etc2OES = 0x9277,
    CompressedRgba8Etc2EacOES = 0x9278,
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
    
public enum CombinerComponentUsageNV
{
    Rgb = 0x1907,
}
    
public enum CombinerPortionNV
{
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
    DepthComponent24 = 0x81A6,
    DepthComponent32 = 0x81A7,
    Rgba32f = 0x8814,
    Rgba16f = 0x881A,
    Rgb16f = 0x881B,
    R11fG11fB10f = 0x8C3A,
    Rgb9E5 = 0x8C3D,
    Srgb8 = 0x8C41,
    Srgb8Alpha8 = 0x8C43,
    Rgba32ui = 0x8D70,
    Rgba16ui = 0x8D76,
    Rgb16ui = 0x8D77,
    Rgb8ui = 0x8D7D,
    Rgba32i = 0x8D82,
    Rgba16i = 0x8D88,
    Rgb16i = 0x8D89,
    Rgba8i = 0x8D8E,
    Rgb8i = 0x8D8F,
    CompressedRgbaBptcUnorm = 0x8E8C,
    CompressedSrgbAlphaBptcUnorm = 0x8E8D,
    CompressedRgbBptcSignedFloat = 0x8E8E,
    CompressedRgbBptcUnsignedFloat = 0x8E8F,
    CompressedR11EacOES = 0x9270,
    CompressedSignedR11EacOES = 0x9271,
    CompressedRg11EacOES = 0x9272,
    CompressedSignedRg11EacOES = 0x9273,
    CompressedRgb8Etc2OES = 0x9274,
    CompressedSrgb8Etc2OES = 0x9275,
    CompressedRgb8PunchthroughAlpha1Etc2OES = 0x9276,
    CompressedSrgb8PunchthroughAlpha1Etc2OES = 0x9277,
    CompressedRgba8Etc2EacOES = 0x9278,
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
    
public enum InternalFormatPName
{
    GenerateMipmap = 0x8191,
}
    
public enum BufferTargetARB
{
    ParameterBuffer = 0x80EE,
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893,
    PixelPackBuffer = 0x88EB,
    PixelUnpackBuffer = 0x88EC,
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
    FramebufferAttachmentLayered = 0x8DA7,

    [GLExtension("GL_OVR_multiview")]
    FramebufferAttachmentTextureNumViewsOvr = 0x9630,

    [GLExtension("GL_OVR_multiview")]
    FramebufferAttachmentTextureBaseViewIndexOvr = 0x9632,
}
    
public enum FramebufferStatus
{
    FramebufferIncompleteLayerTargets = 0x8DA8,
}
    
public enum FramebufferAttachment
{
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
    
public enum BufferPNameARB
{
    BufferSize = 0x8764,
    BufferUsage = 0x8765,
    BufferAccess = 0x88BB,
    BufferMapped = 0x88BC,
    BufferAccessFlags = 0x911F,
    BufferMapLength = 0x9120,
    BufferMapOffset = 0x9121,
}
    
public enum PipelineParameterName
{
    FragmentShader = 0x8B30,
    VertexShader = 0x8B31,
    InfoLogLength = 0x8B84,
    GeometryShader = 0x8DD9,
}
    
public enum ProgramPropertyARB
{
    GeometryVerticesOut = 0x8916,
    GeometryInputType = 0x8917,
    GeometryOutputType = 0x8918,
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
}
    
public enum VertexAttribPropertyARB
{
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
    QueryResult = 0x8866,
    QueryResultAvailable = 0x8867,
}
    
public enum QueryTarget
{
    TransformFeedbackOverflow = 0x82EC,
    VerticesSubmitted = 0x82EE,
    PrimitivesSubmitted = 0x82EF,
    VertexShaderInvocations = 0x82F0,
    SamplesPassed = 0x8914,
    PrimitivesGenerated = 0x8C87,
    TransformFeedbackPrimitivesWritten = 0x8C88,
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
}
    
public enum BufferStorageTarget
{
    ArrayBuffer = 0x8892,
    ElementArrayBuffer = 0x8893,
    PixelPackBuffer = 0x88EB,
    PixelUnpackBuffer = 0x88EC,
}
    
public enum BufferAccessARB
{
    ReadOnly = 0x88B8,
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
    
public enum ShaderType
{
    FragmentShader = 0x8B30,
    VertexShader = 0x8B31,
    GeometryShader = 0x8DD9,
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
    
public enum ConditionalRenderMode
{
    QueryWait = 0x8E13,
    QueryNoWait = 0x8E14,
    QueryByRegionWait = 0x8E15,
    QueryByRegionNoWait = 0x8E16,
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
        private static GLCullFace glCullFace;
        
        public static void CullFace(TriangleFace mode) =>
            glCullFace.Invoke(mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFrontFace(FrontFaceDirection mode);
        private static GLFrontFace glFrontFace;
        
        public static void FrontFace(FrontFaceDirection mode) =>
            glFrontFace.Invoke(mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLHint(HintTarget target, HintMode mode);
        private static GLHint glHint;
        
        public static void Hint(HintTarget target, HintMode mode) =>
            glHint.Invoke(target, mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLineWidth(float width);
        private static GLLineWidth glLineWidth;
        
        public static void LineWidth(float width) =>
            glLineWidth.Invoke(width);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointSize(float size);
        private static GLPointSize glPointSize;
        
        public static void PointSize(float size) =>
            glPointSize.Invoke(size);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPolygonMode(TriangleFace face, PolygonMode mode);
        private static GLPolygonMode glPolygonMode;
        
        public static void PolygonMode(TriangleFace face, PolygonMode mode) =>
            glPolygonMode.Invoke(face, mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLScissor(int x, int y, int width, int height);
        private static GLScissor glScissor;
        
        public static void Scissor(int x, int y, int width, int height) =>
            glScissor.Invoke(x, y, width, height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameterf(TextureTarget target, TextureParameterName pname, float param);
        private static GLTexParameterf glTexParameterf;
        
        public static void TexParameterf(TextureTarget target, TextureParameterName pname, float param) =>
            glTexParameterf.Invoke(target, pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameterfv(TextureTarget target, TextureParameterName pname, float[] parameters);
        private static GLTexParameterfv glTexParameterfv;
        
        public static void TexParameterfv(TextureTarget target, TextureParameterName pname, float[] parameters) =>
            glTexParameterfv.Invoke(target, pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameteri(TextureTarget target, TextureParameterName pname, int param);
        private static GLTexParameteri glTexParameteri;
        
        public static void TexParameteri(TextureTarget target, TextureParameterName pname, int param) =>
            glTexParameteri.Invoke(target, pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameteriv(TextureTarget target, TextureParameterName pname, int[] parameters);
        private static GLTexParameteriv glTexParameteriv;
        
        public static void TexParameteriv(TextureTarget target, TextureParameterName pname, int[] parameters) =>
            glTexParameteriv.Invoke(target, pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage1D(TextureTarget target, int level, int internalformat, int width, int border, PixelFormat format, PixelType type, nint pixels);
        private static GLTexImage1D glTexImage1D;
        
        public static void TexImage1D(TextureTarget target, int level, int internalformat, int width, int border, PixelFormat format, PixelType type, nint pixels) =>
            glTexImage1D.Invoke(target, level, internalformat, width, border, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage2D(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, nint pixels);
        private static GLTexImage2D glTexImage2D;
        
        public static void TexImage2D(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, nint pixels) =>
            glTexImage2D.Invoke(target, level, internalformat, width, height, border, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawBuffer(DrawBufferMode buf);
        private static GLDrawBuffer glDrawBuffer;
        
        public static void DrawBuffer(DrawBufferMode buf) =>
            glDrawBuffer.Invoke(buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClear(ClearBufferMask mask);
        private static GLClear glClear;
        
        public static void Clear(ClearBufferMask mask) =>
            glClear.Invoke(mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearColor(float red, float green, float blue, float alpha);
        private static GLClearColor glClearColor;
        
        public static void ClearColor(float red, float green, float blue, float alpha) =>
            glClearColor.Invoke(red, green, blue, alpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearStencil(int s);
        private static GLClearStencil glClearStencil;
        
        public static void ClearStencil(int s) =>
            glClearStencil.Invoke(s);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearDepth(double depth);
        private static GLClearDepth glClearDepth;
        
        public static void ClearDepth(double depth) =>
            glClearDepth.Invoke(depth);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilMask(uint mask);
        private static GLStencilMask glStencilMask;
        
        public static void StencilMask(uint mask) =>
            glStencilMask.Invoke(mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLColorMask(bool red, bool green, bool blue, bool alpha);
        private static GLColorMask glColorMask;
        
        public static void ColorMask(bool red, bool green, bool blue, bool alpha) =>
            glColorMask.Invoke(red, green, blue, alpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthMask(bool flag);
        private static GLDepthMask glDepthMask;
        
        public static void DepthMask(bool flag) =>
            glDepthMask.Invoke(flag);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisable(EnableCap cap);
        private static GLDisable glDisable;
        
        public static void Disable(EnableCap cap) =>
            glDisable.Invoke(cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnable(EnableCap cap);
        private static GLEnable glEnable;
        
        public static void Enable(EnableCap cap) =>
            glEnable.Invoke(cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFinish();
        private static GLFinish glFinish;
        
        public static void Finish() =>
            glFinish.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFlush();
        private static GLFlush glFlush;
        
        public static void Flush() =>
            glFlush.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);
        private static GLBlendFunc glBlendFunc;
        
        public static void BlendFunc(BlendingFactor sfactor, BlendingFactor dfactor) =>
            glBlendFunc.Invoke(sfactor, dfactor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLogicOp(LogicOp opcode);
        private static GLLogicOp glLogicOp;
        
        public static void LogicOp(LogicOp opcode) =>
            glLogicOp.Invoke(opcode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilFunc(StencilFunction func, int reference, uint mask);
        private static GLStencilFunc glStencilFunc;
        
        public static void StencilFunc(StencilFunction func, int reference, uint mask) =>
            glStencilFunc.Invoke(func, reference, mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass);
        private static GLStencilOp glStencilOp;
        
        public static void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass) =>
            glStencilOp.Invoke(fail, zfail, zpass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthFunc(DepthFunction func);
        private static GLDepthFunc glDepthFunc;
        
        public static void DepthFunc(DepthFunction func) =>
            glDepthFunc.Invoke(func);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPixelStoref(PixelStoreParameter pname, float param);
        private static GLPixelStoref glPixelStoref;
        
        public static void PixelStoref(PixelStoreParameter pname, float param) =>
            glPixelStoref.Invoke(pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPixelStorei(PixelStoreParameter pname, int param);
        private static GLPixelStorei glPixelStorei;
        
        public static void PixelStorei(PixelStoreParameter pname, int param) =>
            glPixelStorei.Invoke(pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadBuffer(ReadBufferMode src);
        private static GLReadBuffer glReadBuffer;
        
        public static void ReadBuffer(ReadBufferMode src) =>
            glReadBuffer.Invoke(src);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, out nint pixels);
        private static GLReadPixels glReadPixels;
        
        public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, out nint pixels) =>
            glReadPixels.Invoke(x, y, width, height, format, type, out pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBooleanv(GetPName pname, out bool data);
        private static GLGetBooleanv glGetBooleanv;
        
        public static void GetBooleanv(GetPName pname, out bool data) =>
            glGetBooleanv.Invoke(pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetDoublev(GetPName pname, out double data);
        private static GLGetDoublev glGetDoublev;
        
        public static void GetDoublev(GetPName pname, out double data) =>
            glGetDoublev.Invoke(pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ErrorCode GLGetError();
        private static GLGetError glGetError;
        
        public static ErrorCode GetError() =>
            glGetError.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetFloatv(GetPName pname, out float data);
        private static GLGetFloatv glGetFloatv;
        
        public static void GetFloatv(GetPName pname, out float data) =>
            glGetFloatv.Invoke(pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetIntegerv(GetPName pname, out int data);
        private static GLGetIntegerv glGetIntegerv;
        
        public static void GetIntegerv(GetPName pname, out int data) =>
            glGetIntegerv.Invoke(pname, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLGetString(StringName name);
        private static GLGetString glGetString;
        
        public static nint GetString(StringName name) =>
            glGetString.Invoke(name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, out nint pixels);
        private static GLGetTexImage glGetTexImage;
        
        public static void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, out nint pixels) =>
            glGetTexImage.Invoke(target, level, format, type, out pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexParameterfv(TextureTarget target, GetTextureParameter pname, out float parameters);
        private static GLGetTexParameterfv glGetTexParameterfv;
        
        public static void GetTexParameterfv(TextureTarget target, GetTextureParameter pname, out float parameters) =>
            glGetTexParameterfv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexParameteriv(TextureTarget target, GetTextureParameter pname, out int parameters);
        private static GLGetTexParameteriv glGetTexParameteriv;
        
        public static void GetTexParameteriv(TextureTarget target, GetTextureParameter pname, out int parameters) =>
            glGetTexParameteriv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, out float parameters);
        private static GLGetTexLevelParameterfv glGetTexLevelParameterfv;
        
        public static void GetTexLevelParameterfv(TextureTarget target, int level, GetTextureParameter pname, out float parameters) =>
            glGetTexLevelParameterfv.Invoke(target, level, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, out int parameters);
        private static GLGetTexLevelParameteriv glGetTexLevelParameteriv;
        
        public static void GetTexLevelParameteriv(TextureTarget target, int level, GetTextureParameter pname, out int parameters) =>
            glGetTexLevelParameteriv.Invoke(target, level, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsEnabled(EnableCap cap);
        private static GLIsEnabled glIsEnabled;
        
        public static bool IsEnabled(EnableCap cap) =>
            glIsEnabled.Invoke(cap);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDepthRange(double n, double f);
        private static GLDepthRange glDepthRange;
        
        public static void DepthRange(double n, double f) =>
            glDepthRange.Invoke(n, f);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLViewport(int x, int y, int width, int height);
        private static GLViewport glViewport;
        
        public static void Viewport(int x, int y, int width, int height) =>
            glViewport.Invoke(x, y, width, height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMinSampleShading(float value);
        private static GLMinSampleShading glMinSampleShading;
        
        public static void MinSampleShading(float value) =>
            glMinSampleShading.Invoke(value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPrimitiveBoundingBox(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW);
        private static GLPrimitiveBoundingBox glPrimitiveBoundingBox;
        
        public static void PrimitiveBoundingBox(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW) =>
            glPrimitiveBoundingBox.Invoke(minX, minY, minZ, minW, maxX, maxY, maxZ, maxW);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFuncSeparatei(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
        private static GLBlendFuncSeparatei glBlendFuncSeparatei;
        
        public static void BlendFuncSeparatei(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha) =>
            glBlendFuncSeparatei.Invoke(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFunci(uint buf, BlendingFactor src, BlendingFactor dst);
        private static GLBlendFunci glBlendFunci;
        
        public static void BlendFunci(uint buf, BlendingFactor src, BlendingFactor dst) =>
            glBlendFunci.Invoke(buf, src, dst);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationSeparatei(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        private static GLBlendEquationSeparatei glBlendEquationSeparatei;
        
        public static void BlendEquationSeparatei(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha) =>
            glBlendEquationSeparatei.Invoke(buf, modeRGB, modeAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationi(uint buf, BlendEquationModeEXT mode);
        private static GLBlendEquationi glBlendEquationi;
        
        public static void BlendEquationi(uint buf, BlendEquationModeEXT mode) =>
            glBlendEquationi.Invoke(buf, mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendBarrier();
        private static GLBlendBarrier glBlendBarrier;
        
        public static void BlendBarrier() =>
            glBlendBarrier.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendBarrierKHR();
        private static GLBlendBarrierKHR glBlendBarrierKHR;
        
        [GLExtension("GL_KHR_blend_equation_advanced")]
        public static void BlendBarrierKHR() =>
            glBlendBarrierKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled);
        private static GLDebugMessageControl glDebugMessageControl;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled) =>
            glDebugMessageControl.Invoke(source, type, severity, count, ids, enabled);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, sbyte[] buf);
        private static GLDebugMessageInsert glDebugMessageInsert;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageInsert(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, sbyte[] buf) =>
            glDebugMessageInsert.Invoke(source, type, id, severity, length, buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageCallback(DebugProc callback, nint userParam);
        private static GLDebugMessageCallback glDebugMessageCallback;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageCallback(DebugProc callback, nint userParam) =>
            glDebugMessageCallback.Invoke(callback, userParam);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLGetDebugMessageLog(uint count, int bufSize, out DebugSource sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, out sbyte messageLog);
        private static GLGetDebugMessageLog glGetDebugMessageLog;
        
        [GLExtension("GL_KHR_debug")]
        public static uint GetDebugMessageLog(uint count, int bufSize, out DebugSource sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, out sbyte messageLog) =>
            glGetDebugMessageLog.Invoke(count, bufSize, out sources, out types, out ids, out severities, out lengths, out messageLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPushDebugGroup(DebugSource source, uint id, int length, sbyte[] message);
        private static GLPushDebugGroup glPushDebugGroup;
        
        [GLExtension("GL_KHR_debug")]
        public static void PushDebugGroup(DebugSource source, uint id, int length, sbyte[] message) =>
            glPushDebugGroup.Invoke(source, id, length, message);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPopDebugGroup();
        private static GLPopDebugGroup glPopDebugGroup;
        
        [GLExtension("GL_KHR_debug")]
        public static void PopDebugGroup() =>
            glPopDebugGroup.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLObjectLabel(ObjectIdentifier identifier, uint name, int length, sbyte[] label);
        private static GLObjectLabel glObjectLabel;
        
        [GLExtension("GL_KHR_debug")]
        public static void ObjectLabel(ObjectIdentifier identifier, uint name, int length, sbyte[] label) =>
            glObjectLabel.Invoke(identifier, name, length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length, out sbyte label);
        private static GLGetObjectLabel glGetObjectLabel;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetObjectLabel(ObjectIdentifier identifier, uint name, int bufSize, out int length, out sbyte label) =>
            glGetObjectLabel.Invoke(identifier, name, bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLObjectPtrLabel(nint ptr, int length, sbyte[] label);
        private static GLObjectPtrLabel glObjectPtrLabel;
        
        [GLExtension("GL_KHR_debug")]
        public static void ObjectPtrLabel(nint ptr, int length, sbyte[] label) =>
            glObjectPtrLabel.Invoke(ptr, length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetObjectPtrLabel(nint ptr, int bufSize, out int length, out sbyte label);
        private static GLGetObjectPtrLabel glGetObjectPtrLabel;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetObjectPtrLabel(nint ptr, int bufSize, out int length, out sbyte label) =>
            glGetObjectPtrLabel.Invoke(ptr, bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled);
        private static GLDebugMessageControlKHR glDebugMessageControlKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageControlKHR(DebugSource source, DebugType type, DebugSeverity severity, int count, uint[] ids, bool enabled) =>
            glDebugMessageControlKHR.Invoke(source, type, severity, count, ids, enabled);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageInsertKHR(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, sbyte[] buf);
        private static GLDebugMessageInsertKHR glDebugMessageInsertKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageInsertKHR(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, sbyte[] buf) =>
            glDebugMessageInsertKHR.Invoke(source, type, id, severity, length, buf);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDebugMessageCallbackKHR(DebugProc callback, nint userParam);
        private static GLDebugMessageCallbackKHR glDebugMessageCallbackKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void DebugMessageCallbackKHR(DebugProc callback, nint userParam) =>
            glDebugMessageCallbackKHR.Invoke(callback, userParam);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLGetDebugMessageLogKHR(uint count, int bufSize, out DebugSource sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, out sbyte messageLog);
        private static GLGetDebugMessageLogKHR glGetDebugMessageLogKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static uint GetDebugMessageLogKHR(uint count, int bufSize, out DebugSource sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, out sbyte messageLog) =>
            glGetDebugMessageLogKHR.Invoke(count, bufSize, out sources, out types, out ids, out severities, out lengths, out messageLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPushDebugGroupKHR(DebugSource source, uint id, int length, sbyte[] message);
        private static GLPushDebugGroupKHR glPushDebugGroupKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void PushDebugGroupKHR(DebugSource source, uint id, int length, sbyte[] message) =>
            glPushDebugGroupKHR.Invoke(source, id, length, message);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPopDebugGroupKHR();
        private static GLPopDebugGroupKHR glPopDebugGroupKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void PopDebugGroupKHR() =>
            glPopDebugGroupKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLObjectLabelKHR(ObjectIdentifier identifier, uint name, int length, sbyte[] label);
        private static GLObjectLabelKHR glObjectLabelKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void ObjectLabelKHR(ObjectIdentifier identifier, uint name, int length, sbyte[] label) =>
            glObjectLabelKHR.Invoke(identifier, name, length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetObjectLabelKHR(int identifier, uint name, int bufSize, out int length, out sbyte label);
        private static GLGetObjectLabelKHR glGetObjectLabelKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetObjectLabelKHR(int identifier, uint name, int bufSize, out int length, out sbyte label) =>
            glGetObjectLabelKHR.Invoke(identifier, name, bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLObjectPtrLabelKHR(nint ptr, int length, sbyte[] label);
        private static GLObjectPtrLabelKHR glObjectPtrLabelKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void ObjectPtrLabelKHR(nint ptr, int length, sbyte[] label) =>
            glObjectPtrLabelKHR.Invoke(ptr, length, label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetObjectPtrLabelKHR(nint ptr, int bufSize, out int length, out sbyte label);
        private static GLGetObjectPtrLabelKHR glGetObjectPtrLabelKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetObjectPtrLabelKHR(nint ptr, int bufSize, out int length, out sbyte label) =>
            glGetObjectPtrLabelKHR.Invoke(ptr, bufSize, out length, out label);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetPointervKHR(int pname, out nint parameters);
        private static GLGetPointervKHR glGetPointervKHR;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetPointervKHR(int pname, out nint parameters) =>
            glGetPointervKHR.Invoke(pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus GLGetGraphicsResetStatus();
        private static GLGetGraphicsResetStatus glGetGraphicsResetStatus;
        
        [GLExtension("GL_KHR_robustness")]
        public static GraphicsResetStatus GetGraphicsResetStatus() =>
            glGetGraphicsResetStatus.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data);
        private static GLReadnPixels glReadnPixels;
        
        [GLExtension("GL_KHR_robustness")]
        public static void ReadnPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data) =>
            glReadnPixels.Invoke(x, y, width, height, format, type, bufSize, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformfv(uint program, int location, int bufSize, out float parameters);
        private static GLGetnUniformfv glGetnUniformfv;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformfv(uint program, int location, int bufSize, out float parameters) =>
            glGetnUniformfv.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformiv(uint program, int location, int bufSize, out int parameters);
        private static GLGetnUniformiv glGetnUniformiv;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformiv(uint program, int location, int bufSize, out int parameters) =>
            glGetnUniformiv.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformuiv(uint program, int location, int bufSize, out uint parameters);
        private static GLGetnUniformuiv glGetnUniformuiv;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformuiv(uint program, int location, int bufSize, out uint parameters) =>
            glGetnUniformuiv.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus GLGetGraphicsResetStatusKHR();
        private static GLGetGraphicsResetStatusKHR glGetGraphicsResetStatusKHR;
        
        [GLExtension("GL_KHR_robustness")]
        public static GraphicsResetStatus GetGraphicsResetStatusKHR() =>
            glGetGraphicsResetStatusKHR.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLReadnPixelsKHR(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data);
        private static GLReadnPixelsKHR glReadnPixelsKHR;
        
        [GLExtension("GL_KHR_robustness")]
        public static void ReadnPixelsKHR(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, out nint data) =>
            glReadnPixelsKHR.Invoke(x, y, width, height, format, type, bufSize, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformfvKHR(uint program, int location, int bufSize, out float parameters);
        private static GLGetnUniformfvKHR glGetnUniformfvKHR;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformfvKHR(uint program, int location, int bufSize, out float parameters) =>
            glGetnUniformfvKHR.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformivKHR(uint program, int location, int bufSize, out int parameters);
        private static GLGetnUniformivKHR glGetnUniformivKHR;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformivKHR(uint program, int location, int bufSize, out int parameters) =>
            glGetnUniformivKHR.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetnUniformuivKHR(uint program, int location, int bufSize, out uint parameters);
        private static GLGetnUniformuivKHR glGetnUniformuivKHR;
        
        [GLExtension("GL_KHR_robustness")]
        public static void GetnUniformuivKHR(uint program, int location, int bufSize, out uint parameters) =>
            glGetnUniformuivKHR.Invoke(program, location, bufSize, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMaxShaderCompilerThreadsKHR(uint count);
        private static GLMaxShaderCompilerThreadsKHR glMaxShaderCompilerThreadsKHR;
        
        [GLExtension("GL_KHR_parallel_shader_compile")]
        public static void MaxShaderCompilerThreadsKHR(uint count) =>
            glMaxShaderCompilerThreadsKHR.Invoke(count);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int baseViewIndex, int numViews);
        private static GLFramebufferTextureMultiviewOVR glFramebufferTextureMultiviewOVR;
        
        [GLExtension("GL_OVR_multiview")]
        public static void FramebufferTextureMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int baseViewIndex, int numViews) =>
            glFramebufferTextureMultiviewOVR.Invoke(target, attachment, texture, level, baseViewIndex, numViews);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTextureMultisampleMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int samples, int baseViewIndex, int numViews);
        private static GLFramebufferTextureMultisampleMultiviewOVR glFramebufferTextureMultisampleMultiviewOVR;
        
        [GLExtension("GL_OVR_multiview_multisampled_render_to_texture")]
        public static void FramebufferTextureMultisampleMultiviewOVR(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int samples, int baseViewIndex, int numViews) =>
            glFramebufferTextureMultisampleMultiviewOVR.Invoke(target, attachment, texture, level, samples, baseViewIndex, numViews);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArrays(PrimitiveType mode, int first, int count);
        private static GLDrawArrays glDrawArrays;
        
        public static void DrawArrays(PrimitiveType mode, int first, int count) =>
            glDrawArrays.Invoke(mode, first, count);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElements(PrimitiveType mode, int count, DrawElementsType type, nint indices);
        private static GLDrawElements glDrawElements;
        
        public static void DrawElements(PrimitiveType mode, int count, DrawElementsType type, nint indices) =>
            glDrawElements.Invoke(mode, count, type, indices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPolygonOffset(float factor, float units);
        private static GLPolygonOffset glPolygonOffset;
        
        public static void PolygonOffset(float factor, float units) =>
            glPolygonOffset.Invoke(factor, units);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int border);
        private static GLCopyTexImage1D glCopyTexImage1D;
        
        public static void CopyTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int border) =>
            glCopyTexImage1D.Invoke(target, level, internalformat, x, y, width, border);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border);
        private static GLCopyTexImage2D glCopyTexImage2D;
        
        public static void CopyTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border) =>
            glCopyTexImage2D.Invoke(target, level, internalformat, x, y, width, height, border);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage1D(TextureTarget target, int level, int xoffset, int x, int y, int width);
        private static GLCopyTexSubImage1D glCopyTexSubImage1D;
        
        public static void CopyTexSubImage1D(TextureTarget target, int level, int xoffset, int x, int y, int width) =>
            glCopyTexSubImage1D.Invoke(target, level, xoffset, x, y, width);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        private static GLCopyTexSubImage2D glCopyTexSubImage2D;
        
        public static void CopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height) =>
            glCopyTexSubImage2D.Invoke(target, level, xoffset, yoffset, x, y, width, height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage1D(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels);
        private static GLTexSubImage1D glTexSubImage1D;
        
        public static void TexSubImage1D(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, nint pixels) =>
            glTexSubImage1D.Invoke(target, level, xoffset, width, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels);
        private static GLTexSubImage2D glTexSubImage2D;
        
        public static void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, nint pixels) =>
            glTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindTexture(TextureTarget target, uint texture);
        private static GLBindTexture glBindTexture;
        
        public static void BindTexture(TextureTarget target, uint texture) =>
            glBindTexture.Invoke(target, texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteTextures(int n, uint[] textures);
        private static GLDeleteTextures glDeleteTextures;
        
        public static void DeleteTextures(int n, uint[] textures) =>
            glDeleteTextures.Invoke(n, textures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGenTextures(int n, out uint textures);
        private static GLGenTextures glGenTextures;
        
        public static void GenTextures(int n, out uint textures) =>
            glGenTextures.Invoke(n, out textures);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsTexture(uint texture);
        private static GLIsTexture glIsTexture;
        
        public static bool IsTexture(uint texture) =>
            glIsTexture.Invoke(texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawRangeElements(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices);
        private static GLDrawRangeElements glDrawRangeElements;
        
        public static void DrawRangeElements(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, nint indices) =>
            glDrawRangeElements.Invoke(mode, start, end, count, type, indices);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexImage3D(TextureTarget target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, nint pixels);
        private static GLTexImage3D glTexImage3D;
        
        public static void TexImage3D(TextureTarget target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, nint pixels) =>
            glTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels);
        private static GLTexSubImage3D glTexSubImage3D;
        
        public static void TexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, nint pixels) =>
            glTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCopyTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        private static GLCopyTexSubImage3D glCopyTexSubImage3D;
        
        public static void CopyTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height) =>
            glCopyTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLActiveTexture(TextureUnit texture);
        private static GLActiveTexture glActiveTexture;
        
        public static void ActiveTexture(TextureUnit texture) =>
            glActiveTexture.Invoke(texture);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLSampleCoverage(float value, bool invert);
        private static GLSampleCoverage glSampleCoverage;
        
        public static void SampleCoverage(float value, bool invert) =>
            glSampleCoverage.Invoke(value, invert);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data);
        private static GLCompressedTexImage3D glCompressedTexImage3D;
        
        public static void CompressedTexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, nint data) =>
            glCompressedTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data);
        private static GLCompressedTexImage2D glCompressedTexImage2D;
        
        public static void CompressedTexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, nint data) =>
            glCompressedTexImage2D.Invoke(target, level, internalformat, width, height, border, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data);
        private static GLCompressedTexImage1D glCompressedTexImage1D;
        
        public static void CompressedTexImage1D(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, nint data) =>
            glCompressedTexImage1D.Invoke(target, level, internalformat, width, border, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data);
        private static GLCompressedTexSubImage3D glCompressedTexSubImage3D;
        
        public static void CompressedTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, InternalFormat format, int imageSize, nint data) =>
            glCompressedTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data);
        private static GLCompressedTexSubImage2D glCompressedTexSubImage2D;
        
        public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, InternalFormat format, int imageSize, nint data) =>
            glCompressedTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data);
        private static GLCompressedTexSubImage1D glCompressedTexSubImage1D;
        
        public static void CompressedTexSubImage1D(TextureTarget target, int level, int xoffset, int width, InternalFormat format, int imageSize, nint data) =>
            glCompressedTexSubImage1D.Invoke(target, level, xoffset, width, format, imageSize, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetCompressedTexImage(TextureTarget target, int level, out nint img);
        private static GLGetCompressedTexImage glGetCompressedTexImage;
        
        public static void GetCompressedTexImage(TextureTarget target, int level, out nint img) =>
            glGetCompressedTexImage.Invoke(target, level, out img);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
        private static GLBlendFuncSeparate glBlendFuncSeparate;
        
        public static void BlendFuncSeparate(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha) =>
            glBlendFuncSeparate.Invoke(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawArrays(PrimitiveType mode, int[] first, int[] count, int drawcount);
        private static GLMultiDrawArrays glMultiDrawArrays;
        
        public static void MultiDrawArrays(PrimitiveType mode, int[] first, int[] count, int drawcount) =>
            glMultiDrawArrays.Invoke(mode, first, count, drawcount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLMultiDrawElements(PrimitiveType mode, int[] count, DrawElementsType type, nint indices, int drawcount);
        private static GLMultiDrawElements glMultiDrawElements;
        
        public static void MultiDrawElements(PrimitiveType mode, int[] count, DrawElementsType type, nint indices, int drawcount) =>
            glMultiDrawElements.Invoke(mode, count, type, indices, drawcount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameterf(PointParameterNameARB pname, float param);
        private static GLPointParameterf glPointParameterf;
        
        public static void PointParameterf(PointParameterNameARB pname, float param) =>
            glPointParameterf.Invoke(pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameterfv(PointParameterNameARB pname, float[] parameters);
        private static GLPointParameterfv glPointParameterfv;
        
        public static void PointParameterfv(PointParameterNameARB pname, float[] parameters) =>
            glPointParameterfv.Invoke(pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameteri(PointParameterNameARB pname, int param);
        private static GLPointParameteri glPointParameteri;
        
        public static void PointParameteri(PointParameterNameARB pname, int param) =>
            glPointParameteri.Invoke(pname, param);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPointParameteriv(PointParameterNameARB pname, int[] parameters);
        private static GLPointParameteriv glPointParameteriv;
        
        public static void PointParameteriv(PointParameterNameARB pname, int[] parameters) =>
            glPointParameteriv.Invoke(pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribDivisor(uint index, uint divisor);
        private static GLVertexAttribDivisor glVertexAttribDivisor;
        
        public static void VertexAttribDivisor(uint index, uint divisor) =>
            glVertexAttribDivisor.Invoke(index, divisor);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetPointerv(GetPointervPName pname, out nint parameters);
        private static GLGetPointerv glGetPointerv;
        
        [GLExtension("GL_KHR_debug")]
        public static void GetPointerv(GetPointervPName pname, out nint parameters) =>
            glGetPointerv.Invoke(pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGenQueries(int n, out uint ids);
        private static GLGenQueries glGenQueries;
        
        public static void GenQueries(int n, out uint ids) =>
            glGenQueries.Invoke(n, out ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteQueries(int n, uint[] ids);
        private static GLDeleteQueries glDeleteQueries;
        
        public static void DeleteQueries(int n, uint[] ids) =>
            glDeleteQueries.Invoke(n, ids);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsQuery(uint id);
        private static GLIsQuery glIsQuery;
        
        public static bool IsQuery(uint id) =>
            glIsQuery.Invoke(id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginQuery(QueryTarget target, uint id);
        private static GLBeginQuery glBeginQuery;
        
        public static void BeginQuery(QueryTarget target, uint id) =>
            glBeginQuery.Invoke(target, id);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndQuery(QueryTarget target);
        private static GLEndQuery glEndQuery;
        
        public static void EndQuery(QueryTarget target) =>
            glEndQuery.Invoke(target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryiv(QueryTarget target, QueryParameterName pname, out int parameters);
        private static GLGetQueryiv glGetQueryiv;
        
        public static void GetQueryiv(QueryTarget target, QueryParameterName pname, out int parameters) =>
            glGetQueryiv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryObjectiv(uint id, QueryObjectParameterName pname, out int parameters);
        private static GLGetQueryObjectiv glGetQueryObjectiv;
        
        public static void GetQueryObjectiv(uint id, QueryObjectParameterName pname, out int parameters) =>
            glGetQueryObjectiv.Invoke(id, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetQueryObjectuiv(uint id, QueryObjectParameterName pname, out uint parameters);
        private static GLGetQueryObjectuiv glGetQueryObjectuiv;
        
        public static void GetQueryObjectuiv(uint id, QueryObjectParameterName pname, out uint parameters) =>
            glGetQueryObjectuiv.Invoke(id, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindBuffer(BufferTargetARB target, uint buffer);
        private static GLBindBuffer glBindBuffer;
        
        public static void BindBuffer(BufferTargetARB target, uint buffer) =>
            glBindBuffer.Invoke(target, buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteBuffers(int n, uint[] buffers);
        private static GLDeleteBuffers glDeleteBuffers;
        
        public static void DeleteBuffers(int n, uint[] buffers) =>
            glDeleteBuffers.Invoke(n, buffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGenBuffers(int n, out uint buffers);
        private static GLGenBuffers glGenBuffers;
        
        public static void GenBuffers(int n, out uint buffers) =>
            glGenBuffers.Invoke(n, out buffers);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsBuffer(uint buffer);
        private static GLIsBuffer glIsBuffer;
        
        public static bool IsBuffer(uint buffer) =>
            glIsBuffer.Invoke(buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferData(BufferTargetARB target, nint size, nint data, BufferUsageARB usage);
        private static GLBufferData glBufferData;
        
        public static void BufferData(BufferTargetARB target, nint size, nint data, BufferUsageARB usage) =>
            glBufferData.Invoke(target, size, data, usage);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBufferSubData(BufferTargetARB target, nint offset, nint size, nint data);
        private static GLBufferSubData glBufferSubData;
        
        public static void BufferSubData(BufferTargetARB target, nint offset, nint size, nint data) =>
            glBufferSubData.Invoke(target, offset, size, data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferSubData(BufferTargetARB target, nint offset, nint size, out nint data);
        private static GLGetBufferSubData glGetBufferSubData;
        
        public static void GetBufferSubData(BufferTargetARB target, nint offset, nint size, out nint data) =>
            glGetBufferSubData.Invoke(target, offset, size, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLMapBuffer(BufferTargetARB target, BufferAccessARB access);
        private static GLMapBuffer glMapBuffer;
        
        public static nint MapBuffer(BufferTargetARB target, BufferAccessARB access) =>
            glMapBuffer.Invoke(target, access);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLUnmapBuffer(BufferTargetARB target);
        private static GLUnmapBuffer glUnmapBuffer;
        
        public static bool UnmapBuffer(BufferTargetARB target) =>
            glUnmapBuffer.Invoke(target);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferParameteriv(BufferTargetARB target, BufferPNameARB pname, out int parameters);
        private static GLGetBufferParameteriv glGetBufferParameteriv;
        
        public static void GetBufferParameteriv(BufferTargetARB target, BufferPNameARB pname, out int parameters) =>
            glGetBufferParameteriv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferPointerv(BufferTargetARB target, BufferPointerNameARB pname, out nint parameters);
        private static GLGetBufferPointerv glGetBufferPointerv;
        
        public static void GetBufferPointerv(BufferTargetARB target, BufferPointerNameARB pname, out nint parameters) =>
            glGetBufferPointerv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBlendEquationSeparate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        private static GLBlendEquationSeparate glBlendEquationSeparate;
        
        public static void BlendEquationSeparate(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha) =>
            glBlendEquationSeparate.Invoke(modeRGB, modeAlpha);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawBuffers(int n, DrawBufferMode[] bufs);
        private static GLDrawBuffers glDrawBuffers;
        
        public static void DrawBuffers(int n, DrawBufferMode[] bufs) =>
            glDrawBuffers.Invoke(n, bufs);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilOpSeparate(TriangleFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
        private static GLStencilOpSeparate glStencilOpSeparate;
        
        public static void StencilOpSeparate(TriangleFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass) =>
            glStencilOpSeparate.Invoke(face, sfail, dpfail, dppass);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilFuncSeparate(TriangleFace face, StencilFunction func, int reference, uint mask);
        private static GLStencilFuncSeparate glStencilFuncSeparate;
        
        public static void StencilFuncSeparate(TriangleFace face, StencilFunction func, int reference, uint mask) =>
            glStencilFuncSeparate.Invoke(face, func, reference, mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLStencilMaskSeparate(TriangleFace face, uint mask);
        private static GLStencilMaskSeparate glStencilMaskSeparate;
        
        public static void StencilMaskSeparate(TriangleFace face, uint mask) =>
            glStencilMaskSeparate.Invoke(face, mask);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLAttachShader(uint program, uint shader);
        private static GLAttachShader glAttachShader;
        
        public static void AttachShader(uint program, uint shader) =>
            glAttachShader.Invoke(program, shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindAttribLocation(uint program, uint index, sbyte[] name);
        private static GLBindAttribLocation glBindAttribLocation;
        
        public static void BindAttribLocation(uint program, uint index, sbyte[] name) =>
            glBindAttribLocation.Invoke(program, index, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLCompileShader(uint shader);
        private static GLCompileShader glCompileShader;
        
        public static void CompileShader(uint shader) =>
            glCompileShader.Invoke(shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLCreateProgram();
        private static GLCreateProgram glCreateProgram;
        
        public static uint CreateProgram() =>
            glCreateProgram.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint GLCreateShader(ShaderType type);
        private static GLCreateShader glCreateShader;
        
        public static uint CreateShader(ShaderType type) =>
            glCreateShader.Invoke(type);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteProgram(uint program);
        private static GLDeleteProgram glDeleteProgram;
        
        public static void DeleteProgram(uint program) =>
            glDeleteProgram.Invoke(program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDeleteShader(uint shader);
        private static GLDeleteShader glDeleteShader;
        
        public static void DeleteShader(uint shader) =>
            glDeleteShader.Invoke(shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDetachShader(uint program, uint shader);
        private static GLDetachShader glDetachShader;
        
        public static void DetachShader(uint program, uint shader) =>
            glDetachShader.Invoke(program, shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisableVertexAttribArray(uint index);
        private static GLDisableVertexAttribArray glDisableVertexAttribArray;
        
        public static void DisableVertexAttribArray(uint index) =>
            glDisableVertexAttribArray.Invoke(index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnableVertexAttribArray(uint index);
        private static GLEnableVertexAttribArray glEnableVertexAttribArray;
        
        public static void EnableVertexAttribArray(uint index) =>
            glEnableVertexAttribArray.Invoke(index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out AttributeType type, out sbyte name);
        private static GLGetActiveAttrib glGetActiveAttrib;
        
        public static void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out AttributeType type, out sbyte name) =>
            glGetActiveAttrib.Invoke(program, index, bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out UniformType type, out sbyte name);
        private static GLGetActiveUniform glGetActiveUniform;
        
        public static void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out UniformType type, out sbyte name) =>
            glGetActiveUniform.Invoke(program, index, bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetAttachedShaders(uint program, int maxCount, out int count, out uint shaders);
        private static GLGetAttachedShaders glGetAttachedShaders;
        
        public static void GetAttachedShaders(uint program, int maxCount, out int count, out uint shaders) =>
            glGetAttachedShaders.Invoke(program, maxCount, out count, out shaders);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GLGetAttribLocation(uint program, sbyte[] name);
        private static GLGetAttribLocation glGetAttribLocation;
        
        public static int GetAttribLocation(uint program, sbyte[] name) =>
            glGetAttribLocation.Invoke(program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetProgramiv(uint program, ProgramPropertyARB pname, out int parameters);
        private static GLGetProgramiv glGetProgramiv;
        
        public static void GetProgramiv(uint program, ProgramPropertyARB pname, out int parameters) =>
            glGetProgramiv.Invoke(program, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetProgramInfoLog(uint program, int bufSize, out int length, out sbyte infoLog);
        private static GLGetProgramInfoLog glGetProgramInfoLog;
        
        public static void GetProgramInfoLog(uint program, int bufSize, out int length, out sbyte infoLog) =>
            glGetProgramInfoLog.Invoke(program, bufSize, out length, out infoLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetShaderiv(uint shader, ShaderParameterName pname, out int parameters);
        private static GLGetShaderiv glGetShaderiv;
        
        public static void GetShaderiv(uint shader, ShaderParameterName pname, out int parameters) =>
            glGetShaderiv.Invoke(shader, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetShaderInfoLog(uint shader, int bufSize, out int length, out sbyte infoLog);
        private static GLGetShaderInfoLog glGetShaderInfoLog;
        
        public static void GetShaderInfoLog(uint shader, int bufSize, out int length, out sbyte infoLog) =>
            glGetShaderInfoLog.Invoke(shader, bufSize, out length, out infoLog);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetShaderSource(uint shader, int bufSize, out int length, out sbyte source);
        private static GLGetShaderSource glGetShaderSource;
        
        public static void GetShaderSource(uint shader, int bufSize, out int length, out sbyte source) =>
            glGetShaderSource.Invoke(shader, bufSize, out length, out source);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GLGetUniformLocation(uint program, sbyte[] name);
        private static GLGetUniformLocation glGetUniformLocation;
        
        public static int GetUniformLocation(uint program, sbyte[] name) =>
            glGetUniformLocation.Invoke(program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetUniformfv(uint program, int location, out float parameters);
        private static GLGetUniformfv glGetUniformfv;
        
        public static void GetUniformfv(uint program, int location, out float parameters) =>
            glGetUniformfv.Invoke(program, location, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetUniformiv(uint program, int location, out int parameters);
        private static GLGetUniformiv glGetUniformiv;
        
        public static void GetUniformiv(uint program, int location, out int parameters) =>
            glGetUniformiv.Invoke(program, location, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribdv(uint index, VertexAttribPropertyARB pname, out double parameters);
        private static GLGetVertexAttribdv glGetVertexAttribdv;
        
        public static void GetVertexAttribdv(uint index, VertexAttribPropertyARB pname, out double parameters) =>
            glGetVertexAttribdv.Invoke(index, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribfv(uint index, VertexAttribPropertyARB pname, out float parameters);
        private static GLGetVertexAttribfv glGetVertexAttribfv;
        
        public static void GetVertexAttribfv(uint index, VertexAttribPropertyARB pname, out float parameters) =>
            glGetVertexAttribfv.Invoke(index, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribiv(uint index, VertexAttribPropertyARB pname, out int parameters);
        private static GLGetVertexAttribiv glGetVertexAttribiv;
        
        public static void GetVertexAttribiv(uint index, VertexAttribPropertyARB pname, out int parameters) =>
            glGetVertexAttribiv.Invoke(index, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribPointerv(uint index, VertexAttribPointerPropertyARB pname, out nint pointer);
        private static GLGetVertexAttribPointerv glGetVertexAttribPointerv;
        
        public static void GetVertexAttribPointerv(uint index, VertexAttribPointerPropertyARB pname, out nint pointer) =>
            glGetVertexAttribPointerv.Invoke(index, pname, out pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsProgram(uint program);
        private static GLIsProgram glIsProgram;
        
        public static bool IsProgram(uint program) =>
            glIsProgram.Invoke(program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsShader(uint shader);
        private static GLIsShader glIsShader;
        
        public static bool IsShader(uint shader) =>
            glIsShader.Invoke(shader);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLLinkProgram(uint program);
        private static GLLinkProgram glLinkProgram;
        
        public static void LinkProgram(uint program) =>
            glLinkProgram.Invoke(program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLShaderSource(uint shader, int count, sbyte str, int[] length);
        private static GLShaderSource glShaderSource;
        
        public static void ShaderSource(uint shader, int count, sbyte str, int[] length) =>
            glShaderSource.Invoke(shader, count, str, length);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUseProgram(uint program);
        private static GLUseProgram glUseProgram;
        
        public static void UseProgram(uint program) =>
            glUseProgram.Invoke(program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1f(int location, float v0);
        private static GLUniform1f glUniform1f;
        
        public static void Uniform1f(int location, float v0) =>
            glUniform1f.Invoke(location, v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2f(int location, float v0, float v1);
        private static GLUniform2f glUniform2f;
        
        public static void Uniform2f(int location, float v0, float v1) =>
            glUniform2f.Invoke(location, v0, v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3f(int location, float v0, float v1, float v2);
        private static GLUniform3f glUniform3f;
        
        public static void Uniform3f(int location, float v0, float v1, float v2) =>
            glUniform3f.Invoke(location, v0, v1, v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4f(int location, float v0, float v1, float v2, float v3);
        private static GLUniform4f glUniform4f;
        
        public static void Uniform4f(int location, float v0, float v1, float v2, float v3) =>
            glUniform4f.Invoke(location, v0, v1, v2, v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1i(int location, int v0);
        private static GLUniform1i glUniform1i;
        
        public static void Uniform1i(int location, int v0) =>
            glUniform1i.Invoke(location, v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2i(int location, int v0, int v1);
        private static GLUniform2i glUniform2i;
        
        public static void Uniform2i(int location, int v0, int v1) =>
            glUniform2i.Invoke(location, v0, v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3i(int location, int v0, int v1, int v2);
        private static GLUniform3i glUniform3i;
        
        public static void Uniform3i(int location, int v0, int v1, int v2) =>
            glUniform3i.Invoke(location, v0, v1, v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4i(int location, int v0, int v1, int v2, int v3);
        private static GLUniform4i glUniform4i;
        
        public static void Uniform4i(int location, int v0, int v1, int v2, int v3) =>
            glUniform4i.Invoke(location, v0, v1, v2, v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1fv(int location, int count, float[] value);
        private static GLUniform1fv glUniform1fv;
        
        public static void Uniform1fv(int location, int count, float[] value) =>
            glUniform1fv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2fv(int location, int count, float[] value);
        private static GLUniform2fv glUniform2fv;
        
        public static void Uniform2fv(int location, int count, float[] value) =>
            glUniform2fv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3fv(int location, int count, float[] value);
        private static GLUniform3fv glUniform3fv;
        
        public static void Uniform3fv(int location, int count, float[] value) =>
            glUniform3fv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4fv(int location, int count, float[] value);
        private static GLUniform4fv glUniform4fv;
        
        public static void Uniform4fv(int location, int count, float[] value) =>
            glUniform4fv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1iv(int location, int count, int[] value);
        private static GLUniform1iv glUniform1iv;
        
        public static void Uniform1iv(int location, int count, int[] value) =>
            glUniform1iv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2iv(int location, int count, int[] value);
        private static GLUniform2iv glUniform2iv;
        
        public static void Uniform2iv(int location, int count, int[] value) =>
            glUniform2iv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3iv(int location, int count, int[] value);
        private static GLUniform3iv glUniform3iv;
        
        public static void Uniform3iv(int location, int count, int[] value) =>
            glUniform3iv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4iv(int location, int count, int[] value);
        private static GLUniform4iv glUniform4iv;
        
        public static void Uniform4iv(int location, int count, int[] value) =>
            glUniform4iv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix2fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix2fv glUniformMatrix2fv;
        
        public static void UniformMatrix2fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix2fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix3fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix3fv glUniformMatrix3fv;
        
        public static void UniformMatrix3fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix3fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix4fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix4fv glUniformMatrix4fv;
        
        public static void UniformMatrix4fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix4fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLValidateProgram(uint program);
        private static GLValidateProgram glValidateProgram;
        
        public static void ValidateProgram(uint program) =>
            glValidateProgram.Invoke(program);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1d(uint index, double x);
        private static GLVertexAttrib1d glVertexAttrib1d;
        
        public static void VertexAttrib1d(uint index, double x) =>
            glVertexAttrib1d.Invoke(index, x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1dv(uint index, double[] v);
        private static GLVertexAttrib1dv glVertexAttrib1dv;
        
        public static void VertexAttrib1dv(uint index, double[] v) =>
            glVertexAttrib1dv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1f(uint index, float x);
        private static GLVertexAttrib1f glVertexAttrib1f;
        
        public static void VertexAttrib1f(uint index, float x) =>
            glVertexAttrib1f.Invoke(index, x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1fv(uint index, float[] v);
        private static GLVertexAttrib1fv glVertexAttrib1fv;
        
        public static void VertexAttrib1fv(uint index, float[] v) =>
            glVertexAttrib1fv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1s(uint index, short x);
        private static GLVertexAttrib1s glVertexAttrib1s;
        
        public static void VertexAttrib1s(uint index, short x) =>
            glVertexAttrib1s.Invoke(index, x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib1sv(uint index, short[] v);
        private static GLVertexAttrib1sv glVertexAttrib1sv;
        
        public static void VertexAttrib1sv(uint index, short[] v) =>
            glVertexAttrib1sv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2d(uint index, double x, double y);
        private static GLVertexAttrib2d glVertexAttrib2d;
        
        public static void VertexAttrib2d(uint index, double x, double y) =>
            glVertexAttrib2d.Invoke(index, x, y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2dv(uint index, double[] v);
        private static GLVertexAttrib2dv glVertexAttrib2dv;
        
        public static void VertexAttrib2dv(uint index, double[] v) =>
            glVertexAttrib2dv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2f(uint index, float x, float y);
        private static GLVertexAttrib2f glVertexAttrib2f;
        
        public static void VertexAttrib2f(uint index, float x, float y) =>
            glVertexAttrib2f.Invoke(index, x, y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2fv(uint index, float[] v);
        private static GLVertexAttrib2fv glVertexAttrib2fv;
        
        public static void VertexAttrib2fv(uint index, float[] v) =>
            glVertexAttrib2fv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2s(uint index, short x, short y);
        private static GLVertexAttrib2s glVertexAttrib2s;
        
        public static void VertexAttrib2s(uint index, short x, short y) =>
            glVertexAttrib2s.Invoke(index, x, y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib2sv(uint index, short[] v);
        private static GLVertexAttrib2sv glVertexAttrib2sv;
        
        public static void VertexAttrib2sv(uint index, short[] v) =>
            glVertexAttrib2sv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3d(uint index, double x, double y, double z);
        private static GLVertexAttrib3d glVertexAttrib3d;
        
        public static void VertexAttrib3d(uint index, double x, double y, double z) =>
            glVertexAttrib3d.Invoke(index, x, y, z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3dv(uint index, double[] v);
        private static GLVertexAttrib3dv glVertexAttrib3dv;
        
        public static void VertexAttrib3dv(uint index, double[] v) =>
            glVertexAttrib3dv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3f(uint index, float x, float y, float z);
        private static GLVertexAttrib3f glVertexAttrib3f;
        
        public static void VertexAttrib3f(uint index, float x, float y, float z) =>
            glVertexAttrib3f.Invoke(index, x, y, z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3fv(uint index, float[] v);
        private static GLVertexAttrib3fv glVertexAttrib3fv;
        
        public static void VertexAttrib3fv(uint index, float[] v) =>
            glVertexAttrib3fv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3s(uint index, short x, short y, short z);
        private static GLVertexAttrib3s glVertexAttrib3s;
        
        public static void VertexAttrib3s(uint index, short x, short y, short z) =>
            glVertexAttrib3s.Invoke(index, x, y, z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib3sv(uint index, short[] v);
        private static GLVertexAttrib3sv glVertexAttrib3sv;
        
        public static void VertexAttrib3sv(uint index, short[] v) =>
            glVertexAttrib3sv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nbv(uint index, sbyte[] v);
        private static GLVertexAttrib4Nbv glVertexAttrib4Nbv;
        
        public static void VertexAttrib4Nbv(uint index, sbyte[] v) =>
            glVertexAttrib4Nbv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Niv(uint index, int[] v);
        private static GLVertexAttrib4Niv glVertexAttrib4Niv;
        
        public static void VertexAttrib4Niv(uint index, int[] v) =>
            glVertexAttrib4Niv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nsv(uint index, short[] v);
        private static GLVertexAttrib4Nsv glVertexAttrib4Nsv;
        
        public static void VertexAttrib4Nsv(uint index, short[] v) =>
            glVertexAttrib4Nsv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
        private static GLVertexAttrib4Nub glVertexAttrib4Nub;
        
        public static void VertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w) =>
            glVertexAttrib4Nub.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nubv(uint index, byte[] v);
        private static GLVertexAttrib4Nubv glVertexAttrib4Nubv;
        
        public static void VertexAttrib4Nubv(uint index, byte[] v) =>
            glVertexAttrib4Nubv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nuiv(uint index, uint[] v);
        private static GLVertexAttrib4Nuiv glVertexAttrib4Nuiv;
        
        public static void VertexAttrib4Nuiv(uint index, uint[] v) =>
            glVertexAttrib4Nuiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4Nusv(uint index, ushort[] v);
        private static GLVertexAttrib4Nusv glVertexAttrib4Nusv;
        
        public static void VertexAttrib4Nusv(uint index, ushort[] v) =>
            glVertexAttrib4Nusv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4bv(uint index, sbyte[] v);
        private static GLVertexAttrib4bv glVertexAttrib4bv;
        
        public static void VertexAttrib4bv(uint index, sbyte[] v) =>
            glVertexAttrib4bv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4d(uint index, double x, double y, double z, double w);
        private static GLVertexAttrib4d glVertexAttrib4d;
        
        public static void VertexAttrib4d(uint index, double x, double y, double z, double w) =>
            glVertexAttrib4d.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4dv(uint index, double[] v);
        private static GLVertexAttrib4dv glVertexAttrib4dv;
        
        public static void VertexAttrib4dv(uint index, double[] v) =>
            glVertexAttrib4dv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4f(uint index, float x, float y, float z, float w);
        private static GLVertexAttrib4f glVertexAttrib4f;
        
        public static void VertexAttrib4f(uint index, float x, float y, float z, float w) =>
            glVertexAttrib4f.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4fv(uint index, float[] v);
        private static GLVertexAttrib4fv glVertexAttrib4fv;
        
        public static void VertexAttrib4fv(uint index, float[] v) =>
            glVertexAttrib4fv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4iv(uint index, int[] v);
        private static GLVertexAttrib4iv glVertexAttrib4iv;
        
        public static void VertexAttrib4iv(uint index, int[] v) =>
            glVertexAttrib4iv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4s(uint index, short x, short y, short z, short w);
        private static GLVertexAttrib4s glVertexAttrib4s;
        
        public static void VertexAttrib4s(uint index, short x, short y, short z, short w) =>
            glVertexAttrib4s.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4sv(uint index, short[] v);
        private static GLVertexAttrib4sv glVertexAttrib4sv;
        
        public static void VertexAttrib4sv(uint index, short[] v) =>
            glVertexAttrib4sv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4ubv(uint index, byte[] v);
        private static GLVertexAttrib4ubv glVertexAttrib4ubv;
        
        public static void VertexAttrib4ubv(uint index, byte[] v) =>
            glVertexAttrib4ubv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4uiv(uint index, uint[] v);
        private static GLVertexAttrib4uiv glVertexAttrib4uiv;
        
        public static void VertexAttrib4uiv(uint index, uint[] v) =>
            glVertexAttrib4uiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttrib4usv(uint index, ushort[] v);
        private static GLVertexAttrib4usv glVertexAttrib4usv;
        
        public static void VertexAttrib4usv(uint index, ushort[] v) =>
            glVertexAttrib4usv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer);
        private static GLVertexAttribPointer glVertexAttribPointer;
        
        public static void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, nint pointer) =>
            glVertexAttribPointer.Invoke(index, size, type, normalized, stride, pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix2x3fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix2x3fv glUniformMatrix2x3fv;
        
        public static void UniformMatrix2x3fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix2x3fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix3x2fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix3x2fv glUniformMatrix3x2fv;
        
        public static void UniformMatrix3x2fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix3x2fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix2x4fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix2x4fv glUniformMatrix2x4fv;
        
        public static void UniformMatrix2x4fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix2x4fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix4x2fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix4x2fv glUniformMatrix4x2fv;
        
        public static void UniformMatrix4x2fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix4x2fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix3x4fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix3x4fv glUniformMatrix3x4fv;
        
        public static void UniformMatrix3x4fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix3x4fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniformMatrix4x3fv(int location, int count, bool transpose, float[] value);
        private static GLUniformMatrix4x3fv glUniformMatrix4x3fv;
        
        public static void UniformMatrix4x3fv(int location, int count, bool transpose, float[] value) =>
            glUniformMatrix4x3fv.Invoke(location, count, transpose, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLColorMaski(uint index, bool r, bool g, bool b, bool a);
        private static GLColorMaski glColorMaski;
        
        public static void ColorMaski(uint index, bool r, bool g, bool b, bool a) =>
            glColorMaski.Invoke(index, r, g, b, a);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBooleani_v(BufferTargetARB target, uint index, out bool data);
        private static GLGetBooleani_v glGetBooleani_v;
        
        public static void GetBooleani_v(BufferTargetARB target, uint index, out bool data) =>
            glGetBooleani_v.Invoke(target, index, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEnablei(EnableCap target, uint index);
        private static GLEnablei glEnablei;
        
        public static void Enablei(EnableCap target, uint index) =>
            glEnablei.Invoke(target, index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDisablei(EnableCap target, uint index);
        private static GLDisablei glDisablei;
        
        public static void Disablei(EnableCap target, uint index) =>
            glDisablei.Invoke(target, index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool GLIsEnabledi(EnableCap target, uint index);
        private static GLIsEnabledi glIsEnabledi;
        
        public static bool IsEnabledi(EnableCap target, uint index) =>
            glIsEnabledi.Invoke(target, index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginTransformFeedback(PrimitiveType primitiveMode);
        private static GLBeginTransformFeedback glBeginTransformFeedback;
        
        public static void BeginTransformFeedback(PrimitiveType primitiveMode) =>
            glBeginTransformFeedback.Invoke(primitiveMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndTransformFeedback();
        private static GLEndTransformFeedback glEndTransformFeedback;
        
        public static void EndTransformFeedback() =>
            glEndTransformFeedback.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTransformFeedbackVaryings(uint program, int count, sbyte varyings, TransformFeedbackBufferMode bufferMode);
        private static GLTransformFeedbackVaryings glTransformFeedbackVaryings;
        
        public static void TransformFeedbackVaryings(uint program, int count, sbyte varyings, TransformFeedbackBufferMode bufferMode) =>
            glTransformFeedbackVaryings.Invoke(program, count, varyings, bufferMode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTransformFeedbackVarying(uint program, uint index, int bufSize, out int length, out int size, out AttributeType type, out sbyte name);
        private static GLGetTransformFeedbackVarying glGetTransformFeedbackVarying;
        
        public static void GetTransformFeedbackVarying(uint program, uint index, int bufSize, out int length, out int size, out AttributeType type, out sbyte name) =>
            glGetTransformFeedbackVarying.Invoke(program, index, bufSize, out length, out size, out type, out name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClampColor(ClampColorTargetARB target, ClampColorModeARB clamp);
        private static GLClampColor glClampColor;
        
        public static void ClampColor(ClampColorTargetARB target, ClampColorModeARB clamp) =>
            glClampColor.Invoke(target, clamp);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBeginConditionalRender(uint id, ConditionalRenderMode mode);
        private static GLBeginConditionalRender glBeginConditionalRender;
        
        public static void BeginConditionalRender(uint id, ConditionalRenderMode mode) =>
            glBeginConditionalRender.Invoke(id, mode);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLEndConditionalRender();
        private static GLEndConditionalRender glEndConditionalRender;
        
        public static void EndConditionalRender() =>
            glEndConditionalRender.Invoke();
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribIPointer(uint index, int size, VertexAttribIType type, int stride, nint pointer);
        private static GLVertexAttribIPointer glVertexAttribIPointer;
        
        public static void VertexAttribIPointer(uint index, int size, VertexAttribIType type, int stride, nint pointer) =>
            glVertexAttribIPointer.Invoke(index, size, type, stride, pointer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribIiv(uint index, VertexAttribEnum pname, out int parameters);
        private static GLGetVertexAttribIiv glGetVertexAttribIiv;
        
        public static void GetVertexAttribIiv(uint index, VertexAttribEnum pname, out int parameters) =>
            glGetVertexAttribIiv.Invoke(index, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetVertexAttribIuiv(uint index, VertexAttribEnum pname, out uint parameters);
        private static GLGetVertexAttribIuiv glGetVertexAttribIuiv;
        
        public static void GetVertexAttribIuiv(uint index, VertexAttribEnum pname, out uint parameters) =>
            glGetVertexAttribIuiv.Invoke(index, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1i(uint index, int x);
        private static GLVertexAttribI1i glVertexAttribI1i;
        
        public static void VertexAttribI1i(uint index, int x) =>
            glVertexAttribI1i.Invoke(index, x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2i(uint index, int x, int y);
        private static GLVertexAttribI2i glVertexAttribI2i;
        
        public static void VertexAttribI2i(uint index, int x, int y) =>
            glVertexAttribI2i.Invoke(index, x, y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3i(uint index, int x, int y, int z);
        private static GLVertexAttribI3i glVertexAttribI3i;
        
        public static void VertexAttribI3i(uint index, int x, int y, int z) =>
            glVertexAttribI3i.Invoke(index, x, y, z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4i(uint index, int x, int y, int z, int w);
        private static GLVertexAttribI4i glVertexAttribI4i;
        
        public static void VertexAttribI4i(uint index, int x, int y, int z, int w) =>
            glVertexAttribI4i.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1ui(uint index, uint x);
        private static GLVertexAttribI1ui glVertexAttribI1ui;
        
        public static void VertexAttribI1ui(uint index, uint x) =>
            glVertexAttribI1ui.Invoke(index, x);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2ui(uint index, uint x, uint y);
        private static GLVertexAttribI2ui glVertexAttribI2ui;
        
        public static void VertexAttribI2ui(uint index, uint x, uint y) =>
            glVertexAttribI2ui.Invoke(index, x, y);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3ui(uint index, uint x, uint y, uint z);
        private static GLVertexAttribI3ui glVertexAttribI3ui;
        
        public static void VertexAttribI3ui(uint index, uint x, uint y, uint z) =>
            glVertexAttribI3ui.Invoke(index, x, y, z);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        private static GLVertexAttribI4ui glVertexAttribI4ui;
        
        public static void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w) =>
            glVertexAttribI4ui.Invoke(index, x, y, z, w);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1iv(uint index, int[] v);
        private static GLVertexAttribI1iv glVertexAttribI1iv;
        
        public static void VertexAttribI1iv(uint index, int[] v) =>
            glVertexAttribI1iv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2iv(uint index, int[] v);
        private static GLVertexAttribI2iv glVertexAttribI2iv;
        
        public static void VertexAttribI2iv(uint index, int[] v) =>
            glVertexAttribI2iv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3iv(uint index, int[] v);
        private static GLVertexAttribI3iv glVertexAttribI3iv;
        
        public static void VertexAttribI3iv(uint index, int[] v) =>
            glVertexAttribI3iv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4iv(uint index, int[] v);
        private static GLVertexAttribI4iv glVertexAttribI4iv;
        
        public static void VertexAttribI4iv(uint index, int[] v) =>
            glVertexAttribI4iv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI1uiv(uint index, uint[] v);
        private static GLVertexAttribI1uiv glVertexAttribI1uiv;
        
        public static void VertexAttribI1uiv(uint index, uint[] v) =>
            glVertexAttribI1uiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI2uiv(uint index, uint[] v);
        private static GLVertexAttribI2uiv glVertexAttribI2uiv;
        
        public static void VertexAttribI2uiv(uint index, uint[] v) =>
            glVertexAttribI2uiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI3uiv(uint index, uint[] v);
        private static GLVertexAttribI3uiv glVertexAttribI3uiv;
        
        public static void VertexAttribI3uiv(uint index, uint[] v) =>
            glVertexAttribI3uiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4uiv(uint index, uint[] v);
        private static GLVertexAttribI4uiv glVertexAttribI4uiv;
        
        public static void VertexAttribI4uiv(uint index, uint[] v) =>
            glVertexAttribI4uiv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4bv(uint index, sbyte[] v);
        private static GLVertexAttribI4bv glVertexAttribI4bv;
        
        public static void VertexAttribI4bv(uint index, sbyte[] v) =>
            glVertexAttribI4bv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4sv(uint index, short[] v);
        private static GLVertexAttribI4sv glVertexAttribI4sv;
        
        public static void VertexAttribI4sv(uint index, short[] v) =>
            glVertexAttribI4sv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4ubv(uint index, byte[] v);
        private static GLVertexAttribI4ubv glVertexAttribI4ubv;
        
        public static void VertexAttribI4ubv(uint index, byte[] v) =>
            glVertexAttribI4ubv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLVertexAttribI4usv(uint index, ushort[] v);
        private static GLVertexAttribI4usv glVertexAttribI4usv;
        
        public static void VertexAttribI4usv(uint index, ushort[] v) =>
            glVertexAttribI4usv.Invoke(index, v);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetUniformuiv(uint program, int location, out uint parameters);
        private static GLGetUniformuiv glGetUniformuiv;
        
        public static void GetUniformuiv(uint program, int location, out uint parameters) =>
            glGetUniformuiv.Invoke(program, location, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLBindFragDataLocation(uint program, uint color, sbyte[] name);
        private static GLBindFragDataLocation glBindFragDataLocation;
        
        public static void BindFragDataLocation(uint program, uint color, sbyte[] name) =>
            glBindFragDataLocation.Invoke(program, color, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GLGetFragDataLocation(uint program, sbyte[] name);
        private static GLGetFragDataLocation glGetFragDataLocation;
        
        public static int GetFragDataLocation(uint program, sbyte[] name) =>
            glGetFragDataLocation.Invoke(program, name);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1ui(int location, uint v0);
        private static GLUniform1ui glUniform1ui;
        
        public static void Uniform1ui(int location, uint v0) =>
            glUniform1ui.Invoke(location, v0);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2ui(int location, uint v0, uint v1);
        private static GLUniform2ui glUniform2ui;
        
        public static void Uniform2ui(int location, uint v0, uint v1) =>
            glUniform2ui.Invoke(location, v0, v1);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3ui(int location, uint v0, uint v1, uint v2);
        private static GLUniform3ui glUniform3ui;
        
        public static void Uniform3ui(int location, uint v0, uint v1, uint v2) =>
            glUniform3ui.Invoke(location, v0, v1, v2);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);
        private static GLUniform4ui glUniform4ui;
        
        public static void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3) =>
            glUniform4ui.Invoke(location, v0, v1, v2, v3);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform1uiv(int location, int count, uint[] value);
        private static GLUniform1uiv glUniform1uiv;
        
        public static void Uniform1uiv(int location, int count, uint[] value) =>
            glUniform1uiv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform2uiv(int location, int count, uint[] value);
        private static GLUniform2uiv glUniform2uiv;
        
        public static void Uniform2uiv(int location, int count, uint[] value) =>
            glUniform2uiv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform3uiv(int location, int count, uint[] value);
        private static GLUniform3uiv glUniform3uiv;
        
        public static void Uniform3uiv(int location, int count, uint[] value) =>
            glUniform3uiv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLUniform4uiv(int location, int count, uint[] value);
        private static GLUniform4uiv glUniform4uiv;
        
        public static void Uniform4uiv(int location, int count, uint[] value) =>
            glUniform4uiv.Invoke(location, count, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameterIiv(TextureTarget target, TextureParameterName pname, int[] parameters);
        private static GLTexParameterIiv glTexParameterIiv;
        
        public static void TexParameterIiv(TextureTarget target, TextureParameterName pname, int[] parameters) =>
            glTexParameterIiv.Invoke(target, pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexParameterIuiv(TextureTarget target, TextureParameterName pname, uint[] parameters);
        private static GLTexParameterIuiv glTexParameterIuiv;
        
        public static void TexParameterIuiv(TextureTarget target, TextureParameterName pname, uint[] parameters) =>
            glTexParameterIuiv.Invoke(target, pname, parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexParameterIiv(TextureTarget target, GetTextureParameter pname, out int parameters);
        private static GLGetTexParameterIiv glGetTexParameterIiv;
        
        public static void GetTexParameterIiv(TextureTarget target, GetTextureParameter pname, out int parameters) =>
            glGetTexParameterIiv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetTexParameterIuiv(TextureTarget target, GetTextureParameter pname, out uint parameters);
        private static GLGetTexParameterIuiv glGetTexParameterIuiv;
        
        public static void GetTexParameterIuiv(TextureTarget target, GetTextureParameter pname, out uint parameters) =>
            glGetTexParameterIuiv.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferiv(Buffer buffer, int drawbuffer, int[] value);
        private static GLClearBufferiv glClearBufferiv;
        
        public static void ClearBufferiv(Buffer buffer, int drawbuffer, int[] value) =>
            glClearBufferiv.Invoke(buffer, drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferuiv(Buffer buffer, int drawbuffer, uint[] value);
        private static GLClearBufferuiv glClearBufferuiv;
        
        public static void ClearBufferuiv(Buffer buffer, int drawbuffer, uint[] value) =>
            glClearBufferuiv.Invoke(buffer, drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferfv(Buffer buffer, int drawbuffer, float[] value);
        private static GLClearBufferfv glClearBufferfv;
        
        public static void ClearBufferfv(Buffer buffer, int drawbuffer, float[] value) =>
            glClearBufferfv.Invoke(buffer, drawbuffer, value);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLClearBufferfi(Buffer buffer, int drawbuffer, float depth, int stencil);
        private static GLClearBufferfi glClearBufferfi;
        
        public static void ClearBufferfi(Buffer buffer, int drawbuffer, float depth, int stencil) =>
            glClearBufferfi.Invoke(buffer, drawbuffer, depth, stencil);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate nint GLGetStringi(StringName name, uint index);
        private static GLGetStringi glGetStringi;
        
        public static nint GetStringi(StringName name, uint index) =>
            glGetStringi.Invoke(name, index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawArraysInstanced(PrimitiveType mode, int first, int count, int instancecount);
        private static GLDrawArraysInstanced glDrawArraysInstanced;
        
        public static void DrawArraysInstanced(PrimitiveType mode, int first, int count, int instancecount) =>
            glDrawArraysInstanced.Invoke(mode, first, count, instancecount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLDrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount);
        private static GLDrawElementsInstanced glDrawElementsInstanced;
        
        public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, nint indices, int instancecount) =>
            glDrawElementsInstanced.Invoke(mode, count, type, indices, instancecount);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLTexBuffer(TextureTarget target, SizedInternalFormat internalformat, uint buffer);
        private static GLTexBuffer glTexBuffer;
        
        public static void TexBuffer(TextureTarget target, SizedInternalFormat internalformat, uint buffer) =>
            glTexBuffer.Invoke(target, internalformat, buffer);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLPrimitiveRestartIndex(uint index);
        private static GLPrimitiveRestartIndex glPrimitiveRestartIndex;
        
        public static void PrimitiveRestartIndex(uint index) =>
            glPrimitiveRestartIndex.Invoke(index);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetInteger64i_v(GetPName target, uint index, out long data);
        private static GLGetInteger64i_v glGetInteger64i_v;
        
        public static void GetInteger64i_v(GetPName target, uint index, out long data) =>
            glGetInteger64i_v.Invoke(target, index, out data);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLGetBufferParameteri64v(BufferTargetARB target, BufferPNameARB pname, out long parameters);
        private static GLGetBufferParameteri64v glGetBufferParameteri64v;
        
        public static void GetBufferParameteri64v(BufferTargetARB target, BufferPNameARB pname, out long parameters) =>
            glGetBufferParameteri64v.Invoke(target, pname, out parameters);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void GLFramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level);
        private static GLFramebufferTexture glFramebufferTexture;
        
        public static void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level) =>
            glFramebufferTexture.Invoke(target, attachment, texture, level);
        
        public static void Initialize(GetProcAddressHandler loader)
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
            glMinSampleShading = Marshal.GetDelegateForFunctionPointer<GLMinSampleShading>(loader.Invoke("glMinSampleShading"));
            glPrimitiveBoundingBox = Marshal.GetDelegateForFunctionPointer<GLPrimitiveBoundingBox>(loader.Invoke("glPrimitiveBoundingBox"));
            glBlendFuncSeparatei = Marshal.GetDelegateForFunctionPointer<GLBlendFuncSeparatei>(loader.Invoke("glBlendFuncSeparatei"));
            glBlendFunci = Marshal.GetDelegateForFunctionPointer<GLBlendFunci>(loader.Invoke("glBlendFunci"));
            glBlendEquationSeparatei = Marshal.GetDelegateForFunctionPointer<GLBlendEquationSeparatei>(loader.Invoke("glBlendEquationSeparatei"));
            glBlendEquationi = Marshal.GetDelegateForFunctionPointer<GLBlendEquationi>(loader.Invoke("glBlendEquationi"));
            glBlendBarrier = Marshal.GetDelegateForFunctionPointer<GLBlendBarrier>(loader.Invoke("glBlendBarrier"));
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
