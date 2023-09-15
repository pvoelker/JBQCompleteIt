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
            const string key = "Lesqs0IaMSb831ch9C5Y/w==";

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
                    Question = "mNAKVl6BbFdZJvfNjKC/dWb+6Tz9PwoEkMF/uY/fHCY=",
                    AnswerHash = -344759053,
                    RawAnswerCount = 16,
                    RawAnswer = "dr7MSRdeMBeLEfQPxQcT4R99SORt9CdSKqV51ib2O2Zd63c7Fd1Gx/beueskIevjkTTkvcU6258Vh1e1fmSU+OsDtW89YnqIGe7Jlibvvq9n6Vu+D+L7jKuShK2b9Cjq",
                    WrongAnswers = null,
                    Passage = "2 Peter 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 290,
                    Question = "jK39/8VSboAuztXPmERszc6/ov+YyJhCizz6vS+5JatnM5TiJw1VCyK5z1rAWm/vINByDCamCJxBQ5OXauTJNA==",
                    AnswerHash = 1056830619,
                    RawAnswerCount = 8,
                    RawAnswer = "ZlY1Ok8GQ4ZV+Ny8SX4Wnu88b8LmvejGu5Mw0pM8fiDVS1zBUAzfTb9PAZWm6nr+",
                    WrongAnswers = null,
                    Passage = "Psalm 119:160; 1 Thessalonians 2:13; 1 Peter 1:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 291,
                    Question = "jK39/8VSboAuztXPmERszc6/ov+YyJhCizz6vS+5JauCy4ELLfxiR/aH57APr3MyMHO0n3exI5rsfvq78h9MWg==",
                    AnswerHash = 2042121049,
                    RawAnswerCount = 13,
                    RawAnswer = "cOhMcm2XiWh7eFJrGC08w0p9qR9uOu/D2ImgeitxHDD3JcaYp8bwdDm0TChLcqSKbEvZQvaFnvSIVlw6SGsQXfJpzGDYc4QnWtuJUDV3rNQ=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 292,
                    Question = "jK39/8VSboAuztXPmERszc6/ov+YyJhCizz6vS+5Javh8BlwNBXiGWJFtBFjmqNvunELdRzVrTaBOvtYOJxF2T9QjL7LTbNNp0g/mN0lMjVjcUdr+s521iqvnJGZBPPe",
                    AnswerHash = -1239122098,
                    RawAnswerCount = 16,
                    RawAnswer = "lGY5oaOgbDLKPUCHQ+RKYBaktWwHwDWi6RH8eO1MCrzdpDI2BVirlnoOd0W1AubOgcggOEX5DkJ6JrKVP+mws3nyJtga8jI5vKphTLkaj2A=",
                    WrongAnswers = null,
                    Passage = "2 Timothy 3:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 293,
                    Question = "676k67zcrbKWE9S/YeZ8LPmUWGSmLtiPwZ8hMyJoYI4=",
                    AnswerHash = -2120422463,
                    RawAnswerCount = 11,
                    RawAnswer = "3jVUGDhhOapZNpQacxEMCv16XmXw8tRP8NJEoOCQPzYeBZHAyI4eV59Xr0HJk8wjzJr4Q84N12oY3n1kiv56Jm1KyoqG8pFiGbyXwDzO9l4=",
                    WrongAnswers = null,
                    Passage = "Matthew 24:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 294,
                    Question = "HoRRD3cW8ILA72fdJOOEiTbeWhD+lJng3I+Kbw7x8kX8hRHrHO+LTp6E0ZMS42g7",
                    AnswerHash = -1671284356,
                    RawAnswerCount = 15,
                    RawAnswer = "2UB5uPj9SgmPzMruL43qV8WPMRA+jLaQIeLUZKlTuARmbf75xbMhCofwH4N6RT+VcEr2fLYegwVIhGp9LG4+Twdr9BY6YcgMYHbt8kDxjGw=",
                    WrongAnswers = null,
                    Passage = "Psalm 119:11",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 295,
                    Question = "jmb+VY7WTO7345rk19c+HlnKDNCsDLP7mkviPOXlcKuDzVSrTkL7ghXK6i+HTX7w",
                    AnswerHash = -1346680564,
                    RawAnswerCount = 17,
                    RawAnswer = "SiUvYacGOgQRnbCeIA2dHh2P1RoKhjq3TyfZGwfmAk0Pk7fFJpO4ZlR9eEJiFAR8Zg5uOmQ60FIajKelyXkYxDoSbzCkIKR1882zlWeEw28mqqasHrpMAV57q9/6c4mi",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 296,
                    Question = "PmoEdrCTliIMXdsVDt3pOihQdlicOZRI5yQUS6aacu4BB0wdgenZuh0cJw8oJEDnoh0779qHs2i27yuhit4Z2w==",
                    AnswerHash = 777767355,
                    RawAnswerCount = 1,
                    RawAnswer = "lX30tBuAg2o14zR4mgrtsKSxusc20BfiYuTNbEuNpm4=",
                    WrongAnswers = new List<string> {
                        "MLDSHxDOn98qs1ivP9omVF+ZBY5mxLo7WftJE1i0IAw=",
                        "gBLtzM4Zgz9gwzmfWViUuA==",
                        "lINZQWU8LoWzCHgITT4mpA==",
                        "ymjV0qKW/e7HM13X+4OfBA==",
                        "sDVhK0KFezKug1ot6biL5w==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 297,
                    Question = "zZkgLsAUhNT6z6sh80+Nw3RnAIjUczl1RhLS0grXrTBmT09KuwjK7+23QD6wTCVv",
                    AnswerHash = -1205377531,
                    RawAnswerCount = 1,
                    RawAnswer = "96CI9QM1mQlgg1xD96gtJw==",
                    WrongAnswers = new List<string> {
                        "6Ct5p3GxDHELhIYYqM8poA==",
                        "kimvEN8bUhpvctqFXCzgOg==",
                        "DjvMDw7aWGo0G1B2BNh8JQ==",
                        "6vQkMOtrsdV6eX4ajGBnpQ==",
                        "rcUeTMl9wp/VfZng8372kQ==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 298,
                    Question = "ipffohDnEVTFcDFYTVu4Bh1e1z9hFxuOUCqSTI41ni2wiqrEtXfehROEMGUKwPP9",
                    AnswerHash = 754004939,
                    RawAnswerCount = 1,
                    RawAnswer = "BtbOdHbUsARBkVF6W1XauC6uWVPJjk265o0HHcr9lXQNrwhl+/JbpSKLS3ehmv9y",
                    WrongAnswers = new List<string> {
                        "pdcGKGtYDQkvNPbaLQTj8upvA7hsNhvaZyqwKnqlw00=",
                        "hqggwESW9SEKU3hVDsPzOXrv3JsAiz3OMd5byRE79ho=",
                        "R6HAAhCIE569JZZ/Ig9KI5mQG/CSTMEP9wR10r9oWJS9hHlNjCzDBr9sslGaezml",
                        "/MwrIjqT6D4OZ1h11ROeibuchN/MjVHN414XG/VHUo8=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 299,
                    Question = "83QzHTKsge0hp1X84J/tqlweRMJ4MhScfFtE/EWgp0EGpM6MdcEejw/EA0Y0oqv1",
                    AnswerHash = -856571652,
                    RawAnswerCount = 1,
                    RawAnswer = "TT8bQ+QPiC6mjSF093fCj6mD0zz/VG3aCa/3D2hTa28=",
                    WrongAnswers = new List<string> {
                        "qQlR2MsinhhBz1HGrPuHFw==",
                        "UJtBYewxW4zgIM9RipMcOA==",
                        "XA+NJV6TQacCDG5HYnXknA==",
                        "6O40P88mzUdxB+YNcTo7r1CI2cu6JQUJfXAksyDyCn4=",
                        "g272zcxOkS8CUsrNqctJCvk0xse1ixqBMEnBvjdgcj0=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 300,
                    Question = "mxAMJ6qedd7SjpAmK4wXWxps+3CUGrjul9dg6B/ay1U=",
                    AnswerHash = -145805459,
                    RawAnswerCount = 14,
                    RawAnswer = "kynDd6yQQAl3UL1XAdy3rXnul9JcC3hnLyerx02BVbBasT9Z4dIiP5WF90fczwDjwA7TMiSppfKdgTG3oJd3Jrwg7H8SUD/GrOvK+bKTszL4aqwH91w/q71/K/qNz6db",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 301,
                    Question = "m2h4pWiw0pV1GalPtFZEaxPMPdJk82jSykvp9P4gVWjUXGhSt/f6RIA8eTNCCROEkR8xLC5rKX3OYCOVVsV9DQ==",
                    AnswerHash = 254672263,
                    RawAnswerCount = 1,
                    RawAnswer = "imEtplkvYdjyXAMd1zuiYLj03BKwFi+GNeUAtQxHYGE=",
                    WrongAnswers = new List<string> {
                        "+6UsJbVYGXyWDMyLFG4Ioexyrl3UyuKvdUbffe7v/sakVN1UQqgKvRrf5FVMJeNSTUpBnXv1DyEgo2eQQ6LhiA==",
                        "0VB4AcYhmjnP+vBk8DCgrk+CAV3TNElGrhubdfOxT3k=",
                        "HX1dHyKdXrFyk1DiotL6H/KcYV5yXT3rPK2GCBe/XjetTJP/6zfs8c+vrYepPQnx",
                        "qhM6Ptncf1AnWUMQKCRi70vB+LoleqzeUoK0P0opALg=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 302,
                    Question = "63kaAEQ+WT1uUwrOxSDdlsJjvN1itiSUBTmz8Ov6WhDzn94Hvwge/CrFN0QFpByhrumMgzHTjC1bIyDwr79p+A==",
                    AnswerHash = -917310919,
                    RawAnswerCount = 1,
                    RawAnswer = "UxVp4oXvw2mq5DvoL9078A==",
                    WrongAnswers = new List<string> {
                        "Fr5+pPjJ5Lb9uIx1qlXboQ==",
                        "zI1TkYLmrVkVpAt5aWkWWQ==",
                        "0nM1aNgrRxKzGDJjX8PZsg==",
                        "X//Ah9K/e1JkqiSXG2kI/g==",
                        "vMSw+R7RglhrxWrzw935Qw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 303,
                    Question = "fKaigTLClmzRaqJJNHHrF2AeSUfJvQjfEc4oOKqyRElva1KOvPDyAq4GQuE+eSDE",
                    AnswerHash = 423533928,
                    RawAnswerCount = 17,
                    RawAnswer = "b9S259uM535wwdJXecq5/XJQlI0R4MPuq6M0ZvehWmzPJnEsVkxEhkdjUect4acDpvQwVkz9MZ1USUtKHjpu5/5rOXfjOMcc5O23I/omTUznhAYmySuIY2ADeQveQhq6waFmQQDSbh5vUsBYJL7Lng==",
                    WrongAnswers = null,
                    Passage = "Hebrews 7:11-28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 304,
                    Question = "hwvJZPbVL+TMQkEJxPFCYF5vIJnAVHeh45msJ0wTHsUWEAAybR7Ih9Sz9rF4EFIo8gNHEcCq4/8HlxioVds9eY2IZrC5OU6P/U5zVVJnFD5bzqMDwQp8sxvhHDx0TvqHAKN+5eHZ39zEG5VAEi1bhg==",
                    AnswerHash = -1545054144,
                    RawAnswerCount = 1,
                    RawAnswer = "6Ct5p3GxDHELhIYYqM8poA==",
                    WrongAnswers = new List<string> {
                        "kimvEN8bUhpvctqFXCzgOg==",
                        "DjvMDw7aWGo0G1B2BNh8JQ==",
                        "6vQkMOtrsdV6eX4ajGBnpQ==",
                        "XPNEbiWzUKBFXv+hff2BbA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 305,
                    Question = "WjnU1Cg7dsl+H2xfDpCHf6lWvbI3Zk0uuXkp1sePsb+17SO8Z5ZdyHI5Ng5OkFjkE5/HitW7ShNylUJRiLQYKeCIwBUTtt726pYVv02PY9a7VGV49Qy7YB4Tj8hh9wnh9Iybp8niBql5Zkqkw9BExA==",
                    AnswerHash = -888882979,
                    RawAnswerCount = 1,
                    RawAnswer = "4LjwQ+OmLnXs5ZW/U2KjxJizvS+yUFjryytT1x8+NxI=",
                    WrongAnswers = new List<string> {
                        "VLO5Hyuk60+OKatwkoHp3NJ/eshUnNLaP8Rw9X4xzJ0=",
                        "rwXN/WP4rAjuVZR7kCYpjhYJ66hEs8loN9JplyzCvdc=",
                        "DAHAgSpXnnBVvZml2Xxbi80i8GFg6uUscpCtP+xoPTk=",
                        "nvOGlYul+nl6C6Tyjn1tEls9Z8e8Afm7nm6zuxdm8TQ=",
                        "+a+fRVLZA2+r35G38G7zHC1DoaqwYBQJHzmT0qRZUnM=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 306,
                    Question = "eCJmysfVGv8SympZm00DzRlW87jf2bSJZhQ5jzapBGLF6mSvU7O1qGelI9BQRPU4",
                    AnswerHash = 748953323,
                    RawAnswerCount = 10,
                    RawAnswer = "ggc10OTpqteKu5Qa1PBkmDzjK7XC6a55Q/+mBeZK8Xy+jfz9dFWl1bjLkXJ/YSEaSdIkscFYWWZvj+Wd9xDcbA==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19; Acts 10:38; 2 Corinthians 13:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 307,
                    Question = "jK39/8VSboAuztXPmERszQEpn3OrXS1n1QfhgH+tWIqfKhu1aY0I+WJGlNgdcYnxMLLr2MWR69rFSINA5SG/Kg==",
                    AnswerHash = -470407565,
                    RawAnswerCount = 14,
                    RawAnswer = "HdTwB5EcWI58xR3Cc1uM074w2oWd7I+pXmluGUjv3cRbg7jsy+7caobQoTPB2ULu+RcwIwZM1t5yo1VBot3C1e4z9V9O+QzYaR+E9pHnba4=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 308,
                    Question = "jK39/8VSboAuztXPmERszQEpn3OrXS1n1QfhgH+tWIpi8YQm/NGt2Hsf1ZukYVg9o2AoXCnhYTTvQjQgibhPXQ==",
                    AnswerHash = -58580859,
                    RawAnswerCount = 7,
                    RawAnswer = "I8Re7BJn4FQU5nLq3bKoVeIRIyENsjRsZabuHj/0ECf2h+45uYMMSK9oOnk2/azX",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 309,
                    Question = "jK39/8VSboAuztXPmERszQEpn3OrXS1n1QfhgH+tWIpDW/jI0hqwxv34l7qA3Io+AsouyHDWsq4lJewubXdTXQ==",
                    AnswerHash = 928896449,
                    RawAnswerCount = 1,
                    RawAnswer = "Biz8bmugsD3dTrK39x391Cg3HURro4gI7JfNnLOOm/8=",
                    WrongAnswers = new List<string> {
                        "KsFhwCCbTAHw6MEEice88NkKVM31YiO1qyLpaqOOqUU=",
                        "Ti/sTpACHBJmvVV8mdpmIwgb5OayFybel4sFgYiOihc=",
                        "My7o5Gdg55Aice5ylttbZHoTsg1m/bJ5v4etRFJjuxA=",
                        "BMFCoBlEpkEDS6U68YiNTbvu9ZfjiebmjVQEbN3ohPo=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 310,
                    Question = "jK39/8VSboAuztXPmERszQEpn3OrXS1n1QfhgH+tWIplolitV4DylGkyFOVqIBchfJR7mDpBcWpkzGsbUXO1/Q==",
                    AnswerHash = 1027546023,
                    RawAnswerCount = 5,
                    RawAnswer = "SEYs4jRc7OgR86/iTNqHoCMI+ud/3/KaDbYmj2DBCjzdpGTv0sn98aR/R6Z9jPGH",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 311,
                    Question = "AlzjePyKpffi9zBxx0+AWkXvdBOLnkg2aRd3N0c/RQgPLAVcySy8PyO6SbSZENpy",
                    AnswerHash = -1318617014,
                    RawAnswerCount = 17,
                    RawAnswer = "ebWkViAzTbwBcGw8PZNZPsaYVQrHMg6AKWMVXplgxakcW7nRrTyXNa49GCIiZ24egQC8MH6xv5JxLvbXE1Rf2NKZloqMj1W7nB5l7+Wb0yjId1UPHYceMsYyqOUYesW+",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 312,
                    Question = "828g01b2tDDqQc9OCxMPsf5rl73hR7c5ygDe8xzw8PgcfzgMymGnpvz+UkWLt8Hp9+UMInx+QhwLVJW5WCA2zA==",
                    AnswerHash = -2131818754,
                    RawAnswerCount = 1,
                    RawAnswer = "ISQyztZp4dB/xxHJVi4/gi5UEtnIeFeDGRamsowl1A4=",
                    WrongAnswers = new List<string> {
                        "2wPY2+GPbKKjCc7yEMKpXE3YRv/dg268jV6So2KdYuY=",
                        "Ee66OmCEA8wna7kNQIlOYA==",
                        "u2oL8vyMxZODZKeeg2TkwA==",
                        "KvgXNp1abOCwqJ9y6q8yMClaRROwKNW7zoHRT3uLFho=",
                    },
                    Passage = "Proverbs 9:10",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 313,
                    Question = "paLJ4ivExEZSlIFSXCBlTSRWPniWPKL0LwXDonmsOb7w4ZMxxJzRHyoHOo3wjHVF",
                    AnswerHash = 8249242,
                    RawAnswerCount = 10,
                    RawAnswer = "dSIJ1VdibtIRAwcyilH1yKBhNLgZeR9oyljACnDcBnvSdJU8TGmRibYgPY+SQ7AKAbAITPZitZnmgww2LhXhhQ==",
                    WrongAnswers = null,
                    Passage = "John 4:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 314,
                    Question = "tv6bmVSGqkCHMG1XUSmcFkU8W9rgyCoFwrKy8H7HyCU=",
                    AnswerHash = 1929663489,
                    RawAnswerCount = 17,
                    RawAnswer = "oiHNJvEfENs2ueYAM3LPhtj1fzBDnOoL0r+iQ9ocyqQLIKZy9hqNzR0t4JWxZCoyKeE98XDyjO7MLeJYQ/LFcTJiY7mnJAc8sZDuRPBbRP2TmC37UMd3csEJlf/xNT2Y",
                    WrongAnswers = null,
                    Passage = "John 1:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 315,
                    Question = "g4eYiGHGwSphXtBdAfePG2tc2M1ug4fJZOldkVf0LL/B7OYJ1qPz3QGwRX4vZGIT",
                    AnswerHash = 180508621,
                    RawAnswerCount = 1,
                    RawAnswer = "0nsKunoawZMXcLeyR3Hz6w==",
                    WrongAnswers = new List<string> {
                        "W9N2E4HmYP784avqcILyuw==",
                        "1zakGLCPT7S2Xiy3D6MyiQ==",
                        "nPaf7EutGkz3iVv/B1Duiw==",
                        "96dIGjEByWw80yfiP3FOY0GZ/JpVFIZQUMapbQQabiQ=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 316,
                    Question = "g4eYiGHGwSphXtBdAfePG9gZp4fMG7DG/UR3pmBxEiiCxj8ohXKfPqMqNbaDrMto",
                    AnswerHash = -1637641259,
                    RawAnswerCount = 1,
                    RawAnswer = "W9N2E4HmYP784avqcILyuw==",
                    WrongAnswers = new List<string> {
                        "0nsKunoawZMXcLeyR3Hz6w==",
                        "1zakGLCPT7S2Xiy3D6MyiQ==",
                        "Muw59ydEaKClcKSHhB1e+1tKdQ9mcDeVfaahcFh+wy0=",
                        "ox5Jsd3fCVEVJK+HPfiATdGD2MP8lorxVuN9byNsyMA=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 317,
                    Question = "yNetPfpNLMztoHNib1rvahhVqglgqd/Ym7JhnyvpJoySMrhGnk+YXeSyFmSa3cDiAkIdHt60BkRIcflEfdloqw==",
                    AnswerHash = 1926915631,
                    RawAnswerCount = 9,
                    RawAnswer = "bFmApmtd5wuCrEmPe/OOU0JMoT0zvr4W+Ht7QMVRYOan45FMNyA7HlTP5fKLmGT0pZ7lGp0UqK1HCsOZ6qNmnQ==",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 318,
                    Question = "ixhtfNoHP5TWWbi7D9CYnL5ATgXb1ZoQE34qfIfK/QtOUaNczqCy9SmGartGGo5c",
                    AnswerHash = -1417411298,
                    RawAnswerCount = 28,
                    RawAnswer = "98dHpyt288BpJ8sKI0DC/xAS8HbJGuLDdRtgLnNrOWDehFY57/rPV1WJk48KGyiCpfITH8BzO1HxqKiyfJz1nK0nbVJv0XGioRaGIJ0X+nP8wpyWpW4VW1RnZnZyS3ctXBSCBPxJCKLS2KlYwnaQIXcUKHLbSUb303I2MbRzB2T/NOrQ4IWLR5mxUbi4U6fq2knAJIyvq/+ydGcVNeRPiugVHtSaXDuQe0H4mGo/T0w=",
                    WrongAnswers = null,
                    Passage = "John 1:3-4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 319,
                    Question = "ehdh+JNUhlK6TqHYhp56tFvXwFT0I4eOdTZtj+nyf/CW+AcP0JCUA+pXgpG9bevSzq4hM8oOCR+W4zM898Msmaq08fvs6DocDcry3k20F4c4BKCSxH2W+QqS8+V0OBcL",
                    AnswerHash = 2065748517,
                    RawAnswerCount = 1,
                    RawAnswer = "Y+45oVS1eKrwqLdFRsqqJA==",
                    WrongAnswers = new List<string> {
                        "H90hfYAS4gbxgXi29jl4tw==",
                        "eN1CL2DOrYdSGfQWWyEpkg==",
                        "mPK3mkQqa7KjgZ0fEMbzpQ==",
                        "nUuG0qOuDJcMYq23dw1I7A==",
                        "0uJADAO+flpt4qod3T23ng==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 320,
                    Question = "k+E2Qmx1291NLUNHL07UUlmp401qZY94sBfAgFXqtlJNww7RT9s+FdEi3jQkeDRp",
                    AnswerHash = 1672212649,
                    RawAnswerCount = 12,
                    RawAnswer = "mSUNDe1xdqoehbMbj92BQ/IPyKOhqcRZhmPVP1MBfhmdVboVCmtP/IRkBlXa36f+mIzjd0KhendIIbXuiEFnnR1Pw+fj4qnD3GzN8ZJJWd8=",
                    WrongAnswers = null,
                    Passage = "Genesis 3:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 321,
                    Question = "tFkOBSvnmvJedjGoTYBBx6U28NCdeJHuVpJTv1yNSJ1wN5flVG9cIhiVbs+A48Tspu+T99A7527WYo94rwhpvQ==",
                    AnswerHash = 1002674931,
                    RawAnswerCount = 9,
                    RawAnswer = "Jy6TK/pAcaTCa7YkxN3AUjzNsWRbmn3bS/TKzzVEyCrOIX3WQ99i+UdpeoHHBxvGkOFJTrLa3EBn7gSq6Kvp1Q2LCTnPRQajNmVr9U4zAdg=",
                    WrongAnswers = null,
                    Passage = "John 12:31; Colossians 2:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 322,
                    Question = "CtMMiNfIjVt6eyZcutAJjsFUnKR5S0GFHUOh3GoCCv1r1DZl9AzvcPnNE0nIgM2B",
                    AnswerHash = 647690064,
                    RawAnswerCount = 13,
                    RawAnswer = "FSZixnd+ciaj5MUIWNgbQZJeVV0IksxxQYBn//U79PDVDsU5mGoAmgwBvJ/kZbyLrCBk5NgbYJF3nx6VJGP6AibsNdqrH/dBnI0Vff0jd65wn3eX0Sq1r8fRJcdp0pkI",
                    WrongAnswers = null,
                    Passage = "Genesis 12:3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 323,
                    Question = "hoo9iBamFP5RKuK1dF/qK/c6BA4BTrsIyGsUTBTnIk36DvEKRfEeC0XlLy42Y5KucZbADeD0WFPBz1fEU+REMZAyWRu7ADbFOdGXT5hb7svNflEsge0XfQnl+uQ7/vXw",
                    AnswerHash = -741469652,
                    RawAnswerCount = 1,
                    RawAnswer = "cB2R82TkMzL27JvWv78+MA==",
                    WrongAnswers = new List<string> {
                        "Fr5+pPjJ5Lb9uIx1qlXboQ==",
                        "96CI9QM1mQlgg1xD96gtJw==",
                        "3Sk5WWpTNAQxASTQRxcMQg==",
                        "pPECgtSF03ZweNuHNqYTBg==",
                        "r4c/c97gyuYwxKo8dfdgVg==",
                    },
                    Passage = "Galatians 3:16",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 324,
                    Question = "IwU6CbRjuuE+WGfaK/kZaF+3sjnOis5O5lZ6OXVRioKaT7U92tw3wOczfI5BBFwT",
                    AnswerHash = 700027102,
                    RawAnswerCount = 9,
                    RawAnswer = "tpMl8F5Lwr0o8xUayRqYz7CNpjk6iGPza7nGN9usB5ioImH+UnjVXuKQiuFxN8Zu",
                    WrongAnswers = null,
                    Passage = "John 1:1,2,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 325,
                    Question = "4d9RzLP2bDHS+0q6PKjZx59z/rw3uf1qFer/PbcMVapy6B47xx+lLrkOtPBryUqvTW75b6PsgTipbespnXkyWg==",
                    AnswerHash = -1725193238,
                    RawAnswerCount = 21,
                    RawAnswer = "jZComP0EoW6enfLRsP+MjQ3Jcr9vcJ4Zeggf6WlR7pUmyfV3vtbcdPPUn4ZiGhkfF36G5nyjqaZ9FFmVyIMJXm0p4UwSyYCLJYLY4jfWAt4zic1yW3r5jESj40MyHha4OBjNNxP+at5xsn6ZWgJQow==",
                    WrongAnswers = null,
                    Passage = "John 10:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 326,
                    Question = "J03DBLzhd3pf4+UiYIwgxpQYy9FhPExhltZ8oZ0kNL7UdoboXq69l/P22M7UqovTDiXMPxPSNMGtH5AfWCpdFA==",
                    AnswerHash = 1689973751,
                    RawAnswerCount = 14,
                    RawAnswer = "wewI25vFk//7ADSBdDvVZSa8tSw6yv+YM8WYghM1EgAkE0d8yh2mhxsE81I/o7+d1cXf6kU87Uxy0k9ycBARYQ==",
                    WrongAnswers = null,
                    Passage = "Luke 19:10",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 327,
                    Question = "6lVRLX1NRftUo6z5D2gz4Zz/4WfMV0TrcqcCzRkeRd8GbIhjDDVpzGzHXDUKfg9dl2PbUItXs9cu4ih1+vwerA==",
                    AnswerHash = -476987836,
                    RawAnswerCount = 4,
                    RawAnswer = "k+Ol6axtQSTJrEALtrhHKk6vGgj117/9CVN8sR0NsIA=",
                    WrongAnswers = null,
                    Passage = "Matthew 4:4-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 328,
                    Question = "wQbboDxgArU2oNfjytU4q43EAMiPLf5dnriPCgtYyswD+JiaLORy1i0dIlwrRkdC+UioQBUIoZA8SGiE0M795g==",
                    AnswerHash = -707998198,
                    RawAnswerCount = 20,
                    RawAnswer = "bL6EkoM+4Z16GLle/DrUQAm8MKgrpX4ccmG25LM/HhPXn5WH7CnfzL2SxWvKUeaE1v2dZ4jqNqjh9Ye4RHWFoOnBwAedRFTbJL+c75xfHB9/Go26ibtSPzrKLhRsmXaIvihZ2SF+0CAIhUmIR+nJxgQhDOZmEhqOp7ssmkwX54Y=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:23; John 1:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 329,
                    Question = "Bgj/q2XHwI9SAl3Ueh8b2z2y3XPxOYQGUZo10Md5kdqzefH41xjSLnL/CukMXRFvr2ymJc8rZ29qy7vUnpilDA==",
                    AnswerHash = -1242070332,
                    RawAnswerCount = 9,
                    RawAnswer = "QCpYpPWrrZFxythukH3h/MDgyMgUyExcIJduRUSDUkZLtNlgPwHIgsEjtRx8oVXCXb+j2miUKvU0AmTQhgP8pw==",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 330,
                    Question = "/FsYU+pBS6guUS71IfyqSA+cI7MNlB3svWbyu0nL+VFTYszYaSBBpS3QylAJCILS",
                    AnswerHash = 220044599,
                    RawAnswerCount = 5,
                    RawAnswer = "InPjL7rzkl+9WghTa0mlGA6zNIpe8D+MAK65z2fLNbU=",
                    WrongAnswers = null,
                    Passage = "Matthew 1:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 331,
                    Question = "/FsYU+pBS6guUS71IfyqSGeShXga0vpWDcMOXKvdIyRPvjdI+EYyZx4iPipFDHrs",
                    AnswerHash = 1685778160,
                    RawAnswerCount = 5,
                    RawAnswer = "UgwjM7/2BhfW4iugw3WFVfHsIBkf0chLLAgAbxB8Gko=",
                    WrongAnswers = null,
                    Passage = "Psalm 2:2; Acts 4:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 332,
                    Question = "/+rx6e5/zKBU3WZ3vZHtAzysgUm6mbq5fKDF/6K7utY=",
                    AnswerHash = 1391435805,
                    RawAnswerCount = 6,
                    RawAnswer = "brzif/tQCwyMgdmOeNts97u5MwvMZAMd1hgNKjxdWY4=",
                    WrongAnswers = null,
                    Passage = "Acts 10:38",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 333,
                    Question = "9sf8G0gQv50QnG8lGK28z0B06JPpiysxEf1OJFhaYApx5w6Tj3ZD9QhT3h123iQSDKsOt9jPEJwF6GrDaNAxFg==",
                    AnswerHash = 862036230,
                    RawAnswerCount = 1,
                    RawAnswer = "+Byq+JaCbCgH8XJLDT9SWw==",
                    WrongAnswers = new List<string> {
                        "ftgiMKzGJA3HkVOwlAcSPw==",
                        "g6Vzz85ToZ2cK6rpEPtqJA==",
                        "hNy7Tq0iSssXtf0WUXMEvA==",
                        "jcZCSB5MTX9NIjwkhkjdVw==",
                    },
                    Passage = "John 1:41",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 334,
                    Question = "t1mfAVLTw/VRreWUzevZT0iRpu68LBFwJZqgZFxKf/p/A3Tmhke2k/VZH7PMhYvi27XQ6axdceAiDNrN86+ucw==",
                    AnswerHash = -1937712170,
                    RawAnswerCount = 19,
                    RawAnswer = "GcG1MuL01Jjy+noIMRoFSLBRbXN5F0rQV3TEYmj69P6Kf8TNsS+Gv4dhpUXILADTTNfwQF4rSOQ5vyrHua/98F+LWOulwInyl955gk6igFzaGWCkRDZullWm61dsCC0W",
                    WrongAnswers = null,
                    Passage = "Acts 1:5",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 335,
                    Question = "FsBoFh7FDLWJEdW6BlgVv9gXRU8GOxkdYEs9yAo//xui6BPsZuJKhRXBtw3TO6kbyrvO/3SuVYZfBA0eKPzPlILrGDZGp8nX3AZH/q772zC4duoSoy3ZfCdTbR6aywONU2NSK3ic1OSOK46BdB2xuA==",
                    AnswerHash = -1091107967,
                    RawAnswerCount = 1,
                    RawAnswer = "lJ6vMQIrqkMM47AGBiAt9/ZaKkfSQeoRPIi6MSD1ffc=",
                    WrongAnswers = new List<string> {
                        "V08MPthvgLVI3ydKZbH9wg==",
                        "8dwrBLN6qtmCwBA/W3/HWw==",
                        "c/HbVmLaPpSt1bjuerq39A==",
                        "fNB3uUHpDT3hkjZ8tSVH8Q==",
                    },
                    Passage = "John 10:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 336,
                    Question = "GMYTBBxm1HZAjMDZGNsgAkbv4gr2B+DfGqhXzZiWeKzR4zv2sfIAdy3XWoBxcjCMGiIItIkRkCHveFJA5ZkeQe55uI5Z528ooTOr93wEB9TP9W9VDC61LzUClbiqiFWA",
                    AnswerHash = 1729163002,
                    RawAnswerCount = 27,
                    RawAnswer = "XghnTMyHok25iS7BeTgEF+a+dJbYrVgFGTWqijNt0T6YU+FIP66BTyul2ANZpPiHTKJ7bPtC9RgXJK7hFw1QIRJ46wYIQWrrnfbnCrFu52Letfq+1FdTmtqa6sI0e0cfNnQynPV9XukVdQMf4a5FwWAu/5v6rmzEhGUAHPkQxvVpaiK1AwEvavipOhXPMmJL",
                    WrongAnswers = null,
                    Passage = "Hebrews 4:14,15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 337,
                    Question = "o8qpWmx7g7tZvac9YYX2QD6iftZpIsbCcsoVxxn4UqSkASEkMek4oi+cvH4plSDV",
                    AnswerHash = 256139125,
                    RawAnswerCount = 14,
                    RawAnswer = "iRR1GRa7nVmDy8UNUXPk+KKBvs2ijxMDYd1JmeTUoiZtZu8Ti0+rW9q6a0NZRKBnJWRC1YA4eCFusC/4+C5wWLzKstmSgxs2XtQOZfOUa7Y=",
                    WrongAnswers = null,
                    Passage = "Romans 1:4; John 8:28",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 338,
                    Question = "13TUjoM4VcAZ0ADTSnqNiaUN7ViE0jKAXjz3KGIVp16TlOQpv4NqVmLGdHc3ouqKUFn32j3+0VnyuFObxhf3BX9vl2yLTnl6wPjqfabaVQQ=",
                    AnswerHash = -1578460993,
                    RawAnswerCount = 12,
                    RawAnswer = "gKcQLUS7UER015KkSmygcW7GKtoGoSRQNPWjVdOJH5Qt+g0e0UnQa4P1gwiFjkqR2isBeaIwvG6s/tdxlV9HhA==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 339,
                    Question = "51ipXsUwPj3CQ9vTK/TF8dcwH3r3Z8DbEq8Kti+disTF57v7qmnd78f3k/3CMcS6JlC9RRZMDz1hyScWD2wHeHGgT0hCEc8mFyIipG6VbGE=",
                    AnswerHash = -336745014,
                    RawAnswerCount = 1,
                    RawAnswer = "816+IbpSTSEjeo++yL/5Aw==",
                    WrongAnswers = new List<string> {
                        "FallOZpensElrciCT9Y7LQ==",
                        "fVTwdVMWorCrZc69MKXtRQ==",
                        "nUuG0qOuDJcMYq23dw1I7A==",
                        "C7i7ZKAd/o0JSFT9u9u10g==",
                        "sCA9GFcWEVZmk4rPXIhVsQ==",
                    },
                    Passage = "1 Corinthians 15:6",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 340,
                    Question = "xelE9bP6l4Su+2m7VFJyCkHYk8jUesqJ5RdMtGmG197itnzijVtzOzhZ0CFcYp1pgcLjiLeTb9A1Eu2FGYdXgjPgnppVvGEH8wUlgXkz2LI=",
                    AnswerHash = -1518347267,
                    RawAnswerCount = 1,
                    RawAnswer = "UmDasJq+AAGik9kWdTIrbA==",
                    WrongAnswers = new List<string> {
                        "4pUjURd1Z8Y6L7H+ro7ZSw==",
                        "lSABuwsA537JAg2G3sGV4A==",
                        "K+MvgGBQ23RVdMtj7Nkbow==",
                        "ZtMmGIifw674wdgHyp9uRQ==",
                        "wErEHQxiKL/pcOdVC4Yu8A==",
                    },
                    Passage = "Acts 1:1-3",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 341,
                    Question = "spfgMFVdvYXHMa1qfi7boUZ4SEu8gMBFyLbRYix/J5r2loY3o7voJL0DNMgSvwnN",
                    AnswerHash = 2114125596,
                    RawAnswerCount = 13,
                    RawAnswer = "zSr/A4BEdlQ8uBNyVPjqSG7tfeWGCDoVVPmJMN99K27P0nhiLVGUANL5B3xC/73VniD631rQoPR6uJGLD/7fZIcuTqohKR4BDE9M3EDnZms=",
                    WrongAnswers = null,
                    Passage = "Mark 16:19; Romans 8:34; Hebrews 7:25; 1 John 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 342,
                    Question = "8qTde5/nNZG+YAHO8iFd4Vlu3v39PWP6iu1h/bUYVbK9WmiT1vTrsaxMw++QQUauY22xo150MIhMZfDqJsddrw==",
                    AnswerHash = -658900504,
                    RawAnswerCount = 17,
                    RawAnswer = "DtOIyHPTAlClyVD4c/mJqiRf5rYxK3Xoo4z3pvNehDFHDNw+yT+McNRLJiA8G6PpcBrTRMH3oPO0NMs1dLxTdxiQWp+FQmi6QfHorWZNRnz6HRKf0PLEiAPx+Ym97oR0",
                    WrongAnswers = null,
                    Passage = "Revelation 22:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 343,
                    Question = "JZj7Xt9ps8ZP+aBz+2oildFq3mghIF3Yd5UcQYIQ2E0=",
                    AnswerHash = -840398386,
                    RawAnswerCount = 17,
                    RawAnswer = "ivsZvkBYjtseypZxk/1nnyRvvM5YJTadxg7tyYmfnG7s7FL6zHZdljNv3RJ9PCJVIOi65Pq8P6KBin9DZc1VKIJ3JCF5KAnU/caLneYqd5n8T2RA4j6pwqHwwJ4Qc2wh",
                    WrongAnswers = null,
                    Passage = "Genesis 2:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 344,
                    Question = "JZj7Xt9ps8ZP+aBz+2oilax7mZQ9AcPCfoTJ1mdAHzs=",
                    AnswerHash = -334007415,
                    RawAnswerCount = 11,
                    RawAnswer = "Pkh0ZoEh2bvf/5tJHkHb/DnkxopX9vppcM505s3XABkQQMQjbCkkI9W/EFReKLRC",
                    WrongAnswers = null,
                    Passage = "Genesis 2:21,22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 345,
                    Question = "whjOrgzGesWxIxNOSfad1a54APJBTp/6BXSCwS42PL7K91v81GBYhyH4qRgIzVj4",
                    AnswerHash = -1254025576,
                    RawAnswerCount = 19,
                    RawAnswer = "bY5f34G+KeFWDpEe7ICWsq+qM5t2hunaTldf+D4nSDl59TGiIVqqNGcfEstxRB1ZWDEsI8MDDhOJX6W31sn3vQngZNJsWOySVyKsqJqjq7+5fK/u3JTqLuY0ZUGgCRwVc6vb6q/YXJXf2l87WfzvYQ==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 346,
                    Question = "qAWx1LKkrMUiJKIfM0ZKeg5qafiDSAp88GcQd94RFJNpXdzFWYptIykgby9bjcNLAbs1Zf2gxIhsTu3oEONMHw==",
                    AnswerHash = 742528177,
                    RawAnswerCount = 9,
                    RawAnswer = "am4NIo5dpJgT3PPMxTurR+AOpPHqbErnkT/U8HoxJF+ZyQ4aQaLmiheI6dDGOdUUX9p+RnIXEVezeQcPNDFGrA==",
                    WrongAnswers = null,
                    Passage = "Genesis 3:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 347,
                    Question = "vIu+PvnDyBdLvpQ/7qRXAhpmyr7WJM/HoKAB2FlGC+JPNfL68RfXGWK+ouRtvdAH",
                    AnswerHash = -234510621,
                    RawAnswerCount = 19,
                    RawAnswer = "nNMdmyck2yVyNSIy6jEm4Uxh6Uj79YJiIfgq8eN975Co+Kji+q69be9F5hV0CniOafE/YyphH8l5uR8NTCEYy5Lmd+phqkf+qGRAGkBh0g/HmsV6G9DGN8axGo+XcGU4",
                    WrongAnswers = null,
                    Passage = "Romans 5:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 348,
                    Question = "fMHRSQt4zxD+yEA8FqO8bCQPW7qv67QjfPjVn6G/Y5FgLpQ6/hu/L7Zy4n++uQfAs1QgtiBFUA7DI7YctuAAJg==",
                    AnswerHash = -547799495,
                    RawAnswerCount = 15,
                    RawAnswer = "UVI04wVK9+AhPERzVzPr1NujXYih4nEfvD3pdvxXEXrKNZ9jpwPZcTVHIi+IOPgr9eCoBngeovJiB6xp4HR4LCKpWm4rLj/97hxfLbWWul7XfD6rbZ305mwMl+e5jiIk",
                    WrongAnswers = null,
                    Passage = "Hebrews 5:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 349,
                    Question = "krcmpLjq0eYgnDAmmiFcO2zxsjajtFXh7PmMTdH3QYSQ/s1WiOVi6BYk0WBedj9B",
                    AnswerHash = 1148898770,
                    RawAnswerCount = 13,
                    RawAnswer = "MbrfHiOTGG3MEf/VUd88OVsv/of09S8T/I2YqWSmVrL+NwDkuNDILAouTUONqVbpmf/1kn6hc8ZXkRErrfjNYA==",
                    WrongAnswers = null,
                    Passage = "1 John 3:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 350,
                    Question = "q6WOVErUdiF1UKh89R4SGRUxR1n1srldq65KH70sK2mYSg67zFV/XiBZ/lwhrRub",
                    AnswerHash = -1669678520,
                    RawAnswerCount = 10,
                    RawAnswer = "CvfQaT1hApUcYaPnpK/qZph71Ip4SxGbRb10uFHEXGM0LXz/bvJE6dyMyLQYG8K5",
                    WrongAnswers = null,
                    Passage = "James 4:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 351,
                    Question = "9hXnYBWNWCVStSfUUmzbjWdlNYPp7hNqF7yAPZJFgDE=",
                    AnswerHash = 1071765623,
                    RawAnswerCount = 12,
                    RawAnswer = "xUxPP3DE5EvNxzO1Fv8DAc5FIax6Alw4HCLpeTk12ooDtXzwkUvG28H3wnngsuZuKJA21s9HSSZRo9DKzyphGhkZdV5vLKA0Y9T88jiNrdQ=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 352,
                    Question = "9kXCq9KeGfswWIesWpcP5+msrzMjS8GJxHtxhafLGPnUw2T78BtXDzGE20yScvJVz/hyhkhEZy4nN25jzwajtubGe+rRr+AUc4xDV2GfuO4L4CiZtU8vqqpH7JIGEyCZBAV+J/gwGQ0HPF+vN3nb4w==",
                    AnswerHash = 22651851,
                    RawAnswerCount = 11,
                    RawAnswer = "F4WEL7NGOvUB1F4tVTbwy36bYEDqP3b2rYhbsOH7foDWX6cd3XKDINPPVcZn39Vis2WfmHJXXoF/zGUv5tlYsYM9pbk/jNsN27lu+m5wicg=",
                    WrongAnswers = null,
                    Passage = "Romans 3:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 353,
                    Question = "DGG9S0pJbtlU667fXc+DY7rkMwJsB0GoQFabpDnm8C4v1N7eVwwVcYA4/pJcjrPPLRMJlCyF2sFBU9q430Qm8luUuBFvIQ0F+nx8fbpu8SVTBX8Ono0PLjOH2tKPItmv",
                    AnswerHash = 1031965179,
                    RawAnswerCount = 9,
                    RawAnswer = "6tbYW0KBUW0eG5rNAKZgDgQKGCg9cy4M7ykNEKDyRkgJAvWRCvB9I5bexAh5Y7vr",
                    WrongAnswers = null,
                    Passage = "Romans 8:31,32",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 354,
                    Question = "yNetPfpNLMztoHNib1rvaiW2mU8pfnN4uShj3nh+rcGmfLs3PR/fJAtxbwXZyjSTEH41OjJWU91HBwwXfjzLwsHLp6juuXWsAKAk2BXOj5g1QH6NXcGSJgBcZ/t+M+KZ",
                    AnswerHash = 1955024048,
                    RawAnswerCount = 20,
                    RawAnswer = "O+8MK6nfAxC7uvd0Q526xf5yiwuXd6nuuTp8tU1gQ9d1sB1HqQS+wNiT9uuwPn+6jTnFsJJJoLaLMzUmtbnGwY3ywPIdy1Yw+KmetC7HITbJmB6ZlNDNrgKx9AH6qTNdMspHcJGTWVCLXroet2rj4Q==",
                    WrongAnswers = null,
                    Passage = "Romans 5:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 355,
                    Question = "pIO5URjBA4PWJ1Vi9T54BcoYIxJKH3UvG0rnDlG7aNWQsT5+85SeMjtzLRzK+cETRVZDv9MqWAxZuJWQfvfSbJjyz9dv17+U72dFRjExneYncU7y7D6mOhlqu1nmqADX",
                    AnswerHash = -14674367,
                    RawAnswerCount = 17,
                    RawAnswer = "+QUJSlzlzbabcA4vmK5btB2eLDxRYy/cvF490ktsfl7FKi82SC0Trbi0pt+C7dhnOoUBPuh4P9fii7NsXM21evwtoLsKMOCTshZ5N28Hrh+MR1bd7KwQcvyb9b0oYlr/",
                    WrongAnswers = null,
                    Passage = "John 3:3",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 356,
                    Question = "fcZP2qWkh29ZTbj/98TDMR7VV9h2h8bfZn3fjPpCscNMJsf7vNWl7yNKIIhqiVCf",
                    AnswerHash = 1024096819,
                    RawAnswerCount = 13,
                    RawAnswer = "dr7MSRdeMBeLEfQPxQcT4dnn4yul5i3f2hJRWA2vIwLEpg3Xje7OTFAlF+z+s3bEfpK+JfRfeM3kSucZfZOPq+vb7K/2bJ5PtC8QWcQDWJc=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:17; John 3:3-8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 357,
                    Question = "DwUS0m9mgFXwJqC7io5IV3n5RCAjC28uHTOlLpZhlVc9MO901NiVfLbBcRLG32nqs/YvIfPcvP7TGlWAzLi3VX72VxLnzZ/tt3bYQ/l2XgE=",
                    AnswerHash = -2132302046,
                    RawAnswerCount = 23,
                    RawAnswer = "RtkGP7kbtccJz/QYOs/TWEhTIuGrHtcdDISuo5MwJHNYtZAMQMU9W+jeW1xA1G+9zbA9QxBiu1kl9dzw375B4RpWIo26rAyz+edBWBYxk68epyDexj5H98mEhgO/MbsqWeDjh/uIKWufbZ8f0dPA7RZf/RXPc1bJxJPqd1OZd7A=",
                    WrongAnswers = null,
                    Passage = "Romans 12:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 358,
                    Question = "BtEFavQ/8HYeQTiTfUvo3f2ZQXCh+MY+khOeOKRKPyeCGRBzvvEe9hfjfNsgI5UW",
                    AnswerHash = 2044541378,
                    RawAnswerCount = 17,
                    RawAnswer = "dcRX1g8/ZMNA2smmm79N6KvvuCNfV4AutDEpYHWxGzLvXkY8WChSoKrECPnjuDg7aAdfoveUZazzIXkmuZpIAuRHQQxExkmtxZBB2X8fmoyBFgPDavPs1+EFmB1AlL7bjv+795DHfTgV4Isb7Bz6BA==",
                    WrongAnswers = null,
                    Passage = "Romans 10:9-13; 1 Timothy 2:4; 2 Peter 3:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 359,
                    Question = "0hTDR0chTybSR03DTTpLeC/A3wodcsE+NI6YqrhC4NQJm4jJR/Tj2T48kK3FEsti+5UMAwvSJBjFfLXRiY5jLA==",
                    AnswerHash = 1088041790,
                    RawAnswerCount = 10,
                    RawAnswer = "VJxPuWc5n5z2Ot6KDcYY1RgaaS2YHMD+3A0Fwgz9gxb/b9fY+D381PTXhfYv/Wgc1iR/RUI7duM38uZJ38pP/gT9V3QOILBErgdZunWhokg=",
                    WrongAnswers = null,
                    Passage = "Mark 3:29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 360,
                    Question = "PKL/VvezTi/MEQS7xcujibLDV/Zt1YKGl4q8+Sn9np2FFMw6UQoFxyPg5UnvvxO/DSg2V7ouVVtXYj+73B97Ig==",
                    AnswerHash = 264352728,
                    RawAnswerCount = 10,
                    RawAnswer = "TJ2XUZ+7v9nvnF3gX4PBy7yhWORGPkx1xO1SqGwoOI0ptcZ6XPcd4fnRFHBSHTFksyCJcwmLnOb6Jav7SfmdZA==",
                    WrongAnswers = null,
                    Passage = "James 4:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 361,
                    Question = "4MYPV0CdCB1k83rfi/YYfJIe2KsyIO/UY3v+nIsqHuRQ8hfclpqFPgp+blOQpOBvTqVgS/RpEYEKkPJGt93wfohLTmj+2OUvczhCNufxUg/+PfqzzRiQR3AAeFnevCzf",
                    AnswerHash = -1784739269,
                    RawAnswerCount = 11,
                    RawAnswer = "K1ybTyH0HBQDC/vDbLR+a41K72mGmJ1h4kLrhQPnldrBGr79b0DnNwpkjUAtHsPV",
                    WrongAnswers = null,
                    Passage = "Luke 18:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 362,
                    Question = "U3clUk2JZyrSCoYXZnu1Sl71MV0gwf2yiHx3NjnpG12f4FjJSToGmv0ymYRZ5DwYb9T3oGU/XQ2IbcJrTfwY1ffeAV6whG+GiTNo5RXk54k=",
                    AnswerHash = -813392955,
                    RawAnswerCount = 21,
                    RawAnswer = "eze8SyPNLwvE0YdElASk+8BLOdkzPgCu0TrNMnPr+QjyCBHaeNyph4SD6Z9XGJ+sv4wgBowMwqVAXyKJwDp4WyRLI3xyzke8GOVfXEccu/Um8kkdehwPjFE7iOGnaggaNlhDm6wMetECUD2jVZpmRw==",
                    WrongAnswers = null,
                    Passage = " Luke 15:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 363,
                    Question = "13TUjoM4VcAZ0ADTSnqNiesmlgaerjB6MmYsrvXI616Q7mkjRWivzWZ7YKs2GXBoE1bup8qP1JsneZchx9AH8g==",
                    AnswerHash = -951792044,
                    RawAnswerCount = 11,
                    RawAnswer = "p/QX9eV/DSbDugqGAON1JjpdJUzJ6cUGz0LIB3pz7BkyuU/ywplxeAGPJMC1ZXYIUdhrGrwuE6kCJMLR77zcug==",
                    WrongAnswers = null,
                    Passage = "Hebrews 9:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 364,
                    Question = "vIu+PvnDyBdLvpQ/7qRXAhvnJGxmQWSDZ2HtlIjTSIF65wWTfqcpP1wegoUXYTN/",
                    AnswerHash = -588338358,
                    RawAnswerCount = 29,
                    RawAnswer = "acf3LSu2z2UVkEwwz4ZDKwF9wkbGuHQ21PgBZamYQxGHYsS0w8XiP6z9oMqpW12NeliXvQ5xjdrrEBb0N3xq1IfQA/cZHVsdk33+PbIJAyaUFez2J8TS7ZAuGYluz5G/Wb+PbAXCkCiDimclj+EeAJyLrmhAGWaOS2QWfkSRvZ+ushXS59BSE28VyjqwFsjM",
                    WrongAnswers = null,
                    Passage = "1 Peter 2:24",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 365,
                    Question = "yNetPfpNLMztoHNib1rvankAE0qGzK+TwQ8qCQsm0ilLPc5nHsqlLb3/72E4zG9Ge/2dFLWWYq6eNBhgwZRRUnNWGmNO7IZW3i7pjJ8GMBQ=",
                    AnswerHash = 1020895466,
                    RawAnswerCount = 23,
                    RawAnswer = "8ozvH4fcQIixYfATWj6GGEBeOJ5EEeYnBFuPUnx25+fYtHj8Yr5/1kk4+JzSmUw2tbvBusEp09QgJf0U6/XZ/6LXiiaiLRW3f5vaqJL/4niwD7E7dWAfphHHkpJB3tNh3iXkLgsFZPPbw8DjiGa43DwMuVx/zg3+t82kEm5FzvU=",
                    WrongAnswers = null,
                    Passage = "Romans 1:16",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 366,
                    Question = "yNetPfpNLMztoHNib1rvaptlPMgob7NPkpUshTfqUoPhP+jrAn6OEwngR9BV7L/iH0g8SdsCGJiHSyNNjHTXNNq/c8yh9pVVeDsBsQzA6QM=",
                    AnswerHash = -264152028,
                    RawAnswerCount = 22,
                    RawAnswer = "ozcsl64oEZ5wGL2q6wrFUb3sEXho7AV9++L47WW1E3daF8MFaNJj7910Ip4WrMaKdKFoY/juFNmp2FuiZAvgJzFHXWuZN87PAS71ZgDgFkPHTF0qYPqbHbgn27hNQ9R1oBPpsmoRk7WLMuE7TcTKhg==",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 367,
                    Question = "jxyjhWfGAWeKyeZMiMe4SbxCh3D0r4B6dC1ISlEMOPx7zMH6df9bMtL83j5B5bpo7eVJf1jaFtebfiYjaCl3eA==",
                    AnswerHash = 1171251824,
                    RawAnswerCount = 15,
                    RawAnswer = "oB1oo7q9Bsmkj0oPv5lqxn26a0lBPO+Ni9TLjsPbs0YF61rCcviW6SPXOdLarDf6rqGkbgyLY7ctryzoesDZSb63lnW/1QmYJJVXUQIK3W6iKGvPTPvIsgpZ3C68ujja",
                    WrongAnswers = null,
                    Passage = "Romans 8:15-17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 368,
                    Question = "6rj11gctXNn1xmSc8E/eWFdsrwJh3n0yfkUKBcHot5qxEAfNcB4UmZRzwUOZQJSTSviZScLSt/axSW5I/Q4vSI6hpUFD96jhr1Asv7l0E49WwvYCJe+ky1jVEEzKAAfJkFw5UsixXsuCdZqVcD92SQ==",
                    AnswerHash = -912725761,
                    RawAnswerCount = 14,
                    RawAnswer = "A8xf7ElPeKehPoH3HhWwYT8qPgWqqyGzdSTjpAyEMIN8JXHQyPV9eJbK5kLjj4TsBkPqW3f0sWF/6M2ETuC01fGNhlnqIsEQQlSSG2qLhUQ=",
                    WrongAnswers = null,
                    Passage = "Ephesians 2:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 369,
                    Question = "02duOlBzdkinjvsIHxMFH8/9Ndkkye8HgR7fOSqVNdviYO2wcHPxvmJStoXCg+e4",
                    AnswerHash = -1160668314,
                    RawAnswerCount = 18,
                    RawAnswer = "G7Q01KOcSAgCRzkvxa5vRoTTjeZ3O57QecWdHRPoyMhG5EuUXikpaZGzPDRSm2Qr9/L722Dmv+BscmrVPzD6q0WDT1XOZr9EZulO9dOrs7oLJnKa/b+payIZP7kxwSbq",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 13:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 370,
                    Question = "6972caM8tAYfr9MlS0GwVZnzFbjdLO9EeGiFlJPTJsuTi5fGR3DvXjKDoyZgfyBf8JF4EGnoEqxr6EtcInjrAE0aHriGTxBoeUmtsfce5+A=",
                    AnswerHash = -1924114511,
                    RawAnswerCount = 15,
                    RawAnswer = "AGUreyoT7mfDdfRSw0BY/5tHmI2WRWFBoD/v0yKlTOANmV0YOCYNpYZqZY6Zw3HFxkynHDHvFo3wotlDLEynoSlbVm9h75NzcuUyhu/kzvCbniP+0dh5XQYlSOqkxr+z",
                    WrongAnswers = null,
                    Passage = "Hebrews 11:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 371,
                    Question = "fCubKSpsKkuqN6XPM6wDn/AQPMcmxx5QQa6in8SuVntoZtkbOPjY8Wl0qMbmdcnWBVYg3iRC9QRWtt715TzwjqonIdm+TF2Xnis2cKfwoaA=",
                    AnswerHash = 1838397218,
                    RawAnswerCount = 21,
                    RawAnswer = "gLeyg0kcRWqIxgLkFGe9mF784FjMfRaPXj4egVq12W6urU6jLVk4lbnMcnd1iX98gyOV18DTG3jDvvtnD+TIWPqRMa+PJkxJ6o2mn2Q1GVAtJXMwQ+vhVIuHiub5gaTs5HloZUipQq39Ezs3lQ1aYw==",
                    WrongAnswers = null,
                    Passage = "Mark 12:30",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 372,
                    Question = "fCubKSpsKkuqN6XPM6wDnynIF1eX7J74UoDRbj378ZwnzHn/FjmA+PUgqVr65sGhox8vwAjAie8+okwy2NyEmA==",
                    AnswerHash = 869807116,
                    RawAnswerCount = 5,
                    RawAnswer = "0bzhp6BHTPBhJW/BAXbpTLDwju2klJREvPJJSaYDcKY=",
                    WrongAnswers = null,
                    Passage = "Mark 12:31",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 373,
                    Question = "fCubKSpsKkuqN6XPM6wDn+ihuVc/sZu98FEY3pBRzKIEbD+XRQtgHl8VxN4cKh0/l2lBsxHC0V52tujx2jp5jQ==",
                    AnswerHash = 1706339713,
                    RawAnswerCount = 14,
                    RawAnswer = "K973EZhOMZzSsYdeHM64E/XTQ1egmunrac5HnXV/951VdibTPd742fcMieqH9BP56S5Bt8QBbgzfX0t5GmgYmFX3Bmr+0dNWnmaC1g32tpY=",
                    WrongAnswers = null,
                    Passage = "John 15:13",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 374,
                    Question = "t1mfAVLTw/VRreWUzevZT6Gwrvb8U3pcnr2fGTSMFxfQy4stnCwMSCMidVPGxCTk",
                    AnswerHash = 888101807,
                    RawAnswerCount = 7,
                    RawAnswer = "5VbO/p2KQR93LxGJqGrYE2gF+v8shu3BhYpuAB3k/DBrfNk5loMgLrPcaQTAONoi",
                    WrongAnswers = null,
                    Passage = "John 14:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 375,
                    Question = "fCubKSpsKkuqN6XPM6wDn/xVU97UzrGfjLL5Cjuy1eZyp3MC7A5NO5L+XpMHJjaaDP1QL1fjyUeiPbIjan9lY7KFkkDDuV5LUN2ioKlmZMI=",
                    AnswerHash = 455890727,
                    RawAnswerCount = 15,
                    RawAnswer = "IEIg+FpkUab7AafbL0/m/AhBmTdOBfueUgmAnf7ukW508nZG7/9k+8KjvYbmvJXmgeStc7C/xILkePCuxhTr9DC3++c1L9DJc17VCWiQQTg=",
                    WrongAnswers = null,
                    Passage = "John 13:35",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 376,
                    Question = "Sv5gGXWasNJhMHZ9qbHsbLcqZbuY+rtW7Lg+J/L0IRMGs9176cbolkEwtbnpAG2y",
                    AnswerHash = 1787009537,
                    RawAnswerCount = 25,
                    RawAnswer = "Z1sLOcy1w2nj7tn7gHuKDSyIRP8vL1kB4aP1tVp5nXg6xCV+GToJX94UTXb8VkfXVOII2n1zIE59WrIAfFlsp5RtjhEXkLPgwkEwuke5nYw3m2mrag6dxZic1Adcp8JC6mMY41AenTuCqRweqbOTptSIRtcv0hFJ+yndJ3uSvdc=",
                    WrongAnswers = null,
                    Passage = "1 John 4:7-8",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 377,
                    Question = "yNetPfpNLMztoHNib1rvaoQ0zxPHu3kgcGzg5coLO38wci4iKVS7Uat38/m79X9D181NUSm72C2DqxT4W4F6W3EG+2+h95aurIPswnWctMDC4EjTTOgbk04v4iTt1zTT",
                    AnswerHash = -1155973671,
                    RawAnswerCount = 25,
                    RawAnswer = "1Qr05t/A9SOaCA4gOBMYOa+9i9ZgGY062PGGVqAzBVe515KeeBGK/Cl5iZyNI7YM7ae3RaGdQknzxBdrIg7mbJiv8zbu1PgFaQDZDwbtsZvvlNDSA745KspvGvm202r4HPexF6f/tTPlljZL311Evig+xUA0dQk4/4Vjl4BkMYY=",
                    WrongAnswers = null,
                    Passage = "Hebrews 12:14",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 378,
                    Question = "b2VvmHApAsnlSbt26wXEwxUbcQRNWwt3fUg8dQOa2JCx1LNxx03PW+Z7e+PGknhz",
                    AnswerHash = 1543870320,
                    RawAnswerCount = 13,
                    RawAnswer = "31ZO4TYR+bOeI0r45cbgcnC7i6Y5309It0MnE4zfi7+C8tyWa3CybouAKENnuEXCTjNxitskjkbwSMcYUWMYB1th/btuPwBEK+S23qNIgrg=",
                    WrongAnswers = null,
                    Passage = "Proverbs 4:23-27; Matthew 12:34,35",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 379,
                    Question = "bcaz7/ErL0U5t1z5VFIJhpamWOMcAIujlvnWUFiCwqpIZzmQmz5hiOl45F4J4EOOe4PEfbHCWkyjc2uvFwrqmCzK5CazIrFMeVsGIBgWcLs=",
                    AnswerHash = 263255398,
                    RawAnswerCount = 13,
                    RawAnswer = "C0lfU4VqcwpYth5Zf3e1gSpKnLw5yZbO/TkjrXD5CDEx++f3OFEDnoSgQcM8QcZscP/Ljly7XYLyZ6AjbgN+E4LHDaMEBjsctws3vGBMKPjaoJXp1K3yHORg+eOVa1rw",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 6:18-20; Hebrews 13:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 380,
                    Question = "eOP+yabuJ4AX54Dbu/gk63ZvfS4qwItXoc0TFMCNH33B82Ap8Cmb3Nz5bNu3ZStd+Noa5AzJFGfG0kUuQKvSpg==",
                    AnswerHash = -806258790,
                    RawAnswerCount = 19,
                    RawAnswer = "OzEgIcR7M2mf11qj4eRQssA6KOFFeUWDM/WxpFvBa46pn9ZS3navEhTyvO2HXxeyIrAu4oxZD3oHS4M6gp/npFIgivx/CU7801eHRLKxBLUf4WeVex+Mm+pTMR/n+6UA9tUF9FnKz7HVcQHrgZ0G9Q==",
                    WrongAnswers = null,
                    Passage = "James 1:22",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 381,
                    Question = "l9N15Hn6PFHz6QqlWpw8/o6InO5BwX4e/bo9xHEspEQqRGP2AI1hc2Oo7sdBJnqP",
                    AnswerHash = 1603069035,
                    RawAnswerCount = 12,
                    RawAnswer = "P3quhFUp3KXbXDK3IcDU0eCK4aMGNaa5bTDvs2HGzKLUPqdGvr2G6Xww8nRapbwjOmw00mGcVObXIkb1BJFsbz3f+W4uIaM0skZ8o6jjfww=",
                    WrongAnswers = null,
                    Passage = "Acts 17:10-12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 382,
                    Question = "dVv6H7kj67bhgdp7V5WL9nM0J5egns+/oF/Wz3QxaqNCLPyVmYgXGj+NGldsXNOF9k59fGdsWqoQOkBYUU/PPGngkFHWVwt5hsuSSTgtLbYbekOGmU9PEN24ClxnY8by",
                    AnswerHash = -916705473,
                    RawAnswerCount = 17,
                    RawAnswer = "BWOySzvAmHJtgHDOfsdJ4XsGQJYP48DvBwjN7ykhNktQXvtF78BsX1Kr7odBJfKsgQpjglDYtM9Dn8ub8I9sQ/7XLc5QeuHXwvuqQUY8F7PmPNTOoVk2ETcQU6LMW6Ai",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:18",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 383,
                    Question = "xV+Yegw41iUFMAgIlKYbS0dJncAXvM+rkwXvt2WmtFaTaTkPed2mzsaD9ndQFk01r+ODqSEDwrG2hUWbVd7iWLGJFc83dNKbWTevtm1zmjs=",
                    AnswerHash = -423079110,
                    RawAnswerCount = 1,
                    RawAnswer = "rRoI/TbeRP8R22ba5qN1aQ==",
                    WrongAnswers = new List<string> {
                        "O7I4S13VhgchInJ03MlRaA==",
                        "GZRnk0RCxz1ZPJslS3bvDg==",
                        "o153gybGHmjyJ5BH/h85Zg==",
                        "qH9rK6/CD9yrDG5kQ1NJrA==",
                    },
                    Passage = "Ecclesiastes 12:1",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 384,
                    Question = "bY98/b9PJvnlN8rZcoI9YjIZ1mVfzoArshcatmXDrW2YAsvMglNxdV4WVemHU3bW",
                    AnswerHash = 606459507,
                    RawAnswerCount = 7,
                    RawAnswer = "pbc5+ipBmeIvTUFYwLjrXLU1hXmq31hwZ9aYoI6tZn9JUPamPEkvNkIzZ9xK0G+E4z+Sfi3vG6j3O7savOAIjQ==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 6:6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 385,
                    Question = "lQ8esqk1AORQHz1aOA40daMmB3uL85pEiUT8qHzkkmU=",
                    AnswerHash = -1791677909,
                    RawAnswerCount = 12,
                    RawAnswer = "c1UUb5XSxPrIqQpXpTlOLJHt6/KNz2oQ5NxaxlIo+7qr78NvRKk7cF2fH9U3dp4UBYQU6epIZGks2MeDNORlPA==",
                    WrongAnswers = null,
                    Passage = "Matthew 7:12",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 386,
                    Question = "yNetPfpNLMztoHNib1rvaskS6atBF6e+gkjsD+37A6zloGcWFu8V3JvjZ9VE5fLJXE/fxY8JggyXLkDbLzvR7STeLQR6J8En47yHNhPI6lg/NxbXLrJ6ttfN6+usYthcRLjWFSvLyiZXMuPoCcuWj17CSi0ZUfDAS3W+mSqYZsw=",
                    AnswerHash = 1427105568,
                    RawAnswerCount = 13,
                    RawAnswer = "dBlkdSpuPXQ962tacPLaoYnqNaDiIjDcm2wTa01qm/c6T6ijgtizTS7E04C+3cuRA3V0o4wRgooVO0Q6z5XtoyeHn3WUdRzQcnLnvxFfBks=",
                    WrongAnswers = null,
                    Passage = "Philippians 1:21",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 387,
                    Question = "cTcRTtdnawSOQvUTL97TgSMRwIJaRRMbNvt4Oi5bDVUa+HUmYuNLzjxGoUST1cj57Iz/I1FKZYtLQgtFCWL7Sf9tk/TwVpNou+Fm+4lkT+s=",
                    AnswerHash = 1299797442,
                    RawAnswerCount = 12,
                    RawAnswer = "K3C2KzvUWrldHD1ItrBRnmTDDZJQpKIsvO+G9CSVp/lkK9pE9ER+NhyB+ZAUwM3aUFRMlErfj4Xz1N+cbdlWt2ryJVD17+JSnnYy7RqFqMc=",
                    WrongAnswers = null,
                    Passage = "Proverbs 15:1",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 388,
                    Question = "DH1rqnHWv/zF9H8X0yzvSbp7TZ+ezlgu56Wpisd+SVOQ59k+INwVl8Mwo8aGNovMSLoIAdbJP9r1Jf3HLiqmrfGyODqsaMV2jb/xmTUg+O+DkUcRbCPgjwpGXqIUaZ2y",
                    AnswerHash = -886242780,
                    RawAnswerCount = 10,
                    RawAnswer = "1qRRF4rBS2FnFCbxU6cwI/83vYU0N2fWpKcEZnqKK8gyIClXq+EVO9ZgMfYfHM7NzlatPuyK3kUWc9izloJGIw==",
                    WrongAnswers = null,
                    Passage = "Romans 13:1,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 389,
                    Question = "DH1rqnHWv/zF9H8X0yzvSViUV9/iz874saSUIj+/dfHHGjahml+GnHMFOFYN9LwvVEdF2rvuVD8U9XixgyTfrDEboXzN46YW6LZIIeN/7+8EBhIXk5pJ72wbMZLDLi5A",
                    AnswerHash = 2035500640,
                    RawAnswerCount = 13,
                    RawAnswer = "1qRRF4rBS2FnFCbxU6cwIwdi+Rlwmv1fSJ2FnCDIphdf3hob9wF784OFezGQUyctyKBaZILlam0R/rj4OxZxjqo101LQ2ZNpFGKSs/4BLiw=",
                    WrongAnswers = null,
                    Passage = "Hebrews 13:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 390,
                    Question = "ztpMvqA77OfuKuHte6Cf7HOK0XMvXInpc6MMVRwINrM=",
                    AnswerHash = 728823363,
                    RawAnswerCount = 7,
                    RawAnswer = "1ele4ckOxmOQdNQgiyzjSNKwn8HovEyVsOd6SB4zEwg=",
                    WrongAnswers = null,
                    Passage = "1 Timothy 2:1",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 391,
                    Question = "qyp41267opxabaxrSmwsbjkYfBA47Upe0ZilDQZ4Rci0nAfiGgEvNAq24oLYv+n8",
                    AnswerHash = 123086639,
                    RawAnswerCount = 1,
                    RawAnswer = "9usIthw+TuYm4ZIfduZ56BXZB7H56WREq4D3JZXG7OU=",
                    WrongAnswers = new List<string> {
                        "rcUeTMl9wp/VfZng8372kQ==",
                        "PJKd8Uusn3HNKSDw51SFaw==",
                        "V7e8Em6UxiQjXdnGz7G8yQ==",
                        "IpzgwmT+Ud3x83Ru1r2LFQ==",
                    },
                    Passage = "Mark 16:19; Romans 8:26,27,34; Hebrews 7:25",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 392,
                    Question = "kFUuLIpuC8zliMgBz8lL/4Hhzo9cvOovxPXa3oCpcp6ykOxj5FTKrFu0c8EYhgCHdCxoOxpQKtn+5oHwLC4DPw==",
                    AnswerHash = -1021237799,
                    RawAnswerCount = 10,
                    RawAnswer = "e8060QeEev0UKD9nt3GWqpcJ91JXMs/iPcCXQbUfQB2PQz0BjN9AgCNJKVeitCgx",
                    WrongAnswers = null,
                    Passage = "Romans 8:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 393,
                    Question = "bcaz7/ErL0U5t1z5VFIJhv0WhAQeVFKh7YsBZyBbVd1G53kQtMZCFK2CL3OtZun3ZpA8Az6LIb4dp2GScneQ+Ema8FBSBu6WlikUUYHGlIg=",
                    AnswerHash = -848961657,
                    RawAnswerCount = 13,
                    RawAnswer = "XzvQQxIus220MRbQz7s5RUQ4pPAqFsygCV2SEZGTABi9Iqk798DATH3s3RadO6Y/3OFb6n1a2O2tuvdL8Egx5DBXUQBr/H35cIXYDE1T+I0=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 6:14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 394,
                    Question = "HY4+gXNx1JRs2jRZ61OM2AryesoboZ4F6SFdEz/VfCo=",
                    AnswerHash = 818932800,
                    RawAnswerCount = 10,
                    RawAnswer = "WgFQO2MvZyDB6Yfb5HxcICcIMdH4wS7uVxccU56XAoiq/tsP3Di/Pvbau31LVflH",
                    WrongAnswers = null,
                    Passage = "James 1:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 395,
                    Question = "dVv6H7kj67bhgdp7V5WL9vPksxtine2w47ribRXRf2TASZmecmNJ2MEL5+znxIpnxClJh3X9kQhmHa8r9l/d7g==",
                    AnswerHash = -1234575229,
                    RawAnswerCount = 15,
                    RawAnswer = "ZQ7PHU+fGRRNIuPbykI+FCQCJnUNVsULT6B8zsp4RdS9vmbZxIst6UKQKIc3W5pe89UXV8GD05z27cKhCfoW2yPldrnH9P6LmG9Ku7hopGd7dH4OhjxVU+Nu2kPBdH8A5s76SBZOJC8iAJydFFakfQ==",
                    WrongAnswers = null,
                    Passage = "1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 396,
                    Question = "02duOlBzdkinjvsIHxMFHyvijVQFFNg9p1Bq19676v/Q+kpW10Tgsa17mAdjXkvI",
                    AnswerHash = 4418941,
                    RawAnswerCount = 7,
                    RawAnswer = "2Nnb0g1bJX6yl3AWZcF0WD7OEX6Hpq+0pSIMHbRFnEqsysQ2XgEwTnWOIUSUkQdV",
                    WrongAnswers = null,
                    Passage = "Matthew 4:1; John 16:33; James 1:14; 1 John 2:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 397,
                    Question = "Tai7UHh+o6IKiCzJGpW9MCcEu21ewxnPDty89n81BgP1fJw+AY3q20iU4qosg1ZD",
                    AnswerHash = -2033779299,
                    RawAnswerCount = 11,
                    RawAnswer = "HcNaFz7nd/gkgNnpUaCzvyoGocpF+hw+VUDtIeCa3qSVhXL8X98OnRJI43Qgfe2VfPMFeL0XSUncb/JO5mM3Pg==",
                    WrongAnswers = null,
                    Passage = "Genesis 1:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 398,
                    Question = "I8QxjErLZtjWBXYSIgZMk82NDaIyvbsWQEpO8Z/PYMfL+XadpUrF8ibu0/Zi8wMLz1SrP1oIzc8fRDItSwomSt6U2m+r9Y3q96HcPmxKPHA3BL44HrtE39AQuJ2noNsU",
                    AnswerHash = -53193394,
                    RawAnswerCount = 1,
                    RawAnswer = "jCIFqPUanVPoUCerYnmirLlqWFzsKDXb7j178FltPJI=",
                    WrongAnswers = new List<string> {
                        "x33dCW36NgB9R0qmoQeJwUVgktW+KsZhUWNcVtwizxE=",
                        "MVBhRuGx3tiXsCYCfQ4xdWq4MW+raYSVd5Ru6cD4Yok=",
                        "aKQZSmU7c6AKmle9kBI7pi1+N560lu1Jy/M/Na9Jjjg=",
                        "gn1gsJKN1BuEJ8uQufD2r1dNd0QuE7IiuW1NYPUoA2U=",
                    },
                    Passage = "John 16:8-11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 399,
                    Question = "k1K/El6WJVaWZfYlW3DYluTPcdjeL5KGEBPkxNzCcyyrSrWBSV5vE8rgP8FT7KbkFO9ycy7IeIbuPpfjs3SUdA==",
                    AnswerHash = -651167650,
                    RawAnswerCount = 8,
                    RawAnswer = "E9NQl5AUpGXnu5lMYRzr3vwRQflE/qGmTq4pNCA4MxDN4xeZF+lVwaPF7t8hJzZM",
                    WrongAnswers = null,
                    Passage = "John 16:8,9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 400,
                    Question = "Koi8up5AwGlYppUk+0vCQTglmDvIb41LIa/Iu6yOgi9WIs/LrJrf8OrZqfeWkNAI",
                    AnswerHash = 684235471,
                    RawAnswerCount = 1,
                    RawAnswer = "WQfQZsNLNkhlpR0lIeUTtw==",
                    WrongAnswers = new List<string> {
                        "X3oW7b1K9DcK1YDmBDWUnw==",
                        "80+MvD+rHtYHeE7e1K27yg==",
                        "96CI9QM1mQlgg1xD96gtJw==",
                        "2Q1eD7Dy9TVs5yeeaiHiVw==",
                    },
                    Passage = "John 16:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 401,
                    Question = "0KKYi/lfQfMR3iOayXTCLmEMJ84W0tlqwD2jObvnjAgy6oKRcQfxEt7YHHgnJnnXRGKGnM0xkTZiWVFAJI36jB705H7Gc++AhalMpIVHVKk=",
                    AnswerHash = 1689374139,
                    RawAnswerCount = 19,
                    RawAnswer = "XD9pHvb6/Fk2F2DcDbcpPImPBBIE5xrfaiyjtCTnugV/WrjpZvUlWkLlw0OV1Gvs7XVwbGz9S6oPAoZgenRyteQs0GdXClmIy1ugqurWT+cy0O23zDGjD8Y+5VfXdpnDbJDQFjxlmrVc3AKudJRHMw==",
                    WrongAnswers = null,
                    Passage = "Galatians 5:22,23; Romans 8:5,6,13; Acts 1:8; Ephesians 1:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 402,
                    Question = "9usIthw+TuYm4ZIfduZ56ELo1G1HgdBXxxVTmoF4TW/p7P1o1BIVK3/UsvVpLK6Q",
                    AnswerHash = -164634854,
                    RawAnswerCount = 1,
                    RawAnswer = "ZpfK8B1xysePEwNPBMwMGQ==",
                    WrongAnswers = new List<string> {
                        "dv6IoGaMqhabsdZ01GSMxQ==",
                        "YUKlSCSAgxShS4G/h+PE6A==",
                        "15oZY3f3YAgTXz6AFdVPdg==",
                        "QZIGkjapoJMSBFThbWVLyw==",
                    },
                    Passage = "John 16:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 403,
                    Question = "cWXJ1b5P8M2GBizVtDJ8vrh3ic6THhuWqaNt6502o26XHyuwz1nyC9rEWN54uvz8jYQqlj+SW1CNgox0iunlIg==",
                    AnswerHash = -86445942,
                    RawAnswerCount = 14,
                    RawAnswer = "dr7MSRdeMBeLEfQPxQcT4VeSls0xFwzPwTX8tKJGdYZfGNjdjPokCuI0w6g0UYgv8CCJ6KToYH/J+OzPqzAnRdwKnKFp/lT1uzcnk5htk34=",
                    WrongAnswers = null,
                    Passage = "Titus 3:5; John 16:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 404,
                    Question = "30RXE01QO+oF1+nyiu2+23730rEFxRVLZcAmhXDiAR/SKfR4mtwFOY1xz/fS78+r",
                    AnswerHash = 1255643051,
                    RawAnswerCount = 13,
                    RawAnswer = "w/3rY9zWtx50xqhwJrd+BUoSfmUuVo4Mg4UC88MKC1o+ibCy8eXY0gbF7eHUYXrQLWkq9PTWkrhLGXIfFR1NNyI18n3GhAoIi1P17gQuQA4=",
                    WrongAnswers = null,
                    Passage = "Romans 8:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 405,
                    Question = "bY98/b9PJvnlN8rZcoI9YuXjIYMTq1OCGFY9o786RW413ALwGhPMugk0ki4SUu27cCYUUNsQDnBZnMNfXMdBPZR24+Rz0na+Diu0pCYjAuo=",
                    AnswerHash = 1547168428,
                    RawAnswerCount = 6,
                    RawAnswer = "6rlz+ujgYp+aa2re9Kye06wOGg1zUVYbDggMWqRWCI9FQ8huYaNa5NNJnc/bH5l1",
                    WrongAnswers = null,
                    Passage = "Ephesians 1:13,14",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 406,
                    Question = "Q25aDLczr+UfQu7BrUoFuFiQFMAp4sfi3/8pFFv2rZ+hsDmLbB2kb9OyXC4WSUFP4ZjF1cgQp4ql5Suv1SAzzw==",
                    AnswerHash = 1311866453,
                    RawAnswerCount = 8,
                    RawAnswer = "3zma9cFNct6IXzCb4rVgzmNMyxxDpOy1RSAWgL695FFHTcttIqEdt8N0DLQWcoyW",
                    WrongAnswers = null,
                    Passage = "John 16:7",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 407,
                    Question = "8ENtciJbTl55pT+UPfqByDAZzdni3BPb8c8LYQVyihKdxOBtLVJLUq/IKB/wQn+MYHIkLp2rrZCqeL+T4GAoVw==",
                    AnswerHash = -662738854,
                    RawAnswerCount = 15,
                    RawAnswer = "bMTqHmWvh+Ak72spjG4SkzcNgKRS870FWElKYT/L5cPJlQRdywRossqVFFHhsxgztZgEHtdrvVBMtz1EOsVk/PhLy43PBf0o7lJCfwq1low=",
                    WrongAnswers = null,
                    Passage = "Zechariah 4:6",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 408,
                    Question = "oqjsZoTcR18ZSgv5UWeWxG6QTTM2qemHR3f2PkDW3sBjsoVWhi1VQXTneHfnc98BYK03BKl2LBOF1/d0Lxy+Cg==",
                    AnswerHash = -947634508,
                    RawAnswerCount = 1,
                    RawAnswer = "jfI7P16sp4+UfEfpheU/sj8SfxsZJ94YUp+vU7r4lhU=",
                    WrongAnswers = new List<string> {
                        "3LwVaunxvctPuKP/kgi0PrSSOEc8oOEaYg6u1S/XMOU=",
                        "5Vg6YjKTHlUaDd8/xJGF2g==",
                        "tqIZNSmpFMpFOujOy2TTaA==",
                        "yQVh255OcSKE9Rps/dSZRA==",
                    },
                    Passage = "Acts 2:1-4",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 409,
                    Question = "yNetPfpNLMztoHNib1rvat/J3Zr6edaLu9TzWliUgQIRLVXlm/j2u+XN6YmEfx8yq8bX4fjJbez+EuT8I5ScLJ22kvQrUcvVjb8xJ0ULGoH5cj4pGqf3u4CI1mb6D669ibkYngffhfeZxNtjFJbN+xLVLttf81IeuvPEI4poFyA=",
                    AnswerHash = -1153377900,
                    RawAnswerCount = 23,
                    RawAnswer = "xWCURvVmH0HcPh7dwnnezUKT8BqFZ4HIMi9albVoZOR4trRh4uBhkenKIXkhP6XZmbevejk/5f40EjZU+M8EKqYDoPbFocMIma7kqF4BEgTVZilURSpeC5XO8inBrp7f8vfY9wKwjdbfB//8dj5Egs5oaCAKc8vyTMJGxw3XKfcSC6awGM8C+4870/WkuFsY",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 410,
                    Question = "hLg1WwVDNZlAEfVAbekvt+S+bqxewB70XPszCyqKDzbHoa5674cw4jixIwGsm/jYeUUBewTs6bfR3pra/AZn3fmdptnZ4wG81B4Td5Zgcb+8xt0GhxKxvPKdIOvOD0Lz",
                    AnswerHash = 783737934,
                    RawAnswerCount = 1,
                    RawAnswer = "nHXODUSzupnbzx6517jvnh45wPR/YdG6j3uj1wV6Dsg=",
                    WrongAnswers = new List<string> {
                        "hqUx4wuI36eZ5Lx8md2Y1ueRuFu7hLgIDViHnVm5f5s=",
                        "4obbCi2E2YxPa1N1UFifj5oDjZ31KlZXIx6pCda3pSc=",
                        "MyzIRYQMtxO5qKaZGK1YyrJjFBO7PDDIyrAmKXpFvCE=",
                        "YYKs2vbJ+viKwllsKxmJK12jsHT+/BHTykypo5NUl6k=",
                    },
                    Passage = "Acts 1:14",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 411,
                    Question = "GNblKR1SCIXF0x4Y+44U1I5BRq7HblXb6uB2gO06XTo860k/xx8JFO+QAPHiRWAlswI1KKe0XUZ00/71HR046X3y/fUkaJVPlPcia975h961kOdpaYUPghVCE37YU+yUMg2YsuKnptRN+WpFNmO1tw==",
                    AnswerHash = 1896776957,
                    RawAnswerCount = 37,
                    RawAnswer = "BfEbzHo7/1cBlx2qK6GdwXkbX1eZP9D8LZzKdEGeYZa8QcG7myivcapoqJLJLFWubn5ZBOhMf4v0BCPay7cChYT7ierJIhwVGmYkin3cEprQAwF5fGZDz0hQK5c2/OYvCaQFoHRosinNQrmFfxMsC8xcscMjED7Q4ewegM7euarD1vw03YfLjb1Hjd+DMBamkxynFnLEvlrJ6scUxivucQZQ36Qd/zb++XWdjbb7wwtShBdHhhING7zJlE6Nf2IJ",
                    WrongAnswers = null,
                    Passage = "Acts 2:38",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 412,
                    Question = "j8a5SYG2gglOzBCdxLr9vtwQyxP3JxyCgjQIQTpFKBL8szkqYuflWV7orB3KMsJV6PVOrsYl3r77UuOkqI6yxg==",
                    AnswerHash = 1979144082,
                    RawAnswerCount = 16,
                    RawAnswer = "ZU8GUjAx2FWjb/zuBGoXUL0vbiW+TRFHjU1KJDM4pdypv3HnF7qECFR30XX0N0PPbODTuGXQxf431zG0oRL+S/NjuYdopQFMby/P7ImMeYjT8/lPgShp7rcqIBwufDFKP/ogdhSPjenG+ZUcfUkyAw==",
                    WrongAnswers = null,
                    Passage = "Acts 19:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 413,
                    Question = "ZjPqhpEZLN8PQosbWFfWmZNROb6rwsXoeS7lONWmk2YfD3BJNiLpJHmnJFSG4aGtkyfC2xdnccIT7Jg6uwMeyQ==",
                    AnswerHash = -829007736,
                    RawAnswerCount = 20,
                    RawAnswer = "ocWq+SvJBszH3eLjWyEcXp299jL7foqiUMIed6DY45Hfjo3bN7NCg/uH9EcbLTOvrYoHDQFER0ScFBqs9idpQevUF1VxFFZ6Ylfq07bL0rK8z/52v8jQI+uOXRg4PFB++xctwK+MA1eLGNLfMqLmxA==",
                    WrongAnswers = null,
                    Passage = "John 15:26; 16:13; Acts 1:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 414,
                    Question = "EkdTw+hJSuu2dNYMCtqatC0/qQZJcwVtnvZUbcjz6mzcCGbDMqebkIsGvqi6FpGwZCiGY/hi0B3ycQsRaxf7RnGLahekKNI/oYOOqXc3pMw=",
                    AnswerHash = -34041518,
                    RawAnswerCount = 10,
                    RawAnswer = "QptYMaA8jKqckb19sMzc5HmiREXyMu72rXPYSycM3OO2y/158gOXrRvChSBYwg3TVEVnI/RypyeQRk25gX6sOmRJ/gfuPydS9plhx8NUD88=",
                    WrongAnswers = null,
                    Passage = "Acts 2:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 415,
                    Question = "GzzcC/hwb3bfbK9uuQ6X2JmwvdqjGyCAmRYl0BQsuBy+mrVMHXGD0IcTVOwLZT6sfH1mrk3hAYX5Z9U7WMnSFA85y9e8B0N+OPDr0nJeWzruhlG8AlZ3pSyT87wv3hQLBRF/O5mY+T+A8zBmWvJ1p3/Z6/u4m6iSIZIwzgJqMc0=",
                    AnswerHash = 2123149606,
                    RawAnswerCount = 10,
                    RawAnswer = "/FgM1GvbQK44bEvPLcmJ0hWcsZKIGGp4CYYPvsiHGyE//w8WAi0dDn9VJTrU8za0gSy7ggCAdpebKGfkvhNX4w==",
                    WrongAnswers = null,
                    Passage = "Acts 2:4; 8:14-21; 9:17; 10:46; 19:6; 1 Corinthians 14:18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 416,
                    Question = "8+M3PROv2UXgZVVe1uHLZBgqnch3K/GceLxa4MrydhM=",
                    AnswerHash = -1328177373,
                    RawAnswerCount = 26,
                    RawAnswer = "isNHTj7vSlAyF54bWf3zBS5NTCGP4GlX1k+q7Zot29/PXkIFBgNH1WvkS2d/D/fCnOlAmMk/+vRRep16kJz+dZDWunVDxEt7yaPRpqJE55rtKJqJi6VoSFkEdv+qfKnC+7z5+MUbqPARgscQxbHhbcS9lgAHgdVk70Y1dSbA2ii3cenz/6rq1FW40/zEKqnK",
                    WrongAnswers = null,
                    Passage = "Colossians 1:18-24; 1 Peter 2:9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 417,
                    Question = "LtxhkOU4Wi4XtDZDvu58WgU0t7mSOe3szWJ30vTJ7zNpTYj5Aw/00+qHI7iGzAP+PJj+pvMnqpxgYzPihkAPXA==",
                    AnswerHash = 714417360,
                    RawAnswerCount = 13,
                    RawAnswer = "eXStIxdSJAk2MYabmY2ODIE1cM+eRjaHrenL6oIEf5r0qYWNN3Cp/B3d9E5F2iRaVbmP17/pK/r/DncD4XJK2c0XyEqHvxVjpgdgAuiq2OM=",
                    WrongAnswers = null,
                    Passage = "Romans 14:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 418,
                    Question = "1Ml8YGlZ5QB6hsGU8+n2xF4uSnnXY+elFkuGEixHBiI=",
                    AnswerHash = 684235471,
                    RawAnswerCount = 1,
                    RawAnswer = "WQfQZsNLNkhlpR0lIeUTtw==",
                    WrongAnswers = new List<string> {
                        "80+MvD+rHtYHeE7e1K27yg==",
                        "96CI9QM1mQlgg1xD96gtJw==",
                        "JMweSxBYfz3J79N9NqoiEw==",
                        "X3oW7b1K9DcK1YDmBDWUnw==",
                    },
                    Passage = "Ephesians 4:15",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 419,
                    Question = "/SfmajtNBKADxq50tUQbplsxDGXOEnKlDEkx5dU06Texqai6PlMP79RSNvzDafJ0",
                    AnswerHash = 276172562,
                    RawAnswerCount = 1,
                    RawAnswer = "GAQdMpv8y0UTC3/3FBOEUg==",
                    WrongAnswers = new List<string> {
                        "Wga+QO7TCf9UWdFt51g5Pw==",
                        "96CI9QM1mQlgg1xD96gtJw==",
                        "80+MvD+rHtYHeE7e1K27yg==",
                        "JMweSxBYfz3J79N9NqoiEw==",
                    },
                    Passage = "1 Corinthians 3:11",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 420,
                    Question = "BDnQdwYYztckTg/Nhu7B+USD9lMwqDm70OvNMtBcM7gcqs/SjES9JZAEFtzM6EpqWCg0yQXm2kj6ycSSrB93+yDdYTAbmWbpzudKn3y4ET8=",
                    AnswerHash = 1911298529,
                    RawAnswerCount = 25,
                    RawAnswer = "Su2zFsAFwXWR76jLdFVCELcuZa9nzTvGrs1cnxrrKhgno7v7Yo2METS9CXybUx4Nd0SaIdvWwx0HFd/HFZJSd5AabuyQs/9Mag0ANDEAgtOIM5J1+nl17cKdp3uNYQ6UuQaUhksVJcM1EC8r6OKUUV5oATx+zqCdJ1aBAhi1omw=",
                    WrongAnswers = null,
                    Passage = "Jeremiah 1:4-5",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 421,
                    Question = "3CVCWb2Bq80KGKLGcMGJwzT94P650xo2VcPBaHBu6vHaV6kQicI2DwFqW+Vc+kFi8yAUZzs2nuuZzmDeD1yatAp4qRx0t2e3DCo1pRrPXgE=",
                    AnswerHash = -2064101349,
                    RawAnswerCount = 1,
                    RawAnswer = "GNN6v/f7iZtkb2Ho6tlvICSR/VIQZN8dSxJoLEblwco=",
                    WrongAnswers = new List<string> {
                        "jcNP/usYJYO/39XCU3+R9XAUxaAR+WCiXDm4baeaVMs=",
                        "yxeejrJrYD2kOLAJBqZGxh1W66ycCcgro6R9LXXhRg0=",
                        "0NXzucVotnigey8CQcmwssaqFMzd1iBGWFW6XSUNup0=",
                        "8KcENgro1bv+L9D+U8+041uU8wg+KDC+5HiJSohSpLI=",
                    },
                    Passage = "1 Corinthians 3:9; 2 Corinthians 11:2, Ephesians 2:16, 20-21; 5:25-27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 422,
                    Question = "cXdhpxV/IZkoXHMGIzLnM42so5bELRx5tgSu4OGMmc0=",
                    AnswerHash = 684235471,
                    RawAnswerCount = 1,
                    RawAnswer = "WQfQZsNLNkhlpR0lIeUTtw==",
                    WrongAnswers = new List<string> {
                        "96CI9QM1mQlgg1xD96gtJw==",
                        "8N3fYJXGMC7Avee1pGZ1KA==",
                        "HFG6Rd0tv1N5rzfirPhO8A==",
                        "j/ka8N4hsv1f1FZOtVXCaA==",
                    },
                    Passage = "Matthew 16:18",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 423,
                    Question = "MEGVQ2LVDzhHQPagCUbIN9uXmlJ8LXmrDj9O66YnfkQJcA88jDGKbulOPpB7oJPW",
                    AnswerHash = 1857112773,
                    RawAnswerCount = 21,
                    RawAnswer = "zYi2b8OQYSB1r5k5iNhRAboSRiUZ16czQDpTldJUKy0FaTMdzWXQluRPA6a0sH2BejcIIlP+JqaHH1jU3Cutnz3OVK2oLXK/0A5+tJ5HwjeW9gHlu6K2tfSYLoMVyXkdPpXuKcHVxpr4pHvjtE5XHQ==",
                    WrongAnswers = null,
                    Passage = "Matthew 18:19",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 424,
                    Question = "NppFKgqcGhWu6YId5voV+Jcf3JWTD92NzBeBUJSQsYbkeXFkzlPkF803qG24GCW4",
                    AnswerHash = 258956801,
                    RawAnswerCount = 12,
                    RawAnswer = "kMA1i1fccE/lCgeGxhzGp1n1dSmxRqdubxUXEvU6cF1LbATi3mFe1f0m+CrCFTobxpriCNpakemmNYWJxAyUGw==",
                    WrongAnswers = null,
                    Passage = "Mark 16:15",
                    Type = QuestionTypeEnum.QuotationQuestion
                },
                new RawQuestionInfo {
                    Number = 425,
                    Question = "uUG8hRdvOGDF3laJunOJZ05mUimKJTa4vjEeXyQKLlU8p5+iNOOtRByGRuMUGV0NiQ9fgWeS6vXdBJ/fU/I5/pKpuooFNfA28dMtkgemtes=",
                    AnswerHash = 1301430995,
                    RawAnswerCount = 1,
                    RawAnswer = "dgBxm3kqHpwIq6gSbkPxh4hxv+nThyvLxzxTzuf8tTU=",
                    WrongAnswers = new List<string> {
                        "Iwmry6mnKWiRZlGDtZPU5Gg/dhKiXzxez2tiNZuXl10=",
                        "0NuUviULlj8/PbHjmCgzUlJ8LaX0bkDtfic16oihn2E=",
                        "Gdd+IZDrv+btKEvzM33cnA==",
                        "kkk0C/V2f6GMs0s/TBVL3FBo+MeAiEMA08P6Qrkn/GQ=",
                    },
                    Passage = "Matthew 21:13",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 426,
                    Question = "Q59LDqNGGJx6veEgv5n2ECuT+iTHNWP2IxF3A4Ag4dTxFivuoTF2f/9PHPhR255A",
                    AnswerHash = 1405719504,
                    RawAnswerCount = 9,
                    RawAnswer = "H9NvhYfPX/Y4kZ2duN14TDSsb0E1pM8ulUXAwQtj9yM9n6PeqYN/zk4ojmKlPUzZ",
                    WrongAnswers = null,
                    Passage = "Ephesians 4:11-13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 427,
                    Question = "jK39/8VSboAuztXPmERszVQWKiQkdZlVsVlAcHOpNgYyfPa/cBGCLj3VY7rfg+uF",
                    AnswerHash = -1319559665,
                    RawAnswerCount = 20,
                    RawAnswer = "gYPovYwgPpjdPbDnRMC2pjpFBnOMmWXPujLwsg25U0tPQLsYkixpoAhGpARQBaxhW/fp67rc+YZ87aamgL9cySOU+3uDwLSC+gIPDzhpaLqsrIlF8EpQaW/tHjRHozCiPkRobHR0CISoSNHDpod9ZA==",
                    WrongAnswers = null,
                    Passage = "1 Timothy 1:12",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 428,
                    Question = "Fr9B6dy/p5aN6LipAYGqM99e/KwctJM1rLgj8igLOfsBlHt9f1LXw+yZssLMtiSO",
                    AnswerHash = 1601769507,
                    RawAnswerCount = 10,
                    RawAnswer = "YciqHTaKfGXcESKijAlTW8SQZry+x7eF6D9Tz0LWVoQwbpZnZTLXaATKrBX1MG2Rbn3uoeKLcDwMW2tONXy3dA==",
                    WrongAnswers = null,
                    Passage = "Malachi 3:10; 1 Corinthians 16:2",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 429,
                    Question = "zxbTlKYc0cf+pHxFY5rRJmCcpfHekknTju52pTx+hNw=",
                    AnswerHash = 2065175057,
                    RawAnswerCount = 19,
                    RawAnswer = "D03TpjPApru88j78V8nyswQ4azDOfuAIEVoVO38B7Fb4RztlvKFQSLwdhUS8TcQcSl0YgmBHRZcI8mLqA/Eyz/kbB7t2i9uD9RKp2qhCb/+c8RiKVyZyCrHkob7aFCprSv8OgVE3uAgfbEYVBV2Ldg==",
                    WrongAnswers = null,
                    Passage = "Leviticus 27:30-32; Malachi 3:10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 430,
                    Question = "JKVuklqCGVN6Pv1HEmNxJdLM5N/giJun7AkhYzNkNVdhLMI3aToTj8xG8oxnHs++sIgE1NVxutfZ45iZYfRT10yQ29IBIogl8ri4tnXbqXiOgKLbxO2/fDXILK0u9Dw+",
                    AnswerHash = -378172777,
                    RawAnswerCount = 1,
                    RawAnswer = "6U/6aSvhtB4y0Gy/btlDG3SLANwLunhnOlQt/xvM5/fa5AS8iuAPCokLPu8UoFo3",
                    WrongAnswers = new List<string> {
                        "PyJvfO5rWkwnJ5U/V4aaonR9M6IwGMXkNCPHk4OPQrI=",
                        "8QvYE1WWW4Sg5WoA33vzsP58EhH7tL1g8WR0eCEj3ow=",
                        "TTxmnZE17hKIGyjmQTJ6wnYMs1yK85s1lpI6ZMl50ak=",
                        "OmaMIWesJxgqlcLWUP2Kjl2juHOwiS2fblNtz3//tMo=",
                    },
                    Passage = "Genesis 14:18-20",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 431,
                    Question = "oyPQ1LTFuXssZO8Ak5m4QZw9b4d5zSnZpxxCO0BhJF0=",
                    AnswerHash = 28128397,
                    RawAnswerCount = 13,
                    RawAnswer = "IdBCqZj64qqX06LqC5GMfJw2/ppatFnafHuDlpv7kAqMGCjjxRqBQY91yv4XMh7L+vYCH1hejOUk2JfL7Ghd4w9nBRhXcnxZsa3oPAurtss=",
                    WrongAnswers = null,
                    Passage = "Malachi 3:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 432,
                    Question = "SnT5k4hjVmGLTXFhb8Le/6HIEG00p6Ys2Gdsl8mFRR2Xl9lKvEvoxJJrNznp6z5yMCdRgc6x1+pMpNcHyzEKew==",
                    AnswerHash = -981834559,
                    RawAnswerCount = 15,
                    RawAnswer = "bn3xdIaGvdt/cCwL0JuZsrkqdTxJlGtxRQuYFG22rgoQstwPln9z5Co/2ahtDiiZWd4vrTw19vUcj4bZbmfZjbmGYc8LVhSrWtwuJgu0S4X8YE1v1ScCZgTiF14Gtoew",
                    WrongAnswers = null,
                    Passage = "Colossians 2:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 433,
                    Question = "uS8apUDSN3SkZxvOpHX3AARR05AVPM/XSphAUrvjBcR6favBcl+/V/ojcUir66JT",
                    AnswerHash = -2037806315,
                    RawAnswerCount = 1,
                    RawAnswer = "qdDt4J+uCg1pX2HLmBqKXPvhGcCtApMJF5bGzi3WUNI=",
                    WrongAnswers = new List<string> {
                        "v8JWfitGBYzmCzoLkCx12YC9gVIp4yZPy47DsfuCWhc=",
                        "9e8cuq+m95k6KbPQpkR4x50qi31V8IvtLobMqSZvo50=",
                        "rCuJcXnJlplyiCJGni958hmeULKHAAYXB7Zb023yNto=",
                        "Z2My12jCA5SV7+sfQNXr+yxjioOzRXMeCYgKUKId2V4=",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 434,
                    Question = "QLoenMVj+xLgtTdBy1cAsJmbb2efcyEjUyaw86ebKvIRgtQ2YQXDIaVxWI5gVXDrfcaxOEtyjpq4QueWOisoyA==",
                    AnswerHash = 208674884,
                    RawAnswerCount = 13,
                    RawAnswer = "E6d12wRPOLMl5LEq0xVaBayyH/ZvisLWTSySyKQ0udF4ALNWz3NA42nj7T6BYUHY6IzfZhPDb+QI23K8EW9Hzg==",
                    WrongAnswers = null,
                    Passage = "Romans 6:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 435,
                    Question = "FEJxcejYoh7Gjg90eUbt9Ovd4vwPbhG8JwIg3pouoi8YJ4ceM4tLmFD8iPS4HlC1",
                    AnswerHash = -1012239948,
                    RawAnswerCount = 9,
                    RawAnswer = "pszlVeJ0iVdMDuwEeX2FFd2cveaR/Sh9waFb/2QV22W1WDLB54c6uGMziqu2pvZ9YlM2yMVXc3ZCz5qBRKfREg==",
                    WrongAnswers = null,
                    Passage = "Acts 2:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 436,
                    Question = "c5SP8rxI7HwnKdKof3n7USF8zpWukzCAs5cfn2zOoIpF2+/ouS6eOyoAha0ZRXOE",
                    AnswerHash = -957806305,
                    RawAnswerCount = 1,
                    RawAnswer = "knDwcmB1rmo8vXYTsgs38YZ0TEYaPweY/4O36HLyxto=",
                    WrongAnswers = new List<string> {
                        "pl0KD4OYNAz5DXFmNJuWNXJi11S2+999ghzedLY2HhQ=",
                        "pbypsfu+IWtRaP7zMXM3og==",
                        "e0EYCkDq6KlmEfTddTj6Ow==",
                        "kLBJpJLEOHgKfva284Awhg==",
                    },
                    Passage = "Acts 8:38",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 437,
                    Question = "vvotFBIjhoQijo8h8SRrg+r2lQF7JS3nCr6C+UQaV6PI/F9ApvNDsXzFKEEJ4Jp0",
                    AnswerHash = -1425576699,
                    RawAnswerCount = 13,
                    RawAnswer = "XbOrs7HbSmHOTs2EU5/3INia3cMnzAmUxJsORIBRmdu13aZtuqbxthvGQeY0bA/X+IMPSou2FSOw+kfZ5sayrA==",
                    WrongAnswers = null,
                    Passage = "Matthew 28:19",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 438,
                    Question = "ClI5L2BGCvyryp562YYXNVgrK2HPTDrF8RZGsgZQqAcgAAR196Iuu2hClR9kD3nq629fJdpmMA/uk1zlJ9ZAEw==",
                    AnswerHash = -88429222,
                    RawAnswerCount = 19,
                    RawAnswer = "8/Zo3kNT6XcO8912DHr3pF4l2ob53ESPxE5j4wGpNwBqkOLahs2kE0XuKa+LtehxpzbpM/eF3wiqVV54n+5nQROs3sBtyqEl+IVScTtWd+fq2Bu42DnKTwfgIoKAdWe7BAVshhBDP9AKibXeYPHfAw==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:24,25",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 439,
                    Question = "yNetPfpNLMztoHNib1rvauxWvpxAeM4tkZytThLeANpBr3LL9WqagxxO/NdhWJJnQfRwjERmXSpjBvfj/aFT6MWdblsEAgZN16V31qkQIRWUoEGwJVb15EYQYyoN5I/W",
                    AnswerHash = -1911014543,
                    RawAnswerCount = 21,
                    RawAnswer = "17hXIawpEJS/kYTCEVCHfMr6FMIh3PFPpEj3mPb5O2MkW2Si7pv2hbDRQSzxNCfGmXPRSKs/71iZbThFDH1egbedV9ObbvaI8UDHwfGprTQ3mlLViG21UHsAr1+DNUjvJ3srqK8mpb1A1PxsyKSjzA==",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 11:26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 440,
                    Question = "VpLH/ieKcxHA/j94clF0+y0r8qGZ973P2EC0oCcqCWu4TMOI+8Fr0Djk4nVJ29ubgBpvA4FdFxOH8YCn1AerG6oXbchNEEqS/htUTrBCDuk=",
                    AnswerHash = 2022241095,
                    RawAnswerCount = 1,
                    RawAnswer = "ln96re4pBlnsnKRaVRTCOTDbFFX5240t3j13dx4W3WUcKUbBPlDLJnSvx7hUSgxX",
                    WrongAnswers = new List<string> {
                        "FCcPkyuflAl9jZgb3vT8EUlFHeKhyY66NOnwe0RgpM8=",
                        "mPMY6vmdS+M0wa83QcWxmD+7HpYmRVljb3MveHTHYjI=",
                        "QVnx1kCk3+mvFFXyBB9ieoYsaS805CN5IrFZHvkaPVY=",
                        "+AmuxQSzdh4BQlUHWgfqb8l6yAfE7vqw970yve/iNTI=",
                    },
                    Passage = "1 Corinthians 11:28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 441,
                    Question = "avA4EynEJb4WHrgUxVLR9QoWFrG3+WHLhNy/txyol/qbj15ZP0wlcDtgKsBU7cl8",
                    AnswerHash = -766004647,
                    RawAnswerCount = 1,
                    RawAnswer = "xZbyP1OL8pLNcObTsooiMC2iqIcse5oLXT/Uk9Hh515z+3JdCRW3O1GjGQc3GKXo",
                    WrongAnswers = new List<string> {
                        "Y0H/tss+UYfYhMa3MZup2yWbK2XpqKg9bcBbHNLjokk=",
                        "YHfp0RJF3KmQ4u9Pwr+TbgYQwwI2hhMGZQUBW4lGONs=",
                        "VyKmwtwkR8OYWscgGwCAgS5Wmsl6b5HhpVvCfzi7TP0=",
                        "RQKP2TEMVMhoOmk6osAOZ6jmrn8eFJrcK1uLc4sHWvU=",
                    },
                    Passage = "Romans 5:12; 8:18-23",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 442,
                    Question = "C0fe3Xub7CogT5g69qi5C6/JlC9XxM0VZw8T1AAFIuxaddYs723SqhQctkju7sjl5yfB4x/f5WTqTlm7e8HQRQ==",
                    AnswerHash = -1542019523,
                    RawAnswerCount = 8,
                    RawAnswer = "dNTnWTIHOQtvgOuGK9uqsHmBxZ5yXXZVV+QNjrDWYnSb2Ur1207jMkLt/PMwhQSwkLNgfnErEMwCxSd0F/hWHQ==",
                    WrongAnswers = null,
                    Passage = "Isaiah 53:4,5; Matthew 8:17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 443,
                    Question = "frMruH2Ykew3klBnpcRbUE8LIVKkkD5W7LWttnbhgW4RRUtcWxsEdGVDjt3EgKNE",
                    AnswerHash = -852533159,
                    RawAnswerCount = 9,
                    RawAnswer = "wyjxOmYizu/04RNmcNUl8bRjp5JPVgul6hJTW64Iz1iLVlwG24t9azppfJs3DAeLFHUp9l2B2kGhm18WnP1lQQ==",
                    WrongAnswers = null,
                    Passage = "Acts 2:22",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 444,
                    Question = "A91wMMrY9WkJoOqC03Td6nB2BUavtXp3sH4oE+npkr2+7gaxa0JI6qAnofv+FnoI",
                    AnswerHash = -1934458751,
                    RawAnswerCount = 12,
                    RawAnswer = "yLMW0+lvHM9HlULPg7SKUgTixlBYHC5wO/2HrMZbHngVWp2aYc3G0V2eKL3SBI3TI46dZYwQe8iayD34U/GSNZCKNZPoFI+Mh//CZk11Nzg=",
                    WrongAnswers = null,
                    Passage = null,
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 445,
                    Question = "eOP+yabuJ4AX54Dbu/gk65HkfeGqyy3IVP66As4jFysojZcmPgZXfB2EMJhwcXi0ndBhZRttJSEobR7um7cG6g==",
                    AnswerHash = 1409199661,
                    RawAnswerCount = 18,
                    RawAnswer = "ht2PHLX3DemJf5BURIHd7AMV18eEJx9aamsNqNQgytsB2D7QQooVwIQL1JIX3ycXBmv1WOv2SAM8Pso9qbUGCvBIKv+UdVRJiBDxvu69EX1N8FphJLhcSAqXtkZyVWma",
                    WrongAnswers = null,
                    Passage = "James 5:14-16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 446,
                    Question = "oaZdOVH+gXHFNZH9ha6+cOD4F5J0ZiLljb6nPeqa4dC0LzKIv/w9mOfemxzFZaAL",
                    AnswerHash = 9431484,
                    RawAnswerCount = 5,
                    RawAnswer = "dnszg8KfshWIjH3qkBmBx9EA5Ariv+Vr4bfENBti0Sc=",
                    WrongAnswers = null,
                    Passage = "Titus 2:13",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 447,
                    Question = "Sh7dt6gMeDLFYUPQJRVQATJme6y0GbzndYLgsgnQntU=",
                    AnswerHash = -999447801,
                    RawAnswerCount = 16,
                    RawAnswer = "nqnWTMhQQaEtWZeaKr5fZouaL+trNCOd5FI4tnnoIwGRSxQ+1i8JNqqcINQ+rwx9FedBhNWBj0jrWCcDXmChc3Gfyi1afjVfXC6IuPm2jLWHXTfdmw1HawIMi0t7aSLyhCK+6s1fjwlXk0iOVaxUHg==",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 448,
                    Question = "R8wzkPPt8gBtaxermtHRsOJBy1tS2++SSVQ9WT98X4Cu0wLf5U5TS6VBmg/GyzUE",
                    AnswerHash = -99939557,
                    RawAnswerCount = 1,
                    RawAnswer = "QYI4OxaFcFrhy2CkpIUcvcbZm/V8m9JnM5PZW7wtJtM=",
                    WrongAnswers = new List<string> {
                        "gdX+AbOERQG3m0vnEnZb8A==",
                        "HSsSnJrEysMTKbrblevW2g==",
                        "bFrMIES5spJlNsZ33TWC0TWlmUpr3PbZE1LrYywK6L4=",
                        "X3oW7b1K9DcK1YDmBDWUnw==",
                    },
                    Passage = "Matthew 24:36",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 449,
                    Question = "FDZOJfMjVL/gRaF9BMlhWSBwteFHl7ashkVK1c2DdTU8dE/IT4HWF7+PLiviKLUrsOrsb8BrvDgRqSjEVubzzg==",
                    AnswerHash = -1103975594,
                    RawAnswerCount = 8,
                    RawAnswer = "kFTuOnnRiQvf2sgnT2k0SGitXcxnM3+lIsVEAqjE3Z/O6asXJYwjt1QHK1lEqigA",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 5:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 450,
                    Question = "Rt01oowR2M1wMlEeIy+eNhCL2uDAc67xpiCmWYhkfJCWGSR3x4pqJJK2EUjnBRVM0EPQQVe6jgKC835KwdLwChR3V5zMd7LQjIESyNNGV7k=",
                    AnswerHash = 407289473,
                    RawAnswerCount = 11,
                    RawAnswer = "03Yex1+X9X8AYsflnrZ5wi5pJ9DVFwfWCfw+CoeQHSpNJonAmP0u6j30R5uc2VxKsZ9hYmkcZiFJbmR+i1iF3w==",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:10; Revelation 19:7-9",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 451,
                    Question = "axtOP1+oR7LBI/9D2c0dAvwy3PKzCp0TOH3kWxm4710=",
                    AnswerHash = 107199506,
                    RawAnswerCount = 15,
                    RawAnswer = "PBlKabqFLXbTpG790EJgndRT2KhdU5FOxZeVB/GZsQBmnZZ9vbrJjCcs0/KsYuydSat6/HJeay4VpECRIQZpiZ0oIe7QpTcTkk1tQSD392QjHR+O8eZj9Ts5GWxBnpAO",
                    WrongAnswers = null,
                    Passage = "Matthew 24:21",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 452,
                    Question = "jK39/8VSboAuztXPmERszXDX0/PCEa7/Gipz+LND4XA/7KBOTcOs0vEoI6IMctSfeWNL3E7xz8boSmEQE7HTrw==",
                    AnswerHash = 719391859,
                    RawAnswerCount = 22,
                    RawAnswer = "V54XEupvwbYBj3ITmHeowJhlQ9+nt03v0Ei84FRZjw0vPdJi+xsj930037UtROKo67RtoRxPc1amR8bu547u7iLJQGlMTiT2H8d0NuTFU8xOY4hvvo0whLo2a56OObAzTQlR3eGozqxBT+E3JHdsJWOOromRwQo+m+w1dDGygqs=",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:3,4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 453,
                    Question = "VerhZ36lqMY2+Icns/clqmqef8e8P4/9TdF8lxM8BeM=",
                    AnswerHash = -1346389460,
                    RawAnswerCount = 15,
                    RawAnswer = "JmgqUPInXetp9fuN4+ETVGziKFRB+G3pLwUwg6q1CJiTg0bMgDYZKyRYOTLQQfbdemxI8PFoOXLY8O6WgSEABMUxis75dXDR6DA/IVm55Nisi8bwWhEfzrCqCAxU+K0S",
                    WrongAnswers = null,
                    Passage = "Revelation 20:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 454,
                    Question = "9W73h8L2rbV5v1eVSSJQFlSoc7gJiv57+v52DSzTwkkEpsckeOUCYm4ij6liiAjLy4OXJGegVpRK4tEGWwewlQ==",
                    AnswerHash = 31815922,
                    RawAnswerCount = 14,
                    RawAnswer = "TYgDhemh3+OgyNVW0JkMwBLpsgziDE114o6rg6CGuSn4krxUqO0bjLOZd/gN8UI93+0QB2sXn6kSrl348w6H2tIv94oA4R9Mtk1pheYqOp0=",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 455,
                    Question = "9W73h8L2rbV5v1eVSSJQFnr/ey7xMN0gUZPHKkV50VMosILbP2i97TNm7tIHfGfYCQAX29J4GlRf5cXYtvVIeg==",
                    AnswerHash = -816343237,
                    RawAnswerCount = 18,
                    RawAnswer = "F6Wil/UH7SAXi+1nG8qpC8XX9+DYgldyfx1MtGO9s5+BjleabKPY7NLYx95JiMdDZfuEX9umyVA4uovFGyNcSvQhelzuTb43DAZJ/aAzRCYpTIP5+30GHgvIvxzvaDve4pGooEziNp8g5OAD2Lws+A==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:1-3,7-10",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 456,
                    Question = "2UYUTFZXqCxR4y4F/u2HftqA085U5+N2OnuTZKIUOX/A5p4Ip6XvtQw3YoKOHRM8",
                    AnswerHash = -1099126445,
                    RawAnswerCount = 1,
                    RawAnswer = "pQoq3F2l80+RdQzog3XDIG8wYKru/tSQZjsWzszErFk=",
                    WrongAnswers = new List<string> {
                        "xxUAHZpVqHV4WImhPLyDWg==",
                        "Bom+Pg4VSe80xVjZ70jpxLTLN6c/55qM5XWYNrh7z/s=",
                        "iP6ehMsrm8/j2UUUlf+rTVA7tw/FxuhDKzHLi/DGtoI=",
                        "9e8cuq+m95k6KbPQpkR4x50qi31V8IvtLobMqSZvo50=",
                    },
                    Passage = "Hebrews 9:27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 457,
                    Question = "YPq9KiJPYAG+1yQtninDIA==",
                    AnswerHash = 1060830329,
                    RawAnswerCount = 23,
                    RawAnswer = "aHZ8F0nd9mBoytdnAL/J+UmmrUkMBZJxGWc/MLbLdvv25LSvaglLX0J4usAdx27g/CwN4zrxfrJ9qcwNcf0dtFROCWvVWyU/52PWdpcOFYkbeAT7PjW7PenpHBwPofTFGIPmU6zMQVasCydeoe6GA44pXnJR2NSgIDD4dk+KDKQ=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:34",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 458,
                    Question = "7mg8hmGuNAZueh33lT61OECCfn1r2S4+en6FtdVFZsu7tA2SvEZ8j/ZdgiNPjAqbK9rNHFJBE1sQzcTtyM8+dQ==",
                    AnswerHash = -1350496365,
                    RawAnswerCount = 4,
                    RawAnswer = "MGbf0hVuGtCwyuSoH5nfQoGzitNg01MP+Z5fEJPG/rQ=",
                    WrongAnswers = null,
                    Passage = "1 John 3:2,3",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 459,
                    Question = "g84iB5KvPo8mSj4gf1xB9EaFWCiz3sLbmHr7KPSeC9sghvUR4gMlJNKYP46xlhBb",
                    AnswerHash = 1729428622,
                    RawAnswerCount = 18,
                    RawAnswer = "C4dymFq4xSAR4daK94v5OqUTmBhe3fJ1X/99CUwuQ/80mQPLgi7tH8vd+yTQzITtEI0laTRDXku88M5+ZnnDKT+aBeNv22pEGFV1uxZ2ITaL+xWENhBf1SZLbVA0HEPbzJ0C3jloGpi9Mase4xHP8g==",
                    WrongAnswers = null,
                    Passage = "Revelation 21:27",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 460,
                    Question = "6kTEc5cFFSpqQdRffxqNuegJbjc/XM+eb4vGdbKikt5ale92Z3/cXdVTuY6xQ1LzG7TIF0rm1wE4SvVW0wOKmg==",
                    AnswerHash = -2070791714,
                    RawAnswerCount = 1,
                    RawAnswer = "NarZtLnYu7u6cNLdiZibwtdrS/ezbb0FWWIMNy8ntVwPHg/a4T87uzidP9rgyonY",
                    WrongAnswers = new List<string> {
                        "BQ0/h93PyvHtL3RgOTm4rnsBVIdlgi4BjeZ3aMxxSDE=",
                        "IWc883n5oMnEEvvTNx/Ltk8SUC62LY7wms0F8G5ccW8MrsajNEFvvbYihlg+9WtB",
                        "wQdvXwTme4i+Ra9dwoZOh9y+qPvg+hQAOJ+rFYbB/tM0cHGaqzFVBwagiAGVltLU",
                        "cEq5eg/dflCBDhrK8ihFrVqtf8j9KoKcOtyiR5Q22lEAYtnZ9KyvtrKZHUQ5erwU3RE4z72AqBvdg/uD2reAAQ==",
                        "KYoe/zhHwjppGCJFH1OfOXZPKoN+M1iK/GlI+T5mH8bfSsc/SIYBW3feOjPk32wo6/hcbU0AXRkhokF9TuxYPg==",
                    },
                    Passage = "Revelation 21:4,27",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 461,
                    Question = "OBHakXDKdIbC5Rz5I8DSJWZ5X7D0dozdtLzmXtgUOlUqhb4g+4fV973OuLs644G/",
                    AnswerHash = -1832396045,
                    RawAnswerCount = 1,
                    RawAnswer = "DcVf29yN1NkPsE5ndqnf/Q==",
                    WrongAnswers = new List<string> {
                        "zUw/OjWFABEBEzq5mnKllw==",
                        "QusWy9I0SEArS33WB3RORw==",
                        "Dcd4Ck0PzEta+e0OPf1fOA==",
                        "4BkcdKwe+EeUUnUiRGuJFg==",
                    },
                    Passage = "1 Corinthians 15:25,26",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 462,
                    Question = "J4WmB1Ri/ExotTLjQgg5tg==",
                    AnswerHash = -785147751,
                    RawAnswerCount = 8,
                    RawAnswer = "RzIgNo3PV7kbeklOViZLEzemuTkACX4Tyk78PBGWTje5fT4f2Sxq/VzM71GWPFXw",
                    WrongAnswers = null,
                    Passage = "Mark 9:43-48; Luke 16:23",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 463,
                    Question = "Ohqzw+PJESCSXlQIIFLFBQDb9ADqGMjU4OzS0b0sbaQ=",
                    AnswerHash = 830055934,
                    RawAnswerCount = 5,
                    RawAnswer = "94WDPpT73MohJeyou5Y0QLmwViOU/5GuTFE99QN5Pp4=",
                    WrongAnswers = null,
                    Passage = "Matthew 25:41",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 464,
                    Question = "g84iB5KvPo8mSj4gf1xB9A2+4rw4tJmPbFMj3KIsqxsfEUWc1jzahEII2witUAkX",
                    AnswerHash = -1809333785,
                    RawAnswerCount = 19,
                    RawAnswer = "9p5DcDKT5JHbapwMwGHN1wza64ecnP2HmOxHClDG5LS2dbenUnqdHVFY5OaV9Z102noil+mwImf8PyU9IldfHYRsidFimwCATaky3I+dB+X6CqOSMWGnTS6AY5tWpHGV9MCmvyNZTv/YqylNUzdtSA==",
                    WrongAnswers = null,
                    Passage = "Revelation 20:15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 465,
                    Question = "URii5v4uRV++o7qV61T4RyTnRYOYeMOW9mOvP2J4W5U=",
                    AnswerHash = -780302377,
                    RawAnswerCount = 19,
                    RawAnswer = "KM+wQwtEF4zqdc1O0ZGvMnFXFx46DeyW9GZ231kEUYPVc91BNf6A4Ay2cuc/zfZPRr1iz3g7JDBNlL4niMZyHoyMTvbK8VupGoCRU3h5KVrxRuJhsIiF3iQept4mIU+UbRfhknMUSFqw6zzx+DQypA==",
                    WrongAnswers = null,
                    Passage = "Isaiah 14:12-15; Ezekiel 28:11-18",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 466,
                    Question = "VFEQmqgSFdQZwXVcKAVdoFDl12t389wUOSBss4Xzo0YyW7RtiE+JY2fMZwiNsXOQ",
                    AnswerHash = 2075898975,
                    RawAnswerCount = 15,
                    RawAnswer = "kPZUe6Ldp+KU/5LfI2znPCxJVBda3WnR255E7chofQf305LLhqMTgR1GKRvP3l2yO+0GBykmt4c3COEt2BGn7GRaavklGE69C2D/EK426oT9LXMSkuoKClgRTMSABWHi",
                    WrongAnswers = null,
                    Passage = "John 16:11; Colossians 1:16",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 467,
                    Question = "qqjS+wVv7t1wytU+AEZdVrtMGs3ZiIRJQaV7eqJFaShkmFMWlCVdtksNNUf3bkMs",
                    AnswerHash = -20783939,
                    RawAnswerCount = 18,
                    RawAnswer = "LSPPY2QeT02pdmLaDL1d7P/+a04Rgawqnbcu1yysV0XKqpaYRsZfUswhok2IZD6eV2vi0+hqI8sYrjDIV7vUpO9Dq4x2awbTWhmVfDyUHu4T1EWaXo2sjpcqQW8NhXT9",
                    WrongAnswers = null,
                    Passage = "1 John 4:4",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 468,
                    Question = "MxIydb/L/ZN2HiGkjce2MNkB++MK328qOoSe0mcoDRVLrXPrj0xPF5UkPv588GUKA7yElry/ShFZWJ8VmT/vki2QbogF1JObB6QneQLnKr4/XvKX8rgCq7pYFY131AoN",
                    AnswerHash = -1022029900,
                    RawAnswerCount = 11,
                    RawAnswer = "3iTajpQQ+eEvAp+7hJ5fhA1q1KgFkDc6cUbLllp9jvgPHw6GrnyRahgTgCh2bS58lom8IvnJgAbGysBNsHJesZHi8pfp/Y5f9fAtQFSmkUutYFPm0FpCw4QcqIkQ65Oe",
                    WrongAnswers = null,
                    Passage = "Isaiah 47:12-15",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 469,
                    Question = "R/iXVbgRWSvyztFCyPiLAlPPiNZaWlViumuXUBTDEONPbPyt2jQOArRJwdWPBqBr7JpYOp+EAdYZxuucS3A6sw==",
                    AnswerHash = 1611168946,
                    RawAnswerCount = 12,
                    RawAnswer = "fSAp3QR0DX2R0moh2lVIyDSjCj8m/FZbl5B4A6Du3gmSUi9dJb0lF7TkOH9cjnc6LbBqKUWHtBSywKs3iiRsK5ahAzk6GSjE1zHEyFfgFmI=",
                    WrongAnswers = null,
                    Passage = "2 Corinthians 5:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 470,
                    Question = "J2jQb+1333sKwy6VBokNBHEYx+lBNYvmQo99vM56L3HoogXe8d7xkokSIvK+ixqP1ltZJ2Xgixlp1ridg+RZ/fLObmzjpi1p4kFgct8o+66FtPZwYvIKxSbb5L5B8Ae2",
                    AnswerHash = 1802203448,
                    RawAnswerCount = 8,
                    RawAnswer = "1w4K62bErWiKWcOZ6FsqWaIq36gWrypaXvNmv8gg8rfSbcSNN2To0EdmTUvJevLK",
                    WrongAnswers = null,
                    Passage = "Luke 16:19-31",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 471,
                    Question = "87U9gv/HeJ+s4x9xg/0JW9SRQPMlNToBFad0WMlHy4ldPevTMevtw+4XOhEClJfiQzR2h1IOqqaYPNqM9bRx5PPHDY683LccOI0RPxZ+XLI=",
                    AnswerHash = 1470579416,
                    RawAnswerCount = 19,
                    RawAnswer = "5qOjA8KBQLhFo970Ll50vVAcJZpvlHj1jBLEMyPB6VRxMGAOw3RzPpvU/HcWWTCNv9UspohonB/TZvud787AV1qiszcRjmQPVFgm1QkuFxK444x7I8wE97KF4MKV0sQ5/TXuVYVPoPPTyG1x+1vDYA==",
                    WrongAnswers = null,
                    Passage = "Job 19:25,26",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 472,
                    Question = "TM7eJdeqBP2LF1dW4KLHF4FFPlrbF93ui3rLxDQisEA=",
                    AnswerHash = -712067559,
                    RawAnswerCount = 18,
                    RawAnswer = "H/Da3z5S3YLuXrAkO3hkpENAJxPc1iejTMjT82wI5B/1nP3R90/0C4UU+0ba2KpBMrRnrBLu/ckAUzvBe5wlmBRs2r+0AOYK74XqxWpdnnccxoQ6uUF/9RI/uHu4diu1cMsev2zywkWOjHt6L6mHdGVuTxq6mQGqjsxKuZGVNSM=",
                    WrongAnswers = null,
                    Passage = "John 5:28,29",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 473,
                    Question = "ds5prBVdpF+tKcJJRG2a+MXVEcduf5bziiDcU9GdwYRG9ij95WrqNw5ImesORZPbytGgn8qzjecRRp1PbaIchTyEU3JWVAFuUcbY6NzTbqY=",
                    AnswerHash = -1177164219,
                    RawAnswerCount = 1,
                    RawAnswer = "1v2Yped+k+2/dZDOxhU8Iuv67HINU9Ev2GW00PusZug=",
                    WrongAnswers = new List<string> {
                        "34b7HYetED+u+QQvlZYyzw==",
                        "nOAGus1p2bgkFas7JmqPskH0sIq6jybgeQ3a01CSq30=",
                        "/42r47HHnRwooI8ygkXkJQ==",
                        "WI7pLxZDWrKQsVNXQCb/Dw==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 474,
                    Question = "J7o1aC7PRRJvzYmFK1Jj2VSQT2COwsxF8SUYTdipa6SGZWqSVPcfqZlZ9P23Q0hvf9iisEFhyMEOrnNQ3nK1NZ5bx72mUMhEmqQiAgtnsctmmwBVjkZejoigwoiKMkxuAMz8ikJYOlmVWYuH4BhtEQ==",
                    AnswerHash = 1606322410,
                    RawAnswerCount = 9,
                    RawAnswer = "L47r/ND1El6/4aZFTDoiBo8n8ydH04oD6ykygiQMjUmHktXKWBRv6B/cqhk312Lu",
                    WrongAnswers = null,
                    Passage = "1 Corinthians 15:36-44",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 475,
                    Question = "PqJ/nOjUuEgR3cUkvbMU9YWZIl4AWf6rVtKe8Z1vOJn94sDn3lnKy8TxqTBrQ+kj/5qJl/9SmO2xj3wBbyc3phRgMUsyIRhZc0XbPxXuE95bP71ZzcTIHWa3OWsgMnCt",
                    AnswerHash = 2065748517,
                    RawAnswerCount = 1,
                    RawAnswer = "Y+45oVS1eKrwqLdFRsqqJA==",
                    WrongAnswers = new List<string> {
                        "/E3wBYphgR+gjqwN8ponRA==",
                        "66q+JkzA+9oH220BNdqNtw==",
                        "yrK7s01k6oTkz+x7/i8V1g==",
                        "K3kRvPeAjkGNTt8CRIpNEA==",
                    },
                    Passage = null,
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 476,
                    Question = "457XqpAhCATKKUrB33LHn5hS4XKMr+kyE/8Pav/iKruxXJzoD1sxbpBGfGZU5qOOJdXbI8O/mhw7wZrUCxiMEw==",
                    AnswerHash = 998397720,
                    RawAnswerCount = 6,
                    RawAnswer = "eYLSNdonD78wpqpfM3Wn87FPtfaf90wFN9mHfGs2Oj0=",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 477,
                    Question = "uUG8hRdvOGDF3laJunOJZ7WTDeprezxxzlmbEjyXK5lI+NcwignNkRjjW0l2YH4ahgITUzUadVzlvYYDOHrA9acEwx2eVnlndq72gOCbgZM=",
                    AnswerHash = 2002780351,
                    RawAnswerCount = 1,
                    RawAnswer = "z7Nz74jtSINEKs4+1eCM+w==",
                    WrongAnswers = new List<string> {
                        "XA+NJV6TQacCDG5HYnXknA==",
                        "qGn40Fb8aksZovhYGf0j8w==",
                        "wMA8StK/tju0YEbV5Ui/swPIA/76G8bnF9dqd8a8Vec=",
                        "D+sTdqhKjiWO75U5bu4s5A==",
                    },
                    Passage = "Luke 17:26-28",
                    Type = QuestionTypeEnum.MultipleChoice
                },
                new RawQuestionInfo {
                    Number = 478,
                    Question = "jK39/8VSboAuztXPmERszXDX0/PCEa7/Gipz+LND4XCosjOj5uW7ar6UN+oF1aLcQaCQuT0NEdQ5EDCjxxkvaw==",
                    AnswerHash = -1627976059,
                    RawAnswerCount = 16,
                    RawAnswer = "RW5ThSDVBNlD4+FNtSPP0ZhyvO8Sv0lrOpf8XBmmeSD8yeLk8M8HNaginXZCl3B3yBlpjEvT2S+Zd7KAjSVVYputkvB0FhWD4lI8Op84GVWw61Do66wru9btFZY/cNIk",
                    WrongAnswers = null,
                    Passage = "2 Thessalonians 2:8; Revelation 20:4-6",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 479,
                    Question = "qN3waB+2ETxeeSYzooAK41uqQvm/UEC5LIATEe43YpS/pRXpecZNyfb4WUY6I3JfucPa4dcvaw6EWymrxKYXvQ==",
                    AnswerHash = 678729485,
                    RawAnswerCount = 5,
                    RawAnswer = "RmimiiPdNhYks0we2C/aQeYYergECk6rX3vfFvp7ndPtQQntdmu8qYkF5sQGZVOa",
                    WrongAnswers = null,
                    Passage = "1 Thessalonians 4:16,17; 2 Thessalonians 2:8",
                    Type = QuestionTypeEnum.Jumble
                },
                new RawQuestionInfo {
                    Number = 480,
                    Question = "32F8KLeFLkqqMaQ9j3HAoyQ7VvnpUd+nffNuMu6ij2i+rHPeddxG53rWmwdEAX2JxHO1HvYimOqLATeE0tg6FhAD8ezz/4OlcLLbf1FmovZiC8WWCJNePRNBllTXu/qevMTCsW/SN4C+T1UCs0v+zg==",
                    AnswerHash = -315100389,
                    RawAnswerCount = 10,
                    RawAnswer = "4/wpKNCzeci8mb50i2PZTKronM+j6CpwEByE5scbc2sAIFkHZaGEPSMi6nhhrfUXsX6C9WXxgvuIUm9Z8r8YWA==",
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
