using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using BeaconIdentifierApp.Models;

namespace BeaconIdentifierApp.Adapter
{
    public class DiscountsAdapter : BaseAdapter<Discount>   
    {
        protected Activity Context = null;
        protected List<Discount> Discounts; 

        public DiscountsAdapter(Activity context, List<Discount> discounts) : base()
        {
            this.Context = context;
            this.Discounts = discounts;
        }


        public override long GetItemId(int position)    
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return Discounts.Count;
            }
        }

        public override Discount this[int index]
        {
            get { return Discounts[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ProductViewHolder holder = null;
            var view = convertView;

            if (view == null)
            {
                view = Context.LayoutInflater.Inflate(Resource.Layout.discount_row, parent, false);

                holder = new ProductViewHolder();
                holder.Name = (TextView)view.FindViewById(Resource.Id.tv_name);
                holder.Price = (TextView)view.FindViewById(Resource.Id.tv_price);
                holder.Region = (TextView)view.FindViewById(Resource.Id.tv_region);
                holder.Discount = (TextView)view.FindViewById(Resource.Id.tv_discount);
                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as ProductViewHolder;
            }

            var item = Discounts[position];
            holder.Name.Text = item.OfferText;
            holder.Discount.Text = $"Discount:{item.DiscountPercentage}%";
            holder.Price.Text = string.Format("Original Price: {0:C}", item.OriginalPrice) + "$";
            holder.Region.Text = item.AssociatedBeacon.AssociatedRegion.RegionName;
            return view;
        }

        private class ProductViewHolder : Java.Lang.Object
        {
            public TextView Name { get; set; }
            public TextView Price { get; set; }
            public TextView Discount { get; set; }
            public TextView Region { get; set; }
        }

        public void UpdateData(List<Discount> discounts)
        {
            Discounts.Clear();
            Discounts.AddRange(discounts);  
            this.NotifyDataSetChanged();
        }
    }
}