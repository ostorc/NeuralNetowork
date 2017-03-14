using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork.MINST.Processing;
using NeuralNetwork.Objects;
using NeuralNetwork.Trainers;

namespace NeuralNetwork.Images.Viewer
{
    public partial class frmMain : Form
    {
        private Random rand = new Random();
        private List<DigitImage> data;
        private readonly ICalculatableImageNetwork network;
        public frmMain()
        {
            TrainerManager tm = new TrainerManager();
            DigitImageLoader loader = new DigitImageLoader();

            
            data = loader.Load().OrderBy(x=>rand.Next(int.MaxValue)).Take(500).ToList();
            network = tm.GetTrainer(LearningSubject.Image, LearningObject.Network).Get<ICalculatableImageNetwork>();
            
            InitializeComponent();
            //imageList.Images.Add(Image.Fro)
            CustomDigitImageProcessor d =
                new CustomDigitImageProcessor(@"C:\Users\ostorc\Desktop\testData_whiteBlack.png", 2);
            var img = d.Load();

            SetMainText(img);
            

            /*
            double succesRate = 0;
            foreach (var pair in data)
            {
                var di = pair;
                var data = network.GetNumber(pair);
                if (di.Label == data) succesRate += 1.0 / this.data.Count;
            }*/
        }

        private DigitImage addToListView(DigitImage image)
        {
            var guid = Guid.NewGuid().ToString();
            imageList.Images.Add(guid,image.NumberImage);
            lvImages.Items.Add(image.Label.ToString(), imageList.Images.IndexOfKey(guid));
            lvImages.Items[lvImages.Items.Count - 1].Tag = image;
            lvImages.Refresh();
            return image;
        }

        private void SetMainText(DigitImage image)
        {
            pcbMain.Image = image.NumberImage;
            lblExpected.Text = image.Label.ToString();
            lblActual.Text = network.GetNumber(image).ToString();
            lblActual.ForeColor = (lblActual.Text == lblExpected.Text) ? Color.Green : Color.Red;
        }
        
        private void btnGetRandom_Click(object sender, EventArgs e)
        {
            SetMainText(data[rand.Next(0, data.Count)]);
        }

        private void lvImages_Click(object sender, EventArgs e)
        {
            var item = lvImages.SelectedItems[0];
           
            SetMainText((DigitImage) item.Tag);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                var res = fileDialog.ShowDialog();
                if (res != DialogResult.OK) return;
                CustomDigitImageProcessor processor = new CustomDigitImageProcessor(fileDialog.FileName, -1);
                var img = processor.Load();
                data.Add(img);
                SetMainText(addToListView(img));
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private async void frmMain_Shown(object sender, EventArgs e)
        {
            Tuple<ImageList, ListView> list =
                await Task.Run(() =>
                {
                    ImageList imgList = new ImageList();
                    ListView itmList = new ListView();
                    foreach (DigitImage image in data)
                    {
                        var guid = Guid.NewGuid().ToString();
                        imgList.Images.Add(guid, image.NumberImage);
                        itmList.Items.Add(image.Label.ToString(), imgList.Images.IndexOfKey(guid));
                        itmList.Items[itmList.Items.Count - 1].Tag = image;
                    }
                    return new Tuple<ImageList, ListView>(imgList, itmList);
                });
            imageList = list.Item1;
            foreach (ListViewItem itm in list.Item2.Items)
            {
                itm.Remove();
                lvImages.Items.Add(itm);
            }
            //lvImages = list.Item2;
            lvImages.LargeImageList = imageList;
            lvImages.SmallImageList = imageList;
            lvImages.Refresh();

            lblTestSuccess.Text = await Task.Run(() =>
            {
                double succesRate = 0;
                foreach (var pair in data)
                {
                    var di = pair;
                    var d = network.GetNumber(pair);
                    if (di.Label == d) succesRate += 1.0 / this.data.Count;
                }
                return succesRate.ToString("p2", CultureInfo.CurrentCulture);
            });


            lblLearningSuccess.Text = await Task.Run(() =>
            {
                var data = new DigitImageLoader(DigitImageLoader.DefaultImagesPathTest, DigitImageLoader.DefaultLabelsPathTest).Load();

                double succesRate = 0;
                foreach (var pair in data)
                {
                    var di = pair;
                    var d = network.GetNumber(pair);
                    if (di.Label == d) succesRate += 1.0 / data.Count;
                }
                return succesRate.ToString("p2", CultureInfo.CurrentCulture);
            });
        }
    }
}
