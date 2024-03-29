// DONE GET all items
// DONE POST add an item
// DONE GET each item (id)
// DONE PUT update an item
// DONE DELEtE delete an item
// DONE GET all items that are out of stock
// DONE GET items based on SKU

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InventoryAllTheThings.Models;

namespace InventoryAllTheThings.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllItems()
    {
      var db = new DatabaseContext();
      return Ok(db.Items);
    }

    [HttpGet("{Id}")]
    public ActionResult GetOneItem(int Id)
    {
      var db = new DatabaseContext();
      var oneItem = db.Items.FirstOrDefault(i => i.Id == Id);
      if (oneItem == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(oneItem);
      }
    }

    [HttpPost]
    public ActionResult AddNewItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, Item item)
    {
      var db = new DatabaseContext();
      var prevItem = db.Items.FirstOrDefault(i => i.Id == id);
      if (prevItem == null)
      {
        return NotFound();
      }
      else
      {
        prevItem.SKU = item.SKU;
        prevItem.Name = item.Name;
        prevItem.ShortDescription = item.ShortDescription;
        prevItem.NumberInStock = item.NumberInStock;
        prevItem.Price = item.Price;
        prevItem.DateOrdered = item.DateOrdered;
        db.SaveChanges();
        return Ok(prevItem);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(i => i.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }
    [HttpGet("OutOfStock")]
    public ActionResult GetOutOfStock()
    {
      var db = new DatabaseContext();
      var outOfStockItems = db.Items.OrderByDescending(i => i.NumberInStock == 0);
      return Ok(outOfStockItems);
    }
    [HttpGet("BySKU")]
    public ActionResult GetBySKU(int SKU)
    {
      var db = new DatabaseContext();
      var itemBySKU = db.Items.FirstOrDefault(i => i.SKU == SKU);
      return Ok(itemBySKU);
    }
  }
}
