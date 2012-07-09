using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural
{
    /*
     * DDD (page 463) has:
     * Decision
     * Policy
     * Operation - orchestration
     * Potential - commands, query, etc
     * */

    /*
     * http://ayende.com/blog/154145/limit-your-abstractions-all-cookies-looks-the-same-to-the-cookie-cutter
     * Here is the list of common abstractions that I gave before, this time, I am going to go over each one and explain it.

        Controllers – Stand at the edge of the system and manage interaction with the outside world. Can be MVC controllers, MVVM models, WCF Services.
        Views  - The actual UI logic that is being executed. Can be MVC views, XAML, or real UI code (you know, that old WinForms stuff ).
        Entities – Data that is being persisted.
        Commands – A packaged command to do something that will execute immediately. (Usually invoked by controllers).
        Tasks – A packaged execution that will be execute at a later point in time (usually async), after the current operation have completed.
        Events – Something that happened in the system that is interesting and require action. Common place for business logic and interaction.
        Queries – Packaged query to be executed immediately. Usually only fairly complex ones gets promoted to an actual query object.
     * */
}
