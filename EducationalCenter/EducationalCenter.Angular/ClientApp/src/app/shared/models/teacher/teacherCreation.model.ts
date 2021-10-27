import { Category } from "../../enums/category";
import { Formation } from "../../enums/formation";

export interface TeacherCreation {
    firstName: string,
    lastName: string,
    dateOfBirth: Date,
    email: string,
    phoneNumber: string,
    departmentId: number | null,
    experience: number,
    category: Category,
    formation: Formation,
    salary: number
}