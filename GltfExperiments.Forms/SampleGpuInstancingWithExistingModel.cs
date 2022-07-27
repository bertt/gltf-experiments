using SharpGLTF.Geometry;
using SharpGLTF.Scenes;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace GltfExperiments.Forms
{
    public static class SampleGpuInstancingWithExistingModel
    {
        public static void DoIt()
        {
            // load glb to be instanced
            var m = ModelRoot.Load("tree.glb");
            var meshBuilder = m.LogicalMeshes.First().ToMeshBuilder();
            var transform = m.DefaultScene.VisualChildren.ToArray()[4].LocalTransform;

            var rnd = new Random(177);

            var sceneBuilder = new SceneBuilder();
            for(int i = 0; i < 100; i++)
            {
                sceneBuilder.AddRigidMesh(meshBuilder, new AffineTransform(
                    new Vector3(rnd.Next(1,10), rnd.Next(1,10), rnd.Next(1,10)), 
                    transform.Rotation, 
                    new Vector3(rnd.Next(-50, 50), 20, rnd.Next(-50, 50))));
            }

            // saving
            var gltf = sceneBuilder.ToGltf2(SceneBuilderSchema2Settings.WithGpuInstancing);
            gltf.SaveGLB("Box_with_instances.glb");

            MessageBox.Show("gpu_instancing_sample.glb");
        }
    }
}
