using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalData : MonoBehaviour
{
    private static int tickets = 0;

    public static void addTickets(int tix) {
        tickets += tix;
    }

    public static void removeTickets(int tix) {
        tickets -= tix;
    }

    public static int getTickets() {
        return tickets;
    }
}
