﻿using System;
using System.Collections.ObjectModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Опрос.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
	public class Poll : MediaAttachment
    {
		/// <summary>
		/// Опрос.
		/// </summary>
		static Poll()
      	{
      		RegisterType(typeof (Poll), "poll");
      	}

	    /// <summary>
	    /// Дата создания опроса
	    /// </summary>
	    [JsonConverter(typeof(UnixDateTimeConverter))]
	    public DateTime? Created { get; set; }

	    /// <summary>
        /// Вопрос, заданный в голосовании.
        /// </summary>
        public string Question { get; set; }

	    /// <summary>
        /// Кол-во ответов
        /// </summary>
        public int? Votes { get; set; }

        /// <summary>
        /// Идентификатор выбранного ответа
        /// </summary>
        public long? AnswerId { get; set; }

	    /// <summary>
	    /// Варианты ответов
	    /// </summary>
	    public ReadOnlyCollection<PollAnswer> Answers { get; set; }

	    /// <summary>
        /// Возможность анонимых ответов
        /// </summary>
        public bool? Anonymous { get; set; }

	    #region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Poll FromJson(VkResponse response)
        {
			var poll = new Poll
			{
				Id = response["id"] ?? response["poll_id"],
				OwnerId = response["owner_id"],
				Question = response["question"],
				Created = response["created"],
				Votes = response["votes"],
				AnswerId = response["answer_id"],
				Anonymous = response["anonymous"],
				Answers = response["answers"].ToReadOnlyCollectionOf<PollAnswer>(x => x)
			};

			return poll;
        }

        #endregion
    }
}