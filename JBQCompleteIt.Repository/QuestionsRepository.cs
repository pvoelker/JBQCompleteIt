using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JBQCompleteIt.Repository
{
    /// <summary>
    /// In-memory repository for questions
    /// </summary>
    /// <remarks>Questions and correct answers are sourced from the 20-points questions of the Bible Fact-Pak (TM) and is Copyright (c) 2021 Gospel Publishing House</remarks>
    /// <remarks>In-memory data for questions and answers are encrypted to help protect the copyrighted material</remarks>
    public class QuestionsRepository : IQuestionRepository
    {
        private static readonly ICryptoTransform _decryptor;

        static private List<RawQuestionInfo> _data;

        /// <summary>
        /// Static constructor for the repository
        /// </summary>
        static QuestionsRepository()
        {
            const string key = "jAJapoeuaFgSsoY39gLauA==";

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];
                _decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            }

            _data = new List<RawQuestionInfo>
            {
                new RawQuestionInfo {
                    Number = 289,
                    Question = "P3nLCeYLN+LLtfDloz2BwBmbHrHZPGyZFi+kwBYYO9s=",
                    AnswerHash = -1169344752,
                    RawAnswerCount = 16,
                    RawAnswer = "Wz3HtusRgAjg2H9ZDP1daJvnq87kmYz5/p6l9i8AcZu/QyLqfdE60OErdvFBqQrfp+pCstLP9M1R3iGZZ0d611Ehqa1ZJyxQ2BbEfhJJQ0GTdil9U8rPhkRxl3HeapNa",
                    WrongAnswers = null,
                    Passage = "2 Peter 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 290,
                    Question = "OwUc4zVMadVVWG6rH/+WC/R8KeINKSBsSd7qVVAFzCpUYrY7zJ33Sknz7BjUMO/PsAXOVzvGxrEL7XW4XT0Yow==",
                    AnswerHash = -612674714,
                    RawAnswerCount = 8,
                    RawAnswer = "eqKFVEJBS7khW0y2vgS8zxYnIQ1Xuy1DKHtm1kuDMNnh5i0D4qufev5VejPmCrkQ",
                    WrongAnswers = null,
                    Passage = "Psalm 119:160; 1 Thessalonians 2:13; 1 Peter 1:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 291,
                    Question = "OwUc4zVMadVVWG6rH/+WC/R8KeINKSBsSd7qVVAFzCpzrWQqKWLo8xgfXcSn6j96/qnkMh5JNGuAmVW7UnT8HQ==",
                    AnswerHash = 1515681485,
                    RawAnswerCount = 13,
                    RawAnswer = "KKj42FC2Ot3KSj9AJAAvYG/V/cfhQb6BDpyruQ+cQSEpExBgs42eZDHRTg5/MqsMOatXWl0L/IXS3jMEAT0xifhc+8xPxbsDYUPea8oKHFg=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 292,
                    Question = "OwUc4zVMadVVWG6rH/+WC/R8KeINKSBsSd7qVVAFzCqtRQvlojAcb42jljCZlZPpjsjSTSaJnrItLJXTRy/e/NkKRFE/ZvkcFC3VJLzK6jZr6l36ImRk6ouQhKJd54zi",
                    AnswerHash = -1343768354,
                    RawAnswerCount = 16,
                    RawAnswer = "M4L9PdEQrxvZVW9awKaOSbvoFqCOqeiTXYPYoli0hT2WUEguMsl7F/FnKuW1KFWRnSJOyXonQWuaMqrqQJ+YfPcOm1KlQ/vUUmyiKdyOxdo=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 293,
                    Question = "XzsJegqRf7aqq3pVJ9UNWdARzsws77VLvQxp9y+v2QM=",
                    AnswerHash = -953781868,
                    RawAnswerCount = 11,
                    RawAnswer = "yLTnnU451BkPIje0qywl3R7fUtIKPfdhQ69NgYDkY+q7aIbXaMQH7monkjKmmUDZnlpAbxP/78fNnxx7RsK7ZwI7758uVN+DsVigZBQv91g=",
                    WrongAnswers = null,
                    Passage = "Matthew 24:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 294,
                    Question = "esDbJB9OllyJOhn/owRmwts/QvoY8UEd04gVINHc/WuU4HUN+UvxzLYjcZU53MCd",
                    AnswerHash = -329575341,
                    RawAnswerCount = 15,
                    RawAnswer = "YN9aIrk4k3TOpCxivhOot64wyd7g5XjWqaL9xMQ/6xwtSpohSLETPugeMoFahYulkW+VTS78oBJE5unzKvHmM7RCWjqCg3oVsiD/mm88GqY=",
                    WrongAnswers = null,
                    Passage = "Psalm 119:11",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 295,
                    Question = "8aeLRlJmxoxqXv1hVQm1dMpqbIcNYbCRJMdZOT0PB5jKEUERQKUwxw317J05jAEx",
                    AnswerHash = -361580047,
                    RawAnswerCount = 17,
                    RawAnswer = "fFa7uOIFdM8t1QZAXMwP3YDwKboNAxknQcgyrWwHJGwscotm8NbPciLM4BqbbUczJrBBDAOTeQPeKeN1bmSuSzhOzm4BXwybYbkDm7IXx9XlBRe+G5GMoAfoJVococ5a",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 296,
                    Question = "fLl2CwKzVdqn6tjkWd0CXy41TSaWWHAsX9odGIKqw1wlJC1VFqdqJ9jnPAvmakiq+A6HtUOnMF5yIgvBvWsmMQ==",
                    AnswerHash = 1840536643,
                    RawAnswerCount = 1,
                    RawAnswer = "2481KxTRx9t/avUqb5ayp+oX7ljY3AlDMEs5XteXU+k=",
                    WrongAnswers = new List<string> {
                        "9mdP8LFJQ2LDEkzSY4YbiePOgxxve89nanhYdY2ph+E=",
                        "GH50sWet8IlzK0J1nNYe9w==",
                        "zlOawkVlGaqqLjxK+K5RMw==",
                        "ZrgXvEQb4ftZYvIiAd5K8Q==",
                        "sRIhluh8dPdpLc+64zhVCg==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 297,
                    Question = "YvfR6tmsE3MGFcsEP5luQR3wTff8kLHrIehKERQkN9oLlyw0iedIr8Z3T6nQUWqa",
                    AnswerHash = -650483233,
                    RawAnswerCount = 1,
                    RawAnswer = "G+z1laR/cUiuUy9/zYO+Bg==",
                    WrongAnswers = new List<string> {
                        "PswEK7qPqpHRSa5HjZht3Q==",
                        "wYOunoBUP9+4JISCm3PBVQ==",
                        "AR9oFuKxrnVbfcIAbkwt4A==",
                        "HBMgJny3f1ZzTNSOA8DiIA==",
                        "yNY54max7iKQSI4CRi/OvQ==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 298,
                    Question = "HRbvMeCq1LbE0ow2Yh40sjwh3EkVBX/2PaP6tU5hOnlzFVN7p7UVzXcwdgPBV5JD",
                    AnswerHash = 1073862730,
                    RawAnswerCount = 1,
                    RawAnswer = "Qi80fT7jMbLMC5PMWZ0ov9TCIr9IuOrtzhdHjF0q2RukFxiCKciX90YMI8Ov3TZM",
                    WrongAnswers = new List<string> {
                        "FMpdCjR0l1tu62xfJADZQhTVO0zanqYTcWnxgN9AR/E=",
                        "bTGpBXy62kJZYJ3R31IuZtNNzmibjrc2+ObiHgLN+q4=",
                        "YxeUdy2HJ7qyugajVcX9R7mtT3u+RVg5Ju63yunh8Z2C3E9cNPelWm3Vub34Hi6M",
                        "+H2HCOfpEjuZKdKR+mFHWVsV1yx8yzY/vuR74/CNY4c=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 299,
                    Question = "2wGfOyKhulgjCsXEEqlrSgY/94Q7dElA4z8UdeMQY3monwJKVluHLMoidVa+47O9",
                    AnswerHash = 639262950,
                    RawAnswerCount = 1,
                    RawAnswer = "oM8616HT8j7+m7lkKAaaBvJKor94WZiKy9fhWIB7HU4=",
                    WrongAnswers = new List<string> {
                        "LAFXQiua3muFv+SZ1sLS2A==",
                        "g+ZjuC71opOT6rziHly6XA==",
                        "88wBfhNOgNClN/lpM0WWPw==",
                        "wTbX0cz7mIAQ5coJKQWQKf7LkK0f7oiVYHdk4sOeoFk=",
                        "NC6bEbtzC/9pewPoVbCWfmLcH+Xr7T3+rMplkRv1ETA=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 300,
                    Question = "xL8B5msnQx/w0b9Vf0fwO4Dt3F7MEJ8Jjg6ywNN2Txs=",
                    AnswerHash = 735368697,
                    RawAnswerCount = 14,
                    RawAnswer = "TZ+NwyJ1elNYRnbb7wnMho7U47snrtF9Eih/6a1Vh98Qk70TlF/CBjwMWqMkFqhbS/JEtZsK7YxnVKlEcaAL1f5SsKgDwjNsumB2ZL+ruSZxkN4DzzKD67RVWkH1ncZo",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 301,
                    Question = "xxvOL/zGy0DuZcw/LvQL6mVdG79f0Ilk1Q1MEYFJJqTZwI4GqHSPcKtd8P8CeX3Uon4mKmDG3kwrsSVZRz9mAw==",
                    AnswerHash = -1885849051,
                    RawAnswerCount = 1,
                    RawAnswer = "TMkUp/Vi5cchmBKjjsHnUPkCrz5KsRzUY9lPizMdcfo=",
                    WrongAnswers = new List<string> {
                        "WASGmRB7umvVTaQqZG6FD+xHq/IZP9BWHhWyzTsomhaeMW4aPiqE5tuYJ7PiowjrzoU8vqf/i4s24hbhtqPyvA==",
                        "3up9eJF3kw/Y56XBhUpYTdfT5iPhyODMhTWngGwCXLQ=",
                        "b+FQfDzImnp2cWWT8agQ76pX5RJgZ1V5EykoGzw/QWQo9Ge8o06DhRdRRzresIaQ",
                        "fcuV3W8YU9hDIRF16Z0ixLa8A0jQVwFtUhrmrNhEaAA=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 302,
                    Question = "QwFrgFEYinHArgNPDcH+VVaZWTPbCvW2DvIHteEmU13IZuCdaXzSIM85ROl/kWN9dEVA4a3s+m+m+BdCZy2pnA==",
                    AnswerHash = -1542849977,
                    RawAnswerCount = 1,
                    RawAnswer = "5CsE4llVhq1TyLpv5maHQA==",
                    WrongAnswers = new List<string> {
                        "C2qdVwwaWlizLul+6Gkbzg==",
                        "mRdU4koFY8QIqTB0K3ulzQ==",
                        "B2mM+jcF9aMw/MfjKPhk7Q==",
                        "R655VNvuCiVOQuEzPb+Wwg==",
                        "vZMdk2zy5KwgI6m+MGQMKw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 303,
                    Question = "DbTXF5wo+zWHAZmGhxa7YpjNp1+DfxrQAiRvtWp8kIdsAT76nnprt1fNHG3L3J/H",
                    AnswerHash = -913546396,
                    RawAnswerCount = 17,
                    RawAnswer = "xJetkOxfZ/W+BfYT5oJTuFTFrLA5a0jD1mW+PZyblkFwnyb8MQn8g6yFkSovx7AMNDIq1HTllO8QrlVROIUhdnlMCzg3RRalba0Do3+XJyGOVW4B0ttvaFS9ryLUJTr+M31+KogNyuYqzxpXRtztZQ==",
                    WrongAnswers = null,
                    Passage = "Hebrews 7:11-28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 304,
                    Question = "CgMn8T7hVz4d/toXMI4C/GQOih7Qil2UM9eVWjvuuLOIcvEjDDQy7ADUyEKA+w8HH7H/Ky9M7o+GmpRwIbLDqbljwNuL46SU7mSsMtwoG4+vVn/uOeS+U+HA0wBAsuo5AQBoOR+8qbCaXMqaTaZc5g==",
                    AnswerHash = -2006497101,
                    RawAnswerCount = 1,
                    RawAnswer = "PswEK7qPqpHRSa5HjZht3Q==",
                    WrongAnswers = new List<string> {
                        "wYOunoBUP9+4JISCm3PBVQ==",
                        "AR9oFuKxrnVbfcIAbkwt4A==",
                        "HBMgJny3f1ZzTNSOA8DiIA==",
                        "FbiEOZgKlSCpZExPRYGv9A==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 305,
                    Question = "HKCq1MIaO57X6+PPulIEgqM3/XccqZpzIAH+xIEH07ioHKqkKq6a4gp4PbLhBbzGAE6Fh1k2C5zWQIViln3dq/9YjWSmgF58VtYhXjThpcSrCo9QgFAEGnqnWw0hbrmsxZ8L5pa1MRKvR+00fRunJQ==",
                    AnswerHash = -147404939,
                    RawAnswerCount = 1,
                    RawAnswer = "1puhLGJgXPlBrBe0rVElwaWwJwQVKtT4salPbPml6oM=",
                    WrongAnswers = new List<string> {
                        "6dFKFe/HtcMQXod/6x4QPcUiAOHx892LaKvIQcaxXdQ=",
                        "9NeEo3H1f79+MWwrX7/45qoM36a0s0cW2A+TsM9pDR4=",
                        "k9P0sezV3GZXPnsBu5KONQMGMKVsDytJNhg/9JfX3bk=",
                        "ZEX6ut0hnojqN14rPSP3/Rq/Z5pdA84GWhU+WQ3JfaI=",
                        "nVn3rYvBo+E5K6pu9XGHM2KKlU9dKfXEBQl+XPwq/GM=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 306,
                    Question = "aHUXTo/s4f/1E6i+nNtkW2NhGeW+tU6Uy7XokYeiFzeeUFgduUGu0g52HaGmIUTc",
                    AnswerHash = -1136414695,
                    RawAnswerCount = 10,
                    RawAnswer = "TtpcTK0P6kTW36kENrnjJr/q9kLt7p0sl7zvli/jUYz9PnduXJJ+6wRBGLqMw56MRiw73WhagkGLS0ryKPD04Q==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19; Acts 10:38; 2 Corinthians 13:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 307,
                    Question = "OwUc4zVMadVVWG6rH/+WC8QN4x1QWoEUSWWSmyOtO6g5If/xUblRP6jS36oabuXF4EBlWFQrxViZkMETRDZbCg==",
                    AnswerHash = -1786039279,
                    RawAnswerCount = 14,
                    RawAnswer = "J++BaGMPG7O+U5BVi335HdXUXbfn8XgEhSo51IbZeyO1zTU3nXIqp4vQXuvEAS+2pwQC8AdwvBQtF+cvV1LVOOwlmk51pT9McRCD1FTQbvs=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 308,
                    Question = "OwUc4zVMadVVWG6rH/+WC8QN4x1QWoEUSWWSmyOtO6hiDNTLA+ilm44DubIBtmZ5o+nXT9gXdmSA2W79R+VrOQ==",
                    AnswerHash = 571361354,
                    RawAnswerCount = 7,
                    RawAnswer = "wLLvRodiBseveE/M4AXMT9oroLANC8yv9fVqJrlp7T/Dzo8VLu4W8/PyPIORkur6",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 309,
                    Question = "OwUc4zVMadVVWG6rH/+WC8QN4x1QWoEUSWWSmyOtO6irM7l5lDlRPTvwIIH7DrfqQXiG8xOo9jNxYPQ7epobQg==",
                    AnswerHash = -601731442,
                    RawAnswerCount = 1,
                    RawAnswer = "rVtC3AbfwDRO4TkBjZLlXMlwgzUpuGaaCBk3LCDnOKY=",
                    WrongAnswers = new List<string> {
                        "7hQALqw3QS3z5GvAqpijWX62MTqU8hirIZoQwUgXxmA=",
                        "GOVj7xW9wjhkkGBtgNCKwdhL8XtVHQLwmdEcwIgtfEo=",
                        "E0JFQxoKdUjmSWwC7yC0PFkMTcTEeK7TY2DbXPqLaOY=",
                        "BHwiIaSrbjkSL8qr2qb990tmkOgE/MZ17B5G7+BCRx4=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 310,
                    Question = "OwUc4zVMadVVWG6rH/+WC8QN4x1QWoEUSWWSmyOtO6gEiA5vv8B5UZoZps8Rse4i3Xsm8oSnJuFj8raxAt4DYg==",
                    AnswerHash = -465280595,
                    RawAnswerCount = 5,
                    RawAnswer = "Ebjji1E3+h/Q6lUlkETvqDkb+ELeIYc95/mp8meh7zgZ8LWFpmfU1n0OP/bpv+vC",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 311,
                    Question = "4dk9pexLHyqG3/3AXypSVI/ElKuZenbEjdUJr8qgvtytzXJupFpbbpi6rgMrzl4n",
                    AnswerHash = 1854948983,
                    RawAnswerCount = 17,
                    RawAnswer = "D90BVsAwBAylAE3Ob8b9YDWJoqDxTDqySuzsk7xjqKK8o3FsyKDQevhEDiE9tJEjiypXnWQDomsVBxfGKQ1Jkn50xESpXEclJC5TL2iNoA2U32JTRpnY92r/oHtVhl0c",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 312,
                    Question = "A4vcC2SvNAq9RNno0njjXXq4bionnHePWA9yXy/mBQ63pDKhIfdJ0KTwdyJ4RfU5lQNOzjjBZOgTO5bFfH460A==",
                    AnswerHash = -87662575,
                    RawAnswerCount = 1,
                    RawAnswer = "cpZZ2Ihl/uODEzf26lE7UMzFTBMNEqIYufXY5mhxdMM=",
                    WrongAnswers = new List<string> {
                        "nPlY9bo9AiKYf5yrq5h4QOFPrw9m7bjUxub7CpRSt4M=",
                        "B1s/Pc0lJJkppgZKqEBnpg==",
                        "bvHR6OPxjTZpN9pNKcMcng==",
                        "9n67vD+1q+Js74nHLw3cmmgSxmXg7sJa4Fe08qoQcEc=",
                    },
                    Passage = "Proverbs 9:10",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 313,
                    Question = "Tfe91hIb0qa2kJSCrBrLUwqn0Ut655UJna9tQ9nwMf193TihuUpRws8zj35b4PWc",
                    AnswerHash = -929347404,
                    RawAnswerCount = 10,
                    RawAnswer = "8fotyAroRYT2u+p3GiyZ72KyCuzNZaDvkoMhxoS0la118hd2ii8IU3dmvdx++px2sGugtKEya3a4Ooi5d/GvxQ==",
                    WrongAnswers = null,
                    Passage = "John 4:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 314,
                    Question = "ZGxwT1FfzrHaUEKnZQPal1WqoKnPlPEETqeKOv3LCs0=",
                    AnswerHash = -1612175980,
                    RawAnswerCount = 17,
                    RawAnswer = "VIYvdRbyrywQygkNiD7u3Z0ZnRblKzcy0WaRNrUdu6qmJuuq7AOplPKmv8mzL0XjGioHkt4w/8KpVM/gpFlU6wBLhAWPp3DkSc0gHLqIjpMLKkzA2F2NCGva4O5/lZPy",
                    WrongAnswers = null,
                    Passage = "John 1:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 315,
                    Question = "KYIfBy98KMKypGnFoBzpeYOH3TD97KEVI9sOnEsGrlEeJL4VopSim17GnmsikmoU",
                    AnswerHash = 2029486307,
                    RawAnswerCount = 1,
                    RawAnswer = "yQOlgdF4novDD9F4Eostbw==",
                    WrongAnswers = new List<string> {
                        "fsy8OfnJRVrBgnI+tqqTpA==",
                        "UGKvyIc4AqpE/z5WEnytRQ==",
                        "Gl+m8dYYk/bWXqzy0N6G0g==",
                        "MVE6LqNqaINHgNNUbi83JgYX/tuZ/hBOFKrGnis/Nvw=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 316,
                    Question = "KYIfBy98KMKypGnFoBzpeeIgWIwqQXPP3lOSkhQXNxWjDhKWKDj6EoJeGi2veAnF",
                    AnswerHash = 906642356,
                    RawAnswerCount = 1,
                    RawAnswer = "fsy8OfnJRVrBgnI+tqqTpA==",
                    WrongAnswers = new List<string> {
                        "yQOlgdF4novDD9F4Eostbw==",
                        "UGKvyIc4AqpE/z5WEnytRQ==",
                        "urEDhYtqU+7SnL2A09fxtY9uO2J/THg4w8r1N4WmVJQ=",
                        "wtH6uDT2w2H69nJU4LSoAb0giHtQxqNGfvLoyFDuZcI=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 317,
                    Question = "I1h3ntAsDYsZU79azn1I/SFq2Wm0wYrIuoFQ/IYzExPsZvFtrZRr9yoebVnRl4lheEOJdpn12eh7lrvgs/qtZw==",
                    AnswerHash = -1711658252,
                    RawAnswerCount = 9,
                    RawAnswer = "zdC40BwpwnrOEVjrfsWq0dDBA4x+M0DrAPhmPvx9eiqn3j6m1ZfrpiLGJEsU7R3dLcTD7mHwg8xLpfinISXRYQ==",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 318,
                    Question = "iDwWyEmF+YqDcNJ7ImOMRLm9lIHsgeD0Pj3QJCBZXjgR+gPw8EG9Ctqu7JqBbBK1",
                    AnswerHash = -1865761228,
                    RawAnswerCount = 28,
                    RawAnswer = "AF3A+sN88sM9nG7/9Fz83DPC1UMTd45tJvFjcyhNLAT678h+wbA8JYX5cA38QqViSnraB5KYVTYvnQ/SqaLZch0lVnSeyDXrXkNmCNplasrOJy3+4F4y1aOc6s/+gKOyr5VQeAyLTSSS2CeBfp3z36bujIZyw6f5e719JPOwyKscMy2dm457VL5DO98wvdz/qLIkjJOP9FQGGRHhs9Aqh9KhGZ3nTp1jUD3N6PGXJEY=",
                    WrongAnswers = null,
                    Passage = "John 1:3-4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 319,
                    Question = "NVhmNBPFCjh9QZfX3A3wiZh5EGXi+QBJ6ugeDfF8FvXCI0wPPzM6RlJy2C+KcQKjb+20BoxzojBedlhqrWDcbZ5JCkFC4vuAyvK4prg6Qb7G7rqKUazAKbAcy19scdXg",
                    AnswerHash = -310174019,
                    RawAnswerCount = 1,
                    RawAnswer = "PrsgZwppT8kXskm6FYV83A==",
                    WrongAnswers = new List<string> {
                        "s7uzYkjv+6CPZCDYOhTZzQ==",
                        "Oaf2GhLMqB/VSSCfHuDbkQ==",
                        "M+Crdb1bYSrBrMDvVCxlIA==",
                        "esIB3NmbDUV5GYN8uX6CDg==",
                        "NyaUt6SWRSyYugtHPfapDw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 320,
                    Question = "ui8eqCn3J2gB/4NrsRSbj030errBgR6ebNd0F+ldK+1tIPSBERGSioE0eOdJYz8+",
                    AnswerHash = -384294695,
                    RawAnswerCount = 12,
                    RawAnswer = "nD0lT60VwoCu0Y/BrKWs+7seJbKSfDYWOP3s2bPTH0WF5IwusGxd9bN5OWbjngSDLJjAg2R8gNGqq2FcMzAcuD1yIKpGe5tTWjyOHQUpGmc=",
                    WrongAnswers = null,
                    Passage = "Genesis 3:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 321,
                    Question = "8q4FCbYvIWaN9NlYQJQpGyoWKUz8L/5o7Kj6ev+TL+ELQUi5FyvB6Bt9eP5qqGEbvFjk3ZOYgzhF0rERzq+wAQ==",
                    AnswerHash = -308220597,
                    RawAnswerCount = 9,
                    RawAnswer = "fP8wQscuj54tLL8SUB55MQ9HvO6bCJOa3EY5aE9jrXaDi0AS2E1TQ7m6Q6z6mVbveOvuyuGVQxLrXDQGz7JQKxOITtBVtwnfs+dpF3zwGF4=",
                    WrongAnswers = null,
                    Passage = "John 12:31; Colossians 2:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 322,
                    Question = "3O6dCgen73Kbs026uzE96KsaN81G4KT6cgZgv5D/E34KnQihiW34gfb5AExOSNpY",
                    AnswerHash = 812946784,
                    RawAnswerCount = 13,
                    RawAnswer = "11YE8ekwnm6mATckm89/ExA2CVwBrtaCnoWjmvOk12RrZfLF/AtkSqL3iJRyNfUymbwcsg9Im0n/PRByLZLc+iAr1rSvl8t4G/JOg2NVyUzHhgPkxSau2PI8H2IInhms",
                    WrongAnswers = null,
                    Passage = "Genesis 12:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 323,
                    Question = "D/tEjAHYSx4gv8d3FiObmcH4cx00IelXunVCNT/H0RISqel6cpSSay7PgYCy2obk+XLXMouDX/FJvAtVDZFlcq9HjGApW5D4aYYPWyVvVPYllem48/HxbH2vDXMhhhJs",
                    AnswerHash = -675788332,
                    RawAnswerCount = 1,
                    RawAnswer = "Mij5/KPYiN2yumeLqEStWg==",
                    WrongAnswers = new List<string> {
                        "C2qdVwwaWlizLul+6Gkbzg==",
                        "G+z1laR/cUiuUy9/zYO+Bg==",
                        "PXZrNgQfJyrVWXRDaqQOEQ==",
                        "C13vGIwHOWhGWDQhpsxHgw==",
                        "HByXXwDscp49C38InE4ZJQ==",
                    },
                    Passage = "Galatians 3:16",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 324,
                    Question = "HfFe0Ib6iXK8PA7aZ7tRUYBIdZw4yutWW31d11wCfJCzTazkv3fHGbjRQZWZSq5t",
                    AnswerHash = 1330177159,
                    RawAnswerCount = 9,
                    RawAnswer = "MdZ6RucJ0jASR9U7tA0kU9cLw+IbNxTA9fTo3jIQE5SIEiq0/lRq7w2EluNgw9GZ",
                    WrongAnswers = null,
                    Passage = "John 1:1,2,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 325,
                    Question = "MbLZ8d3R72ccdAywxM4jWizyb4RY8SbftgpDwF/BMlakm+saKL46+KLUDnPnxogLsWTbSCN3/OjcB/0mgo5Kjw==",
                    AnswerHash = -138424526,
                    RawAnswerCount = 21,
                    RawAnswer = "pU6x8G6MbP27BrLUPizaEH0RuEWe938T0stk2mN0D5MMONWoVa3QmggK39QmVw+BcaE2byttYPl5ZG5zo6pnUORcWNn0ZF6907yTo/XCQgXDJrHtRMHUD2+PpbKE8wk5u1Qhbsqp5hlekAI5rFbcCw==",
                    WrongAnswers = null,
                    Passage = "John 10:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 326,
                    Question = "I6nab8OjUjM1M4SI3MMw2ZH41jdY4epYLwF2mfLJq5+p9oobFxLWO2uXzvDLiVSgN0t9uXw2id9QAk69fj3Sng==",
                    AnswerHash = 299334674,
                    RawAnswerCount = 14,
                    RawAnswer = "O+NcGTrKGfBnYbGBNTTEjDrA4nG5kmoW1ICEOuY/Mlj2PQ6BZUcbmTtDGp6qToia2an7V4RM+ldgIcYBA+TYKw==",
                    WrongAnswers = null,
                    Passage = "Luke 19:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 327,
                    Question = "goyxRfbZgd/AsqZpyxgEu3+Fr3vzYaQODlhGS9i9iQdY/IoajHlrrRfVVzl5mSV6wza4Lu1jSDUatEstTWGV8A==",
                    AnswerHash = 1798297844,
                    RawAnswerCount = 4,
                    RawAnswer = "PvyUkKEbTRwjWsvbLqosxQFisAraWPD9JcgMCbNFt3o=",
                    WrongAnswers = null,
                    Passage = "Matthew 4:4-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 328,
                    Question = "LLhPs0rNb83tmvDTcANDAY4v3obL+ccHia6xC4Yk17Zl9wMcKqMw+CEcVt54eQPZA/B6p56/pfpDo1l1W/vVBQ==",
                    AnswerHash = -1528710622,
                    RawAnswerCount = 20,
                    RawAnswer = "0BtDNy+FJy2jZf7JuFF8+Ovk/jMGpX4Qr39DN5V8IxWTJ6C2KFLjCXUonhNhSw4EZ+i7Pw6ptC13WI+4Xam+XFisNIJO7LhDVf4z4hezzI+wtRaBvR1OXZTmoqAJP2/cMF40h0vbO31ep/RFQOkjUUK5+WPXE3K3EQBrC7vR6fc=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:23; John 1:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 329,
                    Question = "7/ANByJAo4uUZfKsymC9erdn5uOuQOPjZ6ki55VxkXvjvrfTYWiSjgqYv7RD57aPBrK929mBATYH6jyaYjn7uw==",
                    AnswerHash = 1588528180,
                    RawAnswerCount = 9,
                    RawAnswer = "dtYywK7cAveaaTFlvfN/62aG/TYmNFKUXQRyJN3HQtMCtRurHD5imEca2fb4ZgSdhBQ5v1z9Ypjl8E2cHciz6Q==",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 330,
                    Question = "BY/M4RgT+lZz6T8C1k7G/me/bo98cFf7eqyOTHhBHem/y3eGe9t8AOC0lIrcb5vY",
                    AnswerHash = 1319621094,
                    RawAnswerCount = 5,
                    RawAnswer = "jIxrsAjm5lW0iKRkmDlOhDXgMDQ33IXAYEEAk6oRTOs=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 331,
                    Question = "BY/M4RgT+lZz6T8C1k7G/s/iOzE5zJ8AF41y3SBMX3VcADLnJDuJ/yNnnqhufwOT",
                    AnswerHash = 774617635,
                    RawAnswerCount = 5,
                    RawAnswer = "Rmvy5mSYCex68ArWBCTGCJ0m/iq7+5BdMJhF0+gVYlg=",
                    WrongAnswers = null,
                    Passage = "Psalm 2:2; Acts 4:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 332,
                    Question = "JebGs6Vf2TlwfLaf4pc1L5NqK4BvDYOaoiEGj8ANYq4=",
                    AnswerHash = -1651489524,
                    RawAnswerCount = 6,
                    RawAnswer = "yqblGrNjE6qfawu33ytmizK7AVie3GD9paK7VEx4QEA=",
                    WrongAnswers = null,
                    Passage = "Acts 10:38",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 333,
                    Question = "2JJQMFxZy72GSRh1UWmO8YMKFyYXtt49RJkEk35rNJhb8z/PsbQowu0yqHdX+/km5f03p/hEuKanws8jH0T9LQ==",
                    AnswerHash = 1374704379,
                    RawAnswerCount = 1,
                    RawAnswer = "XSTRcPtdjHqPodbyLXl1iA==",
                    WrongAnswers = new List<string> {
                        "9FTEgN9aMV449hslJcdQxQ==",
                        "83Tb4Xa5kZDo9g1DoesUbw==",
                        "FCx0EOCXoO8qr3+OT4TPaQ==",
                        "SN7iOVmVwjWKsDmX0L2i2w==",
                    },
                    Passage = "John 1:41",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 334,
                    Question = "pQIGZtNSmBkNtncAY2KZSml2TBRk2+RpCdVUXqaYDv0kpKgDeE8+/+9ma/QcJG29qcYu8/hAceGw4hqph5rWgg==",
                    AnswerHash = -687599069,
                    RawAnswerCount = 19,
                    RawAnswer = "rrW8usErLXM8jq0NK6cpfnOgGidlp/6YeASDwGC/0u8zNzkHMEOrEQPmWBFy78oR6FTpu1/2UTbKlW2TexcwmRBuwa4EHsLuuOknt5jkARmBHrllU9DwCKHtQo4/O0em",
                    WrongAnswers = null,
                    Passage = "Acts 1:5",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 335,
                    Question = "SjzwyaQwMHANJNJG65W5dzSw+TK5+DenXFLxQqDXOzQ1w74KhO0kzFQqr81/toLDM8WUQXYqty17etI2dKyU4++SM0vbWKzfjDhRZC05KYrv7olQPRo4faS+lEOKYimhQTyjNgUfNCGDTIaki+21hw==",
                    AnswerHash = 1120411489,
                    RawAnswerCount = 1,
                    RawAnswer = "0RAEl0CEUfIwzLPJh7pQa1nvePrlPYhRmJfFW+7P6Eo=",
                    WrongAnswers = new List<string> {
                        "C7DFf0Tnj3iQ4SIxzz4IRg==",
                        "uRDzC89FTz1ijoXbgzvXWg==",
                        "tRzkej6WluMZfgcF9+CcdA==",
                        "xiEjBEulDtsJdvXPNL5KiA==",
                    },
                    Passage = "John 10:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 336,
                    Question = "hSSiyhPILicvCTBna/MhkPeBFQNKk5n+G74ihwmBcVJUsR5Q4cn3ATR5H04co75c4rhyRLO6NVoRtVYs9Ke4xpOlQC7CQbMQltUaOWIFUa+ri9sqOS+Fj3LNZ9zD4X/k",
                    AnswerHash = -904683316,
                    RawAnswerCount = 27,
                    RawAnswer = "jz6vTwxFRlhT0PoQq9i01ChDYC+aZaSg5y7L1yG+AGYMAJegKj02F4InLkGZo/HeDALYGkQFmqsHlmsybvIHvOs6ZBjifaTEPhq+5mnSDRRS6e72QltqK2a6lT1YXzm7MjdKmVCAzchiO2EWJ0ZcJgtdyBH04/+hmguaJEc5erMG8f8LSJJmgMPR4B0NhyMv",
                    WrongAnswers = null,
                    Passage = "Hebrews 4:14,15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 337,
                    Question = "+ydnfZJVuskxlsArE/5Jn0/tpPPJio/GpA9Dpa+nQVb7Dw68Dvbzmt/dM1AYvMxI",
                    AnswerHash = -256021789,
                    RawAnswerCount = 14,
                    RawAnswer = "FfkGg6HwzC5GCjEhzZhREKzDEgCRSs8ZC22acI/SLIDPeXQ+ayc6ABlsxgYRFVZ3GhuBhv60jC1MGYDawNJiacDD15J2VHxLEAkM9ypb7gg=",
                    WrongAnswers = null,
                    Passage = "Romans 1:4; John 8:28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 338,
                    Question = "vWIvMsrFtlyZ9SIa6HQq+cM77lNiOuCoqWjNxoIHsJ8UA2zSAyA9HKRj7h5G3Mk7Q0Tu8AanaLnT4ByzAwr/cg2D8qd8Ncp6Bt6Ftq9gk0o=",
                    AnswerHash = -216878284,
                    RawAnswerCount = 12,
                    RawAnswer = "KbkBZMALfK7jl9QR+b6VETspe/cVWj16OSjXx3yOepOX4dmwI1AQfbzPUmbRwzmhYyJ6FyptAkJgk8F8RbCFNg==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 339,
                    Question = "501mPq2gwoS1o74dvlgVpSUgf0qQEG5RuB2SQQo8szOCQj3VuRIBMtxj42xo8or6mD3BI3qEVWQvAN2/CDe+OMdS6jtGGWPoH8hYrTelyuM=",
                    AnswerHash = 527944983,
                    RawAnswerCount = 1,
                    RawAnswer = "pdX+aZpnlqOlBB50nKNGxw==",
                    WrongAnswers = new List<string> {
                        "pkvoTtQnVOH13B9AEObmXg==",
                        "6VhS+3MKULfzLNlzQR5KTQ==",
                        "esIB3NmbDUV5GYN8uX6CDg==",
                        "wL7Ou87RMkBaZ6jyQQbHng==",
                        "Xt0CqmndxWNiRlKMmj3juQ==",
                    },
                    Passage = "1 Corinthians 15:6",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 340,
                    Question = "AZigyzpo1CKCe1/o1i7RniseKgUWR61mnKNV0+KVkdPYzGVU26jiVzx7KsZ4cwn2nQk3e8bs/3eVCXp8PQhpiw49C4rAadIGmCb8htwOW4Q=",
                    AnswerHash = 896863481,
                    RawAnswerCount = 1,
                    RawAnswer = "9C6ZygBX+NzjjAj9xW0BfQ==",
                    WrongAnswers = new List<string> {
                        "zd7/GyreAcDkn+g7b3ByaA==",
                        "IuFMiuFccLo6yu2Bd8iC0A==",
                        "1RPs4hxTw/uLsP4Y3vXTTQ==",
                        "2io5BQFaLLRomG4HIKXIcw==",
                        "OOlNU926tSsc5+ZkzxupFg==",
                    },
                    Passage = "Acts 1:1-3",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 341,
                    Question = "B3YQ6hhZJruDFCcX5+05fIY2B5RCXl3dkc0q9qDzTBXxaAE6U7xDwbhsAhVjOlQb",
                    AnswerHash = 258681752,
                    RawAnswerCount = 13,
                    RawAnswer = "g9bfFn1FH+LBuA5emBXWAIol5t2+OG33d0LLhyyTw3lJwFvMAMAYaWT42PgvK8MDdflEJyP/wG1TOpZabYLyr2T0ImEyuQbCzwgjgwqQWCA=",
                    WrongAnswers = null,
                    Passage = "Mark 16:19; Romans 8:34; Hebrews 7:25; 1 John 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 342,
                    Question = "YbMD/nEPh5nIVcOJl842nl5o/Cf/Aan+6CN+Iq4Z22wNgnE7XVUJezGoOhDTXKkTqrWtoob51r3ZeGMDVEscYA==",
                    AnswerHash = 59389771,
                    RawAnswerCount = 17,
                    RawAnswer = "RmkaM1xwk8ir1X7bv1ju4WOkJjZNfkWnCcD2X0S6SNJrNAZGCrbgd1hCpBtWLoKT9EdCn5xxB0oTMFV2KgNqPjpbJ9ZX6vQsOgUyNQ+0I0zSQQx0DDGb+uk1gth0Nwa1",
                    WrongAnswers = null,
                    Passage = "Revelation 22:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 343,
                    Question = "xe37Rtd863wmbpJjAnFzUJGm0rAsBnvejNymSGPpbSw=",
                    AnswerHash = 78506735,
                    RawAnswerCount = 17,
                    RawAnswer = "NFH2z326V+UbmtoaTjAcK/gC1WiO8SJ3RRE8mC9eArd9az1jdyxxM7q7b5dxocBlf7/a5AdwBWgrI2vX0mR8kDCjPV7CslHjH8pnnVBnNDt+c/XKuhPwTQ37f2I7q32c",
                    WrongAnswers = null,
                    Passage = "Genesis 2:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 344,
                    Question = "xe37Rtd863wmbpJjAnFzUJ7/v1SoBRjXE7A5A8mo6vM=",
                    AnswerHash = -540462153,
                    RawAnswerCount = 11,
                    RawAnswer = "is/0bdZNqZlL4RzW7c+hoi+ISC54NcNiXR0rM5qWTrGRUottcZM9qBdr2w/QV3ex",
                    WrongAnswers = null,
                    Passage = "Genesis 2:21,22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 345,
                    Question = "jdN+RpYwl7moB82LL7f7HvG7d7ZXD2SMM56MFuLjkuYqBSFDwUwSKNbtN3OH/hhn",
                    AnswerHash = -1034211939,
                    RawAnswerCount = 19,
                    RawAnswer = "fU9PwkG3Q7EXizmOxnEKRtAQfo5dxydiEsY6ticLYCJOOg4tuJgPR+aNCjOYcT61Unr2NHTyw/1BdLjav88/oIxd434KjEFIuj9C62h1eR9/2IyBbgGaUR3jpvt4e3VR1M0XuDSGOu9kYXzvPxWpFQ==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 346,
                    Question = "ggO383iSgPMtf8s/3R8gq5MTa6Dkyhs4ooHQzuoWaqz/vlMvZ8lRXIt75WxKMK3gPy8fJtf37KsWPKk3jGellw==",
                    AnswerHash = 619932888,
                    RawAnswerCount = 9,
                    RawAnswer = "pCmCgQP6YU8uUSHvVyGoMWRyUfB+nVc0omI+lUhAPUFU85GMe75FBahQLh58ltd7TwZKek/zI4dvYBdK4TGMBg==",
                    WrongAnswers = null,
                    Passage = "Genesis 3:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 347,
                    Question = "na0XR2R7V7wQDBF5gzXrgpAq34hLtRhyqXxdUkKayZ2q/zdTdo2q+DKbl6OdlWff",
                    AnswerHash = -508312894,
                    RawAnswerCount = 19,
                    RawAnswer = "PzYO/kuaYfm5sIjAzNmthXIs3Pprzp/dGBCIC2wEAQyRAL0b8uTMD7XhFdCIBvg/Aa0T8wrDJG95z7mSNbtRZZld/+Ff+wSVxW3JCsShP6tLzZDihSs38h5O+9zbrWce",
                    WrongAnswers = null,
                    Passage = "Romans 5:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 348,
                    Question = "tJrXeeCUUUM5Minlg0BEKvnw0T6mkxFEfH3mG6fB9zLeyPVaPeVR2cLdl/f+CwY6CK4ai3zXNpGzhIG3KVOjAw==",
                    AnswerHash = -47676077,
                    RawAnswerCount = 15,
                    RawAnswer = "dve+DnPvnlOoA6tXm/Kr6JSAZW18Cqaaw5sTJALiRFbcMvWNLUQ06RAv3qV7rK+VZkai+So9MpGSCcALeEV7ofefw7fhZ9HwogiBGILmXahsQX5HCgDGekai0CK6mBXf",
                    WrongAnswers = null,
                    Passage = "Hebrews 5:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 349,
                    Question = "a5APzby9bHzc8UnB9kvHF+zAiyRQPbmogcKJySjsiOrRRg7lWsap2SSnRSBeTT4Q",
                    AnswerHash = 1035025162,
                    RawAnswerCount = 13,
                    RawAnswer = "nPlv0WgVjBFiLJKRqfd8WPkBYixz0ojU1BuP4rCmFjqjuqy/PieJklcTbJdM0XeCWKYB+JHHL/job7EF4q/IBA==",
                    WrongAnswers = null,
                    Passage = "1 John 3:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 350,
                    Question = "dVl1VWX8QryvYN8yDpzmyCEomjKn4xkVsAjUDP490qt+XjK8iYJPDGZgGeaGaGUa",
                    AnswerHash = 1784072186,
                    RawAnswerCount = 10,
                    RawAnswer = "5XaGy57e+szdOxoOqoE2e4OSB/N0eSW9l/vqLtR3OGO5OzGKZURadzM1j52bZmBS",
                    WrongAnswers = null,
                    Passage = "James 4:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 351,
                    Question = "sLJqtBHLBZ8L+EZqJ3byMS4+7t1BUs0zAvZb9+RXz3A=",
                    AnswerHash = -802814732,
                    RawAnswerCount = 12,
                    RawAnswer = "LMA/IJ+hf8uo5G0/8/du+wPK5W2QeSA8JYNca+J7Jw9VKmK9jWOFxrTadiAqsMg+hCeT/nhqZ7Fr/WsIhjirk6KQ6buYXDeTJqxwgtaMlCg=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 352,
                    Question = "UMubUNK1vd46Cy0tXOn99E41QS0yJ9x5iQA+SjgNs3KlJCmei5v2iabPyKG/sk0bKd2d3PVBbPUxyXjr3W7obnqto0jCs4pLtGE8oA/R38ljy3xSlRtRHb4Xk/jAVgCIdOeL4PPenqWWd2+mEyDb1A==",
                    AnswerHash = -555770337,
                    RawAnswerCount = 11,
                    RawAnswer = "KWhq8JpKV1lOaAmeMR25PyQhGc9UfQexMeBUuAEvUQE4Fw+rbMHLFcmOopa/D4i3+9wZy0ce7vdAZDQ/htJlIHc3wC4Tiskq+/RjNCZOAAw=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 353,
                    Question = "028vv8AoQx0StKdl5DJBrhy2OUz9+pfdqdqnB6KUBbdAVP+qbZPJdcE5T2jwan0bYPDono8iNeQ4oJSsPHpCkMjn6/TfcrO5AfvqyxuP4RiL6x122raSQ0r4eBF75rEo",
                    AnswerHash = 1775721615,
                    RawAnswerCount = 9,
                    RawAnswer = "yDzH4b/KiI998ZE2T3BO/vPx56Rfjyoih4AYZhRjFlCNZZdLMGe7N4ZLdKa4mS+O",
                    WrongAnswers = null,
                    Passage = "Romans 8:31,32",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 354,
                    Question = "I1h3ntAsDYsZU79azn1I/ar/zTlLOkip3QoJj3x3Q4SsKm77Su4stiPJOmzWN2biFK0uhdHtwWuG9r4jZpBYVb/XADeb4+lpbQo0asIfrgOBTfBPvqqrQld0j46U4S0s",
                    AnswerHash = -93068311,
                    RawAnswerCount = 20,
                    RawAnswer = "PeVtkdeErHXUGyh58XS4fgGVPOnCtdozOR1yLK76YS7xqnrSa7lzoED/cMFIl1LC99sSjm0Fh5nVRxTxHmzzuUhjlOC0LPAnIwyz9MV5TNhq9juonS0fIVG7H+wB6FJe1jOjo4t0nYPY0DoK8GF2oQ==",
                    WrongAnswers = null,
                    Passage = "Romans 5:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 355,
                    Question = "C6//lgyogykw5TA1qZAiOy0Lx6qXst9pkITZQci0xA0oQ8vmrS2AtM9DXeFaK/uqksIPC3KLIR8K1dvkh2BZAc4hPfj+huCt5zeP0lmLDVV5Ie+FkNv++Opd4KjLenk9",
                    AnswerHash = -2123626496,
                    RawAnswerCount = 17,
                    RawAnswer = "ZKq9ktY+HyIvVnNy2I1i2Pp7DI/hnJgou6cCigfuz8OmFe2UhKqhljjwqRhdkt2OqbCHlqaAdtRSqOXjyTBGO1/tg4x9L255i7qslQTFZvHXv/GEgw0C2IRilST+aVPX",
                    WrongAnswers = null,
                    Passage = "John 3:3",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 356,
                    Question = "RIf0nCR2AnbycKnZhlENwK7K4kAzFGTiHaUqZnCA6uFWqItrSiAAXS/R2XSGcL9r",
                    AnswerHash = 553012432,
                    RawAnswerCount = 13,
                    RawAnswer = "Wz3HtusRgAjg2H9ZDP1daI57Tp40Jt02L2zAf6XYTBWEDhNmuB+SOcHKjm+QaQ0bw6y9pZaK6XzIttZuV7IWFlZO9txewuTATXszCFNgXMY=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:17; John 3:3-8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 357,
                    Question = "l91voPD5xjPWfq3MSV0ogl7/MhPwvZUCyN4l2rHzIeD90FiclmXyWA4hA62dJpXUcN6SiZwDqwQvyyGL52i4pmVPS4aklGkEMSVYhC0pKHc=",
                    AnswerHash = -1112976972,
                    RawAnswerCount = 23,
                    RawAnswer = "nOUOpgiTjA+75x3ls89PffevWsbWJw6B8RdX4SQH6tth9p1QJsPn+AXInncJ/P0swQC3A/V31ECWpApsTEjGEq8ng5/aEjBVR6iS0PVE+/aXzgfRasCMauO8RJs0CuKaVmNsdWCfho8bOLmOT7394kvZizJiHZwX6z5NK/coyI8=",
                    WrongAnswers = null,
                    Passage = "Romans 12:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 358,
                    Question = "gJL4154KKJIYyQpwP0DZX5XBPwK9F+pV0qdKJmMk1yuvr2uKZZD8kgvC1ZsNOLB0",
                    AnswerHash = -12301867,
                    RawAnswerCount = 17,
                    RawAnswer = "ATTYN4A+pRmgvUD0iG+x2VV1ZYnUagkA1cIMMMPJL0oc6VsJ0oLWDCGgIyTkF8MTZObEi4IMp7rKFASJmBh/j6lRx0GTt6ewHyLXboGDVv1eFLPm2AS1ecbL64c+Qa49OFLUbJoysytHnlZkak/CWA==",
                    WrongAnswers = null,
                    Passage = "Romans 10:9-13; 1 Timothy 2:4; 2 Peter 3:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 359,
                    Question = "Vgr9weZB2C5VT/uz0NnKL1zR6m3hRJjCe1rGmf1va63QbDCXhVJJeVQqDJ9CWThtVbSyFzpZch+NzRATeC5WYw==",
                    AnswerHash = -1541792178,
                    RawAnswerCount = 10,
                    RawAnswer = "LMkb5C58Gft/7XvTfzFCwGx1k+4ieWhYKBot15uEK2OnM4XKQEXKQDkLsUSCaV3bHkhpbrcgh7YzurXa2mLbnZsvM8xvgScacuGwOLmduwU=",
                    WrongAnswers = null,
                    Passage = "Mark 3:29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 360,
                    Question = "IwLar00kAQhDAC3NIZ2tnmHHijCqpxmCzECdN00D94rVjcYYsknMEOqhxYxCXi3bh0f887oNQza703efCis3xw==",
                    AnswerHash = -1519543212,
                    RawAnswerCount = 10,
                    RawAnswer = "E/Bj7QwVIcuFJg5NQ52jtm/wSlFlT+LNvE3Ot/WjM8d/FaizFSTFsQGMhfBWWyxDaA9mJtdWc2w2i3OEV1nYKw==",
                    WrongAnswers = null,
                    Passage = "James 4:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 361,
                    Question = "crILUs/IFiiH1CBUDGT21smmMMHHxeSYw6f5Pg4NYHStoTfq4fQ2+qNcgKXFrX5m5hMFxg4Leca3aBP7Gobz2FIMiLlt3mZnX5PSjnuAYwklns/1KMYPsdg/GP7V8JgT",
                    AnswerHash = -1436552597,
                    RawAnswerCount = 11,
                    RawAnswer = "FkEGGsHMFL8Dgm0x5HgPzwodjJP9QWnks+n8fIbjIcguRS0yDmdGk5nTV2oAQ9p7",
                    WrongAnswers = null,
                    Passage = "Luke 18:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 362,
                    Question = "LCgRWb4oliUbRJa0SOysPm0us/5JfbcD2vZzW1jY4eIMivutrxazv1Dz2vMEnZWlb4eqyhon4Jg5D4xi1vs/PYPEomYBIWukm0Ybdg1dzP0=",
                    AnswerHash = -1210885471,
                    RawAnswerCount = 21,
                    RawAnswer = "N1sq+f2954fsna4A6LT/8DaZcgHCTY3hIFkhxVIJ72oczyJm6hSOp1yTfs5EMnr42xrUOcI2MzR3N5n2YY5hbLopxUnJiaUH9n/e54CQG0gy2u77sHXKwRF0CMCot3cFZ+k9HL8qpnONlZErcm0+dA==",
                    WrongAnswers = null,
                    Passage = " Luke 15:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 363,
                    Question = "vWIvMsrFtlyZ9SIa6HQq+ROSbfcinNAagkjBeOt7Oh/wyE6zt2AKl/afbGfWL8gQwr0/6vMwkJXR2uF0c8C++Q==",
                    AnswerHash = -1867836186,
                    RawAnswerCount = 11,
                    RawAnswer = "+1RH8rOPM+03/K8eurOehG6M4WTr5IFvDLmB7wCKl4mVzdRNFY9q2ahdiNpqrutq79NT7QQlzU99AEcggRcjAQ==",
                    WrongAnswers = null,
                    Passage = "Hebrews 9:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 364,
                    Question = "na0XR2R7V7wQDBF5gzXrgtCJ/cKR4+MgdRmp8+NbJVKChozIsgglFteF5xBAyD6P",
                    AnswerHash = -900995088,
                    RawAnswerCount = 29,
                    RawAnswer = "6kD9Tvjtzeq+gSxja++XKuad+tyER+o1b8U4bysNAvEaq2J6ocmYRAjpoqIijOB2XJ/iB3W8HJUwbALP7/CM5HiIeNAXqUqmkmmurBM7ARTqMcRoi8MGtP0KKjYaAYxEtOzuBdek6De1xHgd2fJaLjpWC94b1JAtvQzSFi4qYk+kA2HvavU0CBKGwOzAV+B4",
                    WrongAnswers = null,
                    Passage = "1 Peter 2:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 365,
                    Question = "I1h3ntAsDYsZU79azn1I/bU0tm/Gqs7tdfVtQxvYrjEWnw4y4lmqIvv2kFTnhYSGCwr+2tY9vaMmTTJglUvWJ3uNC4DLC9V6MZ+JPzrOkY4=",
                    AnswerHash = 578363438,
                    RawAnswerCount = 23,
                    RawAnswer = "1y4GGuGnhmNkv6OZoyscKsKTPzUg2Jw5ljSGjNaYMd1XelG1uK+4DObvPZxF4TpBpFbxYWzBbLvNCaL5F12ntP8QPJ3d77JJ3FFz10ce6fYrTqBIqgBXOMhqFkjO9pMhghdUL4ISsrcsbCqpLnGKiQ4bhhmk6H4B684CO2pZZeY=",
                    WrongAnswers = null,
                    Passage = "Romans 1:16",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 366,
                    Question = "I1h3ntAsDYsZU79azn1I/eOWSdZNF4W9ckoJUYeVBx0JhHhutVCwVNoUjZtzfNREG0AbgIsJheWc9cuTrcGHtS8ewS3SNEXfKAZIXaanJXQ=",
                    AnswerHash = -1719109230,
                    RawAnswerCount = 22,
                    RawAnswer = "Jjbq2efscpl6cEip0TWoE/aq4XmhQwVfg2VS+1JeVsd0jk61UY/GhjZkk4qPew54Z6kDxe0hnNC0Z//Dk3HjeRKQHr00m6V9rBkUNMQuKrdkWScU/mq3AWo6ZgvGms7tNvE7JReAvLFA6N9PJYwekg==",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 367,
                    Question = "nIVoYxzIhYudIKs5+2bNAiOBb2WdEBelhip5D9STJZvbZEcqQwiVx/mxcUM5GBnARH47hTBHMDjXs7Vor6xuog==",
                    AnswerHash = -712186028,
                    RawAnswerCount = 15,
                    RawAnswer = "cRxl3ZB4L4VRXEa/i+UKNzFXngbh5c75Wk4lrI8tNqtHhDUD3nxEHrPqDdM7pdPtbmR26Ue3SzZP68aE/huJ91eXn5lSNtAMAGGdZ7NsgXhdanxvbB6fapU7R/Jn48eS",
                    WrongAnswers = null,
                    Passage = "Romans 8:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 368,
                    Question = "B+6CZVRwz1IcyhNT+eGy8l/fLnEE4E22Iob3r55xpnmIgOJXEATlzmo71AECYD9avkdUZaz+uU7k9ZLiT657x4QNqKlAOitm6GFnOFdwUXOKsZXYtekv1C7fCLlpHyEWx73d0LHGZJWSCVphbrVl5w==",
                    AnswerHash = -1911117755,
                    RawAnswerCount = 14,
                    RawAnswer = "4UDA6Ml4r9SI+lwY0vAP/UQUD6Lt5bmNAkQdl0AD5P4mXX/MdmuPYVWH2nOFcSp8Sfw2xvHbcQUUfM4A6L02fpBK0GD8G9zDUzQFo2P5mHU=",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 369,
                    Question = "KG9Xg5NbEzOWV45OBprUGCR7896rm52LiLG/Bc0iZJmM4TEC7veMOjbnrTU6Acle",
                    AnswerHash = 400686851,
                    RawAnswerCount = 18,
                    RawAnswer = "eeV2XWuytQdXiFNymdoxlST8dCsRRtBbCFZplfTEm+XKSwrGXlUhvu2N28NmUqUMmo0qhWDLwR3H57Q3T8kGERXB0HfscRwap7y1sA65H1X24kix/MHFEUItIG+FL4ba",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 13:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 370,
                    Question = "JbPrMRMTNVWmiXwWp8lONsZKcueEfijafuDoUqOfWhS+WR1lu/884uMso0MBsD5olpcZRwNaogWyj407OkaHrbbDs+inD99ZKS0HQ7YStYs=",
                    AnswerHash = -664892850,
                    RawAnswerCount = 15,
                    RawAnswer = "enjzru/G9OfTJsP0Z20u7nnx/FGJRAchM3jIrGXNN25e22Bi5osR8O8r/os7Q1FiLbDJ1mWU5oWrHLNJR7wRH31sI63qMyoQZaSx64n7/aY1umvvWGlbrXxkcWaxKFtY",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 371,
                    Question = "gnlEbtut2vVByCgvoZ0b56lEw1DZSeqzX6IB5Vts7qGd+NWpQ+yNLafSJHbifc2LkRmnHFB1B0WtHYT2UHVQieivUe/wBzjNvSDaQgZA4tE=",
                    AnswerHash = -2044806524,
                    RawAnswerCount = 21,
                    RawAnswer = "g8Xvgu3Jr/cQfELZM2qgPlBW4hvRCNmGxyKzIno0w2ImPc7HNwoIXGsqaZ1qLL3aUy4wUestp7AaV5lYoNbeoIoFIj9myMkxvRHh37K7IpdCbxJ+Ch+DYrmXYXvgGPPMePrGRXYjaGNkXxRdr1lwmQ==",
                    WrongAnswers = null,
                    Passage = "Mark 12:30",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 372,
                    Question = "gnlEbtut2vVByCgvoZ0b5+2ZwhLrfk8U48znrD16oBJ99VRvT2h7huxyiz7fdCKMnYfVPiAYydUoV8HpCDyZEQ==",
                    AnswerHash = 1234000404,
                    RawAnswerCount = 5,
                    RawAnswer = "+IfeeosVGcPSQg+64c76bSHciC5Imz56EAZ3waxU9gw=",
                    WrongAnswers = null,
                    Passage = "Mark 12:31",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 373,
                    Question = "gnlEbtut2vVByCgvoZ0b5+UzUHdt2EN3ssCBkF2FmLC9Jzyn86IGEZIHZj4RL3QjuR70OPKtKUrq06m1mmvx9w==",
                    AnswerHash = -675830216,
                    RawAnswerCount = 14,
                    RawAnswer = "cg/TxmN5I/m1ERlMx/OhJyX8Idph5T+SP5cJimdS3n6nxw6rHLYQ48MKt4SGzluMh9LpbEsW5hxFOfPpFoeQzDl0AwKh52S/u8wFBQm01Us=",
                    WrongAnswers = null,
                    Passage = "John 15:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 374,
                    Question = "pQIGZtNSmBkNtncAY2KZSiwn0Xbda6u+cwvQQxax+iFJJdyoLVhPWNwGxvU0WorW",
                    AnswerHash = -299652975,
                    RawAnswerCount = 7,
                    RawAnswer = "gMaSzU00ob9zH53edE3SJzAQDAsGJ25WHRpKn8IkzqwfaD0d9b98NcOpwET77LTk",
                    WrongAnswers = null,
                    Passage = "John 14:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 375,
                    Question = "gnlEbtut2vVByCgvoZ0b5+x+TqnYCGBMwsBvz1LakRdx6hitTTLgGrghyr6McFPbE9KAJWE+ELdti8Bs4a1pKkiXTJ7Y3lMF44FxeDHljLk=",
                    AnswerHash = -1054796732,
                    RawAnswerCount = 15,
                    RawAnswer = "ic2BOANXFAT3vLF16yD2PhFK0t5Lvo53i8agdjLnUxJ0Z2ozNjqLnjRkesrejCTKgA3rmg3i37vhMgSRIjnFIHxkWyydkLLFCaWJ8mtxLks=",
                    WrongAnswers = null,
                    Passage = "John 13:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 376,
                    Question = "+56o4w4LqZiH/v4QT6gsdgOtkT32cy5aHCIEyEa9hNRYRiJ5Dz5i+oTtMwTXnS6B",
                    AnswerHash = -365734631,
                    RawAnswerCount = 25,
                    RawAnswer = "9HBji7IRbf4OSTOkSdCiY4zTpbE2NnkC4spbf+yEOcHp4jr9KTMjWO3N/eWMFK8P4vAz5Q7xiXNc8XbJocrTTim1vfxc31HFlueoFAHfVMzXgeg+H3omEiEibVBRdJ/G6faq+hrMylCXY9F0UW/egjRxSOQ6uyVWjUxckFdd29w=",
                    WrongAnswers = null,
                    Passage = "1 John 4:7-8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 377,
                    Question = "I1h3ntAsDYsZU79azn1I/bg6XnoK+oJcnzQzM/W0smmYrjXk0LOC+WAN4BZjNGdFADHtoQdbqSuJOMpBVB7mZJGuuL2j1Kf9n2wZXCAFUBnM4vvuzpq32HCG+1KDWyBM",
                    AnswerHash = -1433195864,
                    RawAnswerCount = 25,
                    RawAnswer = "p9jZitDpSZg/Yo1QXcG5O4MLB2hS5RNlSa+7I4AFAKR5p7hXCxwjgXkR+sxqiqGZFKFTB9om9/gSlBuLZ20R7pFNQ6JbTgr9b1WtqqdS9Z/QzxsQijEmbJef1I/0mNzbPAEhu3UGCnzIeSX+UdCehnMgg5HiZDhqlxbBhsHn0OQ=",
                    WrongAnswers = null,
                    Passage = "Hebrews 12:14",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 378,
                    Question = "H1iOgn6StQeD3sqmFaMaabBUecfKdNUpCqTyh6WaKIDm87yx8cvAYOSF1WtdDbhH",
                    AnswerHash = -553897956,
                    RawAnswerCount = 13,
                    RawAnswer = "hH9am1EDlHpT+wPbav10fve4JJo1hIQicUzA+bOhFWcbXv/oRkJ1Z1CjfG8EHr7njPaG+xOGeKn176bgDy7sOKMrgfQE/kz3Z0PlZ376UTo=",
                    WrongAnswers = null,
                    Passage = "Proverbs 4:23-27; Matthew 12:34,35",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 379,
                    Question = "D8U7oa/PkgxkmsJdi5zi9QUXbmfZpZcut+6gS4q5Oi35gJOcHID8z7Vm7GFlyicQB7bzgIrOpwBPAiNWIC+U1BJyzH0Ux8HlnPn97rmm2W4=",
                    AnswerHash = 1093897843,
                    RawAnswerCount = 13,
                    RawAnswer = "v9pi7bGWw1WzjbtVVUjE1m+cqi5qPzvN7w5NzLn8+Q1GoruCABjRKDFQ3oLpZFA6g6qs/055mL+DSUkP780xekFVYV25/v2YYyQL0+bTy9Z4qWfggqgLfRJqjNWnzs7t",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 6:18-20; Hebrews 13:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 380,
                    Question = "toEytOI+z3DK+PN8lz9qEGzJWb4BOnOt9Ax+ZhGLfC5jGdsnuJNKo99JN3noQxYEFmD+OQceRmYmWJmbhqEF5g==",
                    AnswerHash = 1090259124,
                    RawAnswerCount = 19,
                    RawAnswer = "+KjKsW0skl8wOC6tOcKjYvG5P9zgPbF+bQnx2+6zCTFkybINCb5ogY3CkXmtfj8/kybpf6wp/z7xVa89KpGSW6K5uGJuba/75t1KqCeCdGIEQntxeSXG8uUG1Q+O8yzBJXE/ZI0KZaCjDw6uNtbvJw==",
                    WrongAnswers = null,
                    Passage = "James 1:22",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 381,
                    Question = "eX18lSDuFQvA1vA9JudjjStXMx872D+X9XJYyneZ/Qp16pTkbAyHwDZiIYsY1/n+",
                    AnswerHash = -1507795381,
                    RawAnswerCount = 12,
                    RawAnswer = "kKhjdNlwpLcpfrI+k5dZYrCJZSlLvGlGRBmV+vdMcV2N+eMjMHEWKvdNWPQkpqO3qoolg7kJzYEfmwQj7/+XqRMcJgQI/P6sSLAmW7EqLfs=",
                    WrongAnswers = null,
                    Passage = "Acts 17:10-12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 382,
                    Question = "kFq/KCorAEFAM/IwhSnNdQRmgi+WBumJq+Eg0ltDcbaiqo7C6PzHjuoz23HYDcBEe8jphjUUxvkP+wThC9ad4Ijqd47TprUAe+MVjbnOJ66foPppu6VyGZIVBGgsgLRH",
                    AnswerHash = 201405318,
                    RawAnswerCount = 17,
                    RawAnswer = "goKnnjlapxkpsx5/7Ka/auV5DAf7rZDXg2j2sw/+Az+7B9j+E2vEtDgYeFD5PuYYiaC4cnKVkFyPUhqDKqgRlIgXf5QpOEeuOr5jGpzHq8ltqvBbWdtLnSqHIU93Ao+D",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:18",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 383,
                    Question = "30ZxrJEHOBkLTbAfjH8tV7M2tOV5L7tWEJWvDQAPVpP5zNgDJ0aWVEdSAmeUUz4lcvKHKTSj1bGxR4tthDibfnf0/20lZ461kO8ppC/vfMw=",
                    AnswerHash = -1113455868,
                    RawAnswerCount = 1,
                    RawAnswer = "Zrs2xx7gTcIfEYbTqVVF3Q==",
                    WrongAnswers = new List<string> {
                        "2Dh3Q20xv0iWaBzhPI8VfA==",
                        "VW2z1FxFJslURXSN+LT/Mg==",
                        "9OnYLigggVi1XSpMaHpC1Q==",
                        "3fCSDW5jJDSg7XZJW9sKoQ==",
                    },
                    Passage = "Ecclesiastes 12:1",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 384,
                    Question = "7ca6BviHb52AoyPbKOFRT1yNHeiX1mGXnfg01p16ienOs5EWNUddzUmn+BkCXtuj",
                    AnswerHash = -1171919566,
                    RawAnswerCount = 7,
                    RawAnswer = "Y2/AOQdc2Z2NuYXKvZC8VIH5m8OUE7ZIUaJlOOzTDaRrEQSruGZwjgHyuhZX3hlrCylKBIKqfVdbKrwZwgGkjA==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 6:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 385,
                    Question = "F+3wKKRjhKPO2AK64cL5SVVFAbA2ZIHRdZVMvFsqFKc=",
                    AnswerHash = -1911852537,
                    RawAnswerCount = 12,
                    RawAnswer = "cZlyX5mufYkfrir/KCONfEXtKV+Ag8MDU91z2LV6F7sBnzypBSM01tYaqLuibk6lzxd3O3UIbk3Q4babjNQjxQ==",
                    WrongAnswers = null,
                    Passage = "Matthew 7:12",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 386,
                    Question = "I1h3ntAsDYsZU79azn1I/Y8mIHFDhQikgYpERSP7pjPVzRK8ZH59muchLVo3tD2LwA0kIJ8CzAOHxGdEDp9RyV5CfNml6s5a+s3lxW3zdu/XOdIVLNbwxWoBPQPeZXu8W7IAbqlaqadgfyvH1db2Lafq16ppKrXBH61xvcJZFxw=",
                    AnswerHash = 1458931593,
                    RawAnswerCount = 13,
                    RawAnswer = "ksu+fIkr+w6UvPne2jlOvPbkNDErt7Kro/Pk6pxUltP96qSOlEjSEHgXi3MCtbC79eDVwK2JAPxFTRI8HTid+dAXt1RLhHIyjrC2/0WIkls=",
                    WrongAnswers = null,
                    Passage = "Philippians 1:21",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 387,
                    Question = "rDrlMCCxw6yfJF4YfmgWIJkmrZxL8K8ieill79ZQWvbLZnsTBA8rRF//TgXDEninQXfvNOG3HVdT8Y475RXahIrrnkfx68MHBt8iBJLPWvA=",
                    AnswerHash = 1971287959,
                    RawAnswerCount = 12,
                    RawAnswer = "OMZyYu4sX8ZXOaxUhcx4E7yG+U+Jegk2E96w1kGwHVMRSXlL9ILd49LjNccS14/nCI4QtQH3MICp/XJTyXYSog4eXyyOlL5XfO7GWvsKVV0=",
                    WrongAnswers = null,
                    Passage = "Proverbs 15:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 388,
                    Question = "ygJgIkn4jzVgfii/q8uBVRa6xoYuePLpcT1+kXS9ZggtFJx3eNIGx3jRC2wIerpxusnBg81bfF3wExKaVc8eXt7Ssi85WBCdLv7C0rXLcV0Gy7R82ck3K3FkhVH0aNAX",
                    AnswerHash = 1054357920,
                    RawAnswerCount = 10,
                    RawAnswer = "bPDHouCvS+9BYuGfEL4l+Ig4FvrsTYIhUbj6uu/DxGB5NnF0Nk3nHc0+Fwd71JtdT8KirJvZ+Mf1QwTrL/eclg==",
                    WrongAnswers = null,
                    Passage = "Romans 13:1,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 389,
                    Question = "ygJgIkn4jzVgfii/q8uBVQ2W5wBCDV+Y02TkRzpZOUd5Uj/ItVLhQiuUfD1/9ZzmxekrlUayWdNL10ChBIinrxePNGfF6t4sqHyi6bu1C6qSUyHD7VFReA4Fh/qzHgJd",
                    AnswerHash = -1267326324,
                    RawAnswerCount = 13,
                    RawAnswer = "bPDHouCvS+9BYuGfEL4l+PzZiii4EO3j/NvPFvSGp5HC2JMqrnLZynDd/EuCJDz/3tKT9+Fo2nZg4P6T4NaGD2pj7RthP/GOi+6DFQyIHNs=",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 390,
                    Question = "3Yzf5dlwODpx1vAd2D3DXUSAhDSdnC86npUCmFZiFp0=",
                    AnswerHash = 973636875,
                    RawAnswerCount = 7,
                    RawAnswer = "tC+IK+Usf/lSqtZVw91DOUtP0Z/iHDxdoBst3kFZa7A=",
                    WrongAnswers = null,
                    Passage = "1 Timothy 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 391,
                    Question = "ujmj8nk/hQNJO2+n+WqUjwG+jj1CPt6rMyNA64pJA08/BNZFl7c3i9//4lk+T6GQ",
                    AnswerHash = -337788814,
                    RawAnswerCount = 1,
                    RawAnswer = "EI8YydvFlz73eQDJM90NuKD1C+wg2q4OpEG1edzCN18=",
                    WrongAnswers = new List<string> {
                        "yNY54max7iKQSI4CRi/OvQ==",
                        "EyJkFsEK8G89eVukp6ckUw==",
                        "Mx0CKZeTJwCLqylJ39QRfQ==",
                        "gArbFciuKAY1AGx7lm8rlQ==",
                    },
                    Passage = "Mark 16:19; Romans 8:26,27,34; Hebrews 7:25",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 392,
                    Question = "qChaipw+iFEB5Jcaz+SarvB7LpJmlQMsRq15PZtO5KuiRh36VwBHgg1H4Br2yCrr1sIf2GwqmVeoFxAur4Ix1g==",
                    AnswerHash = -562140670,
                    RawAnswerCount = 10,
                    RawAnswer = "KWSg64ajD4Vtymz2MFOPwvct4HAejkHADFy6D8ggdK8et81jMIoS1SEThxEOl7DD",
                    WrongAnswers = null,
                    Passage = "Romans 8:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 393,
                    Question = "D8U7oa/PkgxkmsJdi5zi9Xzde5an8LJNdFD9jwx7jKMPxQwPfn2qYhEm8CqBPkmMkg3/UsnOiabyRMuRlDt0wezX/X92vM1rLhz+Ru5iU1E=",
                    AnswerHash = 1735206935,
                    RawAnswerCount = 13,
                    RawAnswer = "xo9H9F5aTEWHuM9xRJLK5WeIdUAbB6qNVGkE7zkxUQlI09ilaNH91E+ONmWmgaR01WBrAA53dcO3yU1NV+oYkKhWUr/tMSlZ8aKQPAqi7pE=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 6:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 394,
                    Question = "2s+fiBh+j7wkbs6sSsOFc0ksEZssYuGkCUNi2cBea/8=",
                    AnswerHash = 1790542010,
                    RawAnswerCount = 10,
                    RawAnswer = "9aW7MStI5lL/Sun/dPVtHo9O3dBUirDtCPKDM1hvIlqKTYllpAhSwWrUdsekx+w2",
                    WrongAnswers = null,
                    Passage = "James 1:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 395,
                    Question = "kFq/KCorAEFAM/IwhSnNdeUf43Mj5DROoRKKU4ldsF3jSLpDuagWkVW9L6UQc7K9KUiaQgnDV//GpgoiiFMiPg==",
                    AnswerHash = 408018620,
                    RawAnswerCount = 15,
                    RawAnswer = "ZbeWQmqVrRQ+YcLsAhS0CBGawltWc6cHtps7HIzrN4kIV8YqdZ6671f8TZ3bgm15dk2fprsCeGrqi/iqEBhn6qW1tILuHzLCjSpl/063NfnYfd+Y/SmkiaDkZRaOJnYlQ3O63m9Dvjyyxsr0EeoiVQ==",
                    WrongAnswers = null,
                    Passage = "1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 396,
                    Question = "KG9Xg5NbEzOWV45OBprUGNdnSnNt+t/kY3A+oayAnklUVyGNunZ13xYCfeo27aGX",
                    AnswerHash = -2062883674,
                    RawAnswerCount = 7,
                    RawAnswer = "jbsRkEbY8zHL3gl2Ndofw2hYAxHOQ82pTtCUpAD8foKrpAazBhGqdN2KIkr6xhKc",
                    WrongAnswers = null,
                    Passage = "Matthew 4:1; John 16:33; James 1:14; 1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 397,
                    Question = "aYYcJP0ORABf1B+4FA1izPdhqB+QoTkBs0nzXGL+4TVy/95ZcDgDutbFNJmrbwL5",
                    AnswerHash = 1736003710,
                    RawAnswerCount = 11,
                    RawAnswer = "Q3cMNcqxLV9TF+JBy9Dnc1oGojJvc3k/j+BlXt9Hz63a8R5xADNUGPWmmSuHu9viggNkFZvvZBeQex5/weqMAw==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 398,
                    Question = "/yQ2ZJE8zqH2WkZJgFbzaieHex8Q7zAT0Ak1UfS1mrBJIkcIKAzQajrxYZgW2cgganJln27qDd34U5o7pjL3lUp8qX/2ewNAcgWvPAJ4ph6+zkM9vjuxqcJA+hUz/Xfv",
                    AnswerHash = -1305855632,
                    RawAnswerCount = 1,
                    RawAnswer = "rMqgPCZCXIlgMlO2qOKWD2LbNeAJ3Y2fw9YCRHj4TMk=",
                    WrongAnswers = new List<string> {
                        "87ywhQXiEJmNV4Zkr4VuK24J1HsPH0XLglUJtk/Rblo=",
                        "nF/X6p/x7Af9piXRy4+Qu01LfQKP4AtzHHG2bm9teyY=",
                        "6D2UKfSrstAc4EYu/FD1hGOWxIaLQnKsm2S4Yvikx5o=",
                        "kmHqxFVeJB2ch8RAbcHtc8XemNGQkG5oap8QTDlBii4=",
                    },
                    Passage = "John 16:8-11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 399,
                    Question = "VXob9yFoD+glSmkxnpSwmZvhQ1Fqca/k6mE5E2gyUgc5FJbDVe7Mct1de489+B5/BgcDv8U00pliXe6P5lSBWQ==",
                    AnswerHash = 318403258,
                    RawAnswerCount = 8,
                    RawAnswer = "fCaPpHtXKaG2zgh1147nCVtg6QWr9FgbeZY84w8p10MfSIhl6vOjqfSv83YhDhIq",
                    WrongAnswers = null,
                    Passage = "John 16:8,9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 400,
                    Question = "iqmw90kgRbe4sjYObR/KpuU+aVVOEYQ8yoNXINRiayTswVECx7QY/1bVn0Re2hI5",
                    AnswerHash = -977883019,
                    RawAnswerCount = 1,
                    RawAnswer = "N4Z/qgOfn/8YGioZ+WiVqA==",
                    WrongAnswers = new List<string> {
                        "8Z9ltyfWi3EVlU/KwZqIEw==",
                        "dOg1eqfoA7OxLLHl2DE86Q==",
                        "G+z1laR/cUiuUy9/zYO+Bg==",
                        "HJV0nDPq5oTmXnQ2+WdjCA==",
                    },
                    Passage = "John 16:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 401,
                    Question = "1j0SkhsStvbldnszK/xZ6bDvHkh/YVET5IfQjpKQ5WMVPeDY2cf55eYL9FV+Azp4mdIsGAcON3V9whI8ok4OWmna02ohKuBvqL1DRPWRb9g=",
                    AnswerHash = -1458823650,
                    RawAnswerCount = 19,
                    RawAnswer = "jihlSyF3aVTQsMQMM9qtZbzD2wkRK04Fp9PMEvrpTTNPX97jYoKRv8AmTjFsB2jNu6eceenKuPd4ZCkFsj+QNnuLJNq5Dk5tQl6qDZew9aTvOXk+bGWHBUgQcuhcFGAAVlgocVeTIhBYSZvYHyr3Lw==",
                    WrongAnswers = null,
                    Passage = "Galatians 5:22,23; Romans 8:5,6,13; Acts 1:8; Ephesians 1:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 402,
                    Question = "EI8YydvFlz73eQDJM90NuGCiqa9QHwu5ehOAVcpf8Ya0AEKlIVCd9dQp+UNy1Dqr",
                    AnswerHash = -1664286573,
                    RawAnswerCount = 1,
                    RawAnswer = "MNvkT1YWvpw+eUzbkj8v9Q==",
                    WrongAnswers = new List<string> {
                        "diJcyBiUMd0iw14zBqxBNQ==",
                        "PIfLK6eH2nY4fLWPPNDQjA==",
                        "4wiSfoGQvK2oRkhRdA2hkw==",
                        "hi4PNpwmLnLapeRgQGqNFw==",
                    },
                    Passage = "John 16:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 403,
                    Question = "fG/NLx/l23wsXqUyCmD+lagTNr/jsHIxbixxBA59uxhg5BsX0yzq81eQl9r9BwSrqtVEP4/WpphzkRi/QuwUyQ==",
                    AnswerHash = 2080193635,
                    RawAnswerCount = 14,
                    RawAnswer = "Wz3HtusRgAjg2H9ZDP1daJ0E0qwQRJY0seN3wmJl2DO2SVuQGxzZZNlaPwoupSBIOFgJtjrgdvtHs9wGzOe7Me7GHiDOXxycRQ7G3Rx/s+Q=",
                    WrongAnswers = null,
                    Passage = "Titus 3:5; John 16:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 404,
                    Question = "bnnU8y9hNHmQrbIHqinW5gtIgcO8/gUNKHg0E1Ur8WZujPnd5873x28MaM0rUEHw",
                    AnswerHash = 1514300086,
                    RawAnswerCount = 13,
                    RawAnswer = "NptdijkXUHxSIq4ngs176GdYcmpuUvAigIPiuxeaf7tWCOZQHqux11FGD4uqpvdFjYck6NXWXJgVm9kobMYl+Um7ApNwB+i90lYfzWflj2U=",
                    WrongAnswers = null,
                    Passage = "Romans 8:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 405,
                    Question = "7ca6BviHb52AoyPbKOFRTzOJga+5AnvvF3JIjbbpmmHRJkdytLxKqt+DHnxumg00ydsDxf8lrVTPsRUSiLklIeVS0ywsZUUmdfvgPl3QAXM=",
                    AnswerHash = -1017429494,
                    RawAnswerCount = 6,
                    RawAnswer = "Rjrmh7Ovde07+lvAO31cqUvkynY0cdF4DPZwAX1VbOuidYFyu/o+qldM0i6gy+Hu",
                    WrongAnswers = null,
                    Passage = "Ephesians 1:13,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 406,
                    Question = "6hD+cyneNWUkE8zwkRr/yawEdOkyyah2DhOptIqBV6h/E33R7JyepUMl+tO55k+V4QRpnr/FOUhpS0rRRUY8Cg==",
                    AnswerHash = -508291672,
                    RawAnswerCount = 8,
                    RawAnswer = "fPRl5KFTSPVrg+AW4IO+BuaTKPQGCqFjSbfLkTIPrFbsJNDCPlgXhY5mPFyZlM8o",
                    WrongAnswers = null,
                    Passage = "John 16:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 407,
                    Question = "Vk+chShlGGmfy+IjbQw8+7213VWb7barxoM0qhM/DzzSA6nZb3uVx4UdqXkUVjydFbJ3wN/BeRIJfZ+avJq/6A==",
                    AnswerHash = -940945247,
                    RawAnswerCount = 15,
                    RawAnswer = "zWreJRLUmT9Na2WasS2TdKLuyPOVhkpDeUXkzonbI8VS4idzPqTXYRM5zxFsGZLvUF5HN8PVj0MT1olrjwkj6lC3hSYV5g3GEnXhQS9KTYU=",
                    WrongAnswers = null,
                    Passage = "Zechariah 4:6",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 408,
                    Question = "kYs+cZbPkPFt8EOb9XJfRUNYXv51p3PYG68wsrBsjXcgdzzTQOV5v4j2wHZAGm5SKaFKec16O5uA4clHhP6F4A==",
                    AnswerHash = 1381088291,
                    RawAnswerCount = 1,
                    RawAnswer = "qYkcnxeQ7gTg3Qvq89ZKgdUqR4ir8KBap2h2WS+2UKA=",
                    WrongAnswers = new List<string> {
                        "/s8k6K+udRZG68y0BgUH8/Cs2k0uYiOF4XLZwKYxRCo=",
                        "MlstIv3ZCwTyx69M64qYaQ==",
                        "5X9IEaUk72YyGhGR1G6/Gg==",
                        "wgpT0NXHCbhF/ra6RTZIfQ==",
                    },
                    Passage = "Acts 2:1-4",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 409,
                    Question = "I1h3ntAsDYsZU79azn1I/QCyfNQugIbgmywWQwWE7eLHDBehyI8OF0L3OwpRRoXELUm7y74mylRqqv0AiyZg6dPxLNv/vuAGP1be0+mJvo2dF5OXZVTnnROGZO10iXT41O9Vu/xBCV6DjlfEti+CvQHSVJpNBR9aRes5LrjmhaQ=",
                    AnswerHash = 460207822,
                    RawAnswerCount = 23,
                    RawAnswer = "HhDI5DLRMli9P3LfoYbgHDVFg81DloALZMKHPrV2FjE7TTvL6TjioRYoEEhOafPQHxOMHdR2/xgxHpq3rGSYHzMHBw0qUrfAFNlByTNW4hd0Ih+WABivP6hsU4L4ASQMY0pGWxFT2lPpUdaJAu0WR+kZBZkbImYg+sVNYx92McBkQuqG0dzPixljWeon3S64",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 410,
                    Question = "ZotNuJlnSpFtzIaBViOGNukZ9lmwi4ElZB2LZrJXRIYmjQHKSuWdKHeWoYwQPRWgyQuRGZ5u5n1vw52NA1ZVD77GzrpnPJnSI4iL08ZY1tBxAivp9HCGDUg0KOC0Ixb+",
                    AnswerHash = -1738484229,
                    RawAnswerCount = 1,
                    RawAnswer = "WNs0V72jCz3O3KSAjAC9JwA+lY8FtJA0JTFfMI05Myw=",
                    WrongAnswers = new List<string> {
                        "bSMGFSAPXp69Rsd1pfoNBcrJa9ooq027AHlsADxjOXM=",
                        "c/W2WUEZUS7OnTs2cK1rIctx5Tgx8WuBjN4cMqWS/Q4=",
                        "CuXwYf7ROzmbIRdRGScGoQmTXue98+RabM27N+d8Nts=",
                        "q6+3/1X6tQcbUBfxm1i59KY+a2KLjik7UhfVIzWPz+o=",
                    },
                    Passage = "Acts 1:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 411,
                    Question = "3PtMNSgoDbv7mr218nqBTMGYnahDsTHOh3X7n1KPamVd2V1cfd3648X+Z3JbtSfjK/OU0KmsSoSt3nuoAa9KTcLh4DdaWsZ0RO44mBYRIyWHY0x/qKRkEDQ6IG68kK34cfEjmUp/GuUYcsfK3eCLVQ==",
                    AnswerHash = -2089146781,
                    RawAnswerCount = 37,
                    RawAnswer = "IZ9LACdbS9pSl7z/Vm0yfb2js0Nk22ndNvV/Y7IUvymkU2Rgip/k0570UU+xHSR0Zot/Ag9rH2BIijd34UE3b0ZTCJVJ5/NL7HtVF6r6DeEsfeP09yiiqDitUo2yUKj1wKdzOHx03cbi8hOsxssntAutoL7j8tgPeZn/MU4HzHpb5ucPOdyqctTxQw2tNcJDGkQHqj543h55NYoYVnbpd7F6u07+yX8OxkULetgTsuhhBfzIubbIGrVs02GeKECf",
                    WrongAnswers = null,
                    Passage = "Acts 2:38",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 412,
                    Question = "kgRbWbDCOC1W5T5sP6eKb3LdAIqkM9zgdQw8N+MihIiivVFKGuI3cLklspWReaq/hz4ox7EgXKtE+fTrvNiSPA==",
                    AnswerHash = 1654753539,
                    RawAnswerCount = 16,
                    RawAnswer = "5YcZ51rxs+ciSut/rfyoTCkL4z59trJilxxJeBRzGe6x3Em3SfMk6TIqMXRtYl7aAf5NFPPhnc9fdEcWusE5XmN8zFoZKCWgd4PCuCOt+4/4c6n0RPCEViLGbmSrPX1voCOjtsZsuTRM4eS+rvHk4Q==",
                    WrongAnswers = null,
                    Passage = "Acts 19:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 413,
                    Question = "zJubu7QYLwwJgg3nP4dlMVQrhaMw6Z2UPgNHP0Xe57wHUlnduN9GS6MTb4zBbSrFd0IwX2RGiJOUYaLEwyyNew==",
                    AnswerHash = 495527379,
                    RawAnswerCount = 20,
                    RawAnswer = "nNtbQxkxnyBOgLfihXgjvJ4TLq0WHhu+OyevQAAj1WF3uOFdp4uvu2IU9CvmSLuNpkPn1zfUSLzoTtjDfTuZ6PWIcietWllR7PgV6Pm0jb1MRcyPzuy29uiBtZCOSAkZqRukFJjW4Q4VTNFMRxXh+Q==",
                    WrongAnswers = null,
                    Passage = "John 15:26; 16:13; Acts 1:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 414,
                    Question = "wvSBCCA4BOVDR/xSOgsYywEtrVzDVRPEHRixJnjoVsOB38G0QVcGNdquhBbW7Cf7YulGGsZwiAxXu7UQC3bo3VrjIlZg3BX6jnAsYNlxhww=",
                    AnswerHash = -1219638378,
                    RawAnswerCount = 10,
                    RawAnswer = "Lvs36JXNwB95EhoqK7X8OJx/VoSlHSWjO8n3kYeqb22mzGFklIcGMuN+HXPJ5AVLF5rB39HOCmoUzVg3LKAtmTChDUJkUZK1rqtStHW2FVg=",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 415,
                    Question = "daBaeVm5afMK9PHpJM3MEVyT0G6IdHsCVxqFOdmXeGAxfykB+LFZpkXlfDoBOb1HIIgJ0x3RHR7VDaIEhQ7fbt4L7kXRlhm17qjd9xYuUefGWBlqY/wE2tbFcsbRkByx7KXrB3/dHc9kOYsGYgiJ3zG7a+aul6+uk/1q5Evx4bw=",
                    AnswerHash = 1033399963,
                    RawAnswerCount = 10,
                    RawAnswer = "bFB/uQZCDaYSt+OZmLvEZ8Bt89DmtXyc4yNBBUu+4nhnsUFjmK9r3EgY9IwZYMZzgBN43P8HjuQUuq7Zymp+OA==",
                    WrongAnswers = null,
                    Passage = "Acts 2:4; 8:14-21; 9:17; 10:46; 19:6; 1 Corinthians 14:18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 416,
                    Question = "7ckIkXNh2h+r0c8KexECfLaJUTDWNJLszLxmQeJc+ck=",
                    AnswerHash = -893927363,
                    RawAnswerCount = 26,
                    RawAnswer = "m+R1jYr1vP1sqPy4YRSgvpRRarNn9bvehVdw9SyUJLKXLsAB3Luvh/7P010e3vygUUBI/HVLDrD40oh+j49lK595C4JcpNIgTIgeyZvKO3k5mvfl9n2+41rw35jTlUHaF+WybLTTDPTx5dmZ1pA+BAdccTMWVxnRQ9UXOqhUVD3k08b0jmM0qx32kxWVWHAl",
                    WrongAnswers = null,
                    Passage = "Colossians 1:18-24; 1 Peter 2:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 417,
                    Question = "QRneZP2iRMboVZJcstNiDy8/X2nz4mgOIbUGIKws1EvYfsT7A61Me2tUGZ3WiXPIMUOU1e/dN9xpxHNNUBT4Lw==",
                    AnswerHash = 1497028323,
                    RawAnswerCount = 13,
                    RawAnswer = "D9WUTdAku0ui2VYoccuwgcHyRT47hG7KuE79Wcf80HRgpSgdOHy+nGqo17vI02dupSJNlsKFiacCo5vmkhOoTFCc+jkPJay6OtKC4fAyJ9s=",
                    WrongAnswers = null,
                    Passage = "Romans 14:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 418,
                    Question = "KQi/Z/NGpamg6ojQqGdzSFvwN8eJSMHNo5J6rLjxAA4=",
                    AnswerHash = -977883019,
                    RawAnswerCount = 1,
                    RawAnswer = "N4Z/qgOfn/8YGioZ+WiVqA==",
                    WrongAnswers = new List<string> {
                        "dOg1eqfoA7OxLLHl2DE86Q==",
                        "G+z1laR/cUiuUy9/zYO+Bg==",
                        "bJhJb6G+eibTKOtRaj+Z0A==",
                        "8Z9ltyfWi3EVlU/KwZqIEw==",
                    },
                    Passage = "Ephesians 4:15",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 419,
                    Question = "iK6nDV+Kl8fdRYidetx2JLykiglrNkVOyxllscLFq+0B/45FFChCG2RRSDUxo35Y",
                    AnswerHash = -52958954,
                    RawAnswerCount = 1,
                    RawAnswer = "9CJDoz/9/vStrZu+kJkwOw==",
                    WrongAnswers = new List<string> {
                        "F7ruuAS2O8VO0YPPZTAwFA==",
                        "G+z1laR/cUiuUy9/zYO+Bg==",
                        "dOg1eqfoA7OxLLHl2DE86Q==",
                        "bJhJb6G+eibTKOtRaj+Z0A==",
                    },
                    Passage = "1 Corinthians 3:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 420,
                    Question = "fqnaT05XlC6H1nAtnZ3BHGVl2RqGPKKacxMgngh/JuCc6coG+51p9LGQg8Ek12SfPfmmq87kMrwohieVeNnTRgsOGmoohKHYy6dO0XCV1u8=",
                    AnswerHash = 1324780110,
                    RawAnswerCount = 25,
                    RawAnswer = "oTmNfdLU8QYe6AyCWT0BKZSMADQTItSoVj5nuTfOjEUWc0e0l5JlsK9rM4obqI4SwqRNqx+aY6qT5+nOZFFgPjnkATFuqDXlwO7KV6qujDFIxQzpyth+zaJ1LFD5yz7Gl6T9L9v0vsvS/ydx7zJBpFxLINVHXNb2Fsv9FbwJ+x0=",
                    WrongAnswers = null,
                    Passage = "Jeremiah 1:4-5",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 421,
                    Question = "nhtvpJEfnBSztjVs4rZtGD0AeITls7tBp1VI4x0vBn1WEKQwhAGrCvLr9lBlRDNEsjNoGjmIEciiYGzCsON6IqTYHBNyAkourihGArtyMEI=",
                    AnswerHash = 61158700,
                    RawAnswerCount = 1,
                    RawAnswer = "pCzalf84MmmlMSC9cuOkUKhnfl2C0oNxDYOhaY9iWmw=",
                    WrongAnswers = new List<string> {
                        "03pxbeWbXwMswHMld4Yz91Cwrkay+OxWFDhfsXqL2ho=",
                        "7sInoe/167HnpvzxQTWp2mmvdMMKOu8DU+Jr6a5fI6E=",
                        "YV1lkH/lA+iRdEn3LiYoJYb0iZq1vgouZ/QvBCoSoro=",
                        "axM9rOQivRtsE/oaylsaTmhZgPVrgJmP0dkJk5fDag0=",
                    },
                    Passage = "1 Corinthians 3:9; 2 Corinthians 11:2, Ephesians 2:16, 20-21; 5:25-27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 422,
                    Question = "+DHgyYMmbLyWDT3obEfpBXZPyxrk4uurLGc9SNJkk4M=",
                    AnswerHash = -977883019,
                    RawAnswerCount = 1,
                    RawAnswer = "N4Z/qgOfn/8YGioZ+WiVqA==",
                    WrongAnswers = new List<string> {
                        "G+z1laR/cUiuUy9/zYO+Bg==",
                        "ORQYx/pRlRJfF2AZHzgGVw==",
                        "lA25hvnM5Vz6my1pGk7puQ==",
                        "DzTkq1AcbT9zjVE4BS61Fw==",
                    },
                    Passage = "Matthew 16:18",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 423,
                    Question = "2ph7Db74OugK+XXcLWbLheD11kYNkq3ZsejfCL9QQhq2BOWx66EqBPXHWIIhBwOi",
                    AnswerHash = 73762437,
                    RawAnswerCount = 21,
                    RawAnswer = "Z1sYMQlrgqe44MLJcfhRiROfwP5yPhWXd9vWXIwGS3m8Cpg/7hag6txudvpYesarZT9cz8gQTFI59jMJee5er8zPJHUep7exhyKLTr/3XlCjHPksQoPiYC+Iq8BEfNuomZ3FyS/SOmzJZoAw/mce4g==",
                    WrongAnswers = null,
                    Passage = "Matthew 18:19",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 424,
                    Question = "mqmTAkNdKkz/Et6lC6tjGwQG7/lgDvRBMrxjvDbpXhel0QjvZyKWEm68scv0zhGA",
                    AnswerHash = -750205692,
                    RawAnswerCount = 12,
                    RawAnswer = "mO/5CrbYylzztt2iHmlAPFiQhO85TM4jxBF8WVuQesEPi96HvAraPKThwY+dkwl4KPQGC9igkKpVbW2jn5Oxrg==",
                    WrongAnswers = null,
                    Passage = "Mark 16:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 425,
                    Question = "E89YIWaUSHLgCrXnJwzaIQvitFO6VozQ9vCyki30J6B89AKoH5S/POoPqDupn6j9jnZVURzvKo0BhmVUz7zjWGLigiFSzCQxQFAmadMrwDk=",
                    AnswerHash = 723030445,
                    RawAnswerCount = 1,
                    RawAnswer = "azkZAXurAcX0ohqxA7hvnTgyOZIcYd/TGQkeaNxLFXo=",
                    WrongAnswers = new List<string> {
                        "I4PuwtqLQdTHDiM6pYXkJeebiFlcJDwOR05LoTJnFCE=",
                        "OCWgoLT5V3ToCsGKmE+vB2odKXg1l0YHNEX3YqTOP4s=",
                        "Ft+shn9IXjWRc+VhLpeXdg==",
                        "yu/XKp2Yo+Ao6eyfT/xcFlIvR1bF2ln7y8tZHadhguk=",
                    },
                    Passage = "Matthew 21:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 426,
                    Question = "Amibcvx6EM6wdqI+0QehvkWi+ICSxMH2/PKAwamKcFCbq/yWrO4EiCgRMM/MIJun",
                    AnswerHash = 1771264818,
                    RawAnswerCount = 9,
                    RawAnswer = "GVAhhAG8eK9rtDoQBgMTqsupxwZGC/PHz6bxqsd0GtsUeb/P8hkLJ0MJiKijTHm/",
                    WrongAnswers = null,
                    Passage = "Ephesians 4:11-13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 427,
                    Question = "OwUc4zVMadVVWG6rH/+WC0b4tg2oT1rcPG9+5c7lwb9BQ+5rrJbLsoGBlyoP/4sb",
                    AnswerHash = 1151558701,
                    RawAnswerCount = 20,
                    RawAnswer = "yBPuNc9rZARRRePM4OuMCr9hywXJLNXBl3Nrs/rOec4QjQaYLHaauY8I+0VBdy8Cb4h3TzE69DgE9Iz4hlW6RHUYieBzSC6nQimaI13HbLSa/GvTkWDS3kz+1+SN5fwX9SbzdKuQGd510uJA1lRZXg==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 1:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 428,
                    Question = "pTLhO0xAtT9bxIkDpqefQFFSTRgaZV5C5/chA2tPKgeGHuE23GrHpdqt2mpszs9Z",
                    AnswerHash = 331021888,
                    RawAnswerCount = 10,
                    RawAnswer = "gLluSR55Z+Ao19zg4EhFh+NDBkppmGjWnx2n0k8vW3SdbV9aX4CvaC6m9h75FkVTD3+Go5COz9B3VrDFvTivNw==",
                    WrongAnswers = null,
                    Passage = "Malachi 3:10; 1 Corinthians 16:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 429,
                    Question = "0ln2WfdPPamuo5gq/lG22CIE6v37iEEht9E6h9SJTV8=",
                    AnswerHash = -1957983816,
                    RawAnswerCount = 19,
                    RawAnswer = "C4TmkWPS9EB1aUZK7o/6FWcgiQUfhMNYNNbgOc8Mi7Cvk0g2lM+jAVGZe3xxKGSr+eczkAC4++YjMf+BDW0vKiuKHsRUcP4k+9VOqCwtH9i4bDY3zCNEChnZNe0ejKSyAXId2ihYfNgPLfncCydkrA==",
                    WrongAnswers = null,
                    Passage = "Leviticus 27:30-32; Malachi 3:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 430,
                    Question = "KHw2dWDmpgqLueXdmEbiuz26Xcy7fEY9Wc1bYl7PxEYNLdUEGPg/6fwdVvvMqBvPXRquzC24NFi4WVbggSQpHi32qKV5xKFU1KHu/Jz45gfVo5u5n9X6iv2V2TBm72qO",
                    AnswerHash = -59660337,
                    RawAnswerCount = 1,
                    RawAnswer = "n2cfjRLalESrXIAHF3n+xHj9wnxs0sm9m7n/0CrHJ1CnkKZTKSxnrg1HP5uRynAb",
                    WrongAnswers = new List<string> {
                        "78MDNR5Pko2UE6s0LucWK3tfH3R914ctmpdfG/kxMiU=",
                        "IIR8jngfoNJnPnmBp0Wb4qVP7OTkv2gG5x54jLo0j3A=",
                        "HTI5UNWBRvzmj0fvoM4DSUfeuRSqrrX6Qx5AOsyR4A4=",
                        "nCFqeCx1gjFYWgfG/XTMwRi38Fb1TaUmbM654yX8Ebs=",
                    },
                    Passage = "Genesis 14:18-20",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 431,
                    Question = "qvuIL5oPZS6h3vEIH45U4cG8xFWl3mdcdszxUKj9j8k=",
                    AnswerHash = -1681282053,
                    RawAnswerCount = 13,
                    RawAnswer = "2soSd9rvaLXBMM1ky3QOT1aNN1uMbXKHeasFCpCd4QD50X27IfMQJiYGp9EAuzJgRd1f1O2UcBLlhxCokuAZQSOgezFUuDHqy3ZIMhY+6Zk=",
                    WrongAnswers = null,
                    Passage = "Malachi 3:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 432,
                    Question = "DsLJnx7b+CpElCQfEij5W3dk73kt+QRBJfyUTtB/hRTamsUjRnIQnuomAfD2+KMuInE0HnFWRa7C/fSc/oDI+g==",
                    AnswerHash = -1779707865,
                    RawAnswerCount = 15,
                    RawAnswer = "KPOmUaA5qHLNz9MZAWTsiR2IwYHgV3ry4LR5Sfo8zwk5qSfxKozHriK1Xl+YygMJhFK1/evves1XLNZmqda9WtKaaiexm+9Ja9i49JbuUKRDBerdT7MrbQ1zXu6V77Fd",
                    WrongAnswers = null,
                    Passage = "Colossians 2:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 433,
                    Question = "d4v2SmYpkc6aq/OyBcEZSGcS+sczNciAYsAaNw0NrWFj24vtuGtA4YWdkQ16JniV",
                    AnswerHash = 449410135,
                    RawAnswerCount = 1,
                    RawAnswer = "VNbJtjjh9E6S7O3xKpZ/0F78twNKHLyUht6VckKrlwo=",
                    WrongAnswers = new List<string> {
                        "5sZOzDiXFy8tp6TUbmAW0Pv8Ob7dK77pF4E1Leg9Dcw=",
                        "kYImNiMujvuSbrQab6e1SnhHclPMHjg/peiBaJ1sRME=",
                        "OXOml4kfBhsz4iYSANaGBFEEyQ/dpxitwtNPKbJZ7s8=",
                        "I1KNHHCUUXnbY1mzrIAL9wTkD3UanSxW3TarS6pExNs=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 434,
                    Question = "wr8jO4tiKWT78cH8+AszQ8BHr2fXo8ZWX1pgaApYL3EKjZg4C2KGwgf3to50gFh7eip2xOda5kKHWZcKCntI0A==",
                    AnswerHash = 953609035,
                    RawAnswerCount = 13,
                    RawAnswer = "WVl3AYHIywfnortuHAgSnI9abZ7x7afHOplZQkDCqfH1rrX0c1QrmuQQPYKkrG0xasu1RuxI4mDbacJKK0WdKw==",
                    WrongAnswers = null,
                    Passage = "Romans 6:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 435,
                    Question = "laTHUGDlmngcw3mpaBH/2bsqbQpkiANYfAmeZ7fa1h5bOyZgEhuyeTSrClN1Gcug",
                    AnswerHash = 167960522,
                    RawAnswerCount = 9,
                    RawAnswer = "b0IFfG/ApQ0rtRYvjxYHClzpMHIpsmJsgbkr/MAfJw4qKATWYnYRRGKlPGkyaZIbB6sQNapYzydjNXdwrdtMrA==",
                    WrongAnswers = null,
                    Passage = "Acts 2:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 436,
                    Question = "e9bDbMIOVZ6p5LoUQMLjyxVehxXoricjEe0LKQ9huicoU2ljFoiDCrTkUVULsQWC",
                    AnswerHash = -1872918712,
                    RawAnswerCount = 1,
                    RawAnswer = "KxCJ5ijgVbto9Vd4mQ/qAOPnWAD3SEWaK1PCw43FPqo=",
                    WrongAnswers = new List<string> {
                        "tC1Lx2kG+ahO5d0iaZzpbBsluWKd5a6mrHMA46opW8M=",
                        "RiLx1LTxvM8VDFzv0lHy3g==",
                        "2w4+dvY3oJW9OFuw9He7Xw==",
                        "Bnzmm3O9GXKgEzosLJZnrw==",
                    },
                    Passage = "Acts 8:38",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 437,
                    Question = "SZBoG07NpD3dldWxwtEcpHG9l6C+XLxOVJti3FJbQ4tLfEOK/gP+aXmU4mY3pl6g",
                    AnswerHash = 66960465,
                    RawAnswerCount = 13,
                    RawAnswer = "qmyrN6qi6NMedtilq0O9r/HUjr+f8iGG/0EvzKT8vzIgB0mPaZruF7XBjzEOhL4zM84VpSEe9AAwq8/1PBSWow==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 438,
                    Question = "OJxzQVLuFg0hI9DVU7abuIzvfEvzeFZcnMG4nUhkhsKKwWoJHtH+zvYgpJwuPdIZvMw10XY48Cfnr62gga24Xg==",
                    AnswerHash = 1680088081,
                    RawAnswerCount = 19,
                    RawAnswer = "ypf13z2Xm3fgpn7v7wOrQdJIkT/r1RoDIp0+tEDy9hhhgTPTPvUdulaXTIyn6qifXnX4h7xCkaGcYgFyDyovJIBIEINGy2mnq+olAavyp7V14yYSg77CgYOL4xVi/ArI0fAdrrWTZoDu3mH1SeKibQ==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:24,25",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 439,
                    Question = "I1h3ntAsDYsZU79azn1I/ammkI/g4t+TnprVJCAE2boGo6KRa/Z29r3t2bWc8iptYHOmtMZNWPLAjCPooeota4E08m8eHYl1DGvn/vUr16N6KAsf+fjiji5NNE+bzWLa",
                    AnswerHash = -1255062722,
                    RawAnswerCount = 21,
                    RawAnswer = "Slz2xrIY/vlIoYWHap0Aw7GoWGSI2WQ1D+sbCvmRnMoOcvRfCnGMkOBmDFMnwhIshWKsbR6fDAWGAJeIjP1x/gXxJj3UwdGsVD2f7lAhp5bfyo6GIQla0Vko2a8n77KDARePkNGSXheMjjaVmDA7iQ==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 440,
                    Question = "dgbi/jj1+CUbTJjZSW17WUUBm6mwLTgtQtm7hkTsLdMV1hjahRZNqMfAw3ECKEZp023xsBGcys3qXQGTs/TIsyGdHepQY31xzJXFQHn2rEs=",
                    AnswerHash = 2140136733,
                    RawAnswerCount = 1,
                    RawAnswer = "dvTWtgDbK0WP1+H5ZQ3eH3Bd2rYltA/itKIjgE426btnB5wmM/FcF7BPtA5hVJWa",
                    WrongAnswers = new List<string> {
                        "0NeaGERRoq8aA5vNWZRjeZypaiZt6myJzn0tJsGYRkY=",
                        "ZGUqMg7F83rINWK9Gdku50xOkxxir5qWZHLR/5JjkY4=",
                        "LWPyd4acYoGZdVvSj20Y/aEe/y6zl1gBV1/qyJdGTNk=",
                        "Evwn+g7IECpEESfmkdubTlqhDjTifNpT4tn437Hjc1Q=",
                    },
                    Passage = "1 Corinthians 11:28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 441,
                    Question = "pEcx3hVEYtMnhaB4tiYRF89mig/fWBEPE3dyiEEXgFRswcEsbUK5W1D6ZfrmO0l9",
                    AnswerHash = 115918938,
                    RawAnswerCount = 1,
                    RawAnswer = "x5tvTaGq6xs1OxF1imzCQ/In6UUQ2atwcE3vNxG6451Rs+UQNOaICjrOai/0sX9G",
                    WrongAnswers = new List<string> {
                        "97rIBnEx3T3sRe5kAE+NxJaFP9yN4FW4F2wJ5v8KK6E=",
                        "lwQJ4AyWVk7No9LMMyT33YfYRHeunw5i9sQXwMzBvco=",
                        "hMftLaGr0MjkLIsNx8q7W/j8Mz/bkIyIbLQ4nCg66vc=",
                        "zKZywr4nBwsEZb7l98Muw4k0JOTLa9i4tJZZWJ1QsRo=",
                    },
                    Passage = "Romans 5:12; 8:18-23",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 442,
                    Question = "NEAPmRN3APSD5xGbi8jgSLKZwBE7fZKArj3bns6Ld8u/k47Nup3i57ThKXKCuRn9o5dmS9YCr1p5BTXjAmf9tg==",
                    AnswerHash = 1202639794,
                    RawAnswerCount = 8,
                    RawAnswer = "CDjjEOqDke85Y+uQQgkwuslvRKKqz0UKuuy8QJuDjv9PmmmOMUlPfu4lEWRDEonTAgI+liNnM2LMwC1Sft5tOg==",
                    WrongAnswers = null,
                    Passage = "Isaiah 53:4,5; Matthew 8:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 443,
                    Question = "dqlrSTuTShOor1j9iElVfbfT6JvLY7R2WKobR0D2NdG3KLRlA5IboEv1xN0u8JF/",
                    AnswerHash = -1403376511,
                    RawAnswerCount = 9,
                    RawAnswer = "+goTRUu6WO6rSRBURHDcqoIz7e+NwHFezM+0/DA9+z5F27kE8viqr0C5wSt+MDfJDh13/2B+yrBa+6v81YyyKg==",
                    WrongAnswers = null,
                    Passage = "Acts 2:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 444,
                    Question = "XqPcCSg+yVDW9rU6xeRX87wGpPJRaxPPCqTLg7bighchyILS0GX9cjQJuCzGWqFv",
                    AnswerHash = 583098055,
                    RawAnswerCount = 12,
                    RawAnswer = "EI2cReSRfY2rG3iCJ6SQp80dEIwZEHE7tn2Bqs0x0Z0BNGhlQ4VEDQOYsrlS/5LUgaRGT1W+QN2WtlbfxisUz7mz9n0NOjux1ufs4/2GqL8=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 445,
                    Question = "toEytOI+z3DK+PN8lz9qEPsgGHdpIPbyqZGRxGUFq8IFVFUXSSAeYDja7AyOk7OM+VgZKdjt35JodGhRcMam6w==",
                    AnswerHash = 914319655,
                    RawAnswerCount = 18,
                    RawAnswer = "V3eFVHD1C+S1kzZbbI5L7XP9feQfJJfm2FxFwwHbC+ALZ33nqmqCGs/CyoBNlH4M7aLkfeHaH5hH9rk0h9OUJ+eYT/OGwbdqrzdXjsXlO6r/lY0zoBXKEhUS+izOPTTY",
                    WrongAnswers = null,
                    Passage = "James 5:14-16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 446,
                    Question = "raEC+cH2PPrE00m/9xF1CQX748EhFFAP1uA1xpVBmnReUY1CZT3P0eUpId5E0f+M",
                    AnswerHash = -1729423184,
                    RawAnswerCount = 5,
                    RawAnswer = "96fsUPNyi9VNutBcwk7Cpa7me4pA03CBlI5xkfC/IFs=",
                    WrongAnswers = null,
                    Passage = "Titus 2:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 447,
                    Question = "1rkfnR/UGlstple+2/1CDQRjwxs5T+eXtJfMNX9nPd8=",
                    AnswerHash = 97550165,
                    RawAnswerCount = 16,
                    RawAnswer = "k01IDwYNi8HdJirEbOUVtYxZlw3PlRMR7SPtJrDWH+tBVvXwXf04hk2MYnlxCSMr8Gf7HCN9cSz0hho3VGcRQrMAuP0DbVTC0NuSRwPkWi0IaBiBtFgKqaW+WxtHwPwaSAa9tw+WTxOc403ZLzyIHQ==",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 448,
                    Question = "21Wq3PaYuk4IAL84O+an89ySpWSO1njXn6XLJAoZ2O+8P+Y1qTGYWcy/im0B/uSA",
                    AnswerHash = -690393515,
                    RawAnswerCount = 1,
                    RawAnswer = "r5SMoNC47M6GssROZ8gbMGn+3sGterea9Md99VYOvrA=",
                    WrongAnswers = new List<string> {
                        "rFnug+B9a3U5wjtEjUbzzw==",
                        "CU3yLySMV8BqFThAD0vRIw==",
                        "tTIIam0z5g7PrfjsYfbzYGRYD+ZL8kZYbYqMMTk2C3Y=",
                        "8Z9ltyfWi3EVlU/KwZqIEw==",
                    },
                    Passage = "Matthew 24:36",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 449,
                    Question = "3FvirOC0Uo51miUIXDZ0Y7L2EzWGH/v8JSaLhPFZSfm2GS6IY18GFTJmoIeF4iGGrsWGM8uId9WCf6ZRRg5yEg==",
                    AnswerHash = -1373961327,
                    RawAnswerCount = 8,
                    RawAnswer = "6XHXgONVvGauLX9TlCCtmhaC7s5g0RX019GgiqrPFQfBkzTh//q0OXIUQ7EG2bqQ",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 450,
                    Question = "0vnM3DEE+BuwtYZJzWve0PnSxa56DRrKqEbyqMl1NKcXpC1i15mtjjm+9QUBS2gIOC9ZJHCMd41jKobZfRbNgT2F9RpLh7murunpK5khAWg=",
                    AnswerHash = 1522827477,
                    RawAnswerCount = 11,
                    RawAnswer = "0sTmNm1lnKiefj6rI1/Ub8bITmNNU0vpH0a1oWPwlK/vXnV3QyB36jDN0E22JtpIKCYN973wFrd6stYFauEOww==",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:10; Revelation 19:7-9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 451,
                    Question = "MOVu40R4W1ZCaSHgf5tAuttJ1Aqq23FA9RglK8KRBRA=",
                    AnswerHash = 1025839691,
                    RawAnswerCount = 15,
                    RawAnswer = "ODM7XD8U8SXieA5x2wqu61h3ECB1iMrvy6TaUQszi9Hig234Re4MecoAHWHzsQh8OJnL8MUZoUunyU4aDSjWZCsrbsDskKDEXWRjClduPsBxYXplXizhyN4+jTcTFJwM",
                    WrongAnswers = null,
                    Passage = "Matthew 24:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 452,
                    Question = "OwUc4zVMadVVWG6rH/+WC9pyEpBslM4daan3fsVhbnrdo9tga/ZRbEeCneGJR/Mj8/QGwWQS3ZK9P7bZQ5xukA==",
                    AnswerHash = 1609059002,
                    RawAnswerCount = 22,
                    RawAnswer = "xV4xpfnoOQ2caPlo6JTWF5hhiikTnD28yumJpdcjo3/LZuxGAtURYhaSfUxtUGsYeXkXReu0yPcPa62pv5HRx2HGfJDLY16pR/uF4uABJo4N6zj9OMQA4rnirWn0QpqGSd/PMkSFJYAOsKQB7gm5LxafAi0T/cokTEefkWEitAg=",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:3,4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 453,
                    Question = "adIaX48i0b5RmV3CUpeuNZRdoSOxep2ZzSbgC+6kiYE=",
                    AnswerHash = -930597431,
                    RawAnswerCount = 15,
                    RawAnswer = "my8TCNJDkgtdUHWS+4RwGugVQxJA2TubGxA4+ttArzyRYgMFhsJcf+RlAdOl3gws2FPnIyltHr+HpI/RRiOT2EouPVCeUN4FVwA48bJHpmiKCYqic2YN5CbIfdVed96c",
                    WrongAnswers = null,
                    Passage = "Revelation 20:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 454,
                    Question = "HXoxNN4nE6ES0GklzSi4TMGGPxbAgCnG6sYWKFJ3Il0m+i4RocjHLCt3bff+1KzkI+deaqzxS07dYHz3d3hBkA==",
                    AnswerHash = 532171604,
                    RawAnswerCount = 14,
                    RawAnswer = "kVKEkawptNlr0HM/sQ6vZ2AnPu4hcwSQpd9WHdrA6vfxOg0A6++ZLc9DvQbMWSD4fen0h0OezwA/65RTWQ0izTU6UF8cfrB7MsrKxHt0Kg4=",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 455,
                    Question = "HXoxNN4nE6ES0GklzSi4TI6q3cSjKUCp1aokP0/2N39yM0GWXVJYJME81wXdg1shR1IlUKdqR4WdEMNDLNPSiw==",
                    AnswerHash = 1472364988,
                    RawAnswerCount = 18,
                    RawAnswer = "0ND3eJw53No0b/NePiBf9NYiCdGwgt7jLNp+gIahawqBupeHYp1HyczkL5y23e0CgF4MDBAth6hp32QvPtUy5SM9HU/OB8/nyXka5Et+ibGvHAHbrdhT4yq02rUtcWhicyYTqTz4gF39k9a4rWcNbQ==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3,7-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 456,
                    Question = "rpK83MjQTfprrZ/qO+zofvKLuTRWsHaZtXtYHwn8NsiicsmEOlFzxJ1t44Hkjld4",
                    AnswerHash = -484415573,
                    RawAnswerCount = 1,
                    RawAnswer = "9G8zBCCryDDwYY5+h8dZbAcpAxKMAdSw+Eb6U0nNPMU=",
                    WrongAnswers = new List<string> {
                        "LZkcnwViRmXhSlYium/QzQ==",
                        "ssH3Gx3yYeU0oiyOT/k+tz6yvsKNzoF1EvDcjWZsq+I=",
                        "5DoY8sjIJP478ajGOkPAX+U7Cedqwb8wlTBRXtMKHhU=",
                        "kYImNiMujvuSbrQab6e1SnhHclPMHjg/peiBaJ1sRME=",
                    },
                    Passage = "Hebrews 9:27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 457,
                    Question = "A8wg6EupfRs+tikYsENB9g==",
                    AnswerHash = 1527128389,
                    RawAnswerCount = 23,
                    RawAnswer = "cFRTNW9376ZY4wYUCbfKOp9COPmtdXq8iZRVzw1CTk9EjrI1aNQMhBAbekOP7H6kgj+9+rYt8Fb5IjAB/lI/n9I4YCdiYknnzAfA2MRGVJPyW52lBTrTtK1/WsfJxNnOoIj9bRZzlJTb2k3OkDs3mmRieE7Grq1SXPsFdTl/CE8=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:34",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 458,
                    Question = "NKc2Qmc6vJx+7njc0wBb8FnDIT3EhUlpXC2Xl5T9h71D3eFtzKgVb45ISVUv7lp5tXZZA3XxXCfZzEE53rxEtQ==",
                    AnswerHash = 1414221606,
                    RawAnswerCount = 4,
                    RawAnswer = "iyFEzz6+dqv8cNfirpgaE3xZnRXNjeDPmCW0e+LW5NY=",
                    WrongAnswers = null,
                    Passage = "1 John 3:2,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 459,
                    Question = "RWhkCGbQzKyotrCLK9ODxD1aoI9z/+HkOYStmANLY6QOZOfjg5E7aATMDqanNWhk",
                    AnswerHash = -2143183427,
                    RawAnswerCount = 18,
                    RawAnswer = "aXyT0YFV7rWwJYU74qc4jPAMuMpEs5YoXCIswWYaxeZIIpJqNhhfijKgswZpMA4yzDeKZbQcdBNL/vuLefDFmKay4MS7vsu6DYIiWAyqIcYMRbXCLM8Z46Vdtb5m4h0DUqUOIqgg2vqNgyXJN1kehQ==",
                    WrongAnswers = null,
                    Passage = "Revelation 21:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 460,
                    Question = "1w0R89MqgmdY7oyOZF4cG1IIXgV+X1FKwwY+agyj0laHsCfDFRSpKzZKpoc3NJ4sYsjtJNoh3sV51LBy4LypUA==",
                    AnswerHash = -1536198596,
                    RawAnswerCount = 1,
                    RawAnswer = "KEXHFY+c9mt8cTQw4I6lufdGA/jHVLncEH9trdHonoGf0vD7bqTRZoLvMxip1cF1",
                    WrongAnswers = new List<string> {
                        "puNJIIJOMTupLUHRbaOEVayTv9ao5vE1Uy/nWaNP0pE=",
                        "BuuCw404fTOCPXhtnPvAm3WWO9/NT4fRNRpTVVlaeHx9Oitdt+5ZXMuxc6E3NuKs1UGCvOWU57jYhEqduV8FtA==",
                        "KKFjkD/jfVtcdBub3tB2kSajgSkevX6LKp74aqSGX3JnEnK0hb/Q1xbnEm/Z4RXC",
                        "tkhc3VGT7oKJRW+codYKN3d2n/0hkJbTZpaWRt9Gtm/m04KCsOr3SzvH0vsBst5nVM+eWg/v7/OTOWcpVKk0fg==",
                        "z//RmvPVQIMPA1G0r5mF7wr7HTh9mHt3QY0aA6wDtSYH/sb+rhY4uSkm3ZOtQI9sXRqpF8mCf7H7IZE/226Jug==",
                    },
                    Passage = "Revelation 21:4,27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 461,
                    Question = "tN/Ai+p/7IR/UmlptjFnZ3kmRoV0urwM58+mxgB4N6HB8s3RWp23D1K+5zAJfMyS",
                    AnswerHash = -681362716,
                    RawAnswerCount = 1,
                    RawAnswer = "kjGeCL8o8R6bcGcqr4ijGg==",
                    WrongAnswers = new List<string> {
                        "Nkj9FMhgCVNjuusOn6kxaQ==",
                        "QwrzC/FV0N7MXJ8z+sOwrA==",
                        "1TDwahh63VD3Blfy4ytHrg==",
                        "4x5GYxVaJ9DPijf17IhKgg==",
                    },
                    Passage = "1 Corinthians 15:25,26",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 462,
                    Question = "JzEepRye7AcMLZ9ubJXGxg==",
                    AnswerHash = -1677213247,
                    RawAnswerCount = 8,
                    RawAnswer = "b+BizhMJa1wkCKAb3aDW5yJuTgKUxOROzhS9HZdmCQPKfoeYhcMjBrEMPF5pGgEx",
                    WrongAnswers = null,
                    Passage = "Mark 9:43-48; Luke 16:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 463,
                    Question = "xtCJ6SWur0dE2aSRbCPKlslaq7lOuBlueeBk4+V3qDc=",
                    AnswerHash = -21411764,
                    RawAnswerCount = 5,
                    RawAnswer = "YblcuJ54uDWaMXvoLLIpOF6vtyA7rbSXUsSjgo2I3hs=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 464,
                    Question = "RWhkCGbQzKyotrCLK9ODxF/eHe6+VzUejquXVP0YTxzq8HDAVNGxsYXwVXFBfH0O",
                    AnswerHash = -219778964,
                    RawAnswerCount = 19,
                    RawAnswer = "W26hZUgP0yIiavD6mwNXfowANDz1cS4UDEM7XWFBhkiG66cMEfxbXpO2eWt0uxHShwSsemDku6NmYxgD5pY1VypSFOHZ7aCti/8pJ6MDLN7p+ThvF2OgQRAmFaxJ4I85UEl0qY9Yp6KsysCvky15NQ==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 465,
                    Question = "LEUtPY6rItFVmYSY7fK1D+mkcboLw868uEKrCWQA3Ig=",
                    AnswerHash = 1446803650,
                    RawAnswerCount = 19,
                    RawAnswer = "d0STe1VY8YDjYafDF/SSBRwDhUcGDQ9itBCHUxGBzVQC57tnl+8pFomnItcxTPb3/j5q27Uo52EIzGeDWYcXfvKtGk/3yxN83JFQ2AL8Ke2HbOFr1gR55BK9L/HaBGHQoajtCuQmiav65srJHEQ3lw==",
                    WrongAnswers = null,
                    Passage = "Isaiah 14:12-15; Ezekiel 28:11-18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 466,
                    Question = "28SfeiXxrJccN/FeTnNGNPl40Vlg7eVP/xmJB+UXaw82sntCPsZxqxH9GRArVtmL",
                    AnswerHash = 498041656,
                    RawAnswerCount = 15,
                    RawAnswer = "SqIgIpkm0U96ChxJSpKilxFvLFwSofMcqiIyONZndjWYLDT8scXRUv2ki4fqe0q+QCCt14oHil4B9pdPt4V+NmJVsUBKC7fC2bDQxAerUlEOc5FThGyW9yQ30FL/ZPAM",
                    WrongAnswers = null,
                    Passage = "John 16:11; Colossians 1:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 467,
                    Question = "0P7wYkXzKYuUhGMMo9YhQcMnWOa6lQabGJRiHc92XF0P/jGtxqeBWQbGnlPZuYAt",
                    AnswerHash = 1679711152,
                    RawAnswerCount = 18,
                    RawAnswer = "3pw63y0PYIgH6I6rTAZHUHdYDp9mZ457nJd3iPQTNOzWXuqRDT9bHg+JhVa8yJfe4QyMEmW5X6Y1QWKF8QUPJROScyngtHzY859v8OHH/d0Cia6Ft1tX/bY1wE2t/x8/",
                    WrongAnswers = null,
                    Passage = "1 John 4:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 468,
                    Question = "HoUvMqan/su4dSso5wb2Lq6O24RnjCAfhlEz12RrtC4OsmRmTQ+eUiKE04tQC8HeF5nr9J3ryMRqw8or8RoBB9iTOQq8cfHOpXslVtf8R6b89W7Dg51TBmzIkyKmlE0l",
                    AnswerHash = 1622433957,
                    RawAnswerCount = 11,
                    RawAnswer = "uMtuOZV1IRihwaw5ixZMUIAY+xYm00J9t69WI6yo8XhQYqDhMSNo8g2YZ3UbK9NDdi1W+Sk7M2E8ElDPVgiHQf2+f17uV3AEMJqHg5Gd1e7eUlc3YP882WgMVd9Ud+ZA",
                    WrongAnswers = null,
                    Passage = "Isaiah 47:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 469,
                    Question = "7sO5/P4JamR9dvUMZV4v2cmUaMVbro+I7nYQykUYO8zEmoRvgRD7ZUktSK+ZRVzgu8kxqnQGYADGW0MLatredw==",
                    AnswerHash = 1306807263,
                    RawAnswerCount = 12,
                    RawAnswer = "s9gH5UwJGzCbbcPwyrz1Cor7u0tVSSV6Mr1/wNKSR+qQX8dKKZf9Y853vcKPJexLCdgljRTiDXjYJjofJB8lMW7NzTkRfHdr6inB2OCL+xw=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 470,
                    Question = "LLoFRoHhKoyFbFayEXQCP7JuxTsJOOEVa+iy1JC5bdBjKAP8IJMFC+NGXsRqdm4le2acBvNsQqUqMMmSztpG5BqTK9iCb0Hw0EGlq1vnrjJcnC+6dcyLTNddXuouPxZt",
                    AnswerHash = -1271884638,
                    RawAnswerCount = 8,
                    RawAnswer = "rQDD3sud+Ks4zY1G91p9OxIIz4Zrpg1UuxeT+3MFwqc72d6CyD2pGxQDUvQoStTi",
                    WrongAnswers = null,
                    Passage = "Luke 16:19-31",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 471,
                    Question = "15taIeuOTr6HzYePv9IW8b+9WZ4GwLsg15EkcjajrCQMBTYsYiR/YuqplY+Zmda3kih7BOIYu1Gl3Apg78+6W6bhuPiO73vD9IsWou4tuew=",
                    AnswerHash = 1748915047,
                    RawAnswerCount = 19,
                    RawAnswer = "dLXB/9Gg7YsHZ392B8+EQFMfGd1pf2cAdI0ZmPYihxb/vPwrSPaunnAiDYy8U2mDZHtwqdNYZgfdYRfA/9dMsPPiMMGqxzU0hOcuTdkcVzXYTRvK91g9l6+8UMrvR/gUHE6pd81dsIRIX3IqElOViA==",
                    WrongAnswers = null,
                    Passage = "Job 19:25,26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 472,
                    Question = "Op+ohZCmHWI0MEvVjb+8hXE76j5EE/PQUUaGrJEXB64=",
                    AnswerHash = -2006508609,
                    RawAnswerCount = 18,
                    RawAnswer = "R8sMSk/FbeQ/6ikp2UtarRe0PEhI8/cYr/pFU9TZ324nkhtBZyqac/7PMMC1CS5GWPL2xTJ9qS6+N9gw+e08vAt7AZGTS9nAeas/+uj9x2jWkzhShODONtrbMrUQzKVjaxJ6cCYyuj0f11oDsT6ekKtaWdeD6HmBwwhpFiE4uLs=",
                    WrongAnswers = null,
                    Passage = "John 5:28,29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 473,
                    Question = "FxIAHGLp0qCjBqWfVhGh2easJ2We9Qtqva3nJ+0Y3rSG94c9n1Kqlu+gIdxlZGe7KqHcQogyf6LBaAGZzT2vHbs41zg85fTuaykln7orabI=",
                    AnswerHash = 1451050738,
                    RawAnswerCount = 1,
                    RawAnswer = "fNSh56NQ9Amzptz2CvDTX1+65MED62qSCkfq9ibLDFg=",
                    WrongAnswers = new List<string> {
                        "yQm+SDYAN9KN5uCoGWknkA==",
                        "k5H2/l15ilu/Z4lvCH340IRt8e0lnFhJAQssjPMGUWY=",
                        "mGwhaPnN7M24fsTdVBt10A==",
                        "wJELU+cXndEwvb1tTUiARw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 474,
                    Question = "F4Ur/E45JaXhP3E5qJxMkv63EdiCDfyto1Oxxnp2du+tlE7WIo+qUkuQdiBN5UvJGMiStFqNEVkLrgjjJLa84qmCPU7ODyfpVU3mESPLk3IjbFJAs3N7TH0d9c2A9grUDGYuW+aAGMvVfQHGHHVpsg==",
                    AnswerHash = 1063280240,
                    RawAnswerCount = 9,
                    RawAnswer = "y7SbXcSt6ghA+t5Xdnk67WC27e0yQvNJW7+GA9NkdCPYZfmJry1D/3NLpGpmFOno",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:36-44",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 475,
                    Question = "QwNMl8Sr0Upjw7NhQYmWCG97WPaQQQOJ9M2UNj9eH64ZNgtU0bs7Rpq9d5ieK2M7TnHkjHhDzv8NSPAUoF+esekyFxKozbLXp5E14t7sKgzn/gz/3EvhpEuKD40P6di1",
                    AnswerHash = -310174019,
                    RawAnswerCount = 1,
                    RawAnswer = "PrsgZwppT8kXskm6FYV83A==",
                    WrongAnswers = new List<string> {
                        "R6bRDYJ8za5h7RvA9FlRHg==",
                        "i5U5wbLryB/5zbo9gezbTQ==",
                        "xY5SMS2ivq7N9OVuTWoGiw==",
                        "/40yJKM930TANidzR52Yjw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 476,
                    Question = "Lkn7Ggbo5jB/pi9LKOF4aPzPFie3EFosmUnAwm/PQFMwgll/K4J2MriRoW8X9WgULWUAOZoCMSXMJq4Q+y2NdQ==",
                    AnswerHash = -1075275386,
                    RawAnswerCount = 6,
                    RawAnswer = "8isdj5hbLhj2OWPCKtEWO8s2daJtOjuxomjXUjhfp/U=",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 477,
                    Question = "E89YIWaUSHLgCrXnJwzaIWCEBc6xle087PchhrODhsLiy+LxxxkkDf66966Li9/6aJnZniGIBx5bBCgQjGmXbTVAnlHWciDmiMRZDkTsuBU=",
                    AnswerHash = -334540406,
                    RawAnswerCount = 1,
                    RawAnswer = "1ywsgMgBPFJ+2SCTp2Zf2g==",
                    WrongAnswers = new List<string> {
                        "88wBfhNOgNClN/lpM0WWPw==",
                        "/R8T7eWqik620IskjaI2bA==",
                        "3tbv5KPagte95mrrdcvLanrrV88h4TuT1GkEHqFFLxQ=",
                        "vUl0AQCe7VR+BpJxR41Nlw==",
                    },
                    Passage = "Luke 17:26-28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 478,
                    Question = "OwUc4zVMadVVWG6rH/+WC9pyEpBslM4daan3fsVhbnoxIpBsKKi5K5WwK7clZJV08p9hhMbwSEg5MWQS+JSLcg==",
                    AnswerHash = -155631569,
                    RawAnswerCount = 16,
                    RawAnswer = "v/WPj+nk9YpA9UoBtX+QORsFGS4/nmTwpG9Y8VkWaYb73l+OOC5yKTRMVdjcuOvpja/sTguSXNxwnFwT+bVW6DRxpa9Hh2M7NnA2vdOD5pP6Dl4IF7xkMpfVr/6Fcmyt",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:8; Revelation 20:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 479,
                    Question = "8K0dNkoUJq/5fLRQmSwcWfmx+8cVsR/cKwEouKvsP59ZoSloh+rpCNGzthSad5lxiFQhf+I6BiN4axwS+P9CLA==",
                    AnswerHash = -1087420178,
                    RawAnswerCount = 5,
                    RawAnswer = "e4bkBlqFOjT27l1VNh+KStQsL+iRsD7zkYGpJv08UIf1TKjbwgMRtVPMs+EYW+/Z",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17; 2 Thessalonians 2:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 480,
                    Question = "nNacGQZvMKnXzninqM3j5wsLrJpNiH4GRL03JbGu9II5Kx0qr+H4f27N5J6WDujP7bOBTaWR8jG7uwqdJANJj+bHcoGundh4KEo673OSCMsPBSuIKr4FkENo/c1lofKMrhMyO11rSJVY9s4NGUPOTw==",
                    AnswerHash = 1260179372,
                    RawAnswerCount = 10,
                    RawAnswer = "EiOrFKSkoF4aKOboYV11bcK4UfBoqbFflapImaBOYbhpCJEOysysjsaA3pr/PtXcNnflNMObW0c2qokkKtXhcA==",
                    WrongAnswers = null,
                    Passage = "Matthew 25:1-13",
                    Type = QuestionTypeEnum.Jumble
                }
            };
        }

        /// <inheritdoc />
        public int GetMinNumber()
        {
            return _data.Min(x => x.Number);
        }

        /// <inheritdoc />
        public int GetMaxNumber()
        {
            return _data.Max(x => x.Number);
        }

        /// <inheritdoc />
        public QuestionInfo? GetByNumber(int number)
        {
            // PEV - 9/11/2023 - Switching from SingleOrDefault as FirstOrDefault is faster and we can assume not duplicates are present
            var retVal = _data.FirstOrDefault(x => x.Number == number);
            return retVal == null ? null : DecryptSingle(retVal);
        }

        private static QuestionInfo DecryptSingle(RawQuestionInfo value)
        {
            var splitAnswer = DecryptString(value.RawAnswer).Split('|');

            if(splitAnswer.Length != value.RawAnswerCount)
            {
                throw new InvalidOperationException($"Mismatch on answer element count for question# {value.Number}");
            }

            return new QuestionInfo
            {
                Number = value.Number,
                Question = DecryptString(value.Question),
                AnswerHash = value.AnswerHash,
                Answer = splitAnswer.ToList(),
                WrongAnswers = value.WrongAnswers?.Select(DecryptString).ToList(),
                Passage = value.Passage,
                Type = value.Type
            };
        }

        private static string DecryptString(string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, _decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }
    }
}
