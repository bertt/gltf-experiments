using SharpGLTF.Materials;
using System;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Geometry.Parametric;
using SharpGLTF.Scenes;
using System.Windows.Forms;

namespace GltfExperiments.Forms
{
    using VPOSNRM = SharpGLTF.Geometry.VertexBuilder<VertexPositionNormal,VertexEmpty, VertexEmpty>;

    public static class SampleGpuInstancing
    {
        public static Quaternion NextQuaternion(this Random rnd)
        {
            var r = NextVector3(rnd) * (float)Math.PI * 2;
            return Quaternion.CreateFromYawPitchRoll(r.X, r.Y, r.Z);
        }


        private static Vector3 NextVector3(Random rnd)
        {
            return new Vector3(rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle());
        }

        public static void DoIt()
        {
            var rnd = new Random(177);

            // create materials

            var materials = Enumerable
                .Range(0, 10)
                .Select(idx => new MaterialBuilder()
                .WithChannelParam(KnownChannel.BaseColor, KnownProperty.RGBA, new Vector4(NextVector3(rnd), 1)))
                .ToList();

            // create meshes
            var cubeMeshes = Enumerable
                .Range(0, 10)
                .Select(idx => materials[idx])
                .Select(mat =>
                {
                    var mesh = VPOSNRM.CreateCompatibleMesh("shape");
#if DEBUG
                    mesh.VertexPreprocessor.SetValidationPreprocessors();
#else
                    mesh.VertexPreprocessor.SetSanitizerPreprocessors();
#endif
                    mesh.AddCube(mat, Matrix4x4.Identity);
                    mesh.Validate();
                    return mesh;
                });

            var meshes = cubeMeshes.ToArray();

            // create scene            

            var scene = new SceneBuilder();

            for (int i = 0; i < 100; ++i)
            {
                var mesh = meshes[rnd.Next(0, 10)];

                // create random transform
                var r = rnd.NextQuaternion();
                var t = NextVector3(rnd) * 25;

                scene.AddRigidMesh(mesh, (r, t));
            }

            // collapse to glTF

            var gltf = scene.ToGltf2(SceneBuilderSchema2Settings.WithGpuInstancing);

            gltf.SaveGLB("gpu_instancing_sample.glb");

            MessageBox.Show("gpu_instancing_sample.glb");
        }
    }
}
