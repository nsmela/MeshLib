using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using static MR.DotNet;

namespace MR.Test
{
    [TestFixture]
    internal class MeshExtrudeTests
    {
        [Test]
        public void TestMeshExtrude()
        {
            Assert.DoesNotThrow(() =>
            {
                var mesh = Mesh.MakeCube(Vector3f.Diagonal(1), Vector3f.Diagonal(-0.5f));
                var count = mesh.ValidPoints.Count();

                FaceBitSet region = new();
                region.AutoResizeSet(3, false);
                region.Set(0, true);
                region.Set(1, true);

                MakeDegenerateBandAroundRegionParams parameters = new();
                mesh = MeshExtrude.Extrude(mesh, ref region, ref parameters);
                Assert.That(mesh is not null, "Mesh extrusion failed to produce a valid mesh.");
                mesh.Dispose();
            });
        }
    }
}
