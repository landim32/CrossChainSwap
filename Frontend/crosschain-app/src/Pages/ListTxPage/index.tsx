import Table from 'react-bootstrap/Table';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/esm/Container';

export default function ListTxPage() {
    return (
        <Container>
            <Row>
                <Col md="8" className='offset-md-2'>
                    <Card>
                        <Card.Body>
                            <h1 className="text-center">Latest Swaps</h1>
                            <hr />
                            <Table striped bordered hover size="sm">
                                <thead>
                                    <tr>
                                        <th scope="col">Swap</th>
                                        <th scope="col">Wallet</th>
                                        <th scope="col">Latest Update</th>
                                        <th scope="col">Amount</th>
                                        <th scope="col">Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td colSpan={5}>
                                            <div className="d-flex justify-content-center">
                                                <div className="spinner-border" role="status">
                                                    <span className="visually-hidden">Loading...</span>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </Table>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
}