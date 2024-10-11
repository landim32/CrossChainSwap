using Core.Domain;
using Core.Domain.Cloud;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Models;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Services;
using BTCSTXSwap.DTO.Goblin;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class MiningSpriteService : BaseSpriteService, IMiningSpriteService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogCore _log;
        private readonly IAssetsProviders _assetsProvider;
        private readonly IGoblinSpriteDomainFactory _miningSpriteFactory;
        private readonly IGeneService _geneService;
        private readonly IAvatarService _avatarService;
        private readonly IEquipmentService _equipmentService;

        private Image<Rgba32> _fxDown1;
        private Image<Rgba32> _fxDown2;
        private Image<Rgba32> _fxUp1;
        private Image<Rgba32> _fxUp2;
        private Image<Rgba32> _fxStop;
        private Image<Rgba32> _fxSpark1;
        private Image<Rgba32> _fxSpark2;
        private Image<Rgba32> _fxSpark3;
        private Image<Rgba32> _fxSpark4;
        private Image<Rgba32> _fxSpark5;

        private Image<Rgba32> _miningStopBodyFg;
        private Image<Rgba32> _miningStopBodyBg;
        private Image<Rgba32> _miningStopChestFg;
        private Image<Rgba32> _miningStopChestBg;
        private Image<Rgba32> _miningStopHandFg;
        private Image<Rgba32> _miningStopHandBg;
        private Image<Rgba32> _miningStopFootFg;
        private Image<Rgba32> _miningStopFootBg;
        private Image<Rgba32> _miningStopPickFg;
        private Image<Rgba32> _miningStopPickBg;

        private Image<Rgba32> _miningUpBodyFg;
        private Image<Rgba32> _miningUpBodyBg;
        private Image<Rgba32> _miningUpArmsFg;
        private Image<Rgba32> _miningUpArmsBg;
        private Image<Rgba32> _miningUpChestFg;
        private Image<Rgba32> _miningUpChestBg;
        private Image<Rgba32> _miningUpHandFg;
        private Image<Rgba32> _miningUpHandBg;
        private Image<Rgba32> _miningUpFootFg;
        private Image<Rgba32> _miningUpFootBg;
        private Image<Rgba32> _miningUpPickFg;
        private Image<Rgba32> _miningUpPickBg;

        private Image<Rgba32> _miningDownBodyFg;
        private Image<Rgba32> _miningDownBodyBg;
        private Image<Rgba32> _miningDownArmsFg;
        private Image<Rgba32> _miningDownArmsBg;
        private Image<Rgba32> _miningDownChestFg;
        private Image<Rgba32> _miningDownChestBg;
        private Image<Rgba32> _miningDownHandFg;
        private Image<Rgba32> _miningDownHandBg;
        private Image<Rgba32> _miningDownFootFg;
        private Image<Rgba32> _miningDownFootBg;
        private Image<Rgba32> _miningDownPickFg;
        private Image<Rgba32> _miningDownPickBg;

        private Image<Rgba32> _miningRestBodyFg;
        private Image<Rgba32> _miningRestBodyBg;
        private Image<Rgba32> _miningRestArmsFg;
        private Image<Rgba32> _miningRestArmsBg;
        private Image<Rgba32> _miningRestChestFg;
        private Image<Rgba32> _miningRestChestBg;
        private Image<Rgba32> _miningRestHandFg;
        private Image<Rgba32> _miningRestHandBg;
        private Image<Rgba32> _miningRestFootFg;
        private Image<Rgba32> _miningRestFootBg;
        private Image<Rgba32> _miningRestPickFg;
        private Image<Rgba32> _miningRestPickBg;

        private const int IMG_WIDTH = 180;
        private const int IMG_HEIGHT = 180;

        private const string MINING_STOP_BODY = "mining-stop-body-{0}-{1}.png";
        private const string MINING_STOP_PICK = "mining-stop-pick-{0}.png";

        private const string MINING_UP_BODY = "mining-up-body-{0}-{1}.png";
        private const string MINING_UP_ARMS = "mining-up-arms-{0}.png";
        private const string MINING_UP_PICK = "mining-up-pick-{0}.png";

        private const string MINING_DOWN_BODY = "mining-down-body-{0}-{1}.png";
        private const string MINING_DOWN_ARMS = "mining-down-arms-{0}.png";
        private const string MINING_DOWN_PICK = "mining-down-pick-{0}.png";

        private const string MINING_REST_BODY = "mining-rest-body-{0}-{1}.png";
        private const string MINING_REST_ARMS = "mining-rest-arms-{0}.png";
        private const string MINING_REST_PICK = "mining-rest-pick-{0}.png";

        private const string FX_DOWN1 = "fx-down1.png";
        private const string FX_DOWN2 = "fx-down2.png";
        private const string FX_UP1 = "fx-up1.png";
        private const string FX_UP2 = "fx-up2.png";
        private const string FX_STOP = "fx-stop.png";
        private const string FX_SPARK1 = "fx-spark1.png";
        private const string FX_SPARK2 = "fx-spark2.png";
        private const string FX_SPARK3 = "fx-spark3.png";
        private const string FX_SPARK4 = "fx-spark4.png";
        private const string FX_SPARK5 = "fx-spark5.png";

        public MiningSpriteService(
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            ILogCore log,
            IAssetsProviders assetsProvider,
            IGoblinSpriteDomainFactory miningSpriteFactory,
            IGeneService geneService,
            IAvatarService avatarService,
            IEquipmentService equipmentService
        )
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _log = log;
            _assetsProvider = assetsProvider;
            _miningSpriteFactory = miningSpriteFactory;
            _geneService = geneService;
            _avatarService = avatarService;
            _equipmentService = equipmentService;
        }

        protected override void LoadImages()
        {
            _fxDown1 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_DOWN1));
            _fxDown1.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxDown2 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_DOWN2));
            _fxDown2.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxUp1 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_UP1));
            _fxUp1.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxUp2 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_UP2));
            _fxUp2.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxStop = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_STOP));
            _fxStop.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxSpark1 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_SPARK1));
            _fxSpark1.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxSpark2 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_SPARK2));
            _fxSpark2.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxSpark3 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_SPARK3));
            _fxSpark3.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxSpark4 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_SPARK4));
            _fxSpark4.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            _fxSpark5 = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", FX_SPARK5));
            _fxSpark5.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
        }

        private string GenreToStr(AvatarInfo avatar)
        {
            return (avatar.Genre == DTO.Enum.GenreEnum.Male) ? "male" : "female";
        }

        private Image<Rgba32> GetImageForeground(ref Image<Rgba32> image, string fileName)
        {
            if (image != null)
            {
                return image;
            }
            image = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", fileName));
            image.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            return image;
        }

        private Image<Rgba32> GetImageBackground(ref Image<Rgba32> image, string fileName, System.Drawing.Color bgColor)
        {
            if (image != null)
            {
                return image;
            }
            image = Utils.BitMapToImageSharp(_assetsProvider.GetBaseAssets("assets", fileName));
            image.Mutate(o => o.Resize(IMG_WIDTH, IMG_HEIGHT));
            Utils.ChangeImageColor(image, bgColor);
            return image;
        }

        private Bitmap UpdateGoblinMineStop1(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));

                outputImage.Mutate(o => o
                    //.DrawImage(_minerBodyStop, 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningStopBodyBg, 
                        string.Format(MINING_STOP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningStopBodyFg,
                        string.Format(MINING_STOP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    //.DrawImage(head, new SixLabors.ImageSharp.Point(17, 17), 1f)
                    //.DrawImage(_minerArmStop, 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopChestBg,
                            string.Format(avatar.Chest.ImageMiningStop, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopChestFg,
                            string.Format(avatar.Chest.ImageMiningStop, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopHandBg,
                            avatar.Hand.ImageMiningStop + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopHandFg,
                            avatar.Hand.ImageMiningStop + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopFootBg,
                            avatar.Foot.ImageMiningStop + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopFootFg,
                            avatar.Foot.ImageMiningStop + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(head, new SixLabors.ImageSharp.Point(17, 17), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningStopPickBg,
                        string.Format(MINING_STOP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningStopPickFg,
                        string.Format(MINING_STOP_PICK, "fg")
                    ), 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineStop2(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyStop, 1f)
                    .DrawImage(head, new SixLabors.ImageSharp.Point(17, 17), 1f)
                    .DrawImage(_minerArmStop, 1f)
                    .DrawImage(_fxStop, 1f)
                );
                */

                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningStopBodyBg,
                        string.Format(MINING_STOP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningStopBodyFg,
                        string.Format(MINING_STOP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopChestBg,
                            string.Format(avatar.Chest.ImageMiningStop, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopChestFg,
                            string.Format(avatar.Chest.ImageMiningStop, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopHandBg,
                            avatar.Hand.ImageMiningStop + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopHandFg,
                            avatar.Hand.ImageMiningStop + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningStopFootBg,
                            avatar.Foot.ImageMiningStop + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningStopFootFg,
                            avatar.Foot.ImageMiningStop + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(head, new SixLabors.ImageSharp.Point(17, 17), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningStopPickBg,
                        string.Format(MINING_STOP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningStopPickFg,
                        string.Format(MINING_STOP_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxStop, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineUp1(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));

                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningUpBodyBg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpBodyFg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpArmsBg,
                        string.Format(MINING_UP_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpArmsFg,
                        string.Format(MINING_UP_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpChestBg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpChestFg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpHandBg,
                            avatar.Hand.ImageMiningUp + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpHandFg,
                            avatar.Hand.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpFootBg,
                            avatar.Foot.ImageMiningUp + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpFootFg,
                            avatar.Foot.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpPickBg,
                        string.Format(MINING_UP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpPickFg,
                        string.Format(MINING_UP_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxUp1, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineUp2(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyUp, 1f)
                    .DrawImage(Utils.BitMapToImageSharp(rotatedHead), new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(_minerArmUp, 1f)
                    .DrawImage(_fxUp2, 1f)
                );
                */

                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningUpBodyBg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpBodyFg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpArmsBg,
                        string.Format(MINING_UP_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpArmsFg,
                        string.Format(MINING_UP_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpChestBg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpChestFg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpHandBg,
                            avatar.Hand.ImageMiningUp + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpHandFg,
                            avatar.Hand.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpFootBg,
                            avatar.Foot.ImageMiningUp + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpFootFg,
                            avatar.Foot.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpPickBg,
                        string.Format(MINING_UP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpPickFg,
                        string.Format(MINING_UP_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxUp2, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineUp3(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyUp, 1f)
                    .DrawImage(Utils.BitMapToImageSharp(rotatedHead), new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(_minerArmUp, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningUpBodyBg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpBodyFg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpArmsBg,
                        string.Format(MINING_UP_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpArmsFg,
                        string.Format(MINING_UP_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpChestBg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpChestFg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpHandBg,
                            avatar.Hand.ImageMiningUp + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpHandFg,
                            avatar.Hand.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpFootBg,
                            avatar.Foot.ImageMiningUp + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpFootFg,
                            avatar.Foot.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpPickBg,
                        string.Format(MINING_UP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpPickFg,
                        string.Format(MINING_UP_PICK, "fg")
                    ), 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }

        }

        private Bitmap UpdateGoblinMineUpWithSpark1(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyUp, 1f)
                    .DrawImage(Utils.BitMapToImageSharp(rotatedHead), new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(_minerArmUp, 1f)
                    .DrawImage(_fxUp1, 1f)
                    .DrawImage(_fxSpark4, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningUpBodyBg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpBodyFg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpArmsBg,
                        string.Format(MINING_UP_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpArmsFg,
                        string.Format(MINING_UP_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpChestBg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpChestFg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpHandBg,
                            avatar.Hand.ImageMiningUp + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpHandFg,
                            avatar.Hand.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpFootBg,
                            avatar.Foot.ImageMiningUp + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpFootFg,
                            avatar.Foot.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpPickBg,
                        string.Format(MINING_UP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpPickFg,
                        string.Format(MINING_UP_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxUp1, 1f)
                    .DrawImage(_fxSpark4, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineUpWithSpark2(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyUp, 1f)
                    .DrawImage(Utils.BitMapToImageSharp(rotatedHead), new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(_minerArmUp, 1f)
                    .DrawImage(_fxUp1, 1f)
                    .DrawImage(_fxSpark5, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningUpBodyBg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpBodyFg,
                        string.Format(MINING_UP_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpArmsBg,
                        string.Format(MINING_UP_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpArmsFg,
                        string.Format(MINING_UP_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpChestBg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpChestFg,
                            string.Format(avatar.Chest.ImageMiningUp, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpHandBg,
                            avatar.Hand.ImageMiningUp + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpHandFg,
                            avatar.Hand.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningUpFootBg,
                            avatar.Foot.ImageMiningUp + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningUpFootFg,
                            avatar.Foot.ImageMiningUp + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(8, 4), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningUpPickBg,
                        string.Format(MINING_UP_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningUpPickFg,
                        string.Format(MINING_UP_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxUp1, 1f)
                    .DrawImage(_fxSpark5, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineDown1(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyDown, 1f)
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(_minerArmDown, 1f)
                    .DrawImage(_fxDown1, 1f)
                    .DrawImage(_fxSpark1, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningDownBodyBg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownBodyFg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownArmsBg,
                        string.Format(MINING_DOWN_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownArmsFg,
                        string.Format(MINING_DOWN_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownChestBg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownChestFg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownHandBg,
                            avatar.Hand.ImageMiningDown + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownHandFg,
                            avatar.Hand.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownFootBg,
                            avatar.Foot.ImageMiningDown + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownFootFg,
                            avatar.Foot.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownPickBg,
                        string.Format(MINING_DOWN_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownPickFg,
                        string.Format(MINING_DOWN_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxDown1, 1f)
                    .DrawImage(_fxSpark1, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineDown2(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyDown, 1f)
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(_minerArmDown, 1f)
                    .DrawImage(_fxDown2, 1f)
                    .DrawImage(_fxSpark2, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningDownBodyBg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownBodyFg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownArmsBg,
                        string.Format(MINING_DOWN_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownArmsFg,
                        string.Format(MINING_DOWN_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownChestBg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownChestFg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownHandBg,
                            avatar.Hand.ImageMiningDown + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownHandFg,
                            avatar.Hand.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownFootBg,
                            avatar.Foot.ImageMiningDown + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownFootFg,
                            avatar.Foot.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownPickBg,
                        string.Format(MINING_DOWN_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownPickFg,
                        string.Format(MINING_DOWN_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxDown2, 1f)
                    .DrawImage(_fxSpark2, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinMineDown3(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyDown, 1f)
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(_minerArmDown, 1f)
                    .DrawImage(_fxSpark3, 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningDownBodyBg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownBodyFg,
                        string.Format(MINING_DOWN_BODY, GenreToStr(avatar), "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownArmsBg,
                        string.Format(MINING_DOWN_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownArmsFg,
                        string.Format(MINING_DOWN_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownChestBg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownChestFg,
                            string.Format(avatar.Chest.ImageMiningDown, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownHandBg,
                            avatar.Hand.ImageMiningDown + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownHandFg,
                            avatar.Hand.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningDownFootBg,
                            avatar.Foot.ImageMiningDown + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningDownFootFg,
                            avatar.Foot.ImageMiningDown + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(head, new SixLabors.ImageSharp.Point(30, 26), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningDownPickBg,
                        string.Format(MINING_DOWN_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningDownPickFg,
                        string.Format(MINING_DOWN_PICK, "fg")
                    ), 1f)
                    .DrawImage(_fxSpark3, 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        private Bitmap UpdateGoblinRest(AvatarInfo avatar, Image<Rgba32> head)
        {
            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {
                head.Mutate(x => x.Resize(147, 147));
                var rotatedHead = Utils.BitMapToImageSharp(RotateImage(Utils.ImageSharpToBitMap(head), 11));
                /*
                outputImage.Mutate(o => o
                    .DrawImage(_minerBodyTired, 1f)
                    .DrawImage(Utils.BitMapToImageSharp(rotatedHead), new SixLabors.ImageSharp.Point(-11, 17), 1f)
                );
                */
                outputImage.Mutate(o => o
                    .DrawImage(GetImageBackground(
                        ref _miningRestBodyBg,
                        string.Format(MINING_REST_BODY, GenreToStr(avatar), "bg"),
                        //string.Format(MINING_REST_BODY, "male", "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningRestBodyFg,
                        string.Format(MINING_REST_BODY, GenreToStr(avatar), "fg")
                        //string.Format(MINING_REST_BODY, "male", "fg")
                    ), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningRestArmsBg,
                        string.Format(MINING_REST_ARMS, "bg"),
                        avatar.SkinColor
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningRestArmsFg,
                        string.Format(MINING_REST_ARMS, "fg")
                    ), 1f)
                );

                if (avatar.Chest != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningRestChestBg,
                            string.Format(avatar.Chest.ImageMiningRest, GenreToStr(avatar)) + "-bg.png",
                            avatar.Chest.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningRestChestFg,
                            string.Format(avatar.Chest.ImageMiningRest, GenreToStr(avatar)) + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Hand != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningRestHandBg,
                            avatar.Hand.ImageMiningRest + "-bg.png",
                            avatar.Hand.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningRestHandFg,
                            avatar.Hand.ImageMiningRest + "-fg.png"
                        ), 1f)
                    );
                }

                if (avatar.Foot != null)
                {
                    outputImage.Mutate(o => o
                        .DrawImage(GetImageBackground(
                            ref _miningRestFootBg,
                            avatar.Foot.ImageMiningRest + "-bg.png",
                            avatar.Foot.Color
                        ), 1f)
                        .DrawImage(GetImageForeground(
                            ref _miningRestFootFg,
                            avatar.Foot.ImageMiningRest + "-fg.png"
                        ), 1f)
                    );
                }

                outputImage.Mutate(o => o
                    .DrawImage(rotatedHead, new SixLabors.ImageSharp.Point(-11, 17), 1f)
                    .DrawImage(GetImageBackground(
                        ref _miningRestPickBg,
                        string.Format(MINING_REST_PICK, "bg"),
                        MaterialColor.IRON
                    ), 1f)
                    .DrawImage(GetImageForeground(
                        ref _miningRestPickFg,
                        string.Format(MINING_REST_PICK, "fg")
                    ), 1f)
                );
                return Utils.ImageSharpToBitMap(outputImage);
            }
        }

        public override async Task<IGoblinSpriteModel> GenerateSprite(IGoblinModel goblin, AvatarInfo avatar, string oldImagePath)
        {
            LoadImages();
            var rt = _miningSpriteFactory.BuildGoblinSpriteModel();

            var geneInfo = _geneService.ConvertInt256ToGene(goblin.Genes);

            //Image<Rgba32> head = null;
            //try {
            var head = Utils.BitMapToImageSharp(GetImage(goblin.GetHeadImageUrl()));
            /*
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
            */

            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH * 12, IMG_HEIGHT))
            {

                outputImage.Mutate(o => o
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineStop1(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 0, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineStop2(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 1, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUp1(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 2, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUp2(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 3, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUp3(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 4, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineDown1(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 5, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineDown2(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 6, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineDown3(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 7, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUpWithSpark1(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 8, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUpWithSpark2(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 9, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineUp3(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 10, 0), 1f)
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinMineStop2(avatar, head)), new SixLabors.ImageSharp.Point(IMG_WIDTH * 11, 0), 1f)
                );
                rt.MiningSprite = Utils.ImageSharpToBitMap(outputImage);
                var imgSave = (byte[])new ImageConverter().ConvertTo(rt.MiningSprite, typeof(byte[]));
                var strPath = string.Format("goblins/{0}/{1}-mine-sprite.png", goblin.TokenId, goblin.BaseImagePath);
                await _assetsProvider.UploadFileToBlobAsync(strPath, imgSave, "image/png");

                if(!String.IsNullOrEmpty(oldImagePath))
                {
                    try
                    {
                        _assetsProvider.DeleteFile(string.Format("goblins/{0}/{1}-mine-sprite.png", goblin.TokenId, oldImagePath));
                    }
                    catch(Exception)
                    {
                        //Se não conseguir deletar, pode seguir com o processamento, pois a mesma pode não existir mais.
                    }
                }
            }

            //imgSprite.Save(@"c:\Projetos\goblin-sprite.png", ImageFormat.Png);

            using (Image<Rgba32> outputImage = new Image<Rgba32>(IMG_WIDTH, IMG_HEIGHT))
            {

                outputImage.Mutate(o => o
                    .DrawImage(Utils.BitMapToImageSharp(UpdateGoblinRest(avatar, head)), 1f)
                );
                rt.TiredSprite = Utils.ImageSharpToBitMap(outputImage);
                var imgSave = (byte[])new ImageConverter().ConvertTo(rt.TiredSprite, typeof(byte[]));
                var strPath = string.Format("goblins/{0}/{1}-tired-sprite.png", goblin.TokenId, goblin.BaseImagePath);
                await _assetsProvider.UploadFileToBlobAsync(strPath, imgSave, "image/png");

                if (!String.IsNullOrEmpty(oldImagePath))
                {
                    try
                    {
                        _assetsProvider.DeleteFile(string.Format("goblins/{0}/{1}-tired-sprite.png", goblin.TokenId, oldImagePath));
                    }
                    catch (Exception)
                    {
                        //Se não conseguir deletar, pode seguir com o processamento, pois a mesma pode não existir mais.
                    }
                }
            }

            return rt;
        }
    }
}
