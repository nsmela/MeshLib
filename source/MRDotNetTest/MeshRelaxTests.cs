using MR;
using NUnit.Framework;
using System;
using static MR.DotNet;

namespace MR.Test
{
    [TestFixture]
    internal class MeshRelaxTests
    {
        [Test]
        public void RelaxMesh_ShouldNotThrow_AndReturnSameMeshInstance()
        {
            // Arrange
            var size = Vector3f.Diagonal(1.0f);
            var baseCoords = new Vector3f();
            var mesh = Mesh.MakeCube(size, baseCoords);
            var originalPoints = mesh.Points;
            var parameters = new RelaxParameters
            {
                iterations = 2,
                force = 0.3f,
                limitNearInitial = true,
                maxInitialDist = 0.5f
            };

            // Act
            var resultMesh = DotNet.MeshRelax.RelaxMesh(mesh, parameters);

            // Assert
            Assert.That(mesh, Is.EqualTo(resultMesh), "RelaxMesh should return the same mesh instance.");
            Assert.That(resultMesh.Points is not null, "Mesh points should not be null after relaxation.");
            // Optionally: check that points have changed (relaxation effect)
            // This is a weak check, as actual values depend on native implementation
            Assert.That(originalPoints.Count == resultMesh.Points.Count, "Point count should remain the same after relaxation.");
        }
    }
}
