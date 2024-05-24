-> main

=== main ===
Welcome to our world, Traveler!
    + [Where am I?]
        -> chosen_where
    + [Who are you?]
        -> chosen_who
    + [Why am I here?]
        -> chosen_why

=== chosen_where ===
You are in the mystical land of Elaria, a place where magic and adventure await at every corner.
    * [Tell me more about Elaria]
        -> more_about_elaria
    * [What should I do next?]
        -> next_steps
    * [How do I leave this place?]
        -> how_to_leave

=== chosen_who ===
I am the Guardian of Elaria, here to guide lost souls like yourself.
    * [What is your purpose?]
        -> guardian_purpose
    * [Can you help me find my way?]
        -> guardian_help
    * [Are there others like you?]
        -> others_like_guardian

=== chosen_why ===
You have been chosen to fulfill an ancient prophecy. Your presence here is no coincidence.
    * [What prophecy?]
        -> prophecy_details
    * [How do I fulfill this prophecy?]
        -> fulfill_prophecy
    * [What happens if I refuse?]
        -> refuse_prophecy

=== more_about_elaria ===
Elaria is a land of diverse landscapes, from lush forests to towering mountains. It is home to many magical creatures and ancient mysteries.
    -> main

=== next_steps ===
Your first task is to find the Elder of Elaria in the nearby village. They will provide you with further guidance.
    -> main

=== how_to_leave ===
Leaving Elaria is not simple. It requires a special ritual performed at the Temple of Light. But first, you must prove yourself worthy.
    -> main

=== guardian_purpose ===
My purpose is to protect Elaria and guide those who are destined to play a role in its future.
    -> main

=== guardian_help ===
Yes, I can provide you with a map and some advice on where to start your journey.
    -> main

=== others_like_guardian ===
There are other guardians, each with their own duties and territories to protect.
    -> main

=== prophecy_details ===
The prophecy speaks of a traveler who will bring balance to Elaria, restoring peace and harmony to the land.
    -> main

=== fulfill_prophecy ===
To fulfill the prophecy, you must undertake a series of quests that will test your courage, wisdom, and strength.
    -> main

=== refuse_prophecy ===
If you refuse, the land of Elaria will fall into chaos, and you may never find a way back to your own world.
    -> main
