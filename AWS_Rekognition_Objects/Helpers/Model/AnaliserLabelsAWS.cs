using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using AWS_Rekognition_Objects.Helpers.Model.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
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

        private const string bucketName = "demo-unibrasil-img-object-reko";

        private FileImage file;

        List<string> nomeImagensExistentesBucket = new List<string>();

        private List<Label> ListlabelObjectsCategories;
        public AnaliserLabelsAWS(FileImage file) {
            this.file = file;
        }

        public void listarNomesImagensDoBucket()
        {
            AmazonS3Client amazonS3Client = new AmazonS3Client(awsCredentials, region);
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = bucketName
            };

            ListObjectsResponse listResponse;
            do
            {
                listResponse = amazonS3Client.ListObjectsAsync(request).Result;
                foreach (Amazon.S3.Model.S3Object obj in listResponse.S3Objects)
                {
                    nomeImagensExistentesBucket.Add(obj.Key);
                    Console.WriteLine(obj.Key);
                    Console.WriteLine(" Size - " + obj.Size);
                }

                request.Marker = listResponse.NextMarker;
            } while (listResponse.IsTruncated);
        }

        public async Task<bool> UploadImageFromS3()
        {
            string[] nameFileSeparado = file.nameFile.Split('\\');
            int qtdeItensNameFile = nameFileSeparado.Length;
            string nomeImagemAInserir = nameFileSeparado[qtdeItensNameFile - 1];
            bool inserirArquivoNoBucket = true;

            if (nomeImagensExistentesBucket.Contains(nomeImagemAInserir))
            {
                if (MessageBox.Show($"Arquivo ja consta no bucket: {bucketName}, deseja substituilo ?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    inserirArquivoNoBucket = false;
                }
            }

            if (inserirArquivoNoBucket)
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
                    MessageBox.Show($"Erro encontrado no servidor, ao escrever objeto { ex.Message} ");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro encontrado no servidor, ao escrever objeto { ex.Message} ");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public List<Label> GetListlabelObjectsCategories()
        {
            return ListlabelObjectsCategories;

        }

        public async Task<bool> GetCredentialsAWS()
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

        public async Task<bool> DetectScenes(int numberLabels, float minConfidence)
        {
            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(awsCredentials, region);
            DetectLabelsRequest detectLabelsRequest = new DetectLabelsRequest()
            {
                Image = new Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
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
                ListlabelObjectsCategories = FormatCoordinates(detectLabelsResponse.Labels);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }


        }

        public List<Label> FormatCoordinates(List<Label> labelObjects)
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

        //[Obsolete("Metodos reconstruido e divido entre outros processos e classes")  ]
        //public List<ObjectCategorized> convertResponseInObjectCategory(List<Label> labelObjects, int pictureWidth, int pictureHeight)
        //{
        //    List<ObjectCategorized> listObjectCategorizeds = new List<ObjectCategorized>();
        //    foreach (Label item in labelObjects)
        //    {
        //        ObjectCategorized objectCategorized = new ObjectCategorized();
        //        objectCategorized.Name = item.Name;
        //        objectCategorized.Confidence = item.Confidence;
        //        objectCategorized.penCategory = new Pen(Color.Red);

        //        // ItemObject[] listRectangleF = new ItemObject[item.Instances.Count];
        //        List<ItemObject> listRectangleF = new List<ItemObject>();
        //        foreach (Instance itemLabel in item.Instances)
        //        {
        //            ItemObject itemObject = new ItemObject();
        //            itemObject.Confidence = itemLabel.Confidence;
        //            itemObject.penItem = new Pen(Color.Red);
        //            //itemLabel.BoundingBox.Top = itemLabel.BoundingBox.Top * pictureHeight;
        //            itemObject.Rectangle = new RectangleF(itemLabel.BoundingBox.Left * pictureWidth,
        //                                                  itemLabel.BoundingBox.Top * pictureHeight,
        //                                                  itemLabel.BoundingBox.Width * pictureWidth,
        //                                                  itemLabel.BoundingBox.Height * pictureHeight);
        //            listRectangleF.Add(itemObject);
        //        }
        //        objectCategorized.Instances = listRectangleF;
        //        listObjectCategorizeds.Add(objectCategorized);
        //    }
        //    return listObjectCategorizeds;
        //}

    }
}
