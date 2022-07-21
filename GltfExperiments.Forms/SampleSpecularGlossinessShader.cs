using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Scenes;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using VERTEX = SharpGLTF.Geometry.VertexTypes.VertexPosition;

namespace GltfExperiments.Forms
{
    public static class SampleSpecularGlossinessShader
    {
        public static void DoIt()
        {
            var diffuseColor = "#E6009000";
            var specularGlossines = "#4D0000ff";
            Console.WriteLine("Hello World!");

            var colorDiffuse = ColorToVector4(ColorTranslator.FromHtml(diffuseColor));
            var colorSpecular = ColorToVector4(ColorTranslator.FromHtml(specularGlossines));

            var material1 = new MaterialBuilder()
                .WithDoubleSide(true)
                .WithAlpha(AlphaMode.OPAQUE)
                .WithSpecularGlossinessShader()
                .WithChannelParam(KnownChannel.SpecularGlossiness, colorSpecular)
                .WithChannelParam(KnownChannel.Diffuse, colorDiffuse);

            var mesh = new MeshBuilder<VERTEX>("mesh");

            var prim = mesh.UsePrimitive(material1);
            prim.AddTriangle(new VERTEX(-10, 0, 0), new VERTEX(10, 0, 0), new VERTEX(0, 10, 0));
            prim.AddTriangle(new VERTEX(10, 0, 0), new VERTEX(-10, 0, 0), new VERTEX(0, -10, 0));


            var scene = new SceneBuilder();
            scene.AddRigidMesh(mesh, Matrix4x4.Identity);

            var model = scene.ToGltf2();
            model.SaveGLTF("mesh.gtlf");

            MessageBox.Show($"model mesh.gltf is created");
        }

        private static Vector4 ColorToVector4(Color c)
        {
            var v = new Vector4((float)c.R / 255, (float)c.G / 255, (float)c.B / 255, (float)c.A / 255);
            return v;
        }

    }
}
