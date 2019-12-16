//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using NUnit.Framework;
using Unity.PerformanceTesting;
using Unity.Burst;
using Unity.Collections;

namespace Unity.Mathematics.PerformanceTests
{
    public partial class TestConversions
    {
        [BurstCompile]
        public class quaternion_to_float3x3
        {
            public struct Arguments
            {
                public NativeArray<quaternion> q;
                public NativeArray<float3x3> f3x3;

                public void Init()
                {
                    q = new NativeArray<quaternion>(10000, Allocator.Persistent);
                    f3x3 = new NativeArray<float3x3>(10000, Allocator.Persistent);
                }

                public void Dispose()
                {
                    q.Dispose();
                    f3x3.Dispose();
                }
            }

            public static void CommonTestFunction(ref Arguments args)
            {
                for (int i = 0; i < 10000; ++i)
                {
                    args.f3x3[i] = new float3x3(args.q[i]);
                }
            }

            public static void MonoTestFunction(ref Arguments args)
            {
                CommonTestFunction(ref args);
            }

            [BurstCompile]
            public static void BurstTestFunction(ref Arguments args)
            {
                CommonTestFunction(ref args);
            }

            public delegate void TestFunction(ref Arguments args);
        }

        [Test, Performance]
        public void quaternion_to_float3x3_mono()
        {
            quaternion_to_float3x3.TestFunction testFunction = quaternion_to_float3x3.MonoTestFunction;
            var args = new quaternion_to_float3x3.Arguments();
            args.Init();

            Measure.Method(() =>
            {
                testFunction.Invoke(ref args);
            })
            .WarmupCount(1)
            .MeasurementCount(10)
            .Run();
            args.Dispose();
        }

        [Test, Performance]
        public void quaternion_to_float3x3_burst()
        {
            FunctionPointer<quaternion_to_float3x3.TestFunction> testFunction = BurstCompiler.CompileFunctionPointer<quaternion_to_float3x3.TestFunction>(quaternion_to_float3x3.BurstTestFunction);
            var args = new quaternion_to_float3x3.Arguments();
            args.Init();

            Measure.Method(() =>
            {
                testFunction.Invoke(ref args);
            })
            .WarmupCount(1)
            .MeasurementCount(10)
            .Run();
            args.Dispose();
        }
    }
}