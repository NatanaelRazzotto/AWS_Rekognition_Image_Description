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
    class Analizer
    {
        AWSCredentials awsCredentials;
        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;

        private const string bucketName = "demo-unibrasil-imgobjectreko";
        //private string fileName;
        private FileImage file;
        public Analizer(FileImage file) {
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

        public async Task<DetectLabelsResponse> DetectScenes()
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
                MaxLabels = 10,
                MinConfidence = 75F
            };
            try
            {
                DetectLabelsResponse detectLabelsResponse = await rekognitionClient.DetectLabelsAsync(detectLabelsRequest);
                return detectLabelsResponse;
            }
            catch (Exception e)
            {
                //rtbRetornoProcesso.AppendText($"Ocorreu um erro{e.Message}");
                Console.WriteLine($"Ocorreu um erro{e.Message}");
                return null;
                throw;
            }


        }
    }
}
