// DONE GET all items
// DONE POST add an item
// DONE GET each item (id)

// TODO PUT update an item
// TODO DELEtE delete an item
// TODO GET all items that are out of stock
// TODO GET items based on SKU

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
  }

}
