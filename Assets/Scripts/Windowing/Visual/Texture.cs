using OpenTK.Graphics.ES30;
using StbImageSharp;

namespace Zephyros1938.DCSM.Windowing.Visual
{

    public class Texture
    {
        public readonly ImageResult Tex;
        public readonly string Path;
        public readonly int Handle;
        public readonly TextureUnit unit;

        public Texture(String location, TextureUnit unit)
        {
            Handle = GL.GenTexture();
            this.unit = unit;
            this.Path = location;
            StbImage.stbi_set_flip_vertically_on_load(1);
            this.Tex = LoadTexture(location);
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
            GL.TexImage2D(TextureTarget2d.Texture2D, 0, TextureComponentCount.Rgba, Tex.Width, Tex.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, Tex.Data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.GenerateMipmap(TextureTarget.Texture2D);
            Use();
        }

        public static ImageResult LoadTexture(String path)
        {
            return ImageResult.FromStream(File.OpenRead(path), ColorComponents.RedGreenBlueAlpha);
        }

        public void Use()
        {
            GL.ActiveTexture(this.unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }
    }
}