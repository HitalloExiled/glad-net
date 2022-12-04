using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics.CodeAnalysis;

namespace OpenGL
{
    public delegate IntPtr GetProcAddressHandler(string funcName);
    public delegate void DebugProc(int source, int type, uint id, int severity, IntPtr length, byte[] message, IntPtr userParam);
    public delegate void DebugProcAMD(uint id, int category, int severity, IntPtr length, byte[] message, IntPtr userParam);
    public delegate void VulkanDebugProcNV();
    
    
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
        MultisampleBitARB = 0x20000000,
        MultisampleBitEXT = 0x20000000,
        MultisampleBit3DFX = 0x20000000,
        AllAttribBits = 0xFFFFFFFF
    }
    
    [Flags]
    public enum BufferStorageMask : uint
    {
        DynamicStorageBit = 0x0100,
        DynamicStorageBitEXT = 0x0100,
        ClientStorageBit = 0x0200,
        ClientStorageBitEXT = 0x0200,
        SparseStorageBitARB = 0x0400,
        LgpuSeparateStorageBitNvx = 0x0800,
        PerGpuStorageBitNV = 0x0800,
        ExternalStorageBitNvx = 0x2000
    }
    
    [Flags]
    public enum ClearBufferMask : uint
    {
        CoverageBufferBitNV = 0x00008000
    }
    
    [Flags]
    public enum ClientAttribMask : uint
    {
        ClientPixelStoreBit = 0x00000001,
        ClientVertexArrayBit = 0x00000002,
        ClientAllAttribBits = 0xFFFFFFFF
    }
    
    [Flags]
    public enum ContextFlagMask : uint
    {
        ContextFlagForwardCompatibleBit = 0x00000001,
        ContextFlagDebugBit = 0x00000002,
        ContextFlagDebugBitKhr = 0x00000002,
        ContextFlagRobustAccessBit = 0x00000004,
        ContextFlagRobustAccessBitARB = 0x00000004,
        ContextFlagNoErrorBit = 0x00000008,
        ContextFlagNoErrorBitKhr = 0x00000008,
        ContextFlagProtectedContentBitEXT = 0x00000010
    }
    
    [Flags]
    public enum ContextProfileMask : uint
    {
        ContextCoreProfileBit = 0x00000001,
        ContextCompatibilityProfileBit = 0x00000002
    }
    
    [Flags]
    public enum MapBufferAccessMask : uint
    {
        MapReadBit = 0x0001,
        MapReadBitEXT = 0x0001,
        MapWriteBit = 0x0002,
        MapWriteBitEXT = 0x0002,
        MapInvalidateRangeBit = 0x0004,
        MapInvalidateRangeBitEXT = 0x0004,
        MapInvalidateBufferBit = 0x0008,
        MapInvalidateBufferBitEXT = 0x0008,
        MapFlushExplicitBit = 0x0010,
        MapFlushExplicitBitEXT = 0x0010,
        MapUnsynchronizedBit = 0x0020,
        MapUnsynchronizedBitEXT = 0x0020,
        MapPersistentBit = 0x0040,
        MapPersistentBitEXT = 0x0040,
        MapCoherentBit = 0x0080,
        MapCoherentBitEXT = 0x0080
    }
    
    [Flags]
    public enum MemoryBarrierMask : uint
    {
        VertexAttribArrayBarrierBit = 0x00000001,
        VertexAttribArrayBarrierBitEXT = 0x00000001,
        ElementArrayBarrierBit = 0x00000002,
        ElementArrayBarrierBitEXT = 0x00000002,
        UniformBarrierBit = 0x00000004,
        UniformBarrierBitEXT = 0x00000004,
        TextureFetchBarrierBit = 0x00000008,
        TextureFetchBarrierBitEXT = 0x00000008,
        ShaderGlobalAccessBarrierBitNV = 0x00000010,
        ShaderImageAccessBarrierBit = 0x00000020,
        ShaderImageAccessBarrierBitEXT = 0x00000020,
        CommandBarrierBit = 0x00000040,
        CommandBarrierBitEXT = 0x00000040,
        PixelBufferBarrierBit = 0x00000080,
        PixelBufferBarrierBitEXT = 0x00000080,
        TextureUpdateBarrierBit = 0x00000100,
        TextureUpdateBarrierBitEXT = 0x00000100,
        BufferUpdateBarrierBit = 0x00000200,
        BufferUpdateBarrierBitEXT = 0x00000200,
        FramebufferBarrierBit = 0x00000400,
        FramebufferBarrierBitEXT = 0x00000400,
        TransformFeedbackBarrierBit = 0x00000800,
        TransformFeedbackBarrierBitEXT = 0x00000800,
        AtomicCounterBarrierBit = 0x00001000,
        AtomicCounterBarrierBitEXT = 0x00001000,
        ShaderStorageBarrierBit = 0x00002000,
        ClientMappedBufferBarrierBit = 0x00004000,
        ClientMappedBufferBarrierBitEXT = 0x00004000,
        QueryBufferBarrierBit = 0x00008000,
        AllBarrierBits = 0xFFFFFFFF,
        AllBarrierBitsEXT = 0xFFFFFFFF
    }
    
    [Flags]
    public enum OcclusionQueryEventMaskAMD : uint
    {
        QueryDepthPassEventBitAMD = 0x00000001,
        QueryDepthFailEventBitAMD = 0x00000002,
        QueryStencilFailEventBitAMD = 0x00000004,
        QueryDepthBoundsFailEventBitAMD = 0x00000008,
        QueryAllEventBitsAMD = 0xFFFFFFFF
    }
    
    [Flags]
    public enum SyncObjectMask : uint
    {
        SyncFlushCommandsBit = 0x00000001,
        SyncFlushCommandsBitAPPLE = 0x00000001
    }
    
    [Flags]
    public enum UseProgramStageMask : uint
    {
        VertexShaderBit = 0x00000001,
        VertexShaderBitEXT = 0x00000001,
        FragmentShaderBit = 0x00000002,
        FragmentShaderBitEXT = 0x00000002,
        GeometryShaderBit = 0x00000004,
        GeometryShaderBitEXT = 0x00000004,
        GeometryShaderBitOES = 0x00000004,
        TessControlShaderBit = 0x00000008,
        TessControlShaderBitEXT = 0x00000008,
        TessControlShaderBitOES = 0x00000008,
        TessEvaluationShaderBit = 0x00000010,
        TessEvaluationShaderBitEXT = 0x00000010,
        TessEvaluationShaderBitOES = 0x00000010,
        ComputeShaderBit = 0x00000020,
        MeshShaderBitNV = 0x00000040,
        TaskShaderBitNV = 0x00000080,
        AllShaderBits = 0xFFFFFFFF,
        AllShaderBitsEXT = 0xFFFFFFFF
    }
    
    [Flags]
    public enum SubgroupSupportedFeatures : uint
    {
        SubgroupFeatureBasicBitKhr = 0x00000001,
        SubgroupFeatureVoteBitKhr = 0x00000002,
        SubgroupFeatureArithmeticBitKhr = 0x00000004,
        SubgroupFeatureBallotBitKhr = 0x00000008,
        SubgroupFeatureShuffleBitKhr = 0x00000010,
        SubgroupFeatureShuffleRelativeBitKhr = 0x00000020,
        SubgroupFeatureClusteredBitKhr = 0x00000040,
        SubgroupFeatureQuadBitKhr = 0x00000080,
        SubgroupFeaturePartitionedBitNV = 0x00000100
    }
    
    [Flags]
    public enum TextureStorageMaskAMD : uint
    {
        TextureStorageSparseBitAMD = 0x00000001
    }
    
    [Flags]
    public enum FragmentShaderDestMaskATI : uint
    {
        RedBitATI = 0x00000001,
        GreenBitATI = 0x00000002,
        BlueBitATI = 0x00000004
    }
    
    [Flags]
    public enum FragmentShaderDestModMaskATI : uint
    {
        TwoXBitATI = 0x00000001,
        FourXBitATI = 0x00000002,
        EightXBitATI = 0x00000004,
        HalfBitATI = 0x00000008,
        QuarterBitATI = 0x00000010,
        EighthBitATI = 0x00000020,
        SaturateBitATI = 0x00000040
    }
    
    [Flags]
    public enum FragmentShaderColorModMaskATI : uint
    {
        CompBitATI = 0x00000002,
        NegateBitATI = 0x00000004,
        BiasBitATI = 0x00000008
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
        TraceAllBitsMESA = 0xFFFF
    }
    
    [Flags]
    public enum PathRenderingMaskNV : uint
    {
        BoldBitNV = 0x01,
        ItalicBitNV = 0x02,
        GlyphWidthBitNV = 0x01,
        GlyphHeightBitNV = 0x02,
        GlyphHorizontalBearingXBitNV = 0x04,
        GlyphHorizontalBearingYBitNV = 0x08,
        GlyphHorizontalBearingAdvanceBitNV = 0x10,
        GlyphVerticalBearingXBitNV = 0x20,
        GlyphVerticalBearingYBitNV = 0x40,
        GlyphVerticalBearingAdvanceBitNV = 0x80,
        GlyphHasKerningBitNV = 0x100,
        FontXMinBoundsBitNV = 0x00010000,
        FontYMinBoundsBitNV = 0x00020000,
        FontXMaxBoundsBitNV = 0x00040000,
        FontYMaxBoundsBitNV = 0x00080000,
        FontUnitsPerEmBitNV = 0x00100000,
        FontAscenderBitNV = 0x00200000,
        FontDescenderBitNV = 0x00400000,
        FontHeightBitNV = 0x00800000,
        FontMaxAdvanceWidthBitNV = 0x01000000,
        FontMaxAdvanceHeightBitNV = 0x02000000,
        FontUnderlinePositionBitNV = 0x04000000,
        FontUnderlineThicknessBitNV = 0x08000000,
        FontHasKerningBitNV = 0x10000000,
        FontNumGlyphIndicesBitNV = 0x20000000
    }
    
    [Flags]
    public enum PerformanceQueryCapsMaskINTEL : uint
    {
        PerfquerySingleContextINTEL = 0x00000000,
        PerfqueryGlobalContextINTEL = 0x00000001
    }
    
    [Flags]
    public enum VertexHintsMaskPGI : uint
    {
        Vertex23BitPGI = 0x00000004,
        Vertex4BitPGI = 0x00000008,
        Color3BitPGI = 0x00010000,
        Color4BitPGI = 0x00020000,
        EdgeflagBitPGI = 0x00040000,
        IndexBitPGI = 0x00080000,
        MatAmbientBitPGI = 0x00100000,
        MatAmbientAndDiffuseBitPGI = 0x00200000,
        MatDiffuseBitPGI = 0x00400000,
        MatEmissionBitPGI = 0x00800000,
        MatColorIndexesBitPGI = 0x01000000,
        MatShininessBitPGI = 0x02000000,
        MatSpecularBitPGI = 0x04000000,
        NormalBitPGI = 0x08000000,
        Texcoord1BitPGI = 0x10000000,
        Texcoord2BitPGI = 0x20000000,
        Texcoord3BitPGI = 0x40000000,
        Texcoord4BitPGI = 0x80000000
    }
    
    [Flags]
    public enum BufferBitQCOM : uint
    {
        ColorBufferBit0QCOM = 0x00000001,
        ColorBufferBit1QCOM = 0x00000002,
        ColorBufferBit2QCOM = 0x00000004,
        ColorBufferBit3QCOM = 0x00000008,
        ColorBufferBit4QCOM = 0x00000010,
        ColorBufferBit5QCOM = 0x00000020,
        ColorBufferBit6QCOM = 0x00000040,
        ColorBufferBit7QCOM = 0x00000080,
        DepthBufferBit0QCOM = 0x00000100,
        DepthBufferBit1QCOM = 0x00000200,
        DepthBufferBit2QCOM = 0x00000400,
        DepthBufferBit3QCOM = 0x00000800,
        DepthBufferBit4QCOM = 0x00001000,
        DepthBufferBit5QCOM = 0x00002000,
        DepthBufferBit6QCOM = 0x00004000,
        DepthBufferBit7QCOM = 0x00008000,
        StencilBufferBit0QCOM = 0x00010000,
        StencilBufferBit1QCOM = 0x00020000,
        StencilBufferBit2QCOM = 0x00040000,
        StencilBufferBit3QCOM = 0x00080000,
        StencilBufferBit4QCOM = 0x00100000,
        StencilBufferBit5QCOM = 0x00200000,
        StencilBufferBit6QCOM = 0x00400000,
        StencilBufferBit7QCOM = 0x00800000,
        MultisampleBufferBit0QCOM = 0x01000000,
        MultisampleBufferBit1QCOM = 0x02000000,
        MultisampleBufferBit2QCOM = 0x04000000,
        MultisampleBufferBit3QCOM = 0x08000000,
        MultisampleBufferBit4QCOM = 0x10000000,
        MultisampleBufferBit5QCOM = 0x20000000,
        MultisampleBufferBit6QCOM = 0x40000000,
        MultisampleBufferBit7QCOM = 0x80000000
    }
    
    [Flags]
    public enum FoveationConfigBitQCOM : uint
    {
        FoveationEnableBitQCOM = 0x00000001,
        FoveationScaledBinMethodBitQCOM = 0x00000002,
        FoveationSubsampledLayoutMethodBitQCOM = 0x00000004
    }
    
    [Flags]
    public enum FfdMaskSGIX : uint
    {
        TextureDeformationBitSGIX = 0x00000001,
        GeometryDeformationBitSGIX = 0x00000002
    }
    
    public enum CommandOpcodesNV
    {
        TerminateSequenceCommandNV = 0x0000,
        NopCommandNV = 0x0001,
        DrawElementsCommandNV = 0x0002,
        DrawArraysCommandNV = 0x0003,
        DrawElementsStripCommandNV = 0x0004,
        DrawArraysStripCommandNV = 0x0005,
        DrawElementsInstancedCommandNV = 0x0006,
        DrawArraysInstancedCommandNV = 0x0007,
        ElementAddressCommandNV = 0x0008,
        AttributeAddressCommandNV = 0x0009,
        UniformAddressCommandNV = 0x000A,
        BlendColorCommandNV = 0x000B,
        StencilRefCommandNV = 0x000C,
        LineWidthCommandNV = 0x000D,
        PolygonOffsetCommandNV = 0x000E,
        AlphaRefCommandNV = 0x000F,
        ViewportCommandNV = 0x0010,
        ScissorCommandNV = 0x0011,
        FrontFaceCommandNV = 0x0012
    }
    
    public enum MapTextureFormatINTEL
    {
        LayoutDefaultINTEL = 0,
        LayoutLinearINTEL = 1,
        LayoutLinearCpuCachedINTEL = 2
    }
    
    public enum PathRenderingTokenNV
    {
        ClosePathNV = 0x00,
        MoveToNV = 0x02,
        RelativeMoveToNV = 0x03,
        LineToNV = 0x04,
        RelativeLineToNV = 0x05,
        HorizontalLineToNV = 0x06,
        RelativeHorizontalLineToNV = 0x07,
        VerticalLineToNV = 0x08,
        RelativeVerticalLineToNV = 0x09,
        QuadraticCurveToNV = 0x0A,
        RelativeQuadraticCurveToNV = 0x0B,
        CubicCurveToNV = 0x0C,
        RelativeCubicCurveToNV = 0x0D,
        SmoothQuadraticCurveToNV = 0x0E,
        RelativeSmoothQuadraticCurveToNV = 0x0F,
        SmoothCubicCurveToNV = 0x10,
        RelativeSmoothCubicCurveToNV = 0x11,
        SmallCcwArcToNV = 0x12,
        RelativeSmallCcwArcToNV = 0x13,
        SmallCwArcToNV = 0x14,
        RelativeSmallCwArcToNV = 0x15,
        LargeCcwArcToNV = 0x16,
        RelativeLargeCcwArcToNV = 0x17,
        LargeCwArcToNV = 0x18,
        RelativeLargeCwArcToNV = 0x19,
        ConicCurveToNV = 0x1A,
        RelativeConicCurveToNV = 0x1B,
        SharedEdgeNV = 0xC0,
        RoundedRectNV = 0xE8,
        RelativeRoundedRectNV = 0xE9,
        RoundedRect2NV = 0xEA,
        RelativeRoundedRect2NV = 0xEB,
        RoundedRect4NV = 0xEC,
        RelativeRoundedRect4NV = 0xED,
        RoundedRect8NV = 0xEE,
        RelativeRoundedRect8NV = 0xEF,
        RestartPathNV = 0xF0,
        DupFirstCubicCurveToNV = 0xF2,
        DupLastCubicCurveToNV = 0xF4,
        RectNV = 0xF6,
        RelativeRectNV = 0xF7,
        CircularCcwArcToNV = 0xF8,
        CircularCwArcToNV = 0xFA,
        CircularTangentArcToNV = 0xFC,
        ArcToNV = 0xFE,
        RelativeArcToNV = 0xFF
    }
    
    public enum TransformFeedbackTokenNV
    {
        NextBufferNV = -2,
        SkipComponents4NV = -3,
        SkipComponents3NV = -4,
        SkipComponents2NV = -5,
        SkipComponents1NV = -6
    }
    
    public enum TriangleListSUN
    {
        RestartSUN = 0x0001,
        ReplaceMiddleSUN = 0x0002,
        ReplaceOldestSUN = 0x0003
    }
    
    public enum TextureEnvParameter
    {
        Combine = 0x8570,
        CombineARB = 0x8570,
        CombineEXT = 0x8570,
        CombineRgb = 0x8571,
        CombineRgbARB = 0x8571,
        CombineRgbEXT = 0x8571,
        CombineAlpha = 0x8572,
        CombineAlphaARB = 0x8572,
        CombineAlphaEXT = 0x8572,
        RgbScale = 0x8573,
        RgbScaleARB = 0x8573,
        RgbScaleEXT = 0x8573,
        AddSigned = 0x8574,
        AddSignedARB = 0x8574,
        AddSignedEXT = 0x8574,
        Interpolate = 0x8575,
        InterpolateARB = 0x8575,
        InterpolateEXT = 0x8575,
        Constant = 0x8576,
        ConstantARB = 0x8576,
        ConstantEXT = 0x8576,
        ConstantNV = 0x8576,
        PrimaryColor = 0x8577,
        PrimaryColorARB = 0x8577,
        PrimaryColorEXT = 0x8577,
        Previous = 0x8578,
        PreviousARB = 0x8578,
        PreviousEXT = 0x8578,
        Source0Rgb = 0x8580,
        Source0RgbARB = 0x8580,
        Source0RgbEXT = 0x8580,
        Src0Rgb = 0x8580,
        Source1Rgb = 0x8581,
        Source1RgbARB = 0x8581,
        Source1RgbEXT = 0x8581,
        Src1Rgb = 0x8581,
        Source2Rgb = 0x8582,
        Source2RgbARB = 0x8582,
        Source2RgbEXT = 0x8582,
        Src2Rgb = 0x8582,
        Source3RgbNV = 0x8583,
        Source0Alpha = 0x8588,
        Source0AlphaARB = 0x8588,
        Source0AlphaEXT = 0x8588,
        Src0Alpha = 0x8588,
        Source1Alpha = 0x8589,
        Source1AlphaARB = 0x8589,
        Source1AlphaEXT = 0x8589,
        Src1Alpha = 0x8589,
        Src1AlphaEXT = 0x8589,
        Source2Alpha = 0x858A,
        Source2AlphaARB = 0x858A,
        Source2AlphaEXT = 0x858A,
        Src2Alpha = 0x858A,
        Source3AlphaNV = 0x858B,
        Operand0Rgb = 0x8590,
        Operand0RgbARB = 0x8590,
        Operand0RgbEXT = 0x8590,
        Operand1Rgb = 0x8591,
        Operand1RgbARB = 0x8591,
        Operand1RgbEXT = 0x8591,
        Operand2Rgb = 0x8592,
        Operand2RgbARB = 0x8592,
        Operand2RgbEXT = 0x8592,
        Operand3RgbNV = 0x8593,
        Operand0Alpha = 0x8598,
        Operand0AlphaARB = 0x8598,
        Operand0AlphaEXT = 0x8598,
        Operand1Alpha = 0x8599,
        Operand1AlphaARB = 0x8599,
        Operand1AlphaEXT = 0x8599,
        Operand2Alpha = 0x859A,
        Operand2AlphaARB = 0x859A,
        Operand2AlphaEXT = 0x859A,
        Operand3AlphaNV = 0x859B
    }
    
    public enum ShaderType
    {
        FragmentShader = 0x8B30,
        FragmentShaderARB = 0x8B30,
        VertexShader = 0x8B31,
        VertexShaderARB = 0x8B31
    }
    
    public enum ContainerType
    {
        ProgramObjectARB = 0x8B40,
        ProgramObjectEXT = 0x8B40
    }
    
    public enum AttributeType
    {
        FloatVec2 = 0x8B50,
        FloatVec2ARB = 0x8B50,
        FloatVec3 = 0x8B51,
        FloatVec3ARB = 0x8B51,
        FloatVec4 = 0x8B52,
        FloatVec4ARB = 0x8B52,
        IntVec2 = 0x8B53,
        IntVec2ARB = 0x8B53,
        IntVec3 = 0x8B54,
        IntVec3ARB = 0x8B54,
        IntVec4 = 0x8B55,
        IntVec4ARB = 0x8B55,
        Bool = 0x8B56,
        BoolARB = 0x8B56,
        BoolVec2 = 0x8B57,
        BoolVec2ARB = 0x8B57,
        BoolVec3 = 0x8B58,
        BoolVec3ARB = 0x8B58,
        BoolVec4 = 0x8B59,
        BoolVec4ARB = 0x8B59,
        FloatMat2 = 0x8B5A,
        FloatMat2ARB = 0x8B5A,
        FloatMat3 = 0x8B5B,
        FloatMat3ARB = 0x8B5B,
        FloatMat4 = 0x8B5C,
        FloatMat4ARB = 0x8B5C,
        Sampler1D = 0x8B5D,
        Sampler1DARB = 0x8B5D,
        Sampler2D = 0x8B5E,
        Sampler2DARB = 0x8B5E,
        Sampler3D = 0x8B5F,
        Sampler3DARB = 0x8B5F,
        Sampler3DOES = 0x8B5F,
        SamplerCube = 0x8B60,
        SamplerCubeARB = 0x8B60,
        Sampler1DShadow = 0x8B61,
        Sampler1DShadowARB = 0x8B61,
        Sampler2DShadow = 0x8B62,
        Sampler2DShadowARB = 0x8B62,
        Sampler2DShadowEXT = 0x8B62,
        Sampler2DRect = 0x8B63,
        Sampler2DRectARB = 0x8B63,
        Sampler2DRectShadow = 0x8B64,
        Sampler2DRectShadowARB = 0x8B64,
        FloatMat2x3 = 0x8B65,
        FloatMat2x3NV = 0x8B65,
        FloatMat2x4 = 0x8B66,
        FloatMat2x4NV = 0x8B66,
        FloatMat3x2 = 0x8B67,
        FloatMat3x2NV = 0x8B67,
        FloatMat3x4 = 0x8B68,
        FloatMat3x4NV = 0x8B68,
        FloatMat4x2 = 0x8B69,
        FloatMat4x2NV = 0x8B69,
        FloatMat4x3 = 0x8B6A,
        FloatMat4x3NV = 0x8B6A
    }
    
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class Gl
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCULLFACEPROC(int mode);
        private static PFNGLCULLFACEPROC glCullFace;
        
        public static void CullFace(int mode)
        {
            glCullFace.Invoke(mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRONTFACEPROC(int mode);
        private static PFNGLFRONTFACEPROC glFrontFace;
        
        public static void FrontFace(int mode)
        {
            glFrontFace.Invoke(mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLHINTPROC(int target, int mode);
        private static PFNGLHINTPROC glHint;
        
        public static void Hint(int target, int mode)
        {
            glHint.Invoke(target, mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLLINEWIDTHPROC(float width);
        private static PFNGLLINEWIDTHPROC glLineWidth;
        
        public static void LineWidth(float width)
        {
            glLineWidth.Invoke(width);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOINTSIZEPROC(float size);
        private static PFNGLPOINTSIZEPROC glPointSize;
        
        public static void PointSize(float size)
        {
            glPointSize.Invoke(size);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOLYGONMODEPROC(int face, int mode);
        private static PFNGLPOLYGONMODEPROC glPolygonMode;
        
        public static void PolygonMode(int face, int mode)
        {
            glPolygonMode.Invoke(face, mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSCISSORPROC(int x, int y, int width, int height);
        private static PFNGLSCISSORPROC glScissor;
        
        public static void Scissor(int x, int y, int width, int height)
        {
            glScissor.Invoke(x, y, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERFPROC(int target, int pname, float param);
        private static PFNGLTEXPARAMETERFPROC glTexParameterf;
        
        public static void TexParameterf(int target, int pname, float param)
        {
            glTexParameterf.Invoke(target, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERFVPROC(int target, int pname, float[] parameters);
        private static PFNGLTEXPARAMETERFVPROC glTexParameterfv;
        
        public static void TexParameterfv(int target, int pname, float[] parameters)
        {
            glTexParameterfv.Invoke(target, pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERIPROC(int target, int pname, int param);
        private static PFNGLTEXPARAMETERIPROC glTexParameteri;
        
        public static void TexParameteri(int target, int pname, int param)
        {
            glTexParameteri.Invoke(target, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERIVPROC(int target, int pname, int[] parameters);
        private static PFNGLTEXPARAMETERIVPROC glTexParameteriv;
        
        public static void TexParameteriv(int target, int pname, int[] parameters)
        {
            glTexParameteriv.Invoke(target, pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXIMAGE1DPROC(int target, int level, int internalformat, int width, int border, int format, int type, IntPtr pixels);
        private static PFNGLTEXIMAGE1DPROC glTexImage1D;
        
        public static void TexImage1D(int target, int level, int internalformat, int width, int border, int format, int type, IntPtr pixels)
        {
            glTexImage1D.Invoke(target, level, internalformat, width, border, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXIMAGE2DPROC(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels);
        private static PFNGLTEXIMAGE2DPROC glTexImage2D;
        
        public static void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, IntPtr pixels)
        {
            glTexImage2D.Invoke(target, level, internalformat, width, height, border, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWBUFFERPROC(int buf);
        private static PFNGLDRAWBUFFERPROC glDrawBuffer;
        
        public static void DrawBuffer(int buf)
        {
            glDrawBuffer.Invoke(buf);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARPROC(uint mask);
        private static PFNGLCLEARPROC glClear;
        
        public static void Clear(uint mask)
        {
            glClear.Invoke(mask);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARCOLORPROC(float red, float green, float blue, float alpha);
        private static PFNGLCLEARCOLORPROC glClearColor;
        
        public static void ClearColor(float red, float green, float blue, float alpha)
        {
            glClearColor.Invoke(red, green, blue, alpha);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARSTENCILPROC(int s);
        private static PFNGLCLEARSTENCILPROC glClearStencil;
        
        public static void ClearStencil(int s)
        {
            glClearStencil.Invoke(s);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARDEPTHPROC(double depth);
        private static PFNGLCLEARDEPTHPROC glClearDepth;
        
        public static void ClearDepth(double depth)
        {
            glClearDepth.Invoke(depth);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILMASKPROC(uint mask);
        private static PFNGLSTENCILMASKPROC glStencilMask;
        
        public static void StencilMask(uint mask)
        {
            glStencilMask.Invoke(mask);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOLORMASKPROC(bool red, bool green, bool blue, bool alpha);
        private static PFNGLCOLORMASKPROC glColorMask;
        
        public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        {
            glColorMask.Invoke(red, green, blue, alpha);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDEPTHMASKPROC(bool flag);
        private static PFNGLDEPTHMASKPROC glDepthMask;
        
        public static void DepthMask(bool flag)
        {
            glDepthMask.Invoke(flag);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDISABLEPROC(int cap);
        private static PFNGLDISABLEPROC glDisable;
        
        public static void Disable(int cap)
        {
            glDisable.Invoke(cap);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENABLEPROC(int cap);
        private static PFNGLENABLEPROC glEnable;
        
        public static void Enable(int cap)
        {
            glEnable.Invoke(cap);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFINISHPROC();
        private static PFNGLFINISHPROC glFinish;
        
        public static void Finish()
        {
            glFinish.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFLUSHPROC();
        private static PFNGLFLUSHPROC glFlush;
        
        public static void Flush()
        {
            glFlush.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLENDFUNCPROC(int sfactor, int dfactor);
        private static PFNGLBLENDFUNCPROC glBlendFunc;
        
        public static void BlendFunc(int sfactor, int dfactor)
        {
            glBlendFunc.Invoke(sfactor, dfactor);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLLOGICOPPROC(int opcode);
        private static PFNGLLOGICOPPROC glLogicOp;
        
        public static void LogicOp(int opcode)
        {
            glLogicOp.Invoke(opcode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILFUNCPROC(int func, int reference, uint mask);
        private static PFNGLSTENCILFUNCPROC glStencilFunc;
        
        public static void StencilFunc(int func, int reference, uint mask)
        {
            glStencilFunc.Invoke(func, reference, mask);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILOPPROC(int fail, int zfail, int zpass);
        private static PFNGLSTENCILOPPROC glStencilOp;
        
        public static void StencilOp(int fail, int zfail, int zpass)
        {
            glStencilOp.Invoke(fail, zfail, zpass);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDEPTHFUNCPROC(int func);
        private static PFNGLDEPTHFUNCPROC glDepthFunc;
        
        public static void DepthFunc(int func)
        {
            glDepthFunc.Invoke(func);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPIXELSTOREFPROC(int pname, float param);
        private static PFNGLPIXELSTOREFPROC glPixelStoref;
        
        public static void PixelStoref(int pname, float param)
        {
            glPixelStoref.Invoke(pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPIXELSTOREIPROC(int pname, int param);
        private static PFNGLPIXELSTOREIPROC glPixelStorei;
        
        public static void PixelStorei(int pname, int param)
        {
            glPixelStorei.Invoke(pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLREADBUFFERPROC(int src);
        private static PFNGLREADBUFFERPROC glReadBuffer;
        
        public static void ReadBuffer(int src)
        {
            glReadBuffer.Invoke(src);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLREADPIXELSPROC(int x, int y, int width, int height, int format, int type, out IntPtr pixels);
        private static PFNGLREADPIXELSPROC glReadPixels;
        
        public static void ReadPixels(int x, int y, int width, int height, int format, int type, out IntPtr pixels)
        {
            glReadPixels.Invoke(x, y, width, height, format, type, out pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBOOLEANVPROC(int pname, out bool data);
        private static PFNGLGETBOOLEANVPROC glGetBooleanv;
        
        public static void GetBooleanv(int pname, out bool data)
        {
            glGetBooleanv.Invoke(pname, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETDOUBLEVPROC(int pname, out double data);
        private static PFNGLGETDOUBLEVPROC glGetDoublev;
        
        public static void GetDoublev(int pname, out double data)
        {
            glGetDoublev.Invoke(pname, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLGETERRORPROC();
        private static PFNGLGETERRORPROC glGetError;
        
        public static int GetError()
        {
            return glGetError.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETFLOATVPROC(int pname, out float data);
        private static PFNGLGETFLOATVPROC glGetFloatv;
        
        public static void GetFloatv(int pname, out float data)
        {
            glGetFloatv.Invoke(pname, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETINTEGERVPROC(int pname, out int data);
        private static PFNGLGETINTEGERVPROC glGetIntegerv;
        
        public static void GetIntegerv(int pname, out int data)
        {
            glGetIntegerv.Invoke(pname, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PFNGLGETSTRINGPROC(int name);
        private static PFNGLGETSTRINGPROC glGetString;
        
        public static IntPtr GetString(int name)
        {
            return glGetString.Invoke(name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXIMAGEPROC(int target, int level, int format, int type, out IntPtr pixels);
        private static PFNGLGETTEXIMAGEPROC glGetTexImage;
        
        public static void GetTexImage(int target, int level, int format, int type, out IntPtr pixels)
        {
            glGetTexImage.Invoke(target, level, format, type, out pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXPARAMETERFVPROC(int target, int pname, out float parameters);
        private static PFNGLGETTEXPARAMETERFVPROC glGetTexParameterfv;
        
        public static void GetTexParameterfv(int target, int pname, out float parameters)
        {
            glGetTexParameterfv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXPARAMETERIVPROC(int target, int pname, out int parameters);
        private static PFNGLGETTEXPARAMETERIVPROC glGetTexParameteriv;
        
        public static void GetTexParameteriv(int target, int pname, out int parameters)
        {
            glGetTexParameteriv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXLEVELPARAMETERFVPROC(int target, int level, int pname, out float parameters);
        private static PFNGLGETTEXLEVELPARAMETERFVPROC glGetTexLevelParameterfv;
        
        public static void GetTexLevelParameterfv(int target, int level, int pname, out float parameters)
        {
            glGetTexLevelParameterfv.Invoke(target, level, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXLEVELPARAMETERIVPROC(int target, int level, int pname, out int parameters);
        private static PFNGLGETTEXLEVELPARAMETERIVPROC glGetTexLevelParameteriv;
        
        public static void GetTexLevelParameteriv(int target, int level, int pname, out int parameters)
        {
            glGetTexLevelParameteriv.Invoke(target, level, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISENABLEDPROC(int cap);
        private static PFNGLISENABLEDPROC glIsEnabled;
        
        public static bool IsEnabled(int cap)
        {
            return glIsEnabled.Invoke(cap);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDEPTHRANGEPROC(double n, double f);
        private static PFNGLDEPTHRANGEPROC glDepthRange;
        
        public static void DepthRange(double n, double f)
        {
            glDepthRange.Invoke(n, f);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVIEWPORTPROC(int x, int y, int width, int height);
        private static PFNGLVIEWPORTPROC glViewport;
        
        public static void Viewport(int x, int y, int width, int height)
        {
            glViewport.Invoke(x, y, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWARRAYSPROC(int mode, int first, int count);
        private static PFNGLDRAWARRAYSPROC glDrawArrays;
        
        public static void DrawArrays(int mode, int first, int count)
        {
            glDrawArrays.Invoke(mode, first, count);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWELEMENTSPROC(int mode, int count, int type, IntPtr indices);
        private static PFNGLDRAWELEMENTSPROC glDrawElements;
        
        public static void DrawElements(int mode, int count, int type, IntPtr indices)
        {
            glDrawElements.Invoke(mode, count, type, indices);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOLYGONOFFSETPROC(float factor, float units);
        private static PFNGLPOLYGONOFFSETPROC glPolygonOffset;
        
        public static void PolygonOffset(float factor, float units)
        {
            glPolygonOffset.Invoke(factor, units);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYTEXIMAGE1DPROC(int target, int level, int internalformat, int x, int y, int width, int border);
        private static PFNGLCOPYTEXIMAGE1DPROC glCopyTexImage1D;
        
        public static void CopyTexImage1D(int target, int level, int internalformat, int x, int y, int width, int border)
        {
            glCopyTexImage1D.Invoke(target, level, internalformat, x, y, width, border);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYTEXIMAGE2DPROC(int target, int level, int internalformat, int x, int y, int width, int height, int border);
        private static PFNGLCOPYTEXIMAGE2DPROC glCopyTexImage2D;
        
        public static void CopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border)
        {
            glCopyTexImage2D.Invoke(target, level, internalformat, x, y, width, height, border);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYTEXSUBIMAGE1DPROC(int target, int level, int xoffset, int x, int y, int width);
        private static PFNGLCOPYTEXSUBIMAGE1DPROC glCopyTexSubImage1D;
        
        public static void CopyTexSubImage1D(int target, int level, int xoffset, int x, int y, int width)
        {
            glCopyTexSubImage1D.Invoke(target, level, xoffset, x, y, width);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYTEXSUBIMAGE2DPROC(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        private static PFNGLCOPYTEXSUBIMAGE2DPROC glCopyTexSubImage2D;
        
        public static void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
        {
            glCopyTexSubImage2D.Invoke(target, level, xoffset, yoffset, x, y, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXSUBIMAGE1DPROC(int target, int level, int xoffset, int width, int format, int type, IntPtr pixels);
        private static PFNGLTEXSUBIMAGE1DPROC glTexSubImage1D;
        
        public static void TexSubImage1D(int target, int level, int xoffset, int width, int format, int type, IntPtr pixels)
        {
            glTexSubImage1D.Invoke(target, level, xoffset, width, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXSUBIMAGE2DPROC(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, IntPtr pixels);
        private static PFNGLTEXSUBIMAGE2DPROC glTexSubImage2D;
        
        public static void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, IntPtr pixels)
        {
            glTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDTEXTUREPROC(int target, uint texture);
        private static PFNGLBINDTEXTUREPROC glBindTexture;
        
        public static void BindTexture(int target, uint texture)
        {
            glBindTexture.Invoke(target, texture);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETETEXTURESPROC(int n, uint[] textures);
        private static PFNGLDELETETEXTURESPROC glDeleteTextures;
        
        public static void DeleteTextures(int n, uint[] textures)
        {
            glDeleteTextures.Invoke(n, textures);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENTEXTURESPROC(int n, out uint textures);
        private static PFNGLGENTEXTURESPROC glGenTextures;
        
        public static void GenTextures(int n, out uint textures)
        {
            glGenTextures.Invoke(n, out textures);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISTEXTUREPROC(uint texture);
        private static PFNGLISTEXTUREPROC glIsTexture;
        
        public static bool IsTexture(uint texture)
        {
            return glIsTexture.Invoke(texture);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWRANGEELEMENTSPROC(int mode, uint start, uint end, int count, int type, IntPtr indices);
        private static PFNGLDRAWRANGEELEMENTSPROC glDrawRangeElements;
        
        public static void DrawRangeElements(int mode, uint start, uint end, int count, int type, IntPtr indices)
        {
            glDrawRangeElements.Invoke(mode, start, end, count, type, indices);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXIMAGE3DPROC(int target, int level, int internalformat, int width, int height, int depth, int border, int format, int type, IntPtr pixels);
        private static PFNGLTEXIMAGE3DPROC glTexImage3D;
        
        public static void TexImage3D(int target, int level, int internalformat, int width, int height, int depth, int border, int format, int type, IntPtr pixels)
        {
            glTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXSUBIMAGE3DPROC(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int type, IntPtr pixels);
        private static PFNGLTEXSUBIMAGE3DPROC glTexSubImage3D;
        
        public static void TexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int type, IntPtr pixels)
        {
            glTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYTEXSUBIMAGE3DPROC(int target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        private static PFNGLCOPYTEXSUBIMAGE3DPROC glCopyTexSubImage3D;
        
        public static void CopyTexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
        {
            glCopyTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLACTIVETEXTUREPROC(int texture);
        private static PFNGLACTIVETEXTUREPROC glActiveTexture;
        
        public static void ActiveTexture(int texture)
        {
            glActiveTexture.Invoke(texture);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLECOVERAGEPROC(float value, bool invert);
        private static PFNGLSAMPLECOVERAGEPROC glSampleCoverage;
        
        public static void SampleCoverage(float value, bool invert)
        {
            glSampleCoverage.Invoke(value, invert);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXIMAGE3DPROC(int target, int level, int internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXIMAGE3DPROC glCompressedTexImage3D;
        
        public static void CompressedTexImage3D(int target, int level, int internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
        {
            glCompressedTexImage3D.Invoke(target, level, internalformat, width, height, depth, border, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXIMAGE2DPROC(int target, int level, int internalformat, int width, int height, int border, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXIMAGE2DPROC glCompressedTexImage2D;
        
        public static void CompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, IntPtr data)
        {
            glCompressedTexImage2D.Invoke(target, level, internalformat, width, height, border, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXIMAGE1DPROC(int target, int level, int internalformat, int width, int border, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXIMAGE1DPROC glCompressedTexImage1D;
        
        public static void CompressedTexImage1D(int target, int level, int internalformat, int width, int border, int imageSize, IntPtr data)
        {
            glCompressedTexImage1D.Invoke(target, level, internalformat, width, border, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC glCompressedTexSubImage3D;
        
        public static void CompressedTexSubImage3D(int target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int format, int imageSize, IntPtr data)
        {
            glCompressedTexSubImage3D.Invoke(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC glCompressedTexSubImage2D;
        
        public static void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, IntPtr data)
        {
            glCompressedTexSubImage2D.Invoke(target, level, xoffset, yoffset, width, height, format, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC(int target, int level, int xoffset, int width, int format, int imageSize, IntPtr data);
        private static PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC glCompressedTexSubImage1D;
        
        public static void CompressedTexSubImage1D(int target, int level, int xoffset, int width, int format, int imageSize, IntPtr data)
        {
            glCompressedTexSubImage1D.Invoke(target, level, xoffset, width, format, imageSize, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETCOMPRESSEDTEXIMAGEPROC(int target, int level, out IntPtr img);
        private static PFNGLGETCOMPRESSEDTEXIMAGEPROC glGetCompressedTexImage;
        
        public static void GetCompressedTexImage(int target, int level, out IntPtr img)
        {
            glGetCompressedTexImage.Invoke(target, level, out img);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLENDFUNCSEPARATEPROC(int sfactorRGB, int dfactorRGB, int sfactorAlpha, int dfactorAlpha);
        private static PFNGLBLENDFUNCSEPARATEPROC glBlendFuncSeparate;
        
        public static void BlendFuncSeparate(int sfactorRGB, int dfactorRGB, int sfactorAlpha, int dfactorAlpha)
        {
            glBlendFuncSeparate.Invoke(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLMULTIDRAWARRAYSPROC(int mode, int[] first, int[] count, int drawcount);
        private static PFNGLMULTIDRAWARRAYSPROC glMultiDrawArrays;
        
        public static void MultiDrawArrays(int mode, int[] first, int[] count, int drawcount)
        {
            glMultiDrawArrays.Invoke(mode, first, count, drawcount);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLMULTIDRAWELEMENTSPROC(int mode, int[] count, int type, IntPtr indices, int drawcount);
        private static PFNGLMULTIDRAWELEMENTSPROC glMultiDrawElements;
        
        public static void MultiDrawElements(int mode, int[] count, int type, IntPtr indices, int drawcount)
        {
            glMultiDrawElements.Invoke(mode, count, type, indices, drawcount);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOINTPARAMETERFPROC(int pname, float param);
        private static PFNGLPOINTPARAMETERFPROC glPointParameterf;
        
        public static void PointParameterf(int pname, float param)
        {
            glPointParameterf.Invoke(pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOINTPARAMETERFVPROC(int pname, float[] parameters);
        private static PFNGLPOINTPARAMETERFVPROC glPointParameterfv;
        
        public static void PointParameterfv(int pname, float[] parameters)
        {
            glPointParameterfv.Invoke(pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOINTPARAMETERIPROC(int pname, int param);
        private static PFNGLPOINTPARAMETERIPROC glPointParameteri;
        
        public static void PointParameteri(int pname, int param)
        {
            glPointParameteri.Invoke(pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPOINTPARAMETERIVPROC(int pname, int[] parameters);
        private static PFNGLPOINTPARAMETERIVPROC glPointParameteriv;
        
        public static void PointParameteriv(int pname, int[] parameters)
        {
            glPointParameteriv.Invoke(pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP4UIVPROC(uint index, int type, bool normalized, uint[] value);
        private static PFNGLVERTEXATTRIBP4UIVPROC glVertexAttribP4uiv;
        
        public static void VertexAttribP4uiv(uint index, int type, bool normalized, uint[] value)
        {
            glVertexAttribP4uiv.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP4UIPROC(uint index, int type, bool normalized, uint value);
        private static PFNGLVERTEXATTRIBP4UIPROC glVertexAttribP4ui;
        
        public static void VertexAttribP4ui(uint index, int type, bool normalized, uint value)
        {
            glVertexAttribP4ui.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP3UIVPROC(uint index, int type, bool normalized, uint[] value);
        private static PFNGLVERTEXATTRIBP3UIVPROC glVertexAttribP3uiv;
        
        public static void VertexAttribP3uiv(uint index, int type, bool normalized, uint[] value)
        {
            glVertexAttribP3uiv.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP3UIPROC(uint index, int type, bool normalized, uint value);
        private static PFNGLVERTEXATTRIBP3UIPROC glVertexAttribP3ui;
        
        public static void VertexAttribP3ui(uint index, int type, bool normalized, uint value)
        {
            glVertexAttribP3ui.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP2UIVPROC(uint index, int type, bool normalized, uint[] value);
        private static PFNGLVERTEXATTRIBP2UIVPROC glVertexAttribP2uiv;
        
        public static void VertexAttribP2uiv(uint index, int type, bool normalized, uint[] value)
        {
            glVertexAttribP2uiv.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP2UIPROC(uint index, int type, bool normalized, uint value);
        private static PFNGLVERTEXATTRIBP2UIPROC glVertexAttribP2ui;
        
        public static void VertexAttribP2ui(uint index, int type, bool normalized, uint value)
        {
            glVertexAttribP2ui.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP1UIVPROC(uint index, int type, bool normalized, uint[] value);
        private static PFNGLVERTEXATTRIBP1UIVPROC glVertexAttribP1uiv;
        
        public static void VertexAttribP1uiv(uint index, int type, bool normalized, uint[] value)
        {
            glVertexAttribP1uiv.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBP1UIPROC(uint index, int type, bool normalized, uint value);
        private static PFNGLVERTEXATTRIBP1UIPROC glVertexAttribP1ui;
        
        public static void VertexAttribP1ui(uint index, int type, bool normalized, uint value)
        {
            glVertexAttribP1ui.Invoke(index, type, normalized, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBDIVISORPROC(uint index, uint divisor);
        private static PFNGLVERTEXATTRIBDIVISORPROC glVertexAttribDivisor;
        
        public static void VertexAttribDivisor(uint index, uint divisor)
        {
            glVertexAttribDivisor.Invoke(index, divisor);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETQUERYOBJECTUI64VPROC(uint id, int pname, out ulong parameters);
        private static PFNGLGETQUERYOBJECTUI64VPROC glGetQueryObjectui64v;
        
        public static void GetQueryObjectui64v(uint id, int pname, out ulong parameters)
        {
            glGetQueryObjectui64v.Invoke(id, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETQUERYOBJECTI64VPROC(uint id, int pname, out long parameters);
        private static PFNGLGETQUERYOBJECTI64VPROC glGetQueryObjecti64v;
        
        public static void GetQueryObjecti64v(uint id, int pname, out long parameters)
        {
            glGetQueryObjecti64v.Invoke(id, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLQUERYCOUNTERPROC(uint id, int target);
        private static PFNGLQUERYCOUNTERPROC glQueryCounter;
        
        public static void QueryCounter(uint id, int target)
        {
            glQueryCounter.Invoke(id, target);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSAMPLERPARAMETERIUIVPROC(uint sampler, int pname, out uint parameters);
        private static PFNGLGETSAMPLERPARAMETERIUIVPROC glGetSamplerParameterIuiv;
        
        public static void GetSamplerParameterIuiv(uint sampler, int pname, out uint parameters)
        {
            glGetSamplerParameterIuiv.Invoke(sampler, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSAMPLERPARAMETERFVPROC(uint sampler, int pname, out float parameters);
        private static PFNGLGETSAMPLERPARAMETERFVPROC glGetSamplerParameterfv;
        
        public static void GetSamplerParameterfv(uint sampler, int pname, out float parameters)
        {
            glGetSamplerParameterfv.Invoke(sampler, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSAMPLERPARAMETERIIVPROC(uint sampler, int pname, out int parameters);
        private static PFNGLGETSAMPLERPARAMETERIIVPROC glGetSamplerParameterIiv;
        
        public static void GetSamplerParameterIiv(uint sampler, int pname, out int parameters)
        {
            glGetSamplerParameterIiv.Invoke(sampler, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSAMPLERPARAMETERIVPROC(uint sampler, int pname, out int parameters);
        private static PFNGLGETSAMPLERPARAMETERIVPROC glGetSamplerParameteriv;
        
        public static void GetSamplerParameteriv(uint sampler, int pname, out int parameters)
        {
            glGetSamplerParameteriv.Invoke(sampler, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERIUIVPROC(uint sampler, int pname, uint[] param);
        private static PFNGLSAMPLERPARAMETERIUIVPROC glSamplerParameterIuiv;
        
        public static void SamplerParameterIuiv(uint sampler, int pname, uint[] param)
        {
            glSamplerParameterIuiv.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERIIVPROC(uint sampler, int pname, int[] param);
        private static PFNGLSAMPLERPARAMETERIIVPROC glSamplerParameterIiv;
        
        public static void SamplerParameterIiv(uint sampler, int pname, int[] param)
        {
            glSamplerParameterIiv.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERFVPROC(uint sampler, int pname, float[] param);
        private static PFNGLSAMPLERPARAMETERFVPROC glSamplerParameterfv;
        
        public static void SamplerParameterfv(uint sampler, int pname, float[] param)
        {
            glSamplerParameterfv.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERFPROC(uint sampler, int pname, float param);
        private static PFNGLSAMPLERPARAMETERFPROC glSamplerParameterf;
        
        public static void SamplerParameterf(uint sampler, int pname, float param)
        {
            glSamplerParameterf.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERIVPROC(uint sampler, int pname, int[] param);
        private static PFNGLSAMPLERPARAMETERIVPROC glSamplerParameteriv;
        
        public static void SamplerParameteriv(uint sampler, int pname, int[] param)
        {
            glSamplerParameteriv.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLERPARAMETERIPROC(uint sampler, int pname, int param);
        private static PFNGLSAMPLERPARAMETERIPROC glSamplerParameteri;
        
        public static void SamplerParameteri(uint sampler, int pname, int param)
        {
            glSamplerParameteri.Invoke(sampler, pname, param);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDSAMPLERPROC(uint unit, uint sampler);
        private static PFNGLBINDSAMPLERPROC glBindSampler;
        
        public static void BindSampler(uint unit, uint sampler)
        {
            glBindSampler.Invoke(unit, sampler);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISSAMPLERPROC(uint sampler);
        private static PFNGLISSAMPLERPROC glIsSampler;
        
        public static bool IsSampler(uint sampler)
        {
            return glIsSampler.Invoke(sampler);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETESAMPLERSPROC(int count, uint[] samplers);
        private static PFNGLDELETESAMPLERSPROC glDeleteSamplers;
        
        public static void DeleteSamplers(int count, uint[] samplers)
        {
            glDeleteSamplers.Invoke(count, samplers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENSAMPLERSPROC(int count, out uint samplers);
        private static PFNGLGENSAMPLERSPROC glGenSamplers;
        
        public static void GenSamplers(int count, out uint samplers)
        {
            glGenSamplers.Invoke(count, out samplers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLGETFRAGDATAINDEXPROC(uint program, sbyte[] name);
        private static PFNGLGETFRAGDATAINDEXPROC glGetFragDataIndex;
        
        public static int GetFragDataIndex(uint program, sbyte[] name)
        {
            return glGetFragDataIndex.Invoke(program, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDFRAGDATALOCATIONINDEXEDPROC(uint program, uint colorNumber, uint index, sbyte[] name);
        private static PFNGLBINDFRAGDATALOCATIONINDEXEDPROC glBindFragDataLocationIndexed;
        
        public static void BindFragDataLocationIndexed(uint program, uint colorNumber, uint index, sbyte[] name)
        {
            glBindFragDataLocationIndexed.Invoke(program, colorNumber, index, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLENDCOLORPROC(float red, float green, float blue, float alpha);
        private static PFNGLBLENDCOLORPROC glBlendColor;
        
        public static void BlendColor(float red, float green, float blue, float alpha)
        {
            glBlendColor.Invoke(red, green, blue, alpha);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLENDEQUATIONPROC(int mode);
        private static PFNGLBLENDEQUATIONPROC glBlendEquation;
        
        public static void BlendEquation(int mode)
        {
            glBlendEquation.Invoke(mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENQUERIESPROC(int n, out uint ids);
        private static PFNGLGENQUERIESPROC glGenQueries;
        
        public static void GenQueries(int n, out uint ids)
        {
            glGenQueries.Invoke(n, out ids);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETEQUERIESPROC(int n, uint[] ids);
        private static PFNGLDELETEQUERIESPROC glDeleteQueries;
        
        public static void DeleteQueries(int n, uint[] ids)
        {
            glDeleteQueries.Invoke(n, ids);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISQUERYPROC(uint id);
        private static PFNGLISQUERYPROC glIsQuery;
        
        public static bool IsQuery(uint id)
        {
            return glIsQuery.Invoke(id);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBEGINQUERYPROC(int target, uint id);
        private static PFNGLBEGINQUERYPROC glBeginQuery;
        
        public static void BeginQuery(int target, uint id)
        {
            glBeginQuery.Invoke(target, id);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENDQUERYPROC(int target);
        private static PFNGLENDQUERYPROC glEndQuery;
        
        public static void EndQuery(int target)
        {
            glEndQuery.Invoke(target);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETQUERYIVPROC(int target, int pname, out int parameters);
        private static PFNGLGETQUERYIVPROC glGetQueryiv;
        
        public static void GetQueryiv(int target, int pname, out int parameters)
        {
            glGetQueryiv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETQUERYOBJECTIVPROC(uint id, int pname, out int parameters);
        private static PFNGLGETQUERYOBJECTIVPROC glGetQueryObjectiv;
        
        public static void GetQueryObjectiv(uint id, int pname, out int parameters)
        {
            glGetQueryObjectiv.Invoke(id, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETQUERYOBJECTUIVPROC(uint id, int pname, out uint parameters);
        private static PFNGLGETQUERYOBJECTUIVPROC glGetQueryObjectuiv;
        
        public static void GetQueryObjectuiv(uint id, int pname, out uint parameters)
        {
            glGetQueryObjectuiv.Invoke(id, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDBUFFERPROC(int target, uint buffer);
        private static PFNGLBINDBUFFERPROC glBindBuffer;
        
        public static void BindBuffer(int target, uint buffer)
        {
            glBindBuffer.Invoke(target, buffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETEBUFFERSPROC(int n, uint[] buffers);
        private static PFNGLDELETEBUFFERSPROC glDeleteBuffers;
        
        public static void DeleteBuffers(int n, uint[] buffers)
        {
            glDeleteBuffers.Invoke(n, buffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENBUFFERSPROC(int n, out uint buffers);
        private static PFNGLGENBUFFERSPROC glGenBuffers;
        
        public static void GenBuffers(int n, out uint buffers)
        {
            glGenBuffers.Invoke(n, out buffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISBUFFERPROC(uint buffer);
        private static PFNGLISBUFFERPROC glIsBuffer;
        
        public static bool IsBuffer(uint buffer)
        {
            return glIsBuffer.Invoke(buffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBUFFERDATAPROC(int target, IntPtr size, IntPtr data, int usage);
        private static PFNGLBUFFERDATAPROC glBufferData;
        
        public static void BufferData(int target, IntPtr size, IntPtr data, int usage)
        {
            glBufferData.Invoke(target, size, data, usage);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBUFFERSUBDATAPROC(int target, IntPtr offset, IntPtr size, IntPtr data);
        private static PFNGLBUFFERSUBDATAPROC glBufferSubData;
        
        public static void BufferSubData(int target, IntPtr offset, IntPtr size, IntPtr data)
        {
            glBufferSubData.Invoke(target, offset, size, data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBUFFERSUBDATAPROC(int target, IntPtr offset, IntPtr size, out IntPtr data);
        private static PFNGLGETBUFFERSUBDATAPROC glGetBufferSubData;
        
        public static void GetBufferSubData(int target, IntPtr offset, IntPtr size, out IntPtr data)
        {
            glGetBufferSubData.Invoke(target, offset, size, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PFNGLMAPBUFFERPROC(int target, int access);
        private static PFNGLMAPBUFFERPROC glMapBuffer;
        
        public static IntPtr MapBuffer(int target, int access)
        {
            return glMapBuffer.Invoke(target, access);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLUNMAPBUFFERPROC(int target);
        private static PFNGLUNMAPBUFFERPROC glUnmapBuffer;
        
        public static bool UnmapBuffer(int target)
        {
            return glUnmapBuffer.Invoke(target);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBUFFERPARAMETERIVPROC(int target, int pname, out int parameters);
        private static PFNGLGETBUFFERPARAMETERIVPROC glGetBufferParameteriv;
        
        public static void GetBufferParameteriv(int target, int pname, out int parameters)
        {
            glGetBufferParameteriv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBUFFERPOINTERVPROC(int target, int pname, out IntPtr parameters);
        private static PFNGLGETBUFFERPOINTERVPROC glGetBufferPointerv;
        
        public static void GetBufferPointerv(int target, int pname, out IntPtr parameters)
        {
            glGetBufferPointerv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLENDEQUATIONSEPARATEPROC(int modeRGB, int modeAlpha);
        private static PFNGLBLENDEQUATIONSEPARATEPROC glBlendEquationSeparate;
        
        public static void BlendEquationSeparate(int modeRGB, int modeAlpha)
        {
            glBlendEquationSeparate.Invoke(modeRGB, modeAlpha);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWBUFFERSPROC(int n, int[] bufs);
        private static PFNGLDRAWBUFFERSPROC glDrawBuffers;
        
        public static void DrawBuffers(int n, int[] bufs)
        {
            glDrawBuffers.Invoke(n, bufs);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILOPSEPARATEPROC(int face, int sfail, int dpfail, int dppass);
        private static PFNGLSTENCILOPSEPARATEPROC glStencilOpSeparate;
        
        public static void StencilOpSeparate(int face, int sfail, int dpfail, int dppass)
        {
            glStencilOpSeparate.Invoke(face, sfail, dpfail, dppass);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILFUNCSEPARATEPROC(int face, int func, int reference, uint mask);
        private static PFNGLSTENCILFUNCSEPARATEPROC glStencilFuncSeparate;
        
        public static void StencilFuncSeparate(int face, int func, int reference, uint mask)
        {
            glStencilFuncSeparate.Invoke(face, func, reference, mask);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSTENCILMASKSEPARATEPROC(int face, uint mask);
        private static PFNGLSTENCILMASKSEPARATEPROC glStencilMaskSeparate;
        
        public static void StencilMaskSeparate(int face, uint mask)
        {
            glStencilMaskSeparate.Invoke(face, mask);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLATTACHSHADERPROC(uint program, uint shader);
        private static PFNGLATTACHSHADERPROC glAttachShader;
        
        public static void AttachShader(uint program, uint shader)
        {
            glAttachShader.Invoke(program, shader);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDATTRIBLOCATIONPROC(uint program, uint index, sbyte[] name);
        private static PFNGLBINDATTRIBLOCATIONPROC glBindAttribLocation;
        
        public static void BindAttribLocation(uint program, uint index, sbyte[] name)
        {
            glBindAttribLocation.Invoke(program, index, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOMPILESHADERPROC(uint shader);
        private static PFNGLCOMPILESHADERPROC glCompileShader;
        
        public static void CompileShader(uint shader)
        {
            glCompileShader.Invoke(shader);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint PFNGLCREATEPROGRAMPROC();
        private static PFNGLCREATEPROGRAMPROC glCreateProgram;
        
        public static uint CreateProgram()
        {
            return glCreateProgram.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint PFNGLCREATESHADERPROC(int type);
        private static PFNGLCREATESHADERPROC glCreateShader;
        
        public static uint CreateShader(int type)
        {
            return glCreateShader.Invoke(type);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETEPROGRAMPROC(uint program);
        private static PFNGLDELETEPROGRAMPROC glDeleteProgram;
        
        public static void DeleteProgram(uint program)
        {
            glDeleteProgram.Invoke(program);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETESHADERPROC(uint shader);
        private static PFNGLDELETESHADERPROC glDeleteShader;
        
        public static void DeleteShader(uint shader)
        {
            glDeleteShader.Invoke(shader);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDETACHSHADERPROC(uint program, uint shader);
        private static PFNGLDETACHSHADERPROC glDetachShader;
        
        public static void DetachShader(uint program, uint shader)
        {
            glDetachShader.Invoke(program, shader);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDISABLEVERTEXATTRIBARRAYPROC(uint index);
        private static PFNGLDISABLEVERTEXATTRIBARRAYPROC glDisableVertexAttribArray;
        
        public static void DisableVertexAttribArray(uint index)
        {
            glDisableVertexAttribArray.Invoke(index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENABLEVERTEXATTRIBARRAYPROC(uint index);
        private static PFNGLENABLEVERTEXATTRIBARRAYPROC glEnableVertexAttribArray;
        
        public static void EnableVertexAttribArray(uint index)
        {
            glEnableVertexAttribArray.Invoke(index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEATTRIBPROC(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name);
        private static PFNGLGETACTIVEATTRIBPROC glGetActiveAttrib;
        
        public static void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name)
        {
            glGetActiveAttrib.Invoke(program, index, bufSize, out length, out size, out type, out name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEUNIFORMPROC(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name);
        private static PFNGLGETACTIVEUNIFORMPROC glGetActiveUniform;
        
        public static void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name)
        {
            glGetActiveUniform.Invoke(program, index, bufSize, out length, out size, out type, out name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETATTACHEDSHADERSPROC(uint program, int maxCount, out int count, out uint shaders);
        private static PFNGLGETATTACHEDSHADERSPROC glGetAttachedShaders;
        
        public static void GetAttachedShaders(uint program, int maxCount, out int count, out uint shaders)
        {
            glGetAttachedShaders.Invoke(program, maxCount, out count, out shaders);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLGETATTRIBLOCATIONPROC(uint program, sbyte[] name);
        private static PFNGLGETATTRIBLOCATIONPROC glGetAttribLocation;
        
        public static int GetAttribLocation(uint program, sbyte[] name)
        {
            return glGetAttribLocation.Invoke(program, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETPROGRAMIVPROC(uint program, int pname, out int parameters);
        private static PFNGLGETPROGRAMIVPROC glGetProgramiv;
        
        public static void GetProgramiv(uint program, int pname, out int parameters)
        {
            glGetProgramiv.Invoke(program, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETPROGRAMINFOLOGPROC(uint program, int bufSize, out int length, out sbyte infoLog);
        private static PFNGLGETPROGRAMINFOLOGPROC glGetProgramInfoLog;
        
        public static void GetProgramInfoLog(uint program, int bufSize, out int length, out sbyte infoLog)
        {
            glGetProgramInfoLog.Invoke(program, bufSize, out length, out infoLog);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSHADERIVPROC(uint shader, int pname, out int parameters);
        private static PFNGLGETSHADERIVPROC glGetShaderiv;
        
        public static void GetShaderiv(uint shader, int pname, out int parameters)
        {
            glGetShaderiv.Invoke(shader, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSHADERINFOLOGPROC(uint shader, int bufSize, out int length, out sbyte infoLog);
        private static PFNGLGETSHADERINFOLOGPROC glGetShaderInfoLog;
        
        public static void GetShaderInfoLog(uint shader, int bufSize, out int length, out sbyte infoLog)
        {
            glGetShaderInfoLog.Invoke(shader, bufSize, out length, out infoLog);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSHADERSOURCEPROC(uint shader, int bufSize, out int length, out sbyte source);
        private static PFNGLGETSHADERSOURCEPROC glGetShaderSource;
        
        public static void GetShaderSource(uint shader, int bufSize, out int length, out sbyte source)
        {
            glGetShaderSource.Invoke(shader, bufSize, out length, out source);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLGETUNIFORMLOCATIONPROC(uint program, sbyte[] name);
        private static PFNGLGETUNIFORMLOCATIONPROC glGetUniformLocation;
        
        public static int GetUniformLocation(uint program, sbyte[] name)
        {
            return glGetUniformLocation.Invoke(program, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETUNIFORMFVPROC(uint program, int location, out float parameters);
        private static PFNGLGETUNIFORMFVPROC glGetUniformfv;
        
        public static void GetUniformfv(uint program, int location, out float parameters)
        {
            glGetUniformfv.Invoke(program, location, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETUNIFORMIVPROC(uint program, int location, out int parameters);
        private static PFNGLGETUNIFORMIVPROC glGetUniformiv;
        
        public static void GetUniformiv(uint program, int location, out int parameters)
        {
            glGetUniformiv.Invoke(program, location, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBDVPROC(uint index, int pname, out double parameters);
        private static PFNGLGETVERTEXATTRIBDVPROC glGetVertexAttribdv;
        
        public static void GetVertexAttribdv(uint index, int pname, out double parameters)
        {
            glGetVertexAttribdv.Invoke(index, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBFVPROC(uint index, int pname, out float parameters);
        private static PFNGLGETVERTEXATTRIBFVPROC glGetVertexAttribfv;
        
        public static void GetVertexAttribfv(uint index, int pname, out float parameters)
        {
            glGetVertexAttribfv.Invoke(index, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBIVPROC(uint index, int pname, out int parameters);
        private static PFNGLGETVERTEXATTRIBIVPROC glGetVertexAttribiv;
        
        public static void GetVertexAttribiv(uint index, int pname, out int parameters)
        {
            glGetVertexAttribiv.Invoke(index, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBPOINTERVPROC(uint index, int pname, out IntPtr pointer);
        private static PFNGLGETVERTEXATTRIBPOINTERVPROC glGetVertexAttribPointerv;
        
        public static void GetVertexAttribPointerv(uint index, int pname, out IntPtr pointer)
        {
            glGetVertexAttribPointerv.Invoke(index, pname, out pointer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISPROGRAMPROC(uint program);
        private static PFNGLISPROGRAMPROC glIsProgram;
        
        public static bool IsProgram(uint program)
        {
            return glIsProgram.Invoke(program);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISSHADERPROC(uint shader);
        private static PFNGLISSHADERPROC glIsShader;
        
        public static bool IsShader(uint shader)
        {
            return glIsShader.Invoke(shader);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLLINKPROGRAMPROC(uint program);
        private static PFNGLLINKPROGRAMPROC glLinkProgram;
        
        public static void LinkProgram(uint program)
        {
            glLinkProgram.Invoke(program);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSHADERSOURCEPROC(uint shader, int count, sbyte str, int[] length);
        private static PFNGLSHADERSOURCEPROC glShaderSource;
        
        public static void ShaderSource(uint shader, int count, sbyte str, int[] length)
        {
            glShaderSource.Invoke(shader, count, str, length);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUSEPROGRAMPROC(uint program);
        private static PFNGLUSEPROGRAMPROC glUseProgram;
        
        public static void UseProgram(uint program)
        {
            glUseProgram.Invoke(program);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1FPROC(int location, float v0);
        private static PFNGLUNIFORM1FPROC glUniform1f;
        
        public static void Uniform1f(int location, float v0)
        {
            glUniform1f.Invoke(location, v0);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2FPROC(int location, float v0, float v1);
        private static PFNGLUNIFORM2FPROC glUniform2f;
        
        public static void Uniform2f(int location, float v0, float v1)
        {
            glUniform2f.Invoke(location, v0, v1);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3FPROC(int location, float v0, float v1, float v2);
        private static PFNGLUNIFORM3FPROC glUniform3f;
        
        public static void Uniform3f(int location, float v0, float v1, float v2)
        {
            glUniform3f.Invoke(location, v0, v1, v2);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4FPROC(int location, float v0, float v1, float v2, float v3);
        private static PFNGLUNIFORM4FPROC glUniform4f;
        
        public static void Uniform4f(int location, float v0, float v1, float v2, float v3)
        {
            glUniform4f.Invoke(location, v0, v1, v2, v3);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1IPROC(int location, int v0);
        private static PFNGLUNIFORM1IPROC glUniform1i;
        
        public static void Uniform1i(int location, int v0)
        {
            glUniform1i.Invoke(location, v0);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2IPROC(int location, int v0, int v1);
        private static PFNGLUNIFORM2IPROC glUniform2i;
        
        public static void Uniform2i(int location, int v0, int v1)
        {
            glUniform2i.Invoke(location, v0, v1);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3IPROC(int location, int v0, int v1, int v2);
        private static PFNGLUNIFORM3IPROC glUniform3i;
        
        public static void Uniform3i(int location, int v0, int v1, int v2)
        {
            glUniform3i.Invoke(location, v0, v1, v2);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4IPROC(int location, int v0, int v1, int v2, int v3);
        private static PFNGLUNIFORM4IPROC glUniform4i;
        
        public static void Uniform4i(int location, int v0, int v1, int v2, int v3)
        {
            glUniform4i.Invoke(location, v0, v1, v2, v3);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1FVPROC(int location, int count, float[] value);
        private static PFNGLUNIFORM1FVPROC glUniform1fv;
        
        public static void Uniform1fv(int location, int count, float[] value)
        {
            glUniform1fv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2FVPROC(int location, int count, float[] value);
        private static PFNGLUNIFORM2FVPROC glUniform2fv;
        
        public static void Uniform2fv(int location, int count, float[] value)
        {
            glUniform2fv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3FVPROC(int location, int count, float[] value);
        private static PFNGLUNIFORM3FVPROC glUniform3fv;
        
        public static void Uniform3fv(int location, int count, float[] value)
        {
            glUniform3fv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4FVPROC(int location, int count, float[] value);
        private static PFNGLUNIFORM4FVPROC glUniform4fv;
        
        public static void Uniform4fv(int location, int count, float[] value)
        {
            glUniform4fv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1IVPROC(int location, int count, int[] value);
        private static PFNGLUNIFORM1IVPROC glUniform1iv;
        
        public static void Uniform1iv(int location, int count, int[] value)
        {
            glUniform1iv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2IVPROC(int location, int count, int[] value);
        private static PFNGLUNIFORM2IVPROC glUniform2iv;
        
        public static void Uniform2iv(int location, int count, int[] value)
        {
            glUniform2iv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3IVPROC(int location, int count, int[] value);
        private static PFNGLUNIFORM3IVPROC glUniform3iv;
        
        public static void Uniform3iv(int location, int count, int[] value)
        {
            glUniform3iv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4IVPROC(int location, int count, int[] value);
        private static PFNGLUNIFORM4IVPROC glUniform4iv;
        
        public static void Uniform4iv(int location, int count, int[] value)
        {
            glUniform4iv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX2FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX2FVPROC glUniformMatrix2fv;
        
        public static void UniformMatrix2fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix2fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX3FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX3FVPROC glUniformMatrix3fv;
        
        public static void UniformMatrix3fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix3fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX4FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX4FVPROC glUniformMatrix4fv;
        
        public static void UniformMatrix4fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix4fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVALIDATEPROGRAMPROC(uint program);
        private static PFNGLVALIDATEPROGRAMPROC glValidateProgram;
        
        public static void ValidateProgram(uint program)
        {
            glValidateProgram.Invoke(program);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1DPROC(uint index, double x);
        private static PFNGLVERTEXATTRIB1DPROC glVertexAttrib1d;
        
        public static void VertexAttrib1d(uint index, double x)
        {
            glVertexAttrib1d.Invoke(index, x);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1DVPROC(uint index, double[] v);
        private static PFNGLVERTEXATTRIB1DVPROC glVertexAttrib1dv;
        
        public static void VertexAttrib1dv(uint index, double[] v)
        {
            glVertexAttrib1dv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1FPROC(uint index, float x);
        private static PFNGLVERTEXATTRIB1FPROC glVertexAttrib1f;
        
        public static void VertexAttrib1f(uint index, float x)
        {
            glVertexAttrib1f.Invoke(index, x);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1FVPROC(uint index, float[] v);
        private static PFNGLVERTEXATTRIB1FVPROC glVertexAttrib1fv;
        
        public static void VertexAttrib1fv(uint index, float[] v)
        {
            glVertexAttrib1fv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1SPROC(uint index, short x);
        private static PFNGLVERTEXATTRIB1SPROC glVertexAttrib1s;
        
        public static void VertexAttrib1s(uint index, short x)
        {
            glVertexAttrib1s.Invoke(index, x);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB1SVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIB1SVPROC glVertexAttrib1sv;
        
        public static void VertexAttrib1sv(uint index, short[] v)
        {
            glVertexAttrib1sv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2DPROC(uint index, double x, double y);
        private static PFNGLVERTEXATTRIB2DPROC glVertexAttrib2d;
        
        public static void VertexAttrib2d(uint index, double x, double y)
        {
            glVertexAttrib2d.Invoke(index, x, y);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2DVPROC(uint index, double[] v);
        private static PFNGLVERTEXATTRIB2DVPROC glVertexAttrib2dv;
        
        public static void VertexAttrib2dv(uint index, double[] v)
        {
            glVertexAttrib2dv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2FPROC(uint index, float x, float y);
        private static PFNGLVERTEXATTRIB2FPROC glVertexAttrib2f;
        
        public static void VertexAttrib2f(uint index, float x, float y)
        {
            glVertexAttrib2f.Invoke(index, x, y);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2FVPROC(uint index, float[] v);
        private static PFNGLVERTEXATTRIB2FVPROC glVertexAttrib2fv;
        
        public static void VertexAttrib2fv(uint index, float[] v)
        {
            glVertexAttrib2fv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2SPROC(uint index, short x, short y);
        private static PFNGLVERTEXATTRIB2SPROC glVertexAttrib2s;
        
        public static void VertexAttrib2s(uint index, short x, short y)
        {
            glVertexAttrib2s.Invoke(index, x, y);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB2SVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIB2SVPROC glVertexAttrib2sv;
        
        public static void VertexAttrib2sv(uint index, short[] v)
        {
            glVertexAttrib2sv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3DPROC(uint index, double x, double y, double z);
        private static PFNGLVERTEXATTRIB3DPROC glVertexAttrib3d;
        
        public static void VertexAttrib3d(uint index, double x, double y, double z)
        {
            glVertexAttrib3d.Invoke(index, x, y, z);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3DVPROC(uint index, double[] v);
        private static PFNGLVERTEXATTRIB3DVPROC glVertexAttrib3dv;
        
        public static void VertexAttrib3dv(uint index, double[] v)
        {
            glVertexAttrib3dv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3FPROC(uint index, float x, float y, float z);
        private static PFNGLVERTEXATTRIB3FPROC glVertexAttrib3f;
        
        public static void VertexAttrib3f(uint index, float x, float y, float z)
        {
            glVertexAttrib3f.Invoke(index, x, y, z);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3FVPROC(uint index, float[] v);
        private static PFNGLVERTEXATTRIB3FVPROC glVertexAttrib3fv;
        
        public static void VertexAttrib3fv(uint index, float[] v)
        {
            glVertexAttrib3fv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3SPROC(uint index, short x, short y, short z);
        private static PFNGLVERTEXATTRIB3SPROC glVertexAttrib3s;
        
        public static void VertexAttrib3s(uint index, short x, short y, short z)
        {
            glVertexAttrib3s.Invoke(index, x, y, z);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB3SVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIB3SVPROC glVertexAttrib3sv;
        
        public static void VertexAttrib3sv(uint index, short[] v)
        {
            glVertexAttrib3sv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NBVPROC(uint index, sbyte[] v);
        private static PFNGLVERTEXATTRIB4NBVPROC glVertexAttrib4Nbv;
        
        public static void VertexAttrib4Nbv(uint index, sbyte[] v)
        {
            glVertexAttrib4Nbv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NIVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIB4NIVPROC glVertexAttrib4Niv;
        
        public static void VertexAttrib4Niv(uint index, int[] v)
        {
            glVertexAttrib4Niv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NSVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIB4NSVPROC glVertexAttrib4Nsv;
        
        public static void VertexAttrib4Nsv(uint index, short[] v)
        {
            glVertexAttrib4Nsv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NUBPROC(uint index, byte x, byte y, byte z, byte w);
        private static PFNGLVERTEXATTRIB4NUBPROC glVertexAttrib4Nub;
        
        public static void VertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w)
        {
            glVertexAttrib4Nub.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NUBVPROC(uint index, byte[] v);
        private static PFNGLVERTEXATTRIB4NUBVPROC glVertexAttrib4Nubv;
        
        public static void VertexAttrib4Nubv(uint index, byte[] v)
        {
            glVertexAttrib4Nubv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NUIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIB4NUIVPROC glVertexAttrib4Nuiv;
        
        public static void VertexAttrib4Nuiv(uint index, uint[] v)
        {
            glVertexAttrib4Nuiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4NUSVPROC(uint index, ushort[] v);
        private static PFNGLVERTEXATTRIB4NUSVPROC glVertexAttrib4Nusv;
        
        public static void VertexAttrib4Nusv(uint index, ushort[] v)
        {
            glVertexAttrib4Nusv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4BVPROC(uint index, sbyte[] v);
        private static PFNGLVERTEXATTRIB4BVPROC glVertexAttrib4bv;
        
        public static void VertexAttrib4bv(uint index, sbyte[] v)
        {
            glVertexAttrib4bv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4DPROC(uint index, double x, double y, double z, double w);
        private static PFNGLVERTEXATTRIB4DPROC glVertexAttrib4d;
        
        public static void VertexAttrib4d(uint index, double x, double y, double z, double w)
        {
            glVertexAttrib4d.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4DVPROC(uint index, double[] v);
        private static PFNGLVERTEXATTRIB4DVPROC glVertexAttrib4dv;
        
        public static void VertexAttrib4dv(uint index, double[] v)
        {
            glVertexAttrib4dv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4FPROC(uint index, float x, float y, float z, float w);
        private static PFNGLVERTEXATTRIB4FPROC glVertexAttrib4f;
        
        public static void VertexAttrib4f(uint index, float x, float y, float z, float w)
        {
            glVertexAttrib4f.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4FVPROC(uint index, float[] v);
        private static PFNGLVERTEXATTRIB4FVPROC glVertexAttrib4fv;
        
        public static void VertexAttrib4fv(uint index, float[] v)
        {
            glVertexAttrib4fv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4IVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIB4IVPROC glVertexAttrib4iv;
        
        public static void VertexAttrib4iv(uint index, int[] v)
        {
            glVertexAttrib4iv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4SPROC(uint index, short x, short y, short z, short w);
        private static PFNGLVERTEXATTRIB4SPROC glVertexAttrib4s;
        
        public static void VertexAttrib4s(uint index, short x, short y, short z, short w)
        {
            glVertexAttrib4s.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4SVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIB4SVPROC glVertexAttrib4sv;
        
        public static void VertexAttrib4sv(uint index, short[] v)
        {
            glVertexAttrib4sv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4UBVPROC(uint index, byte[] v);
        private static PFNGLVERTEXATTRIB4UBVPROC glVertexAttrib4ubv;
        
        public static void VertexAttrib4ubv(uint index, byte[] v)
        {
            glVertexAttrib4ubv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4UIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIB4UIVPROC glVertexAttrib4uiv;
        
        public static void VertexAttrib4uiv(uint index, uint[] v)
        {
            glVertexAttrib4uiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIB4USVPROC(uint index, ushort[] v);
        private static PFNGLVERTEXATTRIB4USVPROC glVertexAttrib4usv;
        
        public static void VertexAttrib4usv(uint index, ushort[] v)
        {
            glVertexAttrib4usv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBPOINTERPROC(uint index, int size, int type, bool normalized, int stride, IntPtr pointer);
        private static PFNGLVERTEXATTRIBPOINTERPROC glVertexAttribPointer;
        
        public static void VertexAttribPointer(uint index, int size, int type, bool normalized, int stride, IntPtr pointer)
        {
            glVertexAttribPointer.Invoke(index, size, type, normalized, stride, pointer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX2X3FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX2X3FVPROC glUniformMatrix2x3fv;
        
        public static void UniformMatrix2x3fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix2x3fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX3X2FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX3X2FVPROC glUniformMatrix3x2fv;
        
        public static void UniformMatrix3x2fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix3x2fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX2X4FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX2X4FVPROC glUniformMatrix2x4fv;
        
        public static void UniformMatrix2x4fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix2x4fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX4X2FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX4X2FVPROC glUniformMatrix4x2fv;
        
        public static void UniformMatrix4x2fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix4x2fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX3X4FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX3X4FVPROC glUniformMatrix3x4fv;
        
        public static void UniformMatrix3x4fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix3x4fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMMATRIX4X3FVPROC(int location, int count, bool transpose, float[] value);
        private static PFNGLUNIFORMMATRIX4X3FVPROC glUniformMatrix4x3fv;
        
        public static void UniformMatrix4x3fv(int location, int count, bool transpose, float[] value)
        {
            glUniformMatrix4x3fv.Invoke(location, count, transpose, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOLORMASKIPROC(uint index, bool r, bool g, bool b, bool a);
        private static PFNGLCOLORMASKIPROC glColorMaski;
        
        public static void ColorMaski(uint index, bool r, bool g, bool b, bool a)
        {
            glColorMaski.Invoke(index, r, g, b, a);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBOOLEANI_VPROC(int target, uint index, out bool data);
        private static PFNGLGETBOOLEANI_VPROC glGetBooleani_v;
        
        public static void GetBooleani_v(int target, uint index, out bool data)
        {
            glGetBooleani_v.Invoke(target, index, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETINTEGERI_VPROC(int target, uint index, out int data);
        private static PFNGLGETINTEGERI_VPROC glGetIntegeri_v;
        
        public static void GetIntegeri_v(int target, uint index, out int data)
        {
            glGetIntegeri_v.Invoke(target, index, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENABLEIPROC(int target, uint index);
        private static PFNGLENABLEIPROC glEnablei;
        
        public static void Enablei(int target, uint index)
        {
            glEnablei.Invoke(target, index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDISABLEIPROC(int target, uint index);
        private static PFNGLDISABLEIPROC glDisablei;
        
        public static void Disablei(int target, uint index)
        {
            glDisablei.Invoke(target, index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISENABLEDIPROC(int target, uint index);
        private static PFNGLISENABLEDIPROC glIsEnabledi;
        
        public static bool IsEnabledi(int target, uint index)
        {
            return glIsEnabledi.Invoke(target, index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBEGINTRANSFORMFEEDBACKPROC(int primitiveMode);
        private static PFNGLBEGINTRANSFORMFEEDBACKPROC glBeginTransformFeedback;
        
        public static void BeginTransformFeedback(int primitiveMode)
        {
            glBeginTransformFeedback.Invoke(primitiveMode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENDTRANSFORMFEEDBACKPROC();
        private static PFNGLENDTRANSFORMFEEDBACKPROC glEndTransformFeedback;
        
        public static void EndTransformFeedback()
        {
            glEndTransformFeedback.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDBUFFERRANGEPROC(int target, uint index, uint buffer, IntPtr offset, IntPtr size);
        private static PFNGLBINDBUFFERRANGEPROC glBindBufferRange;
        
        public static void BindBufferRange(int target, uint index, uint buffer, IntPtr offset, IntPtr size)
        {
            glBindBufferRange.Invoke(target, index, buffer, offset, size);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDBUFFERBASEPROC(int target, uint index, uint buffer);
        private static PFNGLBINDBUFFERBASEPROC glBindBufferBase;
        
        public static void BindBufferBase(int target, uint index, uint buffer)
        {
            glBindBufferBase.Invoke(target, index, buffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTRANSFORMFEEDBACKVARYINGSPROC(uint program, int count, sbyte varyings, int bufferMode);
        private static PFNGLTRANSFORMFEEDBACKVARYINGSPROC glTransformFeedbackVaryings;
        
        public static void TransformFeedbackVaryings(uint program, int count, sbyte varyings, int bufferMode)
        {
            glTransformFeedbackVaryings.Invoke(program, count, varyings, bufferMode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGPROC(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name);
        private static PFNGLGETTRANSFORMFEEDBACKVARYINGPROC glGetTransformFeedbackVarying;
        
        public static void GetTransformFeedbackVarying(uint program, uint index, int bufSize, out int length, out int size, out int type, out sbyte name)
        {
            glGetTransformFeedbackVarying.Invoke(program, index, bufSize, out length, out size, out type, out name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLAMPCOLORPROC(int target, int clamp);
        private static PFNGLCLAMPCOLORPROC glClampColor;
        
        public static void ClampColor(int target, int clamp)
        {
            glClampColor.Invoke(target, clamp);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBEGINCONDITIONALRENDERPROC(uint id, int mode);
        private static PFNGLBEGINCONDITIONALRENDERPROC glBeginConditionalRender;
        
        public static void BeginConditionalRender(uint id, int mode)
        {
            glBeginConditionalRender.Invoke(id, mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLENDCONDITIONALRENDERPROC();
        private static PFNGLENDCONDITIONALRENDERPROC glEndConditionalRender;
        
        public static void EndConditionalRender()
        {
            glEndConditionalRender.Invoke();
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBIPOINTERPROC(uint index, int size, int type, int stride, IntPtr pointer);
        private static PFNGLVERTEXATTRIBIPOINTERPROC glVertexAttribIPointer;
        
        public static void VertexAttribIPointer(uint index, int size, int type, int stride, IntPtr pointer)
        {
            glVertexAttribIPointer.Invoke(index, size, type, stride, pointer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBIIVPROC(uint index, int pname, out int parameters);
        private static PFNGLGETVERTEXATTRIBIIVPROC glGetVertexAttribIiv;
        
        public static void GetVertexAttribIiv(uint index, int pname, out int parameters)
        {
            glGetVertexAttribIiv.Invoke(index, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETVERTEXATTRIBIUIVPROC(uint index, int pname, out uint parameters);
        private static PFNGLGETVERTEXATTRIBIUIVPROC glGetVertexAttribIuiv;
        
        public static void GetVertexAttribIuiv(uint index, int pname, out uint parameters)
        {
            glGetVertexAttribIuiv.Invoke(index, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI1IPROC(uint index, int x);
        private static PFNGLVERTEXATTRIBI1IPROC glVertexAttribI1i;
        
        public static void VertexAttribI1i(uint index, int x)
        {
            glVertexAttribI1i.Invoke(index, x);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI2IPROC(uint index, int x, int y);
        private static PFNGLVERTEXATTRIBI2IPROC glVertexAttribI2i;
        
        public static void VertexAttribI2i(uint index, int x, int y)
        {
            glVertexAttribI2i.Invoke(index, x, y);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI3IPROC(uint index, int x, int y, int z);
        private static PFNGLVERTEXATTRIBI3IPROC glVertexAttribI3i;
        
        public static void VertexAttribI3i(uint index, int x, int y, int z)
        {
            glVertexAttribI3i.Invoke(index, x, y, z);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4IPROC(uint index, int x, int y, int z, int w);
        private static PFNGLVERTEXATTRIBI4IPROC glVertexAttribI4i;
        
        public static void VertexAttribI4i(uint index, int x, int y, int z, int w)
        {
            glVertexAttribI4i.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI1UIPROC(uint index, uint x);
        private static PFNGLVERTEXATTRIBI1UIPROC glVertexAttribI1ui;
        
        public static void VertexAttribI1ui(uint index, uint x)
        {
            glVertexAttribI1ui.Invoke(index, x);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI2UIPROC(uint index, uint x, uint y);
        private static PFNGLVERTEXATTRIBI2UIPROC glVertexAttribI2ui;
        
        public static void VertexAttribI2ui(uint index, uint x, uint y)
        {
            glVertexAttribI2ui.Invoke(index, x, y);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI3UIPROC(uint index, uint x, uint y, uint z);
        private static PFNGLVERTEXATTRIBI3UIPROC glVertexAttribI3ui;
        
        public static void VertexAttribI3ui(uint index, uint x, uint y, uint z)
        {
            glVertexAttribI3ui.Invoke(index, x, y, z);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4UIPROC(uint index, uint x, uint y, uint z, uint w);
        private static PFNGLVERTEXATTRIBI4UIPROC glVertexAttribI4ui;
        
        public static void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w)
        {
            glVertexAttribI4ui.Invoke(index, x, y, z, w);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI1IVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIBI1IVPROC glVertexAttribI1iv;
        
        public static void VertexAttribI1iv(uint index, int[] v)
        {
            glVertexAttribI1iv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI2IVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIBI2IVPROC glVertexAttribI2iv;
        
        public static void VertexAttribI2iv(uint index, int[] v)
        {
            glVertexAttribI2iv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI3IVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIBI3IVPROC glVertexAttribI3iv;
        
        public static void VertexAttribI3iv(uint index, int[] v)
        {
            glVertexAttribI3iv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4IVPROC(uint index, int[] v);
        private static PFNGLVERTEXATTRIBI4IVPROC glVertexAttribI4iv;
        
        public static void VertexAttribI4iv(uint index, int[] v)
        {
            glVertexAttribI4iv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI1UIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIBI1UIVPROC glVertexAttribI1uiv;
        
        public static void VertexAttribI1uiv(uint index, uint[] v)
        {
            glVertexAttribI1uiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI2UIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIBI2UIVPROC glVertexAttribI2uiv;
        
        public static void VertexAttribI2uiv(uint index, uint[] v)
        {
            glVertexAttribI2uiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI3UIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIBI3UIVPROC glVertexAttribI3uiv;
        
        public static void VertexAttribI3uiv(uint index, uint[] v)
        {
            glVertexAttribI3uiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4UIVPROC(uint index, uint[] v);
        private static PFNGLVERTEXATTRIBI4UIVPROC glVertexAttribI4uiv;
        
        public static void VertexAttribI4uiv(uint index, uint[] v)
        {
            glVertexAttribI4uiv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4BVPROC(uint index, sbyte[] v);
        private static PFNGLVERTEXATTRIBI4BVPROC glVertexAttribI4bv;
        
        public static void VertexAttribI4bv(uint index, sbyte[] v)
        {
            glVertexAttribI4bv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4SVPROC(uint index, short[] v);
        private static PFNGLVERTEXATTRIBI4SVPROC glVertexAttribI4sv;
        
        public static void VertexAttribI4sv(uint index, short[] v)
        {
            glVertexAttribI4sv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4UBVPROC(uint index, byte[] v);
        private static PFNGLVERTEXATTRIBI4UBVPROC glVertexAttribI4ubv;
        
        public static void VertexAttribI4ubv(uint index, byte[] v)
        {
            glVertexAttribI4ubv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLVERTEXATTRIBI4USVPROC(uint index, ushort[] v);
        private static PFNGLVERTEXATTRIBI4USVPROC glVertexAttribI4usv;
        
        public static void VertexAttribI4usv(uint index, ushort[] v)
        {
            glVertexAttribI4usv.Invoke(index, v);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETUNIFORMUIVPROC(uint program, int location, out uint parameters);
        private static PFNGLGETUNIFORMUIVPROC glGetUniformuiv;
        
        public static void GetUniformuiv(uint program, int location, out uint parameters)
        {
            glGetUniformuiv.Invoke(program, location, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDFRAGDATALOCATIONPROC(uint program, uint color, sbyte[] name);
        private static PFNGLBINDFRAGDATALOCATIONPROC glBindFragDataLocation;
        
        public static void BindFragDataLocation(uint program, uint color, sbyte[] name)
        {
            glBindFragDataLocation.Invoke(program, color, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLGETFRAGDATALOCATIONPROC(uint program, sbyte[] name);
        private static PFNGLGETFRAGDATALOCATIONPROC glGetFragDataLocation;
        
        public static int GetFragDataLocation(uint program, sbyte[] name)
        {
            return glGetFragDataLocation.Invoke(program, name);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1UIPROC(int location, uint v0);
        private static PFNGLUNIFORM1UIPROC glUniform1ui;
        
        public static void Uniform1ui(int location, uint v0)
        {
            glUniform1ui.Invoke(location, v0);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2UIPROC(int location, uint v0, uint v1);
        private static PFNGLUNIFORM2UIPROC glUniform2ui;
        
        public static void Uniform2ui(int location, uint v0, uint v1)
        {
            glUniform2ui.Invoke(location, v0, v1);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3UIPROC(int location, uint v0, uint v1, uint v2);
        private static PFNGLUNIFORM3UIPROC glUniform3ui;
        
        public static void Uniform3ui(int location, uint v0, uint v1, uint v2)
        {
            glUniform3ui.Invoke(location, v0, v1, v2);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4UIPROC(int location, uint v0, uint v1, uint v2, uint v3);
        private static PFNGLUNIFORM4UIPROC glUniform4ui;
        
        public static void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3)
        {
            glUniform4ui.Invoke(location, v0, v1, v2, v3);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM1UIVPROC(int location, int count, uint[] value);
        private static PFNGLUNIFORM1UIVPROC glUniform1uiv;
        
        public static void Uniform1uiv(int location, int count, uint[] value)
        {
            glUniform1uiv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM2UIVPROC(int location, int count, uint[] value);
        private static PFNGLUNIFORM2UIVPROC glUniform2uiv;
        
        public static void Uniform2uiv(int location, int count, uint[] value)
        {
            glUniform2uiv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM3UIVPROC(int location, int count, uint[] value);
        private static PFNGLUNIFORM3UIVPROC glUniform3uiv;
        
        public static void Uniform3uiv(int location, int count, uint[] value)
        {
            glUniform3uiv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORM4UIVPROC(int location, int count, uint[] value);
        private static PFNGLUNIFORM4UIVPROC glUniform4uiv;
        
        public static void Uniform4uiv(int location, int count, uint[] value)
        {
            glUniform4uiv.Invoke(location, count, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERIIVPROC(int target, int pname, int[] parameters);
        private static PFNGLTEXPARAMETERIIVPROC glTexParameterIiv;
        
        public static void TexParameterIiv(int target, int pname, int[] parameters)
        {
            glTexParameterIiv.Invoke(target, pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXPARAMETERIUIVPROC(int target, int pname, uint[] parameters);
        private static PFNGLTEXPARAMETERIUIVPROC glTexParameterIuiv;
        
        public static void TexParameterIuiv(int target, int pname, uint[] parameters)
        {
            glTexParameterIuiv.Invoke(target, pname, parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXPARAMETERIIVPROC(int target, int pname, out int parameters);
        private static PFNGLGETTEXPARAMETERIIVPROC glGetTexParameterIiv;
        
        public static void GetTexParameterIiv(int target, int pname, out int parameters)
        {
            glGetTexParameterIiv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETTEXPARAMETERIUIVPROC(int target, int pname, out uint parameters);
        private static PFNGLGETTEXPARAMETERIUIVPROC glGetTexParameterIuiv;
        
        public static void GetTexParameterIuiv(int target, int pname, out uint parameters)
        {
            glGetTexParameterIuiv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARBUFFERIVPROC(int buffer, int drawbuffer, int[] value);
        private static PFNGLCLEARBUFFERIVPROC glClearBufferiv;
        
        public static void ClearBufferiv(int buffer, int drawbuffer, int[] value)
        {
            glClearBufferiv.Invoke(buffer, drawbuffer, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARBUFFERUIVPROC(int buffer, int drawbuffer, uint[] value);
        private static PFNGLCLEARBUFFERUIVPROC glClearBufferuiv;
        
        public static void ClearBufferuiv(int buffer, int drawbuffer, uint[] value)
        {
            glClearBufferuiv.Invoke(buffer, drawbuffer, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARBUFFERFVPROC(int buffer, int drawbuffer, float[] value);
        private static PFNGLCLEARBUFFERFVPROC glClearBufferfv;
        
        public static void ClearBufferfv(int buffer, int drawbuffer, float[] value)
        {
            glClearBufferfv.Invoke(buffer, drawbuffer, value);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCLEARBUFFERFIPROC(int buffer, int drawbuffer, float depth, int stencil);
        private static PFNGLCLEARBUFFERFIPROC glClearBufferfi;
        
        public static void ClearBufferfi(int buffer, int drawbuffer, float depth, int stencil)
        {
            glClearBufferfi.Invoke(buffer, drawbuffer, depth, stencil);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PFNGLGETSTRINGIPROC(int name, uint index);
        private static PFNGLGETSTRINGIPROC glGetStringi;
        
        public static IntPtr GetStringi(int name, uint index)
        {
            return glGetStringi.Invoke(name, index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISRENDERBUFFERPROC(uint renderbuffer);
        private static PFNGLISRENDERBUFFERPROC glIsRenderbuffer;
        
        public static bool IsRenderbuffer(uint renderbuffer)
        {
            return glIsRenderbuffer.Invoke(renderbuffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDRENDERBUFFERPROC(int target, uint renderbuffer);
        private static PFNGLBINDRENDERBUFFERPROC glBindRenderbuffer;
        
        public static void BindRenderbuffer(int target, uint renderbuffer)
        {
            glBindRenderbuffer.Invoke(target, renderbuffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETERENDERBUFFERSPROC(int n, uint[] renderbuffers);
        private static PFNGLDELETERENDERBUFFERSPROC glDeleteRenderbuffers;
        
        public static void DeleteRenderbuffers(int n, uint[] renderbuffers)
        {
            glDeleteRenderbuffers.Invoke(n, renderbuffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENRENDERBUFFERSPROC(int n, out uint renderbuffers);
        private static PFNGLGENRENDERBUFFERSPROC glGenRenderbuffers;
        
        public static void GenRenderbuffers(int n, out uint renderbuffers)
        {
            glGenRenderbuffers.Invoke(n, out renderbuffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLRENDERBUFFERSTORAGEPROC(int target, int internalformat, int width, int height);
        private static PFNGLRENDERBUFFERSTORAGEPROC glRenderbufferStorage;
        
        public static void RenderbufferStorage(int target, int internalformat, int width, int height)
        {
            glRenderbufferStorage.Invoke(target, internalformat, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETRENDERBUFFERPARAMETERIVPROC(int target, int pname, out int parameters);
        private static PFNGLGETRENDERBUFFERPARAMETERIVPROC glGetRenderbufferParameteriv;
        
        public static void GetRenderbufferParameteriv(int target, int pname, out int parameters)
        {
            glGetRenderbufferParameteriv.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISFRAMEBUFFERPROC(uint framebuffer);
        private static PFNGLISFRAMEBUFFERPROC glIsFramebuffer;
        
        public static bool IsFramebuffer(uint framebuffer)
        {
            return glIsFramebuffer.Invoke(framebuffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDFRAMEBUFFERPROC(int target, uint framebuffer);
        private static PFNGLBINDFRAMEBUFFERPROC glBindFramebuffer;
        
        public static void BindFramebuffer(int target, uint framebuffer)
        {
            glBindFramebuffer.Invoke(target, framebuffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETEFRAMEBUFFERSPROC(int n, uint[] framebuffers);
        private static PFNGLDELETEFRAMEBUFFERSPROC glDeleteFramebuffers;
        
        public static void DeleteFramebuffers(int n, uint[] framebuffers)
        {
            glDeleteFramebuffers.Invoke(n, framebuffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENFRAMEBUFFERSPROC(int n, out uint framebuffers);
        private static PFNGLGENFRAMEBUFFERSPROC glGenFramebuffers;
        
        public static void GenFramebuffers(int n, out uint framebuffers)
        {
            glGenFramebuffers.Invoke(n, out framebuffers);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLCHECKFRAMEBUFFERSTATUSPROC(int target);
        private static PFNGLCHECKFRAMEBUFFERSTATUSPROC glCheckFramebufferStatus;
        
        public static int CheckFramebufferStatus(int target)
        {
            return glCheckFramebufferStatus.Invoke(target);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERTEXTURE1DPROC(int target, int attachment, int textarget, uint texture, int level);
        private static PFNGLFRAMEBUFFERTEXTURE1DPROC glFramebufferTexture1D;
        
        public static void FramebufferTexture1D(int target, int attachment, int textarget, uint texture, int level)
        {
            glFramebufferTexture1D.Invoke(target, attachment, textarget, texture, level);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERTEXTURE2DPROC(int target, int attachment, int textarget, uint texture, int level);
        private static PFNGLFRAMEBUFFERTEXTURE2DPROC glFramebufferTexture2D;
        
        public static void FramebufferTexture2D(int target, int attachment, int textarget, uint texture, int level)
        {
            glFramebufferTexture2D.Invoke(target, attachment, textarget, texture, level);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERTEXTURE3DPROC(int target, int attachment, int textarget, uint texture, int level, int zoffset);
        private static PFNGLFRAMEBUFFERTEXTURE3DPROC glFramebufferTexture3D;
        
        public static void FramebufferTexture3D(int target, int attachment, int textarget, uint texture, int level, int zoffset)
        {
            glFramebufferTexture3D.Invoke(target, attachment, textarget, texture, level, zoffset);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERRENDERBUFFERPROC(int target, int attachment, int renderbuffertarget, uint renderbuffer);
        private static PFNGLFRAMEBUFFERRENDERBUFFERPROC glFramebufferRenderbuffer;
        
        public static void FramebufferRenderbuffer(int target, int attachment, int renderbuffertarget, uint renderbuffer)
        {
            glFramebufferRenderbuffer.Invoke(target, attachment, renderbuffertarget, renderbuffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC(int target, int attachment, int pname, out int parameters);
        private static PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC glGetFramebufferAttachmentParameteriv;
        
        public static void GetFramebufferAttachmentParameteriv(int target, int attachment, int pname, out int parameters)
        {
            glGetFramebufferAttachmentParameteriv.Invoke(target, attachment, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENERATEMIPMAPPROC(int target);
        private static PFNGLGENERATEMIPMAPPROC glGenerateMipmap;
        
        public static void GenerateMipmap(int target)
        {
            glGenerateMipmap.Invoke(target);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBLITFRAMEBUFFERPROC(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter);
        private static PFNGLBLITFRAMEBUFFERPROC glBlitFramebuffer;
        
        public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, int filter)
        {
            glBlitFramebuffer.Invoke(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC(int target, int samples, int internalformat, int width, int height);
        private static PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC glRenderbufferStorageMultisample;
        
        public static void RenderbufferStorageMultisample(int target, int samples, int internalformat, int width, int height)
        {
            glRenderbufferStorageMultisample.Invoke(target, samples, internalformat, width, height);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERTEXTURELAYERPROC(int target, int attachment, uint texture, int level, int layer);
        private static PFNGLFRAMEBUFFERTEXTURELAYERPROC glFramebufferTextureLayer;
        
        public static void FramebufferTextureLayer(int target, int attachment, uint texture, int level, int layer)
        {
            glFramebufferTextureLayer.Invoke(target, attachment, texture, level, layer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PFNGLMAPBUFFERRANGEPROC(int target, IntPtr offset, IntPtr length, uint access);
        private static PFNGLMAPBUFFERRANGEPROC glMapBufferRange;
        
        public static IntPtr MapBufferRange(int target, IntPtr offset, IntPtr length, uint access)
        {
            return glMapBufferRange.Invoke(target, offset, length, access);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFLUSHMAPPEDBUFFERRANGEPROC(int target, IntPtr offset, IntPtr length);
        private static PFNGLFLUSHMAPPEDBUFFERRANGEPROC glFlushMappedBufferRange;
        
        public static void FlushMappedBufferRange(int target, IntPtr offset, IntPtr length)
        {
            glFlushMappedBufferRange.Invoke(target, offset, length);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLBINDVERTEXARRAYPROC(uint array);
        private static PFNGLBINDVERTEXARRAYPROC glBindVertexArray;
        
        public static void BindVertexArray(uint array)
        {
            glBindVertexArray.Invoke(array);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETEVERTEXARRAYSPROC(int n, uint[] arrays);
        private static PFNGLDELETEVERTEXARRAYSPROC glDeleteVertexArrays;
        
        public static void DeleteVertexArrays(int n, uint[] arrays)
        {
            glDeleteVertexArrays.Invoke(n, arrays);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGENVERTEXARRAYSPROC(int n, out uint arrays);
        private static PFNGLGENVERTEXARRAYSPROC glGenVertexArrays;
        
        public static void GenVertexArrays(int n, out uint arrays)
        {
            glGenVertexArrays.Invoke(n, out arrays);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISVERTEXARRAYPROC(uint array);
        private static PFNGLISVERTEXARRAYPROC glIsVertexArray;
        
        public static bool IsVertexArray(uint array)
        {
            return glIsVertexArray.Invoke(array);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWARRAYSINSTANCEDPROC(int mode, int first, int count, int instancecount);
        private static PFNGLDRAWARRAYSINSTANCEDPROC glDrawArraysInstanced;
        
        public static void DrawArraysInstanced(int mode, int first, int count, int instancecount)
        {
            glDrawArraysInstanced.Invoke(mode, first, count, instancecount);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWELEMENTSINSTANCEDPROC(int mode, int count, int type, IntPtr indices, int instancecount);
        private static PFNGLDRAWELEMENTSINSTANCEDPROC glDrawElementsInstanced;
        
        public static void DrawElementsInstanced(int mode, int count, int type, IntPtr indices, int instancecount)
        {
            glDrawElementsInstanced.Invoke(mode, count, type, indices, instancecount);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXBUFFERPROC(int target, int internalformat, uint buffer);
        private static PFNGLTEXBUFFERPROC glTexBuffer;
        
        public static void TexBuffer(int target, int internalformat, uint buffer)
        {
            glTexBuffer.Invoke(target, internalformat, buffer);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPRIMITIVERESTARTINDEXPROC(uint index);
        private static PFNGLPRIMITIVERESTARTINDEXPROC glPrimitiveRestartIndex;
        
        public static void PrimitiveRestartIndex(uint index)
        {
            glPrimitiveRestartIndex.Invoke(index);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLCOPYBUFFERSUBDATAPROC(int readTarget, int writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size);
        private static PFNGLCOPYBUFFERSUBDATAPROC glCopyBufferSubData;
        
        public static void CopyBufferSubData(int readTarget, int writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            glCopyBufferSubData.Invoke(readTarget, writeTarget, readOffset, writeOffset, size);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETUNIFORMINDICESPROC(uint program, int uniformCount, sbyte uniformNames, out uint uniformIndices);
        private static PFNGLGETUNIFORMINDICESPROC glGetUniformIndices;
        
        public static void GetUniformIndices(uint program, int uniformCount, sbyte uniformNames, out uint uniformIndices)
        {
            glGetUniformIndices.Invoke(program, uniformCount, uniformNames, out uniformIndices);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEUNIFORMSIVPROC(uint program, int uniformCount, uint[] uniformIndices, int pname, out int parameters);
        private static PFNGLGETACTIVEUNIFORMSIVPROC glGetActiveUniformsiv;
        
        public static void GetActiveUniformsiv(uint program, int uniformCount, uint[] uniformIndices, int pname, out int parameters)
        {
            glGetActiveUniformsiv.Invoke(program, uniformCount, uniformIndices, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEUNIFORMNAMEPROC(uint program, uint uniformIndex, int bufSize, out int length, out sbyte uniformName);
        private static PFNGLGETACTIVEUNIFORMNAMEPROC glGetActiveUniformName;
        
        public static void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, out int length, out sbyte uniformName)
        {
            glGetActiveUniformName.Invoke(program, uniformIndex, bufSize, out length, out uniformName);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint PFNGLGETUNIFORMBLOCKINDEXPROC(uint program, sbyte[] uniformBlockName);
        private static PFNGLGETUNIFORMBLOCKINDEXPROC glGetUniformBlockIndex;
        
        public static uint GetUniformBlockIndex(uint program, sbyte[] uniformBlockName)
        {
            return glGetUniformBlockIndex.Invoke(program, uniformBlockName);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEUNIFORMBLOCKIVPROC(uint program, uint uniformBlockIndex, int pname, out int parameters);
        private static PFNGLGETACTIVEUNIFORMBLOCKIVPROC glGetActiveUniformBlockiv;
        
        public static void GetActiveUniformBlockiv(uint program, uint uniformBlockIndex, int pname, out int parameters)
        {
            glGetActiveUniformBlockiv.Invoke(program, uniformBlockIndex, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC(uint program, uint uniformBlockIndex, int bufSize, out int length, out sbyte uniformBlockName);
        private static PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC glGetActiveUniformBlockName;
        
        public static void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, out int length, out sbyte uniformBlockName)
        {
            glGetActiveUniformBlockName.Invoke(program, uniformBlockIndex, bufSize, out length, out uniformBlockName);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLUNIFORMBLOCKBINDINGPROC(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
        private static PFNGLUNIFORMBLOCKBINDINGPROC glUniformBlockBinding;
        
        public static void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
        {
            glUniformBlockBinding.Invoke(program, uniformBlockIndex, uniformBlockBinding);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWELEMENTSBASEVERTEXPROC(int mode, int count, int type, IntPtr indices, int basevertex);
        private static PFNGLDRAWELEMENTSBASEVERTEXPROC glDrawElementsBaseVertex;
        
        public static void DrawElementsBaseVertex(int mode, int count, int type, IntPtr indices, int basevertex)
        {
            glDrawElementsBaseVertex.Invoke(mode, count, type, indices, basevertex);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC(int mode, uint start, uint end, int count, int type, IntPtr indices, int basevertex);
        private static PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC glDrawRangeElementsBaseVertex;
        
        public static void DrawRangeElementsBaseVertex(int mode, uint start, uint end, int count, int type, IntPtr indices, int basevertex)
        {
            glDrawRangeElementsBaseVertex.Invoke(mode, start, end, count, type, indices, basevertex);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC(int mode, int count, int type, IntPtr indices, int instancecount, int basevertex);
        private static PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC glDrawElementsInstancedBaseVertex;
        
        public static void DrawElementsInstancedBaseVertex(int mode, int count, int type, IntPtr indices, int instancecount, int basevertex)
        {
            glDrawElementsInstancedBaseVertex.Invoke(mode, count, type, indices, instancecount, basevertex);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC(int mode, int[] count, int type, IntPtr indices, int drawcount, int[] basevertex);
        private static PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC glMultiDrawElementsBaseVertex;
        
        public static void MultiDrawElementsBaseVertex(int mode, int[] count, int type, IntPtr indices, int drawcount, int[] basevertex)
        {
            glMultiDrawElementsBaseVertex.Invoke(mode, count, type, indices, drawcount, basevertex);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLPROVOKINGVERTEXPROC(int mode);
        private static PFNGLPROVOKINGVERTEXPROC glProvokingVertex;
        
        public static void ProvokingVertex(int mode)
        {
            glProvokingVertex.Invoke(mode);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PFNGLFENCESYNCPROC(int condition, uint flags);
        private static PFNGLFENCESYNCPROC glFenceSync;
        
        public static IntPtr FenceSync(int condition, uint flags)
        {
            return glFenceSync.Invoke(condition, flags);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool PFNGLISSYNCPROC(IntPtr sync);
        private static PFNGLISSYNCPROC glIsSync;
        
        public static bool IsSync(IntPtr sync)
        {
            return glIsSync.Invoke(sync);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLDELETESYNCPROC(IntPtr sync);
        private static PFNGLDELETESYNCPROC glDeleteSync;
        
        public static void DeleteSync(IntPtr sync)
        {
            glDeleteSync.Invoke(sync);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PFNGLCLIENTWAITSYNCPROC(IntPtr sync, uint flags, ulong timeout);
        private static PFNGLCLIENTWAITSYNCPROC glClientWaitSync;
        
        public static int ClientWaitSync(IntPtr sync, uint flags, ulong timeout)
        {
            return glClientWaitSync.Invoke(sync, flags, timeout);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLWAITSYNCPROC(IntPtr sync, uint flags, ulong timeout);
        private static PFNGLWAITSYNCPROC glWaitSync;
        
        public static void WaitSync(IntPtr sync, uint flags, ulong timeout)
        {
            glWaitSync.Invoke(sync, flags, timeout);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETINTEGER64VPROC(int pname, out long data);
        private static PFNGLGETINTEGER64VPROC glGetInteger64v;
        
        public static void GetInteger64v(int pname, out long data)
        {
            glGetInteger64v.Invoke(pname, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETSYNCIVPROC(IntPtr sync, int pname, int count, out int length, out int values);
        private static PFNGLGETSYNCIVPROC glGetSynciv;
        
        public static void GetSynciv(IntPtr sync, int pname, int count, out int length, out int values)
        {
            glGetSynciv.Invoke(sync, pname, count, out length, out values);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETINTEGER64I_VPROC(int target, uint index, out long data);
        private static PFNGLGETINTEGER64I_VPROC glGetInteger64i_v;
        
        public static void GetInteger64i_v(int target, uint index, out long data)
        {
            glGetInteger64i_v.Invoke(target, index, out data);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETBUFFERPARAMETERI64VPROC(int target, int pname, out long parameters);
        private static PFNGLGETBUFFERPARAMETERI64VPROC glGetBufferParameteri64v;
        
        public static void GetBufferParameteri64v(int target, int pname, out long parameters)
        {
            glGetBufferParameteri64v.Invoke(target, pname, out parameters);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLFRAMEBUFFERTEXTUREPROC(int target, int attachment, uint texture, int level);
        private static PFNGLFRAMEBUFFERTEXTUREPROC glFramebufferTexture;
        
        public static void FramebufferTexture(int target, int attachment, uint texture, int level)
        {
            glFramebufferTexture.Invoke(target, attachment, texture, level);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXIMAGE2DMULTISAMPLEPROC(int target, int samples, int internalformat, int width, int height, bool fixedsamplelocations);
        private static PFNGLTEXIMAGE2DMULTISAMPLEPROC glTexImage2DMultisample;
        
        public static void TexImage2DMultisample(int target, int samples, int internalformat, int width, int height, bool fixedsamplelocations)
        {
            glTexImage2DMultisample.Invoke(target, samples, internalformat, width, height, fixedsamplelocations);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLTEXIMAGE3DMULTISAMPLEPROC(int target, int samples, int internalformat, int width, int height, int depth, bool fixedsamplelocations);
        private static PFNGLTEXIMAGE3DMULTISAMPLEPROC glTexImage3DMultisample;
        
        public static void TexImage3DMultisample(int target, int samples, int internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            glTexImage3DMultisample.Invoke(target, samples, internalformat, width, height, depth, fixedsamplelocations);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLGETMULTISAMPLEFVPROC(int pname, uint index, out float val);
        private static PFNGLGETMULTISAMPLEFVPROC glGetMultisamplefv;
        
        public static void GetMultisamplefv(int pname, uint index, out float val)
        {
            glGetMultisamplefv.Invoke(pname, index, out val);
        }
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void PFNGLSAMPLEMASKIPROC(uint maskNumber, uint mask);
        private static PFNGLSAMPLEMASKIPROC glSampleMaski;
        
        public static void SampleMaski(uint maskNumber, uint mask)
        {
            glSampleMaski.Invoke(maskNumber, mask);
        }
        
        public static void Initialize(GetProcAddressHandler loader)
        {
            glCullFace = Marshal.GetDelegateForFunctionPointer<PFNGLCULLFACEPROC>(loader.Invoke("glCullFace"));
            glFrontFace = Marshal.GetDelegateForFunctionPointer<PFNGLFRONTFACEPROC>(loader.Invoke("glFrontFace"));
            glHint = Marshal.GetDelegateForFunctionPointer<PFNGLHINTPROC>(loader.Invoke("glHint"));
            glLineWidth = Marshal.GetDelegateForFunctionPointer<PFNGLLINEWIDTHPROC>(loader.Invoke("glLineWidth"));
            glPointSize = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTSIZEPROC>(loader.Invoke("glPointSize"));
            glPolygonMode = Marshal.GetDelegateForFunctionPointer<PFNGLPOLYGONMODEPROC>(loader.Invoke("glPolygonMode"));
            glScissor = Marshal.GetDelegateForFunctionPointer<PFNGLSCISSORPROC>(loader.Invoke("glScissor"));
            glTexParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERFPROC>(loader.Invoke("glTexParameterf"));
            glTexParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERFVPROC>(loader.Invoke("glTexParameterfv"));
            glTexParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIPROC>(loader.Invoke("glTexParameteri"));
            glTexParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIVPROC>(loader.Invoke("glTexParameteriv"));
            glTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE1DPROC>(loader.Invoke("glTexImage1D"));
            glTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE2DPROC>(loader.Invoke("glTexImage2D"));
            glDrawBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWBUFFERPROC>(loader.Invoke("glDrawBuffer"));
            glClear = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARPROC>(loader.Invoke("glClear"));
            glClearColor = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARCOLORPROC>(loader.Invoke("glClearColor"));
            glClearStencil = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARSTENCILPROC>(loader.Invoke("glClearStencil"));
            glClearDepth = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARDEPTHPROC>(loader.Invoke("glClearDepth"));
            glStencilMask = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILMASKPROC>(loader.Invoke("glStencilMask"));
            glColorMask = Marshal.GetDelegateForFunctionPointer<PFNGLCOLORMASKPROC>(loader.Invoke("glColorMask"));
            glDepthMask = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHMASKPROC>(loader.Invoke("glDepthMask"));
            glDisable = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEPROC>(loader.Invoke("glDisable"));
            glEnable = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEPROC>(loader.Invoke("glEnable"));
            glFinish = Marshal.GetDelegateForFunctionPointer<PFNGLFINISHPROC>(loader.Invoke("glFinish"));
            glFlush = Marshal.GetDelegateForFunctionPointer<PFNGLFLUSHPROC>(loader.Invoke("glFlush"));
            glBlendFunc = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCPROC>(loader.Invoke("glBlendFunc"));
            glLogicOp = Marshal.GetDelegateForFunctionPointer<PFNGLLOGICOPPROC>(loader.Invoke("glLogicOp"));
            glStencilFunc = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILFUNCPROC>(loader.Invoke("glStencilFunc"));
            glStencilOp = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILOPPROC>(loader.Invoke("glStencilOp"));
            glDepthFunc = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHFUNCPROC>(loader.Invoke("glDepthFunc"));
            glPixelStoref = Marshal.GetDelegateForFunctionPointer<PFNGLPIXELSTOREFPROC>(loader.Invoke("glPixelStoref"));
            glPixelStorei = Marshal.GetDelegateForFunctionPointer<PFNGLPIXELSTOREIPROC>(loader.Invoke("glPixelStorei"));
            glReadBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLREADBUFFERPROC>(loader.Invoke("glReadBuffer"));
            glReadPixels = Marshal.GetDelegateForFunctionPointer<PFNGLREADPIXELSPROC>(loader.Invoke("glReadPixels"));
            glGetBooleanv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBOOLEANVPROC>(loader.Invoke("glGetBooleanv"));
            glGetDoublev = Marshal.GetDelegateForFunctionPointer<PFNGLGETDOUBLEVPROC>(loader.Invoke("glGetDoublev"));
            glGetError = Marshal.GetDelegateForFunctionPointer<PFNGLGETERRORPROC>(loader.Invoke("glGetError"));
            glGetFloatv = Marshal.GetDelegateForFunctionPointer<PFNGLGETFLOATVPROC>(loader.Invoke("glGetFloatv"));
            glGetIntegerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGERVPROC>(loader.Invoke("glGetIntegerv"));
            glGetString = Marshal.GetDelegateForFunctionPointer<PFNGLGETSTRINGPROC>(loader.Invoke("glGetString"));
            glGetTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXIMAGEPROC>(loader.Invoke("glGetTexImage"));
            glGetTexParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERFVPROC>(loader.Invoke("glGetTexParameterfv"));
            glGetTexParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIVPROC>(loader.Invoke("glGetTexParameteriv"));
            glGetTexLevelParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXLEVELPARAMETERFVPROC>(loader.Invoke("glGetTexLevelParameterfv"));
            glGetTexLevelParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXLEVELPARAMETERIVPROC>(loader.Invoke("glGetTexLevelParameteriv"));
            glIsEnabled = Marshal.GetDelegateForFunctionPointer<PFNGLISENABLEDPROC>(loader.Invoke("glIsEnabled"));
            glDepthRange = Marshal.GetDelegateForFunctionPointer<PFNGLDEPTHRANGEPROC>(loader.Invoke("glDepthRange"));
            glViewport = Marshal.GetDelegateForFunctionPointer<PFNGLVIEWPORTPROC>(loader.Invoke("glViewport"));
            glDrawArrays = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSPROC>(loader.Invoke("glDrawArrays"));
            glDrawElements = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSPROC>(loader.Invoke("glDrawElements"));
            glPolygonOffset = Marshal.GetDelegateForFunctionPointer<PFNGLPOLYGONOFFSETPROC>(loader.Invoke("glPolygonOffset"));
            glCopyTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXIMAGE1DPROC>(loader.Invoke("glCopyTexImage1D"));
            glCopyTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXIMAGE2DPROC>(loader.Invoke("glCopyTexImage2D"));
            glCopyTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE1DPROC>(loader.Invoke("glCopyTexSubImage1D"));
            glCopyTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE2DPROC>(loader.Invoke("glCopyTexSubImage2D"));
            glTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE1DPROC>(loader.Invoke("glTexSubImage1D"));
            glTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE2DPROC>(loader.Invoke("glTexSubImage2D"));
            glBindTexture = Marshal.GetDelegateForFunctionPointer<PFNGLBINDTEXTUREPROC>(loader.Invoke("glBindTexture"));
            glDeleteTextures = Marshal.GetDelegateForFunctionPointer<PFNGLDELETETEXTURESPROC>(loader.Invoke("glDeleteTextures"));
            glGenTextures = Marshal.GetDelegateForFunctionPointer<PFNGLGENTEXTURESPROC>(loader.Invoke("glGenTextures"));
            glIsTexture = Marshal.GetDelegateForFunctionPointer<PFNGLISTEXTUREPROC>(loader.Invoke("glIsTexture"));
            glDrawRangeElements = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWRANGEELEMENTSPROC>(loader.Invoke("glDrawRangeElements"));
            glTexImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE3DPROC>(loader.Invoke("glTexImage3D"));
            glTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLTEXSUBIMAGE3DPROC>(loader.Invoke("glTexSubImage3D"));
            glCopyTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYTEXSUBIMAGE3DPROC>(loader.Invoke("glCopyTexSubImage3D"));
            glActiveTexture = Marshal.GetDelegateForFunctionPointer<PFNGLACTIVETEXTUREPROC>(loader.Invoke("glActiveTexture"));
            glSampleCoverage = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLECOVERAGEPROC>(loader.Invoke("glSampleCoverage"));
            glCompressedTexImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE3DPROC>(loader.Invoke("glCompressedTexImage3D"));
            glCompressedTexImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE2DPROC>(loader.Invoke("glCompressedTexImage2D"));
            glCompressedTexImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXIMAGE1DPROC>(loader.Invoke("glCompressedTexImage1D"));
            glCompressedTexSubImage3D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC>(loader.Invoke("glCompressedTexSubImage3D"));
            glCompressedTexSubImage2D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC>(loader.Invoke("glCompressedTexSubImage2D"));
            glCompressedTexSubImage1D = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC>(loader.Invoke("glCompressedTexSubImage1D"));
            glGetCompressedTexImage = Marshal.GetDelegateForFunctionPointer<PFNGLGETCOMPRESSEDTEXIMAGEPROC>(loader.Invoke("glGetCompressedTexImage"));
            glBlendFuncSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDFUNCSEPARATEPROC>(loader.Invoke("glBlendFuncSeparate"));
            glMultiDrawArrays = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWARRAYSPROC>(loader.Invoke("glMultiDrawArrays"));
            glMultiDrawElements = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSPROC>(loader.Invoke("glMultiDrawElements"));
            glPointParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERFPROC>(loader.Invoke("glPointParameterf"));
            glPointParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERFVPROC>(loader.Invoke("glPointParameterfv"));
            glPointParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERIPROC>(loader.Invoke("glPointParameteri"));
            glPointParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLPOINTPARAMETERIVPROC>(loader.Invoke("glPointParameteriv"));
            glVertexAttribP4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP4UIVPROC>(loader.Invoke("glVertexAttribP4uiv"));
            glVertexAttribP4ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP4UIPROC>(loader.Invoke("glVertexAttribP4ui"));
            glVertexAttribP3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP3UIVPROC>(loader.Invoke("glVertexAttribP3uiv"));
            glVertexAttribP3ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP3UIPROC>(loader.Invoke("glVertexAttribP3ui"));
            glVertexAttribP2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP2UIVPROC>(loader.Invoke("glVertexAttribP2uiv"));
            glVertexAttribP2ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP2UIPROC>(loader.Invoke("glVertexAttribP2ui"));
            glVertexAttribP1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP1UIVPROC>(loader.Invoke("glVertexAttribP1uiv"));
            glVertexAttribP1ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBP1UIPROC>(loader.Invoke("glVertexAttribP1ui"));
            glVertexAttribDivisor = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBDIVISORPROC>(loader.Invoke("glVertexAttribDivisor"));
            glGetQueryObjectui64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTUI64VPROC>(loader.Invoke("glGetQueryObjectui64v"));
            glGetQueryObjecti64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTI64VPROC>(loader.Invoke("glGetQueryObjecti64v"));
            glQueryCounter = Marshal.GetDelegateForFunctionPointer<PFNGLQUERYCOUNTERPROC>(loader.Invoke("glQueryCounter"));
            glGetSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIUIVPROC>(loader.Invoke("glGetSamplerParameterIuiv"));
            glGetSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERFVPROC>(loader.Invoke("glGetSamplerParameterfv"));
            glGetSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIIVPROC>(loader.Invoke("glGetSamplerParameterIiv"));
            glGetSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSAMPLERPARAMETERIVPROC>(loader.Invoke("glGetSamplerParameteriv"));
            glSamplerParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIUIVPROC>(loader.Invoke("glSamplerParameterIuiv"));
            glSamplerParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIIVPROC>(loader.Invoke("glSamplerParameterIiv"));
            glSamplerParameterfv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERFVPROC>(loader.Invoke("glSamplerParameterfv"));
            glSamplerParameterf = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERFPROC>(loader.Invoke("glSamplerParameterf"));
            glSamplerParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIVPROC>(loader.Invoke("glSamplerParameteriv"));
            glSamplerParameteri = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLERPARAMETERIPROC>(loader.Invoke("glSamplerParameteri"));
            glBindSampler = Marshal.GetDelegateForFunctionPointer<PFNGLBINDSAMPLERPROC>(loader.Invoke("glBindSampler"));
            glIsSampler = Marshal.GetDelegateForFunctionPointer<PFNGLISSAMPLERPROC>(loader.Invoke("glIsSampler"));
            glDeleteSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESAMPLERSPROC>(loader.Invoke("glDeleteSamplers"));
            glGenSamplers = Marshal.GetDelegateForFunctionPointer<PFNGLGENSAMPLERSPROC>(loader.Invoke("glGenSamplers"));
            glGetFragDataIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAGDATAINDEXPROC>(loader.Invoke("glGetFragDataIndex"));
            glBindFragDataLocationIndexed = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAGDATALOCATIONINDEXEDPROC>(loader.Invoke("glBindFragDataLocationIndexed"));
            glBlendColor = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDCOLORPROC>(loader.Invoke("glBlendColor"));
            glBlendEquation = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONPROC>(loader.Invoke("glBlendEquation"));
            glGenQueries = Marshal.GetDelegateForFunctionPointer<PFNGLGENQUERIESPROC>(loader.Invoke("glGenQueries"));
            glDeleteQueries = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEQUERIESPROC>(loader.Invoke("glDeleteQueries"));
            glIsQuery = Marshal.GetDelegateForFunctionPointer<PFNGLISQUERYPROC>(loader.Invoke("glIsQuery"));
            glBeginQuery = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINQUERYPROC>(loader.Invoke("glBeginQuery"));
            glEndQuery = Marshal.GetDelegateForFunctionPointer<PFNGLENDQUERYPROC>(loader.Invoke("glEndQuery"));
            glGetQueryiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYIVPROC>(loader.Invoke("glGetQueryiv"));
            glGetQueryObjectiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTIVPROC>(loader.Invoke("glGetQueryObjectiv"));
            glGetQueryObjectuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETQUERYOBJECTUIVPROC>(loader.Invoke("glGetQueryObjectuiv"));
            glBindBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERPROC>(loader.Invoke("glBindBuffer"));
            glDeleteBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEBUFFERSPROC>(loader.Invoke("glDeleteBuffers"));
            glGenBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENBUFFERSPROC>(loader.Invoke("glGenBuffers"));
            glIsBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISBUFFERPROC>(loader.Invoke("glIsBuffer"));
            glBufferData = Marshal.GetDelegateForFunctionPointer<PFNGLBUFFERDATAPROC>(loader.Invoke("glBufferData"));
            glBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLBUFFERSUBDATAPROC>(loader.Invoke("glBufferSubData"));
            glGetBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERSUBDATAPROC>(loader.Invoke("glGetBufferSubData"));
            glMapBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLMAPBUFFERPROC>(loader.Invoke("glMapBuffer"));
            glUnmapBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLUNMAPBUFFERPROC>(loader.Invoke("glUnmapBuffer"));
            glGetBufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPARAMETERIVPROC>(loader.Invoke("glGetBufferParameteriv"));
            glGetBufferPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPOINTERVPROC>(loader.Invoke("glGetBufferPointerv"));
            glBlendEquationSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLBLENDEQUATIONSEPARATEPROC>(loader.Invoke("glBlendEquationSeparate"));
            glDrawBuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWBUFFERSPROC>(loader.Invoke("glDrawBuffers"));
            glStencilOpSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILOPSEPARATEPROC>(loader.Invoke("glStencilOpSeparate"));
            glStencilFuncSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILFUNCSEPARATEPROC>(loader.Invoke("glStencilFuncSeparate"));
            glStencilMaskSeparate = Marshal.GetDelegateForFunctionPointer<PFNGLSTENCILMASKSEPARATEPROC>(loader.Invoke("glStencilMaskSeparate"));
            glAttachShader = Marshal.GetDelegateForFunctionPointer<PFNGLATTACHSHADERPROC>(loader.Invoke("glAttachShader"));
            glBindAttribLocation = Marshal.GetDelegateForFunctionPointer<PFNGLBINDATTRIBLOCATIONPROC>(loader.Invoke("glBindAttribLocation"));
            glCompileShader = Marshal.GetDelegateForFunctionPointer<PFNGLCOMPILESHADERPROC>(loader.Invoke("glCompileShader"));
            glCreateProgram = Marshal.GetDelegateForFunctionPointer<PFNGLCREATEPROGRAMPROC>(loader.Invoke("glCreateProgram"));
            glCreateShader = Marshal.GetDelegateForFunctionPointer<PFNGLCREATESHADERPROC>(loader.Invoke("glCreateShader"));
            glDeleteProgram = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEPROGRAMPROC>(loader.Invoke("glDeleteProgram"));
            glDeleteShader = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESHADERPROC>(loader.Invoke("glDeleteShader"));
            glDetachShader = Marshal.GetDelegateForFunctionPointer<PFNGLDETACHSHADERPROC>(loader.Invoke("glDetachShader"));
            glDisableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEVERTEXATTRIBARRAYPROC>(loader.Invoke("glDisableVertexAttribArray"));
            glEnableVertexAttribArray = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEVERTEXATTRIBARRAYPROC>(loader.Invoke("glEnableVertexAttribArray"));
            glGetActiveAttrib = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEATTRIBPROC>(loader.Invoke("glGetActiveAttrib"));
            glGetActiveUniform = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMPROC>(loader.Invoke("glGetActiveUniform"));
            glGetAttachedShaders = Marshal.GetDelegateForFunctionPointer<PFNGLGETATTACHEDSHADERSPROC>(loader.Invoke("glGetAttachedShaders"));
            glGetAttribLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETATTRIBLOCATIONPROC>(loader.Invoke("glGetAttribLocation"));
            glGetProgramiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMIVPROC>(loader.Invoke("glGetProgramiv"));
            glGetProgramInfoLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETPROGRAMINFOLOGPROC>(loader.Invoke("glGetProgramInfoLog"));
            glGetShaderiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERIVPROC>(loader.Invoke("glGetShaderiv"));
            glGetShaderInfoLog = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERINFOLOGPROC>(loader.Invoke("glGetShaderInfoLog"));
            glGetShaderSource = Marshal.GetDelegateForFunctionPointer<PFNGLGETSHADERSOURCEPROC>(loader.Invoke("glGetShaderSource"));
            glGetUniformLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMLOCATIONPROC>(loader.Invoke("glGetUniformLocation"));
            glGetUniformfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMFVPROC>(loader.Invoke("glGetUniformfv"));
            glGetUniformiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMIVPROC>(loader.Invoke("glGetUniformiv"));
            glGetVertexAttribdv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBDVPROC>(loader.Invoke("glGetVertexAttribdv"));
            glGetVertexAttribfv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBFVPROC>(loader.Invoke("glGetVertexAttribfv"));
            glGetVertexAttribiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIVPROC>(loader.Invoke("glGetVertexAttribiv"));
            glGetVertexAttribPointerv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBPOINTERVPROC>(loader.Invoke("glGetVertexAttribPointerv"));
            glIsProgram = Marshal.GetDelegateForFunctionPointer<PFNGLISPROGRAMPROC>(loader.Invoke("glIsProgram"));
            glIsShader = Marshal.GetDelegateForFunctionPointer<PFNGLISSHADERPROC>(loader.Invoke("glIsShader"));
            glLinkProgram = Marshal.GetDelegateForFunctionPointer<PFNGLLINKPROGRAMPROC>(loader.Invoke("glLinkProgram"));
            glShaderSource = Marshal.GetDelegateForFunctionPointer<PFNGLSHADERSOURCEPROC>(loader.Invoke("glShaderSource"));
            glUseProgram = Marshal.GetDelegateForFunctionPointer<PFNGLUSEPROGRAMPROC>(loader.Invoke("glUseProgram"));
            glUniform1f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1FPROC>(loader.Invoke("glUniform1f"));
            glUniform2f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2FPROC>(loader.Invoke("glUniform2f"));
            glUniform3f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3FPROC>(loader.Invoke("glUniform3f"));
            glUniform4f = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4FPROC>(loader.Invoke("glUniform4f"));
            glUniform1i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1IPROC>(loader.Invoke("glUniform1i"));
            glUniform2i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2IPROC>(loader.Invoke("glUniform2i"));
            glUniform3i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3IPROC>(loader.Invoke("glUniform3i"));
            glUniform4i = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4IPROC>(loader.Invoke("glUniform4i"));
            glUniform1fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1FVPROC>(loader.Invoke("glUniform1fv"));
            glUniform2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2FVPROC>(loader.Invoke("glUniform2fv"));
            glUniform3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3FVPROC>(loader.Invoke("glUniform3fv"));
            glUniform4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4FVPROC>(loader.Invoke("glUniform4fv"));
            glUniform1iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1IVPROC>(loader.Invoke("glUniform1iv"));
            glUniform2iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2IVPROC>(loader.Invoke("glUniform2iv"));
            glUniform3iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3IVPROC>(loader.Invoke("glUniform3iv"));
            glUniform4iv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4IVPROC>(loader.Invoke("glUniform4iv"));
            glUniformMatrix2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2FVPROC>(loader.Invoke("glUniformMatrix2fv"));
            glUniformMatrix3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3FVPROC>(loader.Invoke("glUniformMatrix3fv"));
            glUniformMatrix4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4FVPROC>(loader.Invoke("glUniformMatrix4fv"));
            glValidateProgram = Marshal.GetDelegateForFunctionPointer<PFNGLVALIDATEPROGRAMPROC>(loader.Invoke("glValidateProgram"));
            glVertexAttrib1d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1DPROC>(loader.Invoke("glVertexAttrib1d"));
            glVertexAttrib1dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1DVPROC>(loader.Invoke("glVertexAttrib1dv"));
            glVertexAttrib1f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1FPROC>(loader.Invoke("glVertexAttrib1f"));
            glVertexAttrib1fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1FVPROC>(loader.Invoke("glVertexAttrib1fv"));
            glVertexAttrib1s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1SPROC>(loader.Invoke("glVertexAttrib1s"));
            glVertexAttrib1sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB1SVPROC>(loader.Invoke("glVertexAttrib1sv"));
            glVertexAttrib2d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2DPROC>(loader.Invoke("glVertexAttrib2d"));
            glVertexAttrib2dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2DVPROC>(loader.Invoke("glVertexAttrib2dv"));
            glVertexAttrib2f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2FPROC>(loader.Invoke("glVertexAttrib2f"));
            glVertexAttrib2fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2FVPROC>(loader.Invoke("glVertexAttrib2fv"));
            glVertexAttrib2s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2SPROC>(loader.Invoke("glVertexAttrib2s"));
            glVertexAttrib2sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB2SVPROC>(loader.Invoke("glVertexAttrib2sv"));
            glVertexAttrib3d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3DPROC>(loader.Invoke("glVertexAttrib3d"));
            glVertexAttrib3dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3DVPROC>(loader.Invoke("glVertexAttrib3dv"));
            glVertexAttrib3f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3FPROC>(loader.Invoke("glVertexAttrib3f"));
            glVertexAttrib3fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3FVPROC>(loader.Invoke("glVertexAttrib3fv"));
            glVertexAttrib3s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3SPROC>(loader.Invoke("glVertexAttrib3s"));
            glVertexAttrib3sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB3SVPROC>(loader.Invoke("glVertexAttrib3sv"));
            glVertexAttrib4Nbv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NBVPROC>(loader.Invoke("glVertexAttrib4Nbv"));
            glVertexAttrib4Niv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NIVPROC>(loader.Invoke("glVertexAttrib4Niv"));
            glVertexAttrib4Nsv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NSVPROC>(loader.Invoke("glVertexAttrib4Nsv"));
            glVertexAttrib4Nub = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUBPROC>(loader.Invoke("glVertexAttrib4Nub"));
            glVertexAttrib4Nubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUBVPROC>(loader.Invoke("glVertexAttrib4Nubv"));
            glVertexAttrib4Nuiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUIVPROC>(loader.Invoke("glVertexAttrib4Nuiv"));
            glVertexAttrib4Nusv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4NUSVPROC>(loader.Invoke("glVertexAttrib4Nusv"));
            glVertexAttrib4bv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4BVPROC>(loader.Invoke("glVertexAttrib4bv"));
            glVertexAttrib4d = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4DPROC>(loader.Invoke("glVertexAttrib4d"));
            glVertexAttrib4dv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4DVPROC>(loader.Invoke("glVertexAttrib4dv"));
            glVertexAttrib4f = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4FPROC>(loader.Invoke("glVertexAttrib4f"));
            glVertexAttrib4fv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4FVPROC>(loader.Invoke("glVertexAttrib4fv"));
            glVertexAttrib4iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4IVPROC>(loader.Invoke("glVertexAttrib4iv"));
            glVertexAttrib4s = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4SPROC>(loader.Invoke("glVertexAttrib4s"));
            glVertexAttrib4sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4SVPROC>(loader.Invoke("glVertexAttrib4sv"));
            glVertexAttrib4ubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4UBVPROC>(loader.Invoke("glVertexAttrib4ubv"));
            glVertexAttrib4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4UIVPROC>(loader.Invoke("glVertexAttrib4uiv"));
            glVertexAttrib4usv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIB4USVPROC>(loader.Invoke("glVertexAttrib4usv"));
            glVertexAttribPointer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBPOINTERPROC>(loader.Invoke("glVertexAttribPointer"));
            glUniformMatrix2x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X3FVPROC>(loader.Invoke("glUniformMatrix2x3fv"));
            glUniformMatrix3x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X2FVPROC>(loader.Invoke("glUniformMatrix3x2fv"));
            glUniformMatrix2x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX2X4FVPROC>(loader.Invoke("glUniformMatrix2x4fv"));
            glUniformMatrix4x2fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X2FVPROC>(loader.Invoke("glUniformMatrix4x2fv"));
            glUniformMatrix3x4fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX3X4FVPROC>(loader.Invoke("glUniformMatrix3x4fv"));
            glUniformMatrix4x3fv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMMATRIX4X3FVPROC>(loader.Invoke("glUniformMatrix4x3fv"));
            glColorMaski = Marshal.GetDelegateForFunctionPointer<PFNGLCOLORMASKIPROC>(loader.Invoke("glColorMaski"));
            glGetBooleani_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETBOOLEANI_VPROC>(loader.Invoke("glGetBooleani_v"));
            glGetIntegeri_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGERI_VPROC>(loader.Invoke("glGetIntegeri_v"));
            glEnablei = Marshal.GetDelegateForFunctionPointer<PFNGLENABLEIPROC>(loader.Invoke("glEnablei"));
            glDisablei = Marshal.GetDelegateForFunctionPointer<PFNGLDISABLEIPROC>(loader.Invoke("glDisablei"));
            glIsEnabledi = Marshal.GetDelegateForFunctionPointer<PFNGLISENABLEDIPROC>(loader.Invoke("glIsEnabledi"));
            glBeginTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINTRANSFORMFEEDBACKPROC>(loader.Invoke("glBeginTransformFeedback"));
            glEndTransformFeedback = Marshal.GetDelegateForFunctionPointer<PFNGLENDTRANSFORMFEEDBACKPROC>(loader.Invoke("glEndTransformFeedback"));
            glBindBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERRANGEPROC>(loader.Invoke("glBindBufferRange"));
            glBindBufferBase = Marshal.GetDelegateForFunctionPointer<PFNGLBINDBUFFERBASEPROC>(loader.Invoke("glBindBufferBase"));
            glTransformFeedbackVaryings = Marshal.GetDelegateForFunctionPointer<PFNGLTRANSFORMFEEDBACKVARYINGSPROC>(loader.Invoke("glTransformFeedbackVaryings"));
            glGetTransformFeedbackVarying = Marshal.GetDelegateForFunctionPointer<PFNGLGETTRANSFORMFEEDBACKVARYINGPROC>(loader.Invoke("glGetTransformFeedbackVarying"));
            glClampColor = Marshal.GetDelegateForFunctionPointer<PFNGLCLAMPCOLORPROC>(loader.Invoke("glClampColor"));
            glBeginConditionalRender = Marshal.GetDelegateForFunctionPointer<PFNGLBEGINCONDITIONALRENDERPROC>(loader.Invoke("glBeginConditionalRender"));
            glEndConditionalRender = Marshal.GetDelegateForFunctionPointer<PFNGLENDCONDITIONALRENDERPROC>(loader.Invoke("glEndConditionalRender"));
            glVertexAttribIPointer = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBIPOINTERPROC>(loader.Invoke("glVertexAttribIPointer"));
            glGetVertexAttribIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIIVPROC>(loader.Invoke("glGetVertexAttribIiv"));
            glGetVertexAttribIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETVERTEXATTRIBIUIVPROC>(loader.Invoke("glGetVertexAttribIuiv"));
            glVertexAttribI1i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1IPROC>(loader.Invoke("glVertexAttribI1i"));
            glVertexAttribI2i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2IPROC>(loader.Invoke("glVertexAttribI2i"));
            glVertexAttribI3i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3IPROC>(loader.Invoke("glVertexAttribI3i"));
            glVertexAttribI4i = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4IPROC>(loader.Invoke("glVertexAttribI4i"));
            glVertexAttribI1ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1UIPROC>(loader.Invoke("glVertexAttribI1ui"));
            glVertexAttribI2ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2UIPROC>(loader.Invoke("glVertexAttribI2ui"));
            glVertexAttribI3ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3UIPROC>(loader.Invoke("glVertexAttribI3ui"));
            glVertexAttribI4ui = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UIPROC>(loader.Invoke("glVertexAttribI4ui"));
            glVertexAttribI1iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1IVPROC>(loader.Invoke("glVertexAttribI1iv"));
            glVertexAttribI2iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2IVPROC>(loader.Invoke("glVertexAttribI2iv"));
            glVertexAttribI3iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3IVPROC>(loader.Invoke("glVertexAttribI3iv"));
            glVertexAttribI4iv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4IVPROC>(loader.Invoke("glVertexAttribI4iv"));
            glVertexAttribI1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI1UIVPROC>(loader.Invoke("glVertexAttribI1uiv"));
            glVertexAttribI2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI2UIVPROC>(loader.Invoke("glVertexAttribI2uiv"));
            glVertexAttribI3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI3UIVPROC>(loader.Invoke("glVertexAttribI3uiv"));
            glVertexAttribI4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UIVPROC>(loader.Invoke("glVertexAttribI4uiv"));
            glVertexAttribI4bv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4BVPROC>(loader.Invoke("glVertexAttribI4bv"));
            glVertexAttribI4sv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4SVPROC>(loader.Invoke("glVertexAttribI4sv"));
            glVertexAttribI4ubv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4UBVPROC>(loader.Invoke("glVertexAttribI4ubv"));
            glVertexAttribI4usv = Marshal.GetDelegateForFunctionPointer<PFNGLVERTEXATTRIBI4USVPROC>(loader.Invoke("glVertexAttribI4usv"));
            glGetUniformuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMUIVPROC>(loader.Invoke("glGetUniformuiv"));
            glBindFragDataLocation = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAGDATALOCATIONPROC>(loader.Invoke("glBindFragDataLocation"));
            glGetFragDataLocation = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAGDATALOCATIONPROC>(loader.Invoke("glGetFragDataLocation"));
            glUniform1ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1UIPROC>(loader.Invoke("glUniform1ui"));
            glUniform2ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2UIPROC>(loader.Invoke("glUniform2ui"));
            glUniform3ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3UIPROC>(loader.Invoke("glUniform3ui"));
            glUniform4ui = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4UIPROC>(loader.Invoke("glUniform4ui"));
            glUniform1uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM1UIVPROC>(loader.Invoke("glUniform1uiv"));
            glUniform2uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM2UIVPROC>(loader.Invoke("glUniform2uiv"));
            glUniform3uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM3UIVPROC>(loader.Invoke("glUniform3uiv"));
            glUniform4uiv = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORM4UIVPROC>(loader.Invoke("glUniform4uiv"));
            glTexParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIIVPROC>(loader.Invoke("glTexParameterIiv"));
            glTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLTEXPARAMETERIUIVPROC>(loader.Invoke("glTexParameterIuiv"));
            glGetTexParameterIiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIIVPROC>(loader.Invoke("glGetTexParameterIiv"));
            glGetTexParameterIuiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETTEXPARAMETERIUIVPROC>(loader.Invoke("glGetTexParameterIuiv"));
            glClearBufferiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERIVPROC>(loader.Invoke("glClearBufferiv"));
            glClearBufferuiv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERUIVPROC>(loader.Invoke("glClearBufferuiv"));
            glClearBufferfv = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERFVPROC>(loader.Invoke("glClearBufferfv"));
            glClearBufferfi = Marshal.GetDelegateForFunctionPointer<PFNGLCLEARBUFFERFIPROC>(loader.Invoke("glClearBufferfi"));
            glGetStringi = Marshal.GetDelegateForFunctionPointer<PFNGLGETSTRINGIPROC>(loader.Invoke("glGetStringi"));
            glIsRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISRENDERBUFFERPROC>(loader.Invoke("glIsRenderbuffer"));
            glBindRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDRENDERBUFFERPROC>(loader.Invoke("glBindRenderbuffer"));
            glDeleteRenderbuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETERENDERBUFFERSPROC>(loader.Invoke("glDeleteRenderbuffers"));
            glGenRenderbuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENRENDERBUFFERSPROC>(loader.Invoke("glGenRenderbuffers"));
            glRenderbufferStorage = Marshal.GetDelegateForFunctionPointer<PFNGLRENDERBUFFERSTORAGEPROC>(loader.Invoke("glRenderbufferStorage"));
            glGetRenderbufferParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETRENDERBUFFERPARAMETERIVPROC>(loader.Invoke("glGetRenderbufferParameteriv"));
            glIsFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLISFRAMEBUFFERPROC>(loader.Invoke("glIsFramebuffer"));
            glBindFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBINDFRAMEBUFFERPROC>(loader.Invoke("glBindFramebuffer"));
            glDeleteFramebuffers = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEFRAMEBUFFERSPROC>(loader.Invoke("glDeleteFramebuffers"));
            glGenFramebuffers = Marshal.GetDelegateForFunctionPointer<PFNGLGENFRAMEBUFFERSPROC>(loader.Invoke("glGenFramebuffers"));
            glCheckFramebufferStatus = Marshal.GetDelegateForFunctionPointer<PFNGLCHECKFRAMEBUFFERSTATUSPROC>(loader.Invoke("glCheckFramebufferStatus"));
            glFramebufferTexture1D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE1DPROC>(loader.Invoke("glFramebufferTexture1D"));
            glFramebufferTexture2D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE2DPROC>(loader.Invoke("glFramebufferTexture2D"));
            glFramebufferTexture3D = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURE3DPROC>(loader.Invoke("glFramebufferTexture3D"));
            glFramebufferRenderbuffer = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERRENDERBUFFERPROC>(loader.Invoke("glFramebufferRenderbuffer"));
            glGetFramebufferAttachmentParameteriv = Marshal.GetDelegateForFunctionPointer<PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC>(loader.Invoke("glGetFramebufferAttachmentParameteriv"));
            glGenerateMipmap = Marshal.GetDelegateForFunctionPointer<PFNGLGENERATEMIPMAPPROC>(loader.Invoke("glGenerateMipmap"));
            glBlitFramebuffer = Marshal.GetDelegateForFunctionPointer<PFNGLBLITFRAMEBUFFERPROC>(loader.Invoke("glBlitFramebuffer"));
            glRenderbufferStorageMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC>(loader.Invoke("glRenderbufferStorageMultisample"));
            glFramebufferTextureLayer = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTURELAYERPROC>(loader.Invoke("glFramebufferTextureLayer"));
            glMapBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLMAPBUFFERRANGEPROC>(loader.Invoke("glMapBufferRange"));
            glFlushMappedBufferRange = Marshal.GetDelegateForFunctionPointer<PFNGLFLUSHMAPPEDBUFFERRANGEPROC>(loader.Invoke("glFlushMappedBufferRange"));
            glBindVertexArray = Marshal.GetDelegateForFunctionPointer<PFNGLBINDVERTEXARRAYPROC>(loader.Invoke("glBindVertexArray"));
            glDeleteVertexArrays = Marshal.GetDelegateForFunctionPointer<PFNGLDELETEVERTEXARRAYSPROC>(loader.Invoke("glDeleteVertexArrays"));
            glGenVertexArrays = Marshal.GetDelegateForFunctionPointer<PFNGLGENVERTEXARRAYSPROC>(loader.Invoke("glGenVertexArrays"));
            glIsVertexArray = Marshal.GetDelegateForFunctionPointer<PFNGLISVERTEXARRAYPROC>(loader.Invoke("glIsVertexArray"));
            glDrawArraysInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWARRAYSINSTANCEDPROC>(loader.Invoke("glDrawArraysInstanced"));
            glDrawElementsInstanced = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDPROC>(loader.Invoke("glDrawElementsInstanced"));
            glTexBuffer = Marshal.GetDelegateForFunctionPointer<PFNGLTEXBUFFERPROC>(loader.Invoke("glTexBuffer"));
            glPrimitiveRestartIndex = Marshal.GetDelegateForFunctionPointer<PFNGLPRIMITIVERESTARTINDEXPROC>(loader.Invoke("glPrimitiveRestartIndex"));
            glCopyBufferSubData = Marshal.GetDelegateForFunctionPointer<PFNGLCOPYBUFFERSUBDATAPROC>(loader.Invoke("glCopyBufferSubData"));
            glGetUniformIndices = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMINDICESPROC>(loader.Invoke("glGetUniformIndices"));
            glGetActiveUniformsiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMSIVPROC>(loader.Invoke("glGetActiveUniformsiv"));
            glGetActiveUniformName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMNAMEPROC>(loader.Invoke("glGetActiveUniformName"));
            glGetUniformBlockIndex = Marshal.GetDelegateForFunctionPointer<PFNGLGETUNIFORMBLOCKINDEXPROC>(loader.Invoke("glGetUniformBlockIndex"));
            glGetActiveUniformBlockiv = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMBLOCKIVPROC>(loader.Invoke("glGetActiveUniformBlockiv"));
            glGetActiveUniformBlockName = Marshal.GetDelegateForFunctionPointer<PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC>(loader.Invoke("glGetActiveUniformBlockName"));
            glUniformBlockBinding = Marshal.GetDelegateForFunctionPointer<PFNGLUNIFORMBLOCKBINDINGPROC>(loader.Invoke("glUniformBlockBinding"));
            glDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSBASEVERTEXPROC>(loader.Invoke("glDrawElementsBaseVertex"));
            glDrawRangeElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC>(loader.Invoke("glDrawRangeElementsBaseVertex"));
            glDrawElementsInstancedBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC>(loader.Invoke("glDrawElementsInstancedBaseVertex"));
            glMultiDrawElementsBaseVertex = Marshal.GetDelegateForFunctionPointer<PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC>(loader.Invoke("glMultiDrawElementsBaseVertex"));
            glProvokingVertex = Marshal.GetDelegateForFunctionPointer<PFNGLPROVOKINGVERTEXPROC>(loader.Invoke("glProvokingVertex"));
            glFenceSync = Marshal.GetDelegateForFunctionPointer<PFNGLFENCESYNCPROC>(loader.Invoke("glFenceSync"));
            glIsSync = Marshal.GetDelegateForFunctionPointer<PFNGLISSYNCPROC>(loader.Invoke("glIsSync"));
            glDeleteSync = Marshal.GetDelegateForFunctionPointer<PFNGLDELETESYNCPROC>(loader.Invoke("glDeleteSync"));
            glClientWaitSync = Marshal.GetDelegateForFunctionPointer<PFNGLCLIENTWAITSYNCPROC>(loader.Invoke("glClientWaitSync"));
            glWaitSync = Marshal.GetDelegateForFunctionPointer<PFNGLWAITSYNCPROC>(loader.Invoke("glWaitSync"));
            glGetInteger64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGER64VPROC>(loader.Invoke("glGetInteger64v"));
            glGetSynciv = Marshal.GetDelegateForFunctionPointer<PFNGLGETSYNCIVPROC>(loader.Invoke("glGetSynciv"));
            glGetInteger64i_v = Marshal.GetDelegateForFunctionPointer<PFNGLGETINTEGER64I_VPROC>(loader.Invoke("glGetInteger64i_v"));
            glGetBufferParameteri64v = Marshal.GetDelegateForFunctionPointer<PFNGLGETBUFFERPARAMETERI64VPROC>(loader.Invoke("glGetBufferParameteri64v"));
            glFramebufferTexture = Marshal.GetDelegateForFunctionPointer<PFNGLFRAMEBUFFERTEXTUREPROC>(loader.Invoke("glFramebufferTexture"));
            glTexImage2DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE2DMULTISAMPLEPROC>(loader.Invoke("glTexImage2DMultisample"));
            glTexImage3DMultisample = Marshal.GetDelegateForFunctionPointer<PFNGLTEXIMAGE3DMULTISAMPLEPROC>(loader.Invoke("glTexImage3DMultisample"));
            glGetMultisamplefv = Marshal.GetDelegateForFunctionPointer<PFNGLGETMULTISAMPLEFVPROC>(loader.Invoke("glGetMultisamplefv"));
            glSampleMaski = Marshal.GetDelegateForFunctionPointer<PFNGLSAMPLEMASKIPROC>(loader.Invoke("glSampleMaski"));
        }
    }
}
