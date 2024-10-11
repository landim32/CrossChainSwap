using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Core.Domain.Cloud;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Enum;
using BTCSTXSwap.DTO.Goblin;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class AvatarService : IAvatarService
    {
        private const int IMAGE_WIDTH = 1100;
        private const int IMAGE_HEIGHT = 1100;

        private const int AVATAR_WIDTH = 600;
        private const int AVATAR_HEIGHT = 600;

        private readonly ILogCore _log;
        private readonly IAssetsProviders _assetsProvider;

        public AvatarService(ILogCore log, IAssetsProviders assetsProvider)
        {
            _log = log;
            _assetsProvider = assetsProvider;
        }

        private Image<Rgba32> BitMapToImageSharp(Bitmap image)
        {
            return Utils.BitMapToImageSharp(image);
        }

        private Bitmap ImageSharpToBitMap(Image<Rgba32> image)
        {
            return Utils.ImageSharpToBitMap(image);
        }

        /*
        public void ChangeImageColor(Image<Rgba32> image, System.Drawing.Color newColor)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Span<Rgba32> row = image.GetPixelRowSpan(y);
                for (int x = 0; x < row.Length; x++)
                {
                    if (image.GetPixelRowSpan(y)[x].A > 0)
                    {
                        image.GetPixelRowSpan(y)[x] = new Rgba32(newColor.R, newColor.G, newColor.B, byte.MaxValue);
                    }
                }
            }
        }
        */

        public AvatarInfo GeneToAvatar(GeneInfo g)
        {
            var a = new AvatarInfo();
            a.Genre = g.Genre;
            a.Skin = g.Skin;
            a.Hair = g.Hair;
            a.Eyes = g.Eyes;
            a.Ear = g.Ear;
            a.Mouth = g.Mouth;
            a.SkinColor = g.SkinColor;
            a.HairColor = g.HairColor;
            a.EyesColor = g.EyesColor;
            a.Height = AVATAR_HEIGHT;
            a.Width = AVATAR_WIDTH;
            return a;
        }

        public AvatarInfo GoblinInfoToAvatar(IGoblinModel g)
        {
            var a = new AvatarInfo();
            a.Genre = g.Genre;
            a.Skin = g.Skin;
            a.Hair = g.Hair;
            a.Eyes = g.Eye;
            a.Ear = g.Ear;
            a.Mouth = g.Mount;
            a.SkinColor = g.SkinColor;
            a.HairColor = g.HairColor;
            a.EyesColor = g.EyeColor;
            a.Height = AVATAR_HEIGHT;
            a.Width = AVATAR_WIDTH;
            return a;
        }

        private void DrawBody(AvatarInfo avatar, Image<Rgba32> image)
        {
            var bg = _assetsProvider.GetBaseAssets("assets", string.Format("stand-body-{0}-bg.png", avatar.Genre.ToString().ToLower()));
            var fg = _assetsProvider.GetBaseAssets("assets", string.Format("stand-body-{0}-fg.png", avatar.Genre.ToString().ToLower()));

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.SkinColor);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawHead(AvatarInfo avatar, Image<Rgba32> image)
        {
            var bg = _assetsProvider.GetBaseAssets("assets", string.Format("head-{0}-bg.png", avatar.Genre.ToString().ToLower()));
            var fg = _assetsProvider.GetBaseAssets("assets", string.Format("head-{0}-fg.png", avatar.Genre.ToString().ToLower()));

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.SkinColor);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawSkin(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Skin == RaceEnum.Forest)
                return;
            var fg = _assetsProvider.GetBaseAssets("assets", string.Format("skin-{0}.png", avatar.Skin.ToString().ToLower()));

            image.Mutate(o => o
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawHair(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Hair == RaceEnum.Cave && avatar.Genre == GenreEnum.Male)
            {
                return;
            }
            if (avatar.Head != null)
            {
                if (avatar.Genre == GenreEnum.Female)
                {
                    var bgb = _assetsProvider.GetBaseAssets("assets", "hair-cave-bg.png");
                    var fgb = _assetsProvider.GetBaseAssets("assets", "hair-cave-fg.png");

                    var imgBgb = BitMapToImageSharp(bgb);
                    Utils.ChangeImageColor(imgBgb, avatar.HairColor);
                    image.Mutate(o => o
                        .DrawImage(imgBgb, 1)
                        .DrawImage(BitMapToImageSharp(fgb), 1)
                    );
                    return;
                } else
                {
                    return;
                }
            }
            string hair = string.Format("hair-{0}-fg.png", avatar.Hair.ToString().ToLower());
            string hairBg = string.Format("hair-{0}-bg.png", avatar.Hair.ToString().ToLower());
            switch (avatar.Hair)
            {
                case RaceEnum.Dark:
                    hair = string.Format("hair-dark-{0}-fg.png", avatar.Genre.ToString().ToLower());
                    hairBg = string.Format("hair-dark-{0}-bg.png", avatar.Genre.ToString().ToLower());
                    break;
            }

            var bg = _assetsProvider.GetBaseAssets("assets", hairBg);
            var fg = _assetsProvider.GetBaseAssets("assets", hair);

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.HairColor);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawEar(AvatarInfo avatar, Image<Rgba32> image)
        {
            var bg = _assetsProvider.GetBaseAssets("assets", string.Format("ear-{0}-bg.png", avatar.Ear.ToString().ToLower()));
            var fg = _assetsProvider.GetBaseAssets("assets", string.Format("ear-{0}-fg.png", avatar.Ear.ToString().ToLower()));

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.SkinColor);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawEye(AvatarInfo avatar, Image<Rgba32> image)
        {
            string eyes = string.Format("eye-{0}-fg.png", avatar.Eyes.ToString().ToLower());
            switch (avatar.Eyes)
            {
                case RaceEnum.Sea:
                    eyes = "eye-sea-blue-fg.png";
                    break;
            }

            string iris = string.Format("eye-{0}-bg.png", avatar.Eyes.ToString().ToLower());

            var bg = _assetsProvider.GetBaseAssets("assets", iris);
            var fg = _assetsProvider.GetBaseAssets("assets", eyes);

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.EyesColor);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }
        private void DrawMouth(AvatarInfo avatar, Image<Rgba32> image)
        {
            var mouth = _assetsProvider.GetBaseAssets("assets", string.Format("mount-{0}.png", avatar.Mouth.ToString().ToLower()));

            image.Mutate(o => o
                .DrawImage(BitMapToImageSharp(mouth), 1)
            );
        }

        private void DrawHelmet(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Head == null)
                return;
            var bg = _assetsProvider.GetBaseAssets("assets", avatar.Head.ImageStand + "-bg.png");
            var fg = _assetsProvider.GetBaseAssets("assets", avatar.Head.ImageStand + "-fg.png");

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.Head.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawChest(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Chest == null)
                return;
            var assetBg = string.Format(avatar.Chest.ImageStand, avatar.Genre.ToString().ToLower()) + "-bg.png";
            var bg = _assetsProvider.GetBaseAssets("assets", assetBg);

            var assetFg = string.Format(avatar.Chest.ImageStand, avatar.Genre.ToString().ToLower()) + "-fg.png";
            var fg = _assetsProvider.GetBaseAssets("assets", assetFg);

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.Chest.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawHand(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Hand == null)
                return;

            var bg = _assetsProvider.GetBaseAssets("assets", avatar.Hand.ImageStand + "-bg.png");
            var fg = _assetsProvider.GetBaseAssets("assets", avatar.Hand.ImageStand + "-fg.png");

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.Hand.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawFoot(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.Foot == null)
                return;

            var bg = _assetsProvider.GetBaseAssets("assets", avatar.Foot.ImageStand + "-bg.png");
            var fg = _assetsProvider.GetBaseAssets("assets", avatar.Foot.ImageStand + "-fg.png");

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.Foot.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawMainHand(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.MainHand == null)
                return;
            var bg = _assetsProvider.GetBaseAssets("assets", "stand-" + avatar.MainHand.ImageStand + "-bg.png");
            var fg = _assetsProvider.GetBaseAssets("assets", "stand-" + avatar.MainHand.ImageStand + "-fg.png");


            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.MainHand.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        private void DrawSecondHand(AvatarInfo avatar, Image<Rgba32> image)
        {
            if (avatar.SecondHand == null)
                return;
            var bgStr = "stand-" + avatar.SecondHand.ImageStand + "-bg.png";
            var fgStr = "stand-" + avatar.SecondHand.ImageStand + "-fg.png";
            if (avatar.SecondHand.IsSecundary) {
                bgStr = "stand-" + avatar.SecondHand.ImageStand + "-sec-bg.png";
                fgStr = "stand-" + avatar.SecondHand.ImageStand + "-sec-fg.png";
            }
            var bg = _assetsProvider.GetBaseAssets("assets", bgStr);
            var fg = _assetsProvider.GetBaseAssets("assets", fgStr);

            var imgBg = BitMapToImageSharp(bg);
            Utils.ChangeImageColor(imgBg, avatar.SecondHand.Color);
            image.Mutate(o => o
                .DrawImage(imgBg, 1)
                .DrawImage(BitMapToImageSharp(fg), 1)
            );
        }

        public BuildAvatarInfo GenerateAvatar(AvatarInfo avatar)
        {
            using (Image<Rgba32> headImage = new Image<Rgba32>(IMAGE_WIDTH, IMAGE_HEIGHT))
            {

                DrawHead(avatar, headImage);
                DrawSkin(avatar, headImage);
                DrawHair(avatar, headImage);
                DrawEye(avatar, headImage);
                DrawHelmet(avatar, headImage);
                DrawEar(avatar, headImage);
                DrawMouth(avatar, headImage);
                

                using (Image<Rgba32> outputImage = new Image<Rgba32>(IMAGE_WIDTH, IMAGE_HEIGHT))
                {

                    DrawSecondHand(avatar, outputImage);
                    DrawBody(avatar, outputImage);
                    DrawChest(avatar, outputImage);
                    DrawHand(avatar, outputImage);
                    DrawFoot(avatar, outputImage);

                    outputImage.Mutate(o => o.DrawImage(headImage, 1f));
                    DrawMainHand(avatar, outputImage);


                    outputImage.Mutate(o => o.Resize(avatar.Width, avatar.Height));

                    var ret = new BuildAvatarInfo
                    {
                        FullImage = ImageSharpToBitMap(outputImage),
                        HeadImage = ImageSharpToBitMap(headImage)
                    };
                    return ret;
                }

            }
            
        }
    }
}
