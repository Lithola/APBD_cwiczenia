using Microsoft.AspNetCore.Mvc;
using cw666.Context;
using Microsoft.EntityFrameworkCore;

namespace cw666.Controllers;
using cw666.Models;

public class Med_Centre_Controller : ControllerBase
{
    private readonly MyDBContext _context;

    public Med_Centre_Controller(MyDBContext context)
    {
        _context = context;
    }
}
