using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using System;
using System.Numerics;
using VERTEX = SharpGLTF.Geometry.VertexTypes.VertexPosition;


namespace GltfExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var material1 = new MaterialBuilder()
                .WithDoubleSide(true)
                .WithSpecularGlossinessShader()
                .WithChannelParam(KnownChannel.SpecularGlossiness, new Vector4(0.7f, 0, 0f, 1.0f))
                .WithEmissive(new Vector3(0.2f, 0.3f, 0.1f));

            var mesh = new MeshBuilder<VERTEX>("mesh");

            var prim = mesh.UsePrimitive(material1);
            prim.AddTriangle(new VERTEX(-10, 0, 0), new VERTEX(10, 0, 0), new VERTEX(0, 10, 0));
            prim.AddTriangle(new VERTEX(10, 0, 0), new VERTEX(-10, 0, 0), new VERTEX(0, -10, 0));

            var scene = new SharpGLTF.Scenes.SceneBuilder();
            scene.AddRigidMesh(mesh, Matrix4x4.Identity);
            var model = scene.ToGltf2();
            model.SaveGLTF("mesh.gtlf");
        }
    }
}
