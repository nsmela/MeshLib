using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MR
{
    public partial class DotNet
    {
        public struct MeshSubdivideSettings
        {
            /// <summary>
            /// Subdivision is stopped when all edges inside or on the boundary of the region are not longer than this value
            /// </summary>
            public float maxEdgeLen = 1.0f;

            /// <summary>
            /// Maximum number of edge splits allowed
            /// </summary>
            public int maxEdgeSplits = 1000;

            /// <summary>
            /// Improves local mesh triangulation by doing edge flips if it does not change dihedral angle more than on this value (in radians)
            /// </summary>
            public float maxAngleChangeAfterFlip = 0.1f;


            public MeshSubdivideSettings() { }
        }

        public class MeshSubdivide
        {
            [StructLayout(LayoutKind.Sequential)]
            internal struct MRSubdivideSettings
            {
                public float maxEdgeLen = 1.0f;
                public int maxEdgeSplits = 1000;
                public float maxAngleChangeAfterFlip = 0.1f;
                public float criticalAspectRatioFlip = 0.5f;
                public FaceBitSet region = new FaceBitSet();
                public UndirectedEdgeBitSet notFlippable = new UndirectedEdgeBitSet();
                public VertBitSet newVerts = new VertBitSet();
                public bool subdivideBorder = true;
                public float maxTriAspectRatio = 1.0f;
                public float maxSplittableAspectRatio = 1.0f;
                public bool smoothMode = false;
                public float minSharpDihedralAngle = 1.0f;
                bool projectOnOriginalMesh = false;

                public MRSubdivideSettings() { }
            }

        }

    }
}
