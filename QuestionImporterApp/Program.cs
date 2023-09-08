using CsvHelper;
using QuestionImporterApp;
using QuestionImporterApp.Validations;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace QuestionsImporterApp
{
    internal class Program
    {
        static private Dictionary<int, string> _stringHashes = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            args = new string[] { "C:\\Users\\heali\\Documents\\GitHub\\JBQCompleteIt\\JBQ_20_Points.csv" };

            if(args.Length == 1)
            {
                List<QuestionSheetRow> rows;

                using (var reader = new StreamReader(args[0]))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        rows = csv.GetRecords<QuestionSheetRow>().ToList();
                    }
                }

                var validations = ValidationHelpers.GetValidations();

                var allPassed = true;

                foreach(var validation in validations)
                {
                    var instance = Activator.CreateInstance(validation.Type) as IValidation;

                    if (instance != null)
                    {
                        var errors = instance.Validate(rows);

                        if(errors.Count() > 0)
                        {
                            foreach(var error in errors)
                            {
                                Console.WriteLine(error);
                            }

                            allPassed = false;
                        }
                    }
                    else
                    {
                        throw new Exception($"Failed to create instance of type '{validation.Type}'");
                    }
                }

                if(allPassed)
                {
                    Console.WriteLine("All validations passed");

                    var key = GenerateKey();

                    Console.WriteLine($"NEW KEY: {key}");

                    using StreamWriter file = new("question_data.cs.snippet", false);

                    foreach (var row in rows)
                    {
                        file.WriteLine(@"new QuestionInfo {");
                        file.WriteLine($"    Number = { row.Number },");
                        file.WriteLine($"    Question = \"{ EncryptString(key, row.Question) }\",");
                        file.WriteLine($"    AnswerHash = { GetStringHash(row.Answer) },");

                        List<string> brokenDownAnswer;
                        if (row.Type == "Jumble" || row.Type == "QuotationQuestion")
                        {
                            brokenDownAnswer = row.Answer.Split(' ').Select(x => $"\"{EncryptString(key, x)}\"").ToList();
                        }
                        else
                        {
                            brokenDownAnswer = new List<string> { $"\"{EncryptString(key, row.Answer)}\"" };
                        }
                        file.WriteLine($"    Answer = new List<string> {{ { string.Join(',', brokenDownAnswer) } }},");

                        var wrongAnswers = row.WrongAnswersAsList();
                        if (wrongAnswers == null)
                        {
                            file.WriteLine($"    WrongAnswers = null,");
                        }
                        else
                        {
                            file.WriteLine($"    WrongAnswers = new List<string> {{");
                            foreach (var wrongAnswer in wrongAnswers)
                            {
                                file.WriteLine($"        \"{EncryptString(key, wrongAnswer)}\",");
                            }
                            file.WriteLine($"    }},");
                        }

                        if(string.IsNullOrEmpty(row.Passage))
                        {
                            file.WriteLine($"    Passage = null,");
                        }
                        else
                        {
                            file.WriteLine($"    Passage = \"{row.Passage}\",");
                        }
                        if (string.IsNullOrEmpty(row.Type))
                        {
                            file.WriteLine($"    Type = null");
                        }
                        else
                        {
                            file.WriteLine($"    Type = QuestionTypeEnum.{row.Type}");
                        }
                        file.WriteLine(@"},");
                    }

                    Console.WriteLine("Code snippet generated");
                }
            }
            else
            {
                Console.WriteLine("ERROR: Full path the CSV file to import must be specified");
            }
        }

        static private string GenerateKey()
        {
            var crypto = Aes.Create();
            crypto.KeySize = 128;
            crypto.BlockSize = 128;
            crypto.GenerateKey();
            byte[] keyGenerated = crypto.Key;
            return Convert.ToBase64String(keyGenerated);
        }

        static private string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        static private int GetStringHash(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            var hash = value.GetHashCode();

            if(_stringHashes.TryGetValue(hash, out var foundMergeString) == false)
            {
                _stringHashes.Add(hash, value);
            }
            else
            {
                if (value != foundMergeString)
                {
                    throw new InvalidOperationException("Deal with when/if it happens...");
                }
            }

            return hash;
        }
    }
}