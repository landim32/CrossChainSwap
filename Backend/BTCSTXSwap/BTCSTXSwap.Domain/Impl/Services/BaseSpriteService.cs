using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.DTO.Goblin;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public abstract class BaseSpriteService
    {
        protected abstract void LoadImages();

        protected Bitmap GetImage(string url)
        {
            try
            {
                var webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(url);
                using (var ms = new MemoryStream(imageBytes))
                {
                    var bm = new Bitmap(ms);
                    return bm;
                }
            }
            catch (Exception err)
            {
                //Console.WriteLine("Error Assets: \n\t" + err.Message);
                throw new Exception(string.Format("Url not found\n{0}", url), err);
            }
        }

        protected Bitmap RotateImage(Bitmap bm, float angle)
        {
            var imagem = Utils.BitMapToImageSharp(bm);
            imagem.Mutate(o => o.Rotate(angle));
            return Utils.ImageSharpToBitMap(imagem);
        }

        public abstract Task<IGoblinSpriteModel> GenerateSprite(IGoblinModel goblin, AvatarInfo avatar, string oldImagePath);
    }
}
