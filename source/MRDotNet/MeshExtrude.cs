using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static MR.DotNet;

namespace MR
{
    public partial class DotNet
    {
        /// <summary>
        /// holds together settings for makeDegenerateBandAroundRegion
        /// </summary>
        public struct MakeDegenerateBandAroundRegionParams
        {
            public FaceBitSet? outnewFaces = new FaceBitSet();
            public UndirectedEdgeBitSet? outExtrudedEdges = new UndirectedEdgeBitSet();
            public float? maxEdgeLength = 1.0f;
            //public MRVertMap? new2OldMap = new MRVertMap();

            public MakeDegenerateBandAroundRegionParams() { }
        }

        public class MeshExtrude
        {

            [StructLayout(LayoutKind.Sequential)]
            internal struct MRMakeDegenerateBandAroundRegionParams
            {
                public IntPtr outnewFaces = IntPtr.Zero;
                public IntPtr outExtrudedEdges = IntPtr.Zero;
                public IntPtr edgeLength = IntPtr.Zero;
                public IntPtr new2OldMap = IntPtr.Zero;

                public MRMakeDegenerateBandAroundRegionParams() { }
            }

            [DllImport("MRMeshC", CharSet = CharSet.Ansi)]
            private static extern void mrMakeDegenerateBandAroundRegion(ref Mesh mesh, FaceBitSet region, ref MRMakeDegenerateBandAroundRegionParams parameters );

            public static Mesh Extrude(Mesh mesh, ref FaceBitSet region, ref MakeDegenerateBandAroundRegionParams refParams)
            {
                if (mesh == null) throw new ArgumentNullException(nameof(mesh));
                if (region.Size() == 0) throw new ArgumentException("Region must contain at least one face.", nameof(region));

                MRMakeDegenerateBandAroundRegionParams parameters = new();
                // TODO parameters.outnewFaces = refParams.outnewFaces?.bs_ ?? IntPtr.Zero;
                // TODO parameters.outExtrudedEdges = refParams.outExtrudedEdges?.bs_ ?? IntPtr.Zero;
                // TODO float
                // TODO VertMap
                mrMakeDegenerateBandAroundRegion(ref mesh, region, ref parameters);
                return mesh; // Return the extruded mesh
            }
        }


    }
}
