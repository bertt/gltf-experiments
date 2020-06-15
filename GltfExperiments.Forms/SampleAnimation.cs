using SharpGLTF.Geometry.Parametric;
using SharpGLTF.Materials;
using SharpGLTF.Scenes;
using System.Numerics;

namespace GltfExperiments.Forms
{
    public static class SampleAnimation
    {
        public static void DoIt()
        {

            var material = MaterialBuilder.CreateDefault();

            var mesh = new Cube<MaterialBuilder>(material)
                .ToMesh(Matrix4x4.Identity);

            var pivot = new NodeBuilder();

            pivot.UseTranslation("track1")
                .WithPoint(0, Vector3.Zero)
                .WithPoint(1, Vector3.One);

            pivot.UseRotation("track1")
                .WithPoint(0, Quaternion.Identity)
                .WithPoint(1, Quaternion.CreateFromAxisAngle(Vector3.UnitY, 1.5f));

            pivot.UseScale("track1")
                .WithPoint(0, Vector3.One)
                .WithPoint(1, new Vector3(0.5f));

            var scene = new SceneBuilder();

            scene.AddRigidMesh(mesh, pivot);

            scene.ToGltf2().SaveGLB(@"animation.glb");
        }
    }
}
