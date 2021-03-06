﻿using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class GiftsCategory
    {
        /// <inheritdoc />
        public async Task<VkCollection<GiftItem>> GetAsync(long userId, int? count = null, int? offset = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Gifts.Get(userId, count, offset));
        }
    }
}