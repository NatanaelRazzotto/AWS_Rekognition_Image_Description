using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Transfer;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = Amazon.Rekognition.Model.Image;
using Label = Amazon.Rekognition.Model.Label;

namespace AWS_Rekognition_Objects.Helpers.Model
{
    class AnaliserLabelsAWS
    {
        AWSCredentials awsCredentials;
        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;

        private const string bucketName = "demo-unibrasil-imgobjectreko";

        private FileImage file;

        private List<Label> ListlabelObjectsCategories;
        public AnaliserLabelsAWS(FileImage file) {
            this.file = file;
        }

        public async Task<bool> UploadImageFromS3()
        {
            try
            {
                AmazonS3Client amazonS3Client = new AmazonS3Client(awsCredentials, region);
                TransferUtility transferUtility = new TransferUtility(amazonS3Client);
                await transferUtility.UploadAsync(file.nameFile, bucketName);
                return true;
            }
            catch (AmazonS3Exception ex)
            {
                MessageBox.Show($"Error encontered on server. Message>: '{0}' when writing an object { ex.Message} ");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error encontered on server. Message>: '{0}' when writing an object { ex.Message} ");
                return false;
            }

        }

        public List<Label> getListlabelObjectsCategories()
        {
            return ListlabelObjectsCategories;

        }

        public async Task<bool> getCredentialsAWS()
        {
            CredentialProfileStoreChain credentialProfileChain = new CredentialProfileStoreChain();
            if (credentialProfileChain.TryGetAWSCredentials("AWS Educate profileD", out awsCredentials))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> DetectScenes(int numberLabels, Single minConfidence)
        {
            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(awsCredentials, region);
            DetectLabelsRequest detectLabelsRequest = new DetectLabelsRequest()
            {
                Image = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Name = Path.GetFileName(file.nameFile),
                        Bucket = bucketName
                    },

                },
                MaxLabels = numberLabels,
                MinConfidence = minConfidence //75F
            };
            try
            {
                DetectLabelsResponse detectLabelsResponse = await rekognitionClient.DetectLabelsAsync(detectLabelsRequest);
                ListlabelObjectsCategories = formatarCoordenadas(detectLabelsResponse.Labels);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro{e.Message}");
                return false;
                throw;
            }


        }
        public List<Label> formatarCoordenadas(List<Label> labelObjects)
        {
            foreach (Label item in labelObjects)
            {
                foreach (Instance itemLabel in item.Instances)
                {
                    itemLabel.BoundingBox.Left = itemLabel.BoundingBox.Left * file.image.Width;
                    itemLabel.BoundingBox.Top = itemLabel.BoundingBox.Top * file.image.Height;
                    itemLabel.BoundingBox.Width = itemLabel.BoundingBox.Width * file.image.Width;
                    itemLabel.BoundingBox.Height = itemLabel.BoundingBox.Height * file.image.Height;
                }
            }
            return labelObjects;
        }

        [Obsolete("Metodos reconstruido e divido entre outros processos e classes")  ]
        public List<ObjectCategorized> convertResponseInObjectCategory(List<Label> labelObjects, int pictureWidth, int pictureHeight)
        {
            List<ObjectCategorized> listObjectCategorizeds = new List<ObjectCategorized>();
            foreach (Label item in labelObjects)
            {
                ObjectCategorized objectCategorized = new ObjectCategorized();
                objectCategorized.Name = item.Name;
                objectCategorized.Confidence = item.Confidence;
                objectCategorized.penCategory = new Pen(Color.Red);

                // ItemObject[] listRectangleF = new ItemObject[item.Instances.Count];
                List<ItemObject> listRectangleF = new List<ItemObject>();
                foreach (Instance itemLabel in item.Instances)
                {
                    ItemObject itemObject = new ItemObject();
                    itemObject.Confidence = itemLabel.Confidence;
                    itemObject.penItem = new Pen(Color.Red);
                    //itemLabel.BoundingBox.Top = itemLabel.BoundingBox.Top * pictureHeight;
                    itemObject.Rectangle = new RectangleF(itemLabel.BoundingBox.Left * pictureWidth,
                                                          itemLabel.BoundingBox.Top * pictureHeight,
                                                          itemLabel.BoundingBox.Width * pictureWidth,
                                                          itemLabel.BoundingBox.Height * pictureHeight);
                    listRectangleF.Add(itemObject);
                }
                objectCategorized.Instances = listRectangleF;
                listObjectCategorizeds.Add(objectCategorized);
            }
            return listObjectCategorizeds;
        }

    }
}
