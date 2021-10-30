import { Faculty } from "../faculty/faculty.model";

export interface Department {
    id: number,
    name: string,
    facultyId: number | null,
    faculty: Faculty
}