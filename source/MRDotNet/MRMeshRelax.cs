using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MR 
{
    public partial class DotNet
    {

        public struct RelaxParameters
        {
            public int iterations = 1; // number of iterations
            public VertBitSet region = new VertBitSet(); // region to relax
            public float force = 0.5f; // speed of relaxing. Typical values [0.0f, 0.5f]
            public bool limitNearInitial = false; // if true, limits maximal displacement of each point
            public float maxInitialDist = 1.0f; // maximum distance between a point and its position before relaxation

            public RelaxParameters() { }
        }


        public class MeshRelax
        {
            [StructLayout(LayoutKind.Sequential)]
            internal struct MRRelaxParameters
            {
                public int iterations = 1; // number of iterations
                public VertBitSet region = new VertBitSet(); // region to relax
                public float force = 0.5f; // speed of relaxing. Typical values [0.0f, 0.5f]
                public bool limitNearInitial = false; // if true, limits maximal displacement of each point
                public float maxInitialDist = 1.0f; // maximum distance between a point and its position before relaxation

                public MRRelaxParameters() { }
            }

            [DllImport("MRMesh", CharSet = CharSet.Ansi)]
            private static extern bool mrRelax(ref Mesh mesh, ref MRRelaxParameters parameters, ref IntPtr progressCallback);

            public static Mesh RelaxMesh(Mesh mesh, RelaxParameters parameters)
            {
                // callback pointer
                IntPtr progressCallback = IntPtr.Zero;

                // convert public struct to internal struct
                MRRelaxParameters mrParameters = new MRRelaxParameters();
                mrParameters.iterations = parameters.iterations;
                mrParameters.region = parameters.region;
                mrParameters.force = parameters.force;
                mrParameters.limitNearInitial = parameters.limitNearInitial;
                mrParameters.maxInitialDist = parameters.maxInitialDist;

                /// applies given number of relaxation iterations to the whole mesh ( or some region if it is specified )
                /// \return true if was finished successfully, false if was interrupted by progress callback
                var finished = mrRelax(ref mesh, ref mrParameters, ref progressCallback);

                return mesh;
            }
        }

    }
}
