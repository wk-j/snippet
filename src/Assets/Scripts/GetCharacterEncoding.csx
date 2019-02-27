// Print the header.
Console.Write("Info.CodePage      ");
Console.Write("Info.Name                    ");
Console.Write("Info.DisplayName");
Console.WriteLine();

// Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
foreach (EncodingInfo ei in Encoding.GetEncodings()) {
    Encoding e = ei.GetEncoding();

    Console.Write("{0,-15}", ei.CodePage);
    if (ei.CodePage == e.CodePage)
        Console.Write("    ");
    else
        Console.Write("*** ");

    Console.Write("{0,-25}", ei.Name);
    if (ei.CodePage == e.CodePage)
        Console.Write("    ");
    else
        Console.Write("*** ");

    Console.Write("{0,-25}", ei.DisplayName);
    if (ei.CodePage == e.CodePage)
        Console.Write("    ");
    else
        Console.Write("*** ");

    Console.WriteLine();
}