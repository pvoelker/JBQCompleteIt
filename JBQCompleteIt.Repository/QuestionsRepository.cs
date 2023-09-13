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
            const string key = "y/svHWdj5BUDJ5sA6dkxfg==";

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
                    Question = "8AzKJAYGJalof7HTw4T22FmnXwUahWRf0nP1PX+mDk8=",
                    AnswerHash = -667982030,
                    RawAnswerCount = 16,
                    RawAnswer = "JsjvHeamTuhSy/plizna2WFX3QXCT1shstEFfjr21y7SIBWpSPIw/NmW45L5Pf87gIfYPpEXNe02uC8BAJL36ciqR0RLAhK/lyly0QaxXNjkYHwiisjgEGEIfvEEnSK+",
                    WrongAnswers = null,
                    Passage = "2 Peter 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 290,
                    Question = "yRSs2NBmQqDux4cEUE7BapIcx4t9IAKBiFYNKvLYioGv93q3sBqju35CgyOhiRheJX3YUvVgVHZCyZvZYcmcZg==",
                    AnswerHash = 1445130117,
                    RawAnswerCount = 8,
                    RawAnswer = "T6ijyTVH+GoHMGXWNC1WTFvYM9tKdWbe4pVok2AUfgfa2COgulMt54lk5nB4voes",
                    WrongAnswers = null,
                    Passage = "Psalm 119:160; 1 Thessalonians 2:13; 1 Peter 1:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 291,
                    Question = "yRSs2NBmQqDux4cEUE7BapIcx4t9IAKBiFYNKvLYioE0B5yS5U/+e8XkMyIYRica0AWEcxivKpDTUKKZDsXQEg==",
                    AnswerHash = -745663469,
                    RawAnswerCount = 13,
                    RawAnswer = "tbi6Lq4a0guM1XpEtS7c9u8g5yPVmOAu1jBLszCQ0UamiYqnBjq83QktHLGgJqY0irgSolZ1tVYmRbeQ5mEhLEQ1OEHBo2ruMStUnjqmn+M=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 292,
                    Question = "yRSs2NBmQqDux4cEUE7BapIcx4t9IAKBiFYNKvLYioHNjn5i2ksUFt6AokWLyTi3iQ82TWTEtrQTsFEe2QRvRB4fioQoWRprptXMmiwnzgNtPXS14rhVSqkHy2vkbhsZ",
                    AnswerHash = 1109877373,
                    RawAnswerCount = 16,
                    RawAnswer = "E6Xy3PkfC8XYn6SGw5dVS/0Sod6DJ/P14lUnfBD8FHMorTFc6pilFfy/7Ws274DnytqPebAchiRp2WBuMikYx4VlOb5DX5FISa5K9hEvILE=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 293,
                    Question = "odmNhpu0lJFKRhs9s1UN7J9hNzNdVKz1OISzrmNpzfE=",
                    AnswerHash = 1285372605,
                    RawAnswerCount = 11,
                    RawAnswer = "A2j66fWm+TGtvdvldZ4NNJpiYh0NYfTJgJNPggXSt0iuVVI/mpsUgZZuaLYFF7i/3co/WUwKkTyPh5LWAvzqYlF1dhu7oO/FP9JvBAj0B0M=",
                    WrongAnswers = null,
                    Passage = "Matthew 24:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 294,
                    Question = "gFNlfHoBaXjT4usKnWDkxINA01kwWtVvA8j5pRJJ03hiOzrabdXCkYIIVwNj+xhJ",
                    AnswerHash = 348313763,
                    RawAnswerCount = 15,
                    RawAnswer = "HAf8hLjNuCS6MTyt1d5LHL3r8nfsSkdxQPKT6LL7JirMAx/BmMDUadVm+9rKEgyxSTLknLy7y1+8oZ1qe7HvYyLVYjPP6QokGhfOFnYba+U=",
                    WrongAnswers = null,
                    Passage = "Psalm 119:11",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 295,
                    Question = "FU/GRPGVJBYYEHkmR/y/ZwUZDEwJDzhweyo5mqK7uyKImn5lELH9QRwknUeEBmbL",
                    AnswerHash = -331276435,
                    RawAnswerCount = 17,
                    RawAnswer = "52Tzg1ny8Q+xtxIZIsBA0rvKMrPsSvl8kSyiyfw8t165y2dqXr5wnq+YNGVKCI5hXA33z+AphlLSvPhFhaj/vqREsrM0jlbY0s+4cvySvKFbzwJWaZp89sXt0mqxdb0Q",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 296,
                    Question = "LcYSq+66m2s0iAxr6WUSBNd4TMNUtuBFFn3Lvpjhna/3x4mcVD8upESeiXLP7dDBjZMEWqJZbxaodTgnAiP8tA==",
                    AnswerHash = 1580709315,
                    RawAnswerCount = 1,
                    RawAnswer = "94UkJXcB5lH7oL7sE0nHzRJR2PNjuCuMiGM6lMWnbXw=",
                    WrongAnswers = new List<string> {
                        "BhoQxcLSWYgf20jHzdi3fLyzVaiCVVClL6oTU7AAuvo=",
                        "q68EvWcpiNZLkreA6W12EQ==",
                        "ZM8XRGOhGwCn1khuG7kf5Q==",
                        "GojzcTlIRe5zlGoVOXxCnw==",
                        "2YVHma+A2ZgWIQwEJPWYDw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 297,
                    Question = "rRT2h2PqxJ/5PidRJe2GhKI83VeMzaqk0i1T1PNTOmfjrfVDaELVM7aL/pJgnw2t",
                    AnswerHash = 1230070152,
                    RawAnswerCount = 1,
                    RawAnswer = "insHJCO+gb+9sOqQ3pwLPw==",
                    WrongAnswers = new List<string> {
                        "fIFvc1ZUngQWCcLSUVhh5g==",
                        "hLzVSt8xBUgH13Xk1HaKFQ==",
                        "XUfATymYbkwEsSQhFHxMpw==",
                        "8nyZNOZy7wdtmycL+cjbog==",
                        "4B8N9MeaP5e6EhsBFXO3rA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 298,
                    Question = "hq9eCNWglFwSbHmXwWjY2LZDeEJbwjqLreUiWU/IMH0iYY5Z7SDs5bY8LOl9aODS",
                    AnswerHash = -1004211923,
                    RawAnswerCount = 1,
                    RawAnswer = "9sRlmvrDlzND4XKJ0UN9qsOpn7ka3NBCeSJ0RAiPsku4eYPfPXo1QGig4kUaP5Ll",
                    WrongAnswers = new List<string> {
                        "Ck0CB8Uc+3NhLev/Vui9VCsodxVg+jHiLXJV8zI8xIo=",
                        "IiissDWEqmTGEoAQ1VTqZp9AH9bpMwAoh5TVWNQybzE=",
                        "4LlCLDQQOmOoCGDtGW89qmd6tkK1vmqEVF0sQFAZC+l1sv92aun144N35SSPaZAT",
                        "piWnsSevEtNBwzfWWPMxlVzy7tME1lHBEAMii2Oye3o=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 299,
                    Question = "BZyq51kggCmDaZtzxQs7wLeucDIh8En09ihpNUHzLbdyyQP0t4pjqR9rws2+Q3da",
                    AnswerHash = 957250939,
                    RawAnswerCount = 1,
                    RawAnswer = "aUV5H7+mneBNFX3fm9JPbakO+wbCrKqYFJrTYNrfxWo=",
                    WrongAnswers = new List<string> {
                        "dT3CykYEudpFoMrahoLgZg==",
                        "tIPZU8ib/fy5mjB5IXI/pQ==",
                        "xi+R+D+vktwAOm1aKKNVrQ==",
                        "/k/h1eM1Y5nL3HijudLPZMCjJXwXyPN7djrPJ2LRqIU=",
                        "o9co+4QKXrYs5eK1WA3lgbA9Q6MHun811UgPi4ar8Mo=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 300,
                    Question = "J4UoDWrec/XyaW8BQG96h6hbMgxfokypY85zA+UrKdo=",
                    AnswerHash = 1290944787,
                    RawAnswerCount = 14,
                    RawAnswer = "+skR8VLroEsXwvSmVt9H1SWTsMezYQerDmKKanmwY5dZeVb9f+RE8KshUlONLAH9rMLSp6JiwKxTu7QdKrTXcMCgt3ZnNdgsckq6Du/l/m2sXm0l6BRQHWvEixClyqTV",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 301,
                    Question = "HXOErc2rTPRKAn+jwfcs1/MHdqOmcLQa/JAtUeMBMp+IeQHulbNbDG7a5woMaqseLaYbQgcRT+VOnTx9DA9aGQ==",
                    AnswerHash = 1132019384,
                    RawAnswerCount = 1,
                    RawAnswer = "DBRcAJv5z69BEVppqnGtDyRY5F3j4JyhUvGVFZkkVLk=",
                    WrongAnswers = new List<string> {
                        "G5FyLvnYHxdRMyZD5zue2fSl4x5WRU58+M4Bo/ob6J9gqSvCZCNw3S9G5DCloxib+aF4Xxwckj88vd9xmVWt3A==",
                        "8wj6CZJCOQUg1fYl26xSpGfZbUwRB+rsZ34sQUiJQ10=",
                        "lSbVHFYr6esN5vFaYkCCNrY3p8TI1nqg+mbynyceO/tBw0PQYhBY4bDIvrCmJpXJ",
                        "leH5nKP5vDl+16+jV3UtCm6VPvourzRgK0umH3Z4oyc=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 302,
                    Question = "OitQ2N3QofUnaK5bSosmSCy1/ouyPsfYF7sAm1y952OXZTXYqLN94r7OQMRJOBm09wiKaYD7cQr7KD/AN1SWKg==",
                    AnswerHash = 162651324,
                    RawAnswerCount = 1,
                    RawAnswer = "uWQpqPWsSvYkltqq0Ng+HA==",
                    WrongAnswers = new List<string> {
                        "fqVU+UGiPrnOPaBFv+7O8w==",
                        "Qrc5uNQDMNxhLI4HsTvb3A==",
                        "YrwLDLiqqnicNPxBvllLrQ==",
                        "7HdA9nfu5IrJFE4GNUP2sQ==",
                        "702Spg2FopFbkRIXaaUVKA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 303,
                    Question = "UJ16mn70Gloa28ltysEjVS8ksx331yyrJxmEX9/LrDHBIJq80jd0shW/QMK5uW2c",
                    AnswerHash = 817327109,
                    RawAnswerCount = 17,
                    RawAnswer = "tBicckP4QvUPbK/vRCOUKGnD9zJdMrRDKr4ZjIG1HLllbZOpb8aC5N2xGrfutfENWlArNM1PKdYPBYamJyy7VEfSlbJq7L6VvDAoTUddKwvXdMkkNQtlRdTC0PXei3ED8lzVkukWSwT2jy0/y5Aunw==",
                    WrongAnswers = null,
                    Passage = "Hebrews 7:11-28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 304,
                    Question = "Rqk/4q9j3cp/S+vQcmcwBgMJGkheRK09Lx+xKd/TD3q7pT3jNinqOUnqG4/GWznZLXWJChzkI4Y6l1Bb44b898/7jPYVYQ+q7WIegq4Gh9hyLYfgc3tE8tScqfpSonV8o1BzfaxWBcO6nhFZKeRy3A==",
                    AnswerHash = -313339779,
                    RawAnswerCount = 1,
                    RawAnswer = "fIFvc1ZUngQWCcLSUVhh5g==",
                    WrongAnswers = new List<string> {
                        "hLzVSt8xBUgH13Xk1HaKFQ==",
                        "XUfATymYbkwEsSQhFHxMpw==",
                        "8nyZNOZy7wdtmycL+cjbog==",
                        "bIF6v8Y+YZogNxNswFezyw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 305,
                    Question = "iD8hB7QCdVJrxIByMbaOBOncdvxu8lnjUt3d/dKBOZCzwiefbPFjOUbao4X40H0/EBQzIaHMWlAH7hkpOdEEO8Pr2GPDxCRKarGLvKzC8oepB+bMQLj39umWmjMBXkqsPfYDBfXIbTQdqfSPQ7I8GA==",
                    AnswerHash = -1071478185,
                    RawAnswerCount = 1,
                    RawAnswer = "2YXQmFKNhi3iQJDNNwSNKRD36V77tEhHBPNa8DqK3qA=",
                    WrongAnswers = new List<string> {
                        "xeSc6NXrva0Rj3WWlQiZTRZ3B+YyjS8lGkI/SnV8TfI=",
                        "wmrPd3yYOHSxvthmboInwAMUC8cPQW426ip0IjiffAU=",
                        "Sxc8Ce9Tt9iZuqG0mKL1u+D+igf6VWCULLeQM4Jb+ug=",
                        "K4F4GG5G0a5hqFwxgX8z4ex8WNk58qLakDy48kNGuLk=",
                        "9B1aJbtYWYOdDcKgGOfraFYmZAy15TBp0RfLJNu3ZvM=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 306,
                    Question = "sk0x7s1FKLZ0ew+8QxRkiHHAuxQ8Un+KnBenMlIqNS4YbadXwovabZ+gVSYYHg/D",
                    AnswerHash = 702958819,
                    RawAnswerCount = 10,
                    RawAnswer = "AckHVsio6zpvQzHcULzlk/cyKV5C8fVSTQ2UNgSCkmfMQzFhi++opwOPcNT7r2xee6346gi/2raAqrnIy/yc2w==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19; Acts 10:38; 2 Corinthians 13:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 307,
                    Question = "yRSs2NBmQqDux4cEUE7BarnqfiPTQpGrU5KbW1Cx28Rc5v29+ELx5kC1+uwZF3o6H1QvW/Ic3SQUr999cCPbVg==",
                    AnswerHash = -1506996964,
                    RawAnswerCount = 14,
                    RawAnswer = "/AOLKxP6TVXRDBPZlWna3/6gRJTUuooAsS7uNexUafzgOVnGBrVuyGwjk1IEsZaV2joxK+onORkgryu3EZY3t3GhJw7AC8+LqrrXXlKUnGc=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 308,
                    Question = "yRSs2NBmQqDux4cEUE7BarnqfiPTQpGrU5KbW1Cx28TDqqpFcJ52n8N5elPIPDmTNeDxGHvsF4sTO/q83zaB/A==",
                    AnswerHash = -510779922,
                    RawAnswerCount = 7,
                    RawAnswer = "sxZ1S6OmEZEyy/eYcDKeQUh3K3z++Q24uNI9CCXc6foawbWQ06EP0dIyKqOOfFrV",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 309,
                    Question = "yRSs2NBmQqDux4cEUE7BarnqfiPTQpGrU5KbW1Cx28Slzrx0ty0Tsqlz65Lv+0drUN8rLi+/MH6J0lgMVGVLNA==",
                    AnswerHash = 427585606,
                    RawAnswerCount = 1,
                    RawAnswer = "kg/mtpF9/qYrZk+nJK8Uez/grFK2pvKDRqlEtXFjr9Y=",
                    WrongAnswers = new List<string> {
                        "M1w0EfzqmpS2PDo2NXppfEc84pd2aayM8tjqUf+WH3I=",
                        "Hc57ooy9RcEwIsazCNefD/McKhqLaeWnk06fGJMsKqk=",
                        "xzy2xVNRxPjQgsfd5ohO+0wzZTJgNJSS0nl/ghvOnvU=",
                        "/7jJNq32BJ/vzV8zO7ID4wEz5yCO84F05rscScpz4U0=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 310,
                    Question = "yRSs2NBmQqDux4cEUE7BarnqfiPTQpGrU5KbW1Cx28RLs2S5tEBygPT1wxPQ4xyR6nHarlqrScEOZqF6ha1zOw==",
                    AnswerHash = -1200576594,
                    RawAnswerCount = 5,
                    RawAnswer = "ZjrukhSPymXXAq+FQ5gnYK0f648+fiEkSO6dhL5m6pappHtg9sZdhrpKK+n+Qa3K",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 311,
                    Question = "HbWRz3r4ohbApXLCaXeCL6Lz5u83DEa9YUiLnz4AHbTnKFB1cbfFn7HsLcfTWU2s",
                    AnswerHash = -1800704622,
                    RawAnswerCount = 17,
                    RawAnswer = "IT9/kGP6NqnXFB6VDoMZfzPmI9I5631CWfsHu7qfd0UQ3PEPMDQ/gNpKhxK6otY8J+Lpl/CmLKkbrWIulEWt03aJFkZR3GCuW7mjE4n07Gted3o45dVfAEUZPw9RcUcn",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 312,
                    Question = "Oui7sLYMjtTEsGb/p6Jz286ysj9j6g/kDXOLTvYqgI+Ho77j/3n2KnnPTkYEhsyPvucp6LAsP3st6vnIRCcfHw==",
                    AnswerHash = 1270484111,
                    RawAnswerCount = 1,
                    RawAnswer = "M2bAHoHauDkGRVChBvW/DXn1q4znn7BYiF0XYA5xZ+Q=",
                    WrongAnswers = new List<string> {
                        "7xpxm3A3x6UnHCMlFqmmn93SK0trPwTS0ICKeSanqZk=",
                        "O99T4cmPjv6XwnDZfLPlzw==",
                        "dL7Q9Y6wJQtWfb3VaZSzRQ==",
                        "qcBujdq1RmkLsA+4/Ffj36GBxV1G0Cs1j+w7XHy5dsI=",
                    },
                    Passage = "Proverbs 9:10",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 313,
                    Question = "0pHWn8qOVmCY/XKwn+fR/AabNgsO+21Ldk58yY0QQUHRoPcsjow+wLVxvv9MpIbK",
                    AnswerHash = -2071244352,
                    RawAnswerCount = 10,
                    RawAnswer = "v155wxs7AKfBxMplicxA1c/o3wozhqswHaPb4W12MUciWAVQIO3WbnX4NIaOIYcIOGrVHKC/AZ2tP8BRuNRt/Q==",
                    WrongAnswers = null,
                    Passage = "John 4:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 314,
                    Question = "mZ2k5s1fQZm9V4w26yTEaYfxd8MpVvA5ut3YI+T5B+s=",
                    AnswerHash = 1206396199,
                    RawAnswerCount = 17,
                    RawAnswer = "X6M0iXydFxswJyDwMWpEw7F3c2s+CZibBHpBMUsCmUkp9KJv8/Ez4shGqSSXxF2RXAAdVRd3Tc6qnhPz52BdilydZ/E8/PdVIffP1eHC4nSEPpk1Ove4VVvrQ3TZdOTi",
                    WrongAnswers = null,
                    Passage = "John 1:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 315,
                    Question = "amweSxxyKOPYU6lRAJq6sG5VI8AUgPSu2RkftGy5/cmqRJlUpvVASDqFbvnqXp6J",
                    AnswerHash = 813995201,
                    RawAnswerCount = 1,
                    RawAnswer = "3QKRXEQ+rG16dpmNruuI5A==",
                    WrongAnswers = new List<string> {
                        "dQwXbKxbdW+tUv+JiWlI8Q==",
                        "wFYc2zuxNdw4avIzknIgjA==",
                        "yg1iT899HqKhTFk/cIyz2g==",
                        "fgPIRh8jgGJhldpe6n32rBQtDSpKHy0cfJ/+DqkndjA=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 316,
                    Question = "amweSxxyKOPYU6lRAJq6sKH9CoPa2/Al6Pt6GmLwAewm2a78vlmP4idNvyyzqGPY",
                    AnswerHash = -925466199,
                    RawAnswerCount = 1,
                    RawAnswer = "dQwXbKxbdW+tUv+JiWlI8Q==",
                    WrongAnswers = new List<string> {
                        "3QKRXEQ+rG16dpmNruuI5A==",
                        "wFYc2zuxNdw4avIzknIgjA==",
                        "fxP+USRsJDvXxNFQZgmext69K7rqJ3lTHzQ1bNfUFlY=",
                        "fLHNUbFmvg9tLr7BDjXrHLVDwaw8jm/Kngzih2mluNU=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 317,
                    Question = "7HOftAV8CqBqQoLeBwjKfR9TSd9gR2SxgoD5XCgkAPT/Rv+TszGHt6LCygoQT536KeEGhYz6HD1TIeeKoxtn3w==",
                    AnswerHash = -717961767,
                    RawAnswerCount = 9,
                    RawAnswer = "MrNrUn+N2qG/TbWGS66gFM/JPxf7dD3zel5M8jzWZXa2pvTgJWYEbnJXMx43c2c3q9YzpE3HERNbzzQQPb00Ww==",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 318,
                    Question = "vzetmatGhlTdMsb9sXW+089d8G6/53c88XL0invBDU/mNfYsa4d+/FG1OUuzcUxJ",
                    AnswerHash = -952342553,
                    RawAnswerCount = 28,
                    RawAnswer = "igrMoRCaY4SrYKHy4ku083IO/GnDYO2C9IkwzjNYZzbZQrgOdwyDGQv0fJQOmUnwy0xf4zffhcOudSdnDjgg4xEz5ilu/cRoDkPSGOFmdyPYokKtorEUJYTBnqvC6D56ehuIywnI3HX8It1X8yPqEGIT9gecjPOvo9p5vjEn5ERKyDRqIby8Wc190BgJ+2BgxKJ2kgd7Gotu/TrHAaDenmfgP0mv1UgmHZ4UzLjrK2g=",
                    WrongAnswers = null,
                    Passage = "John 1:3-4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 319,
                    Question = "eRLyVUsV4Ujd35XPHP91MyfYqd3lNNNpi2HRXifI0PH2oQye4o4Glj/1Cmu1/YjIT++ikJCNtEJ6f8cb4I0gY6GyZX3UB47uAuOUMRRMcF5mc9OQoL8G5721igLxPij0",
                    AnswerHash = -511694587,
                    RawAnswerCount = 1,
                    RawAnswer = "gIB6sO3yLkoSwuySWXJ8MA==",
                    WrongAnswers = new List<string> {
                        "m60clg9ic1yRtket19cspA==",
                        "8SugO8RrkdktXbSVWeQjyg==",
                        "9OtefqGK07U8NDx9WV2fzQ==",
                        "3z+kgpSH4GYXXjDgDG/Ckg==",
                        "XGKhhxJg6ewSKIv9MSrG/w==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 320,
                    Question = "OmUn5d9cDbUIEAo3/DrY5vRXNfmiKfdEnaKLIorJOq9ol+LZ5Pb0nz+33YdJZ1Ul",
                    AnswerHash = -1583202301,
                    RawAnswerCount = 12,
                    RawAnswer = "/ENlkmYw8XwOZkkXZ01cU9ZBIHBKhpw8iouMIYjmOl2KJoGexANqfUfzkYuCto1HguxVrIoSrUpyk8kMAKzHVNe8V91H53tXKSaKNhbv+/o=",
                    WrongAnswers = null,
                    Passage = "Genesis 3:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 321,
                    Question = "ZWcLgZ6Zii09vXjsIvnPaFZsF7ncS3JAXQ9ETjD2fchnNF60tSfHw3CIq1SWfQjVeDB1VB3GihTdvgIsfd3Etw==",
                    AnswerHash = 1759569379,
                    RawAnswerCount = 9,
                    RawAnswer = "0EINhTcMz9wy8GKaNTHBPBrYSQb8T4m+0rYFMr1Y5MmlhE8hA/maBaZ6fxUHyTZDFNKuFRes7QotYOIA3h2MwaWOVDTkoQUR2L5G/XZwhcE=",
                    WrongAnswers = null,
                    Passage = "John 12:31; Colossians 2:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 322,
                    Question = "I2QpioVXtRs542tPaXp1DCKE0WagLp8spct07CuPchll5od+wDeCYkFjEj6m0ahk",
                    AnswerHash = 1395362436,
                    RawAnswerCount = 13,
                    RawAnswer = "l48gS6sSS3nhl5qxKqG19u2rqQooW5qnr2/Bje9rekCoio1EJ9X+hNSUe2rn6ouZKAKCCkRaaDGe0d81cGKLC2CkyQAFXrDoztIiJN+bmUCIs6WMA2N+OSmYIzQw5yb1",
                    WrongAnswers = null,
                    Passage = "Genesis 12:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 323,
                    Question = "nlVgZ6NDz/aYDdZX76Q7bg5iicy6x4n1vdWcGqaf91t6/dgwOdPph9gdyAMhG2Gep6gBz5oHrmDipytwbiVwweGFQDGvbovHoE4EzPvU8r2kVwLNHPKhixTUaHfpwOSF",
                    AnswerHash = 197035039,
                    RawAnswerCount = 1,
                    RawAnswer = "R9PZjgFM26ihf14A+bOJvw==",
                    WrongAnswers = new List<string> {
                        "fqVU+UGiPrnOPaBFv+7O8w==",
                        "insHJCO+gb+9sOqQ3pwLPw==",
                        "67gNk/sle7vbUMItR/wS8Q==",
                        "T1iLV5jeiFZvDJpYh44CoQ==",
                        "gFzmUsJXOhAsJVyZmf6jlw==",
                    },
                    Passage = "Galatians 3:16",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 324,
                    Question = "+neHB/3VhHIoSz7ABuwbhmvGYZBlBrRDYX5Ed+pJmgZvgWAiDytLoX/DKs2t7GHS",
                    AnswerHash = -2120472408,
                    RawAnswerCount = 9,
                    RawAnswer = "hbYnHFL7/lPmALMVVEL+HsLPymju+j7Gd2Jl58N9eRB8HPUld4lRpG9MCNO9Ddyg",
                    WrongAnswers = null,
                    Passage = "John 1:1,2,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 325,
                    Question = "ycOFH+k7nRHGhIKsniHXNXbX3aae95rEKnTbvDGzotDFDS2ywHcHhENgr4c2hSyYv+9JzBL5Kh4w7/ObpEK2hg==",
                    AnswerHash = -836704484,
                    RawAnswerCount = 21,
                    RawAnswer = "6il5VDzzTCIl3Gh0DbPaMugsVBCOXNP28sDlin6u+z4/nkSYnw/fL9FO+Gmz2ISqqVCkBK6K77hLmqHwdHOxg6O9y0d9dIXk/sGHLxThJH2w2UaQZquRSnkaRlxmAayiUQqphVgRWn0DU1oPvGpixw==",
                    WrongAnswers = null,
                    Passage = "John 10:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 326,
                    Question = "zLq7sFjRLcsiNzlJcHQh+BGFDktok0aMnbKIf+uj2usLrTNGWIgxWdqHfrnoJZEY6AeY3WUsS0o8oUKXk6+44Q==",
                    AnswerHash = 1333993614,
                    RawAnswerCount = 14,
                    RawAnswer = "1MnWBPir6/LrZHCjFN0hE2PjqBdcU074FbVZYH31X+fq5A207LaOEtgvDYNOZQOG3ac8vmCB1rNoB9+HtwdNYg==",
                    WrongAnswers = null,
                    Passage = "Luke 19:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 327,
                    Question = "0zroqWq3PXICvTk3L0pV9pro7jYp/kPK9Gd0tDKZd9OVMx3Nb3odGWsrsxYLW6IfuoiNhWJV3/2eiq3cVQBxrA==",
                    AnswerHash = 1058273992,
                    RawAnswerCount = 4,
                    RawAnswer = "w+VThtlgmeB1fLDPsEo1Vpz+sWkW9DIxm9RgSPoJQ9w=",
                    WrongAnswers = null,
                    Passage = "Matthew 4:4-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 328,
                    Question = "mg18fUOl2BvNm6NSGrcgjuqlc0OWgUQkspgYVY8EgAicMQB3GKWOQCZsmgteSpgeQ56m0kxzCgyPCrCyf1QtgQ==",
                    AnswerHash = -2006726003,
                    RawAnswerCount = 20,
                    RawAnswer = "7raVppr15TWq92jo0LZmisKWclZiZjtKOyynq5Cfo90LUMdmXtN3+Zv67uYOWx6s6lH0M7XJd6iaCMEsza9JU2a0UypimPx5VlOFwQWRcBqL0/oooFh/99grC7dXJPL7fLnCy79DPAICF6bgzzyUDCg1zCpyIM6fCzTzuu+XU/M=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:23; John 1:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 329,
                    Question = "o8m8+kyNNO5Df/IFrpRDWWnzQJoipNDQy66ka19gXBlzkHNxxIYZ54F3IQJaBPOZr26u7PRifdDYu+kNdyALaA==",
                    AnswerHash = -603964564,
                    RawAnswerCount = 9,
                    RawAnswer = "wC2n29jOV5q9tl/4JjzW1EYkwXOykjsJVFm5/iMi7TwJXLB169XlUSNa7aCm8zNNFxnXJFFoTVb3dAcAhf9PEQ==",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 330,
                    Question = "znfDTSHaDU896ccNuLIjofOaEERzrvKf1EIRsKiUuG/4ATNGk1JQkg4gystXQ8Fi",
                    AnswerHash = -2069817053,
                    RawAnswerCount = 5,
                    RawAnswer = "nw0tnQRw6E07nEMBNxibwBJKwhRzGlYZTqmzg4rrKUc=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 331,
                    Question = "znfDTSHaDU896ccNuLIjoT/IuKa+jB6vVK1dH7jtgBRX5NAu+CXijSvp7D62bHcD",
                    AnswerHash = 545820274,
                    RawAnswerCount = 5,
                    RawAnswer = "pgFNMrGZ8f1AuhRCRqVhozRMT/BsnfZdrxhOEgOGIM8=",
                    WrongAnswers = null,
                    Passage = "Psalm 2:2; Acts 4:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 332,
                    Question = "JRSiFHi99Mt2j6F/u6XnHZIEKC4ap8T2OhN5m3X295M=",
                    AnswerHash = 2110201282,
                    RawAnswerCount = 6,
                    RawAnswer = "IOOAUOJGWeSgWA/f15DfGRXuWm7r8j2fyxDZcplf0e0=",
                    WrongAnswers = null,
                    Passage = "Acts 10:38",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 333,
                    Question = "gSpxbxXezZNI7CtbOq1CkRYejn//az9vHpUriOQjnvuC/czuMNRbfIz/PgOykhzwvoYlhEVvAfTbCnlSTAxSng==",
                    AnswerHash = 1279100646,
                    RawAnswerCount = 1,
                    RawAnswer = "/V4p/b4UePiHfaX6en+PUg==",
                    WrongAnswers = new List<string> {
                        "/0RtF++sQ0l2mo3eiy4w9w==",
                        "sR1bc4Yj6Iwt3KqKroCkFg==",
                        "XJRaH4ca7TaZZodNBeRlTQ==",
                        "ebkDOJtmVvk85gCyx+ZL7A==",
                    },
                    Passage = "John 1:41",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 334,
                    Question = "OKocsRUZbBm6P+dj4Kf7TinlVcC8k65Yz0lh+Z5s+b36Z4GN+DtL1vQe8VdyqgpmIuaZOfcLgI+BpKeASg2lgQ==",
                    AnswerHash = -1680693548,
                    RawAnswerCount = 19,
                    RawAnswer = "MZHnDxUmBSkxP757R9R5yM1/mA35hAlflEeOmWsdu/rwN7MHT/bq3lUMCt+oj2gtWar2iat7mKm2Ew2dxmrXmN/Xmx+3moA8vHxdKzJc29yRfOwzAnPF/1OUF62Z+Z9y",
                    WrongAnswers = null,
                    Passage = "Acts 1:5",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 335,
                    Question = "4vSZjKNbxvVPL7PGigTKDQ47J7LN55PcH/HkMYlRoDyPJLDROMKz8bz6yJ9CLgJ2DNzK+93SecI/1lHnHo8098FlJzYXE6iYezcxFwaZnjJ+H8LgMGk8o0NauA4BBek23K1poJ6UPVklcVXzJZI53g==",
                    AnswerHash = -1658799858,
                    RawAnswerCount = 1,
                    RawAnswer = "WeNSa1pG4NuLRYoaGALHt57TOkXp0GAyYuFuL2YvF1Q=",
                    WrongAnswers = new List<string> {
                        "xAfXyTAvwD61nYIeVdFtPQ==",
                        "iRy0arJtdB9z2VorJlzcRg==",
                        "OlDiVUYcKP4q4MYaGPDf/A==",
                        "N4IAUekD84/N+yDu0ghqDg==",
                    },
                    Passage = "John 10:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 336,
                    Question = "DL9mb5zrrdTMtzA5a19CSqn3oe52i7JU8a4LazonYKbbsOAb4PMSeT1E8D+ZAPV3fZ+bZkc15q4yvOHzd9lKubHdcGSeeQL+p7lR1/IOV2ltWGQaQl5pX5JvzflBBybs",
                    AnswerHash = 1921621194,
                    RawAnswerCount = 27,
                    RawAnswer = "x9G4pQA6bIBC2WHFumSaKmv8xqfJMWuz/jYS5wHA8ny2ArNidgvqfuHCM787vKtqV6Gzb3PcW3oazeEYVubImnQp433MuhZaY4Bu2PvGcwgST5aFDN+oR72CAIgT+zdUmo9ePllAWtO4ufa+YeKuj1DD6iPZqf4rv4PdwrYOnD3bi9OEeVuS3qlFg+ypOwRb",
                    WrongAnswers = null,
                    Passage = "Hebrews 4:14,15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 337,
                    Question = "aJ7LuuwFr4LQ8rhBsP+YcEDHb7UjkbF2xa4zDPEzG2cmvar2NZ/tqOZJ37bTmo8f",
                    AnswerHash = 468407046,
                    RawAnswerCount = 14,
                    RawAnswer = "TmTrul7LJDBgCIzScag+RopmLR8ZIBLEMkNJ1s+svCIZ1+zW/9M9cz6iQ4hAa/T8Zuz9TUKfnOESNhtzWtdhRb2zD+kMjYrQ3x+w8p0CQ5w=",
                    WrongAnswers = null,
                    Passage = "Romans 1:4; John 8:28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 338,
                    Question = "KYDMnC1QdeV5hwt9wsgUq4q8QxO741a7F8Wi8e+gPjCNkjIIqFnyQ5i3cKvbkgZuL4UpewGFfqF+5HIbFABCwo8oO+CLr6CSSiwp5X0XQic=",
                    AnswerHash = 1767604669,
                    RawAnswerCount = 12,
                    RawAnswer = "4ykHFVSVRiGJUirNEX+RgKYNhO+JpjaALoKCt48gSkE2qQqXJCateTiPokmOTmQ65mWCn/8z79cVQGIm+TTmCw==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 339,
                    Question = "pipmE9NQG/aCw4pmoOU65FigWDQlnLCWCBLulLecia/3w2qonC6XB0CIxK697kFQTNLYh0GqqNqsV0XTy+Pj0EG844TanOITL/l1abDkB7g=",
                    AnswerHash = 142242653,
                    RawAnswerCount = 1,
                    RawAnswer = "W6M66c8FnXEbO5PmmSmyXg==",
                    WrongAnswers = new List<string> {
                        "0tH/OAH9YmEzfB9wNetCPw==",
                        "HRVkHrORkoOm3O232eITYA==",
                        "3z+kgpSH4GYXXjDgDG/Ckg==",
                        "MYtJwvnmSN2qhxWbn57jZQ==",
                        "Aid/746+lRkDYEj8fMqtQQ==",
                    },
                    Passage = "1 Corinthians 15:6",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 340,
                    Question = "T+iZp80/DDwhupZJJIzXDl45RNguocDlZQObivQTffsa0H7SraeiLjTzooB7GRw5cik08FXnSWW4Yntxba+7p8sJejOegs85cDMen0p4khw=",
                    AnswerHash = -1260959373,
                    RawAnswerCount = 1,
                    RawAnswer = "hTy7gFi+ZXcZm8YTLVT+1g==",
                    WrongAnswers = new List<string> {
                        "bak4PNYppJnWOV90pZ0n7Q==",
                        "3V82rg8lavID9w2J9ExSwg==",
                        "Wpp6FWD6h9Xx2qA619CiPw==",
                        "Pr7W7zPBtQoWkVMTnO/0/Q==",
                        "zIKZcKZZd1S0hWLTXY7h4w==",
                    },
                    Passage = "Acts 1:1-3",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 341,
                    Question = "cawXVTFZ11HHn3yxi/Yfxbr7BPIgAW+d1yeoKTRdifKcHyX+3FzIE6o34jaTHAHt",
                    AnswerHash = -1680630969,
                    RawAnswerCount = 13,
                    RawAnswer = "VRuKzBg4pzetjOr9CA2ihqDCx58erumjFVilhn2nuCDN9/oWhUZfDFLLQWtHKG9mcDlDsXg5q9HYuOzIHcIAdP60eD66KlmINEhM8HYWHo0=",
                    WrongAnswers = null,
                    Passage = "Mark 16:19; Romans 8:34; Hebrews 7:25; 1 John 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 342,
                    Question = "7Wei4gVMpX5dTO8pbVesxNUAQzX5onT99MjMec1V4JEhRea+AzODzZsHfhXSNlSwjEcFV7oIhDD0xQayNfBZ0w==",
                    AnswerHash = 1783484552,
                    RawAnswerCount = 17,
                    RawAnswer = "6qarP071gmzv9LZlisxSSNMce9hQNx41J08tuHYDcVnVelhbujfAoDvYResaHh0LWZmb8NqP8///SiWdeg4I9psbPPGXDxdI/RUbgyKSMxchwr1x1g5GyswhNzcO3eJt",
                    WrongAnswers = null,
                    Passage = "Revelation 22:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 343,
                    Question = "X2tze3MiQIW+688GzDFHEcOA74qGYX6x5yIrYdUOfRY=",
                    AnswerHash = -1011516152,
                    RawAnswerCount = 17,
                    RawAnswer = "ftOWIERT0dOXHCZne7oLQKGQdoEHiopKupl+hXzi/w1s6Rdr/YVh0wrVfPHgMZX+IK4qYx7c48GQKC1sHW3CkFqL8rWJXoxM/QZ6PV9TACRLeAeb+S/HTPCB069Y+1Lm",
                    WrongAnswers = null,
                    Passage = "Genesis 2:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 344,
                    Question = "X2tze3MiQIW+688GzDFHETNCtIl07hfJPTvbt3MW0i4=",
                    AnswerHash = 1787759174,
                    RawAnswerCount = 11,
                    RawAnswer = "xfh5PYRZLdhWkZ3YVgk+mmzZVe5zgKSTOryCdFpQ2oiQFJ5aU2SnBxHBHfnQ/gBY",
                    WrongAnswers = null,
                    Passage = "Genesis 2:21,22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 345,
                    Question = "gXu9CuhujaMJIEIlF1iKfF23wghdeqxWqZ3rPqGS2DjgQLmvXx0aPhGzyzrnGFhN",
                    AnswerHash = 779271770,
                    RawAnswerCount = 19,
                    RawAnswer = "fvDwdxvH6xzRA0dnR+SArEXpHChp/ku6kUXilj7e46eYXkwr2YNm/Y7CuKR50CFpBi/0XW6W8nECK7ka/bswUMgZ1H44LU84TeJeacTqa+Su6XJuAxVXrcN+WQTPrOULWWjFE+OLK7pXuAOLJd8a4w==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 346,
                    Question = "AggEZmETWPz8nhAJkyaKuKnzIM2Cp7JgR3hn6JJXxvVv4kP2X4YTOBYzxCKxinnS9uXjgyvP8VDmEWl3voMPUw==",
                    AnswerHash = -30141581,
                    RawAnswerCount = 9,
                    RawAnswer = "DgpY4epn6GvUTMnhRCF9yepTgXi0yHzjhd+/dabiElOgeT5oaxQNTpIR910fQ4WQ3nakTl0TExZZq1Sk8jWfYQ==",
                    WrongAnswers = null,
                    Passage = "Genesis 3:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 347,
                    Question = "dYvxVigccTVX3cuj1/gKthuSx/UXHR7hscIJ/vwV+1HyjVmt/PVEXVYdcGz5ZavE",
                    AnswerHash = -1080413461,
                    RawAnswerCount = 19,
                    RawAnswer = "n+n46IjUNM2pPt36BWVugdYKvE869YJpXOgBy+vGbTijanke9bdP0W2iQnMSCJoZq3XZeWmBqlCGLEV25nIFVinbOnCeFb1nIm/krFcryyrmsCuZl+F17m0N32xsDF8k",
                    WrongAnswers = null,
                    Passage = "Romans 5:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 348,
                    Question = "GtKlIGKNqezkzr/nQwcUW2PDHsy8YnhqU7J47vU9xEDuePeR0Jac17e8EENHEuRVqCONM/DxXWm97MVEkXxKpA==",
                    AnswerHash = 799249600,
                    RawAnswerCount = 15,
                    RawAnswer = "mcrC/WGFwPZtB2zZXFUiUWyN/eQLppgjNYCaWD6+y1+JfhaFb2I92OWWC4WtotkMhyCFnC4Kfu7+gelt+RYAMJ0U6orJEA2GoazGP9A/0r9PLPTxPEdbglX6QZDfXxj0",
                    WrongAnswers = null,
                    Passage = "Hebrews 5:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 349,
                    Question = "VQ4gXYEINjld4XR1R7rtovTIlxf9J3wuQTVzAs8XQFun+PY8gT37pB59KbIi24YU",
                    AnswerHash = -1960282564,
                    RawAnswerCount = 13,
                    RawAnswer = "XZXwCL615Y7FAq2DVUDfe1EbBu0HSkX62t4ao1/fe8zuQib5FE20oeXidX3MF/l8Ax2VLNm3k0D2c9LHYxouRQ==",
                    WrongAnswers = null,
                    Passage = "1 John 3:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 350,
                    Question = "r9/Ib8z1wvzro+Y2cAvWHtdTHndrGtixK2n+HFZHykr4+rS8FEkIUmvvVYCd60Bt",
                    AnswerHash = -1275153750,
                    RawAnswerCount = 10,
                    RawAnswer = "iKoBRCJnIz5rY+XTvilRroQIK4p9EBb+j/qnZk1YtB+IQXmYVtwwS0O7v8jM/SK6",
                    WrongAnswers = null,
                    Passage = "James 4:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 351,
                    Question = "x5EmOu2yusMiYitCkitSpWh3xZzto5O35a302y/hMPU=",
                    AnswerHash = -605162141,
                    RawAnswerCount = 12,
                    RawAnswer = "DzlYRuYkhBG7TpQH+QD3fU8FFupw+M4bsDW+FMsWi/ZSSMSHNG2aO1apbMgvreuAjfAHTQYz6BGSarkvF5UOa9z4fJjd2PXwEvVst/saZvA=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 352,
                    Question = "5tpBtHRrNa9daq6Kp43nTiR3Jwp2Z7AgKuZVAcjkYEjhHo9s0JLleKwF8RIGP1GiBua5/PFxWGqyrgXau0lKVXQdNHFsVw09H3Hjtr7Kuv07fIlSuNDvf3e+GQmz2JPCgRYdyAKaHfXjtgoQahmIuA==",
                    AnswerHash = -1378578000,
                    RawAnswerCount = 11,
                    RawAnswer = "fcQahBg06QDsLuAUeuEfuBqs4rMxis8yu88JS3htZCL6wr/CGySz0Mv69xuMvTnTUWyMi1SvKUnpQVT3YcMNsYsfx+QOYH9DRhphlsl5u98=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 353,
                    Question = "/nB58/4lQMuayctF24EcBsnyLgd5L06SqREkzsNPZ1EcGO0+0n4T1NBW4meapYZ7fvm6wzkOvW+3K3kTQR7wfcuw4+j8QDOE+9iDsraV3qotYj2dpYrRw+NrjsJghUjM",
                    AnswerHash = 2142139763,
                    RawAnswerCount = 9,
                    RawAnswer = "ldflL3MUNz/D0N2+un2S9DMdOGzYnBHk+0j0venZKzxPCmhN5DL6u3vjeo+JzpbH",
                    WrongAnswers = null,
                    Passage = "Romans 8:31,32",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 354,
                    Question = "7HOftAV8CqBqQoLeBwjKfTKefYBDmuGsJLUiEA3kmDHBAfhj5TXerSAkLG41TQ20EP3lWzZLz2gyN8XbM9kzL8YpJJuXKcih9wniWb4C4cMyPPDXJyGTtXj9Bg0Bm6P0",
                    AnswerHash = -1466908152,
                    RawAnswerCount = 20,
                    RawAnswer = "yax5NpW+RhyUZHRbaGrd+e2Nh8zEj+rjFNRZhP9WDr2QLuboWPja9NL+rnLXjVBLy8H/YY0EUHJwANapyG31culp5uk91Y+ZUhTu239Pn5CJ2oeevQh2OWv3AZh4TuXlKjNIKuLIIV+br62DK5PCBw==",
                    WrongAnswers = null,
                    Passage = "Romans 5:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 355,
                    Question = "U45IW/rBGuKvO881JU+WYF8NjzMsUeA2Mu4sGn/WeHfK9V3pRNWvJU/MqjxGsdv7RrawAryjUZ9D8FmfxfpDYARs9ElsFmu15NaAiDkRh4JWs/+o45Gq7M+PFjJPOoX8",
                    AnswerHash = 1740650197,
                    RawAnswerCount = 17,
                    RawAnswer = "phNFvDqpzcXb5W44ov57qQTEj+ucMoIrBEp3oab+W+KhoUadRTlGiNHV59oUhXWVHxgQPmqMrp3Oyq0V0Rh+O6H2LYlrv+98alIcdbI1HGHCJBXxIK3RZwHKcH7qBPg5",
                    WrongAnswers = null,
                    Passage = "John 3:3",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 356,
                    Question = "8LlHawF0pFoosXk4nk3xVhmzF2YcCBgfvd0puZCC9Tg/M0kbBdiBxQIL7fhX+MjG",
                    AnswerHash = 536022954,
                    RawAnswerCount = 13,
                    RawAnswer = "JsjvHeamTuhSy/plizna2Ro8RSchZYo7DYllF2XUjlz4ray6clryZPxazb/sS3l6xhWzyS7+GihUjXwUxLPj3mRDe+I+64jxLjH1OiJ/mbE=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:17; John 3:3-8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 357,
                    Question = "bFtXVyHwJo3lOhFNY3CqHtx8MXAugb0JPCcd6HfJUOFQhlkio/jpM4546g78raGLfx1J6bqRpRdZ55eENsiX/aI42dKNrQ7e7p4i/tGbADo=",
                    AnswerHash = 264890902,
                    RawAnswerCount = 23,
                    RawAnswer = "v4svx6iqMMDg3qvhyghGZbUCfAN/WD4Lk4hKvtFYyQ2caKsavJgEV2m5rfycXHvHrKVMwrh5ri+ROA9HpJd4vz8ppfyaR6TD4GLcfuQqfqH1RkrF39kpTiWXLH3Rf88KGTJWmcYk2yp5jIuaiLYGCPuA0JL5PWPyw4LKurWshLE=",
                    WrongAnswers = null,
                    Passage = "Romans 12:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 358,
                    Question = "IVX3qld/Pdh7TVCpSQdvHn8L7TgbCNlYeAFjf+6+pYWIyBe3et0CGU1qZKKFms3t",
                    AnswerHash = 688395375,
                    RawAnswerCount = 17,
                    RawAnswer = "e3rxYgc/LwdqfWpxlWobR015vi0GVP3FUbWT71WVmzVfzGztpgZsoENUf6YcPefcZ89YdQkGVrgXCDRe3L0h/cOVLHxpcGVYjiNkxSSq5c8aCxfGdqFM1dS5RyJFogY4DZBZvWt3jmeG6kO5nzIm1Q==",
                    WrongAnswers = null,
                    Passage = "Romans 10:9-13; 1 Timothy 2:4; 2 Peter 3:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 359,
                    Question = "0n0bBjQyf43b3r1uZGcDpt+06VTAe/NjZ6EUlvVLfCWTucZiprahX/vUxzZSYtNXSDCd8+ES6tTytXXo77a0aw==",
                    AnswerHash = -1648235409,
                    RawAnswerCount = 10,
                    RawAnswer = "S4BTgz49iqfG5XqMrBZVfDcOXm50mCVfs8PTq3muyI1dBfAnpeu5aFwkaWii8KK6B0jxvC0hg08FKNndBilg6rQXO/1uiT8X2VITRJvlB4A=",
                    WrongAnswers = null,
                    Passage = "Mark 3:29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 360,
                    Question = "3AVwPyQoYOTLYb9ZnA6R+hhk2gWX4Rz/kvxqmJO8+sW6TWwzKyZFvdViqbTYY7iA6Qf4ptChDYGukqa2lMqskw==",
                    AnswerHash = -1188366253,
                    RawAnswerCount = 10,
                    RawAnswer = "NM7Zmx8vRZ+tgUcYMBNIkB0aCf3fzhIcV7tUZF3E5CoqZsjC+FGzW53WAiFpBakwKNIGs6+ulxGbmLHndXeIXw==",
                    WrongAnswers = null,
                    Passage = "James 4:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 361,
                    Question = "h3IvoihEjJyWPn+sZRzOQyHWbB0rSujnchfgvb+imxwDFPLsLdj/3tef0R02JjEwxcGY9ujm4yohy7kX5N5JXaYCMw73QchSCtCvp4r7vTod6vW5MaGDIDA5AtqSJ280",
                    AnswerHash = -1226395767,
                    RawAnswerCount = 11,
                    RawAnswer = "1pVwlaYsS+2ZmSgm0JlsO1/V0pEV/58lTvB2k8KYYtx4+53/UguxEXEGWZVtks1X",
                    WrongAnswers = null,
                    Passage = "Luke 18:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 362,
                    Question = "PRNp2OhrcHA7nZpQhaorPqqgeC0wDp65jFkYqEeKW8g29x/BZtOvRcH8LWGgAQVgFACCzg9E0mo4y54yeQO7scQtGb23uSiRnwytNjQGw3g=",
                    AnswerHash = 183589587,
                    RawAnswerCount = 21,
                    RawAnswer = "MwFlWkNrHmIbAs14mJzjN/xcDSyL/+sYoVc8pruCZN8eI3jbsbLWu4K3Xv5hEWS5J9JzlCfxna5iqxePG35VbrrbKr3LVEmR9fulv16uj/8Plp1MpNqMn8oQzxfkRcfys2Xrz5sXO4Ii8gHXivgW0Q==",
                    WrongAnswers = null,
                    Passage = " Luke 15:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 363,
                    Question = "KYDMnC1QdeV5hwt9wsgUq0L7t5OA8D1XuofUN087zNurBXS51Fw48o1DA6JifXLeF4dxnYqLUz1WMcNx5ybWjQ==",
                    AnswerHash = 748221894,
                    RawAnswerCount = 11,
                    RawAnswer = "CSDKyWVYAq1q3CcCCS52aQ5v9IyUGa8hJRpcUddMw1DxDt+PUM7eKFbJZnPV/xW5w0HhmRjYnqSzNhvOoQh34Q==",
                    WrongAnswers = null,
                    Passage = "Hebrews 9:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 364,
                    Question = "dYvxVigccTVX3cuj1/gKtgC3+23Ap0EZNfWNalbJxSjSGakcDsKe3aOYIlAyKIWQ",
                    AnswerHash = -1878628421,
                    RawAnswerCount = 29,
                    RawAnswer = "QnOnFdTn5Lbp/CWadNADAQyDkAMgaDHWUgVgff7s8PNSES4fZJJSPB3z8y1vthQ6dVupY6+hXX6/r2m/2pP2feWupYXit+VLmHYnFbz/9RC2cb/7oodLb9UOnidocq8s8XWFCosg5ZIBEikFvZTr5DfTbif/+2x7eIbs52lP34jZslnZRJz09Y8vJFwIsYv2",
                    WrongAnswers = null,
                    Passage = "1 Peter 2:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 365,
                    Question = "7HOftAV8CqBqQoLeBwjKffumY1YyAcAGUekCLV0KdzpJ0L1tnLPloZl6oFq7SdP97F/Y4EM2pYiiLH7heJc2+eBJowSPEpfpKbf9VvAFfTY=",
                    AnswerHash = -1739414142,
                    RawAnswerCount = 23,
                    RawAnswer = "7P8BPfnpGyqaeq7q6ptocXbwDKQW0VRJefg9KqwQPadK1GuImEVarpnVrkUXMhBcfPvKMSAGXYxOOtc4aNriOpyomq6Zs5WJgf340gvCdo+Dmet5fMfYcMnWPstkF+Ux7AnYJHg1jJxFL/rlugNREkjW8xlFL4BiuE2PTA+U0+E=",
                    WrongAnswers = null,
                    Passage = "Romans 1:16",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 366,
                    Question = "7HOftAV8CqBqQoLeBwjKfRKduGYxDHvTPkqLXjLkOSOrlWVVuvzUhmhkPEqWCDK4XEX1XfWfnc4Hh38qaCjCQtFuUfV7abguzksM7rWkKg4=",
                    AnswerHash = -1069167484,
                    RawAnswerCount = 22,
                    RawAnswer = "Kvq4hxzX0IHTPCoHTQ+gshu3VzRNnEjexms+QNYjFTGech0uDhMvD2C76tXRkB1bYkciSyq+Ykjmy9CjnqupqNXV7c82w3h9EyQ5A1xzekYv8QyA/l5xFdv6AwzfwUWIUOlnMOFsQDoEtKWQ/yae1g==",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 367,
                    Question = "BXPrXFEXiKivMRF6kvgVjIwaVCnJsS3Lv8/OkBg83tMynS9TTGwaV/iqYz/eE10+CU4q0fwLu8wa8f5mT7i0XA==",
                    AnswerHash = -710715659,
                    RawAnswerCount = 15,
                    RawAnswer = "Gx+eR2hF9BDkp2O/46dYc49+i9wdRIDlhqV6DXSghBkpGns+LVRrZT7P4d2UfgJqznd7sdEVfk+veSwm85QmFvj9EUXPG6W5xRYt2IYzGH+ee+fA0bdpiP4eQT+7Dkyt",
                    WrongAnswers = null,
                    Passage = "Romans 8:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 368,
                    Question = "/Hn4g+nL2J3K2f3+wfdPucHTrdGsXnaXKP9Az2SVJej8pgvba/fnZoS8S5Zc8I4WvoofrCb7mXIpdfi7jLEtNxFPO20FnXc+psayLsPu9BpJvgfG650J8CJ44nE1LL6NwObJHbsM/sqFHuXScN9yFw==",
                    AnswerHash = -1095470832,
                    RawAnswerCount = 14,
                    RawAnswer = "Bdva0zzihtPpfL75owVPrP/6+i/mDlSwFLmCR1a+VF3yIWdbmw8gygtD+4opZeAc8DZ8Yu4rPAMv7m4m+cYpHHSf0Kh7Fuhy7CEI5NSwlFs=",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 369,
                    Question = "tWKlvkSG2n81eC7TMGX17II6Z+7+9PVJYRn7mu0CX+ShdXEFxADdnBCZR+AlOIIi",
                    AnswerHash = -1210602314,
                    RawAnswerCount = 18,
                    RawAnswer = "Fj/K9rp0hoF6fJ6mUFqMfIqs6sm7zF3MHNbh/JdUl2mSxFQkr60VHYnmPPhv5Y6ELiMhte5ygK6BJZkQk63XJlC9FlrOt8N/WRNzqujYWm6FTDmqL7gJnlQMLHRPgb1m",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 13:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 370,
                    Question = "Ips7XBmxcj8q5lmrj7DOZT6IGZOMwYeBJ/V9r8X2m7M+tlNwcm1R9h0sOvTjDaQR2kIXYIJY+2L7Ai/6M280RCdpB6+vmlnm1GSJykLMxYY=",
                    AnswerHash = 1047198835,
                    RawAnswerCount = 15,
                    RawAnswer = "qjGSQwIRl0tV3XkdcE+3ik6/Mq1EG6H1fKB00lV97uhaWOWuTF3lq43AwEnMwcrDdxJmzPqWQE3PHzFO7SLr4egSZFMWuskldmGZdv8tjFpGrgdXCY6amv/llAaOVcM+",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 371,
                    Question = "qIK1arTuWGkNI2vVuQWGDKArPX+EZXuMWuFV+JQL5fz/GelvwAK6FCYG+9z6ZG18Fj3YNJW/LMdbRnSny32tPANAFQdd+4ofO04+n/s5PGY=",
                    AnswerHash = -80485211,
                    RawAnswerCount = 21,
                    RawAnswer = "UTlrILsuWSYF4ubi+IEs1Se3PHj659K5l6fxHm2h+n42f3GD4A+F8/uIPolOJKuVuzWpd2/EvN3XkY/xnzZBtjZ/fK7mPT/zYOBdw+ByZHpuGfQgIMy1T28MsFpsUyprFGTeQ7BC+mqgD2wgRgzpJA==",
                    WrongAnswers = null,
                    Passage = "Mark 12:30",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 372,
                    Question = "qIK1arTuWGkNI2vVuQWGDOOFD0BjiwURXxP/NgHzgmFRekcv3eWgMuKD4qruhf976X950rfx+YiBnA9Pgpk+Cg==",
                    AnswerHash = -1427254564,
                    RawAnswerCount = 5,
                    RawAnswer = "bVKKlaZp9sAoWk46gicyC6BhS1DSMF+NlYfH5nUPqR8=",
                    WrongAnswers = null,
                    Passage = "Mark 12:31",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 373,
                    Question = "qIK1arTuWGkNI2vVuQWGDDOskSei7xyItKo0r9Uu4Dga4ttuEjNDTPhlQCKF4axDXBpTK+jNzvYs9QfUQcBWnQ==",
                    AnswerHash = 21151851,
                    RawAnswerCount = 14,
                    RawAnswer = "BhLjViwbbGNJUHCKkCReMbPr60q8NVrPxZ4P5pPI7NH83wISw78aAFoxQmxO4sW9cx1POL+HMTClaHPnm0UrWr6JlLMUV16GQfwqQ+MhtqU=",
                    WrongAnswers = null,
                    Passage = "John 15:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 374,
                    Question = "OKocsRUZbBm6P+dj4Kf7Tl0X5r+Yx0XLs6/tbvOqERxS53fKfzJJD4UX2bHCb+29",
                    AnswerHash = 940110112,
                    RawAnswerCount = 7,
                    RawAnswer = "yCxN22fyzDa7e45vR+4IViTUiMnkxvhXFyN3fz6gPP7xR9LXTtGme9B2jHXG0Fuu",
                    WrongAnswers = null,
                    Passage = "John 14:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 375,
                    Question = "qIK1arTuWGkNI2vVuQWGDIdfwmogYHtxdOlZLs3um5RHf+scyZccveC2MEd1KnRpK2eOBpbWHUSXZVya/CtsXpc40Nubhv7vBiiQCum1IkA=",
                    AnswerHash = -721111238,
                    RawAnswerCount = 15,
                    RawAnswer = "r9Blx9nX3RbUS8v4Lqbs2SVtJg9nTKOrHpwWHR5QsTciLTjdUbY4zkQvMtEyvyHPeW0KayIUnhPZ2XMjr6KdNTo01prf7i+pxQoDfTE42s8=",
                    WrongAnswers = null,
                    Passage = "John 13:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 376,
                    Question = "e18+YyJ2QRUuqH+dvb44ucZ0c6LQWueAhB7m3SdKNd2uUSJQ71rzHF6Z/kBr152G",
                    AnswerHash = 1083933202,
                    RawAnswerCount = 25,
                    RawAnswer = "WbgfX8UlnQq7WhLx95Vdvz2MBM3yYq8ZmNVYwFbcwe08vNdBqyNPIXSwvxbCAF5R8zUHGQBP/i5ALh/SdCY2H6yCynf04z/DgVnXz3L5SPIl/PUeDGhq/77JBP+eFZ0hMcBAzXWj8lnrFo4DoD2+vi6lpBrc6Q96c8gn/Wy+2C0=",
                    WrongAnswers = null,
                    Passage = "1 John 4:7-8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 377,
                    Question = "7HOftAV8CqBqQoLeBwjKfW/zVnJmqKTzrVTsD0xOZGD9dHdzQKzIAKaKjKOJiottf5Ou9yGrh7J2sAnn8QX9P1xj8srcfVyrEFNGQqAjVUAWFacG0mhepWh2gKsjcJCs",
                    AnswerHash = -1998856979,
                    RawAnswerCount = 25,
                    RawAnswer = "q2hnr7gaem9Bsgn0sIyF8UQVEJ9SOe6lp9uGazlcbSdXDSwtU1wm2TcjgYnr5zpY4rZN0awrEzxz1rGYUeI4FNNzNjEcEWKmuDg8X6xS3SdG/r0Zpp/efEWtCwwnRkPJvEVW2h0X+c2ugVc+MRv86hpH8+8QzHMwuoS2l37erD4=",
                    WrongAnswers = null,
                    Passage = "Hebrews 12:14",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 378,
                    Question = "5eo2noEMI2Of/nlix1B8vGzQ+hnem1a7ak98aSdPDAZyWWh88Sy2vGPkROJW9tiK",
                    AnswerHash = -1328958520,
                    RawAnswerCount = 13,
                    RawAnswer = "U9oMxIfYpRrb8yqF3rX2OpA+AwJD7D6LcEp8o+0gih0j9CFIpDKomLMfUrTmd+ruWgddNk3JNJIQSnKIBuELph1P55yysuILOeKG6ohsHeo=",
                    WrongAnswers = null,
                    Passage = "Proverbs 4:23-27; Matthew 12:34,35",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 379,
                    Question = "wC9u957vrmecPIOVtq4r9dcgnVUh5nLbRvmiuhTSvlIGGn0QJrgPmuiXwlkAF1SAdCdq9MyUmRewsAlTnf1TNjUFYpZ4I/Jk17y2nw+tJO8=",
                    AnswerHash = 755561120,
                    RawAnswerCount = 13,
                    RawAnswer = "qvg+7W797NZqJn6646JgqPCxbdnkx/srEURu3avMjpCyplj88Cs6BbcB7nmN7SGRU5jlmhq91maAolQgozk6GJN/027xriVBLra/5LJ+uDWYAWMpriwc6zt8BzRnYuz4",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 6:18-20; Hebrews 13:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 380,
                    Question = "hdW2MBmwBg/WNIat6x7X2OB/LY698rKOcZHLa0KqVrDf5scETYP+dXK44TN48BQBavu+fw738vZTe7fi32NBVw==",
                    AnswerHash = -1743683002,
                    RawAnswerCount = 19,
                    RawAnswer = "yK64tp4eEgPV4VXI/iGObRBsEb4Op/qUwru+AEfy02NdmeqNd0yfv29gQYrV536M8SD5Q9VJTg4LZIVXmjCWgud9ckuYZoDAc+tmifyqUSmEJ+fpKk8xwD8FCUbejNNnhnaTWuVSnSP34CiIXzIfpw==",
                    WrongAnswers = null,
                    Passage = "James 1:22",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 381,
                    Question = "11ln0QhZ134uBm0iSzFFGWBQWe8vwPjTldHZtbtR0B0AxJRNbwY5IChSJX22+ZM1",
                    AnswerHash = -935361810,
                    RawAnswerCount = 12,
                    RawAnswer = "uiQfCg9tq6bPlHEHmt4XXUDpvdsmv6xdyGcXXAuI3zPZHRHCLz10SMkCU2+KkH22giSJ0KbJaWH+oXhMvh45C7T+iXG3+ERqoGwZlzlm8+s=",
                    WrongAnswers = null,
                    Passage = "Acts 17:10-12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 382,
                    Question = "GDtakU58AZ4yQbXVriIAX37LOvVoRMFaYKOCQoHvP8QzWuD/JD+Zl+cXopTxjz9UzY1BDX1eNAhfOJA7HsDpcPa0GIbx13aQLv6UKwOEmQdv6sjSCKmROuoAzI5MdZQI",
                    AnswerHash = 188208187,
                    RawAnswerCount = 17,
                    RawAnswer = "ZT6Ql/Dz04289IviD+YSzICBBucLmRFLUTreQKgFbG4YiPgfN5AnQ1sE/V7ZqB6E+h17pZtr9NC4OqEE9MYP/j5Z0g9wXwU8Rm4Kew28I6HeX6NTiCsPjBPrE9mOfFJR",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:18",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 383,
                    Question = "efqsPWa5+QCndSl9UKmTeuRwmjhM59ljwkeHNDXDgIvk1wAPi6tpsMokbpmHRVLB2HRStVuLTlzusN5Qx31JDUOTWe3b9DDUFPLDBxv3IHo=",
                    AnswerHash = 1774378790,
                    RawAnswerCount = 1,
                    RawAnswer = "AFVJAir2o5Ayy14VHXZZ8A==",
                    WrongAnswers = new List<string> {
                        "PRP8BlcxSwQRHhuz7eInww==",
                        "yINo9UTr3ONamz3AkRZVeg==",
                        "qGKsMgvxe8LYtT2mR/I+0w==",
                        "Mn0FFEwjzMDj22MRXwud6A==",
                    },
                    Passage = "Ecclesiastes 12:1",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 384,
                    Question = "eMal73hJmCQJs/nJpUou7OfmAYIlIFJvRuwwcv+Ma7WzNOoHYqC3GFiNOpjHDmTV",
                    AnswerHash = 357600342,
                    RawAnswerCount = 7,
                    RawAnswer = "Adj1REAfSQuXBew7LpC+MklAiy2ZbPBJxqTaY3PVfMaehFFJjCSUz3xdCQeQvAirqnncS786R0DJNiZM7IdsUg==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 6:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 385,
                    Question = "k1AjgYfcbUFBQThRzXwXTiziWxjHUAh+JKMC6wbMLhU=",
                    AnswerHash = -5097817,
                    RawAnswerCount = 12,
                    RawAnswer = "+4t2X3FzXXN9wDmFREr2TcmMPBgPSHB2YWmgAs6exar4s1OD8djye4tJx9aD5OWvgVw9oAMKdWY3kWBxeI9yyg==",
                    WrongAnswers = null,
                    Passage = "Matthew 7:12",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 386,
                    Question = "7HOftAV8CqBqQoLeBwjKfdQVtrTwvTowcUBB2JsTdeR9znpMt00shOY0lGXctWWnC+ATRpbdbAtUdz2NMbNhNdmMWkC9MEjhPaxUPV7z/RR9dO8syGnojxG3GC2AnpFbwn/UEdfE0Bm2LsGzk/D8uFyH+38BnJhxxCy+PV0Pyis=",
                    AnswerHash = -87122317,
                    RawAnswerCount = 13,
                    RawAnswer = "QuesiTE8o4mnsuqrVf8aQxTbB4qWAYWQgZ6nDr9mG5rON4x2kMhaJ28qZ06gA33asF57LK8G+Ez5gGCx0WN2ECV1WGFc7jOUZdUZFf2pjjc=",
                    WrongAnswers = null,
                    Passage = "Philippians 1:21",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 387,
                    Question = "SOaggmfMk5dqvtLynZxkjiGnJEnvhVOwdVjvaXexzRh+9GcmCnvs1iDK/MiRxDCxbVCIJPWn3L0Y7/NVcrGurdacTiTTTKGZEcP5MXRg9+0=",
                    AnswerHash = 2029362594,
                    RawAnswerCount = 12,
                    RawAnswer = "+Q8QjNHbkfPLiXkG8oVlOvIcH+x7SSDrkGiFa2N9+iI6Zn1IXVDWkLtaT6NCMW9dHcFcGbCe8MyI7VSpihxFmzfCV6M89GjxGix5Sr/BwZ8=",
                    WrongAnswers = null,
                    Passage = "Proverbs 15:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 388,
                    Question = "gNJmTHc3+skvkbp/ZXgbZ4PnNzEs8cxrEFz5Vq4UulZLPSkalMlrPtlY1+BKY8NZW7TFBw/STGFbQVJRPPHOtKYMfct7nrgvWtAqHS1GfVhwvtQICX1wNzyyEbwHHC6k",
                    AnswerHash = -899868473,
                    RawAnswerCount = 10,
                    RawAnswer = "JKeZYWFRxQ+ig2U8H9lrxsxwZhVIzWhAtMCjPn+uxsG7Pv1YDYtqL05xOUFByjfbeBRsBrVLV9tDglEa3kS81A==",
                    WrongAnswers = null,
                    Passage = "Romans 13:1,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 389,
                    Question = "gNJmTHc3+skvkbp/ZXgbZzHa4XP6HRhpVQ76ZiWkK+8pxu385RqpIOj2hRlH92tsJjpHCH54HkdbhBHm+xZdBPI8GNHfETN+c+ZL8E/1D0dB985Q/85sH6K3AzyFZxye",
                    AnswerHash = -512148921,
                    RawAnswerCount = 13,
                    RawAnswer = "JKeZYWFRxQ+ig2U8H9lrxo3EQiiMgOrvisWJC0TzlS6ymSg98x+UTIqynk0ZIOVbeBMcRYSPswSaobTjkXD7m5bFG2tNaampmmGnBlekVHY=",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 390,
                    Question = "nitBQgsix61/n+e7dwfeCw134UxBZ7sxYTEj2YPJwU0=",
                    AnswerHash = 1235732638,
                    RawAnswerCount = 7,
                    RawAnswer = "IESeFF91hfeX4VkdgFHR0oe16SkLIGTWfaCqqJX+Z1o=",
                    WrongAnswers = null,
                    Passage = "1 Timothy 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 391,
                    Question = "6rcvQ45iH+cxkkOXw+FRSHGC8VxUhTHojkEqt2EgtSCKzhCdGSQ/35fiWBqpa0M3",
                    AnswerHash = -381808440,
                    RawAnswerCount = 1,
                    RawAnswer = "cylZlqNnpENNAe1Oyh3pCEw4ue4xMDRToh8vtR3l+Ak=",
                    WrongAnswers = new List<string> {
                        "4B8N9MeaP5e6EhsBFXO3rA==",
                        "NHIeTZfLYWzvDy5v8CeUxw==",
                        "w4JOkQyTQQTwROsW6+Cm6g==",
                        "EqDwh+JmgvTSAWHSNDwNmg==",
                    },
                    Passage = "Mark 16:19; Romans 8:26,27,34; Hebrews 7:25",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 392,
                    Question = "H5iz0SdzsdQY7twn0SI4FOir9pzacFX5zKAHv6I5kYxc8accWLAYand+AxayhXWwkyDWAPggi/0Y7pVcSReQ1Q==",
                    AnswerHash = -1365756107,
                    RawAnswerCount = 10,
                    RawAnswer = "uueNqyaC04aZvNkgjqQN4L7cs0hfRAu2IF4Yz6guGWGdlrlk6e5Ph/wegSkavf4C",
                    WrongAnswers = null,
                    Passage = "Romans 8:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 393,
                    Question = "wC9u957vrmecPIOVtq4r9blwXNbV5be8xfOZEvoB5nMV5SVIymHY91S4fqs7PEsy4C2+YnSzBIUgCk/GydaekcRmI0r1+DpNrKX5A2GtqUE=",
                    AnswerHash = 654808771,
                    RawAnswerCount = 13,
                    RawAnswer = "U2OEN5D4jou4vrfH4JEx+PK3lfQ3denL/+igP6WcXCggzILwmZAi4F/cWMYtLoGiwjTgPEdoWX8UZsBUwLMopjXoBMDX/4xX51xyzFAP3ps=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 6:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 394,
                    Question = "eZ9T/pb49IEROHZOJik11iCo4nv54LS96bgJ2Aexl5g=",
                    AnswerHash = -49785920,
                    RawAnswerCount = 10,
                    RawAnswer = "DBcxAd+S/SjV5dVCXBYuE36S2GSO9YTQnvZfV4qlee4DQR42ol1okOccRtzPUkT3",
                    WrongAnswers = null,
                    Passage = "James 1:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 395,
                    Question = "GDtakU58AZ4yQbXVriIAX1KcDefxkU8TBXl1a8oTbAl3xOGtBn+fW8SqKMwWI+S0+VtgUZuvtk1o39Awh+jaqQ==",
                    AnswerHash = 177126023,
                    RawAnswerCount = 15,
                    RawAnswer = "GfHxXrxAuWPheWqHCcOWozfGFC/PnesGrsJNNlR5Vic7yFlCBpBfyMy9mxgiyknQJnB6tdDwrxq5Vymm3X5jYYaYoT8rh71WRoCBJwXBouAJdamDSytJhJ/6pecZKJdqtGbDcXPqdYGOJRin4hx7Zg==",
                    WrongAnswers = null,
                    Passage = "1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 396,
                    Question = "tWKlvkSG2n81eC7TMGX17PyypOzIGSqzd/PoSvBZGAEy0U3IiccqswenCxlpSvT1",
                    AnswerHash = -1961223845,
                    RawAnswerCount = 7,
                    RawAnswer = "DI1QIQ2KytTB20wDPwQr35ZKWqn1eXDtRX/e3FjMeg6/ktQhq7NkNPqliJ8mRvXj",
                    WrongAnswers = null,
                    Passage = "Matthew 4:1; John 16:33; James 1:14; 1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 397,
                    Question = "gUAEvv5S+xxWhX8flKHiFbSfqwmGLjUICwT0eJ84uO+A3p1yklJVlorSJZI0SbZT",
                    AnswerHash = -1276421972,
                    RawAnswerCount = 11,
                    RawAnswer = "IWuc/QElTO7gh5ihWILbgsBHrEAehRHvx1p4WRDx6umjrU/Xh+VD5IkBTr0wwXhy31ZRRrD2ThNCHG6W4zd3XQ==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 398,
                    Question = "+rgb7ePMs4uYVAV+2W5oM35Y8HBuDCxP3IVufJydBI5ccCoBhfGsffONjnj+s1GIk2WTJRHZsAy5+G8YWhQ1tPkQuxFSSH2HdzOklqjLwrEtpCHKm0PcyfEmduhYxWpJ",
                    AnswerHash = -637527646,
                    RawAnswerCount = 1,
                    RawAnswer = "P1lJo5eaWSPRleUVseF61clQvvQobxuioITrfdKaMuQ=",
                    WrongAnswers = new List<string> {
                        "zQWgF0EZtdPujMMa7r4VaaKL7Av/GcCPw1PohRYGtJI=",
                        "xTZyf6wZpxwPOgBaHkM9D7A2hSXIgnYr9eJ1h3mDUPU=",
                        "sexlHSiF6HS7e62hdQ15ZG7EZXR4XM/5s0yFFfKrBUs=",
                        "YyhPQ3ZCq6gmvAxJIiySeaR3DmV6Wz3eT9eBWofn3w4=",
                    },
                    Passage = "John 16:8-11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 399,
                    Question = "4Y4eA/OlkXzhiiBFAwy/tkHNabbQsj5kUChJRzyHJkQN1AbUkVgkSzzPo1eHdtuD0VexPdymww6juBlGNT4R2A==",
                    AnswerHash = -1159193434,
                    RawAnswerCount = 8,
                    RawAnswer = "uJg7+hDzZORpgFLDu5eYrheCIaZ7X8xYlUDq5NEbKWFk2wElIyD72YaDWLs2n2hR",
                    WrongAnswers = null,
                    Passage = "John 16:8,9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 400,
                    Question = "NqirSsOguXaUGr7XJ0+05TaVpBhdb9ed+FK2rHy0OiMlUXkjP+9t/bBRaFSCfcdN",
                    AnswerHash = 384630459,
                    RawAnswerCount = 1,
                    RawAnswer = "5NxkoPExTWN++SXl2B6miQ==",
                    WrongAnswers = new List<string> {
                        "LLNGHlru2V1NtKfndxhfcw==",
                        "Rw4Ovn+a52pq6yHevGdWng==",
                        "insHJCO+gb+9sOqQ3pwLPw==",
                        "S2qde5v1y4hXSp6udtfQ9A==",
                    },
                    Passage = "John 16:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 401,
                    Question = "YSA1iC9SW11QwTVhKwM4ttkO2KZoI9DcaibzzJ0TwELvcudH6wvziLSKgHcJFkaJEjlnMotyv8WQ0xCwhB+AXokzslwJZNcqBUcZ4slpDzo=",
                    AnswerHash = -538872709,
                    RawAnswerCount = 19,
                    RawAnswer = "szQhnGfS9W7j2BcaMh2NVWoffsdN4sQV2uevagVx46k3PxzoiHtYVsLjgsJcf7jEPYIg5oD484cfmGgy3e1DcnTfmwGQoBV1u05MYLxQugi5x/drbqxuW0rByP93k/B58ZkM5UFhvHXNLgnGTUZXSw==",
                    WrongAnswers = null,
                    Passage = "Galatians 5:22,23; Romans 8:5,6,13; Acts 1:8; Ephesians 1:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 402,
                    Question = "cylZlqNnpENNAe1Oyh3pCLMx57XXcnCt0DIUmrGmln16kctHwxRGcQ418d7FZhat",
                    AnswerHash = 2146418880,
                    RawAnswerCount = 1,
                    RawAnswer = "aDcaib7j11oIOK+QBM3/gA==",
                    WrongAnswers = new List<string> {
                        "kxxAnS+VGmOGlyxH81TFEw==",
                        "WuDJ8l2kU+cbRvEN1u7Mpw==",
                        "q2WMJr3Mz0Wcv2V52a2Rbw==",
                        "m3Q0dQBVJ40latOEjHwMaw==",
                    },
                    Passage = "John 16:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 403,
                    Question = "WjfxWCNOE3TWuMRQmjPKam0mdAQ4HNSqOaXBYm+g39jZmYjBVlqfAD8L19ba9+uhEzYefJ1FSirkl9JOfsrQqg==",
                    AnswerHash = 768832818,
                    RawAnswerCount = 14,
                    RawAnswer = "JsjvHeamTuhSy/plizna2ZlRORD32Ip3FsJ7mAlYGTpl2bsbGONBJJ+ojiOV1QwZhRdldVtriX3ABFmIuvuL6RSZKd/LxM4uE3N4FCpvKM0=",
                    WrongAnswers = null,
                    Passage = "Titus 3:5; John 16:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 404,
                    Question = "6kr83wbwE6Sn0ce0C5ySAhwIqw+LJszArGNK1swvkoqiBlu0wSJGJzj1Q3XmKg92",
                    AnswerHash = 803483569,
                    RawAnswerCount = 13,
                    RawAnswer = "DfD3QFodKhGSgr2/eSf5cnh7r5HEHL9yrLVjeBCsc5HUw2wN9ppE8PX5qTvLSDL89Ncow/rVfR3Xpr4pBzf+LPo9rAAqv3kI3+v+cf3kPIs=",
                    WrongAnswers = null,
                    Passage = "Romans 8:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 405,
                    Question = "eMal73hJmCQJs/nJpUou7IctrbZDqECdTSVzfYGQ8MfiRPWeMW47fktSiU45tH2HgCyScvQynIN/1PokauyacoAmxb9gFwYHmwz2xFP1LUQ=",
                    AnswerHash = -585781359,
                    RawAnswerCount = 6,
                    RawAnswer = "wRVmhhvlls4pNw7HL0Vi+KDno5Tj8tbvtiI7JJKKtkSADJEuJwJv/RHj+Onl7jhZ",
                    WrongAnswers = null,
                    Passage = "Ephesians 1:13,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 406,
                    Question = "SJk80Oa93vCwR6yNLXUN9Ypb4HLUgXquu6X9rdZHkx6mFnC+W0ehQPu8yO057vXLAmaDKwV22FyGLMrf7bdEgA==",
                    AnswerHash = -747378347,
                    RawAnswerCount = 8,
                    RawAnswer = "r4T7RzNRJcMYgKXKC3JCoGqSTSrjInsP77Ua46jUb7I0mESES7EYpWJ1abTfmE7r",
                    WrongAnswers = null,
                    Passage = "John 16:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 407,
                    Question = "feHuG91l+Dgc09tOfktA62mEbqXD9UdXOVv23O1ZarRBIRp6UEkAWDpU0amfutM4AX6v2dH4Jrs0sXfvoFmHDg==",
                    AnswerHash = -926609167,
                    RawAnswerCount = 15,
                    RawAnswer = "gQWyOvC+D83Zti1ApUMhxOPh10JYgqOBZMFpvR6zVO27bJjTQCQC6d8soqKXrLM0Pk5gaRECgoKY4LhvOJtcUUXdmyQJ2PYgDoCDLK9d90Q=",
                    WrongAnswers = null,
                    Passage = "Zechariah 4:6",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 408,
                    Question = "FdLkx3rpzryLBSIcxwXNWXT5o2cEizm3wPoReqv6DHxLYx6eF291eDU5oZ4J53Z9BUL/2gsrQTwMV/IoftaPZg==",
                    AnswerHash = -1154228736,
                    RawAnswerCount = 1,
                    RawAnswer = "pcZs1ASF2MljHDayPTKWMhZgfmMeUIHe7HrAFRPDBD4=",
                    WrongAnswers = new List<string> {
                        "67T8lBcux9LIMi7d0amHJwxo5FG+m0zc0eDwxODohMA=",
                        "Olu7Ks1D+K8TkZy3ENThKw==",
                        "/tiyQ1wui5BKqyvT5100fQ==",
                        "AZnaOPvSkjv6Yz/BnClldA==",
                    },
                    Passage = "Acts 2:1-4",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 409,
                    Question = "7HOftAV8CqBqQoLeBwjKfc8xw6IwkgEs75zoG800LeUxAPlWT8KEUNsDAirrCrIBeJlBpVn29IDWB9Zj2nGejU/Gax7x/CbJWRlLmhH59Btr4XOxvvgDHykKcOgg8wFrLo10kYCxilVCsHnZmLdEoIUnxMTsrxoPIKZFHQM+qgY=",
                    AnswerHash = 488614521,
                    RawAnswerCount = 23,
                    RawAnswer = "96oSeeYEWco6ODdsBNWDWtSzR/mdxgJ3g79ZPDtOzsR+0PwBHHC6c94DodBHvhiuWT3FcWy26PjkBXHxhTNa1vzN2X+LYbEtafIlA9gnScqRGQYwK3CpAMI49d3hm9nqgOjy3l/sHySQZNCCH2Elp/kvj2KvcygffvNonaLLXUh35/Fta+pSehYQBe5h1JxU",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 410,
                    Question = "/VnfYQpuIfcd7kgDtp3A9GO67dXu50Gg19j6QEsUqW4R5QRgwZ5P2tUzdMpgjep2bgjtp4W6eWAT8j4/PVd+sGkAnRkQ5urLZHbzM4bfXff9PB/eqqdSqMdNYiYsqT+0",
                    AnswerHash = -435843329,
                    RawAnswerCount = 1,
                    RawAnswer = "AIuQX94i9+EM7PvHOSsEa7uWhGTr4y7mhyVhr8YwKFc=",
                    WrongAnswers = new List<string> {
                        "UuL7U7X1/rrPJQXAV8ptO+ISNhpU+7DPdGhy6VsAE10=",
                        "AWcj4Ou7PsEAWLGbNV0dP6p8Wt6wTf47uw15ERccPuI=",
                        "S52D3wfrn+W+FRUDHVMgh8QbyHb02KTvdejWZ6xFUuw=",
                        "d8+KIr6TcXylJ9vT4XrHHzura2T9xx82SAsFK8bRGlQ=",
                    },
                    Passage = "Acts 1:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 411,
                    Question = "mnunUPLlfExkiwNhkwLMbhbOaVuAs0XpRnRvzeD7NceP/qKQt+cbK1drmQN/hl/8ovrVPWXAHzeT1UWulc3kSXXiWRNphCE/bNgYsPyRFUqWNNWLSurtkY4d29+ONWVVQvcekTaP2cedCvKaZoyL2A==",
                    AnswerHash = -819815145,
                    RawAnswerCount = 37,
                    RawAnswer = "g4x77Gdv/Qv6jhYhvMzJYVo2ZGzRqmhj0mpS6RidKQ6F+Sx/XDZ1X1/jkYf/0nmfGSuJC8+U/mynxD7TApbAm0DiUL91FIT1GG8PPUnvbP2VIBB4/YhYel89LmO3ti8htEm3XFN8jUwXj5kNYbVWaVH67ty+MS//iyWNPPyHZgq4s3gXamr9OsliovPeWwDayRN9tNE6/WGFasElznrddd5QvKCg/swZIouJeACO9qqEENf/oPqNpXox/VqBIvIi",
                    WrongAnswers = null,
                    Passage = "Acts 2:38",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 412,
                    Question = "345z58NpMNTCHaT7DNmMlTONmyDbQl5sbfWBfMWpD/H2vcJHqozNob2JZWHauCnviFyXNLY96Bgkx/Q6XErBrg==",
                    AnswerHash = 831437235,
                    RawAnswerCount = 16,
                    RawAnswer = "YRVhZx9MnZmi5kkDKzvKGRmP51t3YxJ+yjO3y1lcPPDY6rQfDKOA/Vazsog/aQod4jMfM7wKX+pBkR3qf0Gvm0CB+CKWMBeEN4W11W/ENhok0t5EPFBZiyFe8GvKlKONjXiINOQAWme8K5zWO2hRtA==",
                    WrongAnswers = null,
                    Passage = "Acts 19:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 413,
                    Question = "hOZK9+f5CxM/Ihg71iMsMSLg8AOeRpsfmmlCYWHtH1I9478azu0gyOFo8FJ/9V/SdWUZantVCbJf7tSb71phfw==",
                    AnswerHash = -762986328,
                    RawAnswerCount = 20,
                    RawAnswer = "oOHlritKt43SkYRhVBa0xZNFBNV5YjLO6o2zivxvRSebvPC1fdc2OOk9nx7UtU2O6dJiK27340Y/vOIIgnkfBtqs+wex7eTPWF94VRPOP2LlmEmcBTArS5nDoSULmWL6Q3mtfCrr2xYPGifVTjwwTw==",
                    WrongAnswers = null,
                    Passage = "John 15:26; 16:13; Acts 1:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 414,
                    Question = "m8XLfG8eVZD1+anNxQ+iSqubpHo0zGe3b2/FEhpQTXsHZcR+dQG+W14xWcwYPs89tQ/oKgRvplLln7R07106yUZZvXYUzABMYNa3FqlQbvk=",
                    AnswerHash = -263328858,
                    RawAnswerCount = 10,
                    RawAnswer = "dwe76xNAwBI6kvizLv+6Q/ha7aEI2CVzqBEP1LIqjIJarIqTd67EhyzPz4bcb1YZNwuJiakSWIvQKxpXi1B9863tjlbxZFYEKXu51E3Y1ms=",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 415,
                    Question = "yWwnpgIld8hNc0zFhi1GBJJierDVPi+/xKLWU3Kj3vhz5P9m4g3M3U4yJQ7xM7FeiCg0XKXabSWt+4H3nlW+b0GQeFeTHLij3d9hwZiL+B6vVDtwueYEr6Y7vKM6F5GY5lzRN0AOQERNUxZ3nxiGkZTL1St6PjgrNZHMsGn9/+w=",
                    AnswerHash = 1987947071,
                    RawAnswerCount = 10,
                    RawAnswer = "E97G01Eeob9wXJpI0+gBGdFmwFVY+fEVOcFN8GJA8InYW//WNar12whmf8HxLdxT0kLR4rpX3aXRakDL4aYFHg==",
                    WrongAnswers = null,
                    Passage = "Acts 2:4; 8:14-21; 9:17; 10:46; 19:6; 1 Corinthians 14:18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 416,
                    Question = "G7YBORlRsGF3V7qDTXwuNGOTTDGlgbQWsqFLenI0kQw=",
                    AnswerHash = 1307180721,
                    RawAnswerCount = 26,
                    RawAnswer = "SmYvAZHSMzpuXvRc/bzASW0jg3CmzFopyWrt6H7xOKnP9D5S7XObJJyNOoNdUNQbRJqdXegB0MzdUT/N2zm+A3KUTr3ix0324s1uuYDRSQgUO5TNJfMlXG1wouRg7z/NXNwhEUQF647V6W7mgt8EmeqOEgFHXUJSIyqLF0Sa22fm7/RsAD6SF2pcTWCqRSfU",
                    WrongAnswers = null,
                    Passage = "Colossians 1:18-24; 1 Peter 2:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 417,
                    Question = "u0PHL7CbN0x547eOC+IvdV+WdA1Ap7ZUp4Z3sNQy4tWRkJISoGGnZGXLsw8WJnfKJBvRdv52mAsDzf3fgpbERQ==",
                    AnswerHash = -2134675708,
                    RawAnswerCount = 13,
                    RawAnswer = "SgtRy8zbpTddn1ZGdFp67v03UIHk9jZzgLdVTWNKfOhG/dAwdA8c44Va5+KsJzVRldKsvXo5p0wXuTYg0WUaJuE5oRBJodJO2eYe1kfEYAU=",
                    WrongAnswers = null,
                    Passage = "Romans 14:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 418,
                    Question = "ZIhiolUu9SmsJRSNG2nzOOoTJd8Yo7GD64tpW3oHiro=",
                    AnswerHash = 384630459,
                    RawAnswerCount = 1,
                    RawAnswer = "5NxkoPExTWN++SXl2B6miQ==",
                    WrongAnswers = new List<string> {
                        "Rw4Ovn+a52pq6yHevGdWng==",
                        "insHJCO+gb+9sOqQ3pwLPw==",
                        "qo+ikx9jTNc22XLKrfGkSg==",
                        "LLNGHlru2V1NtKfndxhfcw==",
                    },
                    Passage = "Ephesians 4:15",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 419,
                    Question = "LP+0AsJo2+1KCINWEWUlIS6l9Yzz8A9ZJLEb6KmxS0d7mF+6k6hqdQT+SbGptRFd",
                    AnswerHash = -778350197,
                    RawAnswerCount = 1,
                    RawAnswer = "ekFT1sHYmxFRtROc5qrbnQ==",
                    WrongAnswers = new List<string> {
                        "Iqsu3NmniEW2Uu1PtIqzEQ==",
                        "insHJCO+gb+9sOqQ3pwLPw==",
                        "Rw4Ovn+a52pq6yHevGdWng==",
                        "qo+ikx9jTNc22XLKrfGkSg==",
                    },
                    Passage = "1 Corinthians 3:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 420,
                    Question = "MYcDh1Oltqtj6qxZBbx9gg2YQlzVGf6adix0WR+zYtEHaxsVOdlAq8w0n4Sv+1+7IUDUtNJ5+3DlYbadE/n8ojEzvk9tEkeW79ZUFFoEzOk=",
                    AnswerHash = -1082204509,
                    RawAnswerCount = 25,
                    RawAnswer = "e0XkaUjMg71udGwPgCpz+dJA+e2oNjrLXA3AR8/PXeBK21JAH16rHs2R9pQ3IPXfWRE80GpbdHdaL5EqKAoJzkyYyfmVlgBkc0yarBXGk6uinpmBLo6Ue1df3pB4CVT4AjCb7i9SjDH58ZnstLOmrqiySh+wXQli1E3ZXt3VOy4=",
                    WrongAnswers = null,
                    Passage = "Jeremiah 1:4-5",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 421,
                    Question = "D1BEbUty8V5BnOsIRJU09FHzMnBw8DKUOULJq7S52I5OmhxUtyzlKY0F6AqNZgcQN9dRHF12Zbzenhz/5AoUipAtHnykWIilA2YGw24Mj3E=",
                    AnswerHash = 752074447,
                    RawAnswerCount = 1,
                    RawAnswer = "AqG8FWPS9tOLv2eMzJ2zQTOqS/xhtu8rJk4R3TnMETw=",
                    WrongAnswers = new List<string> {
                        "WpCPqNrJboyIZx2T7V3h0rfT6r4bE4qzWUwBlfon4GU=",
                        "4L+kihgfh6FnZuph76M9cKztZezNHSiwCn0xPVhxCjo=",
                        "9efHnR0ggyT+ab5uDzWp72mrNH+6w8wB6t0JgklIMRw=",
                        "HGQsJAb937w68tTaQP/WE5xVHAHSIL8u9Q3IzlkoH0E=",
                    },
                    Passage = "1 Corinthians 3:9; 2 Corinthians 11:2, Ephesians 2:16, 20-21; 5:25-27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 422,
                    Question = "Be/AKhCA35HL5Q/uSSOCmo38kg0pMrkeYhwB59nAqRY=",
                    AnswerHash = 384630459,
                    RawAnswerCount = 1,
                    RawAnswer = "5NxkoPExTWN++SXl2B6miQ==",
                    WrongAnswers = new List<string> {
                        "insHJCO+gb+9sOqQ3pwLPw==",
                        "euaz6qaW2Wr7cLp0KBuv6g==",
                        "3WupaBxsqu8EJzaI3A5ytw==",
                        "wRuLpB3R3M9pPpLoIzPdeg==",
                    },
                    Passage = "Matthew 16:18",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 423,
                    Question = "kNR0Bp/GJgHdXmlm5SRMdDl8u6eTkFc17R+ipiF6SQXaO1/QPITzCA//Up4EohZc",
                    AnswerHash = -1930146973,
                    RawAnswerCount = 21,
                    RawAnswer = "OB9n2lLcf/zeu1ckFKBAuGqNfItVs84FBDWqw9KK83mxu6LXuo2Nim6Rq30psvhdheFlJhSf1iMkwmpyEHKzecPoquIlI77d/t5jaVII+3+fjn9hRboQJVr7+3nRleT+tvuc/gEeg8RTrfYk5pLewg==",
                    WrongAnswers = null,
                    Passage = "Matthew 18:19",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 424,
                    Question = "hcBS1Q/iDrP5WVlwcqHKfaRmQdMklQK/YgYKyXi+k2NearawsRRIW7DBi9IR4UbK",
                    AnswerHash = 620940665,
                    RawAnswerCount = 12,
                    RawAnswer = "sf9Ic2lkkyPTt18iAm6nvljf7uuecu8II8r47N2yriLzHpyWIEZEIGSH2Fad4nSH5gNVycT4hF7DKh2wfa8tLA==",
                    WrongAnswers = null,
                    Passage = "Mark 16:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 425,
                    Question = "zac89zhOUq1IxnSyI+19fVIFLa58ZevRpJKS3K/J46kdq4/bacVk4+ki8+Sw08hwiT0O/Ngx7uyT4lsAMRXw438y6au/lLWt1jWbcPJrFnc=",
                    AnswerHash = 699614712,
                    RawAnswerCount = 1,
                    RawAnswer = "9gI9mOPoVzgUzk8FseEVX/qHOOwWgUfwJdtnJ6MPSas=",
                    WrongAnswers = new List<string> {
                        "BAfvgzHtMN//4m4rmm+DWZPPLxBRQXpqH3qHOL418Jk=",
                        "oA4QdjOF6UMhEZFPoT7vT6SWRHydt229hSLnEjyXfrY=",
                        "AmatuMjhNLhtXUl5uhe5WQ==",
                        "mRkPebOsVwepf/r0tgQgOVBw7KRDn+gxX5Y+/D+dO30=",
                    },
                    Passage = "Matthew 21:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 426,
                    Question = "i14LUb/sAPJn7egtdnKx8kuaVvAzqf5NuqT+jqfrPzVjave++BnYp3nuZe1KJoD5",
                    AnswerHash = 701985454,
                    RawAnswerCount = 9,
                    RawAnswer = "BsP32tTQw9NGWh0f3q/QJG6ET0gUMFIyGaLGznElrLpfzdYVlpszC7NFYlfcZ9bD",
                    WrongAnswers = null,
                    Passage = "Ephesians 4:11-13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 427,
                    Question = "yRSs2NBmQqDux4cEUE7BajrIGrEHn9CouAY+5lzRb0+0xvUhXMaNqPHfWjGD6FD4",
                    AnswerHash = 436955727,
                    RawAnswerCount = 20,
                    RawAnswer = "mBl42gzZHU2rRhstwQ8yx7ov6MzmqRfkJmzN31NnfQeR0UBgCRM0eXBO3SlkGkdZOnlKXzlMXMG9Rclb8fp6oedOiuYSlthpRz+ysZiT8WZkdjCpo5oWF737D6cRtDeNMMujJxi65coxL4Tz9XH6Lg==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 1:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 428,
                    Question = "hYiT7Qh8lyAiah57lv+4TdgAfVrWsyLKpk7itpkefzVCqMpQjN/53MsK8pDffH8v",
                    AnswerHash = -646848138,
                    RawAnswerCount = 10,
                    RawAnswer = "jUoY9z0B8QrCK9ExhWR3tWlzMk/k78WbZmnYd2cestFPk1DKnowGpk1smByRu6rI2Avhtm4wzUEKfrswQvkJHA==",
                    WrongAnswers = null,
                    Passage = "Malachi 3:10; 1 Corinthians 16:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 429,
                    Question = "oTAdst5IcoTwdurMSkaxr8Z+XA0yFmIrHMXNBBTOPcY=",
                    AnswerHash = -1098020074,
                    RawAnswerCount = 19,
                    RawAnswer = "gx+bPxfKhxZPh/0rOoSEeZPZzmuYdiHnYt9TCWRXCiiI5RGfgDsk9kxVNjA2yFPP7XxAWR0waifpH3w14kSPNdKKKaw3mrBE9trDnxOlmOXTEx2r3JpwNwx81rKS1Od8Ht5+DRzeycfoaX99q/TBLA==",
                    WrongAnswers = null,
                    Passage = "Leviticus 27:30-32; Malachi 3:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 430,
                    Question = "287JpREyKs9nvsSeRIX7aBL2SNVJSKHxcY4YP+IMAwEdnYbaMo3pxILs0DyJ7ZNuYukP5YT9KcjLF2CJom9uzPvzTrKg2m6ZXGvd5MgqQaLuEYD1VegyTqRwM8W7oNoH",
                    AnswerHash = 1803356149,
                    RawAnswerCount = 1,
                    RawAnswer = "TrBdh5ULE1n832tueTL+pj4r26aijGEHVeVSLKpEK4mtKu6rmNSmVC4N86xSZ/Yu",
                    WrongAnswers = new List<string> {
                        "WBBPgx/8k7y5d86EdIzWnOt0QhH9oG1aZyLFXfP6HPE=",
                        "xKQvDaC4Nw8BPywMcp0izeuIcAeJBC9Sc1uZgJZWBa0=",
                        "JvAVjtcH7BscjI/okS4qP8elMYFK8OWGEPRtcvpcNCc=",
                        "2xDvQ6tR5vu4vQi6F3gNsBna6tWOl+j5uRKtu95eJwo=",
                    },
                    Passage = "Genesis 14:18-20",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 431,
                    Question = "WvBRNvMYx+XbZg3WvJZwRDuBMs6AyOAuP/f0iy/AODA=",
                    AnswerHash = 446549909,
                    RawAnswerCount = 13,
                    RawAnswer = "sWQgV+BcRT5hd0bc65vOfy1qs9tRTzHumf5OuwhP2U4KQtkRIjcAMxC/JF4P8KZx5PNYMmdAoMHXh3hNhitWYOqQv/2VSE0XbwhYvlgLSxg=",
                    WrongAnswers = null,
                    Passage = "Malachi 3:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 432,
                    Question = "yv/8TAZse6jbN2N3jRYB4A1p7VXROmt9UT3ztmWE4mKMABy/xF+W0nhALWp7fczwgmaBuO700FujDSK5RlMZIQ==",
                    AnswerHash = 1559901065,
                    RawAnswerCount = 15,
                    RawAnswer = "hujPsDLhrnZkCxM6VokIu4FALOsYOih80d8jxpNbKckZsvSlHY2ddai73CTE0ZqB0t/M/nCnl4Mz27fjapXxL8+NryH6w4RZ6x7Fg51VtWrGhKR9Cjz6jWkV0YOjrTZf",
                    WrongAnswers = null,
                    Passage = "Colossians 2:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 433,
                    Question = "XwQRp1dXfl8N36LJITqIp4XjPX0h+IKlVz9BzU0EHjkDk78BwnPvmo1zC7GqOPZC",
                    AnswerHash = -977202268,
                    RawAnswerCount = 1,
                    RawAnswer = "MHKVV456V3Obzk05cZL/wYduC344dv+GtklGZqOrIec=",
                    WrongAnswers = new List<string> {
                        "uaptoa/BHKx4pVfDFqjbco9vLJouMwhfZp5Sja0wbrE=",
                        "W7NWaEyjkj0CQeyKFZKAFydiBnLPv4nwe1jdqYaN5xk=",
                        "bMyRobp349UEkKGPu5PEwlS5SXXHywCD2bD/UHVAALo=",
                        "8Mw++rWxcf4BSyWzUP5zjDq4izzvzCHyy/GoU1cwWUk=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 434,
                    Question = "1iQuOSpPLJ7gAMphQshDOgQ8C5+g8Hp5hdeaLs+LRMi1w8pazzVFgYbnv+iFqPrenfhehmwdp2honTT14WCgAQ==",
                    AnswerHash = -225694956,
                    RawAnswerCount = 13,
                    RawAnswer = "WGzhEpQT2SLFkkJaDDGXp2OJrsBseZUdZDO1+crdEDJLaINzRAQXrjrCmk1sfvHS8Zrpzy2khWUlEUaDM7zVwA==",
                    WrongAnswers = null,
                    Passage = "Romans 6:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 435,
                    Question = "0Hd7Q2y8iaYx6KMm+Or1+4Glo3QgXUHD32Krg0hus2BRflt02S+1ZC7tcKdOxQeN",
                    AnswerHash = -1145810191,
                    RawAnswerCount = 9,
                    RawAnswer = "cyNsOkT1wbagZ3AsXoF8a2/f3Y9p2D8R695nLXWnlcx7jxKb+bV4RQvVY5jYACZEi5x9c2H1oz9jSRSiJtcHng==",
                    WrongAnswers = null,
                    Passage = "Acts 2:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 436,
                    Question = "fYUN9CTkRqfz6kLPZb3l1jmnoalQt2P1sNXRs4qt+Ps/wEI7nYfkrAmo747/xM+s",
                    AnswerHash = -2112280297,
                    RawAnswerCount = 1,
                    RawAnswer = "/Z4VfWE4Di4Dxzi64i1WPJz1kHviSKnshMVdBwWZ2ow=",
                    WrongAnswers = new List<string> {
                        "iGfPlacN/jLKF/imkFHpNroiujIFeJs0jJEEcKiBltk=",
                        "pnhLslPnH8PPdupL6m3fCA==",
                        "1XU5hRT88+uq0ojm5Y+FdQ==",
                        "oZ0tmxSS1B4tHfdOx5i3Kg==",
                    },
                    Passage = "Acts 8:38",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 437,
                    Question = "GqdvZ1JHFbjOXGFimDNWg4ijMPidoMHfiLPuh/YnmTkysafX+J2s6M6SpLnwtLot",
                    AnswerHash = 1087636861,
                    RawAnswerCount = 13,
                    RawAnswer = "i+SYqPtu+EcFXqEbyyN7GnX4VcxR1CQHgZajAWHLKa5VzspDboi9MWcBD2O/ZJj7NiQdf22ZYaBIUFIVFfJWsw==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 438,
                    Question = "nLo7AcS6LN5TMU8YmT1Fq97uemmC7/hr9LImhtNli3U9jUE6mMzbfaR/B5IhozhR66Tcb/0SqhqRKGSzR7giSw==",
                    AnswerHash = 1787072059,
                    RawAnswerCount = 19,
                    RawAnswer = "xvB43adRTuYR6RAdAip9DVEnQ1fOae0o2bMhnOWIIBe6sLmrWCVpuOFWE+pRiicVQl/ZJZsVWk1NZyfspXae6cq1P4DrkwZPfgsgCgA9w9V2fkFVWizctBmrrHVNnDqPuS4nnXU39edl0E+umf/8aw==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:24,25",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 439,
                    Question = "7HOftAV8CqBqQoLeBwjKfSdkeUjRmpXDLOMq+MZI0C0zaIQw/jFoDtoHvqM0OXJoDid8JCi4v+lfIXYgzwVX75FeTmpFSHOACVTosbEl+UxjbbVgnBPVVjIvS26HETBY",
                    AnswerHash = 1693686895,
                    RawAnswerCount = 21,
                    RawAnswer = "QpRB+dsi3MOFhLtE07fh2NZgbl9GN3dmJSZVQvxJ9eqVYqJ4YHpdEKivvaOcO+2PZrB0e1S6js8jF+PNf8Y6+muS7vI6V52GS3aIa1FbZ2s10lFWAlSFaNu94ybUseKcq7+ZW6xfXYYMjCX+ajTT8Q==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 440,
                    Question = "th2YfKFcB2yMOMHP28+Z1ft+6juVhHWVmeHNMHEGFepCDAG+CuApCXOmvRCMYQTkfMLZLAcyfSuqyDvCjzXRF1wFNgLfbKg1wBwA/JmswI4=",
                    AnswerHash = 445797666,
                    RawAnswerCount = 1,
                    RawAnswer = "aLnwF6wCBf8rYMruWDIvlVDRblH6wqb8B8mebPOrtMEHo/WRLWFYVuKVdNpmCLqq",
                    WrongAnswers = new List<string> {
                        "ZkAuG2CzLRlbNMvrIAAqpTvwIH355yl7LhOkjjxftiY=",
                        "X9LNC0shnelzJ0neevKWvl1KrnseC6wUB72UOx5AjAA=",
                        "EJmAHKofsuFgR5ovYdslr5X8b0HdbscqRQ76CgKHwQw=",
                        "o14ExOpj8D1rxobJgkCuVNVcn2Y8TzIbsJvXrFcP6bc=",
                    },
                    Passage = "1 Corinthians 11:28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 441,
                    Question = "JJ/y18NtH5V0bzeueaOCzykqyGz3+8w8lFuqv7u1m6QTUmFvEypJm5JhvObC3UQZ",
                    AnswerHash = 1944349357,
                    RawAnswerCount = 1,
                    RawAnswer = "zwyf0iGTdC1eIufEluuhjNV+T9Xeyjlg+zKfaTjPTRve+LKJsGTy8VmqN8xWGRXa",
                    WrongAnswers = new List<string> {
                        "Be+n+ZGy1ZFEFBtgDIyaXiOsScNNmtbDzKZuFJvUvo0=",
                        "JtH4TcHqCqO2G09sUNnraiut65XDwO2bhD5NFw4WVZ4=",
                        "jqY10phQ7jlAlkmxrdnCg1/+849cKX9j5lOFJWz57HM=",
                        "1I5GCzlXPm+TlC1tEIbCvABOLwIrZ68ROwVEnftTGEU=",
                    },
                    Passage = "Romans 5:12; 8:18-23",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 442,
                    Question = "xMvmJmpBYCFgtm0cpCipNL2kENfb3tKj3DHA/DYDiH1dPLQcWy/vgrOpAxY+WJA/Js6cxDTa6pj3M5bqlnUSiQ==",
                    AnswerHash = 1633758127,
                    RawAnswerCount = 8,
                    RawAnswer = "lC5ZL+9ikROObMmFs+C8krkuZAnDqFFZTFjZSHIenFpbm4nZ/UO9SeotaBGfCWXzTdyOgIsErpsWgAYAO8fcYA==",
                    WrongAnswers = null,
                    Passage = "Isaiah 53:4,5; Matthew 8:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 443,
                    Question = "I1zHbk9MPFiUDvHJ+UeS2L2rgDDtgbmiJLJG7yC851Ob1+oeDDWKNR+Qzgii+Vz6",
                    AnswerHash = -1200193283,
                    RawAnswerCount = 9,
                    RawAnswer = "aQgPcEzUlijNjNuytGvMz63K/gadAbh3Jd9rgt7hWjkQ6CtQVRJuDhfps/7UhTw1XwdidfC9tSqSZ2piCaf94Q==",
                    WrongAnswers = null,
                    Passage = "Acts 2:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 444,
                    Question = "9LLGlLkb4Vr2u1DUj+ZU72vfSpOzhlr+i/wvOzgEuVUfkEIXA0wFPYiuVU8BYfy+",
                    AnswerHash = 1667729211,
                    RawAnswerCount = 12,
                    RawAnswer = "ijanzsGr9bb33F06ki75LMERG8zcy+6uOZ31Mz87TNHbsAZYQwycqwV48rYXYfIZOB58XQvMcGsHOktt1EUamp8v6LtkfHTu/zzvQlKsY5Q=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 445,
                    Question = "hdW2MBmwBg/WNIat6x7X2FtpzKgQBCpMev5RoZcM8+w+q52TGLT9299Gv0ObgA4gliA8mxyqZX9OzXNjTTAoCw==",
                    AnswerHash = 694841190,
                    RawAnswerCount = 18,
                    RawAnswer = "c9N8wBEeWrnKG2LlKPmoHzn0Ti2Unu5Ii2PhuDXVoZiyP75JFCiYRjZBI+/lMWeN7Z9BtaI873BwfTaPj3pNVvN7CG/tH6apb80jGSeoraQ5jvQw+co80bNftR5stEsB",
                    WrongAnswers = null,
                    Passage = "James 5:14-16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 446,
                    Question = "dADIrLNMW5vo3pyQI5/lHDU9ZRDwlKl+/ArKHSL44bQg1oc9MrWwGB5C1jIBqtrD",
                    AnswerHash = -672228452,
                    RawAnswerCount = 5,
                    RawAnswer = "vdA3EbhiV9Vp5mx+D2zVVj4S/2hrmVY/9huY43R9pAg=",
                    WrongAnswers = null,
                    Passage = "Titus 2:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 447,
                    Question = "XJSE7dceJfbx+ofXiGtB2yEHAak9ZIYfbiQ0CVRSIkM=",
                    AnswerHash = 517544425,
                    RawAnswerCount = 16,
                    RawAnswer = "V316QhdqLarqHtvmjpg4dj/s6flF7wO2/UWRrJEjg/JSSXuR+J5mVroMF9+hse0MwZ9re5QjYhRRKhCQVohOuJKmDu0xY3VR9GGyOY4CWZ61XMuY+MEmPmYIDmCX7RMVIm5BvM84sGMmvMYyzQ2vUg==",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 448,
                    Question = "opB/pC8phnN4+QRG6t4u8RusKcZ/CFu6rpjcmzOvjcTJVDkAnqB2zaVvbRV8yu8h",
                    AnswerHash = -204466824,
                    RawAnswerCount = 1,
                    RawAnswer = "yVeq7bHI8CoByDatoreyTQrqKre3zy/n4NKbO1ALvIQ=",
                    WrongAnswers = new List<string> {
                        "nWpDaGm093AcNXQfCv5fwg==",
                        "8IzBs+LuFy6xLy3YF0bV1w==",
                        "Xf8QJktmBZL6qY2THyTbyRqeMxNgHvkRL/OG8c9uJ+w=",
                        "LLNGHlru2V1NtKfndxhfcw==",
                    },
                    Passage = "Matthew 24:36",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 449,
                    Question = "4GVTCdIJDvPWLdgDRn/Dzp1eK3pEKcK+9SOsQ+IPqLUvLiGlKQpEMupRGa5Y94aq1XMh/qe1WF1zsHoNU+QSlw==",
                    AnswerHash = 207442966,
                    RawAnswerCount = 8,
                    RawAnswer = "asTSts8LHyOmsS2NgqY41iYfzaDfMthupDmLl6cKv7jr68ApgR9d2AtS8n4IAUxx",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 450,
                    Question = "cLn3MnKOACzXjjSpIZxO1YhOu4oxtopu0izlbz/eBMwBfO1GNfd+hjOLzX5FY8rEiimJ+dERk4CzCbFIXTNkrBXgR442j8002vLkQxeNohM=",
                    AnswerHash = 1233773048,
                    RawAnswerCount = 11,
                    RawAnswer = "/c9jwcM5htzQ9lbY3XRgeVVZDi/WXQpICVMkJQyZxpvhNKfQ6soQ7IEbcsI6QPvs4sLYT3c6ANwFUNfRuYiaJA==",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:10; Revelation 19:7-9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 451,
                    Question = "by0YEE5p60X54ZDEdxt6IaySErialfyFBtEd2qqCYRk=",
                    AnswerHash = 856313181,
                    RawAnswerCount = 15,
                    RawAnswer = "s07Op6LKym/6jyeB2qPLv+rDMLDZoHb4AmqZjnxfzJNzBBTJj4gH63MTzTiZbdW4SH4QrZ6qCjnfOJ8aHvLqNVJUhvrctnoWxPFeJmEOmHN2KX8IVxzGQHhbmChYFoDU",
                    WrongAnswers = null,
                    Passage = "Matthew 24:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 452,
                    Question = "yRSs2NBmQqDux4cEUE7BakOU2zEmdBHydEnQ27zY6h1H8PNCcsJ354b1z+n5gnkOh7lG72xuINKZz92fkFdhdQ==",
                    AnswerHash = 1700539357,
                    RawAnswerCount = 22,
                    RawAnswer = "eQ7/6xrkeFf2FwqM4tI+MN9GbyA8KE7G5xtCIyqasWpZ4oioxV7Xhllx3MpEwt7T3zi6mcmxdfjXJOs2HUatTqhs7K9g8rNAKKMuK5h3d14OXnPp0d7IsChE8cQ2QO9xSc1Afquy3YyrkiVwKz4YsEfL5X4oiuxamSzz20hw6Kg=",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:3,4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 453,
                    Question = "LImds2J3uQ4oeZCopXETlxIe/j323dN8HI7kVelL6RU=",
                    AnswerHash = -1024788087,
                    RawAnswerCount = 15,
                    RawAnswer = "Ta/9G4rG+pJdno9qALkg6CfmASNJGRYwJnQAjfCQmIiymgSAt0zOc4zq28B5Z4Mj3FSDut8DQta9+EXRznMa/hhgtZC8KfiJZKyAvRmyxSqUkgh2myYmEYJ7kthG+Z9D",
                    WrongAnswers = null,
                    Passage = "Revelation 20:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 454,
                    Question = "74gJsevsPUb+tIs7du4fRPwtKjYqwuu5aJfRV1BcCIPYN1Lz3DRPrPH6ypRYAv23HeM4SM2S81NE17NXAn98aw==",
                    AnswerHash = -899667398,
                    RawAnswerCount = 14,
                    RawAnswer = "kGrzCgwnftLm/3+BlYRsudBhvnPyxL5erd/OwyB8Z+cy+gyNtb264dG1XYjdg7/TugN5aakSg0+tUuVrLUFACQNnlqeOXhDXXpOoIG3vTRM=",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 455,
                    Question = "74gJsevsPUb+tIs7du4fRAevHyMDn49yzRXbWFak6Mmw9zZuLWf9jWMWub93VaNBDSEh1sTOhmnDEh8mvmXKtQ==",
                    AnswerHash = 474974953,
                    RawAnswerCount = 18,
                    RawAnswer = "WcbSBWGrJvvFCBiCrekx1xeTJ5laoRGLUoKmfSatsLZg9EjoxgfERBTLHKTtji718dz1FzhE4fZ120FD3uWUpXD209OWL2KQ34GKioa7p/+HtB6K9+eYz5fO15glxBCucG7OJP9fhdfNIhEd4IemFw==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3,7-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 456,
                    Question = "7zUtYnDUdDcR7koKNZV35Lq38Hv0/xDLHeMzYa7sa1MEoBedY+LEGTwrNvnzdSjo",
                    AnswerHash = 393343430,
                    RawAnswerCount = 1,
                    RawAnswer = "ECcH01zsEAzhoAaS5Q8olfbgCVYZqJ33O1TdWdEPJ2Y=",
                    WrongAnswers = new List<string> {
                        "UcDHgSc3pmMMAtPQvM9ZdQ==",
                        "OqKnQxUokdZAy2y5Wi6C7waO1E35jK+VEGSQb1outKk=",
                        "C7eSkCSeVTUKFH2jISWkQ1Sx/njUmfg6lgdIDy2XdfY=",
                        "W7NWaEyjkj0CQeyKFZKAFydiBnLPv4nwe1jdqYaN5xk=",
                    },
                    Passage = "Hebrews 9:27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 457,
                    Question = "9hUOeP7f79+VfSYfTUQx1A==",
                    AnswerHash = -1221106504,
                    RawAnswerCount = 23,
                    RawAnswer = "E+2WDT4ujm4xJF5K84KZGtg0v7DoMu8AFqWuNuwl+yrRNlyB8pX+HoC3HFkmEiPcJVajUht6I95Eb2y/Lu0eItWKtY1lAIH+EjOzE01jYl5Hufq4NUEf4aA/WaUhaBfandl9TxrrFnIJ/II4ypNJgEkTd+DxgzVOn7uJzxa+rPM=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:34",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 458,
                    Question = "xNobJ/J7rB/9ornXL4nftRtl39qMNPSCY3bhX8/2gaTynh57/9Ndo85oGoPaN0TJruiJTDGq/bxlFyIaC1LVpQ==",
                    AnswerHash = -281974559,
                    RawAnswerCount = 4,
                    RawAnswer = "AwnodUems9qYCzMYXY4oxUUmfreWBpcuC+kQxbQDcOA=",
                    WrongAnswers = null,
                    Passage = "1 John 3:2,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 459,
                    Question = "H3YEtxf9n6keNW5spqvg/wiga9/3yHnEbp4+9IXiCCdsai89ro8nmgQbs9PXDGqr",
                    AnswerHash = -1163843209,
                    RawAnswerCount = 18,
                    RawAnswer = "BmNa7JSvMYawyvGH/ksm0W43My2Bf49S+NE1cop/ZTCb1dexnBMpkgbQTrKdp++xUuJy1kkVdt6VMrCfyh7se+H/ASflump2kPN+7LcuXftJXeyYAHqes6bjVb2hzWQ75byxRs+O2TrPSUPcvJhKvw==",
                    WrongAnswers = null,
                    Passage = "Revelation 21:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 460,
                    Question = "cmK+wiRdDCQEag9ntzSWVpxNqKrw/x+ngmQG6qlmWafvSfiewSOJkm6C4vL73m6Qqjgh6FApA4BBt6Rt/TAFHg==",
                    AnswerHash = -324327086,
                    RawAnswerCount = 1,
                    RawAnswer = "L2lGQ4i+YDfTPPn1FOFIVF+TdtckVs84Xs35Vh0wWaGEuhxzzH7Go4ro7oW9IddU",
                    WrongAnswers = new List<string> {
                        "B9ZZ7vxFIN4i//JAz4xGfK+qoSP1wCLUPsFnhmA9SLY=",
                        "7ByGc5X8RmsdEIvejbv3ol34BjlkJN7HhLRhtOXOD4fs61O8+pYf7F9hZXZAkhEw3W9R5yHBRN+IzDkwpfu+JQ==",
                        "BDRhkvQZZFHUf3/xwk5eJRE5iTQ8v9A4hSoxq9yhZAsg/xU6A7arhjG8m8vqflr/",
                        "F/OCekigRqVirbOB55wpUsPS5EfSwYIBqHAGcBdvoXnAMzsl/wMZPyLAaXPHIWE6sdR9NHwFt7NPv5P8N7PswA==",
                        "5x8B9Ypw4CL4UyAEJGRkzQdhfU97nqb9JgZYupSKKUTI0pRjoNvqumbDsotmWEJRfo88cnT17OAIoG669zkbwQ==",
                    },
                    Passage = "Revelation 21:4,27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 461,
                    Question = "al35m6I8T5BXo611rz7AjC0eOQkQ1RCgtKojIUqxHoj+Eu5Zmu6GDZG7KxJOAxN3",
                    AnswerHash = 1037270311,
                    RawAnswerCount = 1,
                    RawAnswer = "vHybKIoQrdUd5kEtapnLcw==",
                    WrongAnswers = new List<string> {
                        "U9NZTu0QxURybpxtfQEKnQ==",
                        "pDRs8nhjEbOt6Y4aoIIhsA==",
                        "4JEsXve1x9I10Jxgc6PkcQ==",
                        "7/5EhtiYjUA/6Au4igk8vg==",
                    },
                    Passage = "1 Corinthians 15:25,26",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 462,
                    Question = "6R7zjRWK6lcyVHd+QvGetA==",
                    AnswerHash = 684469943,
                    RawAnswerCount = 8,
                    RawAnswer = "TB5kWUv+AY3ZVoRiYeD/+CqoocBa37p6BbPCB6udv9L2POJlxoHehJ/XKuw2jZUW",
                    WrongAnswers = null,
                    Passage = "Mark 9:43-48; Luke 16:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 463,
                    Question = "pnKxm0p4ZUSb7m4KGAuVrd36QE5exp6mmgvs8Dg6+F8=",
                    AnswerHash = -1202370525,
                    RawAnswerCount = 5,
                    RawAnswer = "AYb56aPQ65TKUSV1zZmOHZ5mctfT/88jJT3xtiJESzc=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 464,
                    Question = "H3YEtxf9n6keNW5spqvg/1qAuj8EWKf8kBDSEFK9iK604aOt3YE8wUgHu6h0Yec/",
                    AnswerHash = -567858716,
                    RawAnswerCount = 19,
                    RawAnswer = "sXMdQwHh3cvBzG0jGoOOcR2bFOZNG+2RVHnoeM3GwYUjoNFKrqlZfCCEiIVnGn26DZDvdyC9AD+XdgTwEdLTexsDOiCoj20nyyguhdFiDjGoPMR0IUWRFUunfvh2Tw4e2EnidyRhC/uO3W8KEI7Zlg==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 465,
                    Question = "PpknvWUV26r/TYp58FWPO8QcN+3MKJwSj8fcWsno9XI=",
                    AnswerHash = 507748251,
                    RawAnswerCount = 19,
                    RawAnswer = "taUDfecIy7KHZvqJRzVAFdA2XyqhkCK5tyLHniqbhGYq9lEXByNp3K+UsU2l9uIRXDs1w17e3ZUBRTvzjEPNIanGa/+e829VbMB2/QIX5Qp+GBPlcZ+hXJQm0/srFOX193TTPoXYSl++QClwgskttg==",
                    WrongAnswers = null,
                    Passage = "Isaiah 14:12-15; Ezekiel 28:11-18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 466,
                    Question = "yMunM6HBHmCtGo+cEyFDt2BHe9UnDpAktzZv8A6m9+XlXPivyJABROOgoHo/xj+M",
                    AnswerHash = -302837969,
                    RawAnswerCount = 15,
                    RawAnswer = "SYm2koVRZc6lqABRdB2GplB3RddT4i/KSMDVMEDP9X/8QaRJ+tRJ0p+pZ/6KO/QNjaqZy/qOyHIuVsuhpjPfZecb1JcXZsTr8wqiBhuOnnNq4oVE8C+fyv4rAKwQEUWT",
                    WrongAnswers = null,
                    Passage = "John 16:11; Colossians 1:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 467,
                    Question = "DO9pGaiNRTyuZyd7JB9+5Fxfj9YeRn8ng529NQH6ojVEUnn0CradgZD9twzW+f+E",
                    AnswerHash = -1975968875,
                    RawAnswerCount = 18,
                    RawAnswer = "uypg10wg4nicN+NptiMrz9SOee5Myl0Eo9G36burFrbXAcvVVxpDR6xaHEy05wIfJ3FAY1wHY8Bb6eDYXs+gIJR5C5b1j8mkWmdJBlXZG/J2f5CeeF/6R2CGI8O279a2",
                    WrongAnswers = null,
                    Passage = "1 John 4:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 468,
                    Question = "a7vR7b1BmWmPhQ1ubO1xCQhrF9WZjNEUf8Shrytsu1hstQQLSh5TQn4eeK8RAjxf+LkpjbTPuv3ULTBjSNvRif02rs30cLPWUBqBnmcpstqzRLIFF1P7TD7Lttcm26Hb",
                    AnswerHash = 279537683,
                    RawAnswerCount = 11,
                    RawAnswer = "aGNTzv69sRHfRXMNQqGZSTNmLWJepYacJa7rgrJ6uxHzNobImEsFXk5EsPOurdllv+knXP/FdltUITQljQMVn+8ic3z1PzNUV8lCXAATt9ORWNPh1nbGM4tZyr+w1h0k",
                    WrongAnswers = null,
                    Passage = "Isaiah 47:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 469,
                    Question = "0jQdhDEQgaqJh2QUkG3jrnZQoP3eCtkPBLCoTPvlG1oVRo0uaujqcoCpwLO31su4JmOsV4lzuyCwegKjTzm3VQ==",
                    AnswerHash = -343573841,
                    RawAnswerCount = 12,
                    RawAnswer = "xKHrvJTBuLHUkWmvS/LPpylrGf5lpEYGp4mPpcVuAPH2R93P0P/Rx/UOdBGrMxbMw0H8sdQIkPr6CYqA/eTiWhlETr46nXpBCbIGZhzKDt8=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 470,
                    Question = "I98LSLvdtHwZwueQP/wqgEnbEZTV027vM+oKiQJWJshReEo4MxV8tSGKBlY4pppfAhW7UJuXoUoWvOUec3HGK66j0u+pcUa8hCB6Jq32kZj95VMFo82vnzuSwK1kBg57",
                    AnswerHash = -273357131,
                    RawAnswerCount = 8,
                    RawAnswer = "xbvtzdoBtImedHL1MZKAiAmeR8U92eEAvvp21UWPGpzBL/wdHoRq817Bcl5DP5wR",
                    WrongAnswers = null,
                    Passage = "Luke 16:19-31",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 471,
                    Question = "BqNrxMO1uaejudRByhTbF/9hx37MPjFbH9w3f1ALQkC3vzim9zX3LpbUoSfGiSjcQbPAwGuGc2xzEK6AYOT7cBkMFBw9j8N/ZbIS8DsVpk0=",
                    AnswerHash = 1936336862,
                    RawAnswerCount = 19,
                    RawAnswer = "lfQloTHvb1/LmyhH2EyjPU2AqAR/U3qq0d4eZLPgp5iS5SfqFeTqGgWgZq3FEUp5p5w4c/GWeQRFTWNzNg75Lu9eKIp1gPOxhGjEQ2x+765bGtTLOViJxXa/yHzZp3W8CvOyPVX6qEkv59Il3ZOSsQ==",
                    WrongAnswers = null,
                    Passage = "Job 19:25,26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 472,
                    Question = "A6RVAjXTnOKVoI5CFBGGBsKVz5N6acsXrdsHx1tqW20=",
                    AnswerHash = 401677103,
                    RawAnswerCount = 18,
                    RawAnswer = "rdsFnKDNTDH1Llonor5oKmNbyN+WwWv7tNph8398XLzW7H7Dmd/ND0f4QE2Y3rzKU7CPFmv6XbGzlbi/oCl8Ta2A5x4vzFZC0iJS9EcWrf4f7D0wdEjQhVhKhEXB5rLac2xaC2yHyKguOIjbDBIdhHmbhSCFelCpS5sOCzeMTrE=",
                    WrongAnswers = null,
                    Passage = "John 5:28,29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 473,
                    Question = "aCAEGzPXwENMr663zksC6u5ztQFLQiJ+b99roTjNn9Aq8UtgUanJn7z14Gkyo8G27nh34w+wnlY1bDfIgZyf9ZYePHPOwSi+tX0oILMelBs=",
                    AnswerHash = -1003200935,
                    RawAnswerCount = 1,
                    RawAnswer = "qm5MGrwk3TxIGtHmJtkK30Nu+/KJ6HWyw3RM3wVtZT0=",
                    WrongAnswers = new List<string> {
                        "lVvm8oz3KDlVVKQT52EBlw==",
                        "qm5MGrwk3TxIGtHmJtkK30Nu+/KJ6HWyw3RM3wVtZT0=",
                        "+bVYbwyC7CjxwSc6dRHrnw==",
                        "6f2fLFrwAeL6jsmxn1wAXQ==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 474,
                    Question = "iTiymmRDT4TruwW4Do4I2UxauclpzngcwEwyarRRjot/MWAlGDQp7ksetSUk6CNe6xYPsVid6RgH8o1BgnGGHJWxDLOu4oP9ZLA2oXFewPagCkxtXc7DrxxgLbIb3I+H3sk5Fia+g2QCx5Esa/opiQ==",
                    AnswerHash = 1775714068,
                    RawAnswerCount = 9,
                    RawAnswer = "uQNiM8Wm0Z+nCm4VSg2P45L/15wyMr9wlTxb1aZXCC2TV88+VrvPnfmu05HRyZHX",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:36-44",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 475,
                    Question = "rh1LBoJHZEk4BAKjryeMCgrKqnH5Dl/OE1JPwFzilNT4Ua0J9rFKveiHtDR4XL4S9IYpe/r5FRqNEvURECf4GTo5Fr8+ViwMUUOeGtMvDXqpwmb53X/tegjJpisMtIDb",
                    AnswerHash = -511694587,
                    RawAnswerCount = 1,
                    RawAnswer = "gIB6sO3yLkoSwuySWXJ8MA==",
                    WrongAnswers = new List<string> {
                        "/mGnWAVYp1qiy19YoWY0Fw==",
                        "5T67t0KX8tevuql66r4v/Q==",
                        "zYrewpPrYTL3WzDb+T5/KQ==",
                        "47QGis6LzcLxdc9MSN5gdA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 476,
                    Question = "A4EifA8ActUjlWb6VuK10E6eeDHukvf30aXBQeiXuBRVm3wwFpfTttBQzko/7Vaurl8GkMPkR430So7VXIYmtw==",
                    AnswerHash = -832409236,
                    RawAnswerCount = 6,
                    RawAnswer = "Gn6JSv1sykm2F6aUS/A00LscuN7x8K2I+MCXAE6QAeM=",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 477,
                    Question = "zac89zhOUq1IxnSyI+19fWEkAlQcgrJvGhEqw8BsePTxYsYPQ/sfzEpzYUbFYetuBoR1CXQEmuzfz+8/bCPhJYRfm7BQUvh7t7lP4xXoipM=",
                    AnswerHash = -46232728,
                    RawAnswerCount = 1,
                    RawAnswer = "4e2nCcprGf4sYxu7MFtHnw==",
                    WrongAnswers = new List<string> {
                        "xi+R+D+vktwAOm1aKKNVrQ==",
                        "D3sKCJOLp1QCMYIZ9v6EQA==",
                        "KnLnX/8y0cjRXOARe79ol9T7Zn/LHecC7WCwZWKu85w=",
                        "EILM8GqeMhfAFBhFNjxqkw==",
                    },
                    Passage = "Luke 17:26-28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 478,
                    Question = "yRSs2NBmQqDux4cEUE7BakOU2zEmdBHydEnQ27zY6h3ZfEd9C/AgFpEaKV7CEMjgtf/vG6eSE7xaFbsV8mBteg==",
                    AnswerHash = -896473366,
                    RawAnswerCount = 16,
                    RawAnswer = "glEV6M6HuxM2681mGbkYe8BA1QCDsVEUQE5qpcGmTfDcYVYx3qvSNBoKLVQTev8jqRj75Vhty/TsQVTf7XjnVKZl9akYADlNUZ+g8ycI125e47InN/yOmIBuo7WsrDOl",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:8; Revelation 20:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 479,
                    Question = "5K4lx2sK+UGkVIUbVnidwAY6y+2DoB64Rur9cjHQpMDSreLk0x+QDLn1ObLCsmfni3nhFyWWL+9Woojvc3Uafg==",
                    AnswerHash = -1930206934,
                    RawAnswerCount = 5,
                    RawAnswer = "pvt8vbVVwiUhI9ylaHhgfqdXJUL8gIHZdOr9H4vooB/JIWgh86sWXt8XekPcIwcp",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17; 2 Thessalonians 2:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 480,
                    Question = "ex/4rJjy5vrX67ZVLYlEs5ud0KmpFcrTDkYtNlAYLm9xkeFWdtsw0PgTRYEn6T9mUqsSbAhbD6wwiAbKXCgMVRY8R93CanyrKE+S3xAT98G2TNXoInPHOTl3pMw/eR5z+tV/bTVRuMCNEe8I6Z87Dw==",
                    AnswerHash = -1093316530,
                    RawAnswerCount = 10,
                    RawAnswer = "QJ5bRpaLc+Zv/ZcC4fynRow7p+XCdt5wHorHUcf4rFwdpAhomNq9wHyG9sYMYtTJ1/xYU/Z6V3+tgFYdlTxiTw==",
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
