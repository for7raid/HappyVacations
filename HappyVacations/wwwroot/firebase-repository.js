'use strict'

import { initializeApp } from "https://www.gstatic.com/firebasejs/10.3.1/firebase-app.js";
import {
    getFirestore,
    collection,
    setDoc,
    getDocs,
    deleteDoc,
    query,
    where,
    and,
    doc,
} from "https://www.gstatic.com/firebasejs/10.3.1/firebase-firestore.js";

// Firebase configuration details
// replace this configuration with your own configuration details
import { firebaseConfig } from './env.js';
export function initFirebase(window) {

   

    // Initialize Firebase with the configuration details
    const app = initializeApp(firebaseConfig);

    // Initialize Cloud Firestore and get a reference to the service
    const db = getFirestore(app);

    const collections = {
        teams: collection(db, "Teams"),
        calendarExpeptions: collection(db, "CalendarExpeptions"),
        employees: collection(db, "Employees"),
    };

    window.firestore = {
        getTeam: async function (teamId, teamName) {
            const q = query(collections.teams, and(where("id", "==", teamId), where("name", "==", teamName)));

            const querySnapshot = await getDocs(q);
            let dataArray = querySnapshot.docs.map((doc) => ({
                id: doc.id,
                Name: doc.get("name"),
                Title: doc.get("title"),
                HoursPerSP: doc.get("hoursPerSP"),
                Overheads: doc.get("overheads"),
                OperatingExpenses: doc.get("operatingExpenses")
            }));
            return dataArray.length ? dataArray[0] : undefined;
        },

        getTeamsList: async function () {
            const q = query(collections.teams);

            const querySnapshot = await getDocs(q);
            let dataArray = querySnapshot.docs.map((doc) => ({
                id: doc.id,
                Name: doc.get("name"),
                Title: doc.get("title"),
                HoursPerSP: doc.get("hoursPerSP"),
                Overheads: doc.get("overheads"),
                OperatingExpenses: doc.get("operatingExpenses")
            }));
            return dataArray;
        },

        saveTeam: async function (item) {
            const docRef = doc(collections.teams, item.id.toString());
            await setDoc(docRef, item);
        },

        getCalendarExpeptions: async function () {
            const querySnapshot = await getDocs(collections.calendarExpeptions);
            let dataArray = querySnapshot.docs.map((doc) => ({
                id: doc.id,
                date: doc.get("date"),
                exceptionType: doc.get("exceptionType")
            }));
            return dataArray;
        },
        saveCalendarExpeption: async function (item) {
            const docRef = doc(collections.calendarExpeptions, item.id.toString());
            await setDoc(docRef, item);
        },
        removeCalendarExpeption: async function (id) {
            const docRef = doc(collections.calendarExpeptions, id.toString());
            await deleteDoc(docRef);
        },

        getEmployees: async function (teamId) {
            const q = query(collections.employees, where("teamId", "==", teamId));
            const querySnapshot = await getDocs(q);
            let dataArray = querySnapshot.docs.map((doc) => ({
                id: doc.id,
                Name: doc.get("name"),
                teamId: doc.get("teamId"),
                role: doc.get("role"),
                Items: doc.get("items"),
                HireDate: doc.get("hireDate"),
                FireDate: doc.get("fireDate"),
                YearPlan: doc.get("yearPlan"),
            }));
            return dataArray;
        },
        saveEmployee: async function (employee) {
            const docRef = doc(collections.employees, employee.id.toString());
            await setDoc(docRef, employee);
        }
    };
}