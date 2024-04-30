﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InitialProject.Enumeration;

namespace InitialProject.Model;

[Table("ComplexTourRequest")]

public class ComplexTourRequest
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public List<TourRequest>? Requests { get; set; }
    public TourRequestState State { get; set; }

    [InverseProperty("ComplexTourRequests")]
    public List<User>? Guides { get; set; } = new List<User>();

    public ComplexTourRequest()
    {
        State = TourRequestState.Pending;
    }

}