using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using BeaconIdentifierApp.Core.Models;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace BeaconIdentifierApp.Adapter
{
    public class DiscountsAdapter : RecyclerView.Adapter 
    {
        protected List<Discount> Discounts;

        public EventHandler<bool> OnListChanged;    

        public DiscountsAdapter(List<Discount> discounts) : base()
        {
            if (discounts == null)
                discounts = new List<Discount>();
            this.Discounts = discounts;
        }

        public override int ItemCount => Discounts.Count;

        public void UpdateData(List<Discount> discounts)
        {
            if (discounts == null)
                return;

            Discounts.Clear();
            Discounts.AddRange(discounts);
            NotifyDataSetChanged();

            //Show or Hide empty view
            OnListChanged?.Invoke(this, !discounts.Any());
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if(holder is ProductViewHolder productvh)
            {
                var item = Discounts[position];
                productvh.Name.Text = item.OfferText;
                productvh.Discount.Text = $"Discount:{item.DiscountPercentage}%";
                productvh.Price.Text = string.Format("Original Price: {0:C}", item.OriginalPrice) + "$";
                productvh.Region.Text = item.AssociatedBeacon.AssociatedRegion.RegionName;
            }

        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.discount_row, parent, false);
            ProductViewHolder vh = new ProductViewHolder(itemView);
            return vh;
        }
    }

    public class ProductViewHolder : ViewHolder
    {
        public ProductViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            Price = itemView.FindViewById<TextView>(Resource.Id.tv_price);
            Discount = itemView.FindViewById<TextView>(Resource.Id.tv_discount);
            Region = itemView.FindViewById<TextView>(Resource.Id.tv_region);

        }
        public TextView Name { get; set; }
        public TextView Price { get; set; }
        public TextView Discount { get; set; }
        public TextView Region { get; set; }
    }
}