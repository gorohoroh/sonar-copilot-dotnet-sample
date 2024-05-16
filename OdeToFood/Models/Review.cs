using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OdeToFood.Models;

public class Review
{
    public int Id { get; set; }

    [Required, Range(1, 5)]
    public int Rating { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    [StringLength(256)]
    public string ReviewText { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual IdentityUser User { get; set; }}