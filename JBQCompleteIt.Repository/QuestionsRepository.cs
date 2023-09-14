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
            const string key = "DyeAMK6gujglpa7JMk6yIQ==";

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
                    Question = "/5ky9eb/zTL9t7M7u57FXvpQZ5MTmwr8EaL+dFGgbsc=",
                    AnswerHash = -477534284,
                    RawAnswerCount = 16,
                    RawAnswer = "5sT4eIf0Ynj0AFYpHqCztJQ6DX/IyzlNUctmnNjJQApHpgGxk+qr0XEMjRhMWuvQ5sn6QfkyXSVTSckvFOkxleO+QI0ngfXep/nBkc550SnvZQNZ5LExlF5tfXiw7e4X",
                    WrongAnswers = null,
                    Passage = "2 Peter 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 290,
                    Question = "V8xJBuAVxDf5AHdnvn3pMbS9NihnYi4DDXviSrGAaAzN8jNn6cbLrmlKaTSd/Uw5TrHrcR3IKHgfV1UV6re65g==",
                    AnswerHash = 597581677,
                    RawAnswerCount = 8,
                    RawAnswer = "meAgOqVoV+xMocZWW8R5kMsZLtKrRjbV3JB1v1LNWNhHhJINlu+xYtPq8CNBVfW3",
                    WrongAnswers = null,
                    Passage = "Psalm 119:160; 1 Thessalonians 2:13; 1 Peter 1:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 291,
                    Question = "V8xJBuAVxDf5AHdnvn3pMbS9NihnYi4DDXviSrGAaAz1YsOaXHTkPjxcoNyCvzQIupXYOEXnX0pgYHvPGV3guA==",
                    AnswerHash = 548532187,
                    RawAnswerCount = 13,
                    RawAnswer = "bwODiHedflq5YepQTvitW+Q09tm3muTYo3s4eyELTcQc+d7x17nhcUJO0I7y7F0PNDIveC2GKPTQGdiAnp5Y4tkB4ouE62cl45W21ab41hk=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 292,
                    Question = "V8xJBuAVxDf5AHdnvn3pMbS9NihnYi4DDXviSrGAaAxYLMMTG2FI+TCk97bPQR8FlpujdYleT44SemTTztCw2hXqbLUmnsd2saViaJM5gYEinnSI1DJbe1SOc5snesHm",
                    AnswerHash = 912306622,
                    RawAnswerCount = 16,
                    RawAnswer = "Zo+yIzeGOljk4qg087pVmjiixr5/CvHdKK0LUE6dKxN3NZNykVjqlWbTs3WUM4N19ugQVTZCmYfkrsaG+nC3LalXSO6R8Lku1HVdmNXMf+I=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 293,
                    Question = "KYbpnTmIi/CrR4bMgYketToviMyWUsi5tS2/M9M7DwI=",
                    AnswerHash = -413485710,
                    RawAnswerCount = 11,
                    RawAnswer = "d8gCymxMEzeQLlQyjq3GBnEkRMdX7qTuPqcC8cjuo1Nu/un7MPM96keBsh7t2xfBpZGeY3tUpKmuj/5yi8jlSPjdfK8e6mQ7lVgTkQjtYrc=",
                    WrongAnswers = null,
                    Passage = "Matthew 24:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 294,
                    Question = "TL5d6XZfA48Bq9fD9lC1S3g823QOrC5pCLbFSLrPX1kAZKQMIZjs19JH5ofVRDkv",
                    AnswerHash = 664100995,
                    RawAnswerCount = 15,
                    RawAnswer = "KwWjMsWTUOV03C1+Ev5hRDl5LNpgTkL7zCPTD9tNMj87xES0UNnLM9m5tISkyihm3S80NMbFfPwlgABxHJ+DLMLSS+RHJulEbGfQS0HEKjg=",
                    WrongAnswers = null,
                    Passage = "Psalm 119:11",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 295,
                    Question = "YAHOEZ0i5FuIh4rqtruyaoGvVbpDSISqub0FxG5yn5DeUQwQIwBfTyIbNzZtOSq1",
                    AnswerHash = -759577731,
                    RawAnswerCount = 17,
                    RawAnswer = "Qt4fOBe7Ueho7S0WfDO98J34ZkYwN4TaPZLyEGFIESCwe1sUrHlubdvCEI6Y85c5ZbbjBFAkdyaqyR3613bwko5ORbNyQzihKAAtP+J/QA+aJ2fGRGijLvg4EovqSNK0",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 296,
                    Question = "JcHjr5zlHbBcwpAuonPMjA98NmeBku8zisfmfIEDCY94pENqLAw66DeChKLkBlrCusiUkS/nDUsUvu30cGflYQ==",
                    AnswerHash = -1106894312,
                    RawAnswerCount = 1,
                    RawAnswer = "4EObaShrrx9KA6c4oxJ6M2lJbZXjMNVwyShIry+cM5s=",
                    WrongAnswers = new List<string> {
                        "vEIdwy63QO/X2LvG+GRzIMvf9muRtDxCAsN/x07GvD8=",
                        "jP8D5bnD7lZtPF/jGBn5Pw==",
                        "QvEAElOkA4/3s5lKN2AP+A==",
                        "91fBKXQ0ljJ5f/GXWicKFA==",
                        "6zH0ls10oXT0VpZU244CDA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 297,
                    Question = "DoZPmjrOMbKhuY8kbUVFUMWQb5BG1wdz0u2M9MToG66+Dp/5RP5rYSHtM6cgJh+F",
                    AnswerHash = 1383466518,
                    RawAnswerCount = 1,
                    RawAnswer = "uf5emSdHwZjKISnWGfXswg==",
                    WrongAnswers = new List<string> {
                        "miZPQr82/yL6yoGjMv5Wng==",
                        "ylD/9qpZxVklUf1C2dxZZQ==",
                        "Kwz6pOKfz+LzRLLsUea3jA==",
                        "FshFc4bqB+GcfHuVxnwqpw==",
                        "vSWh2YqMRCu0ecmeZBWw8Q==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 298,
                    Question = "QWZLb81BfV/9q0ulwZ0Ob4OqZgjEFqf2afwNAlPnt+flWiH/yxE9CRwX+Og2IE49",
                    AnswerHash = -526712874,
                    RawAnswerCount = 1,
                    RawAnswer = "lIauelJRgub69h6DMQQ4rI1Y4CBxfeIoDB64CRfdaXNBCYH4+1YTjBbrNj/f1inN",
                    WrongAnswers = new List<string> {
                        "0Tpp69yWYwXmaYzXLXrjOwh54TZL3KRUmRAuWXLdf5Q=",
                        "gG23y+j/0TOBUCRJ6a0/tUJD1O+dPL8TuDjupn3VFGg=",
                        "g9CA0GefVXcsymqHNcf0nnzQYOZpvlY76ybzSBJjJWUO3AvU8Q9eSidX/mdEFWYB",
                        "P+q1hWoJE7Qs0ZR0ed+2kR/SoPvMJua8D3k6yoccD9g=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 299,
                    Question = "H9xC69Tsbuc/w8JHfTZYrrQ049+3JjmKnthYaojUK0dtguGQvA6gMH4J7OKzS678",
                    AnswerHash = -755287896,
                    RawAnswerCount = 1,
                    RawAnswer = "Q1LSoQawXLyuqJO2HHF81qehk+KC8uInCb3LAdYYMbE=",
                    WrongAnswers = new List<string> {
                        "zckpG5cDqsTUeOKFv6CVVg==",
                        "1RhiEVafIshcbOIoe0aP/A==",
                        "uO0ocuAlEOpHvgqOJSnbig==",
                        "THLYBbL/r+2QAvayarQ5Xyq0hU6Kg0R2h3l4yYx++tk=",
                        "1V8CoUS2CGZsoXLA0cyMevSIvv9ZBMRQksVIsjpolQc=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 300,
                    Question = "vwfIzHKo4JiobRj6sQbiBere/vbVe/D57oiR4kaKouc=",
                    AnswerHash = 1642760562,
                    RawAnswerCount = 14,
                    RawAnswer = "tdv+edR28ZafaQ+AJfeeF6eiJ+VUYdLfzEmgko8x+D8Z3DNSwvIZaYtTrgKuQ/OgIS2enyFvhMI+KsXGe71kucW6IjBU0YpO86Me1GfXUdCFQk5lBQvvDvrDPqsyQ0Qq",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 301,
                    Question = "qlWfSNSe2gr4id3AD8tpVq3IngvsbXll2ov8oW5OFfWUnASKEhoq7cpcBVLyK2jCWleUl9ffoLL+tsx+JqHRQw==",
                    AnswerHash = 253211454,
                    RawAnswerCount = 1,
                    RawAnswer = "qvHMQHkgkO8dJDb8bhSRFRzIGm+bpX4HyE8fXqFUwkc=",
                    WrongAnswers = new List<string> {
                        "RIqZQOUYuqKY1Nc+HdcD/dmShhQmo234lAcDWVyENyBNUvz16nQjzt9XzCKeqKXieFGz/RuXM3j8CvR5GqWcBw==",
                        "X0snfuLDaQZ1ARwZX4hXiJKUveAu+OUdJpUMLc9qr04=",
                        "pRPjzxB6IR4/Kcy5Uu9VuxU0OSEjhWeyC6pBWZtAJjI6kTesC/pCHnuT4ZAgJAgr",
                        "gJLTuGdDTgdGysNG1IS4GIvoJF0Sbe3ecf3o/YYmaSM=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 302,
                    Question = "RJWx3X3RUGZuYPyVhZSI5J0VSd81UIE5KoRhKyEh48zrVA0RcGL1dc2DDhNgd8mePNMRhPRXnblAXMkCFO889w==",
                    AnswerHash = 1114529282,
                    RawAnswerCount = 1,
                    RawAnswer = "gazK0+utH7D7wRo0LID4Eg==",
                    WrongAnswers = new List<string> {
                        "AKo2FLVhrF5wEkmxRrSg5w==",
                        "kcAiC6a3yZnyhIoqVc7OQw==",
                        "vsQiB5mxHDQxWLifIdoVcg==",
                        "kgZ1Z7Yv7mnxJTzC1G2Rew==",
                        "hg7tKFVhPDmq0YmzgxY0Eg==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 303,
                    Question = "fi6IzwHfZT1NsXHiWsBrTeQ+xRdbq07xPvLFAUeuGMsnrL6LXWRHpLL73CUi/hXg",
                    AnswerHash = -2143787200,
                    RawAnswerCount = 17,
                    RawAnswer = "if8yzJ8LdFJ7aQKfZkhQ6KdOKso0TYCvopU8FdUyyjYv7sWXo4xiiHrPYe1S/tUE+NCeTPrVhERwGIq0hpMFH4+KdTwqPonBrTjrikTspQFC0uBH3dvWMUMxZ65QGhbZMf7LAzEMppIknt21ygLA0w==",
                    WrongAnswers = null,
                    Passage = "Hebrews 7:11-28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 304,
                    Question = "M7N0mAhBghmC59G8tQaTVF4srHj3/paKKb89z6Wiei9tLvoRw7OUxzs9HIvSRt9QpempnIvY/WCzMhU3wZ9XWySwqviWkFXSf9vvIYgGClW8bcBOAcgdAyvczhWHAXOKswqiROeaPfoohxrkoHxLsQ==",
                    AnswerHash = 345786085,
                    RawAnswerCount = 1,
                    RawAnswer = "miZPQr82/yL6yoGjMv5Wng==",
                    WrongAnswers = new List<string> {
                        "ylD/9qpZxVklUf1C2dxZZQ==",
                        "Kwz6pOKfz+LzRLLsUea3jA==",
                        "FshFc4bqB+GcfHuVxnwqpw==",
                        "Vq6y9+z68G0UCP3K6dtZKw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 305,
                    Question = "ckNbpIedq3KtCS1cx5QtfwgdjngGF1kFG1oOO7w7soZ6dCoESkHS8o2/V4NGoKmIXQmPvL69jORu5ExY/nNkU+X2xBkFFOvY2hpg09hXwKxuP2r/M+5RY0R8UD8syTSXQo3WyNqr33KGh8fiCs5o0A==",
                    AnswerHash = -1601542879,
                    RawAnswerCount = 1,
                    RawAnswer = "vS6dk0FHoTczOnW/AmcKD6RS0rLc1+7zEMwujmKYcmk=",
                    WrongAnswers = new List<string> {
                        "5bzbBGa0u5uobrEwYARWIRhF4YhAD8jaV04mxD/udpo=",
                        "Ga0sd4KiZ7Hyra2Bg/FF+Z4pYo8mbgLZbjfJ/LbChnE=",
                        "qj3y+2S0nhk9p8ijTwqC+/A0wAY5Y+FzQ3NiXAS37OQ=",
                        "A8k/o7lP2UxFPl31nc+/7W4NtBt3yz3+eb8PNHgF/2Y=",
                        "CVufyWKG58UGw072RcD4bp3MY1AOaBrwBi7lo4MCTDE=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 306,
                    Question = "dx3M+kKyvHpnVPmcyKBCLLsdaqOyVX+mXfQ73OWECQEEN17K3eVZdnLF0SrV1oZU",
                    AnswerHash = -1685795481,
                    RawAnswerCount = 10,
                    RawAnswer = "OY6kjJ71DvgpIWztyyqvdqhCC64rUf+LxOpYzdD4QZ1PpvvtoMEOP9ssGZCtqVfLEseFY1ji84YM4r+rlC4X/Q==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19; Acts 10:38; 2 Corinthians 13:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 307,
                    Question = "V8xJBuAVxDf5AHdnvn3pMfHMPMZJoEN2l6GSAbScCh91w9A4NyWKkCNvLBFYGwLTFp96h4FXebGXH7HMRTUoYg==",
                    AnswerHash = 1359645467,
                    RawAnswerCount = 14,
                    RawAnswer = "7+zRUP/dtEHHdBnxon8famvxKMEDi39O6WR+4ffTrmYuF1yF4IgKHym2n/Y4IV3+hyopV/4ZxHdVkQV0doGY/QIZ6QePwH361FFbFzrProI=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 308,
                    Question = "V8xJBuAVxDf5AHdnvn3pMfHMPMZJoEN2l6GSAbScCh+ppwMzga5ybwDyV180Xk/lzZLPTwta14j2peN0zRsSrw==",
                    AnswerHash = -279299386,
                    RawAnswerCount = 7,
                    RawAnswer = "ioUnVLWDmMLNZkE6C3zwogbw93smlsKZEDMp+JZXJCpFf/uc7cWSu6ffabisGvsO",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 309,
                    Question = "V8xJBuAVxDf5AHdnvn3pMfHMPMZJoEN2l6GSAbScCh+M2/8qg05ICABXCa+kZiv9ZXehWbsEwPzX81DD0SMNbQ==",
                    AnswerHash = -1532937696,
                    RawAnswerCount = 1,
                    RawAnswer = "o/B7VUuwDHwgDy/e6FGZ/kDttPShvWTgrQVBHMn3ygk=",
                    WrongAnswers = new List<string> {
                        "JdEFDvTIp5NR5TNOpvDLgLChMRsYkIkH070fZrHNWn0=",
                        "lcEhldUL+6p037A6/STguK71cxcO/spQvHBZGhC0tZ0=",
                        "ykCkdielI6VwOleXSkUD20hXmmaODL8iDsEF/2rvmxY=",
                        "EmT9mD7BzBq07ax5Ck6aMFULiIaLqMMECrb5sODdgzM=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 310,
                    Question = "V8xJBuAVxDf5AHdnvn3pMfHMPMZJoEN2l6GSAbScCh+f3Hoosamz+OuMcZntCts6hukYqP+dtreiCEkxPVAbxQ==",
                    AnswerHash = -704070534,
                    RawAnswerCount = 5,
                    RawAnswer = "hpZkgF60yjcoCj614P7+oNaUYFs80AtI0nyMEHbnz4r4bpogeJO1AbX0mvhB7y7t",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 311,
                    Question = "OC+thv29Pa7mb8h0cl1h8iRMYa//DezfXVjEs4iqheNz6PrOYv66DsPbHEdP1PW0",
                    AnswerHash = 643699282,
                    RawAnswerCount = 17,
                    RawAnswer = "v470qlTqtIMAWOFADTfe9rjjvYOlxStg5UaPGe/LsqAZBb/05a+eHBVhPqwPGQTYn55ITgYerTIcR6/l5SF6EYZ6sYVl0XpFTMJDow5c4TmbubKKV7PHUta4G0LRPYjC",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 312,
                    Question = "ZSVnQMCTA4iGpIDmsl5x9DCqf8NBfkL3bRtw2He7IruP/7QtI5OCeSfajd+vhs+MzbK530YGGoji00+doP2S/Q==",
                    AnswerHash = -668056075,
                    RawAnswerCount = 1,
                    RawAnswer = "iRB4JTjXEKSu/VZcgBAnlcfr8iIK2p63D0hGDtlv+YU=",
                    WrongAnswers = new List<string> {
                        "Oa3YqtzwEUZf6qNWxe62rgwXYb99fd7HOA+JqX4I+Y0=",
                        "tUh97Ii3vhnNvZrPk/Wspw==",
                        "UTAMxw2sxRxiE1FThzs/pw==",
                        "X6PUwP5u/FYNaEpp/ZpKsXaWfwiy6SmNdJ4zbFgztsQ=",
                    },
                    Passage = "Proverbs 9:10",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 313,
                    Question = "pmp5ivnogPEl28oEsRke/VPuszAtSu/zvaKlkwfBvpuH4NMsVoVAbkf7CdQXIDSs",
                    AnswerHash = 519687715,
                    RawAnswerCount = 10,
                    RawAnswer = "Nzn8dzM65opzbCFzq2uGUmC7VeGs19OU+dX7A27gXssd7isn5SQvwU4EIPhpHP2KSvC6NjVKMCoNobaecDwDJQ==",
                    WrongAnswers = null,
                    Passage = "John 4:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 314,
                    Question = "tz6Hee4jvFRcobeAw7JMgU3ny2PoV3i/QpICiGccP+4=",
                    AnswerHash = -477459957,
                    RawAnswerCount = 17,
                    RawAnswer = "FDQcwgva8QmtpCaVOYGqztqQm1pmByp0d63aiC1vVpkaFDq6iHv2Fvv1oi6kXLNrc5oeHoUK3nQzVycQRGI7YONP8nZdDR9QpXWKpr1STrdUBHfWsQfO9+vqoRPVFKRW",
                    WrongAnswers = null,
                    Passage = "John 1:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 315,
                    Question = "Ja7+k6gXpjAedKPljejcQnvEkrw3nkRVBTHoP43xH0a/kzpisfhy2IxJ94Stu1Nc",
                    AnswerHash = -1169222186,
                    RawAnswerCount = 1,
                    RawAnswer = "9v6qP29BwwQQhgvzEzztGA==",
                    WrongAnswers = new List<string> {
                        "9NOMTpOUXRr6QShuFzFVbg==",
                        "csRQaIozMLFraST7qr0LVQ==",
                        "8FdKPokNykRMMwsFozh81A==",
                        "8XqXuCs2sgCosobjfFKvddzZdi70dxqQpHOm7BjF/Js=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 316,
                    Question = "Ja7+k6gXpjAedKPljejcQkhP+jSioCZ3nZ0j/KRP+f8mKr1yGIcL7VX6g/ixWlzm",
                    AnswerHash = 1889598857,
                    RawAnswerCount = 1,
                    RawAnswer = "9NOMTpOUXRr6QShuFzFVbg==",
                    WrongAnswers = new List<string> {
                        "9v6qP29BwwQQhgvzEzztGA==",
                        "csRQaIozMLFraST7qr0LVQ==",
                        "NQBT57zlBkncuhoj5sDiVmOdgGoTH8yg0eWaFG7tdyM=",
                        "4F3a4XGj/NZIzQ/0wAE5RMoDpClZlte1gJoUuyxtZ1Q=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 317,
                    Question = "n4jRz49qO6C8MScBCDxAwHWKR217lMaIM5nlwaIY0tXK7pYBZMvlZ+UVxSdKoqsnZWoJDLGZpXg9m7LW+I1KUQ==",
                    AnswerHash = -338725938,
                    RawAnswerCount = 9,
                    RawAnswer = "sOG+FDoCA/AJZH7ihTcB8Auvxep6wna9XLEsvruPr9TEMC8oTrXVIlmR2x7EooJ3CIEFVsC5VT6jvzTFmD4wCw==",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 318,
                    Question = "RUDqVujH7VWX82d6WXuOp7n1D9ECNVJftPCWCBCRCOGZmS6P2mnnVINzvh95+KxW",
                    AnswerHash = -1391455965,
                    RawAnswerCount = 28,
                    RawAnswer = "qyzwLDKUk+P9n7NQirh5wcf2ZlKRajCYY2125fAzsM6bhklj+jonJGSBQtji9YqDP1jN1iq7zqE58Vm8Bt1hKh+uUygTM9E+86VANC8aZWkxF/EYI4uqBJytU0JUUB8vXsfY6w7KagsbQncLTlibSDegNA2UsdXSgMAzyPggiV9eEUS5KYJmrTFPkNRwli1qhJpihYeS9JViOivr//ZfJHOQhzam3rOqzYFd9oz+zKo=",
                    WrongAnswers = null,
                    Passage = "John 1:3-4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 319,
                    Question = "kaZkQ4/7OIaF4q6iP7qLMDZrILIBM86uePVCMlwGoShkj3lA+As3nwD9CjSOYCTCLaPEdLGrt8UKSfF/yWCCoypKzdB3rZcZMyWGtuTuV3DHCHDpoJ6Qy5sYk8Ox25jT",
                    AnswerHash = -1094548753,
                    RawAnswerCount = 1,
                    RawAnswer = "CyaLg8V/Fw0XOfLEAe7deg==",
                    WrongAnswers = new List<string> {
                        "cQnhnXFcH8qI3Xx55CezjQ==",
                        "n5H46FgszkLtRmNWciyhhw==",
                        "H0J496+m3mcpKJ1kzk8oxA==",
                        "Vle2KL4am/xBxIf0ELK51Q==",
                        "l04AfYB2mXRYKZOqraYpSA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 320,
                    Question = "gDViSuCKdvz1dEcpa1bSd11Q9fa+wjc6pg/9/yHppBUq8/SEfdjg+0UzE6HX28tM",
                    AnswerHash = 1784745613,
                    RawAnswerCount = 12,
                    RawAnswer = "/u7Kp41CCGGFGhkFxsRjcLu6C4xIFQExMcDD3VdnJlSeEnP3ZEL1g05Zp+KZfy2Lq+a+HzXGBXtEzfFtep1wOvDZ6bxfdXqFw2V4wnRpR9c=",
                    WrongAnswers = null,
                    Passage = "Genesis 3:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 321,
                    Question = "fOZqLKm15GYjnqt8wQGVMXQsUcs27JmV/TL16KhZAUqBrpterCeCbYMt3CLgtxTDk/TQ4RuJkDZcCYbE8Y+Ctw==",
                    AnswerHash = -958445702,
                    RawAnswerCount = 9,
                    RawAnswer = "eoGgmGX7czMioWbXlbej3RWo1cxiP3bCHOcQGTcSchjABHW6K0/wPGsf52+2Lyud6tn7pFJbnB25xUBNCsad08p38j9MPNz+n/6QjPi9DCI=",
                    WrongAnswers = null,
                    Passage = "John 12:31; Colossians 2:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 322,
                    Question = "m6Gd0bUgkEbOz66mAbxMU4/GjuHIdjxIllQ61F2iHgkdJn0Xo6a163wj/qSTrWQB",
                    AnswerHash = -1118719666,
                    RawAnswerCount = 13,
                    RawAnswer = "L4cYIZwIW0L5cg9IFBzbsCMJFzxClhrTra2uN3jQeNo3B/wazZrZwC/s6eraVZ41EzG6UD/WbuAPs73wwmEfhCCJKkcfvD2tpeQDEjbGcIZEr+w5BRvws+o0WhAEr5hb",
                    WrongAnswers = null,
                    Passage = "Genesis 12:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 323,
                    Question = "Grq9IKTRH6hSUbwPJIBXvImz6QKgWSFO/3yyMJM+cnQb1AcvHXdQ7UTPT7U+kJoRK8ckPOUA/l9vBzbJpUcFMR3X3j62F46YCC8ipfvALcRnTBa9Sm+yBQyVchEkVzPB",
                    AnswerHash = 493647672,
                    RawAnswerCount = 1,
                    RawAnswer = "vG2ADza4c20ErP1r8FetBQ==",
                    WrongAnswers = new List<string> {
                        "AKo2FLVhrF5wEkmxRrSg5w==",
                        "uf5emSdHwZjKISnWGfXswg==",
                        "nOLVi4Zr7PcEFCQ+eSOE/Q==",
                        "lfg7bXAIJa1sTkSzXXENww==",
                        "+ld5sn7L3A5NqwT92oVwRA==",
                    },
                    Passage = "Galatians 3:16",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 324,
                    Question = "4MEht1Cz1s0YSjFLIXYKkG1b6UM4rA9Vj3aw5MaT6PX4aaUSdhVMKd4naNCYfPgW",
                    AnswerHash = 405800613,
                    RawAnswerCount = 9,
                    RawAnswer = "LhjSvPXdGeeUjv+RrsBZW3cBdQ04279KtQCHL1FyNyKGbzAwbpdk0Lg7fw+Urkzo",
                    WrongAnswers = null,
                    Passage = "John 1:1,2,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 325,
                    Question = "6Tzh5sZsKOnd2iiZcfCqJVwnPcTsCJKPFFXMjkmM4nmprgEXGA9rw7I6da5zC0ldNtvf7V7VMdcT3ScVc46Fsg==",
                    AnswerHash = -1940657368,
                    RawAnswerCount = 21,
                    RawAnswer = "jK+tmEKvEkFlo0bD3Wxm4wXwswAUMs6O/RAwqJK5YqNS87Ka51tWdsDtXJeiB1S1Kc3vOOBVaEtPNToNc0Hx0nhhYFL953NaLUODWQ7mLfWUFsaqyCPJAj+8EJZUjGlAHh5oWuTT9i4+2wR/pX4AnA==",
                    WrongAnswers = null,
                    Passage = "John 10:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 326,
                    Question = "6qIyckuZgZfmKuue56YxGmyCPSLH7LRjmJUcbvaZx8a09hfTJWmfJq++Vu1n0Xg0/eLy2+0Ngt7P8do1NC4xXw==",
                    AnswerHash = 395009351,
                    RawAnswerCount = 14,
                    RawAnswer = "U+A/b078j7hUwkZQ0JGvBM6xmAB/rsfqU++O8qaE+nXKiuECA/tM8qj7slGvNSLKJ8x96z+tclpKuGlDlbJZ8g==",
                    WrongAnswers = null,
                    Passage = "Luke 19:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 327,
                    Question = "s/9exAAyICh/n46FCykp52Uui7wa2LniNpnPVDSxB4sWjcAb9UxszIa4C8ye0TFVuNdx8TsP0TXNqQLJz1S3Dg==",
                    AnswerHash = 885183494,
                    RawAnswerCount = 4,
                    RawAnswer = "++ziUO7/p5IHWhos+M1ScxCuc6P1FrBDsJHu26sDUcU=",
                    WrongAnswers = null,
                    Passage = "Matthew 4:4-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 328,
                    Question = "8FjC+vo8LRvF1vafezigfjcHL1nY5uhHoVtc+Oc7rXwEkp1r5sEab5s67IdCliRT+tuY2mNnQqHwo2ZI174TCA==",
                    AnswerHash = -952365688,
                    RawAnswerCount = 20,
                    RawAnswer = "nPKgBM4qLEI9uHWPEncm54mykUjAb/p9Pj5H4WaHmbv+GeFdIXWf8GPZTRrG86DpOi1ZKns3Wgp/kvk9z2CDp9CWzmylEazhXWcP6wjs2PbUBpPp9W+K9zV1S7A11eC2L5R8fCb9Z/8SKuHoL6o52mgGk7MeLoJWBJR1wCe/dLA=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:23; John 1:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 329,
                    Question = "N3wX2HJIUGC9MNXsV3ziTHWDaGGntbPgMb3HUBCgsJJFN4gY4f2iSMiZDwlnmxmLaPs+FhYjf3MhTZfdyxYrwA==",
                    AnswerHash = -774736742,
                    RawAnswerCount = 9,
                    RawAnswer = "181GfcRf9q8QkK4XLb/twPihcMNtLB94psDH+HxAdmcM8gO+utcjqJwApkz6bINy6wzwHuAYTn2dvWqF2ROdFg==",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 330,
                    Question = "Al1qyz0vIl4Ecwo/JFlMp0OInplAnj0ygS32vVuCwC6y19VNmBa3bCVqZFUEZHJ3",
                    AnswerHash = 1011926575,
                    RawAnswerCount = 5,
                    RawAnswer = "5VkM+J+QzL3tIZuuXnITCuD4O7XvkddNuUwHDHEs2a8=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 331,
                    Question = "Al1qyz0vIl4Ecwo/JFlMp0/yFCSpB7sSGxKP1o7GdKupoQqoPFxJSAMVtAo8lG+1",
                    AnswerHash = -1030998358,
                    RawAnswerCount = 5,
                    RawAnswer = "659lr1lnjq6WCDu6wEpCQ07rzPX8n2U9LGffZZMxIdE=",
                    WrongAnswers = null,
                    Passage = "Psalm 2:2; Acts 4:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 332,
                    Question = "W9ND4RKTqiZqFymKjpppxRXR65Ss+S137ZwEs6NzHpA=",
                    AnswerHash = 70577973,
                    RawAnswerCount = 6,
                    RawAnswer = "IHLJ60CK/+6i9RRkwUKJYUr0fcbSZe2PhuesDsaxQx0=",
                    WrongAnswers = null,
                    Passage = "Acts 10:38",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 333,
                    Question = "8DDIaVXjtMLotWQy6Bce8lUu5T3Ux2q5XRyyWDKsLyQLzc73uYmy45it8dLYZ+36uzgv2fxns7m6rdr3Xv+BdQ==",
                    AnswerHash = 171700173,
                    RawAnswerCount = 1,
                    RawAnswer = "0g5Y3zvtFxYIWgpUDyXAWg==",
                    WrongAnswers = new List<string> {
                        "0dZWpOkawJKRziEFmBm8dw==",
                        "hLCXjspyi7Zbnm4xIGrYxg==",
                        "j5u+DZNCkLVUGOz4GWHnkA==",
                        "DN9Ic7sQ4mVWKUVJWotQ4A==",
                    },
                    Passage = "John 1:41",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 334,
                    Question = "drcMXHaG3jSuZ4FhrEBprNCJAxo6XRhLMw+Srb5KUvqFG/RZ9z2HONDfHWx2d+klQL+GCRJxB8Lo0CRhRQHfxA==",
                    AnswerHash = 275836065,
                    RawAnswerCount = 19,
                    RawAnswer = "tSgGmAFHPZ/gK/8nua+LascDkbQsLSRjlUdjN6UXY336GFA9qK4kV8ENhoPsRAXeuxwR2ahVMTzGidsu5+BYo/QSB0RFQ7MtZ6Lu1JKWsuKMgH/ORF6d0tRS13wrxaU2",
                    WrongAnswers = null,
                    Passage = "Acts 1:5",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 335,
                    Question = "xapZPoFvrGKsoHKi8+pEPEiLM/fV5N5DnE9crBBrYeyRnM/5YsOT/8aEAICGOKdDyyyC06z/n6pEmCLs1YSxUBpuNxjKAFaF8f+sk1CyjRO9oYV9dQmYPTH0NN16fKlYmblHBpOenKO83Z3zArqMkw==",
                    AnswerHash = -1733789677,
                    RawAnswerCount = 1,
                    RawAnswer = "g1QygKjX2nIq/gjahyaH3zTIwUnnCYIGLnPDx0lXapA=",
                    WrongAnswers = new List<string> {
                        "EspYDxRw3rODtyr4Kg4u1A==",
                        "Siuo2FkjJM7DIrLUAfbIEA==",
                        "pNbArht92co7gmSFGMI5dA==",
                        "K4nlZ/qQWsnj7HdHdgGjNA==",
                    },
                    Passage = "John 10:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 336,
                    Question = "iwoPqkneCM95u+3Cuu2EVtQk+ifwBMiPWXGAQSsl5gdkhNBi1Pcv1Dxn7fSBSJXC4Uwq0iZMLpWJkAyqWwmP8yYqERoKaU/JxdhuJjWxg+gNpZhfd+Amn+nORKc1531O",
                    AnswerHash = -660790432,
                    RawAnswerCount = 27,
                    RawAnswer = "WOn9VPo5Z7wpuPOVmUWRk/TY8DqV3v1QiHV/fL/Orjh3opk+wWyZv4VDsGU4UKnhLkbfQVzHBR6YLuVenDBmwf+AoTfdzXdq7u8ePpCobrIBTQbRXwVhprNz2zCU/4Dogsh7XinTxeKvEGNvvLM/erzI+iaRX+GE/ATgqQNXh2buY3sREmM6tjMJoJS9bpNP",
                    WrongAnswers = null,
                    Passage = "Hebrews 4:14,15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 337,
                    Question = "ZeuEVwR3ADSp+97N4Cxv1WCwauSOi3GyTxv9TnHaj7h1WIceKR8hxccH8hwTOyu6",
                    AnswerHash = -259102608,
                    RawAnswerCount = 14,
                    RawAnswer = "KVboQWmPA3qwqRMKdsTtxzWXWgi+CU58VgCDqg4wwmu+e1azUiwSzgYe4/Z+b2RXjJLxD3zWBEekDP4waMx8nl4kW1QonCSZct9UU/XEt1U=",
                    WrongAnswers = null,
                    Passage = "Romans 1:4; John 8:28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 338,
                    Question = "n39GHnGegdHcv3FiZMy5dBj7Bc3EGmM+1bqV6+LJcjveLXhb6ISIp5Sk3oXGVT4zeJGTdwr+Tw13yGK5mYmgAqQNbOpzZ/k54YTbv/rZP8I=",
                    AnswerHash = 2077695645,
                    RawAnswerCount = 12,
                    RawAnswer = "2GiKZef4H0qPV15LtWrVbtq21tIsS362BhNK6qwZSZoo661vsKfyj50fqk7Eg+RB/tUtAVDxsJR6N0uda2ojWg==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 339,
                    Question = "HgoAvOvw0InqEUWqK0QiI3PubhtnG+fPXiKKuHPfK/bNfKixUJtPDeVh+/6nLBW15Rhatk859MKjMu3B1G6K0YLRI3ep6cbYXQeUbVBWEoQ=",
                    AnswerHash = -900994225,
                    RawAnswerCount = 1,
                    RawAnswer = "vEXc8kj8o0HyQ/D2Nis2Nw==",
                    WrongAnswers = new List<string> {
                        "nD8yKvwyFgqGhMdY6Sa9Fg==",
                        "IWCmgRolLEQyqQ8OLkAmxg==",
                        "Vle2KL4am/xBxIf0ELK51Q==",
                        "OZx416Mh+vhH+A6kC2Yu6Q==",
                        "1MoWC9zjDXPEFjXlwExqjg==",
                    },
                    Passage = "1 Corinthians 15:6",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 340,
                    Question = "9qPwVm9egZL2eO3HGOqyghcemNyBuw3xmMJ/hy1CDkSJp636Pkpo0HjcT/F3d7DEZXAYQXoc9phj3LfHQnZuc/eR+eNA9e9uKNid8M5b5Hk=",
                    AnswerHash = -986719892,
                    RawAnswerCount = 1,
                    RawAnswer = "3ajFZpaITM9WK4XnB+bdQw==",
                    WrongAnswers = new List<string> {
                        "7RHoKJbkJQkSKIcgEYRXQQ==",
                        "UJT/CAkXWHVEovXn+bMkAA==",
                        "SraHxnKVS9D7WrzMDOhhtA==",
                        "cFPaS3hPMUP7e6aqwDt/gA==",
                        "2GOHJedqyrFTF7pU/4Ukrw==",
                    },
                    Passage = "Acts 1:1-3",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 341,
                    Question = "uBqayjblkDPlye0QzqX9FRGTaA778EL/QTCkyCr+EykI63fPKMe5vXO9q/fS8KAW",
                    AnswerHash = -238345456,
                    RawAnswerCount = 13,
                    RawAnswer = "3krz+tp+5z7av1Vsnsjq6hmpQgQfdwDQghOJsTZzRdH2I3k+ILopeyhMvzOPAEFgIjC2IJpP6RTTROsC+xgwBMWOgS7PsYbU+u7G0k/Y1PA=",
                    WrongAnswers = null,
                    Passage = "Mark 16:19; Romans 8:34; Hebrews 7:25; 1 John 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 342,
                    Question = "STGSBACdEnJG3lhqEF5yAPhLFF+ZydrC/NvvQ+l9g0d6YNcdbUQK9O3xoaXWVyM/737p+9bW9iNUjzRt4xX1Dg==",
                    AnswerHash = -506584866,
                    RawAnswerCount = 17,
                    RawAnswer = "1yq7lvnThYLKAQX6zblzNilyYuST8dwTE2sToVXGvodT/TRas4tT3PSC26OSfFVcBZnjKgM+gtksX5aoRulLAkOdwQwf/kdyZ+j0iLefUNZbCH/88Sf1GR0azbi3zFNi",
                    WrongAnswers = null,
                    Passage = "Revelation 22:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 343,
                    Question = "yaDfY/iVYLV9wZy2f1Wk85q3PEsdpTjSbxqm27YqeG4=",
                    AnswerHash = -523657439,
                    RawAnswerCount = 17,
                    RawAnswer = "DmQvy0aeXetNePw/mtk+7BJT8rq4Izgb2jYV42ePEU/THppSX5f8oV/HG30dv3MjacTaeaR6lKxLOjRSBl1uNFxz+61fDszyhIXRq4flDwljDsjHFg1lbrojvWmtzEuT",
                    WrongAnswers = null,
                    Passage = "Genesis 2:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 344,
                    Question = "yaDfY/iVYLV9wZy2f1Wk8wpN1vSk2Efon7/2gIP8+FQ=",
                    AnswerHash = -1901499525,
                    RawAnswerCount = 11,
                    RawAnswer = "716VJByTZDGEFf7qnISVMYTOkiJdoxReiULZP3iDywq3FlAbIAlXRe03jAlAycIT",
                    WrongAnswers = null,
                    Passage = "Genesis 2:21,22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 345,
                    Question = "Lvtumn8E2smApatLHmQkN29xa4JJP6pcvx0d97K22qzMXTvxpMBft0UEsJ1nuR/w",
                    AnswerHash = -528501945,
                    RawAnswerCount = 19,
                    RawAnswer = "f3Djq9F78dX6N10/2zBPr6FFU9icvnvVf3IRnrEbr8Z0AQm7rFSHb/Kxyq0c9WbVymz3As8MFDjskTdNsgjo5GwEdrfTBroOvPjin4kUtGV6oBlBXYuBt7E6+OsCrusDyTJDiuVAiTF82qxFtWk7ww==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 346,
                    Question = "XYMcoZx2y2YyMeGw9bMKriV2LPAAVBTjYZCfPnXldVnZIIu1Be8N/bQ6TwGeWBuw4fcdkaWCvoCDCp3VhfuMSw==",
                    AnswerHash = -1239837697,
                    RawAnswerCount = 9,
                    RawAnswer = "hLpN2wLOCVaxZg6XE9sGP/eVR+QvnpvCHUkdUt5M9olEAKB/TS7UUURuwHhDsBjawU3286l1VVAoPWZC9q3lAQ==",
                    WrongAnswers = null,
                    Passage = "Genesis 3:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 347,
                    Question = "wujKiRXA6OSUtcRXQZBdz5Ys8XIfXM6WHi+UfcPS3UVXQgP1zVCS1o34FTEk0VLT",
                    AnswerHash = -1333334526,
                    RawAnswerCount = 19,
                    RawAnswer = "RbKhkMoyr3pckz+lIBDeT/bW1Q9faT4N+RW/XaR0GEYgA1dbBvPVlv2r6ZPBqigMaSQEEn1W/XgHZn3rYzbo/CWD9rd/+0oOKACk6cwCCCLC6Hj0VrQotM1V5vNdWbOB",
                    WrongAnswers = null,
                    Passage = "Romans 5:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 348,
                    Question = "alWpG0STw8FEcztzraTbuba/LCDVtfn0MPfM9VPtj3RiMYiC1V9gKz6M2m5228MfOykOM++TqlFko4Jvh65/Zw==",
                    AnswerHash = 1797582346,
                    RawAnswerCount = 15,
                    RawAnswer = "LjjA9ZrcY1ZGqxY8s0v3hzYupX3iRm0hk+gtms2XNSstHMYwciAMY00PHKX0bw47nh5tjb1ZJyE/a8lIFYvg38Oxe0pOILkTAES1t/TnrcMm3WUHRmj8GJQuoUpF/eu1",
                    WrongAnswers = null,
                    Passage = "Hebrews 5:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 349,
                    Question = "TVGvbQenWetcphz4FSoJsxkoCKA3h0q7YmTV1klMZcC+8z4lZnKv4hbxDwq/Y4Qa",
                    AnswerHash = 154351693,
                    RawAnswerCount = 13,
                    RawAnswer = "r0Jtz1S/q6ku1TWqMWMqUQ9ztO68NSleFvld4x6a1PbeIelI+AsZVtTzKt4xfTx2D5Tq5f2jTVC2fNRxeLhm4g==",
                    WrongAnswers = null,
                    Passage = "1 John 3:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 350,
                    Question = "Am295NsA8IS/OfFmP+bjTdZ1lJmwNDFUVcaf/oRdQJodRydcxGvxVVMtjdijCXV2",
                    AnswerHash = 1422860830,
                    RawAnswerCount = 10,
                    RawAnswer = "Q93qXXsBU2KAHaP9qCOT8JXy2AwakjQcvnF4rcKe8coYiKMvuZ2erXFFAJDBNB9J",
                    WrongAnswers = null,
                    Passage = "James 4:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 351,
                    Question = "/4XyN5KNoa+SR0DuhcqEo5VQKgm5cnewszTGSGVpUmY=",
                    AnswerHash = 1840793423,
                    RawAnswerCount = 12,
                    RawAnswer = "kQhKWmbracpLmik4HN6bUHy8xBzQmrDKDylL6DatQMV2wYT/9fV2/rBTKzw1uApaBbIMS0tNEJqPXpOGRVbC/gmWzaaOHIRx7+srzb4sgt0=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 352,
                    Question = "tdgfkPXUF9Ni3u+wBdIg/+ciUncwipNwQSux7MtErBNkXghgBJzQDUzq/XMnsVl48xg0Ds3SQkUxM213uScNHk8O+t5yIAJ7maoUP1iECJbKR03ImU48UTa3l1pLg2uukhaldNl0NpwoL4BDoD671A==",
                    AnswerHash = 1118958103,
                    RawAnswerCount = 11,
                    RawAnswer = "LVCBs2CN363Y9/9WcH8BFQd5h78NbA1NSap4vVSCn5P5l4geVqWOgQFC00BjtY0jrg5NRIGFnBhdooqa8PCwBP5NdJJ/MnGJSdqkEsO2qMA=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 353,
                    Question = "DIpseLXMxQ803pbyoQ9yXoL6hwu8pWCzoi2GMIFMmYHb5NSJ9LK/if3ojdNXx4d2UiTrWcPKIJPgB9rZFV3BVUyQ9i3k761q5hqOgZNBDoDaQmOJPscqfA8OzSYF818b",
                    AnswerHash = 1369597849,
                    RawAnswerCount = 9,
                    RawAnswer = "aKnnnmnj9Xgfd3Eeea9IJr9XsvZXj/eavyTp/NXYXCCkoDKJVZhWCeFpGAWa9gPQ",
                    WrongAnswers = null,
                    Passage = "Romans 8:31,32",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 354,
                    Question = "n4jRz49qO6C8MScBCDxAwNHRyTS1BNa47gpNbJJJbqZVqUXV8MkdczJCu+HsxG3X53qgbbVngYUl0gnMCE3j53KuAsIxF+ehQwG96OS2vTjCh+onTxPm19aHT4e6s+BX",
                    AnswerHash = -1074565938,
                    RawAnswerCount = 20,
                    RawAnswer = "fkP0kqLoxhO3Wv1DCBUCZrn5livPW79ZDX+wgQP6si4rpK0hr4sWDzhdG6+cMbvV0BwqBGnLrMAVT4logkn2zFgXv3PqesmS50PpfarlQuEZm6bmqyABhyKHwHhPFedKRG5HCf/RhPRXfibaODdBSw==",
                    WrongAnswers = null,
                    Passage = "Romans 5:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 355,
                    Question = "/7mFMfppVFzjQTa1eNn7LXLoPJpH07zz9hY+IbRgD8JK3TI74IZlO2++G0uUFSV4WuPTqQXcgIFLVmXFpOAinFAxjl6P+gYOG1WQNJKJIAK4x+u8Ics6aTuwl3t8fzvr",
                    AnswerHash = 438906885,
                    RawAnswerCount = 17,
                    RawAnswer = "zd0lYJJBmvL5tP8lVs6f6/fUbMog1r1Za+WH8z32mRlP8SA8GdtoVQRNRVkomZmp7OAMDujDl4gnpkiIKOnPsjlEaXffvx1zVFbIoqnrmk3fFUXfo/Ndfusgj3capKMM",
                    WrongAnswers = null,
                    Passage = "John 3:3",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 356,
                    Question = "zsyfJbyIPpXixuDcwSNGuwsPRtpQAqYvvvPjEmdkOh26YMBDPF/2mR1MgRHrsU0Z",
                    AnswerHash = 228581655,
                    RawAnswerCount = 13,
                    RawAnswer = "5sT4eIf0Ynj0AFYpHqCztOoN7uR/lFzO7XWgOxL47nxV2FzQlfvd1jA6//OLY2SNWxGC2Hmqc10TaOJ842xbQo+om4xUh2QpUcOZwsEX/wc=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:17; John 3:3-8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 357,
                    Question = "D8fLewQoFsOIQKxFDVpLPVg7OY8RDQDw3Rxn64OXzENyx4Nkxv04MSWfrvN1mSebv+s86AHWfol94ntIcAPjVt+enPRIAOpOzG0IV7woCYg=",
                    AnswerHash = 1971078058,
                    RawAnswerCount = 23,
                    RawAnswer = "1KZf6y8d6tJXRA7FSFJC4zs4K6ZgfMpU3qwH6mRGI2Ptjxs3EI3q4+FitPfYEbafqHSsvaTV6hxfINg8qE/7ykpA9vgMBN5c4qNyQQMvhpQLQEAh4wAc53EWCTpHbzaJdReLR+NSKMTHrOZ5pwLPqdi6zOTZlhzUDtaTdxm/Pok=",
                    WrongAnswers = null,
                    Passage = "Romans 12:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 358,
                    Question = "p7M7Hs3KiYcJNU9gpNpMH8UnUugMKsAsBd7G7z8xvcKKK9Vjv+B6UXkghuI/UcFJ",
                    AnswerHash = 40472471,
                    RawAnswerCount = 17,
                    RawAnswer = "zyGkr56c+jD99K27E7Q0mqx5OWsjOrXRcpIhC4bJnj9uyi0DUbwC/vUJgnHAIULiBGzaLj5VoX5GgORmite0cT9/H31F1DEoN2/NbWhLIO/kseXFtSfze4SIDpUUGeZRJ+w+zovplzxnhwQe63OaLA==",
                    WrongAnswers = null,
                    Passage = "Romans 10:9-13; 1 Timothy 2:4; 2 Peter 3:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 359,
                    Question = "tdJyW1u4n9vdBQ6HvZSgDn6+Hv92jYSx6c1ifeXAv5/PaRxBdGFHxf+u3Hxcv4uBL6J+5B0gHSGnhbTkJn9D9Q==",
                    AnswerHash = -2103080468,
                    RawAnswerCount = 10,
                    RawAnswer = "unREhDja0Bk4+7fb7OYXNYZksknyAaZt3qG4iTJgiel8q7qW2qLvkTyrsj2D7FtyZvCgqoANTa2hTcAWs4L/L2bLJR+jPem+yDnmeHQPgRU=",
                    WrongAnswers = null,
                    Passage = "Mark 3:29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 360,
                    Question = "PwNVWaUVoQkfZkFikH0QnUEbcX8BVSQlN+p/aedVx4b6kxLN2ZOphzenicbf3CSfjPthwQNxxTvnUw5LLk13Fw==",
                    AnswerHash = -746013290,
                    RawAnswerCount = 10,
                    RawAnswer = "8n8Gaua/fuIBmd0+EBu/lMLKJokGKUN4nf+wnkcvLNhT8jev+avBzZnFuC5SvkVQ6MoNKolZqS5J8ETlpzcyYQ==",
                    WrongAnswers = null,
                    Passage = "James 4:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 361,
                    Question = "74D07sO9AlliBNEo6NiOPLBxw8E2q5HYQqCxtF9JqhohglPs3W5oGq3pNCq8kdibDhoLPOFYUYONrKX14USy1WsEw4C3RgeJbvrk3mVK3LUhrWeOfcDCayM0vgp5sIsL",
                    AnswerHash = -28709621,
                    RawAnswerCount = 11,
                    RawAnswer = "okvF7V47hvXI8x2ZgSxN03nRr0ksGgxIZSAw/BJgS/EvenUAdPIpzC62UpQAen09",
                    WrongAnswers = null,
                    Passage = "Luke 18:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 362,
                    Question = "1yvCFF3T4GxLAO9Wr8qVhZnovto7FvBw2JmfWMuaPsmTlrs/E+j7iVZcLXR+ocoU5OzEi7eNMAxZ91Q0KGjcytx1HnVVQ8/MTJylrPfHtMI=",
                    AnswerHash = -579860720,
                    RawAnswerCount = 21,
                    RawAnswer = "M6s/CESR8Wx99pZK6l8IkKs6L20lo+kDAdbLWf0/G+b3bW4TZZFlPmeIRa4bHTEZg7ipxxFyQ5zD/plx2v68Hx5J12MO9ewuHWZoa/GfSjKc2x2WjhAagep1yRejw4ZW7uKMzUWuWlIt1izJ0COaKw==",
                    WrongAnswers = null,
                    Passage = " Luke 15:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 363,
                    Question = "n39GHnGegdHcv3FiZMy5dKUjg7Iqzey3i5it+ikmIHjJN4vfGdJzxXLVpOMYwLmh8YZCptEd5SrjiNUf9v5yzQ==",
                    AnswerHash = -676286739,
                    RawAnswerCount = 11,
                    RawAnswer = "2WJ/K08QkL/RBSgwT7rFNBDnExH1JzLBe6V/Cti0kX8cqWEXrgg66J0YL8BoxVXCP6Kux858cCkunTOIpSeCdQ==",
                    WrongAnswers = null,
                    Passage = "Hebrews 9:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 364,
                    Question = "wujKiRXA6OSUtcRXQZBdz2xc/Ie+nD7xf1XTMr7feNlfsURKq91hJWxoPD+afist",
                    AnswerHash = -2072996474,
                    RawAnswerCount = 29,
                    RawAnswer = "Vo+Q8ElgJZ5mblOkFphuyN1QAgVXuIAuMaYSFj9mMOS8RJ73avEG4AVajO4SP7/T7GY1EgdOu011JGC9gOfQ02E9W3oB3Rhjith3fqgfWFqidGCLzjPydDHQzEo0vZn/OScPQ1ZU0yvzLpx5ATGSev9Fh9m1+0FAXygCTbfUZismGFOZAfIqmsX4Zp0TlCTJ",
                    WrongAnswers = null,
                    Passage = "1 Peter 2:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 365,
                    Question = "n4jRz49qO6C8MScBCDxAwDt9szo1Yr0eBS9a4sSUYy38rVyV1YcPKoCqdhVFMI1DDr6HYGbv4jIcrKSPf1wJtNiNAZRXXU2ndUs5Yw7Zh6c=",
                    AnswerHash = -1907254976,
                    RawAnswerCount = 23,
                    RawAnswer = "PzWSSlh+pVFFyeZLpLsRM9mpn7MWQovZXzX90jOcWp7F6sbY/TLgQiHCyF/ZuVewZntq692klEtGop15gAoEugYSjgxGjuDAMDothGnlNWtbJ1/mPMVVvXDjhIzWSnSP0xOO5QPbsZuSgc08IpKP20clHFL3PJsYM7r6tgNtrmU=",
                    WrongAnswers = null,
                    Passage = "Romans 1:16",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 366,
                    Question = "n4jRz49qO6C8MScBCDxAwGV9oWyyyZyFRGM5DLlKcwWMARz/qhKq2zfyDyjie+bPo6RcQwP2b1OW22mnuLF7rZtWDUJjP7IrAIrg7Ke90xg=",
                    AnswerHash = 824499047,
                    RawAnswerCount = 22,
                    RawAnswer = "grQvbbXqatlVfeNdqnoIcgaCliwKQ03Rq8bQrFaULYx6oIhV55ZIL0RDjhuak8WouK33H8OOdb4RUcHriIB/8LOFmq+BneS+UuHzby79EIYp03wKDlBBMABRSXvLNlyzz1JvxGniw5Md+iYf+yJ0jQ==",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 367,
                    Question = "OQKVuaWhrs3xMvytUScDoHCFLE3OsCFYAd1jzZAVAhwFq92JjvQD5gJXUz0byqh5aOJwxJ7UGO0tOcvPznds0g==",
                    AnswerHash = 1220091310,
                    RawAnswerCount = 15,
                    RawAnswer = "MVJ+7qWU8cK2D8cxUUKmXeVegsR6RrKg9b+9F7IjqLGjkXI+IcJXcw1SE0j7D+4sADNvwnATaG5I/NotdNqEpYMzkh0MmQTHIzm7G6+tiW0gobYwsI0g2wHEGNCyrkvv",
                    WrongAnswers = null,
                    Passage = "Romans 8:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 368,
                    Question = "DYy4rH13/9H1q33dVkWn0Vz+Q4NDtjZDJElqOkt02A9vVXOEGXKcXR+Mpxv1n9XzYpl/znUWz2CRRhiyibRn84wDsDhYfAdMAGoL6qhj00Lvp8Rq4W5dQ91DnXWtbEr2P0/8F0x1BOmeaZlntIva8g==",
                    AnswerHash = -393120406,
                    RawAnswerCount = 14,
                    RawAnswer = "xvaWfZBapIJw+y0UKTfkdp/bGZNw8cVTHpCZfxWOxE98ge6LEiQo9Jj6m1W+bPlV+fa/AX+tSdve5vLsYUnmWmiP9+z3rQ/ipDaT9QedgHY=",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 369,
                    Question = "HIBtGMRLRPSkPFcNh9h9I9+Mx7ZgaJCmhczgQu6RZ3w1zLR7GOMylcDKcmGbFdKu",
                    AnswerHash = 185901805,
                    RawAnswerCount = 18,
                    RawAnswer = "NtGaFZ8d1op46TPkZ4guUcwAscQRiOqi9pv5WiLMm41pxqkkAFtrSWw0nnYGVsBxd3x7SPD/Qx3Fb+QKzWRy9oIHWsLyelZFh9nHbBKkb+++ta/OSOc7/BwSzghyTHLt",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 13:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 370,
                    Question = "KIiQ3L1J/3gN0eiqh+KC2QV5gwRCfvBHhUdC7eyvPg930EqBr6zVxX6GzaV+3jJdKRM03bxTy1IfBoVfaCdyy6JB/I0DF+T8a+gaSbF7q0k=",
                    AnswerHash = -1360992800,
                    RawAnswerCount = 15,
                    RawAnswer = "7s/6BwEvUd/jTgiU+dXmsHiJVa4GWj38fsTe++ZGBDIIGjVXPJxTVGQKUNhkvY2PhAndcRNBFwXIH5fSy2XqFHZ0C30BrM/1hm6tGbHxJnsWMCIPacs2SB8dX8kKKxRd",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 371,
                    Question = "qMgigGcbzUTSPfv2K5UmtEn36tykPbBSjxSPhks1JnjWJRxmQ6mqXT8usIOFlm31k5zuBfU2pN62J4QKhg35kCT1FhJDesTGGIiNaX/n+/M=",
                    AnswerHash = 95820059,
                    RawAnswerCount = 21,
                    RawAnswer = "rbq91q5MVXMoDYbui5UW7QU/zzlBUq9incoIJla8+X88oE/UeO1K7RMMl45jWgL/jLClqdA6Oj4TPRCSrecRICj1iFkRXz1963k28hq8jYzXxdhUlNgtadcU/+iDGDhdOMupHQ2WUT4dhufigX4qTA==",
                    WrongAnswers = null,
                    Passage = "Mark 12:30",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 372,
                    Question = "qMgigGcbzUTSPfv2K5UmtCTL4FkiE9lLiIH514edjviUdqrlcWvL8Ekz2kr4CQbqlgrromGAJkmOZrV08KEeYQ==",
                    AnswerHash = 1098782383,
                    RawAnswerCount = 5,
                    RawAnswer = "3MxjRyw7+gEKA8PgV3xyorcRUVvnuqmuJnpekvvSG5o=",
                    WrongAnswers = null,
                    Passage = "Mark 12:31",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 373,
                    Question = "qMgigGcbzUTSPfv2K5UmtGhzjTJnkMg1tACGtjggiF7+QStEHZJpRKOdO14kvpLWtmZoH+hJNcPuyYkSA5/lVg==",
                    AnswerHash = -1172756888,
                    RawAnswerCount = 14,
                    RawAnswer = "jaf9N+jCiIW6bggo5bTSD+36yuS9+eHdfTzU+FwvMEk1UUGK5G2WIlef25LZGJHHtE89Mj/NJfnUxmhu3a4flVDpViMkZDj6OvWYVMs4CB4=",
                    WrongAnswers = null,
                    Passage = "John 15:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 374,
                    Question = "drcMXHaG3jSuZ4FhrEBprPMigs9XwuD/cHh9yzjihi84yKl4hnNA4p/zg/Ua2r3K",
                    AnswerHash = 715714736,
                    RawAnswerCount = 7,
                    RawAnswer = "lv+dh4u3wd6FU30MQUgYQ88nf46ARFRqihRb2fVzbNy+z31iu5GNVigkvq/3FNGO",
                    WrongAnswers = null,
                    Passage = "John 14:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 375,
                    Question = "qMgigGcbzUTSPfv2K5UmtMC2F0ON4GJtm3wXNguMQ8jzTdS2q4wFyXfkMUIMZwKbuKPVqYNlHjWP02FY1tQqxv84EszLvdQ1fFeTEMj6kKc=",
                    AnswerHash = -672047562,
                    RawAnswerCount = 15,
                    RawAnswer = "AplNLSDnMqtzPJmtO+K2VtbmrwVkKNhTGHeM/MGbBuMEX7g68iuZuCSLxIds/wndKcXRSbpQsLY/stjz2gqmLzFaOpCD7wo5xlVditQ5hj4=",
                    WrongAnswers = null,
                    Passage = "John 13:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 376,
                    Question = "5w2ZRB2uGPX+SJgOUQgzj9lM/yoVO9JdyClSIkXyzxo7UiFzidmh7KyDDm6UXitV",
                    AnswerHash = 480269744,
                    RawAnswerCount = 25,
                    RawAnswer = "MJfAgb346uaUxLtKNt5zBJHGPJsfRPaDM4vWYyUBewbznFfQCxBfbnC6qUrFmvRHo0HJ/AyzLwkmsVqWL65J1ZVMa0iBDWo3kl6I/bIHM7TzzflwlR3aQSb6o+tWnK1IJoff8CqlJyhm4BRmEf+bb8+0336BzGAiaX01p+cdXsw=",
                    WrongAnswers = null,
                    Passage = "1 John 4:7-8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 377,
                    Question = "n4jRz49qO6C8MScBCDxAwAB3YIWZMejv662Fo99QWPaSHaqzpIU2iNUdxLzzB/Ooef9/Awayy6y/HGoJshW2f5Xxrmi8RP0EHav0w+WFK2DYP+4Uvebw2sjukZ/dUXxl",
                    AnswerHash = 99097534,
                    RawAnswerCount = 25,
                    RawAnswer = "2geNV/bEtqdbW54LsMyOP8H6HFpcxvEhjMvFThdqzbD/6FzSnnZwFRkXC75PiCFZWDaD4zn5+qHLl6zD0RaD2WJC/jhm3LIGNSVM1NChz8A5KMpWfvIoHyOAgf00SvJHLs4eNC3gGV2adHk9xQO6FUB6fD+Oc6TDqYbaIL0Ku5g=",
                    WrongAnswers = null,
                    Passage = "Hebrews 12:14",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 378,
                    Question = "mtcqZcE43V5EOdruW2yUtAJ2IcnE8YDJgV9YcjjqNmIcq91HGp0JP4Yiy0odgZoG",
                    AnswerHash = 1617809664,
                    RawAnswerCount = 13,
                    RawAnswer = "MdqOHtjw3b1NeA4Xxh1SAa5iihnkBSFEbW+7yrXpVUZl7qjvAZ+iJNPUU7R854doD9NAS3goRh2rM/S1PMQbNrQHkTxOHEHsEPy90HTxORQ=",
                    WrongAnswers = null,
                    Passage = "Proverbs 4:23-27; Matthew 12:34,35",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 379,
                    Question = "NNU2rUGTpCeqzoW//HAW6IMDpjByKpbBuJpTSYhKr8yS/XhpOYztnYbkHYBamWehCqow7pGGZ7gaVz9QC9k4fnkotgSfHmD9+7/yaMkX76M=",
                    AnswerHash = 1981727141,
                    RawAnswerCount = 13,
                    RawAnswer = "m4mXeK2I10ZykmRu218XbeVSCddZOax1KQp7LCO3q3a3mUVcIb0AreZCQdqhKcDjpazTAlPy/zYUtrfmqRIo0SuRapZ5InI/ewRmQ4Capi0tWgbqswLBCbdrchHBChgW",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 6:18-20; Hebrews 13:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 380,
                    Question = "P7K8LAcx69MnP6nE+gzDK6/znk5JrKuXSzVKuOwnPKsjKm1ZCz3hgfMx9RVyg346gbP/DmIFg/JoVoV/L6VWog==",
                    AnswerHash = 1411943934,
                    RawAnswerCount = 19,
                    RawAnswer = "scVR2u7iT0zCUv/dEFmERZQRjUH1SrFPEf03CaCDaBv2/S9ogCb0awVlJ4j+9LGjJwBtBG0pGVPzLgP81s36HWtkAGmiURcZOTUy1G4BqWd1wJQN92e1Ep/ByWeZHs5b22c6utdqPAVTwwQcTrS/1w==",
                    WrongAnswers = null,
                    Passage = "James 1:22",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 381,
                    Question = "C8Y0oebp+nTMR2T2kH/J95VaYUjXSKDEWO0rViI1SmHDRK98hH3yGcG5x1OxwINM",
                    AnswerHash = -562217413,
                    RawAnswerCount = 12,
                    RawAnswer = "2QDoNtryvgPl8iw1FSzaQQShukdbE4dZlcY6DNiOwyn6i0ANn78uDS8u4uuWsHrpEPeugORAO1HaS3Ixbt0d3KpivytQVUBAYGthcdXBJ7k=",
                    WrongAnswers = null,
                    Passage = "Acts 17:10-12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 382,
                    Question = "O4/EA8YNV0p5bt7sCVFzzgVpFjBGWLoTZQOStDs3wNcjI6IRLSlgGn8kRr6jLBcWHKjkbL+ockFrWJRUfARxD8TYvPjtLwb0YlYVYyLYIk4qvS5IlV4kfKos2gHfLl8O",
                    AnswerHash = 750549615,
                    RawAnswerCount = 17,
                    RawAnswer = "d6MuJWampdGqMmcHHuBpQrCNjUqQWyqg4Rzvez59lypkUT5oMZpYYPRGYB3OiX/ME1TVsQLwEHd4mHz2HV8Cbbi2je//CUOV0Lso3KBsyut/XFsyEYe10GEv250gwEX3",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:18",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 383,
                    Question = "W4CqfgUHUKomTkV9hBXb7nTUxLPTOO6BJjUreLAyMkne7An0bRYOosHbfRhAx8MDePKjLNMggj0Qhiy2Jm7/ewv+sRCVf8/vloGWKpomxnQ=",
                    AnswerHash = 2146684396,
                    RawAnswerCount = 1,
                    RawAnswer = "u4zFHMK5AHKeRLd0C21T5A==",
                    WrongAnswers = new List<string> {
                        "Gw9C2eh8rpQ6bafGbeIc+Q==",
                        "mqg/kH+fYmHO+8wZYgiiWg==",
                        "DoD7GEIlS71EmLSCbv0vDA==",
                        "VVH1MKdq7hPo2m4Zwmzu9g==",
                    },
                    Passage = "Ecclesiastes 12:1",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 384,
                    Question = "ea2BJTGKi7cV2IMZlYhpMLjetSaFklEgFtXxiP5f3gzvFoC+59D5m0iXKQ7E11d5",
                    AnswerHash = -1606377358,
                    RawAnswerCount = 7,
                    RawAnswer = "UwEG+Xd0CIupcGjBsysGC8kAuP8VFPwkYIV7P9vdC3lxPUG0URO+kWwbF/3PR25plhn3qTefbLE1FvDl2NW2lg==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 6:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 385,
                    Question = "L6asiC7nLhiALWKe5Ua3kE09z/T2KIpXcH5wmCn3D8w=",
                    AnswerHash = -191693348,
                    RawAnswerCount = 12,
                    RawAnswer = "W+3MyHChxBV5aP7HS3N/r9WVHBpxLO2kvNrkjL0yoYAEWwDg3VlO2CWmLq3nxKlJwocepHHCtP90VDGhlziJeg==",
                    WrongAnswers = null,
                    Passage = "Matthew 7:12",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 386,
                    Question = "n4jRz49qO6C8MScBCDxAwM6sA/+emzOA5C2jlHJmoPfRqOuJ5smzD1n363z6I2MxKuiXEg1ykaV62Q2FCtynZiQ2WcY42aSouoBzutMY+dqIrOBnf1YN35st98kkkWlwKBwTjhkBiZuV9VV2uocDE6RbhGl4ocs3EMoPGhkrPWo=",
                    AnswerHash = -464946957,
                    RawAnswerCount = 13,
                    RawAnswer = "GOx4ppFEcvr7+0L4POZdwocc3JJqQt80w/hUx+YbfUdPE2LCIgAz01XeL/nY54ykjLtnZvWAdlszDLYHpKl518KeWIlPRRuBkXO7giu7c/o=",
                    WrongAnswers = null,
                    Passage = "Philippians 1:21",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 387,
                    Question = "WBSjyNLX0Sgz0FJm2j/m0bJPVcsVT0fhyG6OYe/2JWE5ushRgTmNycMXHz0rMmdJ5EFRoIL3+qUn9VNlqTGgX9MZxX0/Jmz28ThshVxUbkk=",
                    AnswerHash = -1543766652,
                    RawAnswerCount = 12,
                    RawAnswer = "P+NsUbAE0aWnBkDsp817x51ksSbMDju/kgJ3IGgaJiW9SpI5540ZeUYRtbCfU0O1dmOW1slhhZE/k1ynNWg1Ex7/paY4Vjw+YA8WrRFTlZM=",
                    WrongAnswers = null,
                    Passage = "Proverbs 15:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 388,
                    Question = "+0m/Z7nEILVNbNAS0JWe9bHlP+ngnpulojDHoz0uBkYI7guYJM1+99y17YfHvYy99rCkJ1fTDCrQ4TCoUNBJzExR/7NgUFpn6M/Aok6YS3CSnzvDZ4r3y72XcXhwssr7",
                    AnswerHash = 1956003992,
                    RawAnswerCount = 10,
                    RawAnswer = "k6XQOdPNEc0PEB1rx63YTrmFOIGRzS3+fQegqFCk93YsVM/dR2fzbLe56Asb3QDD9nzMU3dCfcRSFOM/N48/zw==",
                    WrongAnswers = null,
                    Passage = "Romans 13:1,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 389,
                    Question = "+0m/Z7nEILVNbNAS0JWe9W3t4fzbpRMbiiN4IlPQa5rTOI9K+FiY0WH7e5acDVPJj5CB7omOEaqAAbSS0VALHpDSElMuSRk02+sLWjCHFLl+IipMgkwA4iW8mx+KUsOE",
                    AnswerHash = 1481193174,
                    RawAnswerCount = 13,
                    RawAnswer = "k6XQOdPNEc0PEB1rx63YTvccFB1dLHlPMxmd0mEWTZxY61L+OLH9fzdyVXvoq7B/ugcHFzg4jNHgUekFS6RWLfkgABT93aaYAgDcV/8rDEY=",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 390,
                    Question = "YKwxqkIV++bfxISKFkD84n5PSEPmSwi57gE/uQAo7kA=",
                    AnswerHash = 1000749596,
                    RawAnswerCount = 7,
                    RawAnswer = "GVFbHHRxR0imF8Ij96noWDBlzvpXnuWRBxfwDztIfO0=",
                    WrongAnswers = null,
                    Passage = "1 Timothy 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 391,
                    Question = "AxyxHK0GNnMaggSEaO2QRodgaxKVK/f3Y9XHoNhrkA4MUR/NP2fdldkRL/3bs9DM",
                    AnswerHash = -758989903,
                    RawAnswerCount = 1,
                    RawAnswer = "+L5gCzVFVVqSJSEuEl5VC73pGunVGPqEcSJDSNHY76o=",
                    WrongAnswers = new List<string> {
                        "vSWh2YqMRCu0ecmeZBWw8Q==",
                        "rvlI10XerbCVEEt4xzabRw==",
                        "fWh1LmSIL8he/k05OGP7DA==",
                        "lnR6IHAjRub6GcfC6k3Czw==",
                    },
                    Passage = "Mark 16:19; Romans 8:26,27,34; Hebrews 7:25",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 392,
                    Question = "LH0x3hwDc7akL/Ft2igdYLDq1Li8pE/DGw+LedPTwaq5RuX1G6sTDf1ssRnb25wbmuNwF4Yr9A4G6UN/f1lM+w==",
                    AnswerHash = -1352938780,
                    RawAnswerCount = 10,
                    RawAnswer = "1XeNt6mAZND8iWMn97umbYutBs7bZJz+OkOxJPaufA3kt1CAPaDOPGKQzsMgvt8n",
                    WrongAnswers = null,
                    Passage = "Romans 8:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 393,
                    Question = "NNU2rUGTpCeqzoW//HAW6A/agATLHwDL7xIaZyOd2lczir2b/kntHn1Xr+MlmKYWaX0PrgD+G8cSCov32yVpA7BAJVrbfYoIVr1P8WsuuP4=",
                    AnswerHash = -1055217248,
                    RawAnswerCount = 13,
                    RawAnswer = "jiUCYMB4c68Aw+L7MZr5upB7RNN/P1g7Xmt9IRhygu3J5QPy4t0woP5gV7ZyC+2HjDwoIHkW31c5FrCORQmN8yPe7KXgJg7i/bgX0ieAr/4=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 6:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 394,
                    Question = "TLy+VhfxRv+BF7mldnPQpK7hO8/85Hh3zLZa1HDVW1A=",
                    AnswerHash = 1674847617,
                    RawAnswerCount = 10,
                    RawAnswer = "CK99SOq8cFIuokSBuxCNteqPmDTxTaw8nCRaIJzlsLDB3wvE/0FQ/N3H3A6cPg7z",
                    WrongAnswers = null,
                    Passage = "James 1:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 395,
                    Question = "O4/EA8YNV0p5bt7sCVFzztDhXKSGlfko+1YcufkvA/aUaqdKI6ZWHCCq9+t3BFF3b+RTR4HBBB+J49ytL4dWzw==",
                    AnswerHash = 1688303032,
                    RawAnswerCount = 15,
                    RawAnswer = "+X8TTdL7g0mpXudGec5TY1FJgtxyvwm3dA0qbjmAgf8v6gzXv6pbGsk8yR7b0D4rqgM5XYWHpm4M2SMhOo6Y3pQlYDMwOewMdCXpwnawBTiWyRi7BUpAIjo68wepqfeIqxVXHvF+z7FrbdUN0e32hQ==",
                    WrongAnswers = null,
                    Passage = "1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 396,
                    Question = "HIBtGMRLRPSkPFcNh9h9I3eOMTK5yejaLQmDmnCvBjK/9IwiFpiedLds2764fyOq",
                    AnswerHash = 290899996,
                    RawAnswerCount = 7,
                    RawAnswer = "EUB8kNTtU4RqX7WXY+w8W6S2yc1adsPz/QoqZ7+iPFng+78k6btW08Qs8hO+Odqh",
                    WrongAnswers = null,
                    Passage = "Matthew 4:1; John 16:33; James 1:14; 1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 397,
                    Question = "B5I5YXUBhUDr2uHFz6qAdqXhm1P9Yerzy9dMPJrj5uFOZQGZjK6GE6EvGMCowr/K",
                    AnswerHash = -808246367,
                    RawAnswerCount = 11,
                    RawAnswer = "tdjZD47rlm2GROAH6WoM6uirCcRmHbljdKpxm8bzVN4JV5RWLa2QuQF6vlkFT4peiK0xoirA2mdx1WOf01oW8A==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 398,
                    Question = "KwnmUZFGNEWn+RQ1CPmFI8T1vUkm5qiTmPK58QRZFYCBcRwGVLrHCUXlNq1O6EwObiXNFWd+n/ffQ2IzA4nHZ0jofZyrnOqIp8LE7FhDVOcWMfgIb0xBy1+qOFpGQwBj",
                    AnswerHash = -1869973056,
                    RawAnswerCount = 1,
                    RawAnswer = "X3kvk2rTlG5mWOAlsJ0Xf8+5KrNWWhym9FHs7dMIUWw=",
                    WrongAnswers = new List<string> {
                        "QL/2bPN1BYrVNCGaRXBiOVH8hARjlGVu+jiQ7kVj+N0=",
                        "8s7OJzqeubjfWhMe1mVA8pzIfB93UAi9nqyMAQrvGw0=",
                        "WbtrfOPy1hEkZOrPRWSzo6+gDcyWAfz6JumKKHavq1o=",
                        "w2UZE5bsl8FBbkOWfL/GNXwWT2BslRF3sqHXnn+7QL8=",
                    },
                    Passage = "John 16:8-11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 399,
                    Question = "cRuefZSPOmRwZzCk6CqZpLwIIk/oXO96cZXAjAI8qSH86LFzDra4x+/ppeTmjjYVw1QTyC0cw/Bo2Yd/baKlmw==",
                    AnswerHash = -929471417,
                    RawAnswerCount = 8,
                    RawAnswer = "OdfU361oYKq1mgDKdKDorcvSNZkZonY2UdrebV3RNbKX7Q/3qswZeb/h948Wa/0d",
                    WrongAnswers = null,
                    Passage = "John 16:8,9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 400,
                    Question = "J+1CreXqcnDBVAJqDYPJRVtDfb7Z4viEK8n010qe1SyZSwbRkf9wiiM3jPnBn2BZ",
                    AnswerHash = 607498426,
                    RawAnswerCount = 1,
                    RawAnswer = "HfcMCjDaELxpnMBl0NLQOA==",
                    WrongAnswers = new List<string> {
                        "LF/2kehpUmEiowBtibYyhA==",
                        "iuMtLueZujMPYu1mdy3Iig==",
                        "uf5emSdHwZjKISnWGfXswg==",
                        "ZOb2zAZc0dIJ3b2SzeNzLA==",
                    },
                    Passage = "John 16:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 401,
                    Question = "42gQKc6fPOOOpKte973ARNGCENrRijkKOoa2uoZx6qfQtg3+OyxIRM65bzKK1kNfcP7Wvf6ogGh1k2iFcsOCuIX99OitxfGPSYv6Eitz+yc=",
                    AnswerHash = -1317747854,
                    RawAnswerCount = 19,
                    RawAnswer = "ka+ArWBGr4CJT1tINn8anr8bw86LG/JhzceMMnp1y0SzrTCo8UUFQAn0gBxdfdqun6TG7KiP9hhOd2rAdZUhr4reIT9lXxWUlxurAPTiSNcxUuHBE7o5uQ+coEXLYsaTP6aoT4mHBR7jr3HCbBxDUg==",
                    WrongAnswers = null,
                    Passage = "Galatians 5:22,23; Romans 8:5,6,13; Acts 1:8; Ephesians 1:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 402,
                    Question = "+L5gCzVFVVqSJSEuEl5VC0iCGJqMHqyOX0H6+NJKsp6g2ZCiRfd7SOaeaTC+efxb",
                    AnswerHash = 684681368,
                    RawAnswerCount = 1,
                    RawAnswer = "CNSuoskWOhoLiubo/xCJqA==",
                    WrongAnswers = new List<string> {
                        "9q8cL3yEcS+DBH9PAUJYNw==",
                        "hYYpMDqyz/OTKO9ROmnGRg==",
                        "P2xGK5Gv7+IfhLGhXCJy7Q==",
                        "jMCv9qooi3hY6yE2oDFmsA==",
                    },
                    Passage = "John 16:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 403,
                    Question = "PIAHhXCRWr4L4Y6ExuqeX/+fhfPA017XXzX3ZHmmU6AJf6gvwSTSB18+pnx8xKQrcmr74Hv5y09HabK9l9MkEw==",
                    AnswerHash = -39738158,
                    RawAnswerCount = 14,
                    RawAnswer = "5sT4eIf0Ynj0AFYpHqCztPWweyusTV6x2+DmlN9K/rNlkn2B34BSU10FB/nQf0D4+tIyplTgmIKgXCBqQ3FaxFhkmJeeL7dxduhVaDxjmAQ=",
                    WrongAnswers = null,
                    Passage = "Titus 3:5; John 16:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 404,
                    Question = "u/meXMCdRTnuaDNxp4M1n1iksGbBJm4odfXMz2zCp48ILjmzY5V6dg5vUvgs8SiO",
                    AnswerHash = 950304923,
                    RawAnswerCount = 13,
                    RawAnswer = "eJcIPVr0iOyp4ZPMdxCuYAna7zxEjF0gDtPqRIcSi/HtNy3MZkqsxAsAA3UflslNR9rWAu3PaBBPNLjixbssxKqqeXG4VEHLE7k0jtg3KZE=",
                    WrongAnswers = null,
                    Passage = "Romans 8:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 405,
                    Question = "ea2BJTGKi7cV2IMZlYhpMPsQxYVypFTxMqUjtBwbM2aFf2X3O9iQAQsQYuhdnKHWAmbxxtZZJfMXw9kqV6iSuM5kGub2XCozzfK7nPUhtn8=",
                    AnswerHash = 208734031,
                    RawAnswerCount = 6,
                    RawAnswer = "Q50HH+udLLqQHUhy5iKLHnyG13K5EkwvY/CWsduXD9OlyvkV6USHUrdSHFrH5+gq",
                    WrongAnswers = null,
                    Passage = "Ephesians 1:13,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 406,
                    Question = "PaN6rNGoX96fm/LTfQ2xqmU+mm0LCAI1ScgntEGKVciEVZCgOKlkl6tTd/nziCk99/K8WCEHuDUEQbvnjEjXjw==",
                    AnswerHash = 1708563815,
                    RawAnswerCount = 8,
                    RawAnswer = "Bu8lgK8BEpmldbhwtshcuVwMQIJUGQqTBr2/hToF8SXe/oW4vZvP+W43r/XoIkk9",
                    WrongAnswers = null,
                    Passage = "John 16:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 407,
                    Question = "+u+5tEhttUfc9dp6O59RUNwFyh3SwmXa4dkPK6B/vsVsNc1MsHDdZw3K8p/tS9wqMKft9t59kT1NS73RBUPDcA==",
                    AnswerHash = 2135409423,
                    RawAnswerCount = 15,
                    RawAnswer = "XpvV0yCLVL9wGZzNCcGE0lfzVoeAbmQsARfoS04s1ilQv1F0gxRR+ch39Kd7FBj8YJMpCL7FXWBAilURo1MGj1NvYpIH02vMlLPlOBuM1NE=",
                    WrongAnswers = null,
                    Passage = "Zechariah 4:6",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 408,
                    Question = "aU+3+S5JLrAbMlZpv6O1kF4Dz2ux1p1d5qdK7bBqiYV8jI9N+CTi94M8vJOvdxEeTTpPYtfIAKF5HZ9DuqJz5w==",
                    AnswerHash = -2011605602,
                    RawAnswerCount = 1,
                    RawAnswer = "UlXLwy32fwFjc5nZdW+owt8jBcFlLyEvLQk92ipL3Qo=",
                    WrongAnswers = new List<string> {
                        "ULohrgcQykC4kJvAwwM1f9JzQDKPWS1euF7GZhG3+9U=",
                        "WT9zvr8Fd9zqBpxbOTvp7Q==",
                        "w8o44WuY0Vf46yHDEyMMZg==",
                        "gMH8jvsvndLZTctTzj+o2A==",
                    },
                    Passage = "Acts 2:1-4",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 409,
                    Question = "n4jRz49qO6C8MScBCDxAwNxXkCTb0+Rgm5PWdu/aJtEy+FlcAQdBJxJXYXlO3kyIQGRThkhfDoDthWxPA26vuFJ8XHsqlTyQAV02sR3k4CNa+RHzwnFehwgyGJarz51A35zy9fFG37wNWurZoWMXwVoCS7e0Vp+udDruwPSmcCc=",
                    AnswerHash = -349139199,
                    RawAnswerCount = 23,
                    RawAnswer = "shFP6e0pmHYnnTaifSbsYYBcrG9UBL54vpBehb9RA1TKWfvRhQXZTZDlHWwvRcuB3ULRTviIB8l+w63PuKKVvFf/+iI1NunhSH2TX/Dq/ubhmLCl1uQqTbhsnbJICcDtr2g1sAVsAPJqKDfZC+LhbPPYUGXFLVartHy0MME1Up6w1h7YKnJqGWhmXX54x3YA",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 410,
                    Question = "cogNo2LZHj6EqroqRB1cDoXQbUuJijcPSiRuMswCB5A8dXjQv/4YQBK1lSQZxqU28tDVwq7+pN649u+5oD+u7KiG1HUTnIIiBxNpL0ATwEGIt4+en6fer6Dcm0dMsDo2",
                    AnswerHash = 1296642898,
                    RawAnswerCount = 1,
                    RawAnswer = "AsM7uKTFzBnPdfw+9oEhlMpzVVaSYeTBKvKY7QHDv88=",
                    WrongAnswers = new List<string> {
                        "bEomCvPp9E9C0AuWrIFLFy8SJlZHkQ/gdzrmbfsgr6U=",
                        "o47TFWx6EFLRrvAZfbVJDVDjSoInhOnAAiZsk5S3+HM=",
                        "k9+ab5X/9nZvrt04T2AH8VG0T1UrSN0W8AcRAPyXirg=",
                        "YRj0ChBv8c1OiMMf6F3ZQ/zaj9J/LJMq2+yllUzk07k=",
                    },
                    Passage = "Acts 1:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 411,
                    Question = "gtkIM0R4B8Z1KNshYhD58jXNsXhzPGedv++mUDNg+/CRpIlIqF59g5ddQxao2wyJkgkCCpQCf9a9Vp1AtBxRndCMC43tRSay/xQogSD3WHsqVUueThAv6Rf5vjMqS+QlHhPKeXWp79dlpLJTlwWY5g==",
                    AnswerHash = -168273834,
                    RawAnswerCount = 37,
                    RawAnswer = "9ZM7QvZ+C3PepLOzSbBo5SqlnZmphXvD17AGBf17z3z7gVCtlOWIjzfykWdyKTM2Kcz/i1UtFbdCpYLFMEXaOVw9+S1TCr+onFedDqMyTDiniSTqv8y1QzAJWHCvCm0rpO9iis+3/jr6iqY/uSv/Ln9PFPvvDEXsMxHzFX1T4zyrhAblof6IVu04JgGP970hgJK2qamP26wjUW5bB6GwZPWzQGzzi/zn/yg7yrSgFN7IfhgH0Q8VEeGAaFMVolOf",
                    WrongAnswers = null,
                    Passage = "Acts 2:38",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 412,
                    Question = "6naSYZ1uOcTzmGQro+6ye2adQ0SVvC+98Vg7YgK9usnWSyamqb1TrJtItlcOzeaaOD77ZSMh3B85oWo9a+bOig==",
                    AnswerHash = -811243185,
                    RawAnswerCount = 16,
                    RawAnswer = "5G8ZlYvO6V7aaDUGAekGUGXEAwFmeA0FGPk6wbzY3WVZmBYmJ57IyNw7De3g/tCtUizI/FAirhf6c44JBP+JlTUGmrgH8rKdzbv+KMXGtcX50oUf2sJum6eA3HtejDylphLK3aJuJDIaVdP1JwK1og==",
                    WrongAnswers = null,
                    Passage = "Acts 19:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 413,
                    Question = "FKWKIPWo+DkCsG90naQXTdrinNuViNh4RaqyCQfUbE0EHhrp6tBAAbDtbJ8wbXgjWDdFDw8jaYFClPY3qHe8ew==",
                    AnswerHash = 1335713285,
                    RawAnswerCount = 20,
                    RawAnswer = "3QD+oCFfnGnuik3zmnF3zKXu3DdUFZaFopl8HBL7H2v/iG5PxN45Yok+JZLinDhyp4gV/c3qii2n6abM/doWduKz+fo0iLroOcdldWBt8Hk8Jfb5+9rBOpvIVlR/XviF2IdIRjMVXVw8yt1LyOQ69w==",
                    WrongAnswers = null,
                    Passage = "John 15:26; 16:13; Acts 1:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 414,
                    Question = "VkLeqWxM2Tfd+xFWP2uLDvlb2lzXeGGW204TsujpywJD1QrgMjfz8F9c1j5k+gkDkBjMZ/QH1Oq/LM7+06WPOhDlsI1wvTUNHrIKOM2/3sg=",
                    AnswerHash = 2052623121,
                    RawAnswerCount = 10,
                    RawAnswer = "nOC6iMZFo7HVDDGQvw+sMk8cFY2q+NQ+kQedfHWvknyNGNPaIgf2WephjSzqH0+J4M1zWMKxrIY9GcjH6vjJaPYWIjBfjZMhAusrc5zk8qw=",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 415,
                    Question = "XKCwo/7lQVTDfFwwuteN40SrDrN7jz0qGqRbxCOniLvSIYXeBap6LBsWd1WxAIvCt6fmaHRtw0Bo91Jc+TMuhDnZgDJBaa4QvuMn+48iPhaUvje9AfiPwGs6JtBYVFzMpX8dTrU1d1Sos74kLhVGmd1YeXgS3SwMB/PAEawWfxw=",
                    AnswerHash = -551569013,
                    RawAnswerCount = 10,
                    RawAnswer = "Ry0dDIs3CxW1kI8B4yz5ahAkJp0EU6Q0C23BFJSQVSf1vwph/AgE78uJP9bnMmS/Uz92Mmkyb9WpREBC3+RQjQ==",
                    WrongAnswers = null,
                    Passage = "Acts 2:4; 8:14-21; 9:17; 10:46; 19:6; 1 Corinthians 14:18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 416,
                    Question = "/eMd2hP/Ub5oCnqolXlvtD5zfaerEPIYzyVKSXUE3jc=",
                    AnswerHash = 1641911086,
                    RawAnswerCount = 26,
                    RawAnswer = "vPxPt878vyMV12+ZgpkfA+6fqw1XX4kLVisSlrpMsoqF5kjeT5PnJCDGBmZ/YsQeevSk9cHIk4+xtOLSQJLDJC2krTiePybx8KKEvwi0ZN9u/iOYOGxagt2zt8RRrShACQ/6XsFYn+hUz259kM7Z1bX9tJHnJcZ4doZ93ACcRygx2oBKOEV0T+MCRtKysBoV",
                    WrongAnswers = null,
                    Passage = "Colossians 1:18-24; 1 Peter 2:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 417,
                    Question = "fcoHXlpV3BIncnf5LWgHp9guyjtTdKUejMokUSTlQF5GRWBVEZ+ZqmHYxmCaQRtJLUwUuZXti8KKdp90ux5g2Q==",
                    AnswerHash = -168280801,
                    RawAnswerCount = 13,
                    RawAnswer = "+/5uiPQrnYc8WSOm0CFFHR/MjY1wY8AJk9f2a9057wqf5+xAbqeu5fy5hmZHnrSjUacyGiIfA6fgfnzmyIlU1Z8JyTYBdJGmj8emyJ0YWAg=",
                    WrongAnswers = null,
                    Passage = "Romans 14:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 418,
                    Question = "eSEdMvPKWyUhsrb10pdY3Gol2r/URSyX/da/93gNQ6Q=",
                    AnswerHash = 607498426,
                    RawAnswerCount = 1,
                    RawAnswer = "HfcMCjDaELxpnMBl0NLQOA==",
                    WrongAnswers = new List<string> {
                        "iuMtLueZujMPYu1mdy3Iig==",
                        "uf5emSdHwZjKISnWGfXswg==",
                        "Qlff69ed9nOvqBhTeNhJEA==",
                        "LF/2kehpUmEiowBtibYyhA==",
                    },
                    Passage = "Ephesians 4:15",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 419,
                    Question = "nZMHkxlraoKkocbVoDI8avB8dCFNNNvuTyxQIMtBoP2AcGDVXi0ETdyPC2FNvXg+",
                    AnswerHash = -607324010,
                    RawAnswerCount = 1,
                    RawAnswer = "2t1irgZmkBhx4giRDy9B7w==",
                    WrongAnswers = new List<string> {
                        "6h92ul2MCnRMuLhGVxDP2A==",
                        "uf5emSdHwZjKISnWGfXswg==",
                        "iuMtLueZujMPYu1mdy3Iig==",
                        "Qlff69ed9nOvqBhTeNhJEA==",
                    },
                    Passage = "1 Corinthians 3:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 420,
                    Question = "w1Brn8J9i0+d5kIXufwSREFQ9Gg6pQLlnOeWuBkHwPbAq7HDuNFcPER+IT23AXaoh/GEZaJoagOQw6dcZxDWkRhCS8R/BMVhIRsMluJKfUY=",
                    AnswerHash = -2029671460,
                    RawAnswerCount = 25,
                    RawAnswer = "tN+KoHM3xYhRvhRxkUOExKWrGPRIy2hsiMT9q8JAf5Idv/7AORyMXXNe8Ms/eEuDMV8Lc6MYd6iQvZVPi1ZUIKwXXD0ry3n1FEcXpu94Ftu1T8gwgLqZtLRvCOHpDQ/EOTalCB4lUwt4E9i1W2y3QvGboXtL0+BmR8F+5SVAcZI=",
                    WrongAnswers = null,
                    Passage = "Jeremiah 1:4-5",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 421,
                    Question = "VfCuAMy8BwlT6954F140a0BfcjbeC4qq7yzSn8nuH8PYb3nlHib2ltFhPVPeDCm0T3NY3y9+w7O7MP8654SW1aqSJs7PvaofUPsUoI0dALQ=",
                    AnswerHash = -1812037693,
                    RawAnswerCount = 1,
                    RawAnswer = "dShRVXaM1UrGBANvvl8BSg6JcsND4dxBJziItXNEZmg=",
                    WrongAnswers = new List<string> {
                        "GE8GItqVJ6sJpUfWwAf+aFW3ry9NyYEhW/OezFrkPOs=",
                        "eU3gBbmPn6ji32DnoDZQS8Je9+Z/ylForJHVip73X/0=",
                        "b29wEEAXl3+Ajr2/i0ieA6OZfai5rSzsQNsUciGxLX4=",
                        "Sud+wQIFSamii85E1TEpo662tykuwq0GjnPn2upc6eI=",
                    },
                    Passage = "1 Corinthians 3:9; 2 Corinthians 11:2, Ephesians 2:16, 20-21; 5:25-27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 422,
                    Question = "SxZuGpKE4NgZojElQpRtDJy8JpU2w6oAfo193wUB00U=",
                    AnswerHash = 607498426,
                    RawAnswerCount = 1,
                    RawAnswer = "HfcMCjDaELxpnMBl0NLQOA==",
                    WrongAnswers = new List<string> {
                        "uf5emSdHwZjKISnWGfXswg==",
                        "UDGSoqK58XUdbbgPI4c4yw==",
                        "7wXXGOt1gQgjHl6+iepmow==",
                        "EQId1ERrzac4oTEWkyu57Q==",
                    },
                    Passage = "Matthew 16:18",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 423,
                    Question = "BBzsWg81q1POyY5zIp3KchNJGWyNg3rkTHAk47Z30NqbmV9FyfMDD7ltIyXqXduK",
                    AnswerHash = 2017408803,
                    RawAnswerCount = 21,
                    RawAnswer = "S9slkPr7cJcnALXM4NF6zGwnecOz7MAEBntd4IvrC+ld0rNEz7kcde6MHJBo2PuvIsgpApdTStHlnlD0vCmoqz1Io80ymc5bE8DrDR+sSn2puTbuAW8IkuvKlLt+difisCPqj/ArNij0LZihcxoD2g==",
                    WrongAnswers = null,
                    Passage = "Matthew 18:19",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 424,
                    Question = "xw1lCK5j/TpSRww0EJkKuR5YagSnt9WU1JxjJD3ac8e8OtqbpnkciYCjX2R1CS7I",
                    AnswerHash = -1277895724,
                    RawAnswerCount = 12,
                    RawAnswer = "11N9CddNneOMa7+4//snYRlAleqQfh1fAUFDmX+loy0re31/TyX9r1Xmhr/FrG/TvtfzocKOXg++Z1JoQdancg==",
                    WrongAnswers = null,
                    Passage = "Mark 16:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 425,
                    Question = "LdqueXrA7jxkn/BzhWX30gxyP5nzRFFU+xMwZJNhK/o5npR71eYE4JxQW0aUjmHdlnootX/9cqzCBp2LyWh5DnrDjTn+2ttsDvFf5Gz5xm0=",
                    AnswerHash = 1499432159,
                    RawAnswerCount = 1,
                    RawAnswer = "WfqgBW7t9zDqsW9BWSE18MDNI2Hs4YmosMAHQqIGnZ0=",
                    WrongAnswers = new List<string> {
                        "vmYuHTO+aNWGUT7fx5LLL8prGELaSexBn/yIvljwgFY=",
                        "qr3WeeSv8jREDMKE38pBQty7nHgwzn/YxHH8ej8Ypmk=",
                        "BANwyaSytolin4PITXNDNA==",
                        "Pw6I9SMpp1iG1WEOCcVH5eR8IHciWX6jD0NFkgfNvnw=",
                    },
                    Passage = "Matthew 21:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 426,
                    Question = "zjSvqu4MBnKxjL0n41Hk1OdCKhSPHZJIpDC7dD11bpk5TrQfQQEerwDEWg7fcYsZ",
                    AnswerHash = 215897306,
                    RawAnswerCount = 9,
                    RawAnswer = "JxFo8nqfEkVjH/9LVzfWxmnSsa+34ZRQxUyYuZJUyRxdkmQwIS2BhL4GewAjqQPl",
                    WrongAnswers = null,
                    Passage = "Ephesians 4:11-13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 427,
                    Question = "V8xJBuAVxDf5AHdnvn3pMYIWVZlwZ1IjDvAi6oi9x1KQv+jLgiv7luB9KscU552a",
                    AnswerHash = -2036963128,
                    RawAnswerCount = 20,
                    RawAnswer = "0rDJBXzNUK1JYTb5dVgKCyfEADj2zq0HmHCZW0jnkREqyLPqbi7X8iaDLIT6XHdg807IyGnopl+1DVDMTuUGHuMP+SO8dq4ljoBaMMEuA8fG4fBpanMj5YY84XeIKavxGaaP3bIZJPzvVSfDvkVHwg==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 1:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 428,
                    Question = "Q7DTNd4VxWFj9w8RqEegyqmzCiqzWg18stv5+OWuJqnJQJI9EiuCnifigaYMg+LK",
                    AnswerHash = -917157523,
                    RawAnswerCount = 10,
                    RawAnswer = "ChG5Ewm/KeJEMY/sGb7hOVle2H+uU+gb9/kc3xI1zD/AWIJg8cHmHVnMTJJO4/OlxxxW8/cn6qPTWIjGoXD1Gg==",
                    WrongAnswers = null,
                    Passage = "Malachi 3:10; 1 Corinthians 16:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 429,
                    Question = "ztxaFyBSJJDb3hvAv63F+S29i7/OGspQ5VwzzcVgf8g=",
                    AnswerHash = -1075529148,
                    RawAnswerCount = 19,
                    RawAnswer = "eX7jcxPR1AT4xarixLW8s1DsF3zdtNj9Wc1OWyErgHV4282WdU07QOgnrzkrcEgWazO05VGkpjUnO/2131ckO/4yaAeQI+oqJGZdsi9pBLziFPzR5g1BHZcx0T0n+2Ct/tBsO9n9pQpnOmP98wzpGw==",
                    WrongAnswers = null,
                    Passage = "Leviticus 27:30-32; Malachi 3:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 430,
                    Question = "6+ejZ4Tb0ndyTBCBtzKF+PzJLuSptlz6/a/m5VwwNfpjLbz+Xp0PcMit3Uk791XQntoxyMQ9NQxaO56onfR1HH7TT7iqnjCL3yRc3nki9r1qxKJ9aoJY97y3umEa1pEW",
                    AnswerHash = -1291152043,
                    RawAnswerCount = 1,
                    RawAnswer = "U0rGScRLYpcs+Xob6KTC/bGtj+tsBDTr5QrRCwC6cpXS5DHFsJIR37vq0YzaL9Xg",
                    WrongAnswers = new List<string> {
                        "cgTpTlU5d3YGkNGSjVUbntgKVi8nAsKM7gIN2lNxG48=",
                        "aG0pEfn4NRHETdW3jnLSkpzcMx61wAawjv4wmA5o8fQ=",
                        "zyLpEDPdoqNvA6xL48H+FaXZfWRixv5yJunX1GGA9qk=",
                        "wI1UW8EjxiFR4ZTWPyT6BTrxMt0Zo1h7rmXn7IS3ass=",
                    },
                    Passage = "Genesis 14:18-20",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 431,
                    Question = "mKzRmjiM162+IHcsQslQ7BEXo9On+d1MCnrOVJlKkaU=",
                    AnswerHash = 591618964,
                    RawAnswerCount = 13,
                    RawAnswer = "ey+p65A0LGKMSa9TBKry7Im/0N7KhF932zE5oq6Y3g8X9iKuFbaQJ92JGk3cafTZKSt1Vy+9bubbTppP1w9aydapCogqQCtCalxPZFlCxNA=",
                    WrongAnswers = null,
                    Passage = "Malachi 3:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 432,
                    Question = "bjaYhUJqvF/z5O3++VFKL1WUMWMES/0ZSo9ZtCy1aj3emSljfqquS4Z3+Q7wzjvUwOmO49UmKsee+kiAFnckwg==",
                    AnswerHash = 131572968,
                    RawAnswerCount = 15,
                    RawAnswer = "ZdIxV8rcKJkNDDdnVw2zSnlZSFtgKXiN6ualinFZ8lVMPqgFu7PHv3KEBgWvDfVV4bLJSv8BvWhoj1JB5DUJMvuzhjko/D/AlxzAxPe4z8hzs55N/ofHJI+nKapz8Cdm",
                    WrongAnswers = null,
                    Passage = "Colossians 2:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 433,
                    Question = "kNoOBKIZh4L/j5QJ9KTnDLilFfOsv89WESvQ/Pas8TXx2No+7EL+LyEDKBu4cIw8",
                    AnswerHash = 2077619184,
                    RawAnswerCount = 1,
                    RawAnswer = "FVyQD90pXhC++QRKsil344Kgiu8oUEO/09xg+klDsUM=",
                    WrongAnswers = new List<string> {
                        "CJrLQQiH59gx07f8FWMs4zuaEPW5SzMyy0wrLbVY+cQ=",
                        "XDW6CAPP2I4bkxbidRXIx/Q2OSGSnvFaFrSIiby/2Hc=",
                        "5aRirMxxT3to3YcKHwcwSYPaqygh27mjDDqjmPw1OWc=",
                        "tbMrGcyGGZsg3n+ffw5hHSt3XFfSS3OjUyA0wyIeIVQ=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 434,
                    Question = "jFL6ktWpAvw/TAgwGcESkAt8ZpD0nhXodRVNgNIpy1kpv4OBa3T+P13ZUd7H7rzqhpEkfmmBbaAX4iMc4MvLOQ==",
                    AnswerHash = 218337060,
                    RawAnswerCount = 13,
                    RawAnswer = "ZZiVCIcZFsEQWjXJrH3S0SM9GuPQifNpXxikhCE3TXsowOprvaTltraXHd0PFi4UMVWtG2lp7sqBYTxX/X1iHw==",
                    WrongAnswers = null,
                    Passage = "Romans 6:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 435,
                    Question = "fley1twQa/uoyNhaPHjLi66W3XBrbI/UFM0X4GuwubQIQN5BbY+yKdr4u49pl6nK",
                    AnswerHash = 1048365513,
                    RawAnswerCount = 9,
                    RawAnswer = "PwRcW1NgFVsiAPH6Pwfwkd0nOAptZmV5aPgPCMUn/QxlnQAKfPGrvGtr2zqC8SCXdhQbbZ02nbIPZfgzMmNpkw==",
                    WrongAnswers = null,
                    Passage = "Acts 2:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 436,
                    Question = "irBb2fmSBA2f3AkmxRUrhNOMcYR9gi1cxJs/6SI0xQlHeqE6/KhkYv2gJyyFr2Pw",
                    AnswerHash = -1615411982,
                    RawAnswerCount = 1,
                    RawAnswer = "6fKzs95ZEPfPA+rk+qtyx6QzGpGAfs7yfm5fgzpGUkw=",
                    WrongAnswers = new List<string> {
                        "sfPbldu/rJkbH5r6euGeLzUW3mJ+HS0VEx38UY5NGns=",
                        "2dSDlIqLsocGHFh4X5qFug==",
                        "RuoUvkIfUnbHGaZGug8wRw==",
                        "oN0nXeQetfwYTAWJnauTpw==",
                    },
                    Passage = "Acts 8:38",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 437,
                    Question = "kdX+3wZCw3VQkYwtlBgDTLkXsMd/ygem5IJKbnPmXRbOQTtnOEZXb2iAw6VXbQvY",
                    AnswerHash = 424950562,
                    RawAnswerCount = 13,
                    RawAnswer = "owSw9r+LC1nO06iBYLrswQbViUIj4lmvMCPpF7cREjGVYrb0U9eqXENdSDharygc9PpQmZfWFGeaQcW0hHnqDw==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 438,
                    Question = "UZRSiNNcsw9C+9+/djgMAu4w6xGxTJ7CKpga3IEaSFHs7W5zZVIpNf8qLBPUTKd0+A5ZBjLoafBMLPbFvpXnoQ==",
                    AnswerHash = 1832609186,
                    RawAnswerCount = 19,
                    RawAnswer = "hmxpaJ9+bQ5fB1QAP5a2V9TjBk5Q9kZ419cOilwQsx0RWQzmFCW4A41TpK5mxsPmAD3QBemoyT4PpP+zcQlfP4UmVvbZTn7CVOaM0Tlizs2n61eeaomVPrhzrB3OIJwJjAK9GRTvjtsRHi4WyuYZLw==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:24,25",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 439,
                    Question = "n4jRz49qO6C8MScBCDxAwIyQvwESRsIHKCfUmS47SB0Ia5be7E9HieGtbhE1ktO7OyG4yslWVFKTQkh5U9IovlAIAbmYb4B/hN0qbK2un6B78OP+LM4ufGdXxLVmDMzs",
                    AnswerHash = -1731959912,
                    RawAnswerCount = 21,
                    RawAnswer = "5rdyC0qKBfcL7TMlXUktpt5KLfuCXiQz69L0zRHN3QKml7D+QG7KvKr7TyqMYIZv2IDI+A3JnjyLrNjNsKXzgwwzHqVrTSO589YDwEDRHzuEP6BvbcfpJ4lCJgFZexSTyXfSWWZl/Jb+e16paSqQsg==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 440,
                    Question = "01fZ79Y0PfXse0Xm9iFqx+3EiGFZnTHHFDbwSmwTteY6BB5PLFj+0qXLg34CQv55Mj4G+cm7gvbwmRGphOH147NXxK39DLQ6328dft0erHc=",
                    AnswerHash = -241209110,
                    RawAnswerCount = 1,
                    RawAnswer = "BLi96HwXZwjUeZ7sPKYlEg5VlRN04D7TFL/y51ppzJXThje1fm6hQs9VMtmhwwnl",
                    WrongAnswers = new List<string> {
                        "DaArRlwARiYrXMu8lOhnc/iX86sF21Kd048TwLKQ6MI=",
                        "hLZcyvoWt4NYXVmUKnW0Bdk9G5Au1FXuZfhIMmpSnaA=",
                        "Dgfr4MfSutPHgiSPIfxTzdEBp0141e0pkw4sBjMu/EE=",
                        "Wpjk1BH7/F6/Vmzd3SCzvJ1KvIW19k5unbpHoseYGhs=",
                    },
                    Passage = "1 Corinthians 11:28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 441,
                    Question = "LMokZvn9PytiUjpe1BsTOdcnzxWyZDIQ878Io1RK1tyH/dU5yE5CgjRcV1VuwKDr",
                    AnswerHash = -1970427163,
                    RawAnswerCount = 1,
                    RawAnswer = "g0lqn6TWbWGDiM/hKJm+KNoLy95gLRaa1APu6jHgwUtJ2+kPCr8gB1VRGKvmpxTu",
                    WrongAnswers = new List<string> {
                        "CksfIoA6YNXDs8E0hWN2Hkayws1mHi4Gr5n/5Qt9LSw=",
                        "byaB6IyyFQNp4nwUalgCsoJXKa5+aoGHJmefpZsIqAQ=",
                        "Tqh0iawabNZ4Pwsrtq2Ydo/hrVBeI7imcyxnbHFOwd4=",
                        "Fo9FzcJ7Cp4QVn7M6YC1oKp14AaDfBpczMrCWyba6xI=",
                    },
                    Passage = "Romans 5:12; 8:18-23",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 442,
                    Question = "BB5zF2eK6woxUQoBy+d/EGSXgfRnauUmG5XGcAB4s+iNhY+83LN3txr5HbFsQyFGdvz215i4dXxePbB/IhI16w==",
                    AnswerHash = 652248875,
                    RawAnswerCount = 8,
                    RawAnswer = "nyLUTB3UmTReT0R+0M4i+qMYBdeb4QXJlkfi2fHXoD8UnckywTqqZoW4uNmjI+2agnKIACiYVY0S/c9e+8QzGA==",
                    WrongAnswers = null,
                    Passage = "Isaiah 53:4,5; Matthew 8:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 443,
                    Question = "WQvkNXqTdgrcPu1DAkzLF+xEDhCFwkUwWaykd0DXv47R40RQoxbSlKVnKpBI94nN",
                    AnswerHash = 1414621972,
                    RawAnswerCount = 9,
                    RawAnswer = "UWP0coqlYfDh7s6m0Bley7si60KD2Mf/1lIllgKuKI84S1e9NnIxZ4Of8JZUQQLFEfBq7KH1YA0+stFgJatZuw==",
                    WrongAnswers = null,
                    Passage = "Acts 2:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 444,
                    Question = "6kYEYcbbvv+2kQxf7viLlYsBUqmkxEcGfe2wGtEwSQuf7q5VMT7umWqUe0lpVndG",
                    AnswerHash = 716602680,
                    RawAnswerCount = 12,
                    RawAnswer = "8x626nePVb4+qwiIYvxBrZ1gTWC/P/dSbi3bk02AJk6Vfv1a8BUY53zUcQSAChJCzbEtdt5BsLrzPHcSXNlKgBO7oM2XAjwHRIYskmLev4E=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 445,
                    Question = "P7K8LAcx69MnP6nE+gzDK0XXIqxfIiJtDOG6v52ZTGpiy+OYa9DyT6UQcvZ5WdswRZBBWbw2Ih5kk6qbtgkUCw==",
                    AnswerHash = 558753386,
                    RawAnswerCount = 18,
                    RawAnswer = "ZlULGtfU0hUhjCiAxGqJtCRrc4xwOwg/EdQx4wkpZjMUASQn4r3Lbi3p6954dbVaTQ312xD8dAMd0/IUCmnyzioHkGB3DUTUx2vXo8QFPSZCyq+A50T9ccGZFzesYvbM",
                    WrongAnswers = null,
                    Passage = "James 5:14-16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 446,
                    Question = "HdiE0yIQm7sb+vw/n416L7TOA88ieB+zsZeOpMCGCdA1Qz4Pfv0b976nJQLqUGIL",
                    AnswerHash = 596589545,
                    RawAnswerCount = 5,
                    RawAnswer = "pMJnK5P0DZPoGBTlktiVDRiAAUZdbqpbS9ZdR6DLMBw=",
                    WrongAnswers = null,
                    Passage = "Titus 2:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 447,
                    Question = "x4jR6j2l8YtDKcOV5SxALR2xEFVO262pELFmmaYUGAs=",
                    AnswerHash = -985833434,
                    RawAnswerCount = 16,
                    RawAnswer = "ig5eH2cl3Mtbwdm6GG05WNG+KUlbYB//yOq2AUxvnqHGBfUhAjf01fSnciueAQinQXZpRHkn/z6CQXpEU2TlANV56mnV3RuS3KN0CJNPGK+eiQzDysK3v+/Qhyb1xRxDRyz8VkUQCjNldVSKxFQ2zw==",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 448,
                    Question = "E1Jyo5GNczUUlESIeIWW+aAQWH6Lu5E53iSzBo/E2pfudvfhGf/LxJAJChDG/51i",
                    AnswerHash = -429076386,
                    RawAnswerCount = 1,
                    RawAnswer = "1IyNDd9uw67yPt9EKKJVgSB4ijIaYKQAEew3CJtAFGA=",
                    WrongAnswers = new List<string> {
                        "i0YCW/T8FMqHfZLZFaPXNg==",
                        "N+EyUEqqUEwc/gySaJ0E/Q==",
                        "/1/ugLk9y7/j452kF0rn3hY7A8ddOvhPI8WctS+IdB0=",
                        "LF/2kehpUmEiowBtibYyhA==",
                    },
                    Passage = "Matthew 24:36",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 449,
                    Question = "2qUxfUQa4vxZB3ShdxKv9OaeZM5QDEnlkKVmy7ZLXZy3hqrkGyp0FITdiXNa3UCmTTkKYB75VTN2fsij9ZnJaw==",
                    AnswerHash = 513874291,
                    RawAnswerCount = 8,
                    RawAnswer = "MbQuSeN66d1O0Cg7IpqSipD2NN+El5XgEuTwRpsTfU/JBitqnS77b7vRTmW8Jcf7",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 450,
                    Question = "zmVo0Alcsm0e00v+xdfC5m2nYlNUM/gJluJSYzq1MRxBoHNWCccU2ylXj29NO1SqBxp5tp0WV7djtNj/8F2NC/Xg818bIIdPc6wliHMFJgk=",
                    AnswerHash = 843760984,
                    RawAnswerCount = 11,
                    RawAnswer = "sUUhxk6ffj1yXyWdSkQMCxN0nVnt14Mkpvdt1XM6CFco7fu3kntYOFkt3UIsJd8qvVHbpwEIhiA/Q0lXsjbNQw==",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:10; Revelation 19:7-9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 451,
                    Question = "y/+2YQSzQcOvS+aQG4BmAGPK9n5QO2wGnw3UdC4vCkw=",
                    AnswerHash = 761736071,
                    RawAnswerCount = 15,
                    RawAnswer = "ytXQAwZ86Hs7TVFyE6qJ4805l5YNY2ERGLIFnYSJjKriVcX5k8msnYeum/lBJ8eFBJC19sMxGFJskNdRxgvjKuxbL5B+9lS7aqvuzUr+yBDknYyD/EvBMI/Oa+JIjSPA",
                    WrongAnswers = null,
                    Passage = "Matthew 24:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 452,
                    Question = "V8xJBuAVxDf5AHdnvn3pMZIMzQrLSIouS3nw88GhlS09+bTX7i52JcwDgQqiAhaGxa+FzFM55Kr9DHFaO98+ew==",
                    AnswerHash = -749792850,
                    RawAnswerCount = 22,
                    RawAnswer = "3OsaCTzv3lPZqGJwgyy/vUExFU9M/eTVgzdUd53rMZWa9FEvhbdsaSVSKxqymyiRoD/gfoS2nKmHikGIVALYfmH87YvTzebjrkpd//0CUTwlGcmVEy0pVatXonvo/vEOtk8zFw2UMRhUgmTc+AHpNli7YG3JACG7l5Pu1sYndMg=",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:3,4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 453,
                    Question = "g6iNuRJZ4fTe+qWwroKROZ8jC1pQkH3Nl62d/35jkmU=",
                    AnswerHash = 1655614406,
                    RawAnswerCount = 15,
                    RawAnswer = "4wVWrWO64/spr2OOECUgCptkM7oN6jIrdIzsTorzG6LEsNvA1JV2kRZy3UC6wVTALaacrUej0yrOcu3o3dJyRjVT1EUHGeQPafyuKpflUoKSg7bjtbtfM7pyinMsB2t6",
                    WrongAnswers = null,
                    Passage = "Revelation 20:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 454,
                    Question = "B56kG4lu+HeCZ9SgxKuVWt9Hv0ohRwQzUFJCx8IUzR/nDDXyO1rmsVcx4WWqVy3MZ9RVRdm2uXrmKGB/6GETNw==",
                    AnswerHash = -247946240,
                    RawAnswerCount = 14,
                    RawAnswer = "Ekqkvds7ewYAbHfW8ZisFIpDLti6bcLLkmw1BebNnPD1KlzJkzORGGtXMw20b6sJVifCAPwAbqkwM9uUBJE6+xS38rnfKtB11s49xlKjAcA=",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 455,
                    Question = "B56kG4lu+HeCZ9SgxKuVWmAb1TdXoVATbzBDiNmeUBnmGLIPgDiFETp8IIJG1eRnwcNSglbS5/OqAlF7t9u9LQ==",
                    AnswerHash = 899577393,
                    RawAnswerCount = 18,
                    RawAnswer = "xbj0DUJA01p6OinxWTkAZHIp7QQ57Kml5JAZAhIoYxq+iL3ZWU9Mn2DJar4TnhMUs1XPGdf0dbiF8mPDmZSowLllEHy7a/y9YfJh5bZrjRMVP6NzFUsQQgkNi+3c855cuelGSShyQAdx6S/F7HuNkw==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3,7-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 456,
                    Question = "szxzB4qeJpJLhLFflZR7rsdBtghAYsgTAg33ejcAT9dlaUrW1ZDxglm55Od1DDBl",
                    AnswerHash = 359467981,
                    RawAnswerCount = 1,
                    RawAnswer = "oNjNNO7qFVAHQZC3qui24GprHR2XOEo+fEoCWBNzi1E=",
                    WrongAnswers = new List<string> {
                        "Z6QdZJ9PTZo6N683XzDsmw==",
                        "dN3gr4J6gt1zM+ommMZDbwuF0fB7zAAHHVxmMCvcm/M=",
                        "+3wP5VDN+9YvpINOXVZZIzhYRvcatLmQ5LLZqGTyHE4=",
                        "XDW6CAPP2I4bkxbidRXIx/Q2OSGSnvFaFrSIiby/2Hc=",
                    },
                    Passage = "Hebrews 9:27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 457,
                    Question = "bcwdUF1hQr93dMJf6Jy7LQ==",
                    AnswerHash = -1757287849,
                    RawAnswerCount = 23,
                    RawAnswer = "hy3J4h5BNbX9InWPkmYKJPppXEQlFCAOtyBOTTHBZI1vZKHMZnPCSrCimyPFWfXS86DZY2KiGfJY9bFi8HRqQ2QHapmX5pDTq9e9mi7D+gUUgUSeCBG4ClP78K7uy12nE91ZHaD97aKgDdUdvW99pPVoICi06LA+fwIjQQKKEc0=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:34",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 458,
                    Question = "61RcvlVhU98vwmCwB89I+rajmlaK1ZGZDzTfs44Q4HhRnUq6TSXcyPxJrZ68t6vJxlsNtK/1eJAJjqleoIARdg==",
                    AnswerHash = 808853510,
                    RawAnswerCount = 4,
                    RawAnswer = "2Dt0St37XvKg9+9Ci82NfNDhncYjo4W2c74j0V3ZMpc=",
                    WrongAnswers = null,
                    Passage = "1 John 3:2,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 459,
                    Question = "HjqTxlxU0YM+TL3mUl5bMP8FevqSxrl8Oi+nHm942B4krlxOFIcOrF4ZbZFVx8qG",
                    AnswerHash = -1182252059,
                    RawAnswerCount = 18,
                    RawAnswer = "gtED9xZyENax6CLdqhm43d6dNVBpNn6S4HMihpZwCibzqi9naoq3QjnzjuKN9+84KSCeq1jmqUAEgKi+s5FNhqbOb4QLLz74bk3jN4wvvR4njGQ1Hfoqu0WD+dnStDopm9ouZi4P+2hqUFAiVWtXAA==",
                    WrongAnswers = null,
                    Passage = "Revelation 21:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 460,
                    Question = "oWrhtRdmnIs1W9E4yULfHcxIZjB9LjB9UXCgXfKwkQLefoRc/0ghJUflJuUORgvbnSDzFpq7f4DIvU9vARy7jA==",
                    AnswerHash = 1391174707,
                    RawAnswerCount = 1,
                    RawAnswer = "Nx5ZmyfEgzT8Evh2l+F3pjMqZmLrFI5d0xELUywwXVn1psYH2NG6UZET+Xos+TnG",
                    WrongAnswers = new List<string> {
                        "oz3iVTqwk5dZ4z19H0ZerY0K0Wtvw52ouZ+7myJFj34=",
                        "MHAw+iWFnFHJgecxTA8zP1qMTTFAoTi5Sqj2Oe3AHHmj18tZoWN2edgQvLMeOoQ1",
                        "5CL1MB1aR+0MdmT/VmhkZXwskXGcF6bhY88ejiqvQjlZob9ZhUCCWYcAVdxFO5ml",
                        "q3OGPouVD/cNrPeBy9/vSnbbrDyrq8+CSgQ3lgfaicFi2pjKm8ulp0Zn9JIfxd9wouQuuAP+oL6oRq18tfZztg==",
                        "DRr2BdtowtnV6aIhzbkk+dpysoeA2ZLxeumDeGfCOZhQb+vNmUEw6Bloivtu/OvOVy3l6j4g101Eb/O361TW/g==",
                    },
                    Passage = "Revelation 21:4,27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 461,
                    Question = "UCVWf13OTXg5sfcUfplH9CDY6bYGBAOxvNUfn25DOAVitVqwIJQDnHAbrOv7deJ3",
                    AnswerHash = 1780762912,
                    RawAnswerCount = 1,
                    RawAnswer = "Brd/OWQk3ATkXhyiVUkJaw==",
                    WrongAnswers = new List<string> {
                        "1ZHOp1jIwkCb2O9PbJaXaQ==",
                        "bGsPQ0EzFAW/EE1IshbwJA==",
                        "24Bf8x+oLr1ZBf6/Re71IQ==",
                        "tHysQ6Q/E/xYrADG2oDbAw==",
                    },
                    Passage = "1 Corinthians 15:25,26",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 462,
                    Question = "D2JnboYXIX3vANvfpvE0pA==",
                    AnswerHash = 1076893213,
                    RawAnswerCount = 8,
                    RawAnswer = "j+XnrbPgaCEUti5aLfR6ZZJAKYTiviIkKYj8NnW26cFNXUKhL+xz6ctbngAZpOMX",
                    WrongAnswers = null,
                    Passage = "Mark 9:43-48; Luke 16:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 463,
                    Question = "A8e9BhF1O19r7g6fUSIMj7dQs2ikHyNnIbYHUZZmGF8=",
                    AnswerHash = 1055407260,
                    RawAnswerCount = 5,
                    RawAnswer = "uypAUVXuiinkaV2jRMjR5ZC6GKeEllmxJ+hyPFciKNk=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 464,
                    Question = "HjqTxlxU0YM+TL3mUl5bMK63kp/pPDFD2KDkmBPV5Km95kRqddjArt9+GG3Qendd",
                    AnswerHash = -1328779619,
                    RawAnswerCount = 19,
                    RawAnswer = "NrdvmYtOk+X4aPTwXdylzZISJ43TAB9HWWL9olK0NBSu9itkMeT27daFzbOMGNH+KoGZz8Td0YsLleMWjEYVgS0rmLu8MYBgux8KjDSsoPLSSccu5bD/7zggxoK7otHYpLO2bPItLefrjbe6I/dWiQ==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 465,
                    Question = "iboMLBb+6Fhxvmcp15yNhTdcsH7ZFt/3WelG4Be5hRw=",
                    AnswerHash = -1623081384,
                    RawAnswerCount = 19,
                    RawAnswer = "zfi+Avnq30cgEx6ot26TyJtDXemxIfUwdNh/XmL7AaxMz9ADeof0PktDtXOzGyUHC+mGsRPebqkEjM3lgj7I/XMGXp7BcZ/pK6RDVcPlPcpYnMdF+sVKorc2QxI0ZDEQ6RZLbcUUnDxc3WRUttbqIQ==",
                    WrongAnswers = null,
                    Passage = "Isaiah 14:12-15; Ezekiel 28:11-18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 466,
                    Question = "VcuHyAa/mkfK6JW7wEbHfRjwSLnL4ot/fCDd3fvyyNHev9wFYAfSGXcTqxzo4yrd",
                    AnswerHash = -2107502843,
                    RawAnswerCount = 15,
                    RawAnswer = "Ln6YwC5TZWtrzHP3Tpsj3m/JtKE9tcQd1EBGyNKVuDRiTzllstA+ik8O73qpK4+3WRNlTthl67ZmqA8MLOvEE70mLvaaaS/1I3M5pMASA6HB+Ch0pu4cThhZ9URPpLed",
                    WrongAnswers = null,
                    Passage = "John 16:11; Colossians 1:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 467,
                    Question = "eQRej9R4gcN0eATlzawHHjLCCOHpnKnp+xO3g2MQyHoGRZcYqcFqrd5NATTEc0ZD",
                    AnswerHash = 223730995,
                    RawAnswerCount = 18,
                    RawAnswer = "NqEaHEfhhjh9eIqR8/IUq2km3UnObvblS9kwtvu+bLo1JqpEhF3oJwDqDEWGNNfOOU8+rFimkdQX06slGROD1AD2SJk5QFUB/NOfGMBm/94XKbNScnxt0pR8yD1equsd",
                    WrongAnswers = null,
                    Passage = "1 John 4:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 468,
                    Question = "7W8cyK2sHv5Zvpy1ZcJ0FW7FedH9ND6dscc93AvtYONL5BzTMdYuJy7YZ1n46keUffCCC9aDtG4uPTLi88JhECRo/phminpZdRLV1OWzXI9gZM3K1p809Xwbi1za7PBD",
                    AnswerHash = 266764200,
                    RawAnswerCount = 11,
                    RawAnswer = "Yo+cn+UJ+Qk/L3PdQhJFtDUAnq/c/aQOVsQ9TmbMf3yo57jJRyY+1mFRFcVa4qALuS2xy9yYMtKKgevquqnFK4QbabJgCAfmHd/8LE38ZJWW6C4boPj16Z72cf6YWbUP",
                    WrongAnswers = null,
                    Passage = "Isaiah 47:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 469,
                    Question = "rTC+kX9e6Co5pvDfRrCPm136j7Pvbb/84Zf5yBcBXgAR4evG7ejPIVBN26dvZ3YEcO6sZwANHf24l8xwW8fpTQ==",
                    AnswerHash = -1043693165,
                    RawAnswerCount = 12,
                    RawAnswer = "dYGOodM/0A8bEgFWXd94pIb7UaGg7TKHcwuhrNqjd6yqkWeqHpw3ktuEC3JuLy1kB0MhtCoegzkN8EuojoUT/iY4lTb2XCFfnzVhBCZLNHQ=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 470,
                    Question = "lBjU/FvJE7/h+IlbZYBNbEiTvh/2u/TwdgzTubqEYZSFJHHOLSgvmJgw6Y1tmMcI0mdtZL4F7/6s7K+Ws9VqlRjNWCzq4CVjlxjHM0vDqnXMwR/bMVwF87YhBYDDe2jn",
                    AnswerHash = 233276211,
                    RawAnswerCount = 8,
                    RawAnswer = "OwJBM0veYSjZusRZieqcftB147SxY0D0KBKf/YOwwlgmBywWW1D4ScU/eVT2s8ob",
                    WrongAnswers = null,
                    Passage = "Luke 16:19-31",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 471,
                    Question = "N/H8Dk27SRI2pK3qsBszbYaiyGHxUdRTem1EKfckvxltjuIbrsIG4DXDZWNKSAtSzQ1nDXboKUKh4eHXGS0xg5G/eAQAkFASLJ0GfjzzgZM=",
                    AnswerHash = -1982119753,
                    RawAnswerCount = 19,
                    RawAnswer = "YhVmQJCD/bJw+Z33zPTg4wGPU2/wWTzRnGNLp5xWqKgSjeOZQVwPRDNjeh6yq8yu2eguODU40Gx0P2sRM3eoSDqgoRBsnGynM/Xhlk+1Kxr5iygM0GEQw19tSnIb4Yztd+tDVmyXzM/yxywkCnJUnA==",
                    WrongAnswers = null,
                    Passage = "Job 19:25,26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 472,
                    Question = "5gqr3PMYOqqbjr7EzVDF9OYVVpIoLeFUJAyVRiGXAi0=",
                    AnswerHash = 70274663,
                    RawAnswerCount = 18,
                    RawAnswer = "nkyltTagkMiCaRjlW7Bpe7Bl/VpM1HH6wLFLuKBpsnvZkTjtewhpSsoeKxO13cKNhEmd+x4o3FtLpEmK0u++j/mvfXHmWuX9vHSxefwQfuh3xRxXvoIiWK6qGyGFOKEKojYTgTI4RODcLHvLHWOvkOkuT4o+u3BpeQg14xZjn5Y=",
                    WrongAnswers = null,
                    Passage = "John 5:28,29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 473,
                    Question = "cqqa1qFc3/YfQcumfgfz4vpYzsOWUA086g3WxpeXUy478jQHSf4TSfrxgsXFIO8WPKOsdsOw/4/vJtUvgwp3dWvC51FXclC5jkD7JoLXCv8=",
                    AnswerHash = 63169664,
                    RawAnswerCount = 1,
                    RawAnswer = "WPVxsotxdVgv63VjXRabuHDnHJXMyKqWeAzTv5zlm5w=",
                    WrongAnswers = new List<string> {
                        "Gk6THGSG2u+UBYweDq2x7Q==",
                        "dqWbidRFxkn/yn2BQTai3Hy1of8LMeqKfk/NpFZ3MQ0=",
                        "ZGdGJKfr4JzIDk++XheV/w==",
                        "XKX9C/ZGQoc+5e2uKV5GCg==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 474,
                    Question = "MaFJi7tWoEXMj/M5sGkg/8YugexFWEx7Ym0JBNuXSc7OwGtYbqpUtN2ypBRtLuU6mE3WuG9vAHAV0wiQCyWtkWqsCMOY8WcwQtqevzsTaLgghmwJTkcma72QzmtFG2f4zsXa33k7UH2HtbY1OCS6Xw==",
                    AnswerHash = -1034131696,
                    RawAnswerCount = 9,
                    RawAnswer = "gSlVHuUt/5D11wnD5Vf0pD8CWuODPU8i5K6amj/ZIRggsyhVD+hWpQCIxIjKRZP5",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:36-44",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 475,
                    Question = "3pULrq6RiEvvW3tvvf60uLumyBMnm4Ddi8PZhngqmTUWXn+sNXURTpLlJY8oB4pgYohvwoqlIfeZy7TBDCOtUvMgYZdmE45dsNoYmeji8aRydgJZ06j4IfWy+tVshCC7",
                    AnswerHash = -1094548753,
                    RawAnswerCount = 1,
                    RawAnswer = "CyaLg8V/Fw0XOfLEAe7deg==",
                    WrongAnswers = new List<string> {
                        "RENumDiDLGchv+yQO5JZkA==",
                        "4SAcvg73p/acUZ1+fCvpqA==",
                        "Dj65yCR571q0wsHpCzpSxg==",
                        "vMueF9orW+HPCvUgX4NhzQ==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 476,
                    Question = "cvrbfRRPWsWSIISwnkoij3tUvBLYDaK/BHhNPW+RD1hPbOpAm4XOARrrZyxDCCZj0iHtdnOCOuIkC57FrX8u2Q==",
                    AnswerHash = 2008877063,
                    RawAnswerCount = 6,
                    RawAnswer = "bfOD0CEu+QjYJJtT0wCfuP8Xcq+R+35RgurY7PN2YHA=",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 477,
                    Question = "LdqueXrA7jxkn/BzhWX30kssNo7T++wgpLUzTQRVINus6HWMRahXugDkz8rgbQ7ht2CKm2Sln/07RCcs2RlmuFSsh3LX13cEQelueFAJZVg=",
                    AnswerHash = 2058816618,
                    RawAnswerCount = 1,
                    RawAnswer = "mHKwzJ7pGG7FJ58IKgjvnQ==",
                    WrongAnswers = new List<string> {
                        "uO0ocuAlEOpHvgqOJSnbig==",
                        "OZkzBE9J0qqlaEr8C9VDrw==",
                        "D14iyTzYo/hCkAzyxNNUjwWuIb4lHEP9/ZsG9ERDTWU=",
                        "UliUe9WHhzwgocVokVyz7w==",
                    },
                    Passage = "Luke 17:26-28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 478,
                    Question = "V8xJBuAVxDf5AHdnvn3pMZIMzQrLSIouS3nw88GhlS3GcCmPzhb8mbnTcdiar4XmpNS7DlhwP61MlAdLwiFmjQ==",
                    AnswerHash = -468384290,
                    RawAnswerCount = 16,
                    RawAnswer = "pKzwpI8gdqSNnuFrNTVIQt+OE9gS3Dff10PknthzQ+yClDDSPcHpY8cMuLPyQ7MLL5IudsVzPj4xQspSZEV1PO5InxcEEVunahqnAgTTOhURrR8kdN5/scVHOI2osv6s",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:8; Revelation 20:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 479,
                    Question = "mpx2onW7wUGpUdwUkOuBIs9we2R2QXncu9wyos9aQsq5lMxwFakd/ify+YKMTfxG2hiK/LVPUIlC7barjHIOCg==",
                    AnswerHash = 1085440376,
                    RawAnswerCount = 5,
                    RawAnswer = "Gd0c6CPgAoGXqMOUQbHFfPO56vpu4eIns35ywN5pPOnHt3iwVEp05w3HrGQxhNxK",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17; 2 Thessalonians 2:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 480,
                    Question = "YznJqAEiuflYmq/Agt6TTO61azDlLs/vg2WCrdyfbn23z9O/T/1HZN/U49BrBKKHQjBGCDDnKVEWaOi6K5ch26OP48SkTXkBJEKEb7BSFBYxGAvcdeo5H6gy9UbzVMcrAJEvS3LV3VSw1AGTgXJGmQ==",
                    AnswerHash = -1101317718,
                    RawAnswerCount = 10,
                    RawAnswer = "32e1v09VzfwNKGOXL4XDN3N5eLZfVVDC9nP69/cu3GTZiWYZco+7sAkxc95H8FTTZDID6Od3rJTfIW10VdLysw==",
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
