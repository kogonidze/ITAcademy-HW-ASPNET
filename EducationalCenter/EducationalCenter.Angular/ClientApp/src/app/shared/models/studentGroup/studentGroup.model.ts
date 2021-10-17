import { Faculty } from "../faculty/faculty.model";

export interface StudentGroup {
    id: number,
    title: string,
    facultyId: number | null,
    faculty: Faculty,
    startYear: number,
    endingYear: number
}